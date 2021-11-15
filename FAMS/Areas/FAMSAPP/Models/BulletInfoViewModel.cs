using FADMS.Areas.FAMSAPP.Models.Lang;
//using FAMSAPPLICATION.Data.Entity.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;



namespace FAMSAPPLICATION.Areas.License.Models
{
    public class BulletInfoViewModel
    {
        
        public int licenseId { get; set; }
        // public string armNo { get; set; }
        [Key]
        public int bulletId { get; set; }
        public string date { get; set; }
        public string source { get; set; }
        public int quantity { get; set; }
        public string bulletbyinfo { get; set; }
        //public BulletInfo bulletInfo { get; set; } 
        public BulletInfoLN fLang { get; set; }
    }
}
