using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.DAL.Scientist
{
    public class ScientistRepository<T> : IGenericRepository<T> where T : class
    {
        private DatabaseModule _context;
        private DbSet<T> _dbSet;
        public ScientistRepository(DatabaseModule context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public T FindById(object EntityId)
        {
            return _dbSet.Find(EntityId);
        }

        public virtual IEnumerable<T> Select(Expression<Func<T, bool>> Filter = null)
        {
            if (Filter != null)
            {
                return _dbSet.Where(Filter);
            }
            return _dbSet;
        }

        public void Delete(object EntityId)
        {
            T entityToDelete = _dbSet.Find(EntityId);
            Delete(entityToDelete);
        }

        public virtual void Delete(T Entity)
        {
            if (_context.Entry(Entity).State == EntityState.Detached)//For Concurrency
            {
                _dbSet.Attach(Entity);
            }
            _dbSet.Remove(Entity);
        }

        public void Insert(T Entity)
        {
            _dbSet.Add(Entity);
        }

        public virtual void Update(T entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
