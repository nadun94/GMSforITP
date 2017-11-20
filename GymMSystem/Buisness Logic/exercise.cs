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
    class exercise
    {
        public string name { get; set; }
        public string description { get; set; }
        public string  type { get; set; }
        public string equipment { get; set; }
        public string additional_equipment { get; set; }

        public bool addExercise()
        {
            try
            {
                DataLayer.dbConnect myDb = new DataLayer.dbConnect();
                myDb.openConnection();
                string qry = ("INSERT INTO tbl_exercise VALUES (@a,@b,@type,@equi,@add)");
                SqlCommand cmd = new SqlCommand(qry, myDb.getConnection());
                cmd.Parameters.AddWithValue("@a", name);
                cmd.Parameters.AddWithValue("@b", description);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@equi", equipment);
                cmd.Parameters.AddWithValue("@add", additional_equipment);
                cmd.ExecuteNonQuery();
                myDb.closeConnection();
                return true;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
    }
}
