﻿using BLL.Interfaces;
using ServiceParser.Entities;
using ServiceParser.SearchEngine;
using ServiceParser.SearchServices.Yandex;
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
        public async Task<IEnumerable<Snippet>> GetSnippetsFromParserAsync(string searchQuery, int count)
        {
            var searchEngine = new Engine();

            var yandex = new Yandex();

            searchEngine.AddSearchService(yandex);
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
