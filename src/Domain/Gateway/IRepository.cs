using Colossus.Domain.Model;

namespace Colossus.Domain.Gateway
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(Id id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> Queryable { get; }
    }
}
