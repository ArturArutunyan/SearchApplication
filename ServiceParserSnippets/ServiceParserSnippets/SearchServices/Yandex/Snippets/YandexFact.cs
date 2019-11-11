using AngleSharp.Dom;
using ServiceParserSnippets.Entities;
using ServiceParserSnippets.Interfaces.SearchServices;

namespace ServiceParserSnippets.SearchServices.Yandex.Snippets
{
    public class YandexFact : ISnippetContainer
    {
        public Snippet GetSnippet(IElement snippetContainer)
        {
            var factContainer = snippetContainer.QuerySelector(YandexSnippetsCSS.FactContainer);

            if (factContainer != null)
            {
                return new Snippet()
                {
                    Title = factContainer.TextContent,
                    Url = factContainer.GetAttribute(CSSAttributes.Href)
                };
            }

            return null;
        }
    }
}
