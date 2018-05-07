using PH.Site.IRepository;
using PH.Site.Repository;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;

namespace PH.Site.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbConnection _conn;
        private IDbTransaction _trans;
        public UnitOfWork()
        {
            string connStr = "";
            _conn = new SqlConnection(connStr);
            _conn.Open();
        }
        public void BeginTransaction()
        {
            this._trans = _conn.BeginTransaction();
        }
        public void Commit()
        {
            _trans.Commit();
        }
        public void Rollback()
        {
            _trans.Rollback();
        }
        public void Dispose()
        {
            if (_conn != null && _conn.State != ConnectionState.Closed)
            {
                _conn.Close();
                _conn.Dispose();
            }
        }




        public IAppRepository AppRepository => new AppRepository(_conn, _trans);
    }
}
