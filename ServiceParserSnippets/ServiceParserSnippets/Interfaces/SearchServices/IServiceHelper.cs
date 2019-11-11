using System.Collections.Generic;

namespace ServiceParserSnippets.Interfaces.SearchServices
{
    /// <summary>
    ///  Интерфейс определяющий функционал хелпера, инкапсулирующего логику определения типа сниппета
    /// </summary>
    public interface IServiceHelper : ISnippetContainer
    {
        /// <summary>
        /// Метод позволяет добавить пользовательский контейнер сниппета
        /// </summary>
        /// <param name="snippetContainer">Пользовательский контейнер сниппета</param>
        void AddCustomSnippet(ISnippetContainer snippetContainer);

        /// <summary>
        /// Метод позволяет добавить коллекцию пользовательских сниппетов
        /// </summary>
        /// <param name="snippetsContainers">Коллекция пользовательских контейнеров сниппетов</param>
        void AddRangeCustomSnippets(IEnumerable<ISnippetContainer> snippetsContainers);
    }
}
