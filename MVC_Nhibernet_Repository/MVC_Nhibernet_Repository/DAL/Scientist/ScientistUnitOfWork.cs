using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using MVC_Nhibernet_Repository.DAL;

namespace MVC_Nhibernet_Repository.DAL.Scientist
{
    public class ScientistUnitOfWork : IUnitOfWork
    {
        DatabaseModule _databaseModule = null;
        public ScientistUnitOfWork()
        {
            if (_databaseModule==null)
            {
                _databaseModule = new DatabaseModule();
            }
        }
        public void Save()
        {
            using (TransactionScope scope = new TransactionScope())
            {
              // will return to here later.
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}