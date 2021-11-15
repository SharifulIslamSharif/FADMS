using System;
using System.Collections.Generic;
using System.Text;

namespace FADMS.Data.Models
{
   public class vw_getAllDivisionViewModel
    {
        public int? Id { get; set; }

        public int? countryId { get; set; }
        
        public string divisionCode { get; set; }
     
        public string divisionName { get; set; }

        public string divisionNameBn { get; set; }
      
        public string shortName { get; set; }
     
        public string isActive { get; set; }
       
        public string latitude { get; set; }
     
        public string longitude { get; set; }
    }
}
