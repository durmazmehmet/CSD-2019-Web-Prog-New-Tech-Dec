using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CSD.Util.Repository
{
    public interface ICrudRepository<T, ID>
    {
        #region Sync methods
        IEnumerable<T> All { get; }

        long Count();

        void Delete(T t);

        void DeleteById(ID id);

        bool ExistsById(ID id);

        T FindById(ID id);

        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);        

        IEnumerable<T> FindByIds(IEnumerable<ID> ids);

        T Save(T t);

        IEnumerable<T> Save(IEnumerable<T> entities);
        #endregion

        #region ASync methods

        Task<IEnumerable<T>> FindAllAsync();

        Task<long> CountAsync();

        Task DeleteAysnc(T t);

        Task DeleteByIdAsync(ID id);

        Task<bool> ExistsByIdAsync(ID id);

        Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> predicate);

        Task<T> FindByIdAsync(ID id);

        Task<IEnumerable<T>> FindByIdsAsync(IEnumerable<ID> ids);

        Task<T> SaveAsync(T t);

        Task<IEnumerable<T>> SaveAsync(IEnumerable<T> entities);

        #endregion
    }
}
