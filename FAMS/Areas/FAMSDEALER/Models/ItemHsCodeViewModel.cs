using FADMS.Data.Entity.Dealer;
using System;
using System.Collections.Generic;

namespace FADMS.Areas.FAMSDEALER.Models
{
    public class ItemHsCodeViewModel
    {
        public int itemHsCodeId { get; set; }

        public string hsCode { get; set; }
        public string hsDescription { get; set; }
        public DateTime? validFrom { get; set; }
        public int? taxYearId { get; set; }

        public decimal? CD { get; set; }
        public decimal? SD { get; set; }
        public decimal? VAT { get; set; }
        public decimal? AIT { get; set; }
        public decimal? AT { get; set; }
        public decimal? RD { get; set; }
        public decimal? EXD { get; set; }
        public decimal? TTI { get; set; }
        public int? vatTableId { get; set; }
        public int? vatCategoriesId { get; set; }
        public int? vatScheduleId { get; set; }

        public IEnumerable<TaxYear> taxYears { get; set; }
       public IEnumerable<ItemHsCode> itemHsCodes { get; set; }
        //public IEnumerable<ItemHSCodeVM> GetItemHsCodes { get; set; }
        public IEnumerable<VatCategory> vatCategories { get; set; }
        public IEnumerable<VatTable> vatTables { get; set; }
        public IEnumerable<VATSchedule> vATSchedules { get; set; }
    }
}
