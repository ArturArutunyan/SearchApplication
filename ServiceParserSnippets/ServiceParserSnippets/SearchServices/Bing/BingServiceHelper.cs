using ServiceParserSnippets.SearchServices.Bing.Snippets;

namespace ServiceParserSnippets.SearchServices.Bing
{
    public class BingServiceHelper : ServiceHelper
    {
        public BingServiceHelper()
        {
            _snippets.Add(new BingSimpleSnippet());
        }
    }
}
