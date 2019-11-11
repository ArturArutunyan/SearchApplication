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
        Task LaunchBrowserAsync();

        /// <summary>
        /// Метод закрытия браузера
        /// </summary>
        Task CloseBrowserAsync();
    }
}
