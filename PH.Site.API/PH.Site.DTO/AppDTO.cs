using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PH.Site.DTO
{
    public class AppDTO
    {
        public AppDTO()
        {
            Category = new List<AppCategoryDTO>();
        }
        [BindRequired]
        public Guid AppId { get; set; }

        [Required]
        [StringLength(32)]
        public string AppName { get; set; }

        [Required]
        [StringLength(128)]
        public string Image { get; set; }

        [StringLength(128)]
        public string CodeUrl { get; set; }

        public string Description { get; set; }

        [BindNever]
        public virtual ICollection<AppCategoryDTO> Category { get; set; }
    }
}
