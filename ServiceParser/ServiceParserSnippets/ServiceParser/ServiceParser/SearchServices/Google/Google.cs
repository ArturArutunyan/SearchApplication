using System.Threading;
using System.Threading.Tasks;
using ServiceParser.Entities;

namespace ServiceParser.SearchServices.Google
{
    public class Google : SearchServiceBase
    {
        public Google()
        {
        }
        public override async Task<Snippet[]> GetSnippetsAsync(string searchQuery, int count, CancellationToken cancellationToken)
        {
            return await GetSnippetsAsync(
                    searchQuery: searchQuery,
                    count: count,
                    helper: new GoogleServiceHelper(),
                    mainContainerClass: GoogleSnippetsCSS.MainContainerClass,
                    cancellationToken: cancellationToken
                );
        }
    }
}
