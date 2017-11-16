using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace GymMSystem.Buisness_Logic
{
    class empAttendence_repository
    {

        public bool addStartTime(Buisness_Logic.empAttendence eat)
        {
            bool temp1 = false;
            try
            {
               
                DataLayer.dbConnect con1 = new DataLayer.dbConnect();
                con1.openConnection();


                string q1 = "INSERT INTO tbl_emp_attendence (theDay,empid,start_time) values (@day, @empid, @st)";

                SqlCommand cmd1 = new SqlCommand(q1, con1.getConnection());

                cmd1.Parameters.AddWithValue("@day", eat.theDay);
                cmd1.Parameters.AddWithValue("@empid", eat.empID);
                cmd1.Parameters.AddWithValue("@st", eat.startTime);

                cmd1.ExecuteNonQuery();

                temp1 = true;

            }
            catch (Exception eui)
            {

                throw;
            }

            if (temp1 == true) return true;
            else return false;






        }


        public bool searchMemAt(Buisness_Logic.empAttendence eat1)
        {
            bool tempx = false;
            try
            {
                DataLayer.dbConnect con2 = new DataLayer.dbConnect();
                con2.openConnection();


                string q2 = "SELECT * FROM tbl_emp_attendence WHERE empid=@emp AND theDay=@day";

                SqlCommand cmd2 = new SqlCommand(q2, con2.getConnection());

                cmd2.Parameters.AddWithValue("@day", eat1.theDay);
                cmd2.Parameters.AddWithValue("@emp", eat1.empID);

                DataTable dt1 = new DataTable();
                SqlDataAdapter da1 = new SqlDataAdapter(cmd2);

                da1.Fill(dt1);
                

                if (dt1.Rows.Count > 0)
                {
                    eat1.startTime = dt1.Rows[0]["start_time"].ToString();
                    eat1.theDay = dt1.Rows[0]["theDay"].ToString();
                    eat1.endTime = dt1.Rows[0]["end_time"].ToString();
                    if (!DBNull.Value.Equals(dt1.Rows[0]["end_time"]))
                    {
                        eat1.endTime = dt1.Rows[0]["end_time"].ToString();
                    }
                    else
                    {

                    }
                    if (!DBNull.Value.Equals(dt1.Rows[0]["hours_worked"]))
                    {
                        eat1.hoursWorked = (double)dt1.Rows[0]["hours_worked"];
                    }
                    else
                    {

                    }
                    if (!DBNull.Value.Equals(dt1.Rows[0]["extra_hours"]))
                    {
                        eat1.extraHours = (double)dt1.Rows[0]["extra_hours"];
                    }
                    else
                    {

                    }

                   

                    tempx = true;
                }

               
                
            }
            catch (Exception exw)
            {

                throw;
            }

            if (tempx == true) return true;
            else return false;
        }


        public bool addEndTime(Buisness_Logic.empAttendence eat)
        {
            bool temp3 = false;
            try
            {

                DataLayer.dbConnect con3 = new DataLayer.dbConnect();
                con3.openConnection();


                string q3 = "UPDATE  tbl_emp_attendence SET end_time=@et, hours_worked=@hw ,extra_hours=@eh where theDay=@day and empid=@eid";

                SqlCommand cmd3 = new SqlCommand(q3, con3.getConnection());

                cmd3.Parameters.AddWithValue("@day", eat.theDay);
                cmd3.Parameters.AddWithValue("@eid", eat.empID);
                cmd3.Parameters.AddWithValue("@et", eat.endTime);
                cmd3.Parameters.AddWithValue("@hw", eat.hoursWorked);
                cmd3.Parameters.AddWithValue("@eh", eat.extraHours);


                cmd3.ExecuteNonQuery();

                temp3 = true;

            }
            catch (Exception euid)
            {

                throw;
            }

            if (temp3 == true) return true;
            else return false;






        }

        //public bool calculateHours(empAttendence att)
        //{
        //    try
        //    {
                
        //    }
        //    catch (Exception fdsf)
        //    {

        //        throw;
        //    }

        //}

    }
}
