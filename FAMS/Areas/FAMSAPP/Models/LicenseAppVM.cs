using System.ComponentModel.DataAnnotations.Schema;

namespace FAMSAPPLICATION.Areas.License.Models
{
    [NotMapped]
    public class LicenseAppVM
    {

        public int? Id { get; set; }
        public string reason { get; set; }
        public int? licenseTypeId { get; set; }
        public int? armTypeId { get; set; }
        public string LicenseTypeName { get; set; }
        public string ArmTypeName { get; set; }
        public string nameBangla { get; set; }
        public string nationalID { get; set; }
        public string sourceType { get; set; }
        public int? status { get; set; }
        public string ApplicationNo { get; set; }
        

    }


}
