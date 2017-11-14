using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace GymMSystem.Buisness_Logic
{
    class repair
    {
        public int repID { get; set; }
        public int equipmentID { get; set; }
        public string  equipmentName { get; set; }
        public string  status { get; set; }
        public string  descriptioin { get; set; }
        public string  start_date { get; set; }
        public string  finished_date { get; set; }
        public double cost { get; set; }


        public bool addToRepair(Buisness_Logic.repair rep)
        {
            bool temp = false;
            try
            {
                DataLayer.dbConnect con = new DataLayer.dbConnect();
                con.openConnection();

                string q = "Insert into tbl_repair (start_date,repairalble_itemID,equi_name) values (@sdate,@id,@name)";

                SqlCommand cmd = new SqlCommand(q, con.getConnection());

                cmd.Parameters.AddWithValue("@sdate", rep.start_date);
                cmd.Parameters.AddWithValue("@id", rep.equipmentID);
                cmd.Parameters.AddWithValue("@name", rep.equipmentName);

                cmd.ExecuteNonQuery();

                temp = true;



            }
            catch (Exception dfsd)
            {

                throw;
            }

            if (temp == true) return true;
            else return false;
                    
        }

        public bool searchRepairItem(int repID, int equiID, Buisness_Logic.repair rep)
        {
            DataLayer.dbConnect con = new DataLayer.dbConnect();
            con.openConnection();
            bool temp = false;

            try
            {
                string q = "select * from tbl_repair where repairID=@rid or repairalble_itemID=@mid ";

                SqlCommand cmd = new SqlCommand(q, con.getConnection());

                cmd.Parameters.AddWithValue("@rid", repID);
                cmd.Parameters.AddWithValue("@mid", equiID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    rep.repID = (int)dt.Rows[0]["repairID"];
                    rep.equipmentID = (int)dt.Rows[0]["repairalble_itemID"];
                    rep.status = dt.Rows[0]["status"].ToString();
                    rep.descriptioin = dt.Rows[0]["description"].ToString();
                    if (! DBNull.Value.Equals( dt.Rows[0]["cost"]))
                    {
                        rep.cost = double.Parse(dt.Rows[0]["cost"].ToString());
                    }
                    else
                    {
                        
                    }
                    
                    rep.start_date = dt.Rows[0]["start_date"].ToString();
                    rep.finished_date = dt.Rows[0]["finished_date"].ToString();
                    rep.equipmentName = dt.Rows[0]["equi_name"].ToString();

                    temp = true;
                }
            }
            catch (Exception fsdfs)
            {

                throw;
            }

            if (temp == true) return true;
            else return false;
        }

        public bool updateRepItemDetails(Buisness_Logic.repair rep)
        {
            DataLayer.dbConnect con = new DataLayer.dbConnect();
            con.openConnection();
            bool temp = false;
            try
            {
                string qr = "update tbl_repair set status=@status,cost=@cost,description=@des,start_date=@sd,finished_date=@fd where repairID=@rid";


                SqlCommand cmd = new SqlCommand(qr, con.getConnection());
                cmd.Parameters.AddWithValue("@status", rep.status);
                cmd.Parameters.AddWithValue("@cost", rep.cost);
                cmd.Parameters.AddWithValue("@des", rep.descriptioin);
                cmd.Parameters.AddWithValue("@sd", rep.start_date);
                cmd.Parameters.AddWithValue("@fd", rep.finished_date);
                cmd.Parameters.AddWithValue("@rid", rep.repID);

                cmd.ExecuteNonQuery();
                temp = true;
            }
            catch (Exception fsd)
            {

                throw;
            }

            if (temp == true) return true;
            else return false;

        }

    }
}
