using PH.Site.Model.BaseModel;

namespace PH.Site.IRepository
{
    public interface IBaseRepository<T> where T : AggregateRoot
    {
    }
}
