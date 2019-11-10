using ServiceParser.Interfaces;
using ServiceParser.Interfaces.SearchServices;

namespace ServiceParser.SearchServices.Google
{
    public class Google : SearchServiceBase
    {
        public Google(ISearchServiceSettings settings, IServiceHelper helper) 
            : base(settings, helper)
        {
        }
    }
}
