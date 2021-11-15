using System.ComponentModel.DataAnnotations.Schema;

namespace FAMSAPPLICATION.Areas.License.Models
{
    [NotMapped]
    public class ArmsInfoDashboardDivDetail
    {
                          


        public string licenseNumber { get; set; }
   
        public string LicenseTypeName { get; set; }
        public string ArmTypeName { get; set; }
        public string dateOfIssue { get; set; }
        public string dateOfExpair { get; set; }
        public string place { get; set; }
        public string reason { get; set; }
        public string source { get; set; }
        public string thanaName { get; set; }
        public string districtName { get; set; }
        public string divisionName { get; set; }
    }
}
