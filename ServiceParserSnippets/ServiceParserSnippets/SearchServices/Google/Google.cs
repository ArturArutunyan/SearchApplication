using System.Collections.Generic;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using ServiceParserSnippets.Interfaces.SearchServices;

namespace ServiceParserSnippets.SearchServices.Google
{
    public class Google : SearchServiceBase
    {
        public Google(ISearchServiceSettings settings, IServiceHelper helper) 
            : base(settings, helper)
        {
        }

        protected override IEnumerable<IElement> GetSnippetsContainers(IHtmlDocument document)
        {
            var containers = new List<IElement>();


            var simpleContainers = document.QuerySelectorAll(GoogleSnippetsCSS.SimpleMainContainer);

            if (simpleContainers != null)
                containers.AddRange(simpleContainers);


            var imgContainers = document.QuerySelectorAll(GoogleSnippetsCSS.ImagesMainContainer);

            if (imgContainers != null)
                containers.AddRange(imgContainers);

            return containers;
        }
    }
}
