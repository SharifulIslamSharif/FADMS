using FADMS.Areas.FAMSAPP.Models.Lang;
//using FAMSAPPLICATION.Data.Entity.Employee;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FAMSAPPLICATION.Areas.License.Models
{
    [NotMapped]
    public class SpouseViewModel
    {
        public int employeeId { get; set; }

        public int spouseID { get; set; }
       
        [Required]
        [Display(Name = "Spouse Name")]
        public string spouseName { get; set; }
        public int licenseId { get; set; }
        public string spouseNameBN { get; set; }

        [Required]
        [Display(Name ="Date Of Birth")]
        public DateTime dateOfBirth { get; set; }

        [Required]
        [Display(Name = "Occupation")]
        public string occupation { get; set; }

        public string gender { get; set; }

        public string designation { get; set; }

        public string organization { get; set; }

        public string bin { get; set; }

        public string nid { get; set; }

        public string bloodGroup { get; set; }

        [Required]
        [Display(Name ="Mobile Number")]        
        public string contact { get; set; }

        public string higherEducation { get; set; }

        public SpouseLn fLang { get; set; }

        //public Spouse spouse { get; set; }
    }
}
