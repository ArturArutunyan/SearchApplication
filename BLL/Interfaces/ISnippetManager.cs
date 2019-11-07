using ServiceParser.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ISnippetManager
    {
        /// <summary>
        /// Метод возрашающий спискок сниппетов полученных в результате парсинга запроса 
        /// </summary>
        /// <param name="searchQuery">Запрос для поиска</param>
        IEnumerable<Snippet> GetTenSnippetsFromParser(string searchQuery);

        /// <summary>
        /// Метод возрашающий спискок состоящий из первых 10 сниппетов находящихся в БД
        /// </summary>
        Task<IEnumerable<Snippet>> GetTenSnippetsFromDb();
    }
}
