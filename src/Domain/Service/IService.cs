using Colossus.Domain.Gateway;
using Colossus.Domain.Model;

namespace Colossus.Domain.Service
{
    public interface IService<T> where T : BaseEntity
    {
        IQueryable<T> GetQueryable();
        T Get(Id id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
