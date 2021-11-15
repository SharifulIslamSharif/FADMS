using FADMS.DAL.Services.Interfaces;
using FADMS.Data;
using FADMS.Data.Entity.Attachment;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FADMS.DAL.Services
{
    public class GunRepairService : IGunRepairService
    {
        private readonly FADMSDbContext _context;
        public GunRepairService(FADMSDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<GunRepairAttachment>> GetGunRepairAttachmentByPId(int id)
        {
            return await _context.gunRepairAttachments.Where(x => x.personalInfoId == id).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<GunRepairAttachment>> GetGunRepairAttachmentByOrgId(int id)
        {
            return await _context.gunRepairAttachments.Where(x => x.organizationInfoId == id).AsNoTracking().ToListAsync();
        }
    }
}
