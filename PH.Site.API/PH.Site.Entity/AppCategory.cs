using System;

namespace PH.Site.Entity
{
    public class AppCategory
    {
        public Guid AppId { get; set; }
        public Guid CategoryId { get; set; }
        public string AppUrl { get; set; }
        public string QRCode { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
