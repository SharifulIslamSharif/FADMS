using System;
using System.Collections.Generic;
using System.Text;

namespace FADMS.Data.Entity.Dealer
{
    public class DealerItems:Base
    {
        public int? status { get; set; }
        public string remarks { get; set; }

        public int? ItemId { get; set; }
        public Item Item { get; set; }

        public int? DealerId { get; set; }
        public Dealer Dealer { get; set; }
    }
}
