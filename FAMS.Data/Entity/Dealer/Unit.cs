using System.ComponentModel.DataAnnotations;

namespace FADMS.Data.Entity.Dealer
{
    public class Unit : Base
    {
        [MaxLength(250)]
        public string unitName { get; set; }
        [MaxLength(250)]
        public string description { get; set; }
    }
}
