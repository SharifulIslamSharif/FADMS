using System;
using System.Collections.Generic;
using System.Text;

namespace FADMS.Data.Entity.DbQuery_Model
{
    public class LiDetailsVm
    {
        public int? personId { get; set; }
        public string ImgPath { get; set; }
        public string Name { get; set; }
        public string LicenseType { get; set; }
        public string LicenseNO { get; set; }
        public string Reason { get; set; }
        public string ArmsType { get; set; }
        public string LicenseThana { get; set; }
        public string LicenseDistrict { get; set; }
        public string Gender { get; set; }
        public string PoliticalParty { get; set; }
    }
}
