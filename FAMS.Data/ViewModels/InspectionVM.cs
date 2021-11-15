using System;
using System.Collections.Generic;
using System.Text;

namespace FADMS.Data.ViewModels
{
    public class InspectionVM
    {
        public int isOrg { get; set; }
        public int? id { get; set; }
        public int? armsId { get; set; }
        public string Name { get; set; }
        public string licenseNo { get; set; }
    }
}
