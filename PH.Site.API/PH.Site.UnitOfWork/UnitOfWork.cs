using PH.Site.Common;
using PH.Site.IRepository;
using PH.Site.Repository;
using System.Data;
using System.Data.SqlClient;

namespace PH.Site.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbConnection _conn;
        private IDbTransaction _trans;
        public UnitOfWork()
        {
            string connStr = "data source=.;initial catalog=MyDb;;Integrated Security=True";
            _conn = new SqlConnection(connStr);
            _conn.Open();
            this._trans = _conn.BeginTransaction();
        }
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
            catch (System.Exception ex)
            {
                LogHelper.Error(ex.ToString());
                _trans.Rollback();
                throw;
            }
        }

        public IAppRepository AppRepository => new AppRepository(_conn, _trans);
    }
}
