using ServiceParser.Entities;
using System.Threading;
using System.Threading.Tasks;


namespace ServiceParser.SearchServices.Yandex
{
    public class Yandex : SearchServiceBase
    {
        public Yandex()
        {
            BaseUrl = @"https://yandex.ru/search/?text=";
        }

        public override async Task<Snippet[]> GetSnippetsAsync(string searchQuery, int count, CancellationToken cancellationToken)
        {
            return await GetSnippetsAsync(
                    searchQuery: searchQuery,
                    count: count,
                    helper: new YandexServiceHelper(),
                    mainContainerClass: YandexSnippetsCSS.MainContainerClass,
                    cancellationToken: cancellationToken
                );
        }
    }
}
