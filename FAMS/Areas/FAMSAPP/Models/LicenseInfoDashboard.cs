using System.ComponentModel.DataAnnotations.Schema;

namespace FAMSAPPLICATION.Areas.License.Models
{
   [NotMapped]
    public class LicenseInfoDashboard
    {
   
        public int? ApplicantSubmit { get; set; }
        public int? District { get; set; }
        public int? Megistrait { get; set; }
        public int? DCtoHome { get; set; }
        public int? HM { get; set; }
        public int? ToApproved { get; set; }
        public int? Approved { get; set; }
        public int? LicenseAssign { get; set; }
        public int? spin { get; set; }
        public int? spout { get; set; }
        public int? magin { get; set; }
        public int? magout { get; set; }
        public int? HMA { get; set; }

    }
}
