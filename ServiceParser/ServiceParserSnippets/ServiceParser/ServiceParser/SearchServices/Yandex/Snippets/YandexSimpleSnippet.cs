using AngleSharp.Dom;
using ServiceParser.Entities;
using ServiceParser.Interfaces;

namespace ServiceParser.SearchServices.Yandex.Snippets
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
