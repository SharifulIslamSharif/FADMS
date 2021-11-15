using System.ComponentModel.DataAnnotations;
namespace FADMS.Areas.FAMSAPP.Models.Lang
{
    public class CrimeInfoLn
    {
        [Key]
        public string licenseID { get; set; }
        public string reason { get; set; }
        public string caseNo { get; set; }
        public string caseDate { get; set; }

        public string result { get; set; }
      


    }
}
