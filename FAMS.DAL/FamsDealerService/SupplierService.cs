using FADMS.DAL.FamsDealerService.Interface;
using FADMS.Data;
using FADMS.Data.Entity.Dealer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FADMS.DAL.FamsDealerService
{
    public class SupplierService : ISupplierService
    {
        private readonly FADMSDbContext _context;

        public SupplierService(FADMSDbContext context)
        {
            _context = context;
        }
        public async Task<Supplier> SaveSupplier(Supplier supplier)
        {
            if (supplier.Id>0)
            {
                 _context.suppliers.Update(supplier);
            }
            else
            {
                _context.suppliers.Add(supplier);
            }

            await _context.SaveChangesAsync();

            return supplier;
        }

        public async Task<Supplier> LetSupplierById(int id)
        {
            var lastShowPieceId = _context.suppliers.Max(x => x.Id);
            return await _context.suppliers.Where(x => x.Id == lastShowPieceId).FirstOrDefaultAsync();


        }

        public async Task<Contact> SaveContact(Contact contact)
        {
            if (contact.Id > 0)
            {
                _context.contacts.Update(contact);
            }
            else
            {
                _context.contacts.Add(contact);
            }

            await _context.SaveChangesAsync();

            return contact;
        }

        public async Task<IEnumerable<Supplier>> GetSuppliers()
        {
            return await _context.suppliers.Include(x => x.supplierType).AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<Supplier>> GetSuppliersbyDealer(int? id)
        {
            return await _context.suppliers.Include(x => x.supplierType).Where(x => x.Id == id).AsNoTracking().ToListAsync();
        }

        public async Task<SupplierAddress> SaveSupplierAddress(SupplierAddress supplierAddress)
        {
            if (supplierAddress.Id > 0)
            {
                _context.supplierAddress.Update(supplierAddress);
            }
            else
            {
                _context.supplierAddress.Add(supplierAddress);
            }

            await _context.SaveChangesAsync();

            return supplierAddress;
        }

        public async Task<IEnumerable<Supplier>> GetSupplierForPurchase()
        {
            return await _context.suppliers.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<SupplierAddress>> GetSupplierAddresses()
        {
            return await _context.supplierAddress
                .Include(x => x.division)
                .Include(x => x.district)
                .Include(x => x.thana)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
