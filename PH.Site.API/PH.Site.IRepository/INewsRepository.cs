using PH.Site.Model;

namespace PH.Site.IRepository
{
    public interface INewsRepository : IBaseRepository<News>
    {
        void Add(News news);
        void Delete(int id);
        void Update(News news);
        void UpdateVisible(int id);
    }
}
