using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StateDemo.Models
{
    public class SettingsCreateVM
    {
        [Display(Name = "Support E-mail")]
        [Required]
        public string SupportEmail { get; set; }

        [Display(Name = "Company Name")]
        [Required]
        public string CompanyName { get; set; }
    }
}
