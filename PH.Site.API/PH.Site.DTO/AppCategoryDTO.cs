using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations;

namespace PH.Site.DTO
{
    public class AppCategoryDTO
    {

        [BindRequired]
        public Guid CategoryId { get; set; }

        [Required]
        [StringLength(128)]
        public string Url { get; set; }

        [BindNever]
        public string Name { get; set; }

        [BindNever]
        public string Icon { get; set; }

        [StringLength(128)]
        public string QRCode { get; set; }

        [BindNever]
        public DateTime? CreateDate { get; set; }

        [BindNever]
        public DateTime? ModifyDate { get; set; }
    }
}
