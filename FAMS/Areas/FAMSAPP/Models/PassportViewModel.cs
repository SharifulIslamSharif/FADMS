using FADMS.Areas.FAMSAPP.Models.Lang;
//using FAMSAPPLICATION.Data.Entity.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FAMSAPPLICATION.Areas.License.Models
{
    public class PassportViewModel
    {

        public string employeeID { get; set; }

        public string passportId { get; set; }

        [Required]
        [Display(Name = "Passport Number")]
        public string passPortNumber { get; set; }

        [Required]
        [Display(Name = "Place of Issue")]
        public string place { get; set; }

        [Display(Name = "Date Of Issue")]
        public string dateOfIssue { get; set; }

        [Required]
        [Display(Name = "Date Of Expair")]
        public string dateOfExpair { get; set; }
        public string action { get; set; }

        public Passport fLang { get; set; }

        //public IEnumerable<PassportDetails> passportDetails { get; set; }
    }
}
