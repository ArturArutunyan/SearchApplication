using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AngleSharp.Dom;
using ServiceParser.Entities;

namespace ServiceParser.SearchServices.Google
{
    public class Google : SearchServiceBase
    {
        public Google()
        {
            BaseUrl = @"https://www.google.com/search?q=";
        }
        public override async Task<Snippet[]> GetSnippetsAsync(string searchQuery, int count = 10, CancellationToken? cancellationToken = null)
        {
            return await GetSnippetsAsync(
                    searchQuery: searchQuery,
                    count: count,
                    helper: new GoogleServiceHelper(),
                    mainContainerClass: GoogleSnippetsCSS.MainContainerClass,
                    cancellationToken: cancellationToken
                );
        }

        protected override Task<IEnumerable<IElement>> GetSnippetsContainersAsync(string searchQuery, int count, string mainContainerClass)
        {
            throw new NotImplementedException();
        }
    }
}
