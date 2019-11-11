using ServiceParserSnippets.Interfaces.SearchServices;

namespace ServiceParserSnippets.SearchServices.Yandex
{
    public class Yandex : SearchServiceBase
    {
        public Yandex(ISearchServiceSettings settings, IServiceHelper helper) 
            : base(settings, helper)
        {
        }
    }
}
