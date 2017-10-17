using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;


namespace GymMSystem.Buisness_Logic
{
    class finace_repository
    {
       
        public bool getIncome_thisMonth(Finance ff)
        {
            double amount;
            DataTable dt = new DataTable();
     

            try
            {
                
                DateTime date1 = DateTime.Today;
                var firstDayOfMonth = new DateTime(date1.Year, date1.Month, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                //if (DateTime.Now.ToShortDateString() >)

                DataLayer.dbConnect con = new DataLayer.dbConnect();

                con.openConnection();

                string qurey = "Select sum(amount) from tbl_fee where paid_date between @fdate and @tdate";

                SqlCommand cmd = new SqlCommand(qurey, con.getConnection());

                cmd.Parameters.AddWithValue("@fdate", firstDayOfMonth.ToShortDateString());
                cmd.Parameters.AddWithValue("@tdate", lastDayOfMonth.ToShortDateString());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                

                da.Fill(dt);

              






            }
            catch (Exception ex1)
            {

                throw;
            }

            if (dt.Rows[0][0] != null && !string.IsNullOrEmpty(dt.Rows[0][0].ToString()))
            {
                ff.amount = (double)dt.Rows[0][0];

                return true;
            }
            else
            {
                ff.amount = 0.00;
                return false;
            }

        }


        public bool getIncome(int year, int month,Finance ff)
        {
            double amount;
            DataTable dt = new DataTable();
        

            try
            {
                string str = string.Concat(year, month,"01");
                DateTime date1;    
          DateTime.TryParseExact(str, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date1);
                var firstDayOfMonth = new DateTime(date1.Year, date1.Month, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                //if (DateTime.Now.ToShortDateString() >)

                DataLayer.dbConnect con = new DataLayer.dbConnect();

                con.openConnection();

                string qurey = "Select SUM(amount) from tbl_fee where paid_date between @fdate and @tdate";

                SqlCommand cmd = new SqlCommand(qurey, con.getConnection());

                cmd.Parameters.AddWithValue("@fdate", firstDayOfMonth.ToShortDateString());
                cmd.Parameters.AddWithValue("@tdate", lastDayOfMonth.ToShortDateString());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
              

                    da.Fill(dt);


            }
            catch (Exception ex1)
            {

                throw;
            }

            if (dt.Rows[0][0] != null && !string.IsNullOrEmpty(dt.Rows[0][0].ToString()))
            {
                ff.amount = (double)dt.Rows[0][0];

                return true;
            }
            else
            {
                ff.amount = 0.00;
                return false;
            }
        }


        public bool getIncomeOfSales(int year, int month, Finance ff)
        {
            double amount;
            DataTable dt = new DataTable();


            try
            {

                string str;
                DateTime date1;

                if (month > 9)
                {
                    str = string.Concat(year, month, "01");
                  
                  

                }
                else
                {
                   string lmonth= string.Concat("0", month);
                    str = string.Concat(year, lmonth, "01");
                }

                DateTime.TryParseExact(str, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date1);
                var firstDayOfMonth = new DateTime(date1.Year, date1.Month, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                //if (DateTime.Now.ToShortDateString() >)

                DataLayer.dbConnect con = new DataLayer.dbConnect();

                con.openConnection();

                string qurey = "SELECT SUM(o.total) FROM tbl_order o LEFT OUTER JOIN  tbl_cutomer_order C ON o.invoice=c.invID where  o.payment_date between @fdate and @tdate";



                //*************
                //"(SELECT SUM(o.total) FROM tbl_order o LEFT OUTER JOIN  tbl_cutomer_order C ON o.invoice=c.invID  )" +
                //    " = (SELECT invoice FROM tbl_order WHERE  payment_date between @fdate and @tdate)";
                SqlCommand cmd = new SqlCommand(qurey, con.getConnection());

                cmd.Parameters.AddWithValue("@fdate", firstDayOfMonth.ToShortDateString());
                cmd.Parameters.AddWithValue("@tdate", lastDayOfMonth.ToShortDateString());
                SqlDataAdapter da = new SqlDataAdapter(cmd);


                da.Fill(dt);


            }
            catch (Exception ex1)
            {

                throw;
            }

            if (dt.Rows[0][0] != null && !string.IsNullOrEmpty(dt.Rows[0][0].ToString()))
            {
                ff.amount = (double)dt.Rows[0][0];

                return true;
            }
            else
            {
                ff.amount = 0.00;
                return false;
            }
        }

        public bool getExpenseOfSales(int year, int month, Finance ff)
        {
            double amount;
            DataTable dt = new DataTable();


            try
            {

                string str;
                DateTime date1;

                if (month > 9)
                {
                    str = string.Concat(year, month, "01");



                }
                else
                {
                    string lmonth = string.Concat("0", month);
                    str = string.Concat(year, lmonth, "01");
                }

                DateTime.TryParseExact(str, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date1);
                var firstDayOfMonth = new DateTime(date1.Year, date1.Month, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                //if (DateTime.Now.ToShortDateString() >)

                DataLayer.dbConnect con = new DataLayer.dbConnect();

                con.openConnection();

                string qurey = "SELECT SUM(total) FROM tbl_pOrder where date between @fdate and @tdate";



                //*************
                //"(SELECT SUM(o.total) FROM tbl_order o LEFT OUTER JOIN  tbl_cutomer_order C ON o.invoice=c.invID  )" +
                //    " = (SELECT invoice FROM tbl_order WHERE  payment_date between @fdate and @tdate)";
                SqlCommand cmd = new SqlCommand(qurey, con.getConnection());

                cmd.Parameters.AddWithValue("@fdate", firstDayOfMonth.ToShortDateString());
                cmd.Parameters.AddWithValue("@tdate", lastDayOfMonth.ToShortDateString());
                SqlDataAdapter da = new SqlDataAdapter(cmd);


                da.Fill(dt);


            }
            catch (Exception ex1)
            {

                throw;
            }

            if (dt.Rows[0][0] != null && !string.IsNullOrEmpty(dt.Rows[0][0].ToString()))
            {
                ff.expenditure = (double)dt.Rows[0][0];

                return true;
            }
            else
            {
                ff.expenditure = 0.00;
                return false;
            }
        }

    }
}
