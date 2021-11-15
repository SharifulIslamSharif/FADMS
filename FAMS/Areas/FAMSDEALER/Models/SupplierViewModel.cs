using FADMS.Data.Entity.Dealer;
using FADMS.Data.Entity.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FADMS.Areas.FAMSDEALER.Models
{
    public class SupplierViewModel
    {

        public int supplierAddressId { get; set; }
        public int supplierId { get; set; }
        public int contactId { get; set; }
        public int supId { get; set; }
        public string supplierName { get; set; }
        public string supplierNameBn { get; set; }
        public string LicenseNumber { get; set; }
        public string registeredAddress { get; set; }
        public string eTinNumber { get; set; }
        public string binNumber { get; set; }
        public string VATNumber { get; set; }
        public string email { get; set; }
        public string alternativeEmail { get; set; }
        public string mobile { get; set; }
        public string phone { get; set; }
        public int? supplierTypeId { get; set; }
        public int? DealerId { get; set; }
        public int? isAuthorized { get; set; }




        public string Department { get; set; }
        public string Designation { get; set; }
        public string personName { get; set; }
        public string phoneNumber { get; set; }
        public string mobileNumber { get; set; }
        public SupplierAddress supplierAddress { get; set; }

      
     
        public IEnumerable<Contact>contacts  { get; set; }
        public IEnumerable<SupplierAddress> supplierAddresses { get; set; }

        public IEnumerable<Division> divisions { get; set; }
        public IEnumerable<District> districts { get; set; }
        public IEnumerable<Thana> thanas { get; set; }
        public IEnumerable<Supplier> suppliers { get; set; }
        public IEnumerable<Dealer> dealers { get; set; }
        public IEnumerable<SupplierType> supplierTypes { get; set; }
        public IEnumerable<SupplierAddressCategory> addressCategories { get; set; }
        public  Supplier supplier { get; set; }
        public SupplierType supplierType { get; set; }


        //public string[] Department { get; set; }
        //public string[] Designation { get; set; }
        //public string[] personName { get; set; }
        //public string[] phoneNumber { get; set; }
        //public string[] mobileNumber { get; set; }

        public string[] contactList { get; set; }








        public int? addressCategoryId { get; set; }
        public int? organizationId { get; set; }
        public int? countryId { get; set; }
        public int? divisionId { get; set; }
        public int? districtId { get; set; }
        public int? thanaId { get; set; }
        public string union { get; set; }
        public string postOffice { get; set; }
        public string postCode { get; set; }
        public string blockSector { get; set; }
        public string houseVillage { get; set; }
        public string type { get; set; }


        public string[] addressList { get; set; }
    }
}
