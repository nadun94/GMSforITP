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
    class EmployeeRepository
    {

        public bool addEmployee(Buisness_Logic.employee emp)
        {

            bool temp1 = false;
            try
            {
                DataLayer.dbConnect con1 = new DataLayer.dbConnect();
                con1.openConnection();

                string q1 = "insert into tbl_employee (name,dob,nic,address,gender,email,phone,position,profile,joinedDate,photo) values (@name,@dob,@nic,@address,@gender,@email,@phone,@position,@profile,@jdate,@photo)";

                SqlCommand cmd1 = new SqlCommand(q1, con1.getConnection());

                cmd1.Parameters.AddWithValue("@name", emp.name);
                cmd1.Parameters.AddWithValue("@dob", emp.dob);
                cmd1.Parameters.AddWithValue("@nic", emp.nic);
                cmd1.Parameters.AddWithValue("@address", emp.address);
                cmd1.Parameters.AddWithValue("@gender", emp.gender);
                cmd1.Parameters.AddWithValue("@email", emp.email);
                cmd1.Parameters.AddWithValue("@phone", emp.phone);
                cmd1.Parameters.AddWithValue("@position", emp.position);
                cmd1.Parameters.AddWithValue("@profile", emp.profile);
                cmd1.Parameters.AddWithValue("@photo", emp.photo);
                cmd1.Parameters.AddWithValue("@jdate", emp.joinedDate);

                cmd1.ExecuteNonQuery();
                temp1 = true;

            }
            catch (Exception ew)
            {

                throw;
            }


            if (temp1 == true) return true;
            else return false;
            



        }


        public bool searchEMP(Buisness_Logic.employee emp)
        {

            try
            {
                DataLayer.dbConnect dbemp_seach = new DataLayer.dbConnect();
                dbemp_seach.openConnection();
                bool temp = false;
                string query1 = "SELECT * FROM tbl_employee WHERE empID=@reg OR name=@name OR nic=@nic";

                SqlCommand cmd1 = new SqlCommand(query1, dbemp_seach.getConnection());

                cmd1.Parameters.AddWithValue("@reg", emp.empID);
                cmd1.Parameters.AddWithValue("@name", emp.name);
                cmd1.Parameters.AddWithValue("@nic", emp.nic);

          
                DataTable dtq = new DataTable();
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
   
                da1.Fill(dtq);

                if (dtq.Rows.Count > 0)
                {

                   emp.empID = int.Parse(dtq.Rows[0]["empID"].ToString());
                    emp.name = dtq.Rows[0]["name"].ToString();
                    emp.nic = dtq.Rows[0]["nic"].ToString();
                    emp.dob = dtq.Rows[0]["dob"].ToString();
                    emp.gender = dtq.Rows[0]["gender"].ToString();
                    emp.address = dtq.Rows[0]["address"].ToString();
                    emp.phone = dtq.Rows[0]["phone"].ToString();
                    emp.email = dtq.Rows[0]["email"].ToString();
                    emp.position = dtq.Rows[0]["position"].ToString();
                    emp.profile = dtq.Rows[0]["profile"].ToString();
                    emp.photo = (byte[])dtq.Rows[0]["photo"];
                    emp.joinedDate = dtq.Rows[0]["joinedDate"].ToString();


                    temp = true;
                }


                if (temp == true) return true;
                else return false;
            }
            catch (Exception ert)
            {

                throw;
            }
        }

        public bool update_employee(employee g)
        {
            bool tup = false;

            try
            {
                DataLayer.dbConnect dbu = new DataLayer.dbConnect();
         
                dbu.openConnection();

                SqlCommand cmdu = null;

                string qup = "UPDATE tbl_employee set name=@name, dob=@dob, nic=@nic, address=@address , gender=@gender,email=@email, phone=@phone , position=@position ,profile=@profile,joinedDate=@jdate,photo=@photo where empID=@reg ";

                cmdu = new SqlCommand(qup, dbu.getConnection());
                cmdu.Parameters.AddWithValue("@name", g.name);
                cmdu.Parameters.AddWithValue("@dob", g.dob);
                cmdu.Parameters.AddWithValue("@address", g.address);
                cmdu.Parameters.AddWithValue("@nic", g.nic);
                cmdu.Parameters.AddWithValue("@gender", g.gender);
                cmdu.Parameters.AddWithValue("@phone", g.phone);
                cmdu.Parameters.AddWithValue("@reg", g.empID);
                cmdu.Parameters.AddWithValue("@email", g.email);
                cmdu.Parameters.AddWithValue("@position", g.position);
                cmdu.Parameters.AddWithValue("@photo", g.photo);
                cmdu.Parameters.AddWithValue("@profile", g.profile);
                cmdu.Parameters.AddWithValue("@jdate", g.joinedDate);

                cmdu.ExecuteNonQuery();

                tup = true;




            }
            catch (Exception epu)
            {
                // trnup.Rollback();
                MessageBox.Show(epu.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                throw;
            }

            if (tup == true) return true;
            else return false;

        }

        public bool deleteEmployee(int emp)
        {
            bool tempdel = false;
            DataLayer.dbConnect cond = new DataLayer.dbConnect();
            cond.openConnection();
 
            try
            {


                string qd = "DELETE tbl_employee WHERE empID=@mem ";

                SqlCommand cmdel = new SqlCommand(qd, cond.getConnection());

                cmdel.Parameters.AddWithValue("@mem", emp);
            

                cmdel.ExecuteNonQuery();


               
                cond.closeConnection();

                tempdel = true;

            }
            catch (Exception edel)
            {
         
                throw;
            }

            if (tempdel == true) return true;
            else return false;
        }
    }
}
