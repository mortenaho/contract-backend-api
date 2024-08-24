using Common.ModelBuilder;

namespace Entities;

public abstract class BaseEntity :IEntity
{
    public DateTime CreatedDate { set; get; }=DateTime.Now;
    public DateTime? UpdatedDate { set; get; } = null;
    public bool IsDeleted { get; set; }
    
}