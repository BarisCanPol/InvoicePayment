using InvoicePayment.DAL.ORM.Context;
using InvoicePayment.DAL.ORM.Entity;
using InvoicePayment.DAL.ORM.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoicePayment.View.AdminArea.AppUserView
{
    public partial class AppUserPage : Form
    {
        public AppUserPage()
        {
            InitializeComponent();
        }

        ProjectContext db = new ProjectContext();
        public void TextEraser()
        {
            foreach (Control item in groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
                if (item is ComboBox)
                {
                    item.Text = "";
                }
                if (item is MaskedTextBox)
                {
                    item.Text = "";
                }
            }
            foreach (Control item in groupBox2.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
                if (item is ComboBox)
                {
                    item.Text = "";
                }
                if (item is MaskedTextBox)
                {
                    item.Text = "";
                }
            }
            foreach (Control item in groupBox3.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
                
            }
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
            appUser.Role = (Role)Enum.Parse(typeof(Role), cmdAddRole.Text);
            db.AppUsers.Add(appUser);
            db.SaveChanges();
            AddTakeList();           
            TextEraser();

        }
        int id;
        public void UpdateUserr()
        {
            id = int.Parse(dataGridView1.CurrentRow.Cells["ID"].Value.ToString());
            AppUser appUser = db.AppUsers.Where(x => x.ID == id).FirstOrDefault();
            appUser.FirstName = txtUpdateFirst.Text;
            appUser.LastName = txtUpdateLast.Text;
            appUser.Email = txtIpdateEmail.Text;
            appUser.Phone = mskdUpdateTelephone.Text;
            appUser.Password = txtUpdatePassword.Text;
            appUser.UserName = txtUpdateUsername.Text;
            appUser.Role = (Role)Enum.Parse(typeof(Role), cmdUpdateRole.Text);
            db.SaveChanges();
            AddTakeList();
           
            TextEraser();

        }
        public void DeleteUserr()
        {
            int id1 = Convert.ToInt32(txtDeleteUser.Text);
            AppUser appuser = db.AppUsers.Where(x => x.ID == id1).FirstOrDefault();
            appuser.Status = DAL.ORM.Enum.Status.Delete;
            AddTakeList();
            db.SaveChanges();
            

        }
        public void AddTakeList()
        {
            dataGridView1.DataSource = db.AppUsers.Where(x => x.Status == DAL.ORM.Enum.Status.Active || x.Status==DAL.ORM.Enum.Status.Update).ToList();
        }

        public void EnumList()
        {
            cmdAddRole.Items.AddRange(Enum.GetNames(typeof(Role)));
           // cmdAddRole.SelectedIndex = 0;
           

            cmdUpdateRole.Items.AddRange(Enum.GetNames(typeof(Role)));
            // cmdUpdateRole.SelectedIndex = 0;
           
        }

        private void AppUserPage_Load(object sender, EventArgs e)
        {

            EnumList();
            AddTakeList();
            TextEraser();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUpdateFirst.Text = dataGridView1.CurrentRow.Cells["FirstName"].Value.ToString();
            txtUpdateLast.Text = dataGridView1.CurrentRow.Cells["LastName"].Value.ToString();
            txtIpdateEmail.Text = dataGridView1.CurrentRow.Cells["Email"].Value.ToString();           
            txtUpdatePassword.Text = dataGridView1.CurrentRow.Cells["Password"].Value.ToString();
            txtDeleteUser.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            mskdUpdateTelephone.Text = dataGridView1.CurrentRow.Cells["Phone"].Value.ToString();
            txtUpdateUsername.Text = dataGridView1.CurrentRow.Cells["UserName"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control item in groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    if (string.IsNullOrWhiteSpace(item.Text))
                    {                    
                        MessageBox.Show("Lütfen Eksik Bilgileri giriniz !!");
                        break;
                    }                   
                    else
                    {
                        AddUserr();
                        break;
                    }
                }
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            foreach (Control item in groupBox2.Controls) //add 
            {
                if (item is TextBox)
                {
                    if (string.IsNullOrWhiteSpace(item.Text))
                    {
                        MessageBox.Show("Güncelleme için lütfen eksik alanları doldurunuz  !!");
                        break;
                    }
                    else
                    {
                        UpdateUserr();                                    
                        break;
                    }
                }

            }
            TextEraser();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteUserr();
        }
    }
}
