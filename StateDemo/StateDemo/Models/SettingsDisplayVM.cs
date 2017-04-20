using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StateDemo.Models
{
    public class SettingsDisplayVM
    {
        [Display(Name = "Support E-mail")]
        public string SupportEmail { get; set; }

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        public string StatusMessage { get; set; }
    }
}
