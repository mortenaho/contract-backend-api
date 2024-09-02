using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities;

public class ContractingParty:BaseEntity
{
    public int ContractingPartyId { set; get; }
    public string ContractingPartyName  { set; get; }
    public bool IsLegal    { set; get; }
    public long NationalCode { set; get; }
    public virtual ICollection<Contract> Contracts { get; set; }
}

public class ContractingPartyConfiguration : IEntityTypeConfiguration<ContractingParty>,IEntityConfiguration
{
    public void Configure(EntityTypeBuilder<ContractingParty> builder)
    {
        builder.HasKey(b => b.ContractingPartyId);
    }
}