using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using constructionSite.Controller;
namespace constructionSite.Views
{
    public partial class displayImage : Form
    {
        static string dir = Application.StartupPath;
        private string formName="";

        private Project p;
        private Project.Worker projWorker;
        private Project.Company projCompany;
        private Project.Bill projBill;
        public displayImage(Project p,Project.Worker worker,string name, Project.Bill projBill)
        {
            this.p = p;
            this.formName = name;
            this.projBill = projBill;
            this.projWorker = worker;
            InitializeComponent();
        }

        public displayImage(Project p, Project.Company company,string name,Project.Bill projBill)
        {
            this.p = p;
            this.formName = name;
            this.projBill = projBill;
            this.projCompany = company;
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

        private void displayImage_Load(object sender, EventArgs e)
        {
            String pth = this.projBill.imagePath;
            if (Directory.Exists(dir + "\\" + pth) == false)
            {
                if (File.Exists(dir + "\\" + pth))
                {
                    //var img = Image.FromFile(dir + "\\" + pth);
                    pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                    pictureBox1.Image = Image.FromFile(dir + "\\" + pth);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            else
            {
                MessageBox.Show("Error Showing Image");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if(formName =="Worker")
            {
                addNewBill a = new addNewBill(this.p,this.projWorker, formName,this.projBill);
                a.Show();
                this.Hide();
            }
            else if(formName == "Company")
            {

                addNewBill a = new addNewBill(this.p, this.projCompany, formName, this.projBill);
                a.Show();
                this.Hide();
            }
        }
    }
}
