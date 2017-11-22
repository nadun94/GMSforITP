using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace GymMSystem.Buisness_Logic
{
   public class employee
    {
        public int empID { get; set; }
        public string  name { get; set; }
        public string  dob { get; set; }
        public string  address { get; set; }
        public string  gender { get; set; }
        public string email { get; set; }
        public string  position { get; set; }
        public string nic { get; set; }
        public string phone { get; set; }
        public string  profile { get; set; }
        public byte[] photo { get; set; }
        public string joinedDate { get; set; }

        public bool calculate_salaryl(int month, int year, int empid, salary sq)
        {
            bool t1 = false;
            try
            {
                double total_hours, total_extraHours;
                double rate_h, rate_extra;
                double s1, s2, salary;
                DataLayer.dbConnect con = new DataLayer.dbConnect();
                con.openConnection();

                string q = "select sum(hours_worked) as 'h' , sum(extra_hours) as 'e' from tbl_emp_attendence where datepart(yy,theDay)=@y and DATEPART(mm,theDay)=@m";

                SqlCommand cmd = new SqlCommand(q, con.getConnection());

                cmd.Parameters.AddWithValue("@y", year);
                cmd.Parameters.AddWithValue("@m", year);


                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);
                rate_extra = 200.00;
                rate_h = 150.00;



                if (dt.Rows.Count ==1)
                {
                    total_hours = (double)dt.Rows[0]["h"];
                    total_extraHours = (double)dt.Rows[0]["e"];

                    s1 = total_hours * rate_h;
                    s2 = total_extraHours * rate_extra;

                    salary = s1 + s2;
                    t1 = true;
                    sq.ot = s2;
                    sq.originalsala = s2;
                    sq.tot_hours = total_hours;
                    sq.extr_hours = total_extraHours;

                }


            }
            catch (Exception gfg)
            {

                throw;
            }
            if (t1 == true)
            {
                return true;
            }
            else return false;
        }
    }
}
