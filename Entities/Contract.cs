using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities;

[Table("Contract")]
public class Contract:BaseEntity
{
    public long ContractId { set; get; }
    public string ContractNumber { set; get; }
    public string Title { set; get; }
    public string Description { set; get; }
    public DateTime StartDate { set; get; }
    public DateTime EndDate { set; get; }
 
    // Foreign Key
    public int ContractingPartyId { get; set; }

    // Navigation Property
    public virtual ContractingParty ContractingParty { get; set; }
}

public class ContractEntityTypeConfiguration : IEntityTypeConfiguration<Contract>,IEntityConfiguration
{
    public void Configure(EntityTypeBuilder<Contract> builder)
    {
        builder.HasKey(b => b.ContractId);
        builder.HasIndex(b => b.ContractNumber);
        builder.Property(b => b.ContractNumber).IsRequired();
        builder.Property(b => b.Title).IsRequired();
        builder.Property(b => b.StartDate).IsRequired();
        builder.Property(b => b.EndDate).IsRequired();
        builder.HasOne<ContractingParty>(p => p.ContractingParty)
            .WithMany(cp => cp.Contracts)
            .HasForeignKey(c => c.ContractingPartyId);
    }
}