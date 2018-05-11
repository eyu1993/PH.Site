using PH.Site.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PH.Site.ViewModel
{
    public class AppViewModel : BaseViewModel
    {
        public AppViewModel()
        {
            Categories = new List<AppCategory>();
        }
        public Guid AppId { get; set; }
        public string AppName { get; set; }
        public string Image { get; set; }
        public string CodeUrl { get; set; }
        public string Description { get; set; }
        public virtual ICollection<AppCategory> Categories { get; set; }
    }
}
