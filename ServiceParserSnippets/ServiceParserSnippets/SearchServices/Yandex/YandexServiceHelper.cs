using ServiceParserSnippets.Interfaces.SearchServices;
using ServiceParserSnippets.SearchServices.Yandex.Snippets;
using System.Collections.Generic;

namespace ServiceParserSnippets.SearchServices.Yandex
{
    public class YandexServiceHelper : ServiceHelper 
    {
        public YandexServiceHelper()
        {
            // инициализируем дефолтными контейнерами сниппетов
            _snippets.AddRange(new List<ISnippetContainer>
            {
                new YandexImages(),
                new YandexFact(),
                new YandexSimpleSnippet()
            });
        }
    }
}
