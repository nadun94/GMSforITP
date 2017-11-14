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


namespace GymMSystem.Interfaces
{
    public partial class OtherServices : MetroForm
    {
        public OtherServices()
        {
            InitializeComponent();
        }

        private void OtherServices_Load(object sender, EventArgs e)
        {
            radio_hc.Checked = true;

            lbl_monthlyRate.Visible = false;
            lbl_hr.Refresh();
            metroLabel1.Visible = false;
            txtOS1_EndingTime.Visible = false;
            txtOS1_statingTime.Visible = false;
            txt_cordinator.Visible = false;
            cmbOS1_day.Visible = false;
            metroLabel2.Visible = false;
            metroLabel3.Visible = false;
            metroLabel4.Visible = false;

            metroLabel2.Refresh();
            metroLabel3.Refresh();
            metroLabel4.Refresh();
            txt_cordinator.Refresh();
            txtOS1_statingTime.Refresh();
            txtOS1_EndingTime.Refresh();
            cmbOS1_day.Refresh();
            metroLabel1.Refresh();
        }

        private void btnHome_otherServices_Click(object sender, EventArgs e)
        {
            Main mother = new Main();
            this.Hide();
            mother.Show();
        }

        private void btnOS1_Save_Click(object sender, EventArgs e)
        {

        }

        private void radio_hc_CheckedChanged(object sender, EventArgs e)
        {
            // radio button initialization

            if (radio_mc.Checked == true)
            {
                lbl_monthlyRate.Visible = true;
                lbl_monthlyRate.Refresh();
                lbl_hr.Visible = false;
                lbl_hr.Refresh();

            }
            else if (radio_hc.Checked == true)
            {
                lbl_monthlyRate.Visible = false;
                lbl_monthlyRate.Refresh();
                lbl_hr.Visible = true;
                lbl_hr.Refresh();
            }

            // check button initialization

            if (checkOS2Mem.Checked == false)
            {
                lblHint1.Visible = false;
                lblHint2.Visible = false;
                btnOS2_searchMember.Visible = false;

                lblHint1.Refresh();
                lblHint2.Refresh();
                btnOS2_searchMember.Refresh();
            }
            else if (checkOS2Mem.Checked == true)
            {

                lblHint1.Visible = true;
                lblHint2.Visible = true;
                btnOS2_searchMember.Visible = true;

                lblHint1.Refresh();
                lblHint2.Refresh();
                btnOS2_searchMember.Refresh();

            }

        }

        private void radio_mc_CheckedChanged(object sender, EventArgs e)
        {

            if (radio_mc.Checked == true)
            {
                lbl_monthlyRate.Visible = true;
                lbl_monthlyRate.Refresh();
                lbl_hr.Visible = false;
                lbl_hr.Refresh();

                metroLabel1.Visible = true;
                txtOS1_EndingTime.Visible = true;
                txtOS1_statingTime.Visible = true;
                txt_cordinator.Visible = true;
                cmbOS1_day.Visible = true;
                metroLabel2.Visible = true;
                metroLabel3.Visible = true;
                metroLabel4.Visible = true;

                metroLabel2.Refresh();
                metroLabel3.Refresh();
                metroLabel4.Refresh();
                txt_cordinator.Refresh();
                txtOS1_statingTime.Refresh();
                txtOS1_EndingTime.Refresh();
                cmbOS1_day.Refresh();
                metroLabel1.Refresh();


            }
            else if (radio_hc.Checked == true)
            {
                lbl_monthlyRate.Visible = false;
                lbl_monthlyRate.Refresh();
                lbl_hr.Visible = true;
                lbl_hr.Refresh();

                metroLabel1.Visible = false;
                txtOS1_EndingTime.Visible = false;
                txtOS1_statingTime.Visible = false;
                txt_cordinator.Visible = false;
                cmbOS1_day.Visible = false;
                metroLabel2.Visible = false;
                metroLabel3.Visible = false;
                metroLabel4.Visible = false;

                metroLabel2.Refresh();
                metroLabel3.Refresh();
                metroLabel4.Refresh();
                txt_cordinator.Refresh();
                txtOS1_statingTime.Refresh();
                txtOS1_EndingTime.Refresh();
                cmbOS1_day.Refresh();
                metroLabel1.Refresh();





            }
        }

