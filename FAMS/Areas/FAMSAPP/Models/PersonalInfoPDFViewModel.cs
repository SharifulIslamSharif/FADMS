using FADMS.Data.Entity.LicenseInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FADMS.Areas.FAMSAPP.Models
{
    public class PersonalInfoPDFViewModel
    {
        public IEnumerable<PersonalInfo> allPerson { get; set; }
        public IEnumerable<Address> address { get; set; }
      
        public IEnumerable<Photograph> photographs { get; set; }
        public IEnumerable<LicenseInfo> licenseInfos { get; set; }
      

        public PersonalInfo personalInfo { get; set; }
        public Photograph photograph { get; set; }
    }
}
