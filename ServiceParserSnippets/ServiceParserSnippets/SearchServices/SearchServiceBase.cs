using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using PuppeteerSharp;
using ServiceParserSnippets.Entities;
using ServiceParserSnippets.Interfaces.SearchServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceParserSnippets.SearchServices
{
    public abstract class SearchServiceBase : ISearchService, IBrowser
    { 
        public ISearchServiceSettings Settings { get; set; }
        public IServiceHelper Helper { get; set; }
      
        protected Browser browser; // обьект браузера
        public bool BrowserIsLaunched { get; protected set; } = false;

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

            if (!BrowserIsLaunched) // чекаем запущен ли браузер, дабы не плодить под каждый запрос обьект в памяти
                await LaunchBrowserAsync();

            Page page = await browser.NewPageAsync();          

            var parser = new HtmlParser();

            int leftToTake = count;
            int pageId = 0;

            while (snippets.Count != count)
            {
                if (cancellationToken.IsCancellationRequested)
                    return snippets.ToArray();

                leftToTake -= snippets.Count;

                var url = FormUrl(searchQuery, pageId);

                await page.GoToAsync(url); // собственно получение обьекта страницы

                var html = await page.GetContentAsync();          
                var document = await parser.ParseDocumentAsync(html); // строим DOM модель

                var containers = GetSnippetsContainers(document).Take(leftToTake);

                GetSnippetsFromContainers(containers, ref snippets);
            }

            return snippets.ToArray();
        }

        protected virtual string FormUrl(string searchQuery, int pageId)
        {
            return $"{Settings.BaseUrl}{searchQuery}{Settings.Page}{pageId++}";
        }

        protected abstract IEnumerable<IElement> GetSnippetsContainers(IHtmlDocument document);

        protected virtual void GetSnippetsFromContainers(IEnumerable<IElement> containers, ref List<Snippet> snippets)
        {         
            foreach(var container in containers)
            {
                var snippet = Helper.GetSnippet(container);
                
                if (snippet != null)
                    snippets.Add(snippet);
            }
        }

        public virtual async Task LaunchBrowserAsync()
        {
            if (BrowserIsLaunched)
                return;

            // Для запроса страницы используется библиотека Puppeteer sharp
            // она позволяет обходить защиту поисковых систем от парсинга
            // подробнее тут https://www.puppeteersharp.com/api/index.html
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision); // грузит браузер через который будут осуществляться запросы 

            browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });

            BrowserIsLaunched = true; // меняем состояние браузера
        }
    }
}
