using FADMS.Data.Entity.Dealer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FADMS.DAL.FamsDealerService.Interface
{
   public interface ISupplierService
    {
        Task<IEnumerable<Supplier>> GetSuppliers();
        Task<IEnumerable<Supplier>> GetSuppliersbyDealer(int? id);
        Task<IEnumerable<SupplierAddress>> GetSupplierAddresses();
        Task<Supplier> SaveSupplier(Supplier supplier);
        Task<Supplier> LetSupplierById(int id);
        Task<Contact> SaveContact(Contact contact);
        Task<SupplierAddress> SaveSupplierAddress(SupplierAddress supplierAddress);
        Task<IEnumerable<Supplier>> GetSupplierForPurchase();


    }
}
