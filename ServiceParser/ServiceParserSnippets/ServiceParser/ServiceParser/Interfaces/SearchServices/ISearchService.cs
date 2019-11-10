using ServiceParser.Entities;
using ServiceParser.Interfaces.SearchServices;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceParser.SearchService
{
    /// <summary>
    /// Интерфейс определяющий функционал поискового сервиса
    /// </summary>
    public interface ISearchService
    {
        /// <summary>
        /// Обьект хранящий настройки сервиса
        /// </summary>
        ISearchServiceSettings Settings { get; set; }

        /// <summary>
        /// Метод асинхронно возвращающий массив обьектов Snippet
        /// </summary>
        /// <param name="searchQuery">Строка запроса</param>
        /// <param name="count">Количество возвращемых сниппетов</param>
        /// <returns>Массив обьектов Snippet</returns>
        Task<Snippet[]> GetSnippetsAsync(string searchQuery, int count, CancellationToken cancellationToken);
    }
}
