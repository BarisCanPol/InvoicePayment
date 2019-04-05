using InvoicePayment.DAL.ORM.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicePayment.DAL.ORM.Interface
{
    public interface IBaseEntity
    {
        int ID { get; set; }
        DateTime UpdateDate { get; set; }
        DateTime AddDate { get; set; }
        DateTime DeleteDate { get; set; }
        Status Status { get; set; }
    }
}
