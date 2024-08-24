using Microsoft.EntityFrameworkCore;

namespace Data.Repository;

public interface IGenericRepository<TEntity> where TEntity : class
{
    
    DbSet<TEntity> Entities { get; }
    IQueryable<TEntity> Table { get; }
    IQueryable<TEntity> TableNoTracking { get; }
    
    IEnumerable<TEntity> GetAll();

    TEntity GetById(long id);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(long id);
    void Save();
}