using BLL.Interfaces;
using DAL.DAO.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, new()
        where TKey : IEquatable<TKey>
    {
        protected ApplicationDbContext _context { get; set; }

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetSnippets(int count)
        {
            //var entities = _context.Set<TEntity>()
            //    .FromSqlRaw($"SELECT * FROM [search_app][dbo.Snippets]");
            var entities = await _context.Set<TEntity>().Take(10).ToListAsync();
            return entities;
        }
      
    }
}
