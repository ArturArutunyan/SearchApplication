using AngleSharp.Dom;
using ServiceParserSnippets.Entities;

namespace ServiceParserSnippets.Interfaces.SearchServices
{
    public interface ISnippetContainer
    {
        /// <summary>
        /// Метод возвращает 
        /// </summary>
        /// <param name="snippetContainer">Контейнер сниппета</param>
        /// <returns>Обьект Snippet</returns>
        Snippet GetSnippet(IElement snippetContainer);
    }
}
