using System.Reflection;
using Contract.Common.ModelBuilder;
using Contract.Model.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Contract.Repository;


public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
        base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
         
        builder.ApplyConfigurationsFromAssembly(typeof(IEntityConfiguration).Assembly);
    }
    
    public override int SaveChanges()
    {
       this.SoftDeleteEntities();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
       this.SoftDeleteEntities();
        return base.SaveChangesAsync(cancellationToken);
    }
    
    public DbSet<Model.Entities.Contract> Contract { get; set; }
    
 
}