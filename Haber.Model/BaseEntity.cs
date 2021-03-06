﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Model
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        [Display(Name = "Ekleyen Kişi")]
        public string CreatedBy { get; set; }
        [Display(Name = "Eklenme Tarihi")]
        public DateTime CreatedAt { get; set; }
        [Display(Name = "Güncelleyen Kişi")]
        public string UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }

        public string Slug { get; set; }
    }
}
