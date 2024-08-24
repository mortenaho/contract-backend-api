using System.Reflection;
using Common.ModelBuilder;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data;


public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
        base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        var entitiesAssembly = typeof(IEntity).Assembly;
         builder.RegisterAllEntities<IEntity>(entitiesAssembly);
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
}