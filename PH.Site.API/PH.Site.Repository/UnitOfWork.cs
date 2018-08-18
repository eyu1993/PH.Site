using PH.Site.IRepository;
using System;
using System.Data;
using System.Data.SqlClient;

namespace PH.Site.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbConnection _conn;
        private IDbTransaction _trans;
        public UnitOfWork()
        {
            _conn = new SqlConnection("data source=.;initial catalog=Site;user id=pinhua;password=pinhua.site");
            _conn.Open();
            _trans = _conn.BeginTransaction();
        }
        public IAppRepository AppRepository => new AppRepository(_conn, _trans);
        public ICategoryRepository CategoryRepository => new CategoryRepository(_conn, _trans);
        public IMessageRepository MessageRepository => new MessageRepository(_conn, _trans);
        public INewsRepository NewsRepository => new NewsRepository(_conn, _trans);

        public void Dispose()
        {
            if (_conn != null && _conn.State != ConnectionState.Closed)
            {
                _conn.Close();
                _conn.Dispose();
            }
        }

        public void SaveChanges()
        {
            try
            {
                _trans.Commit();
            }
            catch (Exception ex)
            {
                _trans.Rollback();
                throw;
            }
        }
    }
}