        private void btnOS2_searchMember_Click(object sender, EventArgs e)
        {
            try
            {
                Buisness_Logic.AreobicMemberRepository aerorep = new Buisness_Logic.AreobicMemberRepository();

                Buisness_Logic.AreobicMember arm = new Buisness_Logic.AreobicMember();

                arm.MemberID = int.Parse(txtOS2_memId.Text);
                arm.nic = txtOS2_nic.Text;

                aerorep.searchAerobicMem(arm);

                txtOS2_memId.Text = arm.MemberID.ToString();
                txtOS2_nic.Text = arm.nic;
                dateTime_OS2Mem.Value = DateTime.Parse(arm.dob);
                txtaddress.Text = arm.addresss;
                cmbOS2_gender.SelectedItem = arm.gender;
                txtOS2_phone.Text = arm.phone.ToString();
                cmbOS2_serviceType.SelectedItem = arm.service_type;
                txtOS2_memName.Text = arm.name;









            }
            catch (Exception sere)
            {

                MessageBox.Show(sere.Message, "Data Insertion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        bool alreadyMember;
        private void checkOS2Mem_CheckedChanged(object sender, EventArgs e)
        {
            //Already a member or not

            alreadyMember = true;

            lblHint1.Visible = true;
            lblHint2.Visible = true;
            btnOS2_searchMember.Visible = true;

            lblHint1.Refresh();
            lblHint2.Refresh();
            btnOS2_searchMember.Refresh();


        }

        private bool validate_aerobicMember()
        {
            Buisness_Logic.validation val1 = new Buisness_Logic.validation();
            bool phone, email, address, name, nic, gender, dob,pp;

            //phone
            if (!val1.IsPhone(txtOS2_phone.Text))
            {
                this.errorProvider1.SetError(txtOS2_phone, "Phone is invalid.");
                phone = false;
            }
            else
            {
                this.errorProvider1.SetError(txtOS2_phone, (string)null);
                phone = true;
            }


            //Name
            if (!val1.IsName(txtOS2_memName.Text) && string.IsNullOrWhiteSpace(txtOS2_memName.Text))
            {

                this.errorProvider1.SetError(txtOS2_memName, "Name is invalid.");
                name = false;

            }
            else
            {
                this.errorProvider1.SetError(txtOS2_memName, (string)null);
                name = true;

            }
            //NIC
            if (!val1.IsNIC(txtOS2_nic.Text))
            {
                this.errorProvider1.SetError(txtOS2_nic, "NIC is invalid.");
                nic = false;
            }
            else
            {
                this.errorProvider1.SetError(txtOS2_nic, (string)null);
                nic = true;
            }
            //address
            if (!val1.IsAddress(txtaddress.Text))
            {
                this.errorProvider1.SetError(txtaddress, "Address is invalid.");
                address = false;
            }
            else
            {
                this.errorProvider1.SetError(txtaddress, (string)null);
                address = true;
            }
            //gender
            if (cmbOS2_gender.SelectedIndex.Equals(-1))
            {
                this.errorProvider1.SetError(cmbOS2_gender, "Gender is not selected.");
                gender = false;
            }
            else
            {
                this.errorProvider1.SetError(cmbOS2_gender, (string)null);
                gender = true;
            }
            // service type
            if (cmbOS2_serviceType.SelectedIndex.Equals(-1))
            {
                this.errorProvider1.SetError(cmbOS2_serviceType, "Payment Plan is not selected.");
                pp = false;
            }
            else
            {
                this.errorProvider1.SetError(cmbOS2_serviceType, (string)null);
                pp = true;
            }

            //dob
            if (dateTime_OS2Mem.Value >= DateTime.Today)
            {
                this.errorProvider1.SetError(dateTime_OS2Mem, "DOB is invalid.");
                dob = false;
            }
            else
            {
                this.errorProvider1.SetError(dateTime_OS2Mem, (string)null);
                dob = true;
            }

       
            //**** main returning part
            bool condition = phone == true  && name == true && nic == true && gender == true  && address == true && pp==true ;
            if (condition) return true;
            else return false;

        }
        private void btnAddMember_Click(object sender, EventArgs e)
        {
            try
            {
                if (validate_aerobicMember())
                {
                    Buisness_Logic.AreobicMemberRepository areorep = new Buisness_Logic.AreobicMemberRepository();
                    Buisness_Logic.AreobicMember areo = new Buisness_Logic.AreobicMember();

                    //  areo.MemberID = int.Parse(txtOS2_memId.Text);
                    areo.name = txtOS2_memName.Text;
                    areo.addresss = txtaddress.Text;
                    areo.nic = txtOS2_nic.Text;
                    areo.phone = int.Parse(txtOS2_phone.Text);
                    areo.gender = cmbOS2_gender.SelectedItem.ToString();
                    areo.service_type = cmbOS2_serviceType.SelectedItem.ToString();
                    areo.dob = string.Format("{0:M/d/yyyy}", dateTime_OS2Mem.Value.ToShortDateString());


                    if (alreadyMember == true)
                    {
                        if (areorep.addOtherMembers_Exist(areo))
                        {
                            MessageBox.Show("Success", "Data Insertion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed.", "Data Insertion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (areorep.addOtherMembers_notExist(areo))
                        {
                            MessageBox.Show("Success", "Data Insertion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed.", "Data Insertion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }


                }

            }
            catch (Exception exaeo)
            {
                MessageBox.Show(exaeo.Message, "Data Insertion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        private void btnOS3_searchMem_Click(object sender, EventArgs e)
        {
            try
            {
                Buisness_Logic.AreobicMemberRepository aerorep = new Buisness_Logic.AreobicMemberRepository();

                Buisness_Logic.AreobicMember arm = new Buisness_Logic.AreobicMember();

                arm.MemberID = int.Parse(txteditmem_memid.Text);
                arm.nic = txteditmem_nic.Text;

                aerorep.searchAerobicMem(arm);

                txteditmem_memid.Text = arm.MemberID.ToString();
                txteditmem_nic.Text = arm.nic;
                datetimeeditmem.Value = DateTime.Parse(arm.dob);
                txteditmem_address.Text = arm.addresss;
                cmdeditmemGender.SelectedItem = arm.gender;
                txteditmem_phone.Text = arm.phone.ToString();
                cmbeditmemserve.SelectedItem = arm.service_type;
                txteditmem_name.Text = arm.name;




            }
            catch (Exception sere)
            {

                MessageBox.Show(sere.Message, "Data Insertion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOS3_update_Click(object sender, EventArgs e)
        {

        }
    }
}
