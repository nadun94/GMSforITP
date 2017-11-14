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
    class nonRepairableItem_repository
    {

        public bool addNonRepairabItems(nonRepairable_Item nri)
        {
            bool test = false;
            DataLayer.dbConnect dbinv = new DataLayer.dbConnect();
            dbinv.openConnection();
            SqlTransaction trn1 = dbinv.getConnection().BeginTransaction();
            try
            {
                
                

                string q1 = "INSERT INTO tbl_inventory (name,make,model,price,photo) values (@name,@make,@model,@price,@photo) ";
                SqlCommand cmd1 = new SqlCommand(q1, dbinv.getConnection());

                cmd1.Parameters.AddWithValue("@name", nri.name);
                cmd1.Parameters.AddWithValue("@make", nri.make);
                cmd1.Parameters.AddWithValue("@model", nri.model);
                cmd1.Parameters.AddWithValue("@price", nri.price);
                cmd1.Parameters.AddWithValue("@photo", nri.photo);

                cmd1.Transaction = trn1;
                cmd1.ExecuteNonQuery();


                string q2 = "SELECT invID FROM tbl_inventory where name=@name";
                SqlCommand cmd2 = new SqlCommand(q2, dbinv.getConnection());

                cmd2.Parameters.AddWithValue("@name", nri.name);

                cmd2.Transaction = trn1;

                SqlDataAdapter da1 = new SqlDataAdapter(cmd2);
                DataTable dt1 = new DataTable();

                da1.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                    
                    nri.invID = int.Parse(dt1.Rows[0]["invID"].ToString());

                }


                string q3 = "INSERT INTO tbl_non_repairable values (@invid, @qty, @weight)";

                SqlCommand cmd3 = new SqlCommand(q3, dbinv.getConnection());

                cmd3.Parameters.AddWithValue("@invid", nri.invID);
                cmd3.Parameters.AddWithValue("@qty", nri.qty);
                cmd3.Parameters.AddWithValue("@weight", nri.weight);

                cmd3.Transaction = trn1;
                cmd3.ExecuteNonQuery();
                trn1.Commit();
                dbinv.closeConnection();
              
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


        public bool searchWL_Items(int id, string pname, Buisness_Logic.nonRepairable_Item prd)
        {

            // Buisness_Logic.product prd = new Buisness_Logic.product();

            bool temp = false;
            DataLayer.dbConnect con = new DataLayer.dbConnect();
            con.openConnection();
            try
            {
                string qr = "select * from view_nonRepItems where invID=@id or name=@name";

                SqlCommand cmd = new SqlCommand(qr, con.getConnection());

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", pname);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    prd.invID = (int)dt.Rows[0]["invID"];
                    prd.name = dt.Rows[0]["name"].ToString();
                    prd.make = dt.Rows[0]["make"].ToString();
                    prd.qty = (int)dt.Rows[0]["qty"];
                    prd.price = (double)dt.Rows[0]["price"];
                    prd.weight = (double)dt.Rows[0]["weight"];
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

        public bool updateWeightLiftingItems(Buisness_Logic.nonRepairable_Item prd)
        {
            DataLayer.dbConnect con = new DataLayer.dbConnect();
            con.openConnection();

            bool temp = false;
            SqlTransaction trn = con.getConnection().BeginTransaction();
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

                cmd.Transaction = trn;
                cmd.ExecuteNonQuery();

                string qry2 = "update tbl_non_repairable set qty=@qty,weight=@weight where invetoryID=@invid";

                SqlCommand cmd2 = new SqlCommand(qry2, con.getConnection());

                cmd2.Parameters.AddWithValue("@weight", prd.weight);
                cmd2.Parameters.AddWithValue("@qty", prd.qty);
                cmd2.Parameters.AddWithValue("@invid", prd.invID);
                cmd2.Transaction = trn;
                cmd2.ExecuteNonQuery();

                trn.Commit();
                temp = true;

                con.closeConnection();

            }
            catch (Exception dsa)
            {
                trn.Rollback();
                throw;
            }

            if (temp == true) return true;
            else return false;

        }

        public bool deleteWLI(int id)
        {
            bool temp = false;

            DataLayer.dbConnect con = new DataLayer.dbConnect();
            con.openConnection();
            SqlTransaction trn = con.getConnection().BeginTransaction();
            try
            {
                string qd = "delete tbl_non_repairable where invetoryID=@id";

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
    }
}
