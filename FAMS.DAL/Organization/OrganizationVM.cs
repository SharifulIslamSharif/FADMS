using System;
using System.Collections.Generic;

namespace FADMS.Areas.FAMSDB.Models
{
    public class OrganizationVM
    {
        public int? Organogram { get; set; }
        public int? Id { get; set; }
        public string name { get; set; }
        public string nameBn { get; set; }
        public string armsType { get; set; }
        public string orgCode { get; set; }
        public string licenseNumber { get; set; }
        public string branch { get; set; }
        public string generalManager { get; set; }
        public int? demandArmsQty { get; set; }
        public int? carQuintity { get; set; }
        public List<string> licenseList { get; set; }
        public List<string> armsTypelist { get; set; }
    }
}
