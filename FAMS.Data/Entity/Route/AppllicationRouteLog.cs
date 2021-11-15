using System;
using System.Collections.Generic;
using System.Text;

namespace FADMS.Data.Entity.Route
{
    public class AppllicationRouteLog:Base
    {
        public int? status { get; set; }//0 = Recjct //1=application apply||2=Dc approved||3=sb inquire Submit||4=DC Confirmed||5=Home ministry confirm || 6 Return
        public string remarks { get; set; }
        public string comments { get; set; }
        public DateTime? date { get; set; }

        public int?  applicationRouteId { get; set; }
        public ApplicationRoute  applicationRoute { get; set; }

        public String applicationUserId { get; set; }
        public ApplicationUser  applicationUser { get; set; }
    }
}
