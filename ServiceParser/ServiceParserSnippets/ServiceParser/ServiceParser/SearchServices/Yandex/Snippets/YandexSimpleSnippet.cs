using AngleSharp.Dom;
using ServiceParser.Entities;
using ServiceParser.Interfaces;
using System.Linq;

namespace ServiceParser.SearchServices.Yandex.Snippets
{
    public class YandexSimpleSnippet : ISnippetContainer
    {
        public Snippet GetSnippet(IElement snippetContainer)
        {
            var simpleSnippet = snippetContainer.QuerySelectorAll(YandexSnippetsCSS.SimpleSnippetClass).LastOrDefault();

            if (simpleSnippet != null)
            {
                return new Snippet()
                {
                    Title = simpleSnippet.TextContent,
                    Url = simpleSnippet.GetAttribute(CSSAttributes.Href)
                };
            }
            return null;
        }
    }
}
