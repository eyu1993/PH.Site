using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public Guid AppId { get; set; }

        [Required]
        [StringLength(32)]
        public string AppName { get; set; }

        [StringLength(128)]
        public string Image { get; set; }

        [StringLength(128)]
        public string CodeUrl { get; set; }

        public string Description { get; set; }

        public virtual ICollection<CategoryDTO> Category { get; set; }
    }
}
