using PH.Site.Model.BaseModel;
using System;

namespace PH.Site.Model
{
    public class News : AggregateRoot
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsShow { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
