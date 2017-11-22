using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MVC_Nhibernet_Repository.DAL
{
    public interface IGenericRepository<T> where T : class
    {
        T FindById(object EntityId);
        IEnumerable<T> Select(Expression<Func<T, bool>> Filter = null);
        void Insert(T Entity);
        void Update(T Entity);
        void Delete(object EntityId);
        void Delete(T Entity);
    }
}