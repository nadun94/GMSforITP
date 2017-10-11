using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

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
    }
}
