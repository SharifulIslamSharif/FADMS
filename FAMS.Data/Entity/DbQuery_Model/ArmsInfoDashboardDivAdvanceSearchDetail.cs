using System;
using System.Collections.Generic;
using System.Text;

namespace FADMS.Data.Entity.DbQuery_Model
{
    public class ArmsInfoDashboardDivAdvanceSearchDetail
    {

        public int? LicenseId { get; set; }
        public int? LicenseTypeId { get; set; }
        public string licensenumber { get; set; }
        public string LicenseTypeName { get; set; }
        public string ArmTypeName { get; set; }
        public string dateOfIssue { get; set; }
        public string dateOfExpair { get; set; }
        public string place { get; set; } //for arms use as gun identification number
        public string reason { get; set; }
        public string source { get; set; }
        public string thanaName { get; set; }
        public string districtName { get; set; }
        public string LiName { get; set; }
        public int? LiIdFor { get; set; }
        public string ImgUrl { get; set; }
        public string mobileNumberPersonal { get; set; }
        public string nationalID { get; set; }
        public string editUrl { get; set; }
        public string print { get; set; }
        public string phone { get; set; }
        public string NID { get; set; }
    }
}
