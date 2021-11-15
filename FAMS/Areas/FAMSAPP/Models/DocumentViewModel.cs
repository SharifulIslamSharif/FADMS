using FADMS.Areas.FAMSAPP.Models.Lang;
//using FAMSAPPLICATION.Data.Entity.Employee;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FAMSAPPLICATION.Areas.License.Models
{

    [NotMapped]
    public class DocumentViewModel
    {
        public int? ApplicantID { get; set; }
        public int? DocSubjectId{get;set;}
        public string FileLocation { get; set; }
        public string FileName { get; set; }
        public string Descriptione { get; set; }


     //  public subject subject { get; set; }
        //public Data.Entity.Employee.Address present { get; set; }
        //public Data.Entity.Employee.Address permanent { get; set; }
    }
}
