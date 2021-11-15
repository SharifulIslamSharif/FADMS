using FADMS.Areas.FAMSAPP.Models.Lang;
using FADMS.Data.Entity.LicenseInformation;

namespace FADMS.Areas.FAMSAPP.Models

{

    public class MenuViewModel
    {

        public MenuLN fLang { get; set; }
        public PersonalInfo personalInfo { get; set; }
        public Photograph photograph { get; set; }

    }
}
