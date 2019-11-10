using ServiceParser.Interfaces;
using ServiceParser.SearchServices.Yandex.Snippets;
using System.Collections.Generic;

namespace ServiceParser.SearchServices.Yandex
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
