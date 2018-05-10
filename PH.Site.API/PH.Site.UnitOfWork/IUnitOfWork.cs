using PH.Site.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PH.Site.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
        IAppRepository AppRepository { get; }
    }
}
