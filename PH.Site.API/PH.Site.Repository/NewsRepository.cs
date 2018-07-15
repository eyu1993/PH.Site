using PH.Site.IRepository;
using PH.Site.Model;
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

        public void Add(News news)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(News news)
        {
            throw new NotImplementedException();
        }

        public void UpdateVisible(int id)
        {
            throw new NotImplementedException();
        }
    }
}
