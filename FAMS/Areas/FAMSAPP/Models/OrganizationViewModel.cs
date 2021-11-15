using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FADMS.Areas.FAMSAPP.Models.Lang;
//using FAMSAPPLICATION.Data.Entity.Employee;
using System.Linq;
using System.Threading.Tasks;
namespace FAMSAPPLICATION.Areas.License.Models
{
    public class OrganizationViewModel
    {
        public int OranizationId { get; set; }

        public int licenseId { get; set; }

        public string name { get; set; }

        public string type { get; set; }

        public string EstablishDate { get; set; }

        public string noOfEmployee { get; set; }

        public string ownerName { get; set; }

        public string blance { get; set; }
       // public FinancialOrganization financialOrganization { get; set; }
        public OrganizationLn fLang { get; set; }

    }
}
