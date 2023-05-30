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
using constructionSite.Model;

namespace constructionSite.Views
{
    public partial class dashboard : Form
    {
        AccessProject ap;
        Project project;

        public dashboard()
        {
            ap = new AccessProject();
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

        private void btnAddNewProject_Click(object sender, EventArgs e)
        {
            MainAddNewProject a = new MainAddNewProject();
            a.Show();
            this.Hide();
            //this.Dispose();
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            try
            {

                ////////////// Binding Selected Columns of DGRID1//////////////////////

                dgvDashboard.AutoGenerateColumns = false;
                dgvDashboard.ColumnCount = 6;

                dgvDashboard.Columns[0].HeaderText = "SNO";
                dgvDashboard.Columns[0].Name = "SNO";
                dgvDashboard.Columns[0].DataPropertyName = "SNO";

                dgvDashboard.Columns[1].HeaderText = "Plot No";
                dgvDashboard.Columns[1].Name = "plotNo";
                dgvDashboard.Columns[1].DataPropertyName = "plotNo";

                dgvDashboard.Columns[2].HeaderText = "Client Name";
                dgvDashboard.Columns[2].DataPropertyName = "name";
                dgvDashboard.Columns[2].Name = "name";

                dgvDashboard.Columns[3].HeaderText = "Status";
                dgvDashboard.Columns[3].DataPropertyName = "status";
                dgvDashboard.Columns[3].Name = "status";

                dgvDashboard.Columns[4].HeaderText = "contactNo";
                dgvDashboard.Columns[4].DataPropertyName = "contactNo";
                dgvDashboard.Columns[4].Name = "contactNo";


                dgvDashboard.Columns[5].HeaderText = "date";
                dgvDashboard.Columns[5].DataPropertyName = "date";
                dgvDashboard.Columns[5].Name = "date";

                DataTable dt = ap.getAllProjects();

                dgvDashboard.DataSource = dt;

                this.dgvDashboard.Columns["contactNo"].Visible = false;
                this.dgvDashboard.Columns["date"].Visible = false;

                //dgvDashboard.AutoResizeColumns();
                //dgvDashboard.AutoResizeRows();
                dgvDashboard.Columns[0].Width = 50;
                dgvDashboard.Columns[1].Width = 200;
                dgvDashboard.Columns[2].Width = 200;
                dgvDashboard.Columns[3].Width = 100;

                dgvDashboard.DefaultCellStyle.Font = Global.getSystemFont(11);
                dgvDashboard.ColumnHeadersDefaultCellStyle.Font = Global.getSystemFont(11);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvDashboard_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String plotID = "";
            String clientName = "";
            String Status = "";
            String contactNo = "";
            String Date = "";

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvDashboard.Rows[e.RowIndex];
                plotID = row.Cells["plotNo"].Value.ToString();
                clientName = row.Cells["name"].Value.ToString();
                Status = row.Cells["status"].Value.ToString();
                contactNo = row.Cells["contactNo"].Value.ToString();
                Date = row.Cells["date"].Value.ToString();

                if (plotID == "") { }
                else
                {
                    
                    project = new Project();
                    project.plotNo = plotID;
                    project.name = clientName;
                    project.status = Status;
                    project.contactNo = contactNo;
                    project.date = Date;
                    
                    addNewProject a = new addNewProject(project);
                    a.Show();
                    this.Hide();
                    //this.Dispose();
                }

            }

        }
        Bitmap bmp;
        private DataGridView SetColwidth(DataGridView dgvTemp)
        {
            var docWidth = printPreviewDialog1.Document.DefaultPageSettings.PaperSize.Width;
            dgvTemp.Columns["SNO"].Width = Global.GetScreenWidthInPixcel(10, docWidth);
            dgvTemp.Columns["plotNo"].Width = Global.GetScreenWidthInPixcel(40, docWidth);
            dgvTemp.Columns["name"].Width = Global.GetScreenWidthInPixcel(30, docWidth);
            dgvTemp.Columns["status"].Width = Global.GetScreenWidthInPixcel(20, docWidth);

            return dgvTemp;
        }
        private DataGridView CopyDataGridView(DataGridView dg)
        {
            var from = 0;
            var to = dg.Rows.Count;
            var dgvTemp = new DataGridView();
            dgvTemp.Visible = false;
            dgvTemp.ScrollBars = ScrollBars.None;
            dgvTemp.DefaultCellStyle.Font = Global.getSystemFont(9);

            dgvTemp.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvTemp.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;


            dgvTemp.ColumnHeadersDefaultCellStyle.Font = Global.getSystemFont(9);

            try
            {
                int colCount = 0;
                if (dgvTemp.Columns.Count == 0)
                {
                    foreach (DataGridViewColumn dgvc in dgvDashboard.Columns)
                    {
                        dgvTemp.Columns.Add(dgvc.Clone() as DataGridViewColumn);
                        dgvTemp.Columns[colCount].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        //dgvTemp.Columns[colCount].Width = dgvc.Width;
                        colCount++;
                    }
                }

                DataGridViewRow row = new DataGridViewRow();

                for (int i = from; i < to; i++)
                {
                    row = (DataGridViewRow)dgvDashboard.Rows[i].Clone();
                    int intColIndex = 0;
                    foreach (DataGridViewCell cell in dgvDashboard.Rows[i].Cells)
                    {
                        row.Cells[intColIndex].Value = cell.Value;
                        intColIndex++;
                    }
                    dgvTemp.Rows.Add(row);
                }
                dgvTemp.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvTemp.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;

                dgvTemp.AllowUserToAddRows = false;
                dgvTemp.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Copy DataGridViw: " + ex);
            }
            return dgvTemp;
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            //int height = dgvDashboard.Height;
            //int width = dgvDashboard.Width;
            //int printWidth = 800;
            //dgvDashboard.Width = printWidth;
            //dgvDashboard.Height = dgvDashboard.RowCount * dgvDashboard.RowTemplate.Height * 2;
            ////bmp = new Bitmap(dgvDashboard.Width, dgvDashboard.Height);
            //dgvDashboard.DrawToBitmap(bmp, new Rectangle(0, 0, dgvDashboard.Width, dgvDashboard.Height));
            var dg = CopyDataGridView(dgvDashboard);
            dg = SetColwidth(dg);
            var fileName = "All_Projects";
            Extensions.PrintPDF(dg, fileName);

            //dgvDashboard.Height = height;
            //dgvDashboard.Width = width;
            //printPreviewDialog1.ShowDialog();

        }

        private void dgvDashboard_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dgvDashboard.Rows[e.RowIndex].Cells["SNO"].Value = (e.RowIndex + 1).ToString();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }
    }
}
