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
    public partial class MainAddNewProject : Form
    {
        AccessProject ap;
        Project project;
        public MainAddNewProject()
        {
            ap = new AccessProject();
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string theDate = datePicker.Value.ToString("yyyy-MM-dd");
            string Name = txtName.Text.Trim();
            string contactNumber = txtContactNumber.Text.Trim();
            string plotNumber = txtPlotID.Text.Trim();
            int statusIndex = cmbStatus.selectedIndex;

            //MessageBox.Show(theDate);


             if(txtContactNumber.Text != "")
            {
                string no = txtContactNumber.Text;
                if (no.Length != 11)
                {
                    MessageBox.Show("Incorrect Contact Number");
                    txtContactNumber.Focus();
                    return;
                }
            }

            if (statusIndex.ToString() != "-1")
            {
                string status = cmbStatus.Items[statusIndex].ToString();
                try
                {
                    if ( Name.Trim() == "" || plotNumber.Trim() == "" || status.Trim() == "")
                    {
                        MessageBox.Show("please fill Name and Plot No");
                    }
                    else
                    {
                        project = new Project();

                        project.plotNo = plotNumber;
                        project.name = Name;
                        project.contactNo = contactNumber;
                        project.status = status;
                        project.date = theDate;
                        ap.addNewProject(project);

                        dashboard d = new dashboard();
                        d.Show();
                        this.Hide();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select Status");
            }

        }

        private void txtName_OnValueChanged(object sender, EventArgs e)
        {
           // txtName.Text = string.Concat(txtName.Text.Where(char.IsLetter));
        }

        private void txtContactNumber_OnValueChanged(object sender, EventArgs e)
        {
           // txtContactNumber.Text = string.Concat(txtContactNumber.Text.Where(char.IsDigit));
        }

        private void txtPlotID_OnValueChanged(object sender, EventArgs e)
        {
            //txtPlotID.Text = string.Concat(txtPlotID.Text.Where(char.IsDigit));
        }

        private void txtContactNumber_Leave(object sender, EventArgs e)
        {
            
        }

        private void MainAddNewProject_Load(object sender, EventArgs e)
        {
            datePicker.Value = DateTime.Now;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            dashboard d = new dashboard();
            d.Show();
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
    }
}
