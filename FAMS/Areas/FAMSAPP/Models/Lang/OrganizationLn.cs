using System.ComponentModel.DataAnnotations;

namespace FADMS.Areas.FAMSAPP.Models.Lang
{
    public class OrganizationLn
    {
        [Key]
        public string organizaId { get; set; }
        public string orgCode { get; set; }
        public string name { get; set; }
        public string instituteTypeId { get; set; }
        public string branch { get; set; }
        public string generalManager { get; set; }
        public string estrabilishedDate { get; set; }
        public string Organogram { get; set; }
        public string taxId { get; set; }

        public string carQuintity { get; set; }

        public string previousFairArms { get; set; }

        public string certificate { get; set; }

        public string demandArmsType { get; set; }
        public string demandArmsQty { get; set; }

        public string presentSecuritySystem { get; set; }
        public string licenseNeed { get; set; }
        public string reason { get; set; }
        public string action { get; set; }
        public string title { get; set; }
        public string title2 { get; set; }
        public string EstablishDate { get; set; }

        public string noOfEmployee { get; set; }

        public string ownerName { get; set; }

        public string blance { get; set; }
    }
}
