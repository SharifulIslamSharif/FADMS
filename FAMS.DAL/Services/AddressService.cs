using FADMS.DAL.Services.Interfaces;
using FADMS.Data;
using FADMS.Data.Entity.LicenseInformation;
using FADMS.Data.Entity.Master;
using FADMS.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FADMS.DAL.Services
{
    public class AddressService : IAddressService
    {
        private readonly FADMSDbContext _context;
        public AddressService(FADMSDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Address>> GetAddressByPersonalInfoId(int id)
        {
            return await _context.addresses.Include(x=>x.division).Include(x=>x.district).Include(x=>x.thana).Where(x => x.personalInfoId == id).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Address>> GetAddressByOrganizationInfoId(int id)
        {
            return await _context.addresses.Where(x => x.organizationInfoId == id).Include(e=>e.organizationInfo).Include(e=>e.district).Include(e=>e.division).Include(e=>e.thana).Include(e=>e.division).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Thana>> GetThanasByDistrictId(int DistrictId)
        {
            return await _context.Thanas.Where(x => x.districtId == DistrictId).ToListAsync();
        }

        public IQueryable<SpGetAllThanaViewModel> SpGetThanasByDistrictId(int? DistrictId)
        {
            return _context.spGetAllThanaViewModel.FromSql($"sp_vw_GetThanasByDistrictId {DistrictId}");
        }
        public IQueryable<SpGetAllDistrictViewModel> SpGetDistrictByDivisionId(int? DivisionId)
        {
            return _context.spGetAllDistrictViewModel.FromSql($"sp_vw_GetDistrictByDivisionId {DivisionId}");
        }
        public IQueryable<vw_getAllDivisionViewModel> SpGetAllDivision()
        {
            return _context.vw_getAllDivision.FromSql($"sp_vw_getAllDivision");
        }

        public async Task<IEnumerable<District>> GetDistrictByDivisionId(int id)
        {
            return await _context.Districts.Where(x => x.divisionId == id).ToListAsync();
        }


        public async Task<IEnumerable<Division>> GetAllDivision()
        {
            return await _context.Divisions.AsNoTracking().ToListAsync();
        }

        public async Task<Division> GetDivisionById(int id)
        {
            return await _context.Divisions.FindAsync(id);
        }
      
        public async Task<IEnumerable<District>> GetAllDistrict()
        {
            return await _context.Districts.Include(x => x.division).AsNoTracking().ToListAsync();
        }

        public async Task<District> GetDistrictById(int id)
        {
            return await _context.Districts.FindAsync(id);
        }

        public async Task<IEnumerable<District>> GetDistrictsByDivisonId(int DivisionId)
        {
            return await _context.Districts.Where(X => X.divisionId == DivisionId).ToListAsync();
        }
      
        public async Task<IEnumerable<Thana>> GetAllThana()
        {
            return await _context.Thanas.Include(x => x.district.division.country).Include(x => x.district.division).Include(x => x.district).AsNoTracking().ToListAsync();
        }

        public async Task<Thana> GetThanaById(int id)
        {
            return await _context.Thanas.FindAsync(id);
        }

        public async Task<IEnumerable<Country>> GetAllContry()
        {
            return await _context.Countries.AsNoTracking().ToListAsync();
        }
       
        public async Task<bool> DeletePhotoByMasterId(int id)
{
    _context.Photographs.RemoveRange(_context.Photographs.Where(x => x.organizationInfoId == id).ToList());
    _context.organizationInfos.Remove(_context.organizationInfos.Where(e => e.Id == id).FirstOrDefault());

    return 1 == await _context.SaveChangesAsync();
}

        public async Task<int> GetDivisionIdByName(string name)
        {
            return await _context.Divisions.Where(x => x.divisionNameBn == name).Select(x => x.Id).FirstOrDefaultAsync();
        }

        public async Task<int> GetDistrictIdByName(string name)
        {
            return await _context.Districts.Where(x => x.districtNameBn == name).Select(x => x.Id).FirstOrDefaultAsync();
        }

        public async Task<int> GetThanadByName(string name)
        {
            return await _context.Thanas.Where(x => x.thanaNameBn == name).Select(x => x.Id).FirstOrDefaultAsync();
        }
    }
}

