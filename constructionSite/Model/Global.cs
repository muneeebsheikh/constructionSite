using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace constructionSite.Model
{
    class Global
    {
        private static string fontName = "Tahoma";

        public static Font getSystemFont(int fontSize)
        {
            return new Font(fontName, fontSize); 
        }

        public static DataGridView CopyDataGridView(DataGridView dgvCopy, DataGridView dgvOrg, int from, int to)
        {
            dgvCopy = new DataGridView();
            dgvCopy.Visible = false;
            dgvCopy.ScrollBars = ScrollBars.None;
            dgvCopy.DefaultCellStyle.Font = Global.getSystemFont(9);
            dgvCopy.ColumnHeadersDefaultCellStyle.Font = Global.getSystemFont(9);
            try
            {
                int colCount = 0;
                if (dgvCopy.Columns.Count == 0)
                {
                    foreach (DataGridViewColumn dgvc in dgvOrg.Columns)
                    {
                        dgvCopy.Columns.Add(dgvc.Clone() as DataGridViewColumn);
                        dgvCopy.Columns[colCount].Width = dgvc.Width;
                        colCount++;
                    }
                }

                DataGridViewRow row = new DataGridViewRow();

                for (int i = from; i < to; i++)
                {
                    row = (DataGridViewRow)dgvOrg.Rows[i].Clone();
                    int intColIndex = 0;
                    foreach (DataGridViewCell cell in dgvOrg.Rows[i].Cells)
                    {
                        row.Cells[intColIndex].Value = cell.Value;
                        intColIndex++;
                    }
                    dgvCopy.Rows.Add(row);
                }
                dgvCopy.AllowUserToAddRows = false;
                dgvCopy.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Copy DataGridViw: " + ex);
            }
            return dgvCopy;
        }
        public static int GetScreenWidthInPixcel(double percent, int documentWidth)
        {
            var p = documentWidth * (percent / 100);
            var p1 = (int)Math.Floor(p);
            return p1;
        }
    }
}
