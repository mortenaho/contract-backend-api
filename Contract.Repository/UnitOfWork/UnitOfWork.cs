using Contract.Repository.Repository;
using Microsoft.EntityFrameworkCore;

namespace Contract.Repository.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _context;
    private IGenericRepository<Model.Entities.Contract> _contract;

    public UnitOfWork(DbContext context)
    {
        _context = context;
    }
    public IGenericRepository<Model.Entities.Contract> Contract => _contract ??= new GenericRepository<Model.Entities.Contract>(_context);
    
    public void Save()
    {
        _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
