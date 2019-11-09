using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ServiceParser.Entities;
using ServiceParser.Interfaces;
using ServiceParser.Interfaces.SearchServices;
using ServiceParser.SearchService;

namespace ServiceParser.SearchEngine
{
    public class Engine : ISearchEngine
    {
        private readonly List<ISearchService> _searchServices; // сервисы, которые будут обрабатывать запросы
        private readonly CancellationTokenSource _cts;

        public Engine()
        {
            _searchServices = new List<ISearchService>();
            _cts = new CancellationTokenSource();
        }
        public Snippet[] Start(string searchQuery, int count = 10)
        {
            if (!_searchServices.Any())
                return null;

            // создаем массив под каждую задачу для каждого сервиса
            var searchServicesPool = new Task<Snippet[]>[_searchServices.Count];

            // запускаем запрос к каждому сервису из коллекции
            for (int i = 0; i < searchServicesPool.Length; i++)
            {
                searchServicesPool[i] = _searchServices[i].GetSnippetsAsync(searchQuery, count, _cts.Token);
            }

            var result = Task.WaitAny(searchServicesPool); // ожидание выполнения хотя бы одного запроса
            Abort(); // прерываем не завершившиеся запросы

            return searchServicesPool[result].Result;
        }

        public void AddRangeSearchServices(IEnumerable<ISearchService> searchServices)
        {
            if (searchServices != null)
                _searchServices.AddRange(searchServices);
        }

        public void AddSearchService(ISearchService searchService)
        {
            if (searchService != null)
                _searchServices.Add(searchService);
        }

        public void Abort()
        {
            if (_cts.Token.CanBeCanceled)
                _cts.Cancel();
        }
    }
}
