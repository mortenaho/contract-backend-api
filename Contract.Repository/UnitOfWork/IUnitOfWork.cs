using Contract.Repository.Repository;

namespace Contract.Repository.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Model.Entities.Contract> Contract { get; }
    
    void Save();
}