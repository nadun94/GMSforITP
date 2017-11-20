using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace GymMSystem.Buisness_Logic
{
    class feeRepository
    {

        public void paymentCalculation(fee f, gymMember g)
        {

            if (string.IsNullOrWhiteSpace(f.lastVPaymentDate))
            {
                f.lastVPaymentDate = g.joinedDate;
            }
        }
        public bool addFee(fee f,gymMember g)
        {
            try
            {


                paymentCalculation(f, g);


                DataLayer.dbConnect dbfee = new DataLayer.dbConnect();
                dbfee.openConnection();

                string qf1 = "insert into tbl_fee (amount,service,valde_date,paid_date,paid_time,memberID) values(@amount,@service,@valid_date,@paid_date,@paidTime,@memerID)";

                SqlCommand cmd1 = new SqlCommand(qf1, dbfee.getConnection());

               
                cmd1.Parameters.AddWithValue("@amount", f.newAmount);
                cmd1.Parameters.AddWithValue("@service", f.service);
                cmd1.Parameters.AddWithValue("@valid_date", f.PaymentvalidDate);
                cmd1.Parameters.AddWithValue("@paid_date", f.paidDate);
                cmd1.Parameters.AddWithValue("@memerID", f.memberID);
                cmd1.Parameters.AddWithValue("@paidTime", f.paidTime);
                

                cmd1.ExecuteNonQuery();
                return true;
            }
            catch (Exception ext)
            {
                MessageBox.Show(ext.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
           
        }
        public bool searchMemberDerailsFor_fee(gymMember gm)
        {


            try
            {
                DataLayer.dbConnect dbmem_seach = new DataLayer.dbConnect();
                dbmem_seach.openConnection();
                bool temp = false;
                string query1 = "SELECT * FROM tbl_member WHERE regNo=@reg OR name=@name OR nic=@nic";

                SqlCommand cmd1 = new SqlCommand(query1, dbmem_seach.getConnection());

                cmd1.Parameters.AddWithValue("@reg", gm.MemberID);
                cmd1.Parameters.AddWithValue("@name", gm.name);
                cmd1.Parameters.AddWithValue("@nic", gm.nic);

                DataTable dtq = new DataTable();
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
           
                da1.Fill(dtq);
             
                if (dtq.Rows.Count > 0)
                {

                    gm.MemberID = int.Parse(dtq.Rows[0]["regNo"].ToString());
                    gm.name = dtq.Rows[0]["name"].ToString();
                    gm.nic = dtq.Rows[0]["nic"].ToString();
                  
                   // gm.addresss = dtq.Rows[0]["address"].ToString();
                  //  gm.phone = int.Parse(dtq.Rows[0]["phone"].ToString());

                    temp = true;
                }
              
                string query2 = "SELECT * FROM tbl_gymMember WHERE  memberID=@id";


                SqlCommand cmd2 = new SqlCommand(query2, dbmem_seach.getConnection());
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable();


                cmd2.Parameters.AddWithValue("@id", gm.MemberID);
                da2.Fill(dt2);
                bool temp1 = false;

                if (dt2.Rows.Count > 0)
                { 
                   
                    gm.paymentPlan = dt2.Rows[0]["payment_plan"].ToString();
                   
                    temp1 = true;
                }


                if (temp == true && temp1 == true)
                {
                    return true;

                }
                else
                {
                    return false;

                }

              

            }
            catch (Exception er)
            {

                throw;
            }

        }

        public bool checkPaymentDetails(fee f)
        {

            DataLayer.dbConnect fpay = new DataLayer.dbConnect();
            fpay.openConnection();
            
            string qf = "select  * from tbl_fee where memberID=@id and feeID = (select max(feeID) from tbl_fee) ";

            SqlCommand cmdf = new SqlCommand(qf, fpay.getConnection());
            cmdf.Parameters.AddWithValue("@id", f.memberID);
            DataTable dtx = new DataTable();
            SqlDataAdapter daf = new SqlDataAdapter(cmdf);
            bool testf1 = false;
            daf.Fill(dtx);

            if (dtx.Rows.Count > 0)
            {
                f.LastPaid_amount = double.Parse(dtx.Rows[0]["amount"].ToString());
                f.service = dtx.Rows[0]["service"].ToString();
                f.lastVPaymentDate = dtx.Rows[0]["valde_date"].ToString();
                f.lastPaidDate = dtx.Rows[0]["paid_date"].ToString();
                f.lastPaidTime = dtx.Rows[0]["paid_time"].ToString();

                testf1 = true;
            }

            if (testf1 == true)
            {
                return true;
            }
            else
            {
               
                return false;
            }

            
        }
        
        public DataTable getPaymentPendingList()
        {
            try
            {

                DataLayer.dbConnect conrep1 = new DataLayer.dbConnect();
                conrep1.openConnection();

                string qrep1 = "SELECT * FROM vw_paymentPending";

                SqlCommand cmdrep1 = new SqlCommand(qrep1, conrep1.getConnection());

                SqlDataAdapter darep1 = new SqlDataAdapter(cmdrep1);


                DataTable dtrep1 = new DataTable();

                darep1.Fill(dtrep1);

                return dtrep1;

            }
            catch (Exception erep)
            {

                throw;
            }
        }

        public DataTable search_aerobic_fee(int memberID,string nic )
        {
            DataTable dt = new DataTable();
            try
            {
                DataLayer.dbConnect con = new DataLayer.dbConnect();
                con.openConnection();
                string q = "select * from view_aerobic_mem_Fee where memberID=@mid or nic=@nic";
                SqlCommand cmd = new SqlCommand(q, con.getConnection());

                cmd.Parameters.AddWithValue("@mid", memberID);
                cmd.Parameters.AddWithValue("@nic", nic);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);

            }

            catch (Exception ffg)
            {

                throw;
            }

            return dt;
        }

       // public fee calcFee_aerobic()
            
    }
}
