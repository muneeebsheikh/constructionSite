using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace constructionSite.Controller
{
    public enum Vendor
    {
        Company,
        Worker
    }
    public class Project
    {
        public Project()
        {
            workers = new List<Worker>();
            payments = new List<Payment>();
            companies = new List<Company>();
        }

        public string plotNo { get; set; }
        public string date { get; set; }
        public string name { get; set; }
        public string contactNo { get; set; }
        public string status { get; set; }
        public List<Worker> workers { get; set; }
        public List<Company> companies { get; set; }
        public List<Payment> payments { get; set; }

        public class Payment
        {
            public string serialNo { get; set; }
            public string date { get; set; }
            public string amount { get; set; }
            public string description { get; set; }
        }


        public class Worker
        {

            public Worker()
            {
                bills = new List<Bill>();
            }

            public string personName { get; set; }
            public string contactNo { get; set; }
            public string CNIC { get; set; }
            public string email { get; set; }
            public string typeOfWork { get; set; }

            public List<Bill> bills { get; set; }



        }

        public class Company
        {
            public Company()
            {
                bills = new List<Bill>();
            }
            public string companyName { get; set; }
            public string shopAddress { get; set; }
            public string contactNo { get; set; }
            public string personName { get; set; }
            public string type { get; set; }

            public List<Bill> bills { get; set; }



        }


        public class Bill
        {
            public string rowid { get; set; }
            public string date { get; set; }
            public string billNo { get; set; }
            public string amount { get; set; }
            public string type { get; set; }
            public string particular { get; set; }
            public string imagePath { get; set; }
        }

    }
}

