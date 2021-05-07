using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CSD.Util.Repository
{
    public interface ICrudRepository<Entity, ID>
    {
        #region Sync Operations

        IEnumerable<Entity> All { get; }
        long Count();
        void DeleteBy(Entity t);
        void DeleteById(ID id);
        bool ExistById(ID id);
        IEnumerable<Entity> FindBy(Expression<Func<Entity, bool>> predicate);
        Entity FindById(ID id);
        IEnumerable<Entity> FindByIds(IEnumerable<ID> ids);
        Entity Save(Entity entity);
        int SaveAll(IEnumerable<Entity> entities);

        #endregion

        #region Async Operations

        Task<long> CountAsync();
        Task DeleteByAsync(Entity entity);
        Task DeleteByIdAsync(ID id);
        Task<bool> ExistByIdAsync(ID id);
        Task<IEnumerable<Entity>> FindAllAsync();
        Task<IEnumerable<Entity>> FindByAsync(Expression<Func<Entity, bool>> predicate);
        Task<Entity> FindByIdAsync(ID id);
        Task<IEnumerable<Entity>> FindByIdsAsync(IEnumerable<ID> ids);
        Task<int> SaveAllAsync(IEnumerable<Entity> entities);
        Task<Entity> SaveAsync(Entity entity);

        #endregion
    }
}