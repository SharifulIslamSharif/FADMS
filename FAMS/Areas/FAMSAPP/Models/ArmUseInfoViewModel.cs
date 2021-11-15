using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using FADMS.Areas.FAMSAPP.Models.Lang;
//using FAMSAPPLICATION.Data.Entity.Employee;

namespace FAMSAPPLICATION.Areas.License.Models
{
    public class ArmUseInfoViewModel
    {


        public int? licenseId { get; set; }
        [Key]
        public int amrUseId { get; set; }
        public string Reason { get; set; }
      
        public string GDNo { get; set; }
        //public int? DocumentId { get; set; }
        public string Address { get; set; }
       public int ArmUseTypeId { get; set; }
        public int DivisionId { get; set; }
        public int DistrictId { get; set; }
        public int ThanaId { get; set; }
        public string BulletQuantity { get; set; }


        //public ArmUseInfo ArmUseInfo { get; set; }
        //public ArmUseType armUseType { get; set; }
        public ArmUseInfoLn fLang { get; set; }

       // public IEnumerable<EducationalQualification> educationalQualifications { get; set; }
    }
}
