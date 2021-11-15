using System.ComponentModel.DataAnnotations.Schema;

namespace FAMSAPPLICATION.Areas.License.Models
{
    [NotMapped]
    public class ArmsInfoToplist
    {


                       
        public int Id { get; set; }
        public int licenseTypeId { get; set; }
        public int armTypeId { get; set; }
        public string licenseNumber { get; set; }
   
        public string LicenseTypeName { get; set; }
        public string ArmTypeName { get; set; }
        public string dateOfIssue { get; set; }
        public string dateOfExpair { get; set; }
        public string place { get; set; }
        public string reason { get; set; }
        public string source { get; set; }
       
    }
}
