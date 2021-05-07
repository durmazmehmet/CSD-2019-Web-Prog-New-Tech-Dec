using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static CSD.Util.DbUtil;

namespace CSD.Util.Repository
{
    public class CrudRepository<Entity, ID, Context> : ICrudRepository<Entity, ID> where Entity : class, IEntity<ID>
        where Context : DbContext
    {
        private readonly DbSet<Entity> m_entities;

        public CrudRepository(Context context)
        {
            Ctx = context;
            m_entities = Ctx.Set<Entity>();
        }

        //public interface ICrudRepository<Entity, ID>
        public Context Ctx { get; }

        #region Sync Operations

        public IEnumerable<Entity> All => m_entities.ToList();
        public long Count() => m_entities.LongCount();
        public void DeleteBy(Entity t) => DeleteById(t.Id);

        public void DeleteById(ID id)
        {
            var e = FindById(id);

            if (e == null)
                return;

            m_entities.Remove(e);

            Ctx.SaveChanges(); //ayık ol
        }

        public bool ExistById(ID id) => FindById(id) != default;

        public IEnumerable<Entity> FindBy(Expression<Func<Entity, bool>> predicate) =>
            m_entities.Where(predicate).ToList();

        public Entity FindById(ID id) => m_entities.FirstOrDefault(x => x.Id.Equals(id));

        public IEnumerable<Entity> FindByIds(IEnumerable<ID> ids)
        {
            if (ids.Count() == 0)
                return default;

            var results = new List<Entity>();

            foreach (var id in ids)
                results.Add(m_entities.FirstOrDefault(x => x.Id.Equals(id)));

            return results;
        }

        public Entity Save(Entity entity)
        {
            if (ExistById(entity.Id))
                m_entities.Update(entity);
            else
                m_entities.Add(entity);

            Ctx.SaveChanges();
            return entity;
        }

        public int SaveAll(IEnumerable<Entity> entities)
        {
            foreach (var entity in entities)
                Save(entity);

            return Ctx.SaveChanges();
        }

        #endregion

        #region Async Operations

        public Task<IEnumerable<Entity>> FindAllAsync() =>
            WrapNStart(new Task<IEnumerable<Entity>>(() => m_entities.ToList()));

        public Task<long> CountAsync() => m_entities.LongCountAsync();
        public Task DeleteByIdAsync(ID id) => WrapNStart(new Task(() => DeleteById(id)));
        public Task DeleteByAsync(Entity entity) => DeleteByIdAsync(entity.Id);

        public Task<bool> ExistByIdAsync(ID id) =>
            WrapNStart(new Task<bool>(() => FindByIdAsync(id).Result != default(Entity)));

        public Task<IEnumerable<Entity>> FindByAsync(Expression<Func<Entity, bool>> predicate) =>
            WrapNStart(new Task<IEnumerable<Entity>>(() => m_entities.Where(predicate).ToList()));

        public Task<Entity> FindByIdAsync(ID id) => m_entities.FirstOrDefaultAsync(x => x.Id.Equals(id));

        public Task<IEnumerable<Entity>> FindByIdsAsync(IEnumerable<ID> ids) =>
            WrapNStart(new Task<IEnumerable<Entity>>(() => FindByIds(ids)));

        public Task<Entity> SaveAsync(Entity entity)
        {
            if (ExistById(entity.Id))
                m_entities.Update(entity);
            else
                m_entities.Add(entity);

            return WrapNStart(new Task<Entity>(() =>
            {
                Ctx.SaveChanges();
                return entity;
            }));
        }

        public Task<int> SaveAllAsync(IEnumerable<Entity> entities)
        {
            foreach (var entity in entities)
                SaveAsync(entity);

            Ctx.SaveChanges();
            return Ctx.SaveChangesAsync();
        }

        #endregion
    }
}