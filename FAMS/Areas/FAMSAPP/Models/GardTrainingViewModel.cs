using FADMS.Areas.FAMSAPP.Models.Lang;
//using FAMSAPPLICATION.Data.Entity.Employee;
using System.Collections.Generic;

namespace FAMSAPPLICATION.Areas.License.Models
{
    public class GardTrainingViewModel
    {
        public int? trainingInfoId { get; set; }
        public int licenseTypeId { get; set; }
        public int gardId { get; set; }

        public int sourceId { get; set; }

        public int trainingCategoryId { get; set; }

        public int trainingInstituteId { get; set; }

        public string trainingDate { get; set; }

        public string heading { get; set; }

        public string remarks { get; set; }

        public string address { get; set; }

        public TrainingLn fLang { get; set; }

       // public IEnumerable<GardTrainingInformation> gardTrainingInformation { get; set; }
    }
}
