using Colossus.Domain.Gateway;
using Colossus.Domain.Model;

namespace Colossus.Domain.Service
{
    public class Service<T> : IService<T> where T : BaseEntity
    {
        private readonly IRepository<T> repository;

        public Service(IRepository<T> _repository)
        {
            repository = _repository;
        }      

        public void Delete(T entity)
        {         
            repository.Delete(entity);  
        }        

        public T Get(Id id)
        {         
            return repository.GetById(id);
        }
      
        public IQueryable<T> GetQueryable()
        {
            return repository.Queryable;
        }        

        public void Insert(T entity)
        {         
            repository.Insert(entity);
        }

        public void Update(T entity)
        {        
            repository.Update(entity);
        }
    }
}
