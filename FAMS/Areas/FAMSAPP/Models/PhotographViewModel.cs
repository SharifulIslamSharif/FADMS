using FADMS.Data.Entity;
using FADMS.Data.Entity.LicenseInformation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace FAMSAPPLICATION.Areas.License.Models
{
    public class PhotographViewModel
    {
        [Display(Name = "Employee Photo")]
        public string empPhoto { get; set; }

        public int photoPersonId { get; set; }

        public int photographID { get; set; }


        public IFormFile imgUrl { get; set; }

        public Photograph photograph { get; set; }

        public PersonalInfo personalInfo { get; set; }

        public ApplicationUser applicationUser { get; set; }
    }
}
