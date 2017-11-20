using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace GymMSystem.Buisness_Logic
{
    public class login
    {

        public string  username { get; set; }
        public string pwd { get; set; }
        public employee emp { get; set; }
        public Boolean  user_type { get; set; }

        public login()
        {
            emp = new employee();
        }


        public bool add_users()
        {
            bool temp = false;
            try
            {
                DataLayer.dbConnect con = new DataLayer.dbConnect();
                con.openConnection();

                string q = "insert into tbl_userLogin values (@uname,@pwd,@emp,@type)";

                SqlCommand cmd = new SqlCommand(q, con.getConnection());

                cmd.Parameters.AddWithValue("@uname", username);
                cmd.Parameters.AddWithValue("@pwd", pwd);
                cmd.Parameters.AddWithValue("@type", user_type);
                cmd.Parameters.AddWithValue("@emp", emp.empID);

                cmd.ExecuteNonQuery();

                con.closeConnection();

                temp = true;



            }
            catch (Exception fsd)
            {

                throw;
            }
            if (temp == true) return true;
            else return false;
                
        }
        
        public bool do_log()
        {
            bool temp = false;
            try
            {
                DataLayer.dbConnect con = new DataLayer.dbConnect();
                con.openConnection();

               

                string q = " select * from tbl_userLogin where username=@uname and password=@pwd";

                SqlCommand cmd = new SqlCommand(q, con.getConnection());
                cmd.Parameters.AddWithValue("@uname", username);
                cmd.Parameters.AddWithValue("@pwd", pwd);

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                if(dt.Rows.Count == 1)
                {
                    user_type =(bool)dt.Rows[0]["type"];
                    

                    temp = true;
                }

            }
            catch (Exception dfs)
            {

                throw;
            }

            if (temp == true) return true;
            else return false;

        }

    }
}
