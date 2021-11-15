using FADMS.Data.Entity.ArmsInfo;
using FADMS.Data.Entity.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FADMS.Data.Entity.LicenseInformation
{
    public class Sp_LicenseInfoViewModel
    {
        public int? Id { get; set; }
    
        public int? licenseTypeId { get; set; }
  
        public int? armTypeId { get; set; }
     
        public int? licenseSourseTypeId { get; set; }
      
        public string licenseNumber { get; set; }       

        public string place { get; set; }  
       

        public int? personalInfoId { get; set; }

        public int? organizationInfoId { get; set; }
    }
}
