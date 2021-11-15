using System.ComponentModel.DataAnnotations;

namespace FADMS.Areas.FAMSAPP.Models.Lang
{
    public class BulletInfoLN
    {
        [Key]
        public string licenseID { get; set; }
        public string armNo { get; set; }
        public string date { get; set; }
        public string source { get; set; }
        public string quantity { get; set; }
        public string bulletbyinfo { get; set;}
    }
}
