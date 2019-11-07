using BLL.Interfaces;
using DAL.DAO.EF;
using ServiceParser.Entities;

namespace BLL.Repositories
{
    public class SnippetRepository : Repository<Snippet, int>, ISnippetRepository
    {
        public SnippetRepository(ApplicationDbContext context)
            : base(context)
        {            
        }
    }
}
