using PH.Site.Model.BaseModel;
using System;

namespace PH.Site.Model
{
    public class Message : AggregateRoot
    {
        public int Id { get; set; }
        public Guid? AppId { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; }
        public DateTime ReplyTime { get; set; }
        public int ReplyId { get; set; }
        public int Order { get; set; }
        public string Ip { get; set; }
        public string Address { get; set; }
        public bool IsShow { get; set; }
        public bool IsPass { get; set; }
    }
}
