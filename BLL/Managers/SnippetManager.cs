using BLL.Interfaces;
using ServiceParserSnippets.Entities;
using ServiceParserSnippets.Interfaces.SearchServices;
using ServiceParserSnippets.SearchEngine;
using ServiceParserSnippets.SearchServices.Google;
using ServiceParserSnippets.SearchServices.Yandex;
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
        public async Task<IEnumerable<Snippet>> GetSnippetsFromParserAsync(string searchQuery, int count)
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

        public async Task<IEnumerable<Snippet>> GetSnippetsFromDbAsync(int count)
        {
            return await _snippetRepository.GetSnippets(count);
        }
    }
}
