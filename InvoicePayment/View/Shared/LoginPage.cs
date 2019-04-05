using InvoicePayment.DAL.ORM.Context;
using InvoicePayment.DAL.ORM.Entity;
using InvoicePayment.DAL.ORM.Enum;
using InvoicePayment.View.AdminArea.AppUserView;
using InvoicePayment.View.MemberArea;
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
using InvoicePayment.View.AdminArea.MainPage;

namespace InvoicePayment.View.Shared
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        ProjectContext db = new ProjectContext();
        
        public void TextEraser ()
        {

            foreach (Control item in groupBox2.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = ""; 
                }
                if (item is MaskedTextBox)
                {
                    item.Text = "";
;                }
            }


        }   

        public void Checking()
        {
            if (db.AppUsers.Any(x => x.Status == DAL.ORM.Enum.Status.Active || x.Status == DAL.ORM.Enum.Status.Update) && db.AppUsers.Any(x=> x.UserName==txtUserName.Text && x.Role == DAL.ORM.Enum.Role.Admin && x.Password == txtPassword.Text))
            
            {
                Thread th;
                this.Close();
                th = new Thread(openNewForm);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
              
                    

            }
            else if (db.AppUsers.Any(x => x.Status == DAL.ORM.Enum.Status.Active || x.Status == DAL.ORM.Enum.Status.Update ) && db.AppUsers.Any(x=> x.UserName== txtUserName.Text && x.Role == DAL.ORM.Enum.Role.Member && x.Password == txtPassword.Text))
            
            {
                Thread th;
                this.Close();
                th = new Thread(PaymentForm);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();

            }
            else
            {
                MessageBox.Show("Password or Username Wrong !");
            }          
        }

        private void openNewForm(object obj)
        {
            Application.Run(new AdminMainPage());
        }
        public void PaymentForm()
        {
            Application.Run(new PaymentPage());
        }
        public void AddUserr()
        {
            AppUser appUser = new AppUser();
            appUser.FirstName = txtAddFirst.Text;
            appUser.LastName = txtAddLast.Text;
            appUser.Email = txtAddEmail.Text;
            appUser.Password = txtAddPassword.Text;
            appUser.Phone = mskdAddTelephone.Text;
            appUser.UserName = txtAddUserName.Text;
            appUser.Role = Role.Member;
            db.AppUsers.Add(appUser);
            db.SaveChanges();
            
        }
        private void LoginPage_Load(object sender, EventArgs e)
        {

            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            DialogResult Register = new DialogResult();
            Register = MessageBox.Show("You have a membership ?","Warning", MessageBoxButtons.YesNo);
            if (Register == DialogResult.Yes)
            {
                groupBox1.Enabled = true;                  
            }
            else
            {
                groupBox2.Enabled = true;
            }

        }

      

       

        private void button2_Click(object sender, EventArgs e)
        {
            AddUserr();
            TextEraser();
            groupBox2.Enabled = false;
            groupBox1.Enabled = true;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Checking();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
