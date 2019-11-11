
using ServiceParserSnippets.Entities;
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
        Task<IEnumerable<Snippet>> GetSnippetsFromParserAsync(string searchQuery, int count);

        /// <summary>
        /// Метод возрашающий спискок состоящий из первых 10 сниппетов находящихся в БД
        /// </summary>
        Task<IEnumerable<Snippet>> GetSnippetsFromDbAsync(int count);
    }
}
