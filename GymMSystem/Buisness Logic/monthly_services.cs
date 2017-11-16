using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace GymMSystem.Buisness_Logic
{
    class monthly_services:services
    {
        public double monthly_charge { get; set; }
        public string day { get; set; }
        public string start_time { get; set; }
        public string end_time { get; set; }
        public string  cordinator { get; set; }


        public bool addMonthly_service(monthly_services ms)
        {

            bool temp = false;
            try
            {
                DataLayer.dbConnect con = new DataLayer.dbConnect();
                con.openConnection();

                string q = "insert into tbl_services (service_name,service_type,monthly_charge,day,start_time,end_time,cordinator) values (@name,@type,@mrate,@day,@stime,@etime,@cordi)";

                SqlCommand cmd = new SqlCommand(q, con.getConnection());

                cmd.Parameters.AddWithValue("@name", ms.service_name);
                cmd.Parameters.AddWithValue("@type", ms.service_type);
                cmd.Parameters.AddWithValue("@mrate", ms.monthly_charge);
                cmd.Parameters.AddWithValue("@day", ms.day);
                cmd.Parameters.AddWithValue("@stime", ms.start_time);
                cmd.Parameters.AddWithValue("@etime", ms.end_time);
                cmd.Parameters.AddWithValue("@cordi", ms.cordinator);

                cmd.ExecuteNonQuery();

                temp = true;
                con.closeConnection();
            }
            catch (Exception fd)
            {

                throw;
            }

            if (temp == true) return true;
            else return false;
        }
    }
}
