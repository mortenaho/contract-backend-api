using Microsoft.EntityFrameworkCore;

namespace Contract.Repository.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly DbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public IEnumerable<T> GetAll() => _dbSet.ToList();

    public T GetById(int id) => _dbSet.Find(id);

    public void Add(T entity) => _dbSet.Add(entity);

    public void Update(T entity) => _dbSet.Attach(entity);

    public void Delete(int id)
    {
        var entity = _dbSet.Find(id);
        if (entity != null) _dbSet.Remove(entity);
    }
}