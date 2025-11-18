using Domain.Aggregates.UserManagementAggregates;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RepositoryDesignPattern.Frameworks.Abstracts;
using ResponseFramework;

namespace RepositoryDesignPattern.Frameworks.Bases;

public class GenericRepository<TDbContext, TEntity, TPrimaryKey> : IGenericRepository<TEntity, TPrimaryKey>
                                                                          where TEntity : class
                                                                          where TDbContext : IdentityDbContext<User, Role, string,
                                                                              IdentityUserClaim<string>, UserRole, IdentityUserLogin<string>,
                                                                              IdentityRoleClaim<string>, IdentityUserToken<string>>
{
    #region Filds
    protected virtual TDbContext DbContext { get; set; }
    protected virtual DbSet<TEntity> DbSet { get; set; }
    #endregion

    #region Constructor

    public GenericRepository()
    {
        
    }
    #endregion

    #region [- InsertAsync(T_Entity entity) -]
    public virtual async Task<IResponse<object>> InsertAsync(TEntity entity)
    {
        DbSet.Add(entity);
        await SaveChanges();
        return new Response<object>(entity);

    }
    #endregion

    #region [- UpdateAsync(T_Entity entity) -]
    public virtual async Task<IResponse<object>> UpdateAsync(TEntity entity)
    {
        DbSet.Attach(entity);
        DbContext.Entry(entity).State = EntityState.Modified;
        await SaveChanges();
        return new Response<object>(entity);
    }
    #endregion

    #region [- DeleteAsync(U_PrimaryKey id) -]
    public virtual async Task<IResponse<object>> DeleteAsync(TPrimaryKey id)
    {
        var entityToDelete = DbSet.FindAsync(id).Result;
        if (entityToDelete == null) return new Response<object>("");
        DbSet.Remove(entityToDelete);
        await SaveChanges();
        return new Response<object>(entityToDelete);
    }
    #endregion

    #region [- DeleteAsync(T_Entity entityToDelete) -]
    public virtual async Task<IResponse<object>> DeleteAsync(TEntity entityToDelete)
    {
        if (DbContext.Entry(entityToDelete).State == EntityState.Detached)
            DbSet.Attach(entityToDelete);

        DbSet.Remove(entityToDelete);
        await SaveChanges();
        return new Response<object>(entityToDelete);
    }
    #endregion

    #region [- Select() -]
    public virtual async Task<IResponse<List<TEntity>>> Select()
    {
        var q = await DbSet.AsNoTracking().ToListAsync();
        var response = new Response<List<TEntity>>(new List<TEntity>()) { Result = q };
        return response;
    }
    #endregion

    #region [- FindByIdAsync(TPrimaryKey id) -]
    public virtual async Task<IResponse<TEntity>> FindByIdAsync(TPrimaryKey? id)
    {
        var q = await DbSet.FindAsync(id);
        return q == null ? new Response<TEntity>("") : new Response<TEntity>(q);
    }
    #endregion

    #region [- SaveChanges() -]
    public async Task SaveChanges()
    {
        await DbContext.SaveChangesAsync();
    }


    #endregion
}
