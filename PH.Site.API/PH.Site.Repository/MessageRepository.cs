using Dapper;
using PH.Site.IRepository;
using PH.Site.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PH.Site.Repository
{
    public class MessageRepository : BaseRepository, IMessageRepository
    {
        public MessageRepository(IDbConnection connection, IDbTransaction transaction) : base(connection, transaction)
        {

        }

        public void Add(Message message)
        {
            string sql = "insert into Message Values(@Address,@ReplyTime,@ReplyId,@Order,@AppId,@IsShow,@IsPass,@UserId)";
            _conn.Execute(sql, message, transaction: _trans);
        }

        public void Delete(int id)
        {
            string sql = "delete from Message where Id=@Id";
            _conn.Execute(sql, new { Id = id }, transaction: _trans);
        }

        public void Update(Message message)
        {
            throw new NotImplementedException();
        }

        public IList<Message> Get(Guid appId)
        {
            throw new NotImplementedException();
        }
    }
}
