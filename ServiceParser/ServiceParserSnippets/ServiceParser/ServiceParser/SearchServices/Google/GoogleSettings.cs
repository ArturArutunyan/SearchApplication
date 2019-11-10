
using ServiceParser.Interfaces.SearchServices;

namespace ServiceParser.SearchServices.Google
{
    public class GoogleSettings : ISearchServiceSettings
    {
        public string BaseUrl { get; } = "https://www.google.com/search?q=";

        public string Page { get; } = "&start=";

        public string MainContainerClass { get; } = ".g";
    }
}
