using System.Collections.Generic;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using ServiceParserSnippets.Interfaces.SearchServices;

namespace ServiceParserSnippets.SearchServices.Bing
{
    public class Bing : SearchServiceBase
    {
        public Bing(ISearchServiceSettings settings, IServiceHelper helper)
            : base(settings, helper)
        {
        }

        // В отличии от яндекса и гугла, где каждая страница запроса имеет свой номер (прим. &page=1, &page=2,...&page=n),
        // бинг имеет иную форму страницы запроса. 
        // Здесь вместо номерома используется количество запрашиваемых страниц.
        // Например: &page=1 == &first=10, &page=2 == &first=20 и т.д.
        // В связи с этим необходимо расчитать количество
        protected override string FormUrl(string searchQuery, int pageId)
        {
            var first = pageId;
            // Данная переменная хранит количество запращиваемых страниц от поисковика
            if (first != 0)
                first = (pageId + 1 * 10);

            return $"{Settings.BaseUrl}{searchQuery}{Settings.Page}{first}";
        }
        protected override IEnumerable<IElement> GetSnippetsContainers(IHtmlDocument document)
        {
            return document.QuerySelectorAll(BingSnippetsCSS.MainContainer);
        }
    }
}
