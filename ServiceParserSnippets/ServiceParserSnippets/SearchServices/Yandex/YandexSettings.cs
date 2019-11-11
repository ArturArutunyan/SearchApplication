using ServiceParserSnippets.Interfaces.SearchServices;

namespace ServiceParserSnippets.SearchServices.Yandex
{
    public class YandexSettings : ISearchServiceSettings
    {
        public string BaseUrl { get; } = @"https://yandex.ru/search/?text=";

        public string Page { get; } = "&p=";    
    }
}
