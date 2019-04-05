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

namespace InvoicePayment.View.MemberArea
{
    public partial class PaymentPage : Form
    {
        public PaymentPage()
        {
            InitializeComponent();
        }
        ProjectContext db = new ProjectContext();

        private void PaymentPage_Load(object sender, EventArgs e)
        {
            EnumList();
            Listt();
            
        }

        public void IncludeTaxx()
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells["AppUserID"].Value.ToString());
            decimal Amountt = decimal.Parse(dataGridView1.CurrentRow.Cells["BillAmount"].Value.ToString());
            if ((db.AppUsers.Any(x => x.Status == DAL.ORM.Enum.Status.Active || x.Status == DAL.ORM.Enum.Status.Update) && (db.AppUsers.Any(x => x.ID == id && x.Role == DAL.ORM.Enum.Role.Member) && (db.Bills.Any(x => x.BillType == DAL.ORM.Enum.BillType.Electricty)))))
            {
                    Amountt = ((Amountt * 18 / 100) + Amountt);
                    txtAddTotal.Text = Amountt.ToString();


              }
              else if ((db.AppUsers.Any(x => x.Status == DAL.ORM.Enum.Status.Active || x.Status == DAL.ORM.Enum.Status.Update) && (db.AppUsers.Any(x => x.ID == id && x.Role == DAL.ORM.Enum.Role.Member) && (db.Bills.Any(x => x.BillType == DAL.ORM.Enum.BillType.Water)))))
                {
                    Amountt = ((Amountt * 17 / 100) + Amountt);
                    txtAddTotal.Text = Amountt.ToString();

                }
                else if ((db.AppUsers.Any(x => x.Status == DAL.ORM.Enum.Status.Active || x.Status == DAL.ORM.Enum.Status.Update) && (db.AppUsers.Any(x => x.ID == id && x.Role == DAL.ORM.Enum.Role.Member) && (db.Bills.Any(x => x.BillType == DAL.ORM.Enum.BillType.Phone)))))
                {
                    Amountt = ((Amountt * 20 / 100) + Amountt);
                    txtAddTotal.Text = Amountt.ToString();
                }
              else
               {
                MessageBox.Show("No match found !!");
                }





        }
        public void AddBill()
        {
            Bill bill = new Bill();
            bill.BillNo = txtAddBill.Text;
            bill.BillType = (BillType)Enum.Parse(typeof(BillType), cmdType.Text);
            bill.BillAmount = Convert.ToDecimal(txtAddAmount.Text);
           // bill.BillAmountInclude = Convert.ToDecimal( txtAddTotal.Text);
            bill.AppUserID = (int)cmdUsers.SelectedValue;
            db.Bills.Add(bill);
            db.SaveChanges();
            Listt();

        }
        public void EnumList()
        {
            cmdType.Items.AddRange ( Enum.GetNames(typeof(BillType)));
            cmdUsers.DataSource = db.AppUsers.Where(x => x.Role == DAL.ORM.Enum.Role.Member && x.Status == DAL.ORM.Enum.Status.Active).ToList();
            cmdUsers.DisplayMember = "UserName";
            cmdUsers.ValueMember = "ID";
            cmdUsers.SelectedValue = -1;
        }
        public void Listt()
        {
            dataGridView1.DataSource = db.Bills.Where(x => x.Status == DAL.ORM.Enum.Status.Active).ToList();
        }
        public void Eraserr()
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
            }
            foreach (Control item in groupBox3.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }

            }
        public void Deletee()
        {
            int id = Convert.ToInt32(txtPaymentID.Text);
            Bill bill = db.Bills.Where(x => x.ID == id).FirstOrDefault();
            bill.Status = DAL.ORM.Enum.Status.Delete;
            db.SaveChanges();
            Listt();
            
        

        }

        public void UpdateBill()
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells["ID"].Value.ToString());
            Bill bill = db.Bills.Where(x => x.ID == id).FirstOrDefault();
            bill.BillAmountInclude = Convert.ToDecimal(txtAddTotal.Text);
            db.SaveChanges();
            Listt();


        }

        private void txtAddTotal_Click(object sender, EventArgs e)
        {
            //IncludeTaxx();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            AddBill();
            Eraserr();

            MessageBox.Show("Please select bill and add tax !!");

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {           
            txtPaymentBill.Text = dataGridView1.CurrentRow.Cells["BillNo"].Value.ToString();
            txtPaymentID.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            IncludeTaxx();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateBill();
            Eraserr();

            MessageBox.Show("Can pay your bill NOW !!");

            txtPaymentBill.Text = dataGridView1.CurrentRow.Cells["BillNo"].Value.ToString();
            txtPaymentID.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            txtPaymentTotal.Text = dataGridView1.CurrentRow.Cells["BillAmountInclude"].Value.ToString();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DialogResult payy = new DialogResult();

            payy = MessageBox.Show("you must pay : "+dataGridView1.CurrentRow.Cells["BillAmountInclude"].Value.ToString(), "Waning", MessageBoxButtons.YesNo);

            if (payy == DialogResult.Yes)
            {
                Deletee();
                Eraserr();
                MessageBox.Show("Done !!!");
            }
            else
            {
                MessageBox.Show("You are out !!");
            }
                      
        }
    }
}
