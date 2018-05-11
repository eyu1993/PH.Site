using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PH.Site.DTO
{
    public class CategoryDTO
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(32)]
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public string QRCode { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
