using constructionSite.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using constructionSite.Model;

namespace constructionSite.Views
{
    public partial class SelectedWorker : Form
    {
        AccessProject ap = new AccessProject();
        private Project.Worker projectWorker;
        private Project.Bill projectBill;
        private Project p;
        public SelectedWorker(Project proj, Project.Worker p)
        {
            this.p = proj;
            this.projectWorker = p;
            InitializeComponent();
        }

        private void btnAddNewBill_Click(object sender, EventArgs e)
        {
            addNewBill a = new addNewBill(this.p, this.projectWorker, "Worker");
            a.Show();
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            workerRecordDetails w = new workerRecordDetails(this.p, this.projectWorker);
            w.Show();
            this.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            dashboard d = new dashboard();
            d.Show();
            this.Hide();
        }

        private void SelectedWorker_Load(object sender, EventArgs e)
        {

            lblName.Text = this.p.name;
            txtPersonName.Text = projectWorker.personName;
            txtContactNumber.Text = projectWorker.contactNo;
            txtCNIC.Text = projectWorker.CNIC;
            txtEmail.Text = projectWorker.email;
            txtTypeOfWork.Text = projectWorker.typeOfWork;

            //try
            //{

                ////////////// Binding Selected Columns of DGRID1//////////////////////

                DataTable dt = ap.getWorkerBills(this.p, this.projectWorker);
                dgvBills.ColumnCount = 0;
                dgvBills.DataSource = dt;

                dgvBills.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;

                dgvBills.AutoResizeColumns();
                dgvBills.AutoResizeRows();
                dgvBills.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                this.dgvBills.Columns["IMAGEPATH"].Visible = false;
                this.dgvBills.Columns["TYPE"].Visible = false;
                this.dgvBills.Columns["AMOUNT"].Visible = false;
                this.dgvBills.Columns["rowid"].Visible = false;

                
                this.dgvBills.Columns["PARTICULAR"].FillWeight = 150;
                this.dgvBills.Columns["BILLNO"].FillWeight = 20;
                this.dgvBills.Columns["NAAM"].FillWeight = 50;
                this.dgvBills.Columns["JAMA"].FillWeight = 50;
                this.dgvBills.Columns["DATE"].FillWeight = 30;
                this.dgvBills.Columns["BALANCE"].FillWeight = 50;
            dgvBills.DefaultCellStyle.Font = Global.getSystemFont(11);
            dgvBills.ColumnHeadersDefaultCellStyle.Font = Global.getSystemFont(11);

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void dgvBills_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvBills.RowCount - 1)
            {
                DataGridViewRow row = this.dgvBills.Rows[e.RowIndex];
                string BNo = row.Cells["billNo"].Value.ToString();
                string Amount = row.Cells["amount"].Value.ToString();
                string Date = row.Cells["date"].Value.ToString();
                string Type = row.Cells["type"].Value.ToString();
                string Particular = row.Cells["particular"].Value.ToString();
                string imagePath = row.Cells["imagePath"].Value.ToString();
                string rowid = row.Cells["rowid"].Value.ToString();
                if (BNo == "") { }
                else
                {

                    projectBill = new Project.Bill();
                    projectBill.billNo = BNo;
                    projectBill.amount = Amount;
                    projectBill.date = Date;
                    projectBill.type = Type;
                    projectBill.particular = Particular;
                    projectBill.imagePath = imagePath;
                    projectBill.rowid = rowid;

                    addNewBill a = new addNewBill(this.p, this.projectWorker, "Worker", projectBill);
                    a.Show();
                    this.Hide();
                }
            }
        }
        Bitmap bmp;
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            var dgvTemp = GetTempDgv();
            
            //int height = dgvTemp.Height;
            int printWidth = 800;
            //int dvgWidth = dgvTemp.Width;
            dgvTemp.Width = printWidth;

            SetTempColWidth(dgvTemp);

            dgvTemp.Height = dgvTemp.RowCount * dgvTemp.RowTemplate.Height * 2;

            //dgvTemp.AutoResizeRows();

            //bmp = new Bitmap(dgvTemp.Width, dgvTemp.Height);
            //dgvTemp.DrawToBitmap(bmp, new Rectangle(0, 0, dgvTemp.Width, dgvTemp.Height));

            var fileName = projectWorker.personName;
            Extensions.PrintPDF(dgvTemp, fileName);
            dgvTemp.Dispose();
            //dgvTemp.Height = height;
            //dgvTemp.Width = dvgWidth;
            //printPreviewDialog1.ShowDialogWithMargin();


            //dgvBills.DefaultCellStyle.Font = Global.getSystemFont(9);
            //dgvBills.ColumnHeadersDefaultCellStyle.Font = Global.getSystemFont(8);


            //int height = dgvBills.Height;
            //int printWidth = 800;
            //int dvgWidth = dgvBills.Width;
            //dgvBills.Width = printWidth;

            //dgvBills.Height = dgvBills.RowCount * dgvBills.RowTemplate.Height * 2;
            //bmp = new Bitmap(dgvBills.Width, dgvBills.Height);
            //dgvBills.DrawToBitmap(bmp, new Rectangle(0, 0, dgvBills.Width, dgvBills.Height));
            //dgvBills.Height = height;
            //dgvBills.Width = dvgWidth;
            //printPreviewDialog1.ShowDialog();

            //dgvBills.DefaultCellStyle.Font = Global.getSystemFont(11);
            //dgvBills.ColumnHeadersDefaultCellStyle.Font = Global.getSystemFont(11);

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        void SetTempColWidth(DataGridView dgv)
        {
            var docWidth = printPreviewDialog1.Document.DefaultPageSettings.PaperSize.Width;

            dgv.Columns["billno"].Width = Global.GetScreenWidthInPixcel(10, docWidth);
            dgv.Columns["date"].Width = Global.GetScreenWidthInPixcel(10, docWidth);
            dgv.Columns["particular"].Width = Global.GetScreenWidthInPixcel(40, docWidth);
            dgv.Columns["naam"].Width = Global.GetScreenWidthInPixcel(10, docWidth);
            dgv.Columns["jama"].Width = Global.GetScreenWidthInPixcel(10, docWidth);
            dgv.Columns["balance"].Width = Global.GetScreenWidthInPixcel(10, docWidth);

        }

        DataGridView GetTempDgv()
        {
            var dgvTemp = new DataGridView();
            dgvTemp.Visible = false;
            dgvTemp.ScrollBars = ScrollBars.None;
            dgvTemp.DefaultCellStyle.Font = Global.getSystemFont(9);
            dgvTemp.ColumnHeadersDefaultCellStyle.Font = Global.getSystemFont(8);
            dgvTemp.AllowUserToAddRows = false;

            int colCount = 0;
            foreach (DataGridViewColumn col in dgvBills.Columns)
            {
                dgvTemp.Columns.Add(col.Clone() as DataGridViewColumn);
                colCount++;
            }

            foreach (DataGridViewRow row in dgvBills.Rows)
            {
                var r = row.Clone() as DataGridViewRow;
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    //DataGridViewCell cell = row.Cells[i].Clone() as DataGridViewCell;
                    r.Cells[i].Value = row.Cells[i].Value;
                }
                dgvTemp.Rows.Add(r);

            }

            dgvTemp.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvTemp.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            return dgvTemp;
        }


    }
}
