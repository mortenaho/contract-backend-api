using Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private IGenericRepository<Entities.Contract> _contract;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }
    public IGenericRepository<Entities.Contract> Contract => _contract ??= new GenericRepository<Entities.Contract>(_context);
    
    public void Save()
    {
        _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
