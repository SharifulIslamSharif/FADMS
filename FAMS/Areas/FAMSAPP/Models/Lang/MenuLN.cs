using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FADMS.Areas.FAMSAPP.Models.Lang
{
    [NotMapped]
    public class MenuLN
    {
        public string title { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string designation { get; set; }
        public string mobileNumberPersonal { get; set; }
        public string emailAddressPersonal { get; set; }
        public string basic { get; set; }
        public string address { get; set; }
        public string traning { get; set; }
        public string gd { get; set; }
        public string tax { get; set; }
        public string photo { get; set; }
        public string useGun { get; set; }
        public string gunBuy { get; set; }
        public string gunStolen { get; set; }

    }
}
