namespace Phoenix.Data.Interfaces;

public interface ICrudRepository<TEntity, ID> where TEntity : class {
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(ID id);
    Task<TEntity> SaveAsync(TEntity entity);
    void DeleteAsync(TEntity entity);
}