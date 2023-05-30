using constructionSite.Controller;
using constructionSite.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace constructionSite.Views
{
    public partial class Summary : Form
    {

        private Project p;
        private AccessProject ap = new AccessProject();
        private DataGridView dgvTemp;
        private Bitmap bmp;
        public Summary(Project proj)
        {
            this.p = proj;
            InitializeComponent();
            init_form();

        }

        private void init_form()
        {
            lblName.Text = p.name;
            dgvSummary.ColumnCount = 0;
            dgvSummary.DataSource = ap.getSummaryTable(this.p);
            this.dgvSummary.DefaultCellStyle.Font = Global.getSystemFont(11);
            this.dgvSummary.ColumnHeadersDefaultCellStyle.Font = Global.getSystemFont(11);
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            CopyDataGridView(0, dgvSummary.Rows.Count);
            SetColwidth();
            var fileName = p.plotNo + " - Summary";
            Extensions.PrintPDF(dgvTemp, fileName);
            dgvTemp.Dispose();
            //int rowCount = dgvSummary.Rows.Count;
            //int rowsPerPage = 42;
            //if (dgvSummary.Rows.Count > rowsPerPage)
            //{
            //    int preCount = 0;
            //    int count = rowsPerPage;
            //    while (count <= rowCount)
            //    {
            //        CopyDataGridView(preCount, count);
            //        printDoc();
            //        preCount = count;
            //        count += rowsPerPage;

            //    }
            //    CopyDataGridView(preCount, rowCount);
            //    printDoc();
            //}
            //else
            //{
            //    CopyDataGridView(0, rowCount);
            //    printDoc();
            //}
        }

        private void printDoc()
        {

            dgvTemp.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvTemp.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;

            int height = dgvTemp.Height;
            
            SetColwidth();

            int printWidth = 800;
            int dvgWidth = dgvTemp.Width;
            dgvTemp.Width = printWidth;
            dgvTemp.Height = dgvTemp.RowCount * dgvTemp.RowTemplate.Height * 2;

            dgvTemp.AutoResizeRows();

            bmp = new Bitmap(dgvTemp.Width, dgvTemp.Height);
            dgvTemp.DrawToBitmap(bmp, new Rectangle(0, 0, dgvTemp.Width, dgvTemp.Height));
            dgvTemp.Height = height;
            dgvTemp.Width = dvgWidth;
            SetColwidth();
            
            printPreviewDialog1.ShowDialogWithMargin();

        }

        //private int GetScreenWidthInPixcel(double percent)
        //{
        //    //var screenWidth = Screen.PrimaryScreen.Bounds.Width;
            
        //    var screenWidth = printPreviewDialog1.Document.DefaultPageSettings.PaperSize.Width;
        //    var p = screenWidth * (percent / 100);
        //    var p1 = (int)Math.Floor(p);
        //    return p1;
        //}

        private void SetColwidth()
        {

            //dgvTemp.Columns["S.No"].Width = 50;
            //dgvTemp.Columns["Name"].Width = 475;
            //dgvTemp.Columns["company_worker"].Width = 125;
            //dgvTemp.Columns["Amount"].Width = 150;
            var docWidth = printPreviewDialog1.Document.DefaultPageSettings.PaperSize.Width;
            dgvTemp.Columns["S.No"].Width = Global.GetScreenWidthInPixcel(5, docWidth);
            dgvTemp.Columns["Name"].Width = Global.GetScreenWidthInPixcel(45, docWidth);
            dgvTemp.Columns["company_worker"].Width = Global.GetScreenWidthInPixcel(30, docWidth);
            dgvTemp.Columns["Amount"].Width = Global.GetScreenWidthInPixcel(20, docWidth);
        }

        private DataGridView CopyDataGridView(int from, int to)
        {
            dgvTemp = new DataGridView();
            dgvTemp.Visible = false;
            dgvTemp.ScrollBars = ScrollBars.None;

            dgvTemp.DefaultCellStyle.Font = Global.getSystemFont(9);
            dgvTemp.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dgvTemp.ColumnHeadersDefaultCellStyle.Font = Global.getSystemFont(9);

            try
            {
                int colCount = 0;
                if (dgvTemp.Columns.Count == 0)
                {
                    foreach (DataGridViewColumn dgvc in dgvSummary.Columns)
                    {
                        dgvTemp.Columns.Add(dgvc.Clone() as DataGridViewColumn);
                        colCount++;
                    }
                }

                DataGridViewRow row = new DataGridViewRow();

                for (int i = from; i < to; i++)
                {
                    row = (DataGridViewRow)dgvSummary.Rows[i].Clone();
                    int intColIndex = 0;
                    foreach (DataGridViewCell cell in dgvSummary.Rows[i].Cells)
                    {
                        row.Cells[intColIndex].Value = cell.Value;
                        intColIndex++;
                    }
                    dgvTemp.Rows.Add(row);
                }
                dgvTemp.AllowUserToAddRows = false;
                dgvTemp.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Copy DataGridViw: " + ex);
            }
            return dgvTemp;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }
    }
}
