using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Common.ModelBuilder;

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
    /// <summary>
    /// Dynamicaly register all Entities that inherit from specific BaseType
    /// </summary>
    /// <param name="modelBuilder"></param>
    /// <param name="baseType">Base type that Entities inherit from this</param>
    /// <param name="assemblies">Assemblies contains Entities</param>
    public static void RegisterAllEntities<BaseType>(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder, params Assembly[] assemblies)
    {
        IEnumerable<Type> types = assemblies.SelectMany(a => a.GetExportedTypes())
            .Where(c => c.IsClass && !c.IsAbstract && c.IsPublic && typeof(BaseType).IsAssignableFrom(c));
        foreach (Type type in types)
            modelBuilder.Entity(type);
    }
}