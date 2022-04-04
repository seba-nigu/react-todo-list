using Microsoft.EntityFrameworkCore;

namespace TaskManagement.WebApi.Persistance
{
    public interface IApplicationDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        IQueryable<TEnt> ReadSet<TEnt>() where TEnt: class;
        int SaveChanges();
    }
}
