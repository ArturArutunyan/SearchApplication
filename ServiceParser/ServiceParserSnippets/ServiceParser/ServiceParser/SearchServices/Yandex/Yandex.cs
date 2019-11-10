using ServiceParser.Interfaces;
using ServiceParser.Interfaces.SearchServices;

namespace ServiceParser.SearchServices.Yandex
{
    public class Yandex : SearchServiceBase
    {
        public Yandex(ISearchServiceSettings settings, IServiceHelper helper) 
            : base(settings, helper)
        {
        }
    }
}
