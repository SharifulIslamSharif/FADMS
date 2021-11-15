using System.ComponentModel.DataAnnotations.Schema;

namespace FAMSAPPLICATION.Areas.License.Models
{
    [NotMapped]
    public class ArmsInfoDashboardDivPivot
    {
   
       
        public string TypeName { get; set; }
   
        public int? Pistol { get; set; }
        public int? Revolbar { get; set; }
        public int? Eknola { get; set; }
        public int? Donola { get; set; }
        public int? ShortGun { get; set; }
        public int? Raifel { get; set; }
    }
}
