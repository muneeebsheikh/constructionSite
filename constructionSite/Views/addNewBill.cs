using constructionSite.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace constructionSite.Views
{
    public partial class addNewBill : Form
    {
        static string dir = Application.StartupPath;
        Image img;
        String openFileDialougPath = "a";
        bool flagOpenFileDialouge = false;

        AccessProject ap = new AccessProject();
        private Project p;
        private Project.Worker projWorker;
        private Project.Company projCompany;
        private Project.Bill projBill;
        private String FormName;
        private String ready = "false";
        private string lblDisplayNameFull = "";
        private string lblDisplayName = "";
        private string typeOfBill = "";

        private void initCtor()
        {
            lblDisplayNameFull = lblDisplayName;
            if(lblDisplayName.Length > 15)
            {
                lblDisplayName = lblDisplayName.Substring(0, 50) + "...";
            }
            lblDisplayName += Environment.NewLine + $"({typeOfBill})";
            
        }
        private addNewBill(Project proj, string personName, string typeOfBill)
        {
            lblDisplayName = proj.name + " - " + personName;
            this.typeOfBill = typeOfBill;
            InitializeComponent();
            var toolTipName = new ToolTip();
            toolTipName.ShowAlways = true;
            toolTipName.IsBalloon = true;
            toolTipName.ToolTipIcon = ToolTipIcon.Info;
            toolTipName.SetToolTip(lblName, lblDisplayNameFull);
            initCtor();
        }
        public addNewBill(Project proj , Project.Worker projectWorker,String formName): this(proj, projectWorker.personName, "Worker Bill")
        {
            this.p = proj;
            this.projWorker = projectWorker;
            this.FormName = formName;
        }
        public addNewBill(Project proj, Project.Worker projectWorker, String formName,Project.Bill projBill): this(proj, projectWorker.personName, "Worker Bill")
        {
            this.p = proj;
            this.projWorker = projectWorker;
            this.FormName = formName;
            this.projBill = projBill;
            this.ready = "true";
        }
        public addNewBill(Project proj, Project.Company projectCompany, String formName): this(proj, projectCompany.personName, "Company Bill")
        {
            this.p = proj;
            this.projCompany = projectCompany;
            this.FormName = formName;

        }
        public addNewBill(Project proj, Project.Company projectCompany, String formName,Project.Bill projBill): this(proj, projectCompany.personName, "Company Bill")
        {
            
            this.p = proj;
            this.projCompany = projectCompany;
            this.FormName = formName;
            this.projBill = projBill;
            this.ready = "true";
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
            if(FormName == "Worker")
            {
                SelectedWorker s = new SelectedWorker(this.p, this.projWorker);
                s.Show();
                this.Hide();
            }
            else if(FormName == "Company")
            {
                SelectedCompany s= new SelectedCompany(this.p, this.projCompany);
                s.Show();
                this.Hide();
            }
        }

        private void txtBillNumber_OnValueChanged(object sender, EventArgs e)
        {
            //txtBillNumber.Text = string.Concat(txtBillNumber.Text.Where(char.IsDigit));
        }

        private void addNewBill_Load(object sender, EventArgs e)
        {

            lblName.Text = lblDisplayName;
            if (ready == "true")
            {
                btnSave.Visible = false;
                txtBillNumber.Enabled = false;
                //datePicker.Visible = false;
                txtDate.Visible = false;

                txtBillNumber.Text = projBill.billNo;
                txtAmount.Text = projBill.amount;
                rtbParticular.Text = projBill.particular;
                txtImagePath.Text = projBill.imagePath;

                //DateTime oDate = Convert.ToDateTime(projBill.date);
                //MessageBox.Show(oDate.ToString());
                //DateTime dt = DateTime.ParseExact(oDate.ToString(), "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                //string s = dt.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
                //txtDate.Text = s;

                //datePicker.Value = DateTime.Parse(projBill.date);
                datePicker.Value = DateTime.ParseExact(projBill.date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                if (Directory.Exists(dir + "\\" + txtImagePath.Text.ToString()) == false)
                {
                    if (File.Exists(dir + "\\" + txtImagePath.Text.ToString()))
                    {
                        pictureBox1.Image = Image.FromFile(dir + "\\" + txtImagePath.Text.ToString());
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                else
                {
                    //MessageBox.Show("No Image Found");
                }

                if (projBill.type == "Naam")
                {
                    chkboxNaam.Checked = true;
                    chkboxJama.Checked = false;
                }
                else if (projBill.type == "Jama")
                {
                    chkboxNaam.Checked = false;
                    chkboxJama.Checked = true;
                }
                else
                {
                    chkboxNaam.Checked = true;
                    chkboxJama.Checked = false;
                }
            }
            else
            {
                chkboxNaam.Checked = true;
                chkboxJama.Checked = false;
                datePicker.Value = DateTime.Now;
                txtDate.Visible = false;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
            }
        }

        private void chkboxNaam_OnChange(object sender, EventArgs e)
        {
            if (chkboxJama.Checked == true)
             {
                chkboxJama.Checked = false;
             }
        }

        private void chkboxJama_OnChange(object sender, EventArgs e)
        {
            if (chkboxNaam.Checked == true)
            {
                chkboxNaam.Checked = false;
            }
        }

        private void txtAmount_OnValueChanged(object sender, EventArgs e)
        {
            txtAmount.Text = string.Concat(txtAmount.Text.Where(char.IsDigit));
        }

        private void datePicker_onValueChanged(object sender, EventArgs e)
        {
           // MessageBox.Show(datePicker.Value.ToShortDateString());
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            
            try
            {
                openFileDialog1.InitialDirectory = "c:\\Pictures";
                openFileDialog1.Filter = "All Images Files (*.png;*.jpeg;*.gif;*.jpg;*.bmp;*.tiff;*.tif)|*.png;*.jpeg;*.gif;*.jpg;*.bmp;*.tiff;*.tif" ;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    txtImagePath.Text = openFileDialog1.FileName.ToString();
                    openFileDialougPath = txtImagePath.Text.ToString();
                    img = Image.FromFile(openFileDialog1.FileName);
                    //img = (Image)(new Bitmap(img, new Size(pictureBox1.Width, pictureBox1.Height)));
                    pictureBox1.Image = img;
                    flagOpenFileDialouge = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string date= datePicker.Value.ToString("yyyy-MM-dd");
            string billNumber = txtBillNumber.Text.ToString();
            string amount = txtAmount.Text.ToString();
            String particuler = rtbParticular.Text.ToString();
            string type = "";

            //MessageBox.Show(date);

            if (chkboxJama.Checked == true)
            {
                type = "Jama";
            }
            else if (chkboxNaam.Checked == true)
            {
                type = "Naam";
            }
            

           if(txtBillNumber.Text =="" || txtAmount.Text == "")
            {
                MessageBox.Show("Bill No And Amount is required");
            }
            else
            {
                if (FormName == "Worker")
                {
                    try
                    {
                        if(flagOpenFileDialouge == true)
                        {
                            string iName = openFileDialog1.FileName;
                            string folder = @"workerBillImages\";
                            var path = Path.Combine(folder, Path.GetFileName(iName));
                            Console.WriteLine("path:" + path);
                            if (!Directory.Exists(folder))
                            {
                                Directory.CreateDirectory(folder);
                            }

                            if (File.Exists(path))
                            {
                                string newFilename = ap.getFilename(iName) + txtBillNumber.Text;
                                string ext = ap.getExtension(iName);
                                //iName = newFilename + ext;
                                path = Path.Combine(folder, Path.GetFileName(newFilename + ext));
                                Console.WriteLine("path2:" + path);
                            }
                            if (!File.Exists(path))
                            {
                                Console.WriteLine("path3:" + path);
                                File.Copy(iName, path);
                            }

                            if (path != "") { txtImagePath.Text = path; }
                            else { txtImagePath.Text = ""; }
                        }
                        else { txtImagePath.Text = ""; }
                        


                        projBill = new Project.Bill();
                        projBill.amount = amount;
                        projBill.billNo = billNumber;
                        projBill.type = type;
                        projBill.particular = particuler;
                        projBill.date = date;
                        projBill.imagePath = txtImagePath.Text.ToString();

                        this.projWorker.bills.Add(projBill);
                        ap.addNewWorkerBill(this.p, this.projWorker);
                        MessageBox.Show("Worker Bill Added Successfully");
                        
                            SelectedWorker s = new SelectedWorker(this.p, this.projWorker);
                            s.Show();
                            this.Hide();
                       

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (FormName == "Company")
                {
                    try
                    {


                        if (flagOpenFileDialouge == true)
                        {
                            string iName = openFileDialog1.FileName;
                            string folder = @"companyBillImages\";
                            var path = Path.Combine(folder, Path.GetFileName(iName));
                            Console.WriteLine("path:" + path);
                            if (!Directory.Exists(folder))
                            {
                                Directory.CreateDirectory(folder);
                            }

                            if (File.Exists(path))
                            {
                                string newFilename = ap.getFilename(iName) + txtBillNumber.Text;
                                string ext = ap.getExtension(iName);
                                //iName = newFilename + ext;
                                path = Path.Combine(folder, Path.GetFileName(newFilename + ext));
                                Console.WriteLine("path2:" + path);
                            }
                            if (!File.Exists(path))
                            {
                                Console.WriteLine("path3:" + path);
                                File.Copy(iName, path);
                            }
                            if (path != "") { txtImagePath.Text = path; }
                            else { txtImagePath.Text = ""; }
                        }
                        else { txtImagePath.Text = ""; }


                        projBill = new Project.Bill();
                        projBill.amount = amount;
                        projBill.billNo = billNumber;
                        projBill.type = type;
                        projBill.particular = particuler;
                        projBill.date = date;
                        projBill.imagePath = txtImagePath.Text.ToString();

                        this.projCompany.bills.Add(projBill);
                        ap.addNewCompanyBill(this.p, this.projCompany);

                        MessageBox.Show("Company Bill Added Successfully");
                        
                        
                            SelectedCompany s = new SelectedCompany(this.p, this.projCompany);
                            s.Show();
                            this.Hide();
                        



                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(txtBillNumber.Text=="" || txtAmount.Text == "")
            {
                MessageBox.Show("Bill No And Amount Cannot be Empty");
            }
            else
            {
                if (FormName == "Worker")
                {
                    try
                    {
                        DialogResult res = MessageBox.Show("Are you Sure you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (res == DialogResult.Yes)
                        {
                            ap.deleteWorkerBill(this.p, this.projWorker, this.projBill);
                            MessageBox.Show("Worker Bill Deleted Successfully");
                            SelectedWorker s = new SelectedWorker(this.p, this.projWorker);
                            s.Show();
                            this.Hide();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (FormName == "Company")
                {
                    try
                    {
                        ap.deleteCompanyBill(this.p, this.projCompany, this.projBill);
                        MessageBox.Show("Worker Bill Deleted Successfully");
                        SelectedCompany s = new SelectedCompany(this.p, this.projCompany);
                        s.Show();
                        this.Hide();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //string date = txtDate.Text.ToString();
            string date = datePicker.Value.ToString("yyyy-MM-dd");
            string billNumber = txtBillNumber.Text.ToString();
            string amount = txtAmount.Text.ToString();
            string particuler = rtbParticular.Text.ToString();
            string type = "";
            if (chkboxJama.Checked == true)
            {
                type = "Jama";
            }
            else if (chkboxNaam.Checked == true)
            {
                type = "Naam";
            }
            txtImagePath.Text = this.projBill.imagePath;


            if (billNumber == "" || amount == "")
            {
                MessageBox.Show("Bill no and Amount cannot be Null");
            }
            else
            {
                if (FormName == "Worker")
                {
                    try
                    {
                        if (flagOpenFileDialouge == true)
                        {
                            string iName = openFileDialog1.FileName;
                            string folder = @"workerBillImages\";
                            var path = Path.Combine(folder, Path.GetFileName(iName));
                            Console.WriteLine("path:" + path);
                            if (!Directory.Exists(folder))
                            {
                                Directory.CreateDirectory(folder);
                            }

                            if (File.Exists(path))
                            {
                                string newFilename = ap.getFilename(iName) + txtBillNumber.Text;
                                string ext = ap.getExtension(iName);
                                //iName = newFilename + ext;
                                path = Path.Combine(folder, Path.GetFileName(newFilename + ext));
                                Console.WriteLine("path2:" + path);
                            }
                            if (!File.Exists(path))
                            {
                                Console.WriteLine("path3:" + path);
                                File.Copy(iName, path);
                            }

                            if (path != "") { txtImagePath.Text = path; }
                            else { txtImagePath.Text = ""; }
                        }
                        else { txtImagePath.Text = ""; }


                    }catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    Project.Bill projBill_new = new Project.Bill();
                    projBill_new.amount = amount;
                    projBill_new.billNo = billNumber;
                    projBill_new.type = type;
                    projBill_new.particular = particuler;
                    projBill_new.date = date;
                    projBill_new.imagePath = txtImagePath.Text.ToString();
                    projBill_new.rowid = projBill.rowid;

                    ap.updateWorkerBill(this.p, this.projWorker, projBill_new);
                    MessageBox.Show("Successfullly Updated");
                }
                else if (FormName == "Company")
                {
                    try
                    {

                        if (flagOpenFileDialouge == true)
                        {
                            string iName = openFileDialog1.FileName;
                            string folder = @"companyBillImages\";
                            var path = Path.Combine(folder, Path.GetFileName(iName));
                            Console.WriteLine("path:" + path);
                            if (!Directory.Exists(folder))
                            {
                                Directory.CreateDirectory(folder);
                            }

                            if (File.Exists(path))
                            {
                                string newFilename = ap.getFilename(iName) + txtBillNumber.Text;
                                string ext = ap.getExtension(iName);
                                //iName = newFilename + ext;
                                path = Path.Combine(folder, Path.GetFileName(newFilename + ext));
                                Console.WriteLine("path2:" + path);
                            }
                            if (!File.Exists(path))
                            {
                                Console.WriteLine("path3:" + path);
                                File.Copy(iName, path);
                            }

                            if (path != "") { txtImagePath.Text = path; }
                            else { txtImagePath.Text = ""; }
                        }
                        else { txtImagePath.Text = ""; }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    Project.Bill projBill_new = new Project.Bill();
                    projBill_new.amount = amount;
                    projBill_new.billNo = billNumber;
                    projBill_new.type = type;
                    projBill_new.particular = particuler;
                    projBill_new.date = date;
                    projBill_new.imagePath = txtImagePath.Text.ToString();
                    projBill_new.rowid = projBill.rowid;

                    ap.updateComapnyBill(this.p, this.projCompany, projBill_new);
                    MessageBox.Show("Successfullly Updated");
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            String path = projBill.imagePath;
           if(path != "")
            {
                if (FormName == "Worker")
                {
                    displayImage d = new displayImage(this.p, this.projWorker, this.FormName, this.projBill);
                    d.Show();
                    this.Hide();

                }

                else if (FormName == "Company")
                {
                    displayImage d = new displayImage(this.p, this.projCompany, this.FormName, this.projBill);
                    d.Show();
                    this.Hide();
                }
            }
        }
    }
}
