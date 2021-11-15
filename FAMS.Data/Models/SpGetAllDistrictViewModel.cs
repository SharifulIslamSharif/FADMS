using System;
using System.Collections.Generic;
using System.Text;

namespace FADMS.Data.Models
{
   public class SpGetAllDistrictViewModel
    {
        public int Id { get; set; }

        public int divisionId { get; set; }
       
        public string districtCode { get; set; }
   
        public string districtName { get; set; }
    
        public string districtNameBn { get; set; }
    
        public string shortName { get; set; }
     
        public string isActive { get; set; }
   
        public string latitude { get; set; }

        public string longitude { get; set; }
    }
}
