using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EfCore.Frameworks;

public static class ModelBuilderExtensions
{
    public static void RegisterAllEntities<BaseEntity>(this ModelBuilder modelBuilder, params Assembly[] assemblies)
    {
        IEnumerable<Type> types = assemblies.SelectMany(a => a.GetExportedTypes()).Where(c => c.IsClass && !c.IsAbstract &&
            typeof(BaseEntity).IsAssignableFrom(c));
        foreach (Type type in types)
            modelBuilder.Entity(type);
    }
}
