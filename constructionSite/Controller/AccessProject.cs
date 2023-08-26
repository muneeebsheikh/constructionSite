using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace constructionSite.Controller
{
    class AccessProject
    {
        DbHelper db;
        private readonly Logger.Logger _log = new Logger.Logger("AccessProject");
        public AccessProject()
        {

            db = DbHelper.getInstance();
            //db.insertProject(plotno: "R-1250", name: "Muneeb", contactno: "0302-1233-123");

            //db.insertWorker(personname: "worker1", contactno: "0323312", cnic: "21414-123455-1", email: "ggello@gmai.com", projectName: "Muneeb", typeofwork: "labour",
            //    projectPlotNo: "R-1250");
        }
        public string getSnoRecievePayment(Project project)
        {
            try
            {
                return db.getSno_RecievePayment(plotNo: project.plotNo, projectName: project.name);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "";
        }
        // ADD NEW
        public void addNewCompanyBill(Project p, Project.Company pc)
        {
            int lastind = pc.bills.Count - 1;
            Project.Bill b = pc.bills[lastind];
            if(DateTime.Parse(b.date) > DateTime.Now)
            {
                Console.WriteLine("Future Date Cannot be Entered");
                return;
            } 

            int noOfRows = db.insertCompanyBill(billno: b.billNo, date: b.date, amount: Int32.Parse(b.amount), imagePath: b.imagePath, particular: b.particular,
                type: b.type, companyName: pc.companyName, projectName: p.name, projectPlotNo: p.plotNo);
            if (noOfRows < 1)
            {
                MessageBox.Show("Unable to add new Bill. Maybe already added!");
            }
        }

        public void addNewWorkerBill(Project p, Project.Worker pw)
        {
            _log.Info("addNewWorkerBill started");
            int lastind = pw.bills.Count - 1;
            _log.Info($"project bill count: {pw.bills.Count}");
            Project.Bill b = pw.bills[lastind];
            if (DateTime.Parse(b.date) > DateTime.Now)
            {
                _log.Info("Future Date Cannot be Entered");
                throw new Exception("Future Date Cannot be Entered");
            }
            int noOfRows = db.insertWorkerBill(billno: b.billNo, date: b.date, amount: Int32.Parse(b.amount), imagePath: b.imagePath, particular: b.particular,
                type: b.type, personName: pw.personName, projectName: p.name, projectPlotNo: p.plotNo);
            if (noOfRows < 1)
            {
                _log.Info($"Unable to add new Bill. Maybe already added! - noOfRows: {noOfRows}");
                MessageBox.Show("Unable to add new Bill. Maybe already added!");
            }
        }
        public void addNewRecievePayment(Project p)
        {
            int lastind = p.payments.Count - 1;
            Project.Payment pc = p.payments[lastind];
            if (DateTime.Parse(pc.date) > DateTime.Now)
            {
                Console.WriteLine("Future Date Cannot be Entered");
                return;
            }
            int noOfRows = db.insertRecievePayment(Int16.Parse(pc.serialNo), pc.date, Int32.Parse(pc.amount), pc.description, p.plotNo, p.name);
            if (noOfRows < 1)
            {
                MessageBox.Show("Unable to add new Payment. Maybe already added!");
            }
        }
        public void addNewProject(Project p)
        {
            p.contactNo = setContactNo(p.contactNo);
            int noOfRows = db.insertProject(plotno: p.plotNo, name: p.name, contactno: p.contactNo, status: p.status, date: p.date);
            
            if (noOfRows < 1)
            {
                MessageBox.Show("Unable to add new Project. Maybe already added!");
            }
        }
        public void addNewCompany(Project p)
        {
            int lastind = p.companies.Count - 1;
            Project.Company pc = p.companies[lastind];
            pc.contactNo = setContactNo(pc.contactNo);

            int noOfRows = db.insertCompany(companyName: pc.companyName, personName: pc.personName, contactNo: pc.contactNo, type: pc.type, shopAddress: pc.shopAddress, projectPlotNo: p.plotNo, projectName: p.name);
            if (noOfRows < 1)
            {
                MessageBox.Show("Unable to add new Company. Maybe already added!");
            }
        }

        public void addNewWorker(Project p)
        {
            int lastind = p.workers.Count - 1;
            Project.Worker pw = p.workers[lastind];
            pw.contactNo = setContactNo(pw.contactNo);

            int noOfRows = db.insertWorker(contactno: pw.contactNo, personname: pw.personName, cnic: pw.CNIC, email: pw.email, typeofwork: pw.typeOfWork, projectPlotNo: p.plotNo, projectName: p.name);
            if (noOfRows < 1)
            {
                MessageBox.Show("Unable to add new Worker. Maybe already added!");
            }
        }
        // GETTER

        public DataTable getSummaryTable(Project p)
        {
            DataTable dt = new DataTable();
            //DataTable dt1 = new DataTable();
            if(p != null)
            {
                dt = db.getSummary(projectName: p.name, plotno: p.plotNo);


                dt.Columns.Add("S.No", typeof(long));
                //dt1.Columns.Add("Name", typeof(System.String));
                //dt1.Columns.Add("Worker/Company", typeof(System.String));
                //dt1.Columns.Add("Amount", typeof(System.Int64));

                double tot = 0;
                int i = 0;
                foreach (DataRow row in dt.Rows)
                {
                    row["S.No"] = ++i;
                    tot += long.Parse(row["amount"].ToString());
                }

                /// set order first

                dt.Columns["S.No"].SetOrdinal(0);
                dt.Columns["Name"].SetOrdinal(1);
                dt.Columns["company_worker"].SetOrdinal(2);
                dt.Columns["Amount"].SetOrdinal(3);

                /// now add new rows

                dt.Rows.Add(null, "", "SUB TOTAL", tot);
                DataTable dt2 = db.getRecievePayment_table(plotno: p.plotNo, name: p.name);

                double recieve_tot = 0;
                foreach (DataRow row in dt2.Rows)
                {
                    recieve_tot += int.Parse(row["AMOUNT"].ToString());
                }

                double grand_total = recieve_tot - tot;
                //Console.WriteLine("grand: " + grand_total + " :: recieve_tot: " + recieve_tot + " :: tot: " + tot);
                dt.Rows.Add(null, "Total Recieved", "", recieve_tot);
                dt.Rows.Add(null, "", "TOTAL", grand_total);
            }

            return dt;
        }

        public DataTable getMainTable(Project p, string fromdate = "2000-01-01", string todate = "now")
        {
            DataTable dt;
            if (fromdate.Trim().Length > 0 && todate.Trim().Length > 0)
            {
                dt = db.getTransactions(name: p.name, plotno: p.plotNo, fromdate: fromdate, todate: todate);
            }
            else
            {
                dt = db.getTransactions(name: p.name, plotno: p.plotNo);
            }

            dt.Columns.Add("BALANCE", typeof(System.Int64));
            dt.Columns.Add("NAAM", typeof(System.Int64));
            dt.Columns.Add("RECIEVED AMOUNT", typeof(System.Int64));

            //MessageBox.Show("Date: " + fromdate);
            DateTime v_date = DateTime.Parse(fromdate);
            v_date = v_date.AddDays(-1);
            //MessageBox.Show("Date__ " + fromdate);

            string st_day = v_date.Day.ToString();
            if (st_day.Length < 2)
            {
                st_day = st_day.Insert(0, "0");
            }
            string st_month = v_date.Month.ToString();
            if (st_month.Length < 2)
            {
                st_month = st_month.Insert(0, "0");
            }
            string _fromdate = v_date.Year + "-" + st_month + "-" + st_day;
            double openingbal = getOpeningBalance(name: p.name, plotno: p.plotNo, todate: _fromdate);
            //MessageBox.Show("Opening Bal: " + openingbal);
            DataRow r;
            r = dt.NewRow();
            r["PARTICULARS"] = "Opening Balance";
            r["BALANCE"] = openingbal;
            dt.Rows.InsertAt(r, 0);


            double tot = openingbal;
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {   if(i == 0)
                {
                    i++;
                    continue;
                }
                i++;
                string date= row["DATE"].ToString();
                DateTime date2 = DateTime.Parse(date); ;
                row["DATE"] = date2.ToString("dd-MM-yyyy");

                string particular = row["PARTICULARS"].ToString();
                //if (particular.Length >= 35)
                //{
                //    row["PARTICULARS"] = particular.Substring(0, 34) + "....";
                //}


                string type = row["BILL_TYPE"].ToString();
                if (type.ToUpper() == "NAAM")
                {
                    tot -= Int32.Parse(row["AMOUNT"].ToString());
                    row["NAAM"] = row["AMOUNT"];
                    //Console.WriteLine("**NAAM: " + row["NAAM"]);
                }
                else
                {
                    row["RECIEVED AMOUNT"] = row["AMOUNT"];
                    tot += Int32.Parse(row["AMOUNT"].ToString());
                }
                row["BALANCE"] = tot;
            }

            dt.Columns.Remove("BILL_TYPE");
            dt.Columns.Remove("rowid");
            dt.Columns.Remove("AMOUNT");
            dt.Columns.Remove("Priority");
            dt.Columns["NAAM"].SetOrdinal(3);
            dt.Columns["RECIEVED AMOUNT"].SetOrdinal(4);

            string naamtot = getSumCol(dt, "NAAM");
            string recievetot = getSumCol(dt, "RECIEVED AMOUNT");

            dt.Rows.Add("", "", "TOTAL", Int64.Parse(naamtot), Int64.Parse(recievetot), tot);

            

            return dt;
        }

        private double getOpeningBalance(string name , string plotno, string fromdate = "2000-01-01", string todate = "now")
        {
            
            DataTable dt = db.getTransactions(name, plotno, fromdate, todate);
            int lastRow = -1;
            lastRow = dt.Rows.Count - 1;
            double tot = 0;
            foreach (DataRow row in dt.Rows)
            {
             
                string type = row["BILL_TYPE"].ToString();
                if (type.ToUpper() == "NAAM")
                {
                    tot -= Int32.Parse(row["AMOUNT"].ToString());
                }
                else
                {
                    tot += Int32.Parse(row["AMOUNT"].ToString());
                }
            }
            //MessageBox.Show("date: " + todate + "\n tot: " + tot);
            return tot;
        }

        public double totalBalance(Project p, bool onlyPayments, DataTable dt = null ,string fromdate = "2000-01-01", string todate = "now")
        {
            //int lastRow = -1;
            //if (onlyPayments)
            //{
            //    dt = getAllRecievedPayments(p);
            //}
            //else
            //{
            //    dt = getMainTable(p, fromdate: fromdate, todate: todate);
            //}
            //lastRow = dt.Rows.Count - 1;

            //double bal = 0;

            //if (lastRow >= 0)
            //{
            //    //bal = Int64.Parse(dt.Rows[lastRow]["BALANCE"].ToString());
            //}
            ////Console.WriteLine("lineNo: 184, lastRow: " + lastRow);
            ////Console.WriteLine("lineNo: 185, bal: " + bal + ", "+dt.Rows[lastRow]["BALANCE"].ToString());
            //return bal;
            return 0;
        }

        public DataTable getCompanyBills(Project p, Project.Company c, string fromdate = "2000-01-01", string toDate = "now")
        {
            DataTable dt;
            if (fromdate.Trim().Length < 0 && toDate.Trim().Length < 0)
            {
                dt = db.getCompanyBill_table(plotno: p.plotNo, name: p.name, companyName: c.companyName);
            }
            else
            {
                dt = db.getCompanyBill_table(plotno: p.plotNo, name: p.name, companyName: c.companyName, fromdate: fromdate, todate: toDate);
            }
            dt = setBillTable(dt);
            return FormatBillDataTable(dt);

        }
        public DataTable getWorkerBills(Project p, Project.Worker w, string fromdate = "2000-01-01", string toDate = "now")
        {
            DataTable dt;

            dt = db.getWorkerBill_table(plotno: p.plotNo, name: p.name, personName: w.personName, fromdate: fromdate, todate: toDate);
            dt = setBillTable(dt);

            return FormatBillDataTable(dt);
        }


        private DataTable FormatBillDataTable(DataTable dt) 
        {
            foreach (DataRow row in dt.Rows)
            {
                string date = row["DATE"].ToString();
                if (!string.IsNullOrEmpty(date))
                {
                    DateTime date2 = DateTime.Parse(date);
                    row["DATE"] = date2.ToString("dd-MM-yyyy");
                }
            }

            return dt;
        }
        
        private DataTable setBillTable(DataTable dt)
        {
            dt.Columns.Add("BALANCE", typeof(System.Int64));
            dt.Columns.Add("NAAM", typeof(System.Int64));
            dt.Columns.Add("JAMA", typeof(System.Int64));
            int tot = 0;
            foreach (DataRow row in dt.Rows)
            {
                string type = row["TYPE"].ToString();
                if (type.ToUpper() == "NAAM")
                {
                    tot -= Int32.Parse(row["AMOUNT"].ToString());
                    row["NAAM"] = row["AMOUNT"];
                }
                else
                {
                    row["JAMA"] = row["AMOUNT"];
                    tot += Int32.Parse(row["AMOUNT"].ToString());
                }
                row["BALANCE"] = tot;
            }

            dt.Columns["BILLNO"].SetOrdinal(0);
            dt.Columns["DATE"].SetOrdinal(1);
            dt.Columns["PARTICULAR"].SetOrdinal(2);
            dt.Columns["NAAM"].SetOrdinal(3);
            dt.Columns["JAMA"].SetOrdinal(4);
            dt.Columns["BALANCE"].SetOrdinal(5);
            string totNaam = getSumCol(dt, "NAAM");
            string totJama = getSumCol(dt, "JAMA");
            dt.Rows.Add("TOTAL", "", "", Int64.Parse(totNaam), Int64.Parse(totJama), null);
            return dt;
        }

        public string getSumCol(DataTable dt, string colName)
        {
            double total = 0;
            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (Int64.TryParse(row[colName].ToString(), out long num))
                        total += num;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return total.ToString();
        }

        public DataTable getAllProjects()
        {
            DataTable dt = db.getProject_table();
            foreach (DataRow row in dt.Rows)
            {
                row["contactno"] = getContactNo(row["contactno"].ToString());
            }
            return dt;
        }

        public DataTable getAllCompanies(Project p)
        {
            DataTable dt = db.getCompany_table(plotno: p.plotNo, name: p.name);
            foreach (DataRow row in dt.Rows)
            {
                row["contactno"] = getContactNo(row["contactno"].ToString());
            }
            return dt;
        }
        public DataTable getAllWorker(Project p)
        {
            DataTable dt = db.getWorker_table(plotno: p.plotNo, name: p.name);
            foreach (DataRow row in dt.Rows)
            {
                row["contactno"] = getContactNo(row["contactno"].ToString());
            }
            return dt;
        }
        public DataTable getAllRecievedPayments(Project p, string fromdate = "2000-01-01", string todate = "now")
        {
            DataTable dt = db.getRecievePayment_table(plotno: p.plotNo, name: p.name, fromdate: fromdate, todate: todate);

            dt.Columns.Add("BALANCE", typeof(System.Int64));
            int tot = 0;
            foreach (DataRow row in dt.Rows)
            {
                string date = row["DATE"].ToString();
                DateTime date2 = DateTime.Parse(date); ;
                row["DATE"] = date2.ToString("dd-MM-yyyy");

                //string particular = row["PAYMENT_DESCRIPTION"].ToString();
                //if (particular.Length >= 35)
                //{
                //    row["PAYMENT_DESCRIPTION"] = particular.Substring(0, 34) + "....";
                //}


                tot += Int32.Parse(row["AMOUNT"].ToString());
                row["BALANCE"] = tot;
            }
            dt.Columns.Remove("PROJECTPLOTNO");
            dt.Columns.Remove("PROJECTNAME");
            dt.Columns["SNO"].SetOrdinal(0);
            dt.Columns["AMOUNT"].SetOrdinal(3);
            return dt;
        }
        public DataTable getAllRecievedPayments2(Project p, string fromdate = "2000-01-01", string todate = "now")
        {
            DataTable dt = db.getRecievePayment_table(plotno: p.plotNo, name: p.name, fromdate: fromdate, todate: todate);

            dt.Columns.Add("BALANCE", typeof(System.Int64));
            int tot = 0;
            foreach (DataRow row in dt.Rows)
            {
                string date = row["DATE"].ToString();
                DateTime date2 = DateTime.Parse(date); ;
                row["DATE"] = date2.ToString("dd-MM-yyyy");
                
                tot += Int32.Parse(row["AMOUNT"].ToString());
                row["BALANCE"] = tot;
            }
            dt.Columns.Remove("PROJECTPLOTNO");
            dt.Columns.Remove("PROJECTNAME");
            dt.Columns["SNO"].SetOrdinal(0);
            dt.Columns["AMOUNT"].SetOrdinal(3);
            return dt;
        }

        // DELETE
        public void deleteProject(Project p)
        {
            deleteAllWorker(p);
            deleteAllCompanies(p);
            db.deleteProject(plotNo: p.plotNo, name: p.name);
        }
        public void deleteAllCompanies(Project p)
        {
            db.deleteComapanies(plotno: p.plotNo, projectName: p.name);
        }
        public void deleteAllWorker(Project p)
        {
            db.deleteWorkers(plotno: p.plotNo, projectName: p.name);
        }
        public void deleteCompany(Project p, Project.Company pc)
        {
            db.deleteCompany(comapanyName: pc.companyName, plotno: p.plotNo, projectName: p.name);
        }
        public void deleteWorker(Project p, Project.Worker pw)
        {
            db.deleteWorker(personName: pw.personName, plotno: p.plotNo, projectName: p.name);
        }
        public void deleteWorkerBill(Project p, Project.Worker pw, Project.Bill b)
        {
            db.deleteWorkerBill(billNo: b.billNo, personName: pw.personName, plotno: p.plotNo, projectName: p.name, rowid: Int64.Parse(b.rowid));
        }
        public void deleteCompanyBill(Project p, Project.Company pc, Project.Bill b)
        {
            db.deleteCompanyBill(billNo: b.billNo, companyName: pc.companyName, plotno: p.plotNo, projectName: p.name, rowid: Int64.Parse(b.rowid));
        }
        public void deleteWorkerBills(Project p, Project.Worker pw)
        {
            db.deleteWorkerBills(personName: pw.personName, plotno: p.plotNo, projectName: p.name);
        }
        public void deleteCompanyBills(Project p, Project.Company pc)
        {
            db.deleteCompanyBills(companyName: pc.companyName, plotno: p.plotNo, projectName: p.name);
        }
        public void deleteRecievePayment(Project p, Project.Payment payment)
        {
            db.deleteRecievePayment(sno: payment.serialNo, plotno: p.plotNo, projectName: p.name);
        }
        // UPDATE
        public void updateProject(Project old_project, Project new_project)
        {
            updateWorkers(old_project: old_project, new_project: new_project);
            updateCompanies(old_project: old_project, new_project: new_project);
            db.updateRecievedPayments(old_plotno: old_project.plotNo, old_projectName: old_project.name, plotno: new_project.plotNo, projectName: new_project.name);

            new_project.contactNo = setContactNo(new_project.contactNo);
            db.updateProject(old_name: old_project.name, old_plotno: old_project.plotNo, plotno: new_project.plotNo, date: new_project.date,
                name: new_project.name, contactno: new_project.contactNo, status: new_project.status);
        }
        public void updateCompany(Project p, Project.Company old_company, Project.Company new_Company, Project old_p)
        {
            new_Company.contactNo = setContactNo(new_Company.contactNo);
            db.updateCompanyBills(old_compnanyName: old_company.companyName, old_plotno: old_p.plotNo, old_projectName: old_p.name,
                compnanyName: new_Company.companyName, plotno: p.plotNo, projectName: p.name);

            db.updateCompany(old_companyName: old_company.companyName, old_plotno: old_p.plotNo, old_projectName: old_p.name, plotno: p.plotNo, projectName: p.name,
                companyName: new_Company.companyName, contactno: new_Company.contactNo, shopAddress: new_Company.shopAddress, typeofwork: new_Company.type, personName: new_Company.personName);
        }
        public void updateCompanies(Project old_project, Project new_project)
        {

            DataTable dt = getAllCompanies(old_project);
            Project.Company old_company = new Project.Company();
            foreach (DataRow row in dt.Rows)
            {
                old_company.companyName = row["COMPANYNAME"].ToString();
                db.updateCompanyBills(old_compnanyName: old_company.companyName, old_plotno: old_project.plotNo, old_projectName: old_project.name,
                    compnanyName: old_company.companyName, plotno: new_project.plotNo, projectName: new_project.name);
            }
            db.updateCompanies(old_plotno: old_project.plotNo, old_projectName: old_project.name, plotno: new_project.plotNo, projectName: new_project.name);
        }
        public void updateWorkers(Project old_project, Project new_project)
        {
            DataTable dt = getAllWorker(old_project);
            Project.Worker old_worker = new Project.Worker();
            foreach (DataRow row in dt.Rows)
            {
                old_worker.personName = row["PERSONNAME"].ToString();
                db.updateWorkerBills(old_personName: old_worker.personName, old_plotno: old_project.plotNo, old_projectName: old_project.name,
                    personName: old_worker.personName, plotno: new_project.plotNo, projectName: new_project.name);
            }
            db.updateWorkers(old_plotno: old_project.plotNo, old_projectName: old_project.name, plotno: new_project.plotNo, projectName: new_project.name);
        }
        public void updateWorker(Project p, Project.Worker old_worker, Project.Worker new_worker, Project old_p)
        {
            new_worker.contactNo = setContactNo(new_worker.contactNo);

            db.updateWorkerBills(old_personName: old_worker.personName, old_plotno: old_p.plotNo, old_projectName: old_p.name,
                personName: new_worker.personName, plotno: p.plotNo, projectName: p.name);
            db.updateWorker(old_personName: old_worker.personName, old_plotno: old_p.plotNo, old_projectName: old_p.name, plotno: p.plotNo, projectName: p.name,
                cnic: new_worker.CNIC, contactno: new_worker.contactNo, email: new_worker.email, typeofwork: new_worker.typeOfWork, personName: new_worker.personName);
        }
        public void updateRecievedPayment(Project p, Project.Payment payment)
        {
            if (DateTime.Parse(payment.date) > DateTime.Now)
            {
                Console.WriteLine("Future Date Cannot be Entered");
                return;
            }
            db.updateRecievedPayment(sno: Int16.Parse(payment.serialNo), old_plotno: p.plotNo, old_projectName: p.name,
                date: payment.date, paymentDesc: payment.description, amount: Int32.Parse(payment.amount));
        }
        public void updateWorkerBill(Project p, Project.Worker pw, Project.Bill b)
        {
            if (DateTime.Parse(b.date) > DateTime.Now)
            {
                Console.WriteLine("Future Date Cannot be Entered");
                return;
            }
            db.updateWorkerBill(personName: pw.personName, billNo: b.billNo, plotno: p.plotNo, projectName: p.name,
                date: b.date, amount: Int32.Parse(b.amount), type: b.type, particular: b.particular, imagePath: b.imagePath, rowid: Int64.Parse(b.rowid));
        }
        public void updateComapnyBill(Project p, Project.Company pc, Project.Bill b)
        {
            if (DateTime.Parse(b.date) > DateTime.Now)
            {
                Console.WriteLine("Future Date Cannot be Entered");
                return;
            }
            db.updateCompanyBill(compnanyName: pc.companyName, billNo: b.billNo, plotno: p.plotNo, projectName: p.name,
                date: b.date, amount: Int32.Parse(b.amount), type: b.type, particular: b.particular, 
                imagePath: b.imagePath, rowid: Int64.Parse(b.rowid));
        }
        // EXTRAS
        public string getFilename(string file)
        {
            int ind_extDot = file.LastIndexOf('.');
            string filename = file.Substring(0, ind_extDot);
            return filename;
        }

        public string getExtension(string file)
        {
            int ind_extDot = file.LastIndexOf('.');
            string ext = file.Substring(ind_extDot);
            return ext;
        }
        public string setContactNo(string contactNo)
        {
            if (contactNo.Length > 0 && contactNo[0].Equals('0'))
            {
                string contact = contactNo.Remove(0, 1);
                contact = "+92 " + contact;
                contactNo = contact;
            }
            return contactNo;
        }

        public string getContactNo(string contactNo)
        {

            if (contactNo.Length > 0 && contactNo[0].Equals('+'))
            {
                string contact = contactNo.Remove(0, 4);
                contact = "0" + contact;
                return contact;
            }
            return contactNo;
        }
    }
}
