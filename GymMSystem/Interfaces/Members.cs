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

            pictureBox_card_mem.Image = new Bitmap(pictureBox_card_mem.Width, pictureBox_card_mem.Height);
        }

        private void datagridm3refresh()
        {
            try
            {
                Buisness_Logic.gymMemberRepository gmrep = new Buisness_Logic.gymMemberRepository();
                dataGridMemedit.DataSource = gmrep.editGymMembers();
                this.dataGridMemedit.Columns[14].Visible = false;
                // txtM3_memID.Text= dataGridMemedit.SelectedRows[0].Cells[0].Value + string.Empty;


            }
            catch (Exception yt)
            {

                throw;
            }
        }
        private void Members_Load(object sender, EventArgs e)
        {

          //  this.reportViewer1.RefreshReport();
        }
        private bool validateAddMember()
        {
            Buisness_Logic.validation val1 = new Buisness_Logic.validation();
            bool phone, email, address, name, nic,gender,pp,dob,height,weight;

            //phone
            if (!val1.IsPhone(txtM_phone.Text))
            {
                this.errorProvider1.SetError(txtM_phone, "Phone is invalid.");
                phone = false;
            }
            else
            {
                this.errorProvider1.SetError(txtM_phone, (string)null);
                phone = true;
            }

            //Email

             if  (!val1.IsEmail2(txtM_email.Text)){

                this.errorProvider1.SetError(txtM_email, "Email is invalid.");
                email = false;

            }
            else
            {
                this.errorProvider1.SetError(txtM_email, (string)null);
                email = true;

            }

             //Name
            if (!val1.IsName(txtM_name.Text) && string.IsNullOrWhiteSpace(txtM_name.Text))
            {

                this.errorProvider1.SetError(txtM_name, "Name is invalid.");
                name = false;

            }
            else
            {
                this.errorProvider1.SetError(txtM_name, (string)null);
                name = true;

            }
            //NIC
            if (!val1.IsNIC(txtM_nic.Text) )
            {
                this.errorProvider1.SetError(txtM_nic, "NIC is invalid.");
                nic = false;
            }
            else
            {
                this.errorProvider1.SetError(txtM_nic, (string)null);
                nic = true;
            }
            //address
            if (!val1.IsAddress(txtM_address.Text))
            {
                this.errorProvider1.SetError(txtM_address, "Address is invalid.");
                address = false;
            }
            else
            {
                this.errorProvider1.SetError(txtM_address, (string)null);
                address = true;
            }
            //gender
            if (cmbM_gender.SelectedIndex.Equals(-1))
            {
                this.errorProvider1.SetError(cmbM_gender, "Gender is not selected.");
                gender = false;
            }
            else
            {
                this.errorProvider1.SetError(cmbM_gender, (string)null);
                gender = true;
            }
            //payment plan
            if (cmbM_paymentPlan.SelectedIndex.Equals(-1))
            {
                this.errorProvider1.SetError(cmbM_paymentPlan, "Payment Plan is not selected.");
                pp = false;
            }
            else
            {
                this.errorProvider1.SetError(cmbM_paymentPlan, (string)null);
                pp = true;
            }

            //dob
            if (dateTimePickerMem.Value>= DateTime.Today)
            {
                this.errorProvider1.SetError(dateTimePickerMem, "DOB is invalid.");
                dob = false;
            }
            else
            {
                this.errorProvider1.SetError(dateTimePickerMem, (string)null);
                dob = true;
            }

            //height
            if (!val1.IsHeight(txtM_height.Text))
            {

                this.errorProvider1.SetError(txtM_height, "Height is invalid.");
                height = false;

            }
            else
            {
                this.errorProvider1.SetError(txtM_height, (string)null);
                height = true;

            }

            //weight
            if (!val1.IsWeight(txtM_weight.Text))
            {

                this.errorProvider1.SetError(txtM_weight, "Weight is invalid.");
                weight = false;

            }
            else
            {
                this.errorProvider1.SetError(txtM_weight, (string)null);
                weight = true;

            }

            //**** main returning part
            bool condition = phone == true && email == true && name == true && nic == true && gender == true && height == true && weight == true && address == true && pp == true;
            if (condition) return true;
            else return false;


        }
       

        
       
        private void btnM_save_Click(object sender, EventArgs e)
        {
            try
            {

                if (validateAddMember())
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
                    mem.phone = txtM_phone.Text;
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


            Buisness_Logic.validation val1 = new Buisness_Logic.validation();
            bool  name, nic,memid;

            if (string.IsNullOrWhiteSpace(txtM3_memID.Text) && string.IsNullOrWhiteSpace(txtM3_nic.Text) && string.IsNullOrWhiteSpace(txtM3_name.Text))
            {
                MessageBox.Show("Please enter memberID or NIC or name to search member.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {

                // Member ID
                if (!txtM3_memID.Text.All(char.IsDigit) && !string.IsNullOrWhiteSpace(txtM3_memID.Text))
                {
                    this.errorProvider1.SetError(txtM3_memID, "MemeberID is invalid.");
                    memid = false;
                }
                else
                {
                    this.errorProvider1.SetError(txtM3_memID, (string)null);
                    memid = true;
                }

                //Name
                if (!val1.IsName(txtM3_name.Text) && !string.IsNullOrWhiteSpace(txtM3_name.Text))
                {

                    this.errorProvider1.SetError(txtM3_name, "Name is invalid.");
                    name = false;

                }
                else
                {
                    this.errorProvider1.SetError(txtM3_name, (string)null);
                    name = true;

                }
                //NIC
                if (!val1.IsNIC(txtM3_nic.Text) && !string.IsNullOrWhiteSpace(txtM3_nic.Text))
                {
                    this.errorProvider1.SetError(txtM3_nic, "NIC is invalid.");
                    nic = false;
                }
                else
                {
                    this.errorProvider1.SetError(txtM3_nic, (string)null);
                    nic = true;
                }




                //**** main returning part
                if (memid == true || name == true || nic == true) return true;
                else return false;
            }
            

            



        }
        
        private void clearMSearch()
        {
          
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
            cmbM3_gender.Refresh();
            txtmsearch_address.Text = "";
            txtM3_jdate.Text = "";


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

        private bool validateUpdateMember()
        {
            Buisness_Logic.validation val1 = new Buisness_Logic.validation();
            bool phone, email, address, name, nic, gender, pp, dob, height, weight;

            //phone
            if (!val1.IsPhone(txtM3_phone.Text))
            {
                this.errorProvider1.SetError(txtM3_phone, "Phone is invalid.");
                phone = false;
            }
            else
            {
                this.errorProvider1.SetError(txtM3_phone, (string)null);
                phone = true;
            }

            //Email

            if (!val1.IsEmail2(txtmsemail.Text))
            {

                this.errorProvider1.SetError(txtmsemail, "Email is invalid.");
                email = false;

            }
            else
            {
                this.errorProvider1.SetError(txtmsemail, (string)null);
                email = true;

            }

            //Name
            if (!val1.IsName(txtM3_name.Text) && string.IsNullOrWhiteSpace(txtM3_name.Text))
            {

                this.errorProvider1.SetError(txtM3_name, "Name is invalid.");
                name = false;

            }
            else
            {
                this.errorProvider1.SetError(txtM3_name, (string)null);
                name = true;

            }
            //NIC
            if (!val1.IsNIC(txtM3_nic.Text))
            {
                this.errorProvider1.SetError(txtM3_nic, "NIC is invalid.");
                nic = false;
            }
            else
            {
                this.errorProvider1.SetError(txtM3_nic, (string)null);
                nic = true;
            }
            //address
            if (!val1.IsAddress(txtmsearch_address.Text))
            {
                this.errorProvider1.SetError(txtmsearch_address, "Address is invalid.");
                address = false;
            }
            else
            {
                this.errorProvider1.SetError(txtmsearch_address, (string)null);
                address = true;
            }
            //gender
            if (cmbM3_gender.SelectedIndex.Equals(-1))
            {
                this.errorProvider1.SetError(cmbM3_gender, "Gender is not selected.");
                gender = false;
            }
            else
            {
                this.errorProvider1.SetError(cmbM3_gender, (string)null);
                gender = true;
            }
            //payment plan
            if (cmbM3_paymentpaln.SelectedIndex.Equals(-1))
            {
                this.errorProvider1.SetError(cmbM3_paymentpaln, "Payment Plan is not selected.");
                pp = false;
            }
            else
            {
                this.errorProvider1.SetError(cmbM3_paymentpaln, (string)null);
                pp = true;
            }

            //dob
            DateTime dt;
            if (DateTime.TryParse(txtm3_dob.Text,out dt) && dt > DateTime.Today)
            {
                this.errorProvider1.SetError(txtm3_dob, "DOB is invalid.");
                dob = false;
            }
            else
            {
                this.errorProvider1.SetError(txtm3_dob, (string)null);
                dob = true;
            }

            //height
            if (!val1.IsHeight(txtM3_height.Text))
            {

                this.errorProvider1.SetError(txtM3_height, "Height is invalid.");
                height = false;

            }
            else
            {
                this.errorProvider1.SetError(txtM3_height, (string)null);
                height = true;

            }

            //weight
            if (!val1.IsWeight(txtM3_weight.Text))
            {

                this.errorProvider1.SetError(txtM3_weight, "Weight is invalid.");
                weight = false;

            }
            else
            {
                this.errorProvider1.SetError(txtM3_weight, (string)null);
                weight = true;

            }

            //**** main returning part
            if (phone == true && email == true && name == true && nic == true && gender == true && height == true && address && weight ==true) return true;
            else return false;

        }
        private void btnM3_update_Click(object sender, EventArgs e)
        {

            if (validateUpdateMember())
            {
                Buisness_Logic.gymMember gm = new Buisness_Logic.gymMember();

                MemoryStream memt1p2 = new MemoryStream();
                pictureBoxM3.Image.Save(memt1p2, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] photo_memt2 = memt1p2.ToArray();

                gm.MemberID = int.Parse(txtM3_memID.Text);
                gm.name = txtM3_name.Text;
                gm.nic = txtM3_nic.Text;
                gm.phone = txtM3_phone.Text;

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
                    datagridm3refresh();
                }
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
                        datagridm3refresh();
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

        private void tb_editmem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridMemedit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridMemedit.Rows[e.RowIndex];
                    txtM3_memID.Text = row.Cells[0].Value.ToString();
                    txtM3_bmi.Text = row.Cells[9].Value.ToString();
                    txtm3_dob.Text = row.Cells[2].Value.ToString();
                    txtM3_fatLevel.Text = row.Cells[13].Value.ToString();
                    txtM3_height.Text = row.Cells[10].Value.ToString();
                    txtM3_name.Text = row.Cells[1].Value.ToString();
                    txtM3_nic.Text = row.Cells[4].Value.ToString();
                    txtmsemail.Text = row.Cells[7].Value.ToString();
                    txtM3_phone.Text = row.Cells[6].Value.ToString();
                    txtM3_jdate.Text= row.Cells[8].Value.ToString();
                    txtM3_weight.Text = row.Cells[11].Value.ToString();
                    cmbM3_gender.SelectedItem = row.Cells[5].Value.ToString();
                    cmbM3_paymentpaln.SelectedItem = row.Cells[12].Value.ToString();
                    cmbM3_paymentpaln.Refresh();
                    cmbM_gender.Refresh();
                    txtmsearch_address.Text = row.Cells[3].Value.ToString();

                    byte[] picdg = (byte[])row.Cells[14].Value;
                    pictureBoxM3.SizeMode = PictureBoxSizeMode.StretchImage;

                    MemoryStream msdg1 = new MemoryStream(picdg);
                    msdg1.Position = 0;

                    msdg1.Read(picdg, 0, picdg.Length);
                    pictureBoxM3.Image = Image.FromStream(msdg1);
                    pictureBoxM3.Refresh();

                }
            }
            catch (Exception ecell)
            {

                throw;
            }
        }

        private void metroTabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            datagridm3refresh();
        }

        private void metroLabel21_Click(object sender, EventArgs e)
        {

        }

        private void txtM3_nic_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel46_Click(object sender, EventArgs e)
        {

        }

        private void btn_member_card_Add_Paint(object sender, PaintEventArgs e)
        {
          

        }
         Buisness_Logic.gymMember gmzzz = null;

        private void mebershipCard_writeOn_image()
        {
            var image = new Bitmap(this.pictureBox_card_mem.Width, this.pictureBox_card_mem.Height);
            var font_family = new FontFamily("Tahoma");
            var font = new Font(font_family, 20, FontStyle.Regular, GraphicsUnit.Pixel);
           var solid_brush = new SolidBrush(Color.White);
            var graphics = Graphics.FromImage(image);

            graphics.DrawString("Name : "+gmzzz.name, font, solid_brush, new Point(250, 60));
            graphics.DrawString("Member ID : "+gmzzz.MemberID.ToString(), font, solid_brush, new Point(250, 90));
            graphics.DrawString("Member sice: "+gmzzz.joinedDate, font, solid_brush, new Point(250, 120));

            this.pictureBox_card_mem.Image = image;
            this.pictureBox_card_mem.Refresh();
            pictureBox_card_mem.Update();


        }
        private void pictureBox_card_mem_Paint(object sender, PaintEventArgs e)
        {
            //var font_family = new FontFamily("Tahoma");
            //var font = new Font(font_family, 20, FontStyle.Bold, GraphicsUnit.Pixel);
            //var solid_brush = new SolidBrush(Color.White);

            //e.Graphics.DrawString("Nadun sirimevan", font, solid_brush, new PointF(10, 20));

            //font = new Font(font_family, 14, FontStyle.Regular, GraphicsUnit.Pixel);
            //e.Graphics.DrawString("Hello world", font, solid_brush, new PointF(15, 50));

            //MessageBox.Show("dfsdf");

            //Bitmap bitmap_forCard = new Bitmap(pictureBox_card_mem.Width, pictureBox_card_mem.Height);

            //using (Graphics g = Graphics.FromImage(bitmap_forCard))
            //{


            //    g.DrawImage(pictureBox_card_mem.Image, 0, 0);
            ////    g.DrawImage(pictureBox_card_mem.Image, 380, 30, 100, 100);
            ////    pictureBox_card_mem.Refresh();
            //}

            //pictureBox_card_mem.Image = bitmap_forCard;
            //pictureBox_card_photo.Visible = false;
        }
       
        private void btn_member_card_Add_Click(object sender, EventArgs e)
        {
            mebershipCard_writeOn_image();

            Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
            pictureBox_barcode.Image = barcode.Draw("Member ID: "+txt_memCardID.Text, 50);

            Bitmap bitmap_forCard = new Bitmap(pictureBox_card_mem.Width, pictureBox_card_mem.Height);

            using (Graphics g = Graphics.FromImage(bitmap_forCard))
            {

                pictureBox_barcode.SizeMode = PictureBoxSizeMode.AutoSize;
                g.DrawImage(pictureBox_card_mem.Image, 0, 0);
                g.DrawImage(pictureBox_card_photo.Image, 20, 30, 160, 184);
                g.DrawImage(pictureBox_barcode.Image, 250, 255, 276, 70);
              //  g.DrawImage(pictureBox_logo.Image, 473, 104, 117, 104);
                pictureBox_card_mem.Refresh();
            }

            pictureBox_card_mem.Image = bitmap_forCard;
            pictureBox_card_photo.Visible = false;
            pictureBox_barcode.Visible = false;
            //    Bitmap finalImage = null;
            //    try
            //    {
            //        mebershipCard_writeOn_image();

            //        List<Bitmap> images = new List<Bitmap>();

            //        int width = 0;
            //        int height = 0;
            //        Bitmap b1 = new Bitmap(pictureBox_card_mem.Image);
            //        Bitmap b2 = new Bitmap(pictureBox_card_photo.Image);
            //        width = b1.Width;
            //        height = b1.Height;

            //        images.Add(b1);
            //        images.Add(b2);

            //        finalImage = new Bitmap(width, height);
            //        using (Graphics g = Graphics.FromImage(finalImage))
            //        {
            //            g.Clear(Color.Transparent);
            //            int offset = 0;
            //            foreach (Bitmap image in images)
            //            {
            //                g.DrawImage(image, new Rectangle(offset, 0, image.Width, image.Height));
            //                offset += image.Width;
            //            }
            //        }

            //        FinImg = finalImage;

            //    }
            //    catch (Exception vv)
            //    {
            //        if (finalImage != null)
            //            finalImage.Dispose();
            //        throw;
            //    } 

        }

        private void btn_member_card_search_Click(object sender, EventArgs e)
        {
            try
            {
                Buisness_Logic.gymMemberRepository gr = new Buisness_Logic.gymMemberRepository();
              //  Buisness_Logic.gymMember gm = new Buisness_Logic.gymMember();
                string nicr = " ";
                gmzzz = gr.search(int.Parse(txt_memCardID.Text), txt_memCard_name.Text, nicr);


                    txt_memCard_name.Text = gmzzz.name;
                txt_memCard_jdate.Text = gmzzz.joinedDate;

                pictureBox_card_photo.SizeMode = PictureBoxSizeMode.StretchImage;

                MemoryStream ms1 = new MemoryStream(gmzzz.photo);
                // ms1.ToArray();
                ms1.Position = 0;

                ms1.Read(gmzzz.photo, 0, gmzzz.photo.Length);
                pictureBox_card_photo.Image = Image.FromStream(ms1);



            }
            catch (Exception dsf)
            {

                throw;
            }
        }

        private void btnCard_savetopc_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialg = new SaveFileDialog();
            if (dialg.ShowDialog() == DialogResult.OK)
            {
                int wid = Convert.ToInt32(pictureBox_card_mem.Width);
                int hei = Convert.ToInt32(pictureBox_card_mem.Height);

                Bitmap bmp = new Bitmap(wid,hei);
               pictureBox_card_mem.DrawToBitmap(bmp, new Rectangle(0, 0, wid, hei));
                bmp.Save(dialg.FileName + ".png");

            }
        }
    }
    }

