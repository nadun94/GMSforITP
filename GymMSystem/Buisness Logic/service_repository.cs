using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace GymMSystem.Buisness_Logic
{
    class service_repository
    {

        public DataTable search_services()
        {
            try
            {
                DataLayer.dbConnect con = new DataLayer.dbConnect();
                con.openConnection();

                string q = "select * from tbl_services";

                SqlCommand cmd = new SqlCommand(q, con.getConnection());

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                return dt;
            }
            catch (Exception fd)
            {

                throw;
            }
        }


        //user accounts
        public DataTable search_users()
        {
            try
            {
                DataLayer.dbConnect con = new DataLayer.dbConnect();
                con.openConnection();

                string q = "select * from tbl_userLogin";

                SqlCommand cmd = new SqlCommand(q, con.getConnection());

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                return dt;
            }
            catch (Exception fd)
            {

                throw;
            }
        }

    }
}
