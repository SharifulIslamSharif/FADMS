using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FADMS.Areas.FAMSAPP.Models.Lang
{
    [NotMapped]
    public class TrainingLn
    {
        public string title { get; set; }
        public string employeeId { get; set; }
        public string trainingType { get; set; }
        public string trainingDate { get; set; }
        public string trainingTitle { get; set; }
        public string institute { get; set; }
        public string address { get; set; }
        public string comments { get; set; }
        public string action { get; set; }
        public string trList { get; set; }
        public string cheakbox { get; set; }
        public string dropdawn { get; set; }
    }
}
