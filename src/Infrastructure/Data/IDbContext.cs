using Colossus.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Colossus.Infrastructure.Data
{
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
