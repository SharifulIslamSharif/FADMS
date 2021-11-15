using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FADMS.Data.Entity.Dealer
{
    public class SpecificationCategory : Base
    {
        [MaxLength(250)]
        public string specificationCategoryName { get; set; }
    }
}
