using FADMS.Data.Entity.LicenseInformation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FADMS.Data.Entity.Attachment
{
    public class PersonalAttachment:Base
    {
        public string fileUrl { get; set; }
        public string fileName { get; set; }//use as attachment type
        public string remarks { get; set; }
        public int? status { get; set; } //1=active;

        public int?  personalInfoId { get; set; }
        public PersonalInfo  personalInfo { get; set; }
    }
}
