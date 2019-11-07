using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using ServiceParser.Entities;
using ServiceParser.Interfaces;
using ServiceParser.SearchService;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceParser.SearchServices
{
    public abstract class SearchServiceBase : ISearchService
    {
        public string BaseUrl { get; protected set; }
        private readonly static HttpClient Client = new HttpClient();

        public abstract Task<Snippet[]> GetSnippetsAsync(string searchQuery, int count = 10, CancellationToken? cancellationToken = null);

        protected virtual async Task<Snippet[]> GetSnippetsAsync(string searchQuery, int count, string mainContainerClass,
            IServiceHelper helper, CancellationToken? cancellationToken = null)
        {
            if (searchQuery == null)
                return null;

            List<Snippet> snippets = new List<Snippet>(); // итоговый список сниппетов

            var snippetsContainers = await GetSnippetsContainersAsync(searchQuery, count, mainContainerClass); // получем контейнеры сниппетов           

            // Если токен был передан, то предоставляем функцию отмены запроса
            if (cancellationToken != null)
            {
                var token = cancellationToken.Value;

                // перебираем все контейнеры
                foreach (var snippetDOM in snippetsContainers)
                {
                    if (token.IsCancellationRequested) // проверяем токен на запрос отмены операции
                        return snippets.ToArray();

                    var snippet = helper.GetSnippet(snippetDOM); // хелпер инкапсулирующий в себе логику определения типа сниппета, возвращает обьект Snippet
                    snippets.Add(snippet); // добавляем в итоговую коллекцию
                }
            }
            else
            {
                foreach (var snippetDOM in snippetsContainers)
                {
                    var snippet = helper.GetSnippet(snippetDOM); // хелпер инкапсулирующий в себе логику определения типа сниппета, возвращает обьект Snippet
                    snippets.Add(snippet); // добавляем в итоговую коллекцию
                }
            }            

            return snippets.ToArray();
        }

        protected virtual async Task<IEnumerable<IElement>> GetSnippetsContainersAsync(string searchQuery, int count, string mainContainerClass)
        {
            var source = await Client.GetAsync(BaseUrl + searchQuery); // Запрашиваем страницу
            var html = await source.Content.ReadAsStringAsync();  // приводим к string, дабы построить DOM модель

            var parser = new HtmlParser();
            var document = parser.ParseDocument(html); // строим DOM модель

            return document.QuerySelectorAll(mainContainerClass).Take(count); // берем контейнер каждого сниппета                
        }
    }
}
