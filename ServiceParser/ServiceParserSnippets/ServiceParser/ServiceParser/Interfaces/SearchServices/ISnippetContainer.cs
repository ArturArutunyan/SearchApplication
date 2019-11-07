using AngleSharp.Dom;
using ServiceParser.Entities;

namespace ServiceParser.Interfaces
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
