using ServiceParserSnippets.Interfaces.SearchServices;

namespace ServiceParserSnippets.SearchServices.Bing
{
    public class BingSettings : ISearchServiceSettings
    {
        public string BaseUrl { get; } = "https://www.bing.com/search?q=";

        public string Page { get; } = "&first=";

    }
}
