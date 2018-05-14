﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PH.Site.DTO
{
    public class CategoryDTO
    {
        [Required]
        public Guid? CategoryId { get; set; }

        [Required]
        [StringLength(32)]
        public string Name { get; set; }

        [Required]
        [StringLength(128)]
        public string Url { get; set; }

        [StringLength(128)]
        public string Icon { get; set; }

        [StringLength(128)]
        public string QRCode { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
