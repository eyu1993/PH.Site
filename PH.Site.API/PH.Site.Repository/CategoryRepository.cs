using PH.Site.IRepository;
using System.Data;

namespace PH.Site.Repository
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(IDbConnection connection, IDbTransaction transaction) : base(connection, transaction)
        {
        }
    }
}
