using AngleSharp.Dom;
using ServiceParserSnippets.Entities;
using ServiceParserSnippets.Interfaces.SearchServices;

namespace ServiceParserSnippets.SearchServices.Yandex.Snippets
{
    public class YandexImages : ISnippetContainer
    {
        public Snippet GetSnippet(IElement snippetContainer)
        {
            var imgContainer = snippetContainer.QuerySelector(YandexSnippetsCSS.YandexImagesClass);

            if (imgContainer != null)
            {
                return new Snippet()
                {
                    Title = imgContainer.TextContent,
                    Url = imgContainer.GetAttribute(CSSAttributes.Href)
                };
            }

            return null;
        }
    }
}
