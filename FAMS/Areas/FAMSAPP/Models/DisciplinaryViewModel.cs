using FADMS.Areas.FAMSAPP.Models.Lang;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FAMSAPPLICATION.Areas.License.Models
{
    public class DisciplinaryViewModel
    {
        [Required]
        [Display(Name ="Action Name")]
        public string actionName { get; set; }

        [Required]
        [Display(Name = "Action Date")]
        public string actionDate { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string description { get; set; } 
        
        [Display(Name = "Duration")]
        public string duration { get; set; }
        public string action { get; set; }

        public Disciplinary fLang { get; set; }
    }
}
