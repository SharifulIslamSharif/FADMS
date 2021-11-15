using System;
using System.Collections.Generic;
using System.Text;

namespace FADMS.Data.Entity.VM
{
    public class SurrenderLIDetailsVM
    {
        public int? armsTypeId { get; set; }
        public int? dealerID { get; set; }
        public string armsTypeName { get; set; }
        public string armsModel { get; set; }
        public string armsIdentification { get; set; }
        public string dealer { get; set; }
    }
}
