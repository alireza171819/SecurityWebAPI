using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Model.Frameworks;
using System.Reflection;

namespace EfCore;

/// <summary>
/// Provides the database context for a web API application.
/// </summary>
/// <remarks>
/// The context is configured via dependency injection and exposes
/// <see cref="DbSet{TEntity}"/> properties for each entity type.
/// </remarks>
public class SecurityWebAPIContext : IdentityDbContext<MbssUser, MbssRole, string,
        IdentityUserClaim<string>, MbssUserRole, IdentityUserLogin<string>,
        IdentityRoleClaim<string>, IdentityUserToken<string>>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SecurityWebAPIContext"/> class
    /// using the supplied options.
    /// </summary>
    /// <param name="options">The options used to configure the context.</param>
    public SecurityWebAPIContext(DbContextOptions<SecurityWebAPIContext> options)
        : base(options)
    {
    }


    #region [- OnModelCreating(ModelBuilder modelBuilder) -]
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.RegisterAllEntities<IDbSetEntity>(typeof(IDbSetEntity).Assembly);

        base.OnModelCreating(modelBuilder);
    }
    #endregion
}

