 using Microsoft.EntityFrameworkCore;

namespace Data.Repository;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    protected readonly ApplicationDbContext DbContext;
    public DbSet<TEntity> Entities { get; }
    public virtual IQueryable<TEntity> Table => Entities;
    public virtual IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();

    public GenericRepository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
        Entities = DbContext.Set<TEntity>();
    }

    public IEnumerable<TEntity> GetAll() => Entities.ToList();
    

    public TEntity GetById(long id) => Entities.Find(id);

    public void Add(TEntity entity)
    {
        Entities.Add(entity);
        Save();
    }

    public void Update(TEntity entity)
    {
        Entities.Attach(entity);
        Save();
    }

    public void Delete(long id)
    {
        var entity = Entities.Find(id);
        if (entity != null) Entities.Remove(entity);
        Save();
    }

    public void Save()
    {
        DbContext.SaveChanges();
    }

}