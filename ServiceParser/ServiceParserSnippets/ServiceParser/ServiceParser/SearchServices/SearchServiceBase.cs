using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using PuppeteerSharp;
using ServiceParser.Entities;
using ServiceParser.Interfaces;
using ServiceParser.SearchService;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceParser.SearchServices
{
    public abstract class SearchServiceBase : ISearchService
    {
        public string BaseUrl { get; protected set; }

        public abstract Task<Snippet[]> GetSnippetsAsync(string searchQuery, int count, CancellationToken cancellationToken);

        protected virtual async Task<Snippet[]> GetSnippetsAsync(string searchQuery, int count, string mainContainerClass,
            IServiceHelper helper, CancellationToken cancellationToken)
        {
            if (searchQuery == null)
                return null;

            List<Snippet> snippets = new List<Snippet>(); // итоговый список сниппетов

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

                await page.GoToAsync(BaseUrl + searchQuery + $"&p={pageId++}"); // собственно получение обьекта страницы

                var html = await page.GetContentAsync();
                
                var document = parser.ParseDocument(html); // строим DOM модель

                var containers = document.QuerySelectorAll(mainContainerClass).Take(leftToTake);

                snippets.AddRange(GetSnippets(containers, helper));

            }

            return snippets.ToArray();
        }

        protected virtual IEnumerable<Snippet> GetSnippets(IEnumerable<IElement> containers, IServiceHelper helper)
        {
            var snippets = new List<Snippet>();

            foreach(var container in containers)
            {
                var snippet = helper.GetSnippet(container);
                
                if (snippet != null)
                    snippets.Add(snippet);
            }
            return snippets;
        }

    }
}
