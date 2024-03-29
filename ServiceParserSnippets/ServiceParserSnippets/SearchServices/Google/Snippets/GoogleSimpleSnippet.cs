﻿using AngleSharp.Dom;
using ServiceParserSnippets.Entities;
using ServiceParserSnippets.Interfaces.SearchServices;

namespace ServiceParserSnippets.SearchServices.Google.Snippets
{
    public class GoogleSimpleSnippet : ISnippetContainer
    {
        public Snippet GetSnippet(IElement snippetContainer)
        {
            var title = snippetContainer.QuerySelector(GoogleSnippetsCSS.SimpleTitleClass);

            if (title != null)
            {
                var url = snippetContainer.QuerySelector(GoogleSnippetsCSS.SimpleContainerHref).GetAttribute(CSSAttributes.Href);

                return new Snippet()
                {
                    Title = title.TextContent,
                    Url = url
                };
            }

            return null;
        }
    }
}
