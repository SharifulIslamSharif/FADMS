using System.ComponentModel.DataAnnotations.Schema;

namespace FAMSAPPLICATION.Areas.License.Models
{
   [NotMapped]
    public class LicenseInfoDashboardPivot
    {
   
        public string indicatorname { get; set; }
        public int? indicatorvalue { get; set; }
    

    }
}
