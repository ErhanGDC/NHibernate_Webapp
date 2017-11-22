using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using MVC_Nhibernet_Repository.DAL;
using NHibernate;

namespace MVC_Nhibernet_Repository.DAL.Scientist
{
    public class ScientistRepository<T> : IGenericRepository<T> where T : class
    {
        DatabaseModule _databaseModule = null;
        public ScientistRepository()
        {
            if (_databaseModule == null)
            {
                _databaseModule = new DatabaseModule();
            }
        }

        public void Delete(object EntityId)
        {
            throw new NotImplementedException();
        }

        public void Delete(T Entity)
        {
            throw new NotImplementedException();
        }

        public T FindById(object EntityId)
        {
            throw new NotImplementedException();
        }

        public void Insert(T Entity)
        {
        }

        public IEnumerable<T> Select(Expression<Func<T, bool>> Filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(T Entity)
        {
            throw new NotImplementedException();
        }
    }
}