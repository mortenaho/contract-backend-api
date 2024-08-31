namespace Contract.DTOs.Request;

public class ContractRequest
{
    public long ContractId { set; get; }
    public string Title { set; get; }
    public string ContractNumber { set; get; }
    public string Description { set; get; }
    public string StartDate { set; get; }
    public string EndDate { set; get; }
}