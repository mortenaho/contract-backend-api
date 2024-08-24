using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Common.ModelBuilder;

public static class QueryableExtensions
{
   public static IQueryable<T> WhereNotDeleted<T>(this IQueryable<T> source) where T : class
   {
      // Get the type of the entity
      var entityType = typeof(T);

      // Find the 'isDeleted' property
      var isDeletedProperty = entityType.GetProperty("IsDeleted");

      if (isDeletedProperty == null)
      {
         throw new ArgumentException($"Type {entityType.Name} does not contain a property named 'isDeleted'.");
      }

      // Create the expression: e => !e.isDeleted
      var parameter = Expression.Parameter(entityType, "e");
      var propertyAccess = Expression.MakeMemberAccess(parameter, isDeletedProperty);
      var filter = Expression.Lambda<Func<T, bool>>(
         Expression.Equal(propertyAccess, Expression.Constant(false)), parameter);

      // Apply the filter
      return source.Where(filter);
   }
}