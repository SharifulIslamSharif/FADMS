using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FADMS.Areas.FAMSAPP.Models.Lang;
//using FAMSAPPLICATION.Data.Entity.Employee;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FAMSAPPLICATION.Areas.License.Models
{
    public class FinancialOrganizationViewModel
    {
        public int financialOranizationId { get; set; }

        public int licenseTypeId { get; set; }

        public string name { get; set; }

        public string type { get; set; }

        public string orgCategory { get; set; }

        public string EstablishDate { get; set; }

        public string noOfEmployee { get; set; }

        public int? noOfVehicle { get; set; }

        public string ownerName { get; set; }

        public string tid { get; set; }

        public string branchName { get; set; }

        public string branchManager { get; set; }

        public int? armTypeId { get; set; }

        public int? isBBPermit { get; set; }

        public IFormFile bbAttachment { get; set; }

        public int? isHomeRentalAgreement { get; set; }

        public IFormFile homeRentalAgreementAttachment { get; set; }

        public string securityProtected { get; set; }

        public string reasonOfFireArms { get; set; }

        public int? numberOfFireArms { get; set; }

        public string beforeArms { get; set; }
        public int status { get; set; }


        //public FinancialOrganization financialOrganization { get; set; }
        //public FinancialOrganizationLn fLang { get; set; }

        //public OrgAddress present { get; set; }
        //public OrggardAddress presentgard { get; set; }
        //public OrggardAddress permanentgard { get; set; }
        //public OrgAddress permanent { get; set; }
        //public OrgAddress Organization { get; set; }
        public OrgAddressLN orgAddLang { get; set; }

        //public OrgTaxInfo orgTaxInfo { get; set; }
        //public IEnumerable<OrgTaxInfo> taxInfos { get; set; }
        public OrgTaxInfoLN orgTaxLang { get; set; }


        //wahid
        public GardLN fLang1 { get; set; }
        public OrgAddressLN orgAddLang1 { get; set; }
        public TrainingLn trainingLN { get; set; }
        //public IEnumerable<Gard> gards { get; set; }
        //public List<Gard> gardsList { get; set; }
        //public IEnumerable<OrggardAddress> OrggardAddresslist { get; set; }
        //public IEnumerable<GardTrainingInformation> gardTrainingInformation { get; set; }

        //public IEnumerable<ArmType> armTypes { get; set; }
    }
}
