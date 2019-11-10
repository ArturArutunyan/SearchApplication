using BLL.Interfaces;
using ServiceParser.Interfaces.SearchServices;
using ServiceParser.SearchEngine;
using ServiceParser.SearchService;
using ServiceParser.SearchServices.Google;
using ServiceParser.SearchServices.Yandex;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Managers
{
    public class SnippetManager : ISnippetManager
    {
        private readonly ISnippetRepository _snippetRepository;
        public SnippetManager(ISnippetRepository snippetRepository)
        {
            _snippetRepository = snippetRepository;
        }
        public async Task<IEnumerable<ISnippet>> GetSnippetsFromParserAsync(string searchQuery, int count)
        {
            var searchEngine = new Engine(); // обьект поискового движка

            #region Settings for services
            var yandexSettings = new YandexSettings();
            var googleSettings = new GoogleSettings();
            #endregion

            #region Helpers
            var yandexHelper = new YandexServiceHelper();
            var googleHelper = new GoogleServiceHelper();
            #endregion

            #region Services
            var yandex = new Yandex(yandexSettings, yandexHelper);
            var google = new Google(googleSettings, googleHelper);
            #endregion

            var services = new List<ISearchService>() { google, yandex };

            searchEngine.AddRangeSearchServices(services);

            var snippets = searchEngine.Start(searchQuery, count);

            if (snippets != null)
                await _snippetRepository.AddRangeAsync(snippets);
                
            return snippets;
        }

        public async Task<IEnumerable<ISnippet>> GetSnippetsFromDbAsync(int count)
        {
            return await _snippetRepository.GetSnippets(count);
        }
    }
}
