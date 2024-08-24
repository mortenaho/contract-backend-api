using Data.Repository;

namespace Data.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Entities.Contract> Contract { get; }
    
    void Save();
}