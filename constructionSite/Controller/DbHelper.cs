using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace constructionSite.Controller
{

    class DbHelper
    {
        //https://www.sqlitetutorial.net/tryit/query/sqlite-date/#2
        /// <summary>
        /// how to handle date check from above link (use real dataType for date)
        /// </summary>

        private const string DB_NAME = "db.db3";
        private const string PROJECT_TABLE = @"CREATE TABLE IF NOT EXISTS
                                    [PROJECT] (
                                    [PLOTNO] STRING NOT NULL,
                                    [DATE] REAL ,
                                    [NAME] STRING NOT NULL,
                                    [CONTACTNO] STRING,
                                    [STATUS] STRING,
                                    UNIQUE (PLOTNO, NAME),
                                    CONSTRAINT PK_PROJECT PRIMARY KEY (PLOTNO, NAME) )";

        private const string WORKER_TABLE = @"CREATE TABLE IF NOT EXISTS
                                    [WORKER] (
                                    [PERSONNAME] STRING ,
                                    [CONTACTNO] STRING ,
                                    [CNIC] STRING ,
                                    [EMAIL] STRING,
                                    [TYPEOFWORK] STRING,
                                    [PROJECTPLOTNO] STRING NOT NULL REFERENCES PROJECT(PLOTNO) ON DELETE SET NULL ON UPDATE CASCADE,
                                    [PROJECTNAME] STRING NOT NULL REFERENCES PROJECT(NAME) ON DELETE SET NULL ON UPDATE CASCADE,
                                    CONSTRAINT PK_WORKER PRIMARY KEY (PERSONNAME, PROJECTPLOTNO, PROJECTNAME)
                                    )";
        private const string COMPANY_TABLE = @"CREATE TABLE IF NOT EXISTS
                                    [COMPANY] (
                                    [COMPANYNAME] STRING ,
                                    [PERSONNAME] STRING ,
                                    [CONTACTNO] STRING ,
                                    [TYPE] STRING ,
                                    [SHOPADDRESS] STRING,
                                    [PROJECTPLOTNO] STRING NOT NULL REFERENCES PROJECT(PLOTNO) ON DELETE SET NULL ON UPDATE CASCADE,
                                    [PROJECTNAME] STRING NOT NULL REFERENCES PROJECT(NAME) ON DELETE SET NULL ON UPDATE CASCADE,
                                    CONSTRAINT PK_COMPANY PRIMARY KEY (COMPANYNAME, PROJECTPLOTNO, PROJECTNAME)
                                    )";
        private const string RECIEVEPAYMENT_TABLE = @"CREATE TABLE IF NOT EXISTS
                                    [RECIEVEPAYMENT] (
                                    [SNO] INTEGER ,
                                    [DATE] REAL ,
                                    [AMOUNT] REAL ,
                                    [PAYMENT_DESCRIPTION] CHAR(50) ,
                                    [PROJECTPLOTNO] STRING NOT NULL REFERENCES PROJECT(PLOTNO) ON DELETE SET NULL ON UPDATE CASCADE,
                                    [PROJECTNAME] STRING NOT NULL REFERENCES PROJECT(NAME) ON DELETE SET NULL ON UPDATE CASCADE,
                                    CONSTRAINT PK_RECIEVEPAYMENT PRIMARY KEY (SNO, PROJECTPLOTNO, PROJECTNAME)
                                    )";
        private const string WORKERBILL_TABLE = @"CREATE TABLE IF NOT EXISTS
                                    [WORKERBILL] (
                                    [BILLNO] STRING ,
                                    [DATE] REAL ,
                                    [AMOUNT] REAL ,
                                    [TYPE] CHAR(50) ,
                                    [PARTICULAR] CHAR(50) ,
                                    [IMAGEPATH] STRING ,
                                    [PERSONNAME] STRING NOT NULL REFERENCES WORKER(PERSONNAME) ON DELETE SET NULL ON UPDATE CASCADE,
                                    [PROJECTPLOTNO] STRING NOT NULL REFERENCES PROJECT(PLOTNO) ON DELETE SET NULL ON UPDATE CASCADE,
                                    [PROJECTNAME] STRING NOT NULL REFERENCES PROJECT(NAME) ON DELETE SET NULL ON UPDATE CASCADE
                                    )";
        private const string COMPANYBILL_TABLE = @"CREATE TABLE IF NOT EXISTS
                                    [COMPANYBILL] (
                                    [BILLNO] STRING ,
                                    [DATE] REAL ,
                                    [AMOUNT] REAL ,
                                    [TYPE] CHAR(50) ,
                                    [PARTICULAR] CHAR(50) ,
                                    [IMAGEPATH] STRING ,
                                    [COMPANYNAME] STRING NOT NULL REFERENCES COMPANY(COMPANYNAME) ON DELETE SET NULL ON UPDATE CASCADE,
                                    [PROJECTPLOTNO] STRING NOT NULL REFERENCES PROJECT(PLOTNO) ON DELETE SET NULL ON UPDATE CASCADE,
                                    [PROJECTNAME] STRING NOT NULL REFERENCES PROJECT(NAME) ON DELETE SET NULL ON UPDATE CASCADE
                                    )";

        private SQLiteConnection conn;
        private static DbHelper obj;
        private static Logger.Logger _log = new Logger.Logger("DBHelper");
        private DbHelper()
        {
            initDB();
        }

        public static DbHelper getInstance()
        {
            if (obj == null)
            {
                obj = new DbHelper();
            }
            return obj;
        }
        private void createTables()
        {
            using (SQLiteCommand cmd = new SQLiteCommand(conn))
            {
                cmd.CommandText = PROJECT_TABLE;
                cmd.ExecuteNonQuery();
                cmd.CommandText = RECIEVEPAYMENT_TABLE;
                cmd.ExecuteNonQuery();

                cmd.CommandText = WORKER_TABLE;
                cmd.ExecuteNonQuery();
                cmd.CommandText = COMPANY_TABLE;
                cmd.ExecuteNonQuery();
                cmd.CommandText = COMPANYBILL_TABLE;
                cmd.ExecuteNonQuery();
                cmd.CommandText = WORKERBILL_TABLE;
                cmd.ExecuteNonQuery();
            }

        }

        private void initDB()
        {
            createDBFile();
            using (conn = new SQLiteConnection("data source = " + DB_NAME))
            {
                conn.Open();
                createTables();
                conn.Close();
            }
        }
        private void createDBFile()
        {
            if (!File.Exists(DB_NAME))
            {
                SQLiteConnection.CreateFile(DB_NAME);
            }
        }

        /// <summary>
        /// DO NOT ALTER THE FUNCTIONS ABOVE
        /// Add all the CRUD functions below
        /// </summary>

        public int insertCompanyBill(string billno, string date, int amount, string particular, string imagePath, string type, string companyName, string projectPlotNo, string projectName)
        {
            int n = 0;
            try
            {
                using (conn = new SQLiteConnection("data source = " + DB_NAME))
                {
                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        conn.Open();
                        cmd.CommandText = "INSERT INTO COMPANYBILL VALUES('" + billno + "', julianday('" + date + "'), "
                            + amount + ", '" + type + "', '" + particular + "','" + imagePath + "','" + companyName + "', '" + projectPlotNo + "'," +
                            "'" + projectName + "')";
                        n = cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex, "insertCompanyBill");
            }
            return n;
        }
        public int insertWorkerBill(string billno, string date, int amount, string particular, string imagePath, string type, string personName, string projectPlotNo, string projectName)
        {
            _log.Info($"insertWorkerBill started - billno: {billno}");
            int n = 0;
            try
            {
                using (conn = new SQLiteConnection("data source = " + DB_NAME))
                {
                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        conn.Open();
                        var q = $@"INSERT INTO WORKERBILL VALUES('{billno}', julianday('{date}'), {amount}, '{type}', '{particular}', '{imagePath}', '{personName}', '{projectPlotNo}', '{projectName}')";
                        _log.Debug(q);
                        cmd.CommandText = q;
                        n = cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex, "insertWorkerBill");
            }
            finally
            {
                _log.Info($"insertWorkerBill ended - billno: {billno}");
            }
            return n;
        }

        public int insertRecievePayment(int sno, string date, int amount, string payment_desc, string projectPlotNo, string projectName)
        {
            int n = 0;
            try
            {
                using (conn = new SQLiteConnection("data source = " + DB_NAME))
                {
                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        conn.Open();
                        cmd.CommandText = "INSERT INTO RECIEVEPAYMENT VALUES(" + sno + ", julianday('" + date + "'), "
                            + amount + ", '" + payment_desc + "', '" + projectPlotNo + "'," +
                            "'" + projectName + "')";
                        n = cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex, "insertRecievePayment");
            }
            return n;
        }

        public int insertCompany(string companyName, string personName, string contactNo, string type, string shopAddress, string projectPlotNo, string projectName)
        {
            int n = 0;
            try
            {
                using (conn = new SQLiteConnection("data source = " + DB_NAME))
                {
                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        conn.Open();
                        cmd.CommandText = "INSERT INTO COMPANY VALUES('" + companyName + "', '" + personName + "', '" + contactNo + "', '" + type + "', '" + shopAddress + "', '" + projectPlotNo + "'," +
                            "'" + projectName + "')";
                        n = cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                _log.Error(ex, "insertCompany");
            }
            return n;
        }

        public int insertWorker(string personname, string contactno, string cnic, string email, string typeofwork, string projectPlotNo, string projectName)
        {
            int n = 0;
            try
            {
                using (conn = new SQLiteConnection("data source = " + DB_NAME))
                {
                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        conn.Open();
                        cmd.CommandText = "INSERT INTO WORKER VALUES('" + personname + "', '" + contactno + "', '" + cnic + "', '" + email + "', '" + typeofwork + "', '" + projectPlotNo + "'," +
                            "'" + projectName + "')";
                        n = cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                _log.Error(ex, "insertWorker");
            }
            return n;
        }

        public string getSno_RecievePayment(string plotNo, string projectName)
        {
            string sno = "";

            using (conn = new SQLiteConnection("data source = " + DB_NAME))
            {
                conn.Open();
                var sqliteAdapter = new SQLiteDataAdapter("", conn);
                using (SQLiteCommand fmd = conn.CreateCommand())
                {
                    fmd.CommandText = @"SELECT IFNULL(MAX(SNO), 0)+1 sno FROM RECIEVEPAYMENT where PROJECTPLOTNO = '" + plotNo
                        + "' and PROJECTNAME = '" + projectName + "'";
                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader r = fmd.ExecuteReader();
                    while (r.Read())
                    {
                        sno = (Convert.ToString(r["sno"]));
                    }
                }
                conn.Close();
            }

            return sno;

        }

        public DataTable getTransactions(string name, string plotno, string fromdate = "2000-01-01", string todate = "now")
        {
            DataTable table = new DataTable();
            using (conn = new SQLiteConnection("data source = " + DB_NAME))
            {
                conn.Open();
                var sqliteAdapter = new SQLiteDataAdapter("" +
                    "select rowid,date(DATE) DATE, 'Recieved Payment' as NAME, PAYMENT_DESCRIPTION PARTICULARS, AMOUNT, null BILL_TYPE " +
                    ",0 as Priority from RECIEVEPAYMENT" +
                    " where PROJECTNAME = '" + name + "' and PROJECTPLOTNO = '" + plotno + "' and date between julianday('" + fromdate + "') and julianday('" + todate + "') + 0.5 " +
                    " UNION" +
                    " select rowid,date(DATE) DATE , PERSONNAME, PARTICULAR ,amount, type" +
                    ",1 as Priority from WORKERBILL" +
                    " where TYPE = 'Naam' AND PROJECTNAME = '" + name + "' and PROJECTPLOTNO = '" + plotno + "' and date between julianday('" + fromdate + "') and julianday('" + todate + "') + 0.5 " +
                    " UNION" +
                    " select rowid,date(DATE) DATE, COMPANYNAME, PARTICULAR ,amount, type" +
                    ",1 as Priority from COMPANYBILL" +
                    " where TYPE = 'Naam' AND PROJECTNAME = '" + name + "' and PROJECTPLOTNO = '" + plotno + "' and date between julianday('" + fromdate + "') and julianday('" + todate + "') + 0.5 " +
                    " order by DATE, Priority", conn);
                var cmdBuilder = new SQLiteCommandBuilder(sqliteAdapter);
                sqliteAdapter.Fill(table);
                sqliteAdapter.Update(table);
                conn.Close();
            }
            return table;
        }

        public DataTable getSummary(string projectName, string plotno)
        {
            DataTable table = new DataTable();
            using (conn = new SQLiteConnection("data source = " + DB_NAME))
            {
                conn.Open();
                var sqliteAdapter = new SQLiteDataAdapter("" +
                    "select  personname as name, 'worker' as company_worker, sum(amount) as amount" +
                    " from workerbill" +
                    " where projectname = '" + projectName + "'" +
                    " and projectplotno = '" + plotno + "'" +
                    " and type = 'Naam'" +
                    " and date between julianday('2000-01-01') and julianday('now') + 0.5" +
                    " group by personname" +
                    " union" +
                    " select companyname, 'company' , sum(amount)" +
                    " from companybill" +
                    " where projectname = '" + projectName + "'" +
                    " and projectplotno = '" + plotno + "'" +
                    " and type = 'Naam'" +
                    " and date between julianday('2000-01-01') and julianday('now') + 0.5" +
                    " group by companyname" +
                    " order by name", conn);
                var cmdBuilder = new SQLiteCommandBuilder(sqliteAdapter);
                sqliteAdapter.Fill(table);
                sqliteAdapter.Update(table);
                conn.Close();
            }
            return table;
        }



        public DataTable getRecievePayment_table(string plotno, string name, string fromdate = "2000-01-01", string todate = "now")
        {
            DataTable table = new DataTable();
            using (conn = new SQLiteConnection("data source = " + DB_NAME))
            {
                conn.Open();
                var sqliteAdapter = new SQLiteDataAdapter("SELECT SNO, date(DATE) DATE, AMOUNT, PAYMENT_DESCRIPTION, PROJECTPLOTNO, PROJECTNAME  " +
                    "FROM RECIEVEPAYMENT " +
                    "WHERE PROJECTPLOTNO = '" + plotno +
                    "' AND PROJECTNAME = '" + name + "' AND  DATE BETWEEN julianday('" + fromdate + "') AND julianday('" + todate + "') + 0.5" +
                    " ORDER BY DATE", conn);
                var cmdBuilder = new SQLiteCommandBuilder(sqliteAdapter);
                sqliteAdapter.Fill(table);
                sqliteAdapter.Update(table);
                conn.Close();
            }
            return table;
        }


        public DataTable getCompanyBill_table(string plotno, string name, string companyName, string fromdate = "2000-01-01", string todate = "now")
        {
            DataTable table = new DataTable();
            using (conn = new SQLiteConnection("data source = " + DB_NAME))
            {
                conn.Open();
                var sqliteAdapter = new SQLiteDataAdapter("SELECT rowid, BILLNO, date(DATE) DATE, AMOUNT, TYPE, PARTICULAR," +
                    "IMAGEPATH  " +
                    "FROM COMPANYBILL " +
                    "WHERE PROJECTPLOTNO = '" + plotno + "' AND PROJECTNAME = '" + name + "' AND COMPANYNAME = '" + companyName + "' " +
                    "AND DATE BETWEEN julianday('" + fromdate + "') AND julianday('" + todate + "') + 0.5 " +
                    "ORDER BY DATE", conn);
                var cmdBuilder = new SQLiteCommandBuilder(sqliteAdapter);
                sqliteAdapter.Fill(table);
                sqliteAdapter.Update(table);
                conn.Close();
            }
            return table;
        }

        public DataTable getWorkerBill_table(string plotno, string name, string personName, string fromdate = "2000-01-01", string todate = "now")
        {
            DataTable table = new DataTable();

            using (conn = new SQLiteConnection("data source = " + DB_NAME))
            {
                conn.Open();
                var sqliteAdapter = new SQLiteDataAdapter("SELECT rowid, BILLNO, date(DATE) DATE, AMOUNT, TYPE, PARTICULAR," +
                   "IMAGEPATH  " +
                   "FROM WORKERBILL " +
                   "WHERE PROJECTPLOTNO = '" + plotno + "' AND PROJECTNAME = '" + name + "' AND PERSONNAME = '" + personName + "' " +
                   "AND DATE BETWEEN julianday('" + fromdate + "') AND julianday('" + todate + "') + 0.5 " +
                   "ORDER BY DATE", conn);

                var cmdBuilder = new SQLiteCommandBuilder(sqliteAdapter);
                sqliteAdapter.Fill(table);
                sqliteAdapter.Update(table);
                conn.Close();
            }
            return table;
        }


        public DataTable getWorker_table(string plotno, string name)
        {
            DataTable table = new DataTable();
            using (conn = new SQLiteConnection("data source = " + DB_NAME))
            {
                conn.Open();
                var sqliteAdapter = new SQLiteDataAdapter("SELECT PERSONNAME, CONTACTNO, CNIC, EMAIL, TYPEOFWORK, PROJECTPLOTNO  FROM WORKER WHERE PROJECTPLOTNO = '" + plotno +
                    "' AND PROJECTNAME = '" + name + "'", conn);
                var cmdBuilder = new SQLiteCommandBuilder(sqliteAdapter);
                sqliteAdapter.Fill(table);
                sqliteAdapter.Update(table);
                conn.Close();
            }
            return table;
        }

        public DataTable getCompany_table(string plotno, string name)
        {
            DataTable table = new DataTable();
            using (conn = new SQLiteConnection("data source = " + DB_NAME))
            {
                conn.Open();
                var sqliteAdapter = new SQLiteDataAdapter("SELECT COMPANYNAME, PERSONNAME, CONTACTNO, TYPE, SHOPADDRESS, PROJECTPLOTNO  FROM COMPANY WHERE PROJECTPLOTNO = '" + plotno +
                    "' AND PROJECTNAME = '" + name + "'", conn);
                var cmdBuilder = new SQLiteCommandBuilder(sqliteAdapter);
                sqliteAdapter.Fill(table);
                sqliteAdapter.Update(table);
                conn.Close();
            }
            return table;
        }


        public int insertProject(string plotno, string name, string contactno, string date = "now", string status = "in progress")
        {
            int n = 0;
            try
            {
                using (conn = new SQLiteConnection("data source = " + DB_NAME))
                {
                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        conn.Open();
                        cmd.CommandText = "INSERT INTO PROJECT VALUES('" + plotno + "',julianday('" + date + "'), '" + name + "', '" + contactno + "', '" + status + "')";
                        n = cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex, "insertProject");
            }
            return n;
        }

        public DataTable getProject_table()
        {
            try
            {
                DataTable table = new DataTable();
                using (conn = new SQLiteConnection("data source = " + DB_NAME))
                {
                    conn.Open();
                    var sqliteAdapter = new SQLiteDataAdapter("SELECT plotno, date(date) date, name, contactno, status FROM PROJECT", conn);
                    var cmdBuilder = new SQLiteCommandBuilder(sqliteAdapter);
                    sqliteAdapter.Fill(table);
                    sqliteAdapter.Update(table);
                    conn.Close();
                }
                return table;
            }
            catch (Exception ex)
            {
                _log.Error(ex, "getProject_table");
                throw;
            }
        }

        public void deleteProject(string plotNo, string name)
        {
            using (conn = new SQLiteConnection("data source = " + DB_NAME))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = "DELETE FROM PROJECT WHERE PLOTNO = '" + plotNo + "' AND NAME = '" + name + "'";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void deleteRecievePayment(string sno, string plotno, string projectName)
        {
            using (conn = new SQLiteConnection("data source = " + DB_NAME))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = "DELETE FROM RECIEVEPAYMENT WHERE SNO = '" + sno + "' AND PROJECTPLOTNO = '" + plotno + "' AND PROJECTNAME = '" + projectName + "'";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

        }

        public void deleteCompany(string comapanyName, string plotno, string projectName)
        {
            using (conn = new SQLiteConnection("data source = " + DB_NAME))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = "DELETE FROM COMPANY WHERE COMPANYNAME = '" + comapanyName + "' AND PROJECTPLOTNO = '" + plotno + "' AND PROJECTNAME = '" + projectName + "'";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

        }

        public void deleteWorker(string personName, string plotno, string projectName)
        {
            using (conn = new SQLiteConnection("data source = " + DB_NAME))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = "DELETE FROM WORKER WHERE PERSONNAME = '" + personName + "' AND PROJECTPLOTNO = '" + plotno + "' AND PROJECTNAME = '" + projectName + "'";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

        }
        public void deleteCompanyBill(string billNo, string companyName, string plotno, string projectName, long rowid)
        {
            using (conn = new SQLiteConnection("data source = " + DB_NAME))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = "DELETE FROM COMPANYBILL " +
                        "WHERE rowid = " + rowid;
                    //"WHERE BILLNO = '" + billNo + "' AND COMPANYNAME = '" + companyName + "' AND PROJECTPLOTNO = '" + plotno + "' AND PROJECTNAME = '" + projectName + "'";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void deleteWorkerBill(string billNo, string personName, string plotno, string projectName, long rowid)
        {
            using (conn = new SQLiteConnection("data source = " + DB_NAME))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = "DELETE FROM WORKERBILL " +
                        "WHERE rowid = " + rowid;
                    //"WHERE BILLNO = '" + billNo + "' AND PERSONNAME = '" + personName + "' AND PROJECTPLOTNO = '" + plotno + "' AND PROJECTNAME = '" + projectName + "'";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void deleteWorkerBills(string personName, string plotno, string projectName)
        {
            using (conn = new SQLiteConnection("data source = " + DB_NAME))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = "DELETE FROM WORKERBILL WHERE PERSONNAME = '" + personName + "' AND PROJECTPLOTNO = '" + plotno + "' AND PROJECTNAME = '" + projectName + "'";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void deleteCompanyBills(string companyName, string plotno, string projectName)
        {
            using (conn = new SQLiteConnection("data source = " + DB_NAME))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = "DELETE FROM COMPANYBILL WHERE COMPANYNAME = '" + companyName + "' AND PROJECTPLOTNO = '" + plotno + "' AND PROJECTNAME = '" + projectName + "'";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void deleteComapanies(string plotno, string projectName)
        {
            using (conn = new SQLiteConnection("data source = " + DB_NAME))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = "DELETE FROM COMPANY WHERE PROJECTPLOTNO = '" + plotno + "' AND PROJECTNAME = '" + projectName + "'";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void deleteWorkers(string plotno, string projectName)
        {
            using (conn = new SQLiteConnection("data source = " + DB_NAME))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = "DELETE FROM WORKER WHERE PROJECTPLOTNO = '" + plotno + "' AND PROJECTNAME = '" + projectName + "'";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void updateProject(string old_plotno, string old_name, string plotno, string date, string name, string contactno, string status)
        {
            using (conn = new SQLiteConnection("data source = " + DB_NAME))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = "UPDATE PROJECT SET CONTACTNO = '" + contactno + "', DATE = julianday('" + date + "'), NAME = '" + name + "'," +
                        "STATUS = '" + status + "', PLOTNO = '" + plotno + "' " +
                        "WHERE PLOTNO = '" + old_plotno + "' AND NAME = '" + old_name + "'";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

        }

        public void updateCompany(string old_companyName, string companyName, string old_plotno, string old_projectName, string plotno, string projectName,
            string contactno, string shopAddress, string typeofwork, string personName)
        {
            using (conn = new SQLiteConnection("data source = " + DB_NAME))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = "UPDATE COMPANY SET CONTACTNO = '" + contactno + "', SHOPADDRESS = '" + shopAddress + "', TYPE = '" + typeofwork + "', PROJECTPLOTNO = '" + plotno + "'"
                        + ", PROJECTNAME = '" + projectName + "', COMPANYNAME = '" + companyName + "', PERSONNAME= '" + personName + "'"
                        + "WHERE COMPANYNAME = '" + old_companyName + "' AND PROJECTPLOTNO = '" + old_plotno + "' AND PROJECTNAME = '" + old_projectName + "'";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

        }

        public void updateWorker(string old_personName, string cnic, string old_plotno, string old_projectName, string plotno, string projectName, string contactno, string email, string typeofwork, string personName)
        {

            using (conn = new SQLiteConnection("data source = " + DB_NAME))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = "UPDATE WORKER SET CONTACTNO = '" + contactno + "', EMAIL = '" + email + "', TYPEOFWORK = '" + typeofwork + "', PROJECTPLOTNO = '" + plotno + "'"
                        + ", PROJECTNAME = '" + projectName + "', CNIC = '" + cnic + "', PERSONNAME= '" + personName + "'"
                        + "WHERE PERSONNAME = '" + old_personName + "' AND PROJECTPLOTNO = '" + old_plotno + "' AND PROJECTNAME = '" + old_projectName + "'";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void updateCompanyBill(string compnanyName, string billNo, string plotno, string projectName, string date, int amount, string type, string particular, string imagePath, long rowid)
        {
            using (conn = new SQLiteConnection("data source = " + DB_NAME))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = "UPDATE COMPANYBILL SET DATE = julianday('" + date + "'), AMOUNT = " + amount + ", TYPE = '" + type + "', PARTICULAR = '" + particular + "'"
                        + ", IMAGEPATH = '" + imagePath + "'"
                        + "WHERE rowid = " + rowid +
                        //+ "WHERE rowid = "+rowid+ " COMPANYNAME = '" + compnanyName + "' AND PROJECTPLOTNO = '" + plotno + "' AND PROJECTNAME = '" + projectName + "'" +
                        " AND BILLNO = '" + billNo + "'";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void updateCompanyBills(string old_compnanyName, string old_plotno, string old_projectName, string compnanyName, string plotno, string projectName)
        {
            using (conn = new SQLiteConnection("data source = " + DB_NAME))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = "UPDATE COMPANYBILL SET COMPANYNAME = '" + compnanyName + "', PROJECTPLOTNO = '" + plotno + "' , PROJECTNAME = '" + projectName + "'"
                        + " WHERE COMPANYNAME = '" + old_compnanyName + "' AND PROJECTPLOTNO = '" + old_plotno + "' AND PROJECTNAME = '" + old_projectName + "'";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void updateWorkerBill(string personName, string billNo, string plotno, string projectName, string date, int amount, string type, string particular, string imagePath, long rowid)
        {
            using (conn = new SQLiteConnection("data source = " + DB_NAME))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = "UPDATE WORKERBILL SET DATE = julianday('" + date + "'), AMOUNT = " + amount + ", TYPE = '" + type + "', PARTICULAR = '" + particular + "'"
                        + ", IMAGEPATH = '" + imagePath + "'"
                        + " WHERE rowid = " + rowid +
                        //+ "WHERE PERSONNAME = '" + personName + "' AND PROJECTPLOTNO = '" + plotno + "' AND PROJECTNAME = '" + projectName + "'" +
                        " AND BILLNO = '" + billNo + "'";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
        public void updateWorkerBills(string old_personName, string old_plotno, string old_projectName, string personName, string plotno, string projectName)
        {
            using (conn = new SQLiteConnection("data source = " + DB_NAME))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = "UPDATE WORKERBILL SET PERSONNAME = '" + personName + "', PROJECTPLOTNO = '" + plotno + "' , PROJECTNAME = '" + projectName + "'"
                        + "WHERE PERSONNAME = '" + old_personName + "' AND PROJECTPLOTNO = '" + old_plotno + "' AND PROJECTNAME = '" + old_projectName + "'";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void updateRecievedPayment(int sno, string old_plotno, string old_projectName, string date, int amount, string paymentDesc)
        {
            using (conn = new SQLiteConnection("data source = " + DB_NAME))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = "UPDATE RECIEVEPAYMENT SET DATE = julianday('" + date + "'), AMOUNT = " + amount
                        + ", PAYMENT_DESCRIPTION = '" + paymentDesc + "'"
                        + "WHERE SNO = " + sno + " AND PROJECTPLOTNO = '" + old_plotno + "' AND PROJECTNAME = '" + old_projectName + "'";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

        }

        public void updateCompanies(string old_plotno, string old_projectName, string plotno, string projectName)
        {
            using (conn = new SQLiteConnection("data source = " + DB_NAME))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = "UPDATE COMPANY SET PROJECTNAME = '" + projectName + "', PROJECTPLOTNO= '" + plotno + "'"
                        + "WHERE PROJECTPLOTNO = '" + old_plotno + "' AND PROJECTNAME = '" + old_projectName + "'";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

        }

        public void updateWorkers(string old_plotno, string old_projectName, string plotno, string projectName)
        {
            using (conn = new SQLiteConnection("data source = " + DB_NAME))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = "UPDATE WORKER SET PROJECTNAME = '" + projectName + "', PROJECTPLOTNO= '" + plotno + "'"
                        + "WHERE PROJECTPLOTNO = '" + old_plotno + "' AND PROJECTNAME = '" + old_projectName + "'";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

        }
        public void updateRecievedPayments(string old_plotno, string old_projectName, string plotno, string projectName)
        {
            using (conn = new SQLiteConnection("data source = " + DB_NAME))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    //"UPDATE WORKER SET CONTACTNO = '" + contactno + "', EMAIL = '" + email + "', TYPEOFWORK = '" + typeofwork + "', PROJECTPLOTNO = '" + plotno + "'"
                    //    + ", PROJECTNAME = '" + projectName + "', CNIC = '" + cnic + "', PERSONNAME= '" + personName + "'"
                    //    + "WHERE PROJECTPLOTNO = '" + old_plotno + "' AND PROJECTNAME = '" + old_projectName + "'";
                    cmd.CommandText = "UPDATE RECIEVEPAYMENT SET PROJECTNAME = '" + projectName + "', PROJECTPLOTNO= '" + plotno + "'"
                        + "WHERE PROJECTPLOTNO = '" + old_plotno + "' AND PROJECTNAME = '" + old_projectName + "'";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

        }

    }
}
