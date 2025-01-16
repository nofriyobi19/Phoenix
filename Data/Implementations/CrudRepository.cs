using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Phoenix.Data.Interfaces;

namespace Phoenix.Data.Implementations;

public class CrudRepository<TEntity, ID> : ICrudRepository<TEntity, ID> where TEntity : class {
    private readonly PhoenixContext dbContext;
    private readonly DbSet<TEntity> dbSet;
    public virtual string NoEntityFoundErrorMessage => "No entity found with this id";

    public CrudRepository(PhoenixContext phoenixContext) {
        dbContext = phoenixContext;
        dbSet = dbContext.Set<TEntity>();
    }

    public virtual async void DeleteAsync(TEntity entity) {
        dbContext.Remove(entity);
        await dbContext.SaveChangesAsync();
    }

    public virtual async Task<List<TEntity>> GetAllAsync() {
        return await dbSet.ToListAsync();
    }

    public virtual async Task<TEntity> GetByIdAsync(ID id) {
        return await dbSet.FindAsync(id) ?? throw new KeyNotFoundException(NoEntityFoundErrorMessage);
    }

    public virtual async Task<TEntity> SaveAsync(TEntity entity) {
        if (await dbSet.ContainsAsync(entity)) {
            dbSet.Attach(entity);
            dbSet.Entry(entity).State = EntityState.Modified;
        } else await dbSet.AddAsync(entity);

        await dbContext.SaveChangesAsync();

        return entity;
    }
}