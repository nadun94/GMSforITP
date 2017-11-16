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
    class AreobicMemberRepository
    {

        public bool addOtherMembers_notExist(Buisness_Logic.AreobicMember am)
        {
          
            DataLayer.dbConnect con = new DataLayer.dbConnect();
            con.openConnection();
            SqlTransaction trn1 = con.getConnection().BeginTransaction();
            bool temp1 = false, status = true;

            try
            {
                string qt1 = "select * from tbl_member where name=@name and nic=@nic";

                SqlCommand qt = new SqlCommand(qt1, con.getConnection());

                DataTable dtw = new DataTable();
                SqlDataAdapter daw = new SqlDataAdapter(qt);

                qt.Parameters.AddWithValue("@name", am.name);
                qt.Parameters.AddWithValue("@nic", am.nic);

                qt.Transaction = trn1;
                daw.Fill(dtw);

                if (dtw.Rows.Count > 0)
                {
                    status = false;
                }
                if (status == true)
                { //qery one 
                    string q1 = "Insert into tbl_member(name, dob,address,nic,gender,phone) values (@name, @dob,@address,@nic,@gender,@phone)";

                    SqlCommand cmd1 = new SqlCommand(q1, con.getConnection());
                    cmd1.Transaction = trn1;

                    cmd1.Parameters.AddWithValue("@name", am.name);
                    cmd1.Parameters.AddWithValue("@dob", am.dob);
                    cmd1.Parameters.AddWithValue("@address", am.addresss);
                    cmd1.Parameters.AddWithValue("@nic", am.nic);
                    cmd1.Parameters.AddWithValue("@gender", am.gender);
                    cmd1.Parameters.AddWithValue("@phone", am.phone);


                    cmd1.ExecuteNonQuery();

                    //query two

                    string q2 = "SELECT regNo FROM tbl_member WHERE name=@name AND nic=@nic";

                    SqlCommand cmdx = new SqlCommand(q2, con.getConnection());
                    SqlDataAdapter da = new SqlDataAdapter(cmdx);
                    DataTable dt = new DataTable();

                    cmdx.Transaction = trn1;
                    cmdx.Parameters.AddWithValue("@name", am.name);
                    cmdx.Parameters.AddWithValue("@nic", am.nic);

                    da.Fill(dt);
                
                    if (dt.Rows.Count > 0)
                    {
                        am.MemberID = int.Parse(dt.Rows[0]["regNo"].ToString());

                    }


                    string q3 = "INSERT INTO tbl_areobic_member VALUES (@memid, @stype)";

                    SqlCommand cmd2 = new SqlCommand(q3, con.getConnection());
                    cmd2.Transaction = trn1;
                    cmd2.Parameters.AddWithValue("@memid", am.MemberID);
                    cmd2.Parameters.AddWithValue("@stype", am.service_type);

                    cmd2.ExecuteNonQuery();
                    trn1.Commit();

                    temp1 = true;

                }
                else
                {
                    MessageBox.Show("This member already exists.", "Infromation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            catch (Exception exareo1)
            {

                throw;
            }

            if (temp1 == true) return true;
            else return false;


        




    }
        public bool addOtherMembers_Exist(Buisness_Logic.AreobicMember am)
        {

            DataLayer.dbConnect con = new DataLayer.dbConnect();
            con.openConnection();
           
            bool temp1 = false;

            try
            {

                string q2 = "INSERT INTO tbl_areobic_member VALUES (@memid, @stype)";

                SqlCommand cmd2 = new SqlCommand(q2, con.getConnection());

                cmd2.Parameters.AddWithValue("@memid", am.MemberID);
                cmd2.Parameters.AddWithValue("@stype", am.service_type);

                cmd2.ExecuteNonQuery();
                

                temp1 = true;

            }
            catch (Exception exareo1)
            {

                throw;
            }

            if (temp1 == true) return true;
            else return false;




        }

        public bool updateOtherMembers(AreobicMember arem)
        {
            bool temp = false;
            DataLayer.dbConnect con = new DataLayer.dbConnect();
            con.openConnection();
           SqlTransaction trn = con.getConnection().BeginTransaction();
            try
            {
                //qery one 
                string q1 = "update tbl_member set name=@name, dob=@dob,address=@address,nic=@nic,gender=@gender,phone=@phone where regNo=@regNo"; 

                SqlCommand cmd1 = new SqlCommand(q1, con.getConnection());

                cmd1.Parameters.AddWithValue("@regNo", arem.MemberID);
                cmd1.Parameters.AddWithValue("@name", arem.name);
                cmd1.Parameters.AddWithValue("@dob", arem.dob);
                cmd1.Parameters.AddWithValue("@address", arem.addresss);
                cmd1.Parameters.AddWithValue("@nic", arem.nic);
                cmd1.Parameters.AddWithValue("@gender", arem.gender);
                cmd1.Parameters.AddWithValue("@phone", arem.phone);

             
                cmd1.Transaction = trn;
                cmd1.ExecuteNonQuery();

                //qery two 
                string q2 = "update tbl_areobic_member set  service_type=@st where memberID=@regNo";

                SqlCommand cmd2 = new SqlCommand(q2, con.getConnection());

                cmd2.Parameters.AddWithValue("@regNo", arem.MemberID);
                cmd2.Parameters.AddWithValue("@st", arem.service_type);

               cmd2.Transaction = trn;

                cmd2.ExecuteNonQuery();
                trn.Commit();
                con.closeConnection();

                temp = true;

            }
            catch (Exception dd) 
            {
             trn.Rollback();
                throw;
            }

            if (temp == true) return true;
            else return false;
           

           


        }


        public bool deleteAreobicMem(int regNo)
        {
            bool temp = false;
            
            DataLayer.dbConnect con = new DataLayer.dbConnect();
            con.openConnection();
            SqlTransaction trn = con.getConnection().BeginTransaction();

            try
            {
                DataLayer.dbConnect conx = new DataLayer.dbConnect();
                conx.openConnection();
                //check gym member 
                string q = "select * from tbl_gymMember where memberID=@regNo";
                SqlCommand cmd = new SqlCommand(q, conx.getConnection());

                cmd.Parameters.AddWithValue("@regNo", regNo);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                string qx = "delete tbl_areobic_member where memberID=@regNo";

                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    // this means the member is part of fitness center also not only a areobic member
                   
                    SqlCommand cmdx = new SqlCommand(qx, conx.getConnection());

                    cmdx.Parameters.AddWithValue("@regNo", regNo);
                    cmdx.ExecuteNonQuery();
                    temp = true;
                    conx.closeConnection();
                }
                else
                {


                    SqlCommand cmd2 = new SqlCommand(qx, con.getConnection());

                    cmd2.Parameters.AddWithValue("@regNo", regNo);
                    cmd2.Transaction = trn;
                    cmd2.ExecuteNonQuery();

                    string q1 = "delete tbl_member where regNo=@regNo";

                    SqlCommand cmd1 = new SqlCommand(q1, con.getConnection());

                    cmd1.Parameters.AddWithValue("@regNo", regNo);
                    cmd1.Transaction = trn;
                    cmd1.ExecuteNonQuery();

                    trn.Commit();
                    temp = true;
                }

               
            }
            catch (Exception fds)
            {
                trn.Rollback();

                throw;
            }


            if (temp == true) return true;
            else return false;


        }

        public void searchAerobicMem(int id,string name, string nic,  Buisness_Logic.AreobicMember arm)
        {


            bool temp = false, temp1 = false;
            DataLayer.dbConnect cons = new DataLayer.dbConnect();
            cons.openConnection();
            SqlTransaction trn = cons.getConnection().BeginTransaction();

            try
            {


                //qery one 
                string q1 = "select * from tbl_member where regNo=@regNo or nic=@nic or name=@name";

                SqlCommand cmd1 = new SqlCommand(q1,cons.getConnection());
                cmd1.Transaction = trn;
                cmd1.Parameters.AddWithValue("@regNo", id);
                cmd1.Parameters.AddWithValue("@nic", nic);
                cmd1.Parameters.AddWithValue("@name", name);

                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();

                da1.Fill(dt1);

                if (dt1.Rows.Count > 0)
                {

                    arm.MemberID = int.Parse(dt1.Rows[0]["regNo"].ToString());
                    arm.name = dt1.Rows[0]["name"].ToString();
                    arm.nic = dt1.Rows[0]["nic"].ToString();
                    arm.dob = dt1.Rows[0]["dob"].ToString();
                    arm.gender = dt1.Rows[0]["gender"].ToString();
                    arm.addresss = dt1.Rows[0]["address"].ToString();
                    arm.phone = dt1.Rows[0]["phone"].ToString();

                    temp = true;

                }

                //query 2

                string q2 = "select * from tbl_areobic_member where memberID=@memberID";

                SqlCommand cmd2 = new SqlCommand(q2, cons.getConnection());

                cmd2.Transaction = trn;
                cmd2.Parameters.AddWithValue("@memberID", arm.MemberID);

                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable();

                da2.Fill(dt2);

                if (dt2.Rows.Count > 0)
                {
                    arm.service_type = dt2.Rows[0]["service_type"].ToString();
                    temp1 = true;
                }
                trn.Commit();
            }
            catch (Exception nex)
            {

                trn.Rollback();
                throw;
            }

            if (temp1 == true && temp == true)
            {
                MessageBox.Show("Record found. The member is a already registered Areobic member.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            else if(temp==true && temp1 == false)
            {
                MessageBox.Show("Record found. The member is already registered Gym member.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No Record found..", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);






        }

                    
        public bool searchAerobicMemOnly(int memID, string name, string nic, AreobicMember arm)
        {
            DataLayer.dbConnect con = new DataLayer.dbConnect();
            con.openConnection();
            bool temp = false;

            try
            {
                string q1 = "select * from veiw_areobicMember where memberID=@regNo or nic=@nic or name=@name";

                SqlCommand cmd1 = new SqlCommand(q1, con.getConnection());

                cmd1.Parameters.AddWithValue("@regNo", memID);
                cmd1.Parameters.AddWithValue("@nic", nic);
                cmd1.Parameters.AddWithValue("@name", name);

                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();

                da1.Fill(dt1);

                if (dt1.Rows.Count > 0)
                {

                    arm.MemberID = int.Parse(dt1.Rows[0]["memberID"].ToString());
                    arm.name = dt1.Rows[0]["name"].ToString();
                    arm.nic = dt1.Rows[0]["nic"].ToString();
                    arm.dob = dt1.Rows[0]["dob"].ToString();
                    arm.gender = dt1.Rows[0]["gender"].ToString();
                    arm.addresss = dt1.Rows[0]["address"].ToString();
                    arm.phone = dt1.Rows[0]["phone"].ToString();
                    arm.service_type = dt1.Rows[0]["service_type"].ToString();

                    temp = true;

                }

            }
            catch (Exception df)
            {

                throw;
            }

            if (temp == true) return true;
            else return false;
        }


    }
}
