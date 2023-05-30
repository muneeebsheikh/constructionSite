using constructionSite.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace constructionSite.Views
{
    public partial class RecivePayment : Form
    {
        Project Project;
        AccessProject ap;
        Project.Payment payment;
        public RecivePayment(Project p)
        {
            this.Project = p;
            ap = new AccessProject();
            InitializeComponent();
            txtSerialNumber.Text = ap.getSnoRecievePayment(this.Project);
            datePicker.Value = DateTime.Now;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            //formReload();
        }
        public RecivePayment(Project p, Project.Payment payment)
        {
            this.Project = p;
            this.payment = payment;
            ap = new AccessProject();
            InitializeComponent();
            txtSerialNumber.Text = payment.serialNo;
            datePicker.Value = DateTime.ParseExact(payment.date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            txtAmount.Text = payment.amount;
            rtbPaymentDescription.Text = payment.description;

            txtSerialNumber.Enabled = false;
            btnSave.Visible = false;
            //formReload();
        }

        private void formReload()
        {
            RecivePayment rp = new RecivePayment(this.Project);
            rp.Show();
            this.Hide();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            addNewProject a = new addNewProject(this.Project);
            a.Show();
            this.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            dashboard d = new dashboard();
            d.Show();
            this.Hide();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtSerialNumber_OnValueChanged(object sender, EventArgs e)
        {
            //txtSerialNumber.Text = string.Concat(txtSerialNumber.Text.Where(char.IsDigit));
        }

        private void datePicker_onValueChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(datePicker.Value.ToShortDateString());
        }

        private void txtAmount_OnValueChanged(object sender, EventArgs e)
        {
            txtAmount.Text = string.Concat(txtAmount.Text.Where(char.IsDigit));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Project.Payment payment = new Project.Payment();
                payment.amount = txtAmount.Text;
                payment.date = datePicker.Value.ToString("yyyy-MM-dd");
                payment.description = rtbPaymentDescription.Text;
                payment.serialNo = txtSerialNumber.Text;
                this.Project.payments.Add(payment);
                ap.addNewRecievePayment(this.Project);
                formReload();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Project.Payment nPay = new Project.Payment();
            nPay.amount = txtAmount.Text;
            nPay.serialNo = txtSerialNumber.Text;
            nPay.date = datePicker.Value.ToString("yyyy-MM-dd");
            nPay.description = rtbPaymentDescription.Text;
            ap.updateRecievedPayment(p:this.Project ,payment:nPay);
            addNewProject a = new addNewProject(this.Project);
            a.Show();
            this.Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you Sure you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                ap.deleteRecievePayment(this.Project, payment);
                addNewProject a = new addNewProject(this.Project);
                a.Show();
                this.Hide();

            }
        }

        private void RecivePayment_Load(object sender, EventArgs e)
        {

            lblName.Text = this.Project.name;
        }
    }
}
