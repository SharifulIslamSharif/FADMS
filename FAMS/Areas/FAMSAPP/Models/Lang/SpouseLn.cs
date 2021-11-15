using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FADMS.Areas.FAMSAPP.Models.Lang
{
    public class SpouseLn
    {
        [Key]
        public string employeeId { get; set; }
        public string title { get; set; }
        public string spouseName { get; set; }
        public string spouseNameBN { get; set; }
        public string dateOfBirth { get; set; }
        public string occupation { get; set; }
        public string gender { get; set; }
        public string designation { get; set; }
        public string organization { get; set; }
        public string bin { get; set; }
        public string nid { get; set; }
        public string bloodGroup { get; set; }
        public string contact { get; set; }
        public string higherEducation { get; set; }
        public string spouseList { get; set; }
    }
}
