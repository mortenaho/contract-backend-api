namespace Contract.DTOs.Request;

public class ContractRequest
{
    public string Title { set; get; }
    public string ContractNumber { set; get; }
    public string Description { set; get; }
    public DateTime StartDate { set; get; }
    public DateTime EndDate { set; get; }
}