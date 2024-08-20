namespace Contract.Model.Entities;

public class BaseEntity
{
    public DateTime CreatedDate { set; get; }=DateTime.Now;
    public DateTime? UpdatedDate { set; get; } = null;
    public Boolean IsDeleted { set; get; } = false;
}