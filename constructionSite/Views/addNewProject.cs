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
using System.Globalization;

namespace constructionSite.Views
{
    public partial class addNewProject : Form
    {
        private Project p;
        AccessProject ap;
        public addNewProject()
        {
            InitializeComponent();
        }

        public addNewProject(Project proj)
        {
            this.p = proj;
            ap = new AccessProject();
            InitializeComponent();
            btnSave.Visible = false;
        }
        

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            dashboard d = new dashboard();
            d.Show();
            this.Hide();

        }

        private void btnAddnewWorker_Click(object sender, EventArgs e)
        {
            if (p != null)
            {
                AddNewWorker a = new AddNewWorker(this.p);
                a.Show();
                this.Hide();
            }
        }

        private void btnAddNewCompany_Click(object sender, EventArgs e)
        {
            if (p != null)
            {
                addNewCompany a = new addNewCompany(this.p);
                a.Show();
                this.Hide();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //PrintScreen p = new PrintScreen();
            //p.Show();
            //this.Hide();
            RecivePayment r = new RecivePayment(this.p);
            r.Show();
            this.Hide();
        }

        private void btnDasti_Click(object sender, EventArgs e)
        {

            patyCash p = new patyCash();
            p.Show();
            this.Hide();
        }

        private void btnRecivePayment_Click(object sender, EventArgs e)
        {
            RecivePayment r = new RecivePayment(this.p);
            r.Show();
            this.Hide();
        }

        private void btnCompanyDetails_Click(object sender, EventArgs e)
        {
            CompanyRecordDtails c = new CompanyRecordDtails(this.p);
            c.Show();
            this.Hide();
        }

        private void btnWorkerDetails_Click(object sender, EventArgs e)
        {
            workerRecordDetails w = new workerRecordDetails(this.p);
            
            w.Show();
            this.Hide();
        }

        private void txtContactNumber_OnValueChanged(object sender, EventArgs e)
        {
            txtContactNumber.Text = string.Concat(txtContactNumber.Text.Where(char.IsDigit));
        }

        private void txtName_OnValueChanged(object sender, EventArgs e)
        {
            //txtName.Text = string.Concat(txtName.Text.Where(char.IsLetter));
        }
      

        private void txtPlotID_OnValueChanged(object sender, EventArgs e)
        {
            //txtPlotID.Text = string.Concat(txtPlotID.Text.Where(char.IsLetterOrDigit));
        }

        private void txtContactNumber_Leave(object sender, EventArgs e)
        {
            
        }

        private void addNewProject_Load(object sender, EventArgs e)
        {

            try
            {
               
                if (p != null)
                {
                    lblName.Text = this.p.name;
                    txtName.Text = this.p.name;
                    txtContactNumber.Text = this.p.contactNo;
                    txtPlotID.Text = this.p.plotNo;
                    txtStatus.Text = this.p.status;
                    datePicker.Visible = true;
                    datePicker.Value = DateTime.Parse(this.p.date);
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        Project project;
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                btnEdit.Visible = false;
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
                p = new Project();
                p.contactNo = txtContactNumber.Text;
                p.date = datePicker.Value.ToString("yyyy-MM-dd");
                p.name = txtName.Text;
                p.plotNo = txtPlotID.Text;
                p.status = txtStatus.Text;

                ap.updateProject(new_project: p, old_project: project);
                p.contactNo = ap.getContactNo(contactNo: p.contactNo);
                addNewProject d = new addNewProject(p);
                d.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to update. Project already exists! "+ "/n" +ex.Message);

                addNewProject d = new addNewProject(project);
                d.Show();
                this.Hide();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnUpdate.Visible = true;
            btnEdit.Visible = false;
            btnSave.Visible = false;
            btnDelete.Visible = false;

            project = new Project();
            project.contactNo = txtContactNumber.Text.ToString();
            project.date= datePicker.Value.ToString("yyyy-MM-dd");
            //project.date = txtDate.Text.ToString();
            project.name = txtName.Text.ToString();
            project.plotNo = txtPlotID.Text.ToString();
            project.status = txtStatus.Text.ToString();

            txtContactNumber.Enabled = true;
            //txtDate.Enabled = true;
            datePicker.Visible = true;
            
            datePicker.Value = DateTime.Parse(this.p.date);
            
            txtName.Enabled = true;
            txtPlotID.Enabled = true;
            txtStatus.Enabled = true;

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            dashboard d = new dashboard();
            d.Show();
            this.Hide();
            

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you Sure you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                ap.deleteProject(p);
                dashboard d = new dashboard();
                d.Show();
                this.Hide();
            }

        }
        //private void bunifuFlatButton1_Click(object sender, EventArgs e)
        //{
        //    int height = dgvPayment.Height;
        //    dgvPayment.Height = dgvPayment.RowCount * dgvPayment.RowTemplate.Height * 2;
        //    bmp = new Bitmap(dgvPayment.Width, dgvPayment.Height);
        //    dgvPayment.DrawToBitmap(bmp, new Rectangle(0, 0, dgvPayment.Width, dgvPayment.Height));
        //    dgvPayment.Height = height;
        //    printPreviewDialog1.ShowDialog();
        //}

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
}

        private void chkRecivedPayments_OnChange(object sender, EventArgs e)
        {
           
        }

        private void datePickerFrom_onValueChanged(object sender, EventArgs e)
        {
           }

        private void dgvPayment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            projectPayments p = new projectPayments(this.p);
            p.Show();
            this.Hide();
            
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Summary summary = new Summary(this.p);
            summary.Show();
            this.Hide();
        }
    }
}
