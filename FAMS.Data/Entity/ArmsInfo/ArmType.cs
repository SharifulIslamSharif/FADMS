using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FADMS.Data.Entity.ArmsInfo
{
    public class ArmType:Base
    {
        [Column(TypeName = "NVARCHAR(150)")]
        public string ArmTypeName { get; set; }
        [Column(TypeName = "NVARCHAR(150)")]
        public string ArmTypeNameBn { get; set; }
    }
}
