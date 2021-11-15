using FADMS.Data.Entity.Master;

namespace FADMS.Data.Entity.Dealer
{
    public class SupplierAddress:Base
    {
        public int? addressCategoryId { get; set; }
        public SupplierAddressCategory addressCategory { get; set; }
        

        public int? supplierId { get; set; }
        public Supplier supplier { get; set; }
        
        public int? countryId { get; set; }
        public Country country { get; set; }

        public int? divisionId { get; set; }
        public Division division { get; set; }

        public int? districtId { get; set; }
        public District district { get; set; }

        public int? thanaId { get; set; }
        public Thana thana { get; set; }

        public string union { get; set; }

        public string postOffice { get; set; }

        public string postCode { get; set; }

        public string blockSector { get; set; }

        public string houseVillage { get; set; }    

        public string type { get; set; }  

    }
}
