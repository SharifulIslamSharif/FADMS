using System.ComponentModel.DataAnnotations.Schema;

namespace FAMSAPPLICATION.Areas.License.Models
{
    [NotMapped]
    public class LicenseAppVMM
    {

        public int? Id { get; set; }
        public string reason { get; set; }
        public int? licenseTypeId { get; set; }
        public int? armTypeId { get; set; }
        public string LicenseTypeName { get; set; }
        public string ArmTypeName { get; set; }
        public string nameBangla { get; set; }
        public string nationalID { get; set; }
        public string sourceType { get; set; }
        public int? status { get; set; }
        public string blockSector { get; set; }
        public string postCode { get; set; }

        public string postOffice { get; set; }
        public string houseVillage { get; set; }
        public string thanaName { get; set; }
        public string districtName { get; set; }
        public string divisionName { get; set; }
        public string fatherNameBangla { get; set; }
        public string motherNameBangla { get; set; }
        public string  picfileName { get; set; }
        public string ApplicationNo { get; set; }





    }


}
