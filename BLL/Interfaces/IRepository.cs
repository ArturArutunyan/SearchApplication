using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    /// <summary>
    /// Контракт CRUD репозитория сущности
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности</typeparam>
    /// <typeparam name="TKey">Тип ключа сущности</typeparam>
    public interface IRepository<TEntity, TKey>
        where TEntity : class
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Создать запись
        /// </summary>
        /// <param name="entity">
        /// Экземпляр класса
        /// </param>
        Task AddRangeAsync(IEnumerable<TEntity> entity);

        /// <summary>
        /// Получить запись
        /// </summary>
        /// <param name="count">
        /// Количество сниппетов, которое необходимо получить из бд
        /// </param> 
        /// <returns>
        /// Запись
        /// </returns>
        Task<IEnumerable<TEntity>> GetSnippets(int count);
    }
}
