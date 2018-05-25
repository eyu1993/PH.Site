using PH.Site.Model.BaseModel;
using System;

namespace PH.Site.Model
{
    public class AppCategory : IEntity
    {
        public Guid AppId { get; set; }
        public Guid CategoryId { get; set; }
        public string Url { get; set; }
        public string QRCode { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        //public bool IsActive { get; set; }
    }
}
