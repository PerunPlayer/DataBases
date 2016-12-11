using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace SuperheroesUniverse.Data.Repository
{
    public interface ISuperheroDBContext
    {
        DbContextConfiguration Configuration { get; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        int SaveChanges();
    }
}