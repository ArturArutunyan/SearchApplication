using ServiceParserSnippets.Entities;
using ServiceParserSnippets.Interfaces.SearchServices;
using System.Collections.Generic;

namespace ServiceParserSnippets.Interfaces.SearchEngine
{
    /// <summary>
    /// Интерфейс определяющий функционал поискового движка
    /// </summary>
    public interface ISearchEngine
    {
        /// <summary>
        /// Метод асинхронно возвращающий массив обьектов Snippet
        /// </summary>
        /// <param name="searchQuery">Строка запроса</param>
        /// <param name="count">Количество возвращемых сниппетов</param>
        /// <returns>Массив обьектов Snippet</returns>
        Snippet[] Start(string searchQuery, int count);

        /// <summary>
        /// Метод позволяющий добавлять поисковой сервис в коллекцию 
        /// </summary>
        /// <param name="searchService">Поисковой сервис</param>
        void AddSearchService(ISearchService searchService);

        /// <summary>
        /// Метод позволяющий добавлять коллекцию поисковых сервисов 
        /// </summary>
        /// <param name="searchServices">Коллекцию поисковых сервисов</param>
        void AddRangeSearchServices(IEnumerable<ISearchService> searchServices);

        /// <summary>
        /// Метод прерывающий выполнение запроса 
        /// </summary>
        void Abort();
    }
}
