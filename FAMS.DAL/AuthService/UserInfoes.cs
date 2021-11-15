using FADMS.DAL.AuthService.Interfaces;
using FADMS.Data;
using FADMS.Data.Entity;
using FADMS.Data.Entity.Auth;
using FADMS.Data.Entity.Dealer;
using FADMS.Data.Entity.Master;
using FADMS.Data.Models.Auth;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FADMS.DAL.AuthService
{
    public class UserInfoes: IUserInfoes
    {
        private readonly FADMSDbContext _context;
        public UserInfoes(FADMSDbContext context)
        {
            _context = context;
        }

        public async Task<ApplicationUser> GetUserInfoByUser(string userName)
        {
            return await _context.Users.Where(x => x.UserName == userName).Include(x=>x.userType).FirstOrDefaultAsync();
        }      

        public async Task<AspNetUsersViewModel> GetUserInfoByUserNameNew(string userName)
        {
            var result = await (from U in _context.Users.Where(x => x.UserName == userName)
                                join E in _context.PersonalInfos on U.Id equals E.ApplicationUserId
                                into EE
                                from m in EE.DefaultIfEmpty()
                                join PH in _context.Photographs on m.Id equals PH.personalInfo.Id
                                into PP
                                from P in EE.DefaultIfEmpty()
                                select new AspNetUsersViewModel
                                {
                                    aspnetId = U.Id,
                                    UserName = U.UserName,
                                    UserTypeId = U.userTypeId,
                                    Email = U.Email,
                                    EmpCode = U.Id,
                                    isActive = U.isActive,                                   
                                   
                                    mobileNo = m.mobileNumberOffice,
                                    email = m.emailAddress,
                                   
                                    photoId = PP.FirstOrDefault().Id,
                                    imageUrl = PP.FirstOrDefault().url,
                                    EmpName = m.nameEnglish,
                                    EmployeeId = (m.Id == null) ? 0 : m.Id,
                                    DesignationName = m.designation
                                }).FirstOrDefaultAsync();
            return result;
        }

        //GetUserInfoByThana
        public async Task<ApplicationUser> GetUserInfoByThana(string userName)
        {
            //return await _context.Users.Where(x => x.UserName == userName).Include(x=>x.userType).FirstOrDefaultAsync();
            var list = await _context.Users.Include(x => x.division).Include(e => e.district)
               .Include(e => e.thana)
               .Where(x => x.UserName == userName).Include(x => x.userType).FirstOrDefaultAsync();
            return list;
        }

        public async Task<IEnumerable<AspNetUsersViewModel>> GetUserInfoList()
        {
            var result =await (from a in _context.Users
                               join d in _context.Districts on a.districtId equals d.Id into dis from ldist in dis.DefaultIfEmpty()
                               join dv in _context.Divisions on a.divisionId equals dv.Id into div from ldiv in div.DefaultIfEmpty()
                               join ur in _context.UserRoles on a.Id equals ur.UserId
                               join r in _context.Roles on ur.RoleId equals r.Id
                               //join dl in _context.dealers on a.Id equals dl.ApplicationUserId
                               select new AspNetUsersViewModel
                               {
                                     aspnetId=a.Id,
                                     UserName = a.UserName,
                                     Email = a.Email,
                                     mobileNo = a.PhoneNumber,
                                     PersonName = a.PersonName,
                                     rank = a.ranks,
                                     BpNumber = a.bpNumbers,
                                     roleName = r.Name,
                                     DivisionName= ldiv.divisionName,
                                     DistrictName= ldist.districtName,
                                     createdAt =a.createdAt,
                                     isActive=a.isActive,
                                     UserTypeId =a.userTypeId
                               }).ToListAsync();
            
            return result;
        }
    public async Task<IEnumerable<AspNetUsersViewModel>> GetUserInfoListForDistrict(int? disId)
        {
            //var li = await _context.Users.Where(x => x.districtId == disId).Select(x => x.UserName).AsNoTracking().ToListAsync();
            var result = await (from c in _context.Users.Where(x => x.districtId == disId)
                                join t in _context.Thanas on c.thanaId equals t.Id into tis
                                from ttis in tis.DefaultIfEmpty()
                                join d in _context.Districts on c.districtId equals d.Id into dis
                                from ldist in dis.DefaultIfEmpty()
                                join dv in _context.Divisions on c.divisionId equals dv.Id into div
                                from ldiv in div.DefaultIfEmpty()
                                join ur in _context.UserRoles on c.Id equals ur.UserId
                                join r in _context.Roles on ur.RoleId equals r.Id
                                //where (x => x.districtId == disId)
                                //join dl in _context.dealers on a.Id equals dl.ApplicationUserId

                                select new AspNetUsersViewModel
                                {
                                    aspnetId = c.Id,

                                    UserName = c.UserName,
                                    Email = c.Email,
                                    BpNumber = c.bpNumbers,
                                    mobileNo = c.PhoneNumber,
                                    PersonName = c.PersonName,
                                    rank = c.ranks,
                                    roleName = r.Name,
                                    DivisionName = ldiv.divisionName,
                                    DistrictName = ldist.districtName,
                                    ThanaName = ttis.thanaNameBn,
                                    createdAt = c.createdAt,
                                    isActive = c.isActive,
                                    UserTypeId = c.userTypeId,
                                    //licenseList = await context.Users.Where(e=>e.DistrictId == disId && (e.isDelete == null || e.isDelete != 1)).Select(e => e.).AsNoTracking().ToListAsync()
                                }).OrderByDescending(x=>x.Id).ToListAsync();
            
            return result;
        }

        public async Task<IEnumerable<FAMSModule>> GetAllMenu()
        {
            return await _context.FAMSModules.ToListAsync();
        }

        public async Task<IEnumerable<FAMSModule>> GetAllFAMSModule()
        {
            return await _context.FAMSModules.AsNoTracking().ToListAsync();
        }

        public async Task<bool> DeleteRoleById(string Id)
        {
            _context.Roles.Remove(_context.Roles.Where(x => x.Id == Id).First());
            return 1 == await _context.SaveChangesAsync();
        }

        public async Task<string> GetUserRoleByUserName(string userName)
        {
            var name = "";
            var user = await _context.Users.Where(x => x.UserName == userName).FirstOrDefaultAsync();
            var userRole= await _context.UserRoles.Where(x => x.UserId == user.Id).FirstOrDefaultAsync();
            if (userRole != null) {
                var role = await _context.Roles.Where(x => x.Id == userRole.RoleId).FirstOrDefaultAsync();
                name = role?.Name;
            }
            else { name = "no roles assingn"; }
            return name;
        }

        public async Task<string> GetUserRoleIdByUserName(string userName)
        {
            var Id = "";
            var user = await _context.Users.Where(x => x.UserName == userName).FirstOrDefaultAsync();
            var userRole= await _context.UserRoles.Where(x => x.UserId == user.Id).FirstOrDefaultAsync();
            if (userRole != null) {
                var role = await _context.Roles.Where(x => x.Id == userRole.RoleId).FirstOrDefaultAsync();
                Id = role?.Id;
            }
            else { Id = "no roles assingn"; }
            return Id;
        }

        public async Task<string> CheckUserName(string uname)
        {
            var user= await _context.Users.Where(x => x.UserName == uname).Select(x => x.UserName).FirstOrDefaultAsync();
            if(user == null)
            {
                user = "Not Used";
            }
            return user;
        }
        public async Task<string> CheckEmail(string email)
        {
            var user = await _context.Users.Where(x => x.Email == email).Select(x => x.Email).FirstOrDefaultAsync();
            if (user == null)
            {
                user = "Not Used";
            }
            return user;
        }
        public async Task<string> DeleteUser(string id)
        {
            try
            {
                var user = await _context.Users.Where(s => s.Id == id).FirstOrDefaultAsync();
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return user.UserName;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //public async Task<string> DeleteUser(string id)
        //{
        //    //_context.PersonalInfos.RemoveRange(_context.PersonalInfos.Where(y => y.ApplicationUserId == id));
        //    //_context.SaveChanges();

        //    var userExist = _context.Users.Find(_context.PersonalInfos.Where(x => x.ApplicationUserId == id).Select(x => x.ApplicationUserId).FirstOrDefault());
        //    if (userExist != null || userExist == null)
        //    {
        //        var user = _context.Users.Find(_context.PersonalInfos.Where(x => x.ApplicationUserId == id).Select(x => x.ApplicationUserId));
        //        _context.Users.Remove(user);
        //        await _context.SaveChangesAsync();
        //    }
        //    try
        //    {


        //        _context.Users.Remove(_context.Users.Find(_context.PersonalInfos.Find(id).ApplicationUserId));
        //        _context.SaveChanges();
        //        //_context.employeeInfos.Remove(_context.employeeInfos.Find(id));
        //        //return userExist ==  await _context.SaveChangesAsync();
        //        return userExist.UserName;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }   
        //}
        public async Task<string> UpdateUserStatusByUserIdAndStatus(string id, int status)
        {
            try
            {
                var user = await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
                user.isActive = status;
                 _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return user.UserName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
          public async Task<string> UpdateUserByUserid(string id, int? status, string person,string email,string bp, string rank,string phone)
        {
            try
            {
                var user = await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
                user.isActive = status;
                user.PersonName = person;
                user.Email = email;
                user.bpNumbers = bp;
                user.ranks = rank;
                user.PhoneNumber = phone;     
                 _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return user.UserName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

          public async Task<ApplicationUser> UpdateUserStatusByUserId(ApplicationUser applicationUser)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync();
                 _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return applicationUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public async Task<int> GetOrganizationIdByUserId(string id)
        {
            return await _context.organizationInfos.Where(x => x.ApplicationUserId == id).Select(x => x.Id).FirstOrDefaultAsync();
        }
        public async Task<int> GetPersonalIdByUserId(string id)
        {
            return await _context.PersonalInfos.Where(x => x.ApplicationUserId == id).Select(x => x.Id).FirstOrDefaultAsync();
        }

        #region User Management
        public async Task<IEnumerable<ModuleAccessPage>> GetUserMenuAccessByUserType(string userTypeid)
        {
            return await _context.ModuleAccessPages.Where(x => x.applicationRoleId == userTypeid).ToListAsync();
        }
        public async Task<bool> DeleteModuleAccesspageByUserTypeId(string userTypeid)
        {
            _context.ModuleAccessPages.RemoveRange(_context.ModuleAccessPages.Where(x => x.applicationRoleId == userTypeid));
            return 1 == await _context.SaveChangesAsync();
        }
        public async Task<int> SaveUserAccessPage(ModuleAccessPage userAccessPage)
        {
            try
            {
                if (userAccessPage.Id != 0)
                {
                    userAccessPage.updatedBy = userAccessPage.createdBy;
                    userAccessPage.updatedAt = DateTime.Now;
                    _context.ModuleAccessPages.Update(userAccessPage);
                }
                else
                {
                    userAccessPage.createdAt = DateTime.Now;
                    _context.ModuleAccessPages.Add(userAccessPage);
                }

                await _context.SaveChangesAsync();
                return userAccessPage.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<Dealer>> GetAllUncreatedDealers()
        {
            //return await _context.dealers.AsNoTracking().ToListAsync();
            return await _context.dealers.Where(x => x.ApplicationUserId == null).AsNoTracking().ToListAsync();
        }
       
        public async Task<int> UpdateDealerUserIdById(int? id,string userid)
        {
            try
            {
                var dealer = await _context.dealers.Where(x => x.Id == id).FirstOrDefaultAsync();
                dealer.ApplicationUserId = userid;
                _context.dealers.Update(dealer);
                await _context.SaveChangesAsync();
                return dealer.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        #endregion

        #region Layout
        public async Task<IEnumerable<string>> GetMenuByUserName(string username)
        {
            var menu = await (from u in _context.Users
                              join r in _context.UserRoles
                              on u.Id equals r.UserId
                              join ma in _context.ModuleAccessPages
                              on r.RoleId equals ma.applicationRoleId
                              join mn in _context.FAMSModules
                              on ma.eRPModuleId equals mn.Id

                              where u.UserName == username
                              select mn.moduleName).ToListAsync();
            return menu;
            //var menu = new List<string>();
            //menu.Add("Dealer");
            //return menu;
        }
        #endregion

      
    }
}
