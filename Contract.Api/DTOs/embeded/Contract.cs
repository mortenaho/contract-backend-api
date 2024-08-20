namespace Contract.DTOs.embeded;

public class Contract
{
    public long ContractId { set; get; }
    public string ContractNumber { set; get; }
    public string Title { set; get; }
    public string Description { set; get; }
    public DateTime StartDate { set; get; }
    public DateTime EndDate { set; get; }
}