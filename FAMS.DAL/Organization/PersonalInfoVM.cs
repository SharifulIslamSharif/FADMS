using System;
using System.Collections.Generic;
using System.Text;

namespace FADMS.DAL.Organization
{
  public  class PersonalInfoVM
    {
        public int? Id { get; set; }
        public string personName { get; set; }
        public string personNameEng { get; set; }
        public List<string> licenseList { get; set; }
        public string personCode { get; set; }
        public string email { get; set; }
        public DateTime? dateofBirth { get; set; }
        public string designation { get; set; }
        public string mobile { get; set; }
        public string NID { get; set; }
        public string comment { get; set; }
    }
}
