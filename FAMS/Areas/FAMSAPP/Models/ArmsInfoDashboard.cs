using System.ComponentModel.DataAnnotations.Schema;

namespace FADMS.Areas.License.Models
{
    [NotMapped]
    public class ArmsInfoDashboard
    {
        public string TypeName { get; set; }
        public int? Total { get; set; }
       
    }
}
