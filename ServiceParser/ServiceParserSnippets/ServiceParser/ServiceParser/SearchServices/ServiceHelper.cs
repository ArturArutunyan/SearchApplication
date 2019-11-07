using AngleSharp.Dom;
using ServiceParser.Entities;
using ServiceParser.Interfaces;
using System.Collections.Generic;

namespace ServiceParser.SearchServices
{
    public abstract class ServiceHelper : IServiceHelper
    {
        protected readonly List<ISnippetContainer> _snippets = new List<ISnippetContainer>(); // список хранящий виды сниппетов

        public Snippet GetSnippet(IElement snippetContainer)
        {
            foreach (var s in _snippets)
            {
                var snippet = s.GetSnippet(snippetContainer);

                if (snippet != null)
                    return snippet;
            }
            return null;
        }

        public void AddCustomSnippet(ISnippetContainer snippet)
        {
            _snippets.Add(snippet);
        }

        public void AddRangeCustomSnippets(IEnumerable<ISnippetContainer> snippets)
        {
            _snippets.AddRange(snippets);
        }
    }
}
