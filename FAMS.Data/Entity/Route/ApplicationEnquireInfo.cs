using System;
using System.Collections.Generic;
using System.Text;

namespace FADMS.Data.Entity.Route
{
    public class ApplicationEnquireInfo:Base
    {
        public int? socialPeaceBreakingStatus { get; set; }//0=no||1=yes
        public int? armsManagementKnoledgeStatus { get; set; }//0=no||1=yes
        public int? lifeThreatArmsNeedStatus { get; set; }//0=no||1=yes
        public int? allCertificateVarifyStatus { get; set; }//0=no||1=yes
        public string voilenceInfo { get; set; }
        public int? isAppropriate { get; set; }//0=no||1=yes

        public int? status { get; set; }//1=application apply||2=Dc approved||3=sb inquire Submit||4=DC Confirmed||5=Home ministry confirm
        public string remarks { get; set; }
        public DateTime? date { get; set; }

        public int? applicationRouteId { get; set; }
        public ApplicationRoute applicationRoute { get; set; }

        public String applicationUserId { get; set; }
        public ApplicationUser applicationUser { get; set; }
    }
}
