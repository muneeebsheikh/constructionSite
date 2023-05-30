 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using constructionSite.Controller;

namespace constructionSite.Views
{
    public partial class workerRecordDetails : Form
    {
        private Project p;
        AccessProject ap;
        //Project project;
        Project.Worker projectWorker;
        public workerRecordDetails(Project proj)
        {
            this.p = proj;
            ap = new AccessProject();
            InitializeComponent();
        }
        public workerRecordDetails(Project proj , Project.Worker p)
        {
            this.p = proj;
            this.projectWorker = p;
            ap = new AccessProject();
            InitializeComponent();
        }
        private void reloadForm()
        {
            workerRecordDetails reload = new workerRecordDetails(p);
            reload.Show();
            this.Hide();
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

        private void workerRecordDetails_Load(object sender, EventArgs e)
        {
            lblName.Text = this.p.name;
            try
            {
                if (projectWorker != null)
                {
                    txtPersonName.Text = projectWorker.personName;
                    txtContactNumber.Text = projectWorker.contactNo;
                    txtCNIC.Text = projectWorker.CNIC;
                    txtEmail.Text = projectWorker.email;
                    txtTypeOfWork.Text = projectWorker.typeOfWork;
                }

                DataTable dt = ap.getAllWorker(this.p);
                ////////////// Binding Selected Columns of DGRID1//////////////////////

                dgvWorkerDetails.AutoGenerateColumns = false;
                dgvWorkerDetails.ColumnCount = 7;
                dgvWorkerDetails.Columns[0].HeaderText = "PersonName";
                dgvWorkerDetails.Columns[0].Name = "PersonName";
                dgvWorkerDetails.Columns[0].DataPropertyName = "PersonName";


                dgvWorkerDetails.Columns[1].HeaderText = "projectName";
                dgvWorkerDetails.Columns[1].Name = "projectName";
                dgvWorkerDetails.Columns[1].DataPropertyName = "projectName";

                dgvWorkerDetails.Columns[2].HeaderText = "plotNo";
                dgvWorkerDetails.Columns[2].Name = "plotNo";
                dgvWorkerDetails.Columns[2].DataPropertyName = "plotNo";

                dgvWorkerDetails.Columns[3].HeaderText = "CNIC";
                dgvWorkerDetails.Columns[3].DataPropertyName = "CNIC";
                dgvWorkerDetails.Columns[3].Name = "CNIC";

                dgvWorkerDetails.Columns[4].HeaderText = "contactNo";
                dgvWorkerDetails.Columns[4].DataPropertyName = "contactNo";
                dgvWorkerDetails.Columns[4].Name = "contactNo";

                dgvWorkerDetails.Columns[5].HeaderText = "email";
                dgvWorkerDetails.Columns[5].DataPropertyName = "email";
                dgvWorkerDetails.Columns[5].Name = "email";

                dgvWorkerDetails.Columns[6].HeaderText = "typeOfWork";
                dgvWorkerDetails.Columns[6].DataPropertyName = "typeOfWork";
                dgvWorkerDetails.Columns[6].Name = "typeOfWork";



                dgvWorkerDetails.Columns[1].Visible = false;
                dgvWorkerDetails.Columns[2].Visible = false;
                dgvWorkerDetails.AutoResizeColumns();
                dgvWorkerDetails.AutoResizeRows();
                dgvWorkerDetails.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvWorkerDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String PersonName = "";
            String contactNo = "";
            String CNIC = "";
            String Email = "";
            String typeOfWork = "";

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvWorkerDetails.Rows[e.RowIndex];
                PersonName = row.Cells["personName"].Value.ToString();
                contactNo = row.Cells["contactNo"].Value.ToString();
                Email = row.Cells["email"].Value.ToString();
                CNIC = row.Cells["CNIC"].Value.ToString();
                typeOfWork = row.Cells["typeOfWork"].Value.ToString();

                txtPersonName.Text = PersonName;
                txtCNIC.Text = CNIC;
                txtContactNumber.Text = contactNo;
                txtEmail.Text = Email;
                txtTypeOfWork.Text = typeOfWork;

                projectWorker = new Project.Worker();
                projectWorker.personName = PersonName;
                projectWorker.contactNo = contactNo;
                projectWorker.CNIC = CNIC;
                projectWorker.email = Email;
                projectWorker.typeOfWork = typeOfWork;

            }
        }


        private void btnUpdateWorker_Click(object sender, EventArgs e)
        {
            ob("update", projectWorker);
            reloadForm();
        }

        private void btnDeleteWorker_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you Sure you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                ob("delete", projectWorker);
                reloadForm();
            }
            
        }

        public void ob(string param, Project.Worker old_pw)
        {
            try
            {

                String personName = txtPersonName.Text.ToString();
                String contactNo = txtContactNumber.Text.ToString();
                String CNIC = txtCNIC.Text.ToString();
                String Email = txtEmail.Text.ToString();
                String typeOfWork = txtTypeOfWork.Text.ToString();

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

                if (txtCNIC.Text != "")
                {

                    if (!Regex.Match(txtCNIC.Text, "^[0-9]{5}-[0-9]{7}-[0-9]{1}$").Success)
                    {
                        MessageBox.Show("Invalid CNIC");
                        txtCNIC.Focus();
                        return;
                    }
                }

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

                if ( personName == "" )
                {
                    MessageBox.Show("Person Name Required");
                }
                else
                {
                    projectWorker = new Project.Worker();
                    projectWorker.personName = personName;
                    projectWorker.contactNo = contactNo;
                    projectWorker.CNIC = CNIC;
                    projectWorker.email = Email;
                    projectWorker.typeOfWork = typeOfWork;

                    if (param.Equals("update"))
                    {
                        ap.updateWorker(old_p: p, p: p, old_worker: old_pw, new_worker:projectWorker);
                        //ap.updateWorker(this.p, projectWorker);
                    }
                    else if (param.Equals("delete"))
                    {
                        ap.deleteWorker(p: p, pw: projectWorker);
                        //ap.updateWorker(this.p, projectWorker;
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtContactNumber_Leave(object sender, EventArgs e)
        {
            
        }

        private void txtCNIC_Leave(object sender, EventArgs e)
        {
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            
        }

        private void txtTypeOfWork_Leave(object sender, EventArgs e)
        {
            //txtTypeOfWork.Text = string.Concat(txtTypeOfWork.Text.Where(char.IsLetter));
        }

        private void txtPersonName_Leave(object sender, EventArgs e)
        {
           // txtPersonName.Text = string.Concat(txtPersonName.Text.Where(char.IsLetter));
        }

        private void btnAddBill_Click(object sender, EventArgs e)
        {
            if (projectWorker != null)
            {
                SelectedWorker s = new SelectedWorker(this.p  , this.projectWorker);
                s.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Select A Worker please");
            }
        }
    }
    }
