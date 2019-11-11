using ServiceParserSnippets.Interfaces.SearchServices;

namespace ServiceParserSnippets.SearchServices.Google
{
    public class GoogleSettings : ISearchServiceSettings
    {
        public string BaseUrl { get; } = "https://www.google.com/search?q=";

        public string Page { get; } = "&start=";

        public string MainContainerClass { get; } = ".g";
    }
}
