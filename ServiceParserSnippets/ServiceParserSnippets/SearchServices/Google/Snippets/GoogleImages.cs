using AngleSharp.Dom;
using ServiceParserSnippets.Entities;
using ServiceParserSnippets.Interfaces.SearchServices;

namespace ServiceParserSnippets.SearchServices.Google.Snippets
{
    public class GoogleImages : ISnippetContainer
    {
        public Snippet GetSnippet(IElement snippetContainer)
        {
            var imgContainer = snippetContainer.QuerySelector(GoogleSnippetsCSS.ImagesContainer);

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
