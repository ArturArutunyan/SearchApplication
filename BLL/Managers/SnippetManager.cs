using BLL.Interfaces;
using ServiceParser.Entities;
using ServiceParser.SearchEngine;
using ServiceParser.SearchServices.Yandex;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<Snippet> GetTenSnippetsFromParser(string searchQuery)
        {
            var searchEngine = new Engine();

            var yandex = new Yandex();

            searchEngine.AddSearchService(yandex);
            var snippets = searchEngine.Start(searchQuery);

            if (snippets != null)
                _snippetRepository.AddRangeAsync(snippets);
                
            return snippets;
        }

        public async Task<IEnumerable<Snippet>> GetTenSnippetsFromDb()
        {
            return await _snippetRepository.GetSnippets(10);
        }
    }
}
