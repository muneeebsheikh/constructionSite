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
    public partial class patyCash : Form
    {
        public patyCash()
        {
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

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            dashboard d = new dashboard();
            d.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            addNewProject a = new addNewProject();
            a.Show();
            this.Hide();
        }

        private void datePicker_onValueChanged(object sender, EventArgs e)
        {
            MessageBox.Show(datePicker.Value.ToShortDateString());
        }

        private void txtAmount_OnValueChanged(object sender, EventArgs e)
        {
            txtAmount.Text = string.Concat(txtAmount.Text.Where(char.IsDigit));
        }

  
    }
}
