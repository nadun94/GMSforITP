using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace GymMSystem.Buisness_Logic
{
    class hourly_services:services
    {
        public double hourly_rate { get; set; }

        public bool addHourly_service(hourly_services ms)
        {

            bool temp = false;
            try
            {
                DataLayer.dbConnect con = new DataLayer.dbConnect();
                con.openConnection();

                string q = "insert into tbl_services (service_name,service_type,hourly_rate) values (@name,@type,@rate)";

                SqlCommand cmd = new SqlCommand(q, con.getConnection());

                cmd.Parameters.AddWithValue("@name", ms.service_name);
                cmd.Parameters.AddWithValue("@type", ms.service_type);
                cmd.Parameters.AddWithValue("@rate", ms.hourly_rate);
           
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

        public bool UpdateHourly_service(hourly_services ms)
        {

            bool temp = false;
            try
            {
                DataLayer.dbConnect con = new DataLayer.dbConnect();
                con.openConnection();

                string q = "update  tbl_services  set service_type=@type,hourly_rate=@rate where service_name=@name";

                SqlCommand cmd = new SqlCommand(q, con.getConnection());

                cmd.Parameters.AddWithValue("@name", ms.service_name);
                cmd.Parameters.AddWithValue("@type", ms.service_type);
                cmd.Parameters.AddWithValue("@rate", ms.hourly_rate);

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
