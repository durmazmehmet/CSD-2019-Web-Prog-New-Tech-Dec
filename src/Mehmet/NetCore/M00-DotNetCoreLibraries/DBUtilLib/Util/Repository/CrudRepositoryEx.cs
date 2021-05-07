using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static CSD.Util.DbUtil;

namespace CSD.Util.Repository
{
    //Interface (ICrudRepository) re-implemation yapıyoruz
    public class CrudRepositoryEx<Entity, ID, Context> : CrudRepository<Entity, ID, Context>,
        ICrudRepository<Entity, ID>
        where Entity : class, IEntity<ID>
        where Context : DbContext
    {
        public CrudRepositoryEx(Context context) : base(context) { }

        #region ASync Operations

        public new Task<IEnumerable<Entity>> FindAllAsync =>
            DoWorkForRepositoryAsync(() => base.FindAllAsync(), "CrudRepositoryEx.FindAllAsync");

        public new Task<long> CountAsync() =>
            DoWorkForRepositoryAsync(() => base.CountAsync(), "CrudRepositoryEx.CountAsync");


        public new Task DeleteByAsync(Entity entity) =>
            DoWorkForRepositoryAsync(() => base.DeleteByAsync(entity), "CrudRepositoryEx.DeleteByAsync");


        public new Task DeleteByIdAsync(ID id) =>
            DoWorkForRepositoryAsync(() => base.DeleteByIdAsync(id), "CrudRepositoryEx.DeleteByIdAsync");


        public new Task<bool> ExistByIdAsync(ID id) =>
            DoWorkForRepositoryAsync(() => base.ExistByIdAsync(id), "CrudRepositoryEx.ExistByIdAsync");


        public new Task<Entity> FindByIdAsync(ID id) =>
            DoWorkForRepositoryAsync(() => base.FindByIdAsync(id), "CrudRepositoryEx.FindByIdAsync");


        public new Task<IEnumerable<Entity>> FindByIdsAsync(IEnumerable<ID> ids) =>
            DoWorkForRepositoryAsync(() => base.FindByIdsAsync(ids), "CrudRepositoryEx.FindByIdsAsync");


        public new Task<Entity> SaveAsync(Entity entity) =>
            DoWorkForRepositoryAsync(() => base.SaveAsync(entity), "CrudRepositoryEx.SaveAsync");


        public new Task<int> SaveAllAsync(IEnumerable<Entity> entities) =>
            DoWorkForRepositoryAsync(() => base.SaveAllAsync(entities), "CrudRepositoryEx.SaveAllAsync");

        #endregion

        #region Sync Operations

        public new IEnumerable<Entity> All => DoWorkForRepository(() => base.All, "CrudRepositoryEx.All");

        public new long Count() => DoWorkForRepository(() => base.Count(), "CrudRepositoryEx.Count");


        public new void DeleteBy(Entity entity) =>
            DoWorkForRepository(() => base.DeleteBy(entity), "CrudRepositoryEx.DeleteBy");


        public new void DeleteById(ID id) =>
            DoWorkForRepository(() => base.DeleteById(id), "CrudRepositoryEx.DeleteById");


        public new bool ExistById(ID id) => DoWorkForRepository(() => base.ExistById(id), "CrudRepositoryEx.ExistById");


        public new Entity FindById(ID id) => DoWorkForRepository(() => base.FindById(id), "CrudRepositoryEx.FindById");


        public new IEnumerable<Entity> FindByIds(IEnumerable<ID> ids) =>
            DoWorkForRepository(() => base.FindByIds(ids), "CrudRepositoryEx.FindByIds");


        public new Entity Save(Entity entity) => DoWorkForRepository(() => base.Save(entity), "CrudRepositoryEx.Save");


        public new int SaveAll(IEnumerable<Entity> entities) =>
            DoWorkForRepository(() => base.SaveAll(entities), "CrudRepositoryEx.SaveAll");

        #endregion
    }
}