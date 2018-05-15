using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations;

namespace PH.Site.DTO
{
    public class AppCategoryDTO
    {
        [BindRequired]
        public Guid AppId { get; set; }

        [BindRequired]
        public Guid CategoryId { get; set; }

        [Required]
        [StringLength(128)]
        public string Url { get; set; }

        [StringLength(128)]
        public string QRCode { get; set; }
    }
}
