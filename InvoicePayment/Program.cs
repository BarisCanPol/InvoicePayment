using InvoicePayment.View.AdminArea.AppUserView;
using InvoicePayment.View.AdminArea.MainPage;
using InvoicePayment.View.MemberArea;
using InvoicePayment.View.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoicePayment
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PaymentPage());
        }
    }
}
