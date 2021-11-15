using FADMS.Areas.FAMSAPP.Models.Lang;
using FADMS.Data.Entity;
using FADMS.Data.Entity.LicenseInformation;
using FADMS.Data.Entity.Master;
using System.Collections.Generic;

namespace FADMS.Areas.FAMSAPP.Models
{

    public class AddressViewModel
    {

        public int? orgId { get; set; }
        public int? employeeId { get; set; }
        public int? personalInfoId { get; set; }

        public ApplicationUser applicationUser { get; set; }
        public int? presentAddressID { get; set; }
        public int? permanentAddressID { get; set; }
        public int? organizationAddressID { get; set; }
        public int? addressId { get; set; }
        public int? licenseId { get; set; }

        public string organizationDivision { get; set; }
        public string organizationDistrict { get; set; }
        public string organizationUpazila { get; set; }
        public string organizationUnion { get; set; }
        public string organizationPostOffice { get; set; }
        public string organizationPostCode { get; set; }
        public string organizationBlockSector { get; set; }
        public string organizationHouseVillage { get; set; }
        public string organizationArea { get; set; }


        public string presentDivision { get; set; }
        public int? divisionid { get; set; }
        public int? districtid { get; set; }
        public int? thanaId { get; set; }
        public string presentDistrict { get; set; }
        public string presentUpazila { get; set; }
        public string presentUnion { get; set; }
        public string presentPostOffice { get; set; }
        public string presentPostCode { get; set; }
        public string presentBlockSector { get; set; }
        public string presentHouseVillage { get; set; }
        public string presentArea { get; set; }


        public string permanentDivision { get; set; }
        public string permanentDistrict { get; set; }
        public string permanentUpazila { get; set; }
        public string permanentUnion { get; set; }
        public string permanentPostOffice { get; set; }
        public string permanentPostCode { get; set; }
        public string permanentBlockSector { get; set; }
        public string permanentHouseVillage { get; set; }
        public string permanentArea { get; set; }
        public string type { get; set; }
        public string addresstype { get; set; }


        public AddressLN fLang { get; set; }
      
        public Address addres { get; set; }
        public Address present { get; set; }
        public Address permanent { get; set; }
        public Address organization { get; set; }
        public string sameAddress { get; set; }

        public IEnumerable<Division> divisions { get; set; }
        public IEnumerable<District> districts { get; set; }
        public IEnumerable<Thana> thanas { get; set; }
        public IEnumerable<Address> address { get; set; }

    }
}
