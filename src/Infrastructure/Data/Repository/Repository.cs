

using Colossus.Domain.Gateway;
using Colossus.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Colossus.Infrastructure.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IDbContext _context;
        private DbSet<T> _entities;

        public Repository(IDbContext context)
        {
            this._context = context;
        }

        public T GetById(long id)
        {
            return this.Entities.Find(id);
        }

        public void Insert(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                this.Entities.Add(entity);
                this._context.SaveChanges();
            }
            catch (DbUpdateException dbEx)
            {
                handleDbEntityValidationException(dbEx);
                //TODO: ADD LOGS
                throw;
            }
        }

        public void Update(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                this._context.SaveChanges();
            }
            catch (DbUpdateException dbEx)
            {
                handleDbEntityValidationException(dbEx);
                //TODO: ADD LOGS
                throw;
            }
        }

        public void Delete(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                this.Entities.Remove(entity);
                this._context.SaveChanges();
            }
            catch (DbUpdateException dbEx)
            {
                handleDbEntityValidationException(dbEx);
                //TODO: ADD LOGS
                throw;
            }
        }

        private DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _context.Set<T>();
                }
                return _entities;
            }
        }

        public IQueryable<T> Queryable => this.Entities;

        private string handleDbEntityValidationException(DbUpdateException dbu)
        {
            var builder = new StringBuilder("A DbUpdateException was caught while saving changes. ");

            try
            {
                foreach (var result in dbu.Entries)
                {
                    builder.AppendFormat("Type: {0} was part of the problem. ", result.Entity.GetType().Name);
                }
            }
            catch (Exception e)
            {
                builder.Append("Error parsing DbUpdateException: " + e.ToString());
            }

            return builder.ToString();
            
        }
    }
}
