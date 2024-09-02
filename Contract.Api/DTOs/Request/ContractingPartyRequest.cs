namespace Contract.DTOs.Request;

public class ContractingPartyRequest
{
    public int ContractingPartyId { set; get; }
    public string ContractingPartyName  { set; get; }
    public bool IsLegal    { set; get; }
    public long NationalCode { set; get; }
}