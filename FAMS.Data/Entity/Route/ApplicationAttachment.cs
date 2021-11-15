using System;
using System.Collections.Generic;
using System.Text;

namespace FADMS.Data.Entity.Route
{
    public class ApplicationAttachment:Base
    {
        public string fileName { get; set; }
        public string fileUrl { get; set; }
        public string comment { get; set; }
        public string remarks { get; set; }
        public DateTime? date { get; set; }

        public int? applicationRouteId { get; set; }
        public ApplicationRoute applicationRoute { get; set; }

        public String applicationUserId { get; set; }
        public ApplicationUser applicationUser { get; set; }
    }
}
