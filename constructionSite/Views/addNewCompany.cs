using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using constructionSite.Controller;

namespace constructionSite.Views
{
    public partial class addNewCompany : Form
    {
        private Project p;
        AccessProject ap = new AccessProject();
        Project.Company projectCompany;
        public addNewCompany(Project proj)
        {
            this.p = proj;
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            dashboard d = new dashboard();
            d.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            addNewProject a = new addNewProject(this.p);
            a.Show();
            this.Hide();
        }

        //private void btnAddNewBill_Click(object sender, EventArgs e)
        //{
        //    addNewBill a = new addNewBill();
        //    a.Show();
        //    this.Hide();
        //}

        private void txtCompanyName_OnValueChanged(object sender, EventArgs e)
        {
            //txtCompanyName.Text = string.Concat(txtCompanyName.Text.Where(char.IsLetter));
        }

        private void txtShopAddress_OnValueChanged(object sender, EventArgs e)
        {
            //txtShopAddress.Text = string.Concat(txtShopAddress.Text.Where(char.IsLetterOrDigit));
        }

        private void txtContactNumber_OnValueChanged(object sender, EventArgs e)
        {
            txtContactNumber.Text = string.Concat(txtContactNumber.Text.Where(char.IsDigit));
        }

        private void txtPersonName_OnValueChanged(object sender, EventArgs e)
        {
            //txtPersonName.Text = string.Concat(txtPersonName.Text.Where(char.IsLetter));
        }

        private void txtType_OnValueChanged(object sender, EventArgs e)
        {
            //txtType.Text = string.Concat(txtType.Text.Where(char.IsLetter));
        }

        private void txtContactNumber_Leave(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            String companyName = txtCompanyName.Text.ToString();
            String shopAddress = txtShopAddress.Text.ToString();
            String contactNo = txtContactNumber.Text.ToString();
            String personName = txtPersonName.Text.ToString();
            String type = txtType.Text.ToString();

            if(txtContactNumber.Text != "")
            {
                string text = txtContactNumber.Text;
                if (text.Length != 11)
                {
                    MessageBox.Show("Invald Contact Number");
                    txtContactNumber.Focus();
                    return;
                }
            }

            try
            {
                if (companyName == "" )
                {
                    MessageBox.Show("Name Required");
                }
                else
                {
                    projectCompany = new Project.Company();
                    projectCompany.companyName = companyName;
                    projectCompany.personName = personName;
                    projectCompany.contactNo = contactNo;
                    projectCompany.shopAddress = shopAddress;
                    projectCompany.type = type;


                    this.p.companies.Add(projectCompany);
                    ap.addNewCompany(this.p);
                    //this.p.workers.Add(projectWorker);
                    //ap.addNewWorker(this.p);
                    
                    addNewProject a = new addNewProject(this.p);
                    a.Show();
                    this.Hide();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
        }

        private void addNewCompany_Load(object sender, EventArgs e)
        {
            lblName.Text = this.p.name;
        }
    }
}
