using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace MyAbpDemo.EntityFramework.Repositories
{
    public abstract class MyAbpDemoRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<MyAbpDemoDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected MyAbpDemoRepositoryBase(IDbContextProvider<MyAbpDemoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class MyAbpDemoRepositoryBase<TEntity> : MyAbpDemoRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected MyAbpDemoRepositoryBase(IDbContextProvider<MyAbpDemoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
