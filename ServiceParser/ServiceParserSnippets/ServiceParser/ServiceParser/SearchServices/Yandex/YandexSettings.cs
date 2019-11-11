using ServiceParser.Interfaces.SearchServices;

namespace ServiceParser.SearchServices.Yandex
{
    public class YandexSettings : ISearchServiceSettings
    {
        public string BaseUrl { get; } = @"https://yandex.ru/search/?text=";

        public string Page { get; } = "&p=";

        public string MainContainerClass { get; } = ".serp-item";
    }
}
