using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FADMS.Data.Entity.LicenseInformation
{
    public class LicenseType:Base
    {
        [Column(TypeName = "NVARCHAR(160)")]
        public string name { get; set; }
        [Column(TypeName = "NVARCHAR(160)")]
        public string nameBn { get; set; }
    }
}
