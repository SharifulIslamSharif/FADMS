using FADMS.Data.Entity.LicenseInformation;
using FADMS.Data.Entity.Master;
using FADMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FADMS.DAL.Services.Interfaces
{
   public interface IAddressService
    {
        Task<IEnumerable<Address>> GetAddressByPersonalInfoId(int id);
        Task<IEnumerable<Address>> GetAddressByOrganizationInfoId(int id);

        Task<IEnumerable<Thana>> GetThanasByDistrictId(int DistrictId);
        Task<IEnumerable<District>> GetDistrictByDivisionId(int id);

        IQueryable<SpGetAllThanaViewModel> SpGetThanasByDistrictId(int? DistrictId);
        IQueryable<SpGetAllDistrictViewModel> SpGetDistrictByDivisionId(int? DivisionId);
        IQueryable<vw_getAllDivisionViewModel> SpGetAllDivision();

        Task<IEnumerable<Division>> GetAllDivision();
        Task<IEnumerable<Country>> GetAllContry();
        Task<Division> GetDivisionById(int id);
    

        Task<IEnumerable<District>> GetAllDistrict();
        Task<District> GetDistrictById(int id);
        Task<IEnumerable<District>> GetDistrictsByDivisonId(int DivisionId);

    
        Task<IEnumerable<Thana>> GetAllThana();
        Task<Thana> GetThanaById(int id);
        Task<bool> DeletePhotoByMasterId(int id);

        Task<int> GetDivisionIdByName(string name);
        Task<int> GetDistrictIdByName(string name);
        Task<int> GetThanadByName(string name);

    }
}
