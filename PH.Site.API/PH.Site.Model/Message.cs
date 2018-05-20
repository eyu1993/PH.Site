using PH.Site.Model.BaseModel;
using System;

namespace PH.Site.Model
{
    public class Message : AggregateRoot
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
        public string ReplyTime { get; set; }
        public string ReplyId { get; set; }
        public bool IsShow { get; set; }
        public bool IsPass { get; set; }
        public Guid UserId { get; set; }
    }
}
