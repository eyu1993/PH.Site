using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations;

namespace PH.Site.DTO
{
    public class CategoryDTO
    {
        [BindRequired]
        public Guid CategoryId { get; set; }

        [BindRequired]
        [StringLength(32)]
        public string Name { get; set; }

        [BindRequired]
        [StringLength(128)]
        public string Icon { get; set; }
    }
}
