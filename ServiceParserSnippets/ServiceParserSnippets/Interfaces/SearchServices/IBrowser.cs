
using System.Threading.Tasks;

namespace ServiceParserSnippets.Interfaces.SearchServices
{
    /// <summary>
    /// Интерфейс определяющий функционал обьекта браузера
    /// </summary>
    public interface IBrowser
    {
        /// <summary>
        /// Свойство указывающее на состояние браузера
        /// </summary>
        bool BrowserIsLaunched { get; }

        /// <summary>
        /// Метод запуска браузера
        /// </summary>
        /// <returns></returns>
        Task LaunchBrowserAsync();
    }
}
