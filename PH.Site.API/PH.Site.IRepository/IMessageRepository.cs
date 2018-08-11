using PH.Site.Model;
using System;
using System.Collections.Generic;

namespace PH.Site.IRepository
{
    public interface IMessageRepository : IBaseRepository<Message>
    {
        void Add(Message message);
        void Delete(int id);
        void Update(Message message);
        IList<Message> Get(Guid? appId);
    }
}
