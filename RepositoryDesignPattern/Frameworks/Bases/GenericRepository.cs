using RepositoryDesignPattern.Frameworks.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDesignPattern.Frameworks.Bases;

internal class GenericRepository<TDbContext, TEntity, TPrimaryKey> : IGenericRepository<TEntity, TPrimaryKey>
                                                                          where TEntity : class
                                                                          where TDbContext : IdentityDbContext<User, Role, string,
                                                                              IdentityUserClaim<string>, UserRole, IdentityUserLogin<string>,
                                                                              IdentityRoleClaim<string>, IdentityUserToken<string>>
{
    #region Filds
    protected virtual TDbContext DbContext { get; set; }
    #endregion

    #region Constructor

    public GenericRepository()
    {
        
    }
    #endregion
}
