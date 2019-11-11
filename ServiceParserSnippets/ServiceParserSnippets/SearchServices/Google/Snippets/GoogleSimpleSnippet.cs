using AngleSharp.Dom;
using ServiceParserSnippets.Entities;
using ServiceParserSnippets.Interfaces.SearchServices;

namespace ServiceParserSnippets.SearchServices.Google.Snippets
{
    public class GoogleSimpleSnippet : ISnippetContainer
    {
        public Snippet GetSnippet(IElement snippetContainer)
        {
            var title = snippetContainer.QuerySelector(GoogleSnippetsCSS.TitleClass);

            if (title != null)
            {
                var url = snippetContainer.QuerySelector(GoogleSnippetsCSS.ContainerHref).GetAttribute("href");

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
