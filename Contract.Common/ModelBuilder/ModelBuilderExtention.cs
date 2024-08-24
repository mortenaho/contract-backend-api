using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Contract.Common.ModelBuilder;

public static class ModelBuilderExtention
{
    public static void SoftDeleteEntities(this Microsoft.EntityFrameworkCore.DbContext context)
    {
        foreach (var entry in context.ChangeTracker.Entries()
                     .Where(e => e.State == EntityState.Deleted))
        {
            entry.State = EntityState.Modified;
            var properties = entry.Entity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.CanRead && p.CanWrite && p.PropertyType == typeof(bool));
            foreach (var property in properties)
            {
                var propName = property.Name;
                if (propName=="IsDeleted")
                {
                    property.SetValue(entry.Entity,true,null);
                }
            }
        }
    }
}