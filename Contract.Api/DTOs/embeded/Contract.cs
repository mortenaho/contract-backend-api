using Common;

namespace Contract.DTOs.embeded;

public class Contract
{
    public long ContractId { set; get; }
    public int ContractingPartyId { set; get; }
    public string ContractNumber { set; get; }
    public string Title { set; get; }
    public string Description { set; get; }
    public string StartDate { set; get; }
    public string EndDate { set; get; }
    public string ContractingName { set; get; }

    public string ShamsiStartDate
    {
        get { return StartDate.ToPersianDate(); }
    }

    public string ShamsiEndDate
    {
        get { return EndDate.ToPersianDate(); }
    }
}