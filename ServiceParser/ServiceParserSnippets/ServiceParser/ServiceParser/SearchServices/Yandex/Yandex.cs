using ServiceParser.Entities;
using ServiceParser.Interfaces.SearchServices;
using System.Threading;
using System.Threading.Tasks;


namespace ServiceParser.SearchServices.Yandex
{
    public class Yandex : SearchServiceBase
    {
        public Yandex(ISearchServiceSettings settings)
        {
            Settings = settings;
        }

        public override async Task<Snippet[]> GetSnippetsAsync(string searchQuery, int count, CancellationToken cancellationToken)
        {
            return await GetSnippetsAsync(
                    searchQuery: searchQuery,
                    count: count,
                    helper: new YandexServiceHelper(),
                    mainContainerClass: Settings.MainContainerClass,
                    cancellationToken: cancellationToken
                );
        }
    }
}
