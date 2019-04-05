using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using InvoicePayment.View.AdminArea.AppUserView;
using InvoicePayment.DAL.ORM.Context;

namespace InvoicePayment.View.AdminArea.MainPage
{
    public partial class AdminMainPage : Form
    {
        public AdminMainPage()
        {
            InitializeComponent();
        }
        ProjectContext db = new ProjectContext();
        private void appuserPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread th;
            this.Close();
            th = new Thread(OpenAppUserPage);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        public void SortUser()
        {
            var User = from p in db.AppUsers
                       orderby p.ID ascending
                       select new
                       {
                           p.FirstName,
                           p.LastName,
                           p.Email,
                           p.AddDate,
                           p.UpdateDate,
                           p.DeleteDate,
                           p.Password,
                           p.UserName,
                           p.Role
                       };
            dataGridView1.DataSource = User.ToList();
        }

        public void SortBill()
        {
            var bill = from a in db.Bills
                         orderby a.ID ascending
                         select new
                         {
                             a.BillAmount,
                             a.BillAmountInclude,
                             a.BillNo,
                             a.BillType,
                             a.AppUser,
                             a.AppUserID
                         };
            dataGridView1.DataSource = bill.ToList();
        }
        public void OpenAppUserPage()
        {
            Application.Run(new AppUserPage());
        }
        private void AdminMainPage_Load(object sender, EventArgs e)
        {
            dataGridView1.Enabled = false;
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
        }

        private void queryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = true;
            groupBox1.Enabled = true;
        }

        private void queryBillDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = true;
            groupBox2.Enabled = true;

        }

        private void btnSortUser_Click(object sender, EventArgs e)
        {
            SortUser();
        }

    }
}
