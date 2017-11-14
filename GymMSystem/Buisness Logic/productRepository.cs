using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace GymMSystem.Buisness_Logic
{
    class productRepository
    {

        public bool save_Product(product prod)
        {
            bool temp1 = false;

            try
            {

                // Initialize image
                
                DataLayer.dbConnect dbp = new DataLayer.dbConnect();
                dbp.openConnection();
                string query1 = "INSERT INTO tbl_product (name,make ,p_type, qty,buying_price,selling_price,photo) VALUES  (@name, @make, @type, @qty,@bprice,@sprice, @photo)";

                SqlCommand cmd = new SqlCommand(query1, dbp.getConnection());
                cmd.Parameters.AddWithValue("@name", prod.name);
                cmd.Parameters.AddWithValue("@make", prod.make);
                cmd.Parameters.AddWithValue("@type", prod.productType);
                cmd.Parameters.AddWithValue("@qty", prod.qty);
                cmd.Parameters.AddWithValue("@bprice", prod.buying_price);
                cmd.Parameters.AddWithValue("@sprice", prod.selling_Price);
                cmd.Parameters.AddWithValue("@photo", prod.photo);

         
                cmd.ExecuteNonQuery();

                string q2 = "SELECT productID from tbl_product where name=@name ";

                SqlCommand cmd2 = new SqlCommand(q2, dbp.getConnection());

                cmd2.Parameters.AddWithValue("@name", prod.name);

                SqlDataReader dr = cmd2.ExecuteReader();



                while (dr.Read())
                {
                    prod.productID= (int)dr["productID"];
                }

                dr.Close();
                dbp.closeConnection();
                temp1 = true;

            }
            catch (Exception exprep)
            {
                MessageBox.Show(exprep.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

            if (temp1 == true) return true;

            else
            return false;


        }

        public bool searchProduct(int id,string pname,Buisness_Logic.product prd)
        {

           // Buisness_Logic.product prd = new Buisness_Logic.product();

            bool temp = false;
            DataLayer.dbConnect con = new DataLayer.dbConnect();
            con.openConnection();
            try
            {
                string qr = "select * from tbl_product where productID=@id or name=@name";

                SqlCommand cmd = new SqlCommand(qr, con.getConnection());

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", pname);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    prd.productID= (int)dt.Rows[0]["productID"];
                    prd.name = dt.Rows[0]["name"].ToString();
                    prd.make = dt.Rows[0]["make"].ToString();
                    prd.qty = (int)dt.Rows[0]["qty"];
                    prd.buying_price = (double)dt.Rows[0]["buying_price"];
                    prd.selling_Price = (double)dt.Rows[0]["selling_price"];
                    prd.productType = dt.Rows[0]["p_type"].ToString();
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

        public bool updateProduct (Buisness_Logic.product prd)
        {

            DataLayer.dbConnect con = new DataLayer.dbConnect();
            con.openConnection();

            bool temp = false;

            try
            {
                string qry = "update tbl_product set name=@name,make=@make,p_type=@type,qty=@qty,buying_price=@bp,selling_price=@sp,photo=@photo where productID=@pid";

                SqlCommand cmd = new SqlCommand(qry, con.getConnection());

                cmd.Parameters.AddWithValue("@name", prd.name);
                cmd.Parameters.AddWithValue("@make", prd.make);
                cmd.Parameters.AddWithValue("@type", prd.productType);
                cmd.Parameters.AddWithValue("@qty", prd.qty);
                cmd.Parameters.AddWithValue("@bp", prd.buying_price);
                cmd.Parameters.AddWithValue("@sp", prd.selling_Price);
                cmd.Parameters.AddWithValue("@photo", prd.photo);
                cmd.Parameters.AddWithValue("@pid", prd.productID);

                cmd.ExecuteNonQuery();
                temp = true;

            }
            catch (Exception dsa)
            {

                throw;
            }

            if (temp == true) return true;
            else return false;


        }

        public bool deleteProduct(int id)
        {

            bool temp = false;

            DataLayer.dbConnect con = new DataLayer.dbConnect();
            con.openConnection();

            try
            {
                string qd = "delete tbl_product where productID=@id";

                SqlCommand cmd = new SqlCommand(qd, con.getConnection());

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();

                temp = true;

            }
            catch (Exception ui)
            {

                throw;
            }

            if (temp == true) return true;
            else return false;

               
        }
    }
}
