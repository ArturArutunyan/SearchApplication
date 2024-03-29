using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using PuppeteerSharp;
using ServiceParser.Entities;
using ServiceParser.Interfaces;
using ServiceParser.Interfaces.SearchServices;
using ServiceParser.SearchService;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceParser.SearchServices
{
    public abstract class SearchServiceBase : ISearchService
    { 
        public ISearchServiceSettings Settings { get; set; }
        public IServiceHelper Helper { get; set; }

        public SearchServiceBase(ISearchServiceSettings settings, IServiceHelper helper)
        {
            Settings = settings;
            Helper = helper;
        }

        public virtual async Task<Snippet[]> GetSnippetsAsync(string searchQuery, int count, CancellationToken cancellationToken)
        {
            if (searchQuery == null)
                return null;

            var snippets = new List<Snippet>(); // итоговый список сниппетов

            // Для запроса страницы используется библиотека Puppeteer sharp
            // она позволяет обходить защиту поисковых систем от парсинга
            // подробнее тут https://www.puppeteersharp.com/api/index.html
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision); // грузит браузер через который будут осуществляться запросы 

            // запуск браузера
            Browser browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });

            Page page = await browser.NewPageAsync();          

            var parser = new HtmlParser();

            int leftToTake = count;
            int pageId = 0;

            while (snippets.Count != count)
            {
                if (cancellationToken.IsCancellationRequested)
                    return snippets.ToArray();

                leftToTake -= snippets.Count;

                await page.GoToAsync($"{Settings.BaseUrl}{searchQuery}{Settings.Page}{pageId++}"); // собственно получение обьекта страницы

                var html = await page.GetContentAsync();          
                var document = await parser.ParseDocumentAsync(html); // строим DOM модель

                var containers = document.QuerySelectorAll(Settings.MainContainerClass).Take(leftToTake);

                GetSnippetsFromContainers(containers, ref snippets);
            }

            return snippets.ToArray();
        }

        protected virtual void GetSnippetsFromContainers(IEnumerable<IElement> containers, ref List<Snippet> snippets)
        {         
            foreach(var container in containers)
            {
                var snippet = Helper.GetSnippet(container);
                
                if (snippet != null)
                    snippets.Add(snippet);
            }
        }
    }
}
