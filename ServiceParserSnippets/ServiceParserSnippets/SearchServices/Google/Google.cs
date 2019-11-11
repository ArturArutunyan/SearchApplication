using ServiceParserSnippets.Interfaces.SearchServices;

namespace ServiceParserSnippets.SearchServices.Google
{
    public class Google : SearchServiceBase
    {
        public Google(ISearchServiceSettings settings, IServiceHelper helper) 
            : base(settings, helper)
        {
        }
    }
}
