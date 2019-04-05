using InvoicePayment.DAL.ORM.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicePayment.DAL.ORM.Entity
{
    public class AppUser :BaseEntity
    {
 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }       
        public string  Password { get; set; }
        public string UserName { get; set; }
        public Role Role { get; set; }

       public virtual List<Bill> Bills { get; set; }


    }
}
