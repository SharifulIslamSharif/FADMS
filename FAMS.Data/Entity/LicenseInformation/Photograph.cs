using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FADMS.Data.Entity.LicenseInformation
{
    public class Photograph : Base
    {
        public int? personalInfoId { get; set; }
        public PersonalInfo personalInfo { get; set; }
        public int? organizationInfoId { get; set; }
        public OrganizationInfo OrganizationInfo { get; set; }

        [Required]
        public string url { get; set; }
        [Column(TypeName = "NVARCHAR(300)")]
        public string remarks { get; set; }

        [Required]
        public string type { get; set; }
    }
}
