using FADMS.Data.Entity.Master;

namespace FADMS.Data.Entity.Dealer
{
    public class DealerAddress : Base
    {
        public int? addressCategoryId { get; set; }
        public DealerAddressCategory addressCategory { get; set; }
        

        public int? dealerId { get; set; }
        public Dealer dealer { get; set; }
        
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
