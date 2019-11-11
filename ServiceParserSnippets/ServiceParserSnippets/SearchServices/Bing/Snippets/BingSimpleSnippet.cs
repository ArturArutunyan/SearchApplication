using AngleSharp.Dom;
using ServiceParserSnippets.Entities;
using ServiceParserSnippets.Interfaces.SearchServices;

namespace ServiceParserSnippets.SearchServices.Bing.Snippets
{
    public class BingSimpleSnippet : ISnippetContainer
    {
        public Snippet GetSnippet(IElement snippetContainer)
        {
            var simpleContainer = snippetContainer.QuerySelector("a");

            if (simpleContainer != null)
            {
                var title = simpleContainer.TextContent;
                var url = simpleContainer.GetAttribute(CSSAttributes.Href);

                if (title != null && url != null)
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
