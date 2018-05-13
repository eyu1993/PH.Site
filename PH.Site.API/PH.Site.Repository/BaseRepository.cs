using System.Data;

namespace PH.Site.Repository
{
    public class BaseRepository
    {
        public IDbConnection _conn;
        public IDbTransaction _trans;
        public BaseRepository(IDbConnection connection, IDbTransaction transaction)
        {
            this._conn = connection;
            this._trans = transaction;
        }
    }
}
