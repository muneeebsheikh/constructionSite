using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net.Mail;
using constructionSite.Controller;

namespace constructionSite.Views
{
    public partial class AddNewWorker : Form
    {
        private Project p;
        private AccessProject ap = new AccessProject();
        private Project.Worker projectWorker;
        
        //public AddNewWorker()
        //{
        //    ap = new AccessProject();
        //    InitializeComponent();
        //}

        public AddNewWorker(Project proj)
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

        private void txtPersonName_OnValueChanged(object sender, EventArgs e)
        {
            //txtPersonName.Text = string.Concat(txtPersonName.Text.Where(char.IsLetter));
        }

        private void txtContactNumber_OnValueChanged(object sender, EventArgs e)
        {
            txtContactNumber.Text = string.Concat(txtContactNumber.Text.Where(char.IsDigit));
        }
  

        private void txtTypeOfWork_OnValueChanged(object sender, EventArgs e)
        {
            //txtTypeOfWork.Text = string.Concat(txtTypeOfWork.Text.Where(char.IsLetter));
        }
        
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            String personName = txtPersonName.Text.ToString();
            String contactNo = txtContactNumber.Text.ToString();
            String CNIC = txtCNIC.Text.ToString();
            String Email= txtEmail.Text.ToString();
            String typeOfWork = txtTypeOfWork.Text.ToString();
            
            if(txtEmail.Text != "")
            {
                try
                {
                    MailAddress m = new MailAddress(txtEmail.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Invalid Email Address");
                    txtEmail.Focus();
                    return;
                }
            }
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
            if(txtCNIC.Text != "")
            {
                if (!Regex.Match(txtCNIC.Text, "^[0-9]{5}-[0-9]{7}-[0-9]{1}$").Success)
                {
                    MessageBox.Show("Invalid CNIC");
                    txtCNIC.Focus();
                    return;
                }
            }

            try
            {
                if ( personName == "" )
                {
                    MessageBox.Show("Name  Required");
                }
                else
                {
                    projectWorker = new Project.Worker();
                    projectWorker.personName = personName;
                    projectWorker.contactNo = contactNo;
                    projectWorker.CNIC = CNIC;
                    projectWorker.email = Email;
                    projectWorker.typeOfWork = typeOfWork;

                    this.p.workers.Add(projectWorker);
                    ap.addNewWorker(this.p);

                    addNewProject d = new addNewProject(this.p);
                    d.Show();
                    this.Hide();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }        }

        private void AddNewWorker_Load(object sender, EventArgs e)
        {

            lblName.Text = this.p.name;
        }
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
