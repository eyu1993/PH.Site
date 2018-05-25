using PH.Site.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PH.Site.Repository
{
    public class NewsRepository : BaseRepository, INewsRepository
    {
        public NewsRepository(IDbConnection connection, IDbTransaction transaction) : base(connection, transaction)
        {
        }
    }
}
