using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace GymMSystem.Buisness_Logic
{
    class workout_repository
    {

        public bool addWorkouts(Buisness_Logic.workout wo)
        {
            bool temp = false;
            try
            {
                DataLayer.dbConnect con1 = new DataLayer.dbConnect();

                con1.openConnection();

                string q1 = "INSERT INTO tbl_workout  values (@name,@type,@bmi_f,@fat_f,@interval,@bmi_t,@fat_t)";
                //(w_name,type, BMI_rate,fat_level,repeats,interval_days)
                SqlCommand cmd1 = new SqlCommand(q1, con1.getConnection());

                cmd1.Parameters.AddWithValue("@name", wo.workout_name);
                cmd1.Parameters.AddWithValue("@type",wo.type);
               //from
                cmd1.Parameters.AddWithValue("@bmi_f",wo.BMI_rate_from);
                cmd1.Parameters.AddWithValue("@fat_f",wo.fat_level_from);
                //to
                cmd1.Parameters.AddWithValue("@bmi_t", wo.BMI_rate_to);
                cmd1.Parameters.AddWithValue("@fat_t", wo.fat_level_to);

               
                cmd1.Parameters.AddWithValue("@interval",wo.interval_days);

                cmd1.ExecuteNonQuery();


                temp = true;
                
            }
            catch (Exception exr)
            {

                throw;
            }

            if (temp == true) return true;
            else return false;

        }


        // add exercises to given workout

            public bool addExercises_to_workout(Buisness_Logic.workout wo)
        {
            bool temp = false;
            try
            {
                DataLayer.dbConnect con1 = new DataLayer.dbConnect();

                con1.openConnection();

                string q1 = "INSERT INTO tbl_workout_exercise values (@name,@ex_name,@rep)";

                SqlCommand cmd1 = new SqlCommand(q1, con1.getConnection());

                cmd1.Parameters.AddWithValue("@name", wo.workout_name);
                cmd1.Parameters.AddWithValue("@ex_name", wo.exName);
                cmd1.Parameters.AddWithValue("@rep", wo.repeats);


                cmd1.ExecuteNonQuery();


                temp = true;
            }
            catch (Exception fs)
            {

                throw;
            }

            if (temp == true) return true;
            else return false;
        }


        public bool updateWorkouts(Buisness_Logic.workout wo1)
        {

            bool temp = false;

            try
            {
                DataLayer.dbConnect mydb = new DataLayer.dbConnect();
                mydb.openConnection();

                SqlCommand cmd = null;
                string qry = "UPDATE tbl_workout SET type=@type, BMI_rate=@BMI, fat_level=@fat, repeats=@repeat, interval_days=@interval WHERE w_name=@wname";

                cmd = new SqlCommand(qry, mydb.getConnection());

                cmd.Parameters.AddWithValue("@type",wo1.type);
                //cmd.Parameters.AddWithValue("@BMI",wo1.BMI_rate);
                //cmd.Parameters.AddWithValue("@fat",wo1.fat_level);
                cmd.Parameters.AddWithValue("@repeat",wo1.repeats);
                cmd.Parameters.AddWithValue("@interval",wo1.interval_days);

                cmd.ExecuteNonQuery();

                temp = true;

                return temp;

            }
            catch (Exception exr)
            {
                
                throw;
            }
        }

        public bool searchWorkouts(Buisness_Logic.workout wrk)
        {
            bool temp = false;

            try
            {
                DataLayer.dbConnect workoutSearch= new DataLayer.dbConnect();
                workoutSearch.openConnection();
                
                string query1 = "SELECT * FROM tbl_workout WHERE w_name=@workout";

                SqlCommand cmd1 = new SqlCommand(query1, workoutSearch.getConnection());

                cmd1.Parameters.AddWithValue("@workout", wrk.workout_name);
                DataTable dtq = new DataTable();
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
              //  workout wrk = new workout();
                da1.Fill(dtq);

                if (dtq.Rows.Count > 0)
                {
                    wrk.id = int.Parse(dtq.Rows[0]["w_id"].ToString());
                    wrk.workout_name = dtq.Rows[0]["w_name"].ToString();
                    wrk.type = dtq.Rows[0]["type"].ToString();
                    //wrk.BMI_rate = double.Parse(dtq.Rows[0]["BMI_rate"].ToString());
                    //wrk.fat_level = double.Parse(dtq.Rows[0]["fat_level"].ToString());
                    wrk.repeats = int.Parse(dtq.Rows[0]["repeats"].ToString());
                    wrk.interval_days = dtq.Rows[0]["interval_days"].ToString();
                    

                    temp = true;
                }
                workoutSearch.closeConnection();

               
            }
            catch (Exception exp)
            {

                throw;
            }

            if (temp == true) return true;
            else return false;


        }
        public DataTable searchWorkouts_for_grid()
        {
            
            DataTable dtq = new DataTable();
            try
            {
                DataLayer.dbConnect workoutSearch = new DataLayer.dbConnect();
                workoutSearch.openConnection();

                string query1 = "SELECT * FROM tbl_workout ";

                SqlCommand cmd1 = new SqlCommand(query1, workoutSearch.getConnection());


                
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                //  workout wrk = new workout();
                da1.Fill(dtq);

               
                workoutSearch.closeConnection();


            }
            catch (Exception exp)
            {

                throw;
            }

            return dtq;

        }
    }
}
