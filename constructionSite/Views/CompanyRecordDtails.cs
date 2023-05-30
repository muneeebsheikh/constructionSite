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
    public partial class CompanyRecordDtails : Form
    {
        private Project p;
        AccessProject ap = new AccessProject();
        Project.Company projectCompany;
        public CompanyRecordDtails(Project proj)
        {
            this.p = proj;
            InitializeComponent();
        }
        public CompanyRecordDtails(Project proj,Project.Company projCompany)
        {
            this.p = proj;
            this.projectCompany = projCompany;
            InitializeComponent();
        }
        private void reloadForm()
        {
            CompanyRecordDtails reload = new CompanyRecordDtails(p);
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

        private void CompanyRecordDtails_Load(object sender, EventArgs e)
        {
            lblName.Text = this.p.name;
            try
            {
                if (projectCompany!= null)
                {
                    txtPersonName.Text = projectCompany.personName;
                    txtContactNumber.Text = projectCompany.contactNo;
                    txtCompanyName.Text = projectCompany.companyName;
                    txtShopAddress.Text = projectCompany.shopAddress;
                    txtType.Text = projectCompany.type;
                }

                DataTable dt = ap.getAllCompanies(this.p);
                ////////////// Binding Selected Columns of DGRID1//////////////////////

                dgvCompanyRecord.AutoGenerateColumns = false;
                dgvCompanyRecord.ColumnCount = 5;
                dgvCompanyRecord.Columns[0].HeaderText = "companyName";
                dgvCompanyRecord.Columns[0].Name = "companyName";
                dgvCompanyRecord.Columns[0].DataPropertyName = "companyName";


                dgvCompanyRecord.Columns[1].HeaderText = "shopAddress";
                dgvCompanyRecord.Columns[1].Name = "shopAddress";
                dgvCompanyRecord.Columns[1].DataPropertyName = "shopAddress";

                dgvCompanyRecord.Columns[2].HeaderText = "contactNo";
                dgvCompanyRecord.Columns[2].Name = "contactNo";
                dgvCompanyRecord.Columns[2].DataPropertyName = "contactNo";

                dgvCompanyRecord.Columns[3].HeaderText = "type";
                dgvCompanyRecord.Columns[3].DataPropertyName = "type";
                dgvCompanyRecord.Columns[3].Name = "type";

               dgvCompanyRecord.Columns[4].HeaderText = "personName";
               dgvCompanyRecord.Columns[4].DataPropertyName = "personName";
                dgvCompanyRecord.Columns[4].Name = "personName";
                dgvCompanyRecord.DataSource = dt;

                dgvCompanyRecord.AutoResizeColumns();
                dgvCompanyRecord.AutoResizeRows();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvCompanyRecord_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String PersonName = "";
            String contactNo = "";
            String companyName = "";
            String type = "";
            String shopAddress = "";

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvCompanyRecord.Rows[e.RowIndex];
                PersonName = row.Cells["personName"].Value.ToString();
                contactNo = row.Cells["contactNo"].Value.ToString();
                companyName = row.Cells["companyName"].Value.ToString();
                type = row.Cells["type"].Value.ToString();
                shopAddress = row.Cells["shopAddress"].Value.ToString();

                txtPersonName.Text = PersonName;
                txtContactNumber.Text = contactNo;
                txtCompanyName.Text = companyName;
                txtType.Text = type;
                txtShopAddress.Text = shopAddress;

                projectCompany = new Project.Company();
                projectCompany.personName = PersonName;
                projectCompany.contactNo = contactNo;
                projectCompany.companyName = companyName;
                projectCompany.type = type;
                projectCompany.shopAddress = shopAddress;

            }
            else
            {
                projectCompany = null;
            }
        }

        private void btnDeleteWorker_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you Sure you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                fun("delete", projectCompany);
                reloadForm();
            }
        }

        private void btnUpdateWorker_Click(object sender, EventArgs e)
        {
            fun("update", projectCompany);
            reloadForm();
        }
        public void fun(string param, Project.Company old_pc)
        {
            try
            {

                String personName = txtPersonName.Text.ToString();
                String contactNo = txtContactNumber.Text.ToString();
                String companName = txtCompanyName.Text.ToString();
                String type= txtType.Text.ToString();
                String shopAddress = txtShopAddress.Text.ToString();


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

                


                if (companName == "" )
                {
                    MessageBox.Show("company Name Required");
                }
                else
                {
                    projectCompany = new Project.Company();
                    projectCompany.personName = personName;
                    projectCompany.contactNo = contactNo;
                    projectCompany.companyName = companName;
                    projectCompany.type = type;
                    projectCompany.shopAddress= shopAddress;

                    if (param.Equals("update"))
                    {

                        ap.updateCompany(old_company: old_pc, old_p: p, p:p, new_Company: projectCompany);
                        //ap.updateWorker(this.p, projectWorker);
                    }
                    else if (param.Equals("delete"))
                    {
                        ap.deleteCompany(p: p, pc: projectCompany);
                        //ap.updateWorker(this.p, projectWorker;
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddBill_Click(object sender, EventArgs e)
        {
            if(projectCompany != null)
            {
                SelectedCompany s = new SelectedCompany(this.p,this.projectCompany);
                s.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("please Select A Company");
            }
        }
    }
}
