using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace RepositoryPattern.DAL.Scientist
{
    public class ScientistUnitOfWork : IUnitOfWork
    {
        private DatabaseModule _context = new DatabaseModule();
        public ScientistRepository<ScientistEntity> _scientistRepository;
        public ScientistRepository<Invention> _scientistRepositoryInvention;
        private bool _disposed = false;

        public ScientistRepository<ScientistEntity> ScientistRepository
        {
            get
            {
                if (_scientistRepository == null)
                    _scientistRepository = new ScientistRepository<ScientistEntity>(_context);
                return _scientistRepository;
            }
        }
        public ScientistRepository<Invention> ScientistRepositoryInvention
        {
            get
            {
                if (_scientistRepositoryInvention == null)
                    _scientistRepositoryInvention = new ScientistRepository<Invention>(_context);
                return _scientistRepositoryInvention;
            }
        }

        public void Save()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                _context.SaveChanges();
                scope.Complete();
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
