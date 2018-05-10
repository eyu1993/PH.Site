using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PH.Site.WebAPI.Models
{
    public class AppDTO
    {
        public AppDTO()
        {
            Category = new List<CategoryDTO>();
        }
        public Guid AppId { get; set; }
        public string AppName { get; set; }
        public string Image { get; set; }
        public string CodeUrl { get; set; }
        public string Description { get; set; }
        public virtual ICollection<CategoryDTO> Category { get; set; }
    }
}
