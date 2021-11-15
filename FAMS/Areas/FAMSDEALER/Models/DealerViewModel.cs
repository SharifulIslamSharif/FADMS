using FADMS.Data.Entity.Dealer;
using FADMS.Data.Entity.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FADMS.Areas.FAMSDEALER.Models
{
    public class DealerViewModel
    {
        public int dealerIdAddressId { get; set; }
        public int dealerId { get; set; }
        public int dealerContactId { get; set; }
        public int contactId { get; set; }
        public string dealerName { get; set; }
        public string dealerNameBn { get; set; }
        public string LicenseNumber { get; set; }
        public string registeredAddress { get; set; }
        public string eTinNumber { get; set; }
        public string binNumber { get; set; }
        public string VATNumber { get; set; }
        public string email { get; set; }
        public string alternativeEmail { get; set; }
        public string mobile { get; set; }
        public string phone { get; set; }
        public int? dealerTypeId { get; set; }
        public int? isAuthorized { get; set; }




        public string Department { get; set; }
        public string Designation { get; set; }
        public string personName { get; set; }
        public string phoneNumber { get; set; }
        public string mobileNumber { get; set; }



        public IEnumerable<Contact> contacts { get; set; }
        public IEnumerable<DealerAddress> dealerAddresses { get; set; }

        public IEnumerable<Division> divisions { get; set; }
        public IEnumerable<District> districts { get; set; }
        public IEnumerable<Thana> thanas { get; set; }
        public IEnumerable<Dealer> dealers { get; set; }
        public IEnumerable<DealerType> dealerTypes { get; set; }
        public IEnumerable<DealerAddressCategory> dealerAddressCategories { get; set; }
        public Dealer dealer  { get; set; }


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
