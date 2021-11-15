using System;
using System.Collections.Generic;
using System.Text;

namespace FADMS.Data.Entity.VM
{
    public class PersonMenuOptionDetailsVM
    {
        public int? gunRepairId { get; set; }
        public int? armsTypeId { get; set; }
        public int? dealerID { get; set; }
        public string armsTypeName { get; set; }
        public string armsModel { get; set; }
        public string armsIdentification { get; set; }
        public string dealer { get; set; }
        public DateTime? date { get; set; }
        public string licenseNumber { get; set; }
        public string referenceNO { get; set; }
        public string reason { get; set; }
        public string Attachment { get; set; }
    }
}
