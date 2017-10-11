using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace GymMSystem.Interfaces
{
    public partial class Members : MetroForm
    {
        public Members()
        {
            InitializeComponent();
        }

        private void Members_Load(object sender, EventArgs e)
        {

        }

        public bool validateMemeber()
        {
            Buisness_Logic.validation val = new Buisness_Logic.validation();
            // bool status = false;

            if (val.IsWord(txtM_name.Text, "Name"))
            {



                if (val.IsAddress(txtM_address.Text))
                {

                    if (val.IsPhone(txtM_phone.Text))
                    {
                        if (val.IsEmail1(txtM_email.Text))
                        {

                            if (val.IsHeight(txtM_height.Text))
                            {

                                if (val.IsWeight(txtM_weight.Text))
                                {
                                    if (picuturebox_member.Image != null) return true;

                                    else return false;
                                }
                                else return false;
                            }
                            else return false;
                        }
                        else return false;
                    }
                    else return false;





                }

                else return false;





            }

            else return false;



        }


        private void btnM_save_Click(object sender, EventArgs e)
        {
            try
            {

                if (validateMemeber())
                {

                    //initialize image

                    MemoryStream memt1p1 = new MemoryStream();
                    picuturebox_member.Image.Save(memt1p1, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] photo_memt1 = memt1p1.ToArray();

                    //******************************************



                    // create gymMember object 
                    Buisness_Logic.gymMember mem = new Buisness_Logic.gymMember();

                    //*******************************************

                    // set values to gymMember class
                    mem.name = txtM_name.Text;
                    mem.dob = dateTimePickerMem.Value.ToShortDateString();
                    mem.gender = cmbM_gender.SelectedItem.ToString();
                    mem.phone = int.Parse(txtM_phone.Text);
                    mem.addresss = txtM_address.Text;
                    mem.nic = txtM_nic.Text;

                    mem.height = double.Parse(txtM_height.Text);
                    mem.weight = double.Parse(txtM_weight.Text);
                    mem.email = txtM_email.Text;
                    mem.photo = photo_memt1;
                    mem.paymentPlan = cmbM_paymentPlan.SelectedItem.ToString();
                    mem.fatLevel = double.Parse(txtM_fat.Text);

                    //**********************************************






                    Buisness_Logic.gymMemberRepository gr = new Buisness_Logic.gymMemberRepository();


                    if (gr.save(mem))
                    {
                        MessageBox.Show("Success", "Data Insertion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtM_memID.Text = mem.MemberID.ToString();
                        txtM_bmiratio.Text = mem.BMIratio.ToString();
                    }


                }






            }

            catch (Exception exm1)
            {
                MessageBox.Show(exm1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_mem_browse_Click(object sender, EventArgs e)
        {
            try
            {
                openFIleDialog_mem.Filter = "Image files | *.jpg; *.PNG; *.gif; *.BMP";
                DialogResult drMem1 = openFIleDialog_mem.ShowDialog();

                if (drMem1 == DialogResult.OK)
                {
                    picuturebox_member.SizeMode = PictureBoxSizeMode.StretchImage;
                    picuturebox_member.Image = Image.FromFile(openFIleDialog_mem.FileName);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void btnMemHme_Click(object sender, EventArgs e)
        {
            Main hm = new Main();
            this.Hide();
            hm.Show();

        }

        private void btnM_clear_Click(object sender, EventArgs e)
        {

            txtM_height.Text = "";
            txtM_name.Text = "";
            txtM_nic.Text = "";
            txtM_phone.Text = "";
            txtM_weight.Text = "";
            txtM_email.Text = "";
            txtM_bmiratio.Text = "";
            cmbM_gender.SelectedItem = null;
            cmbM_paymentPlan.SelectedItem = null;
            picuturebox_member.Image = null;
            txtM_fat.Text = "";
            txtM_name.Focus();
            txtM_address.Text = "";
        }

        private void btnMemHme_Click_1(object sender, EventArgs e)
        {
            Main hm = new Main();
            this.Hide();
            hm.Show();

        }

        private void btnM3_browse_Click(object sender, EventArgs e)
        {
            try
            {
                openFIleDialog_mem.Filter = "Image files | *.jpg; *.PNG; *.gif; *.BMP";
                DialogResult drMem1 = openFIleDialog_mem.ShowDialog();

                if (drMem1 == DialogResult.OK)
                {
                    pictureBoxM3.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBoxM3.Image = Image.FromFile(openFIleDialog_mem.FileName);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private bool validate_search()
        {

            if (txtM3_memID.Text.Trim().Length == 0 && txtM3_name.Text.Trim().Length == 0 && txtM3_nic.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter Name or MemberID or NIC to search Member.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;

            }
            else
            {

                if ((!Regex.Match(txtM3_name.Text, "^[a-zA-Z][a-zA-Z\\s]+$").Success) && ((txtM3_memID.Text.Trim().Length == 0) && (txtM3_nic.Text.Trim().Length == 0)))
                {
                    MessageBox.Show("Please enter Name in correct format.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;

                }
                else if (!txtM3_nic.Text.ToString().All(char.IsLetterOrDigit) && (txtM3_memID.Text.Trim().Length == 0) && txtM3_memID.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Please enter NIC in correct format.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else return true;
            }

        }
        private void clearMSearch()
        {
           // txtMF_amount.Text = "";
            txtM3_bmi.Text = "";
            txtm3_dob.Text = "";
            txtM3_fatLevel.Text = "";
            txtM3_height.Text = "";
            txtM3_memID.Text = "";
            txtM3_name.Text = "";
            txtM3_nic.Text = "";
            txtmsemail.Text = "";
            txtM3_phone.Text = "";
            txtM3_weight.Text = "";
            cmbM3_gender.SelectedItem = null;
            cmbM3_paymentpaln.SelectedItem = null;
            pictureBoxM3.Image = null;
            cmbM3_paymentpaln.Refresh();
            cmbM_gender.Refresh();
            txtM_address.Text = "";
            txtmsearch_address.Text = "";


        }
        private void btnM3_Search_Click(object sender, EventArgs e)
        {

            try
            {
                // Buisness_Logic.validation val3 = new Buisness_Logic.validation();


                if (validate_search())
                {

                    Buisness_Logic.gymMemberRepository gr_search = new Buisness_Logic.gymMemberRepository();

                    var gm = gr_search.search((string.IsNullOrEmpty(txtM3_memID.Text) ? 0 : int.Parse(txtM3_memID.Text)), txtM3_name.Text.ToString(), txtM3_nic.Text.ToString());


                    if (gm.MemberID == 0)
                    {
                        clearMSearch();
                    }
                    else
                    {
                        txtM3_memID.Text = gm.MemberID.ToString();
                        txtM3_name.Text = gm.name;
                        txtM3_nic.Text = gm.nic;
                        txtM3_phone.Text = gm.phone.ToString();
                        //  txt.Text = gm.joinedDate;
                        txtM3_fatLevel.Text = gm.fatLevel.ToString();
                        //MemoryStream ms = new MemoryStream(gm.photo);
                        //pictureBoxM3.Image = Image.FromStream(ms);
                        cmbM3_gender.SelectedItem = gm.gender;
                        cmbM3_paymentpaln.SelectedItem = gm.paymentPlan;
                        txtm3_dob.Text = gm.dob;
                        txtM3_height.Text = gm.height.ToString();
                        txtM3_weight.Text = gm.weight.ToString();
                        txtM3_bmi.Text = gm.BMIratio.ToString();
                        txtmsemail.Text = gm.email;
                        txtmsearch_address.Text = gm.addresss;

                        pictureBoxM3.SizeMode = PictureBoxSizeMode.StretchImage;

                        MemoryStream ms1 = new MemoryStream(gm.photo);
                        // ms1.ToArray();
                        ms1.Position = 0;

                        ms1.Read(gm.photo, 0, gm.photo.Length);
                        pictureBoxM3.Image = Image.FromStream(ms1);
                    }


                }







            }
            catch (Exception expo)
            {
                // MessageBox.Show(expo.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // throw;
            }
        }

        private void btnM3_update_Click(object sender, EventArgs e)
        {
            Buisness_Logic.gymMember gm = new Buisness_Logic.gymMember();

            MemoryStream memt1p2 = new MemoryStream();
            pictureBoxM3.Image.Save(memt1p2, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] photo_memt2 = memt1p2.ToArray();

            gm.MemberID = int.Parse(txtM3_memID.Text);
            gm.name = txtM3_name.Text;
            gm.nic = txtM3_nic.Text;
            gm.phone = int.Parse(txtM3_phone.Text);

            gm.fatLevel = double.Parse(txtM3_fatLevel.Text);
            gm.addresss = txtmsearch_address.Text;

            gm.gender = cmbM3_gender.SelectedItem.ToString();
            gm.paymentPlan = cmbM3_paymentpaln.SelectedItem.ToString();
            gm.dob = txtm3_dob.Text;
            gm.height = double.Parse(txtM3_height.Text);
            gm.weight = double.Parse(txtM3_weight.Text);
            gm.photo = photo_memt2;
            gm.email = txtmsemail.Text;

            Buisness_Logic.gymMemberRepository grup = new Buisness_Logic.gymMemberRepository();

            if (grup.updateGymMember(gm))
            {
                MessageBox.Show("Member detail updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnM2delete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtM3_memID.Text))
            {
                try
                {
                    Buisness_Logic.gymMember gmd = new Buisness_Logic.gymMember();

                    gmd.MemberID = int.Parse(txtM3_memID.Text);

                    Buisness_Logic.gymMemberRepository grd = new Buisness_Logic.gymMemberRepository();

                    if (grd.deleteMemeber(gmd))
                    {
                        MessageBox.Show("Record deleted.", "Information.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else
                    {
                        MessageBox.Show("Record delete failed.", "Information.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
                catch (Exception edel)
                {

                    throw;
                }
            }
            else
            {
                MessageBox.Show("Please enter the member ID to delete a record.", "Information.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnM3_clear_Click(object sender, EventArgs e)
        {
            clearMSearch();
        }

        private bool validateFeedatils()
        {
            Buisness_Logic.validation vf = new Buisness_Logic.validation();
            if (string.IsNullOrWhiteSpace(txtMF_memID.Text) && string.IsNullOrWhiteSpace(txtmfNIC.Text) && (string.IsNullOrWhiteSpace(txtMFee_name.Text)))
            {

                MessageBox.Show("Enter Member ID or Name or NIC to find fee payment details.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                if (!txtMF_memID.Text.All(char.IsDigit) && string.IsNullOrWhiteSpace(txtmfNIC.Text) && (string.IsNullOrWhiteSpace(txtMFee_name.Text)))
                {
                    MessageBox.Show("Member Id should include digits.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //  else return true;
                else if ((!txtMFee_name.Text.All(char.IsLetter)) && string.IsNullOrWhiteSpace(txtmfNIC.Text) && string.IsNullOrWhiteSpace(txtMF_memID.Text))
                {
                    MessageBox.Show("Enter name in correct format.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                else if ((!vf.IsNIC(txtmfNIC.Text)) && string.IsNullOrWhiteSpace(txtMF_memID.Text) && (string.IsNullOrWhiteSpace(txtMFee_name.Text)))
                {
                    MessageBox.Show("NIC  is invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                // else return true;


                else return true;


            }
        }
        private Buisness_Logic.gymMember checKFeeUI()
        {
            Buisness_Logic.gymMember gmf = new Buisness_Logic.gymMember();
            try
            {
                if (validateFeedatils())
                {


                    Buisness_Logic.feeRepository frfee = new Buisness_Logic.feeRepository();
                    gmf.MemberID = (string.IsNullOrEmpty(txtMF_memID.Text) ? 0 : int.Parse(txtMF_memID.Text));
                    gmf.nic = txtmfNIC.Text.ToString();
                    gmf.name = txtMFee_name.Text.ToString();


                    bool req1 = frfee.searchMemberDerailsFor_fee(gmf);




                    Buisness_Logic.fee ft = new Buisness_Logic.fee();

                    ft.memberID = gmf.MemberID;
                    //gmf.MemberID = int.Parse(txtMF_memID.Text);
                    //gmf.nic = txtmfNIC.Text;
                    //gmf.name = txtMFee_name.Text;





                    bool req2 = frfee.checkPaymentDetails(ft);
                    if (gmf.MemberID == 0)
                    {
                        clearFee();
                    }
                    else
                    {
                        txtMF_memID.Text = gmf.MemberID.ToString();
                        txtMFee_name.Text = gmf.name;
                        txtmfNIC.Text = gmf.nic;
                        txtMF_payPlan.Text = gmf.paymentPlan;

                    }
                    txtMF_lastValidDate.Text = ft.lastVPaymentDate;
                    txtlstPaidDate.Text = ft.lastPaidDate;
                    txtLastpaidtime.Text = ft.lastPaidTime;
                    txtMF_amount.Text = ft.LastPaid_amount.ToString();
                    txtfservice.Text = ft.service;
                    if (req1 == true && req2 == true)
                    {
                        MessageBox.Show("payment record found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (req1 == true && req2 == false)
                    {

                        txtMF_amount.Text = "";
                        txtMF_lastValidDate.Text = "";
                        txtfservice.Text = "";
                        txtlstPaidDate.Text = "";
                        txtLastpaidtime.Text = "";
                        MessageBox.Show("Member information found. But no payment record found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else
                    {
                        MessageBox.Show("No memeber information found by that Member ID", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        clearFee();

                    }

                }





            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            return gmf;
        }

        private Buisness_Logic.gymMember transporter = null;
        private void btnM3_check_Click(object sender, EventArgs e)
        {

            transporter = checKFeeUI();

        }

        private void clearFee()
        {
            txtMFee_name.Text = "";
            txtmfNIC.Text = "";
            txtMF_amount.Text = "";
            txtMF_lastValidDate.Text = "";
            txtfservice.Text = "";
            txtMF_memID.Text = "";
            txtMF_payPlan.Text = "";

            txtlstPaidDate.Text = "";
            txtLastpaidtime.Text = "";
            txtMF_memID.Focus();


        }

        private void btnMFee_clear1_Click(object sender, EventArgs e)
        {

            clearFee();
        }

        private void btnmfCalcPayment_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMF_memID.Text) || string.IsNullOrWhiteSpace(txtMF_payPlan.Text))
            {
                MessageBox.Show("Please search payment details of a member first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Buisness_Logic.fee fee2 = new Buisness_Logic.fee();

                fee2.service = "Gym";
                fee2.lastVPaymentDate = txtMF_lastValidDate.Text;
                fee2.memberID = int.Parse(txtMF_memID.Text);
                fee2.paymentPlan = txtMF_payPlan.Text;
                Buisness_Logic.feeRepository fr = new Buisness_Logic.feeRepository();
                fr.paymentCalculation(fee2, transporter);


                txtMFnewpayemnt.Text = fee2.newAmount.ToString();
                txtPaymentValidfor.Text = fee2.PaymentvalidDate;
            }
        }

        private void btnMF_addfee_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMF_memID.Text))
            {
                MessageBox.Show("Please search payment details of a member first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Buisness_Logic.fee fee1 = new Buisness_Logic.fee();

                fee1.paymentPlan = txtMF_payPlan.Text;
                // fee1.LastPaid_amount = double.Parse(txtMFnewpayemnt.Text);
                fee1.service = "Gym";
                fee1.lastVPaymentDate = txtMF_lastValidDate.Text;
                fee1.memberID = int.Parse(txtMF_memID.Text);





                Buisness_Logic.feeRepository fr = new Buisness_Logic.feeRepository();
                if (fr.addFee(fee1, transporter))
                {
                    txtMFnewpayemnt.Text = fee1.newAmount.ToString();
                    txtPaidDate.Text = fee1.paidDate;
                    txtPaidTIme.Text = fee1.paidTime;
                    txtPaymentValidfor.Text = fee1.PaymentvalidDate;



                    MessageBox.Show("Payment Updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnFee_clear_Click(object sender, EventArgs e)
        {

            txtPaymentValidfor.Text = "";
            txtPaidDate.Text = "";
            txtPaidTIme.Text = "";
            txtMFnewpayemnt.Text = "";
        }

        private void bntMem4_checkPp_Click(object sender, EventArgs e)
        {

            try
            {
                Buisness_Logic.feeRepository fr = new Buisness_Logic.feeRepository();

                dataGridPayementPending.DataSource = fr.getPaymentPendingList();
                //dataGridPayementPending.dataB






            }
            catch (Exception ert)
            {

                throw;
            }
        }
    }
    }

