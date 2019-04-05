using InvoicePayment.DAL.ORM.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicePayment.DAL.ORM.Entity
{
   public class Bill :BaseEntity
    {
        public string  BillNo { get; set; }
        public decimal BillAmount { get; set; }
        public decimal? BillAmountInclude   { get; set; }
        public BillType BillType { get; set; }

        public int AppUserID { get; set; }
        public virtual AppUser AppUser { get; set; }

    }
}
