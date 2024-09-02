namespace Contract.DTOs.embeded;

public class ContractingPartyDetail
{
    public int ContractingPartyId { set; get; }
    public string ContractingPartyName  { set; get; }
    public bool IsLegal    { set; get; }
    public long NationalCode { set; get; }
}