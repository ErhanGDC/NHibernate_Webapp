using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.DAL
{
    public interface IUnitOfWork
        : IDisposable
    {
        void Save();
        // can create another operations
        // void OpenTransaction(); 
        // void CloseTransaction(); 
        // etc..
    }
}
