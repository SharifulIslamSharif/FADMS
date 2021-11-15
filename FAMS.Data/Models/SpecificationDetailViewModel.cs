using System;
using System.Collections.Generic;
using System.Text;

namespace FADMS.Data.Models
{
   public class SpecificationDetailViewModel
    {
        public int? Id { get; set; }
        public string specificationName { get; set; }
        public string specificationCategoryName { get; set; }
        public int? specificationCategoryId { get; set; }
        public string value { get; set; }
    }
}
