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
        public string BaseUrl { get; protected set; }

        public abstract Task<Snippet[]> GetSnippetsAsync(string searchQuery, int count, CancellationToken cancellationToken);


        //protected virtual async Task<Snippet[]> GetSnippetsAsync(string searchQuery, int count, string mainContainerClass,
        //    IServiceHelper helper, CancellationToken? cancellationToken = null)
        //{
        //    if (searchQuery == null)
        //        return null;

        //    List<Snippet> snippets = new List<Snippet>(); // итоговый список сниппетов

        //    var snippetsContainers = await GetSnippetsContainersAsync(searchQuery, count, mainContainerClass); // получем контейнеры сниппетов           

        //    // Если токен был передан, то предоставляем функцию отмены запроса
        //    if (cancellationToken != null)
        //    {
        //        var token = cancellationToken.Value;

        //        // перебираем все контейнеры
        //        foreach (var snippetDOM in snippetsContainers)
        //        {
        //            if (token.IsCancellationRequested) // проверяем токен на запрос отмены операции
        //                return snippets.ToArray();

        //            var snippet = helper.GetSnippet(snippetDOM); // хелпер инкапсулирующий в себе логику определения типа сниппета, возвращает обьект Snippet

        //            if (snippet != null)
        //                snippets.Add(snippet); // добавляем в итоговую коллекцию
        //        }
        //    }
        //    else
        //    {
        //        foreach (var snippetDOM in snippetsContainers)
        //        {
        //            var snippet = helper.GetSnippet(snippetDOM); // хелпер инкапсулирующий в себе логику определения типа сниппета, возвращает обьект Snippet
        //            snippets.Add(snippet); // добавляем в итоговую коллекцию
        //        }
        //    }            

        //    return snippets.ToArray();
        //}

        //protected virtual async Task<IEnumerable<IElement>> GetSnippetsContainersAsync(string searchQuery, int count, string mainContainerClass)
        //{
        //    // Для запроса страницы используется библиотека Puppeteer sharp
        //    // она позволяет обходить защиту поисковых систем от парсинга
        //    // подробнее тут https://www.puppeteersharp.com/api/index.html

        //    await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision); // грузит браузер через который будут осуществляться запросы 

        //    // запуск браузера
        //    Browser browser = await Puppeteer.LaunchAsync(new LaunchOptions
        //    {
        //        Headless = true 
        //    });           

        //    List<IElement> snippetsContainers = new List<IElement>();
        //    Page page = await browser.NewPageAsync();

        //    count = 20;
        //    int leftToTake = count;
        //    int pageId = 0;

        //    while (snippetsContainers.Count != count)
        //    {
        //        leftToTake -= snippetsContainers.Count;

        //        await page.GoToAsync(BaseUrl + searchQuery + $"&p={pageId++}"); // собственно получение обьекта страницы

        //        var html = await page.GetContentAsync();

        //        var parser = new HtmlParser();
        //        var document = parser.ParseDocument(html); // строим DOM модель

        //        var containers = document.QuerySelectorAll(mainContainerClass).Take(leftToTake);

        //        foreach (var container in containers)
        //        {
        //            if (container != null)
        //                snippetsContainers.Add(container);
        //        }
        //        snippetsContainers.AddRange(containers); // берем контейнер каждого сниппета
        //    }

        //    return snippetsContainers;               
        //}

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

            List<IElement> snippetsContainers = new List<IElement>();
            Page page = await browser.NewPageAsync();
            var parser = new HtmlParser();

            int leftToTake = count;
            int pageId = 0;

            while (snippetsContainers.Count != count)
            {
                if (cancellationToken.IsCancellationRequested)
                    return snippets.ToArray();

                leftToTake -= snippetsContainers.Count;

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
                if (container != null)
                    snippets.Add(helper.GetSnippet(container));
            }
            return snippets;
        }

    }
}
