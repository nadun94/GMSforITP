using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace GymMSystem.Buisness_Logic
{
    class repairableItem_repository
    {
        public bool addRepItems(repairablerable_Items rep)
        {
            DataLayer.dbConnect dbrep = new DataLayer.dbConnect();
            dbrep.openConnection();

            

            bool test = false;
          
            SqlTransaction trn1 = dbrep.getConnection().BeginTransaction();
            try
            { 

                string q1 = "INSERT INTO tbl_inventory (name,make,model,price,photo) values (@name,@make,@model,@price,@photo) ";
                SqlCommand cmd1 = new SqlCommand(q1, dbrep.getConnection());

                cmd1.Parameters.AddWithValue("@name", rep.name);
                cmd1.Parameters.AddWithValue("@make", rep.make);
                cmd1.Parameters.AddWithValue("@model", rep.model);
                cmd1.Parameters.AddWithValue("@price", rep.price);
                cmd1.Parameters.AddWithValue("@photo", rep.photo);

                cmd1.Transaction = trn1;
                cmd1.ExecuteNonQuery();


                string q2 = "SELECT invID FROM tbl_inventory where name=@name";
                SqlCommand cmd2 = new SqlCommand(q2, dbrep.getConnection());

                cmd2.Parameters.AddWithValue("@name", rep.name);

                cmd2.Transaction = trn1;

                SqlDataAdapter da1 = new SqlDataAdapter(cmd2);
                DataTable dt1 = new DataTable();

                da1.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {

                rep.invID = int.Parse(dt1.Rows[0]["invID"].ToString());

                }


                string q3 = "INSERT INTO tbl_repairable_item values (@invid)";

                SqlCommand cmd3 = new SqlCommand(q3, dbrep.getConnection());

                cmd3.Parameters.AddWithValue("@invid", rep.invID);
      

                cmd3.Transaction = trn1;
                cmd3.ExecuteNonQuery();
                trn1.Commit();
            dbrep.closeConnection();

                test = true;

            }
            catch (Exception exinv)
            {
                trn1.Rollback();
                MessageBox.Show(exinv.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }


            if (test == true) return true;

            else return false;
        }

        public bool searchEqui_Items(int id, string pname, Buisness_Logic.repairablerable_Items prd)
        {

            // Buisness_Logic.product prd = new Buisness_Logic.product();

            bool temp = false;
            DataLayer.dbConnect con = new DataLayer.dbConnect();
            con.openConnection();
            try
            {
                string qr = "select * from view_repairItemsSet where inventoryID=@id or name=@name";

                SqlCommand cmd = new SqlCommand(qr, con.getConnection());

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", pname);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    prd.invID = (int)dt.Rows[0]["inventoryID"];
                    prd.name = dt.Rows[0]["name"].ToString();
                    prd.make = dt.Rows[0]["make"].ToString();
                    prd.price = (double)dt.Rows[0]["price"];
                    prd.model = dt.Rows[0]["model"].ToString();
                    prd.photo = (byte[])dt.Rows[0]["photo"];

                    temp = true;
                }
            }
            catch (Exception pt)
            {

                throw;
            }

            if (temp == true) return true;
            else return false;

        }

        public bool update_Equipments(Buisness_Logic.repairablerable_Items prd)
        {
            DataLayer.dbConnect con = new DataLayer.dbConnect();
            con.openConnection();

            bool temp = false;

            try
            {
                string qry1 = "update tbl_inventory set name=@name,make=@make,model=@model,price=@price,photo=@photo where invID=@id";

                SqlCommand cmd = new SqlCommand(qry1, con.getConnection());

                cmd.Parameters.AddWithValue("@name", prd.name);
                cmd.Parameters.AddWithValue("@make", prd.make);
                cmd.Parameters.AddWithValue("@model", prd.model);
                cmd.Parameters.AddWithValue("@price", prd.price);
                cmd.Parameters.AddWithValue("@photo", prd.photo);
                cmd.Parameters.AddWithValue("@id", prd.invID);

                cmd.ExecuteNonQuery();

                temp = true;

                con.closeConnection();

            }
            catch (Exception dsa)
            {
          
                throw;
            }

            if (temp == true) return true;
            else return false;

        }

        public bool deleteEqui(int id)
        {
            bool temp = false;

            DataLayer.dbConnect con = new DataLayer.dbConnect();
            con.openConnection();
            SqlTransaction trn = con.getConnection().BeginTransaction();
            try
            {
                string qd = "delete tbl_repairable_item where inventoryID=@id";

                SqlCommand cmd1 = new SqlCommand(qd, con.getConnection());

                cmd1.Parameters.AddWithValue("@id", id);
                cmd1.Transaction = trn;
                cmd1.ExecuteNonQuery();


                string q2 = "delete tbl_inventory where invID=@id";

                SqlCommand cmd2 = new SqlCommand(q2, con.getConnection());

                cmd2.Parameters.AddWithValue("@id", id);
                cmd2.Transaction = trn;
                cmd2.ExecuteNonQuery();

                trn.Commit();
                con.closeConnection();
                temp = true;

            }
            catch (Exception ui)
            {
                trn.Rollback();
                throw;
            }

            if (temp == true) return true;
            else return false;

        }
        public DataTable searchEqui_Items()
        {

            // Buisness_Logic.product prd = new Buisness_Logic.product();

            bool temp = false;
            DataLayer.dbConnect con = new DataLayer.dbConnect();
            con.openConnection();
            DataTable dt = new DataTable();
            try
            {
                string qr = "select * from view_repairItemsSet";

                SqlCommand cmd = new SqlCommand(qr, con.getConnection());



                SqlDataAdapter da = new SqlDataAdapter(cmd);


                da.Fill(dt);

            }
            catch (Exception pt)
            {

                throw;
            }

            return dt;

        }
    }
}
