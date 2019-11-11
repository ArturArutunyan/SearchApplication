using System.Collections.Generic;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using ServiceParserSnippets.Interfaces.SearchServices;

namespace ServiceParserSnippets.SearchServices.Yandex
{
    public class Yandex : SearchServiceBase
    {
        public Yandex(ISearchServiceSettings settings, IServiceHelper helper) 
            : base(settings, helper)
        {
        }

        protected override IEnumerable<IElement> GetSnippetsContainers(IHtmlDocument document)
        {
            return document.QuerySelectorAll(YandexSnippetsCSS.MainContainerClass);
        }
    }
}
