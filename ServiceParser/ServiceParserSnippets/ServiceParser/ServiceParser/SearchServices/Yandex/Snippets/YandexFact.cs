using AngleSharp.Dom;
using ServiceParser.Entities;
using ServiceParser.Interfaces;


namespace ServiceParser.SearchServices.Yandex.Snippets
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
