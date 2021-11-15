using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FADMS.Data.Entity.Dealer.AttachmentComment
{
    public class Comment:Base
    {
        [MaxLength(250)]
        public string actionType { get; set; }
        public int? actionTypeId { get; set; }
        [MaxLength(250)]
        public string title { get; set; }
        public string comment { get; set; }
    }
}
