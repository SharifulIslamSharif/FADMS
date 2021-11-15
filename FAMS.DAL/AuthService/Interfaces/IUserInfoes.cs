using FADMS.Data.Entity;
using FADMS.Data.Entity.Auth;
using FADMS.Data.Entity.Dealer;

using FADMS.Data.Models.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FADMS.DAL.AuthService.Interfaces
{
    public interface IUserInfoes
    {
        Task<ApplicationUser> GetUserInfoByUser(string userName);
        Task<IEnumerable<AspNetUsersViewModel>> GetUserInfoList();
        Task<IEnumerable<FAMSModule>> GetAllFAMSModule();
        Task<bool> DeleteRoleById(string Id);
        Task<string> GetUserRoleByUserName(string userName);
        Task<string> GetUserRoleIdByUserName(string userName);
        Task<IEnumerable<FAMSModule>> GetAllMenu();
        Task<string> CheckUserName(string uname);
        Task<string> CheckEmail(string email);
        Task<string> DeleteUser(string id);
        Task<string> UpdateUserStatusByUserIdAndStatus(string id, int status);
        Task<int> GetOrganizationIdByUserId(string id);
        Task<int> GetPersonalIdByUserId(string id);
        Task<ApplicationUser> GetUserInfoByThana(string userName);
        Task<IEnumerable<AspNetUsersViewModel>> GetUserInfoListForDistrict(int? disId);
        Task<AspNetUsersViewModel> GetUserInfoByUserNameNew(string userName);
        Task<string> UpdateUserByUserid(string id, int? status, string person, string email, string bp, string rank, string phone);

        #region User Management
        Task<IEnumerable<ModuleAccessPage>> GetUserMenuAccessByUserType(string userTypeid);
        Task<bool> DeleteModuleAccesspageByUserTypeId(string userTypeid);
        Task<int> SaveUserAccessPage(ModuleAccessPage userAccessPage);
        Task<IEnumerable<Dealer>> GetAllUncreatedDealers();
        Task<int> UpdateDealerUserIdById(int? id, string userid);
       #endregion

        #region Layout
        Task<IEnumerable<string>> GetMenuByUserName(string username);
        #endregion

      
    }
}
