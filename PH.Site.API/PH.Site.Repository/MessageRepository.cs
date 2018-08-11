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
            string sql = "insert into Message Values(@AppId,@UserId,@Content,@ReplyTime,@ReplyId,@Order,@Ip,@Address,@IsShow,@IsPass)";
            _conn.Execute(sql, new
            {
                AppId = message.AppId,
                UserId = message.UserId,
                Content = message.Content,
                ReplyTime = message.ReplyTime,
                ReplyId = message.ReplyId,
                Order = message.Order,
                Ip = message.Ip,
                Address = message.Address,
                IsShow = message.IsShow,
                IsPass = message.IsPass
            }, transaction: _trans);
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

        public IList<Message> Get(Guid? appId)
        {
            string sql = "select * from Message where AppId=@AppId";
            return _conn.Query<Message>(sql, new { AppId = appId }, transaction: _trans).AsList();
        }
    }
}
