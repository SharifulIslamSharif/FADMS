using FADMS.Data.Entity.Attachment;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FADMS.DAL.Services.Interfaces
{
    public interface IGunRepairService
    {

        Task<IEnumerable<GunRepairAttachment>> GetGunRepairAttachmentByPId(int id);
        Task<IEnumerable<GunRepairAttachment>> GetGunRepairAttachmentByOrgId(int id);
    }
}
