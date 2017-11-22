using System;

namespace MVC_Nhibernet_Repository.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        // can create another operations
        // void OpenTransaction(); 
        // void CloseTransaction(); 
        // etc..      
    }
}