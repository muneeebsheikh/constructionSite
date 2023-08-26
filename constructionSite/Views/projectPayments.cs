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
    public partial class projectPayments : Form
    {
        private Project p;
        AccessProject ap;

        DataTable dtGlobal;

        Bitmap bmp;
        int recievedAmountWidth = 0;
        int datetWidth = 0;
        int balancetWidth = 0;
        DataGridView dgvTemp;


        public projectPayments(Project proj)
        {
            this.p = proj;
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

        private void mainTableFormat()
        {
            var docWidth = dgvPayment.Width;
            if (!chkRecivedPayments.Checked)
            {
                dgvPayment.Columns["DATE"].Width = Global.GetScreenWidthInPixcel(10, docWidth);
                dgvPayment.Columns["NAME"].Width = Global.GetScreenWidthInPixcel(20, docWidth);
                dgvPayment.Columns["PARTICULARS"].Width = Global.GetScreenWidthInPixcel(40, docWidth);
                dgvPayment.Columns["NAAM"].Width = Global.GetScreenWidthInPixcel(10, docWidth);
                dgvPayment.Columns["RECIEVED AMOUNT"].Width = Global.GetScreenWidthInPixcel(10, docWidth);
                dgvPayment.Columns["BALANCE"].Width = Global.GetScreenWidthInPixcel(10, docWidth);
            }
            else
            {
                dgvPayment.Columns["SNO"].Width = Global.GetScreenWidthInPixcel(10, docWidth); ;
                dgvPayment.Columns["DATE"].Width = Global.GetScreenWidthInPixcel(10, docWidth); ;
                dgvPayment.Columns["PAYMENT_DESCRIPTION"].Width = Global.GetScreenWidthInPixcel(60, docWidth);
                dgvPayment.Columns["AMOUNT"].Width = Global.GetScreenWidthInPixcel(15, docWidth);
                dgvPayment.Columns["BALANCE"].Width = Global.GetScreenWidthInPixcel(15, docWidth);
            }

 

        }
        private void formReload()
        {
            dgvPayment.DefaultCellStyle.Font = Global.getSystemFont(11);
            dgvPayment.ColumnHeadersDefaultCellStyle.Font = Global.getSystemFont(11);
            dgvPayment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPayment.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvPayment.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvPayment.AutoResizeRows();
        }


        private void SetColwidth()
        {
            var docWidth = printPreviewDialog1.Document.DefaultPageSettings.PaperSize.Width;

            if (!chkRecivedPayments.Checked)
            {
                if (recievedAmountWidth == 0 && datetWidth == 0 && balancetWidth == 0)
                {
                    recievedAmountWidth = dgvTemp.Columns["RECIEVED AMOUNT"].Width;
                    datetWidth = dgvTemp.Columns["DATE"].Width;
                    balancetWidth = dgvTemp.Columns["BALANCE"].Width;
                }

                dgvTemp.Columns["DATE"].Width = Global.GetScreenWidthInPixcel(15, docWidth);
                dgvTemp.Columns["NAME"].Width = Global.GetScreenWidthInPixcel(20, docWidth);
                dgvTemp.Columns["PARTICULARS"].Width = Global.GetScreenWidthInPixcel(35, docWidth);
                dgvTemp.Columns["RECIEVED AMOUNT"].Width = Global.GetScreenWidthInPixcel(10, docWidth);
                dgvTemp.Columns["NAAM"].Width = Global.GetScreenWidthInPixcel(10, docWidth);
                dgvTemp.Columns["BALANCE"].Width = Global.GetScreenWidthInPixcel(10, docWidth);

            }
            else { 
                dgvTemp.Columns["SNO"].Width = 50;
                dgvTemp.Columns["DATE"].Width = 100;
                dgvTemp.Columns["PAYMENT_DESCRIPTION"].Width = 400;
                dgvTemp.Columns["AMOUNT"].Width = 100;
                dgvTemp.Columns["BALANCE"].Width = 150;


            }

        }
        
        private void printDoc()
        {
            int height = dgvTemp.Height;

            dgvTemp.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvTemp.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;


            SetColwidth();

            int printWidth = 800;
            int dvgWidth = dgvTemp.Width;
            var printHeight = dgvTemp.RowCount * dgvTemp.RowTemplate.Height * 2;
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

        private DataGridView CopyDataGridView(int from, int to)
        {
            dgvTemp = new DataGridView();
            dgvTemp.Visible = false;
            dgvTemp.ScrollBars = ScrollBars.None;
            dgvTemp.DefaultCellStyle.Font = Global.getSystemFont(9);
            
            dgvTemp.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvTemp.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;


            dgvTemp.ColumnHeadersDefaultCellStyle.Font = Global.getSystemFont(9);

            try
            { int colCount = 0;
                if (dgvTemp.Columns.Count == 0)
                {
                    foreach (DataGridViewColumn dgvc in dgvPayment.Columns)
                    {
                        dgvTemp.Columns.Add(dgvc.Clone() as DataGridViewColumn);
                        dgvTemp.Columns[colCount].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        colCount++;
                    }
                }

                DataGridViewRow row = new DataGridViewRow();

                for (int i = from; i < to; i++)
                {
                    row = (DataGridViewRow)dgvPayment.Rows[i].Clone();
                    int intColIndex = 0;
                    foreach (DataGridViewCell cell in dgvPayment.Rows[i].Cells)
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
        
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            CopyDataGridView(0, dgvPayment.Rows.Count);
            SetColwidth();
            var fileName = p.plotNo + (chkRecivedPayments.Checked ? " - Received Payments" : "");
            Extensions.PrintPDF(dgvTemp, fileName, $"All Payments\nTitle: {fileName}");
            dgvTemp.Dispose();

        }


        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //e.HasMorePages = true;

            e.Graphics.DrawImage(bmp, 0, 0);

        }

        private void datePickerFrom_onValueChanged(object sender, EventArgs e)
        {
            dgvPayment.DataSource = null;
            dgvPayment.ColumnCount = 0;
            string fromDate = datePickerFrom.Value.ToString("yyyy-MM-dd");
            string toDate = datePickerTo.Value.ToString("yyyy-MM-dd");

            if (chkRecivedPayments.Checked)
            {
                dgvPayment.DataSource = ap.getAllRecievedPayments(this.p, fromdate: fromDate, todate: toDate);
                dtGlobal= ap.getAllRecievedPayments2(this.p, fromdate: fromDate, todate: toDate);
            }
            else
            {
                dgvPayment.DataSource = ap.getMainTable(p: this.p, fromdate: fromDate, todate: toDate);
            }
            mainTableFormat();
            formReload();
        }

        private void datePickerTo_onValueChanged(object sender, EventArgs e)
        {
            dgvPayment.DataSource = null;
            dgvPayment.ColumnCount = 0;
            string fromDate = datePickerFrom.Value.ToString("yyyy-MM-dd");
            string toDate = datePickerTo.Value.ToString("yyyy-MM-dd");

            if (chkRecivedPayments.Checked)
            {
                dgvPayment.DataSource = ap.getAllRecievedPayments(this.p, fromdate: fromDate, todate: toDate);
                dtGlobal = ap.getAllRecievedPayments2(this.p, fromdate: fromDate, todate: toDate);
            }
            else
            {
                dgvPayment.DataSource = ap.getMainTable(p: this.p, fromdate: fromDate, todate: toDate);
            }
            mainTableFormat();
            formReload();

        }

        private void chkRecivedPayments_OnChange(object sender, EventArgs e)
        {
            dgvPayment.DataSource = null;
            dgvPayment.ColumnCount = 0;
            string fromDate = datePickerFrom.Value.ToString("yyyy-MM-dd");
            string toDate = datePickerTo.Value.ToString("yyyy-MM-dd");

            if (chkRecivedPayments.Checked)
            {
                dgvPayment.DataSource = ap.getAllRecievedPayments(this.p, fromdate: fromDate, todate: toDate);
                dtGlobal = ap.getAllRecievedPayments2(this.p, fromdate: fromDate, todate: toDate);
               
            }
            else
            {
                dgvPayment.DataSource = ap.getMainTable(p: this.p, fromdate: fromDate, todate: toDate);
            }
            mainTableFormat();

        }

        private void dgvPayment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Project.Payment payment = new Project.Payment();
                Project.Payment payment2 = new Project.Payment();
                DataGridViewRow row = this.dgvPayment.Rows[e.RowIndex];
                if (chkRecivedPayments.Checked)
                {
                    payment.amount = row.Cells["AMOUNT"].Value.ToString();
                    payment.serialNo = row.Cells["SNO"].Value.ToString();
                    payment.date = row.Cells["DATE"].Value.ToString();
                    payment.description = row.Cells["PAYMENT_DESCRIPTION"].Value.ToString();
                    string vv = "";
                    foreach (DataRow rowGlobal in dtGlobal.Rows)
                    {
                        if (payment.amount == rowGlobal["AMOUNT"].ToString() &&
                            payment.serialNo == rowGlobal["SNO"].ToString() &&
                            payment.date == rowGlobal["DATE"].ToString())
                        {
                            vv=rowGlobal["PAYMENT_DESCRIPTION"].ToString();
                        }
                    }
                    payment2.amount = row.Cells["AMOUNT"].Value.ToString();
                    payment2.serialNo = row.Cells["SNO"].Value.ToString();
                    payment2.date = row.Cells["DATE"].Value.ToString();
                    payment2.description = vv;

                    RecivePayment paymentForm = new RecivePayment(this.p, payment2);
                    paymentForm.Show();
                    this.Hide();
                }
            }
        }

        private void projectPayments_Load(object sender, EventArgs e)
        {
            try
            {

                lblName.Text = this.p.name;
                chkRecivedPayments.Checked = false;
                datePickerFrom.Value = new DateTime(2000, 01, 01);
                datePickerTo.Value = DateTime.Now;
                dgvPayment.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            addNewProject a = new addNewProject(this.p);
            a.Show();
            this.Hide();
             
        }
        
    }
}
