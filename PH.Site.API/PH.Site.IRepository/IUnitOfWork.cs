using System;

namespace PH.Site.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
        IAppRepository AppRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IMessageRepository MessageRepository { get; }
        INewsRepository NewsRepository { get; }
    }
}
