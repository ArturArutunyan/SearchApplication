using AngleSharp.Dom;
using ServiceParserSnippets.Entities;
using ServiceParserSnippets.Interfaces.SearchServices;

namespace ServiceParserSnippets.SearchServices.Yandex.Snippets
{
    public class YandexSimpleSnippet : ISnippetContainer
    {
        public Snippet GetSnippet(IElement snippetContainer)
        {
            var simpleContainer = snippetContainer.QuerySelector(YandexSnippetsCSS.SimpleSnippetClass);

            if (simpleContainer != null)
            {
                return new Snippet()
                {
                    Title = simpleContainer.TextContent,
                    Url = simpleContainer.GetAttribute(CSSAttributes.Href)
                };
            }
            return null;
        }
    }
}
