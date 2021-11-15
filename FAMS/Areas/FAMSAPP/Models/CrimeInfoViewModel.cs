using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using FADMS.Areas.FAMSAPP.Models.Lang;
//using FAMSAPPLICATION.Data.Entity.Employee;
using System.ComponentModel.DataAnnotations.Schema;
using FADMS.Areas.FAMSAPP.Models.Lang;

namespace FAMSAPPLICATION.Areas.License.Models
{
    [NotMapped]
    public class CrimeInfoViewModel
    {


        public int employeeId { get; set; }

        public int crmInfoId { get; set; }
        public string Reason { get; set; }
   
        public string CaseNo { get; set; }

        public string CaseDate { get; set; }

        public string Result { get; set; }
       public int? crimeResultTypeId { get; set; }

        //public CrimeInfo crimeInfo { get; set; }
        public CrimeInfoLn fLang { get; set; }

       // public IEnumerable<EducationalQualification> educationalQualifications { get; set; }
    }
}
