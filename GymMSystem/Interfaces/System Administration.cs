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
    public partial class Settings : MetroForm
    {
        public Settings()
        {
            InitializeComponent();
            this.StyleManager = metroStyleManager1;
        }

        private void Settings_Load(object sender, EventArgs e)
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

        private void btnHome_settings_Click(object sender, EventArgs e)
        {
            Main setmai = new Main();
            this.Hide();
            setmai.Show();
        }

        private  void btnTheme_Click(object sender, EventArgs e)
        {
            metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            themCarrier tc = new themCarrier();
            tc.theme();
        }

        private void btnwhitetheme_Click(object sender, EventArgs e)
        {
            metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Light;
        }

        private void cmbtheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbtheme.SelectedIndex) {

                case 0:
                    metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
                    break;
                case 1:
                    metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Light;
                    break;
            }

        }
        private void check_h()
        {       // radio button initialization
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

        }
        private void radio_hc_CheckedChanged(object sender, EventArgs e)
        {
            // radio button initialization
            check_h();


        }
        private void check_m()
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
        private void radio_mc_CheckedChanged(object sender, EventArgs e)
        {
            check_m();
        }

        private void tab_OtherServices_Click(object sender, EventArgs e)
        {

        }
        private bool validateUpdate_AddServices()
        {
            Buisness_Logic.validation val1 = new Buisness_Logic.validation();
            bool sname, cordinator, day, fee, stime, etime;



            //Service name
            if (!val1.IsWord(txtOS1_name.Text) && string.IsNullOrWhiteSpace(txtOS1_name.Text))
            {

                this.errorProvider1.SetError(txtOS1_name, "Service name is invalid.");
                sname = false;

            }
            else
            {
                this.errorProvider1.SetError(txtOS1_name, (string)null);
                sname = true;
                
            }

            // rate 
            if (!val1.isPrice(txtOS1_Rate.Text) && string.IsNullOrWhiteSpace(txtOS1_Rate.Text))
            {

                this.errorProvider1.SetError(txtOS1_Rate, "Service charge is invalid.");
                fee = false;

            }
            else
            {
                this.errorProvider1.SetError(txtOS1_Rate, (string)null);
                fee = true;

            }

            if (radio_mc.Checked == true)
            {
                //Cordinator name
                if (!val1.IsName(txt_cordinator.Text) && string.IsNullOrWhiteSpace(txt_cordinator.Text))
                {

                    this.errorProvider1.SetError(txt_cordinator, "Cordinator name is invalid.");
                    cordinator = false;

                }
                else
                {
                    this.errorProvider1.SetError(txt_cordinator, (string)null);
                    cordinator = true;

                }


                //Day
                if (cmbOS1_day.SelectedIndex.Equals(-1))
                {
                    this.errorProvider1.SetError(cmbOS1_day, "Day is not selected.");
                    day = false;
                }
                else
                {
                    this.errorProvider1.SetError(cmbOS1_day, (string)null);
                    day = true;
                }



                //start time
                DateTime dt1;
                if (DateTime.TryParse(txtOS1_statingTime.Text, out dt1) && dt1 > DateTime.Now && string.IsNullOrWhiteSpace(txtOS1_statingTime.Text))
                {
                    this.errorProvider1.SetError(txtOS1_statingTime, "Start time is invalid.");
                    stime = false;
                }
                else
                {
                    this.errorProvider1.SetError(txtOS1_statingTime, (string)null);
                    stime = true;
                }

                //end time
                DateTime dt2;
                if (DateTime.TryParse(txtOS1_EndingTime.Text, out dt2) && dt2 > DateTime.Now && string.IsNullOrWhiteSpace(txtOS1_EndingTime.Text))
                {
                    this.errorProvider1.SetError(txtOS1_EndingTime, "End time is invalid.");
                    etime = false;
                }
                else
                {
                    this.errorProvider1.SetError(txtOS1_EndingTime, (string)null);
                    etime = true;
                }
                if (cordinator == true && day == true && stime == true && etime == true ) return true;
                else return false;

            }

            else
            {
                if (sname == true && fee == true) return true;
                else return false;
            }

            
            

        }
        private void btnOS1_Save_Click(object sender, EventArgs e)
        {
            if (validateUpdate_AddServices())
            {
                try
                {

                    if (radio_mc.Checked)
                    {
                        Buisness_Logic.monthly_services ser = new Buisness_Logic.monthly_services();
                        ser.cordinator = txt_cordinator.Text;
                        ser.start_time = txtOS1_statingTime.Text;
                        ser.end_time = txtOS1_EndingTime.Text;
                        ser.day = cmbOS1_day.SelectedItem.ToString();
                        ser.service_name = txtOS1_name.Text;
                        ser.monthly_charge = double.Parse(txtOS1_Rate.Text);
                        ser.service_type = "Monthly";


                        if (ser.addMonthly_service(ser))
                        {
                            MessageBox.Show("Service added.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }

                    if (radio_hc.Checked)
                    {
                        Buisness_Logic.hourly_services hser = new Buisness_Logic.hourly_services();

                        hser.service_type = "Hourly";
                        hser.service_name = txtOS1_name.Text;
                        hser.hourly_rate = double.Parse(txtOS1_Rate.Text);


                        if (hser.addHourly_service(hser))
                        {
                            MessageBox.Show("Service added.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception fsf)
                {

                    throw;
                }
            }
            
        }

        private void btnOS1_clear_Click(object sender, EventArgs e)
        {

        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Buisness_Logic.service_repository ser = new Buisness_Logic.service_repository();
                dataGriddServices.DataSource = ser.search_services();
            }
            catch (Exception sf)
            {

                throw;
            }
        }

        private void dataGriddServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string stype;
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGriddServices.Rows[e.RowIndex];
                    stype = row.Cells[1].Value.ToString();
                    
                    txtOS1_name.Text = row.Cells[0].Value.ToString();
                    if (stype == "Monthly")
                    {
                        radio_mc.Checked = true;
                        check_m();
                        txtOS1_Rate.Text = row.Cells[3].Value.ToString();
                        cmbOS1_day.SelectedItem = row.Cells[4].Value.ToString();
                        txtOS1_statingTime.Text = row.Cells[5].Value.ToString();
                        txtOS1_EndingTime.Text = row.Cells[6].Value.ToString();

                        txt_cordinator.Text = row.Cells[7].Value.ToString();
                    }
                    else
                    {
                        radio_hc.Checked = true;
                        check_h();
                        txtOS1_Rate.Text = row.Cells[2].Value.ToString();
                    }
                    

                }
            }
            catch (Exception ecell)
            {

                throw;
            }
        }

        private void btnOS1_update_Click(object sender, EventArgs e)
        {

            if (validateUpdate_AddServices())
            {
                try
                {

                    if (radio_mc.Checked)
                    {
                        Buisness_Logic.monthly_services ser = new Buisness_Logic.monthly_services();
                        ser.cordinator = txt_cordinator.Text;
                        ser.start_time = txtOS1_statingTime.Text;
                        ser.end_time = txtOS1_EndingTime.Text;
                        ser.day = cmbOS1_day.SelectedItem.ToString();
                        ser.service_name = txtOS1_name.Text;
                        ser.monthly_charge = double.Parse(txtOS1_Rate.Text);
                        ser.service_type = "Monthly";


                        if (ser.updateMonthly_service(ser))
                        {
                            MessageBox.Show("Service Updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }

                    if (radio_hc.Checked)
                    {
                        Buisness_Logic.hourly_services hser = new Buisness_Logic.hourly_services();

                        hser.service_type = "Hourly";
                        hser.service_name = txtOS1_name.Text;
                        hser.hourly_rate = double.Parse(txtOS1_Rate.Text);


                        if (hser.UpdateHourly_service(hser))
                        {
                            MessageBox.Show("Service Updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception fsf)
                {

                    throw;
                }
            }
           
               

            
            
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel5_Click(object sender, EventArgs e)
        {

        }

        private void btn_usrAcnt_Click(object sender, EventArgs e)
        {
            try
            {
                Buisness_Logic.login lg = new Buisness_Logic.login();

                lg.emp.empID = int.Parse(txtUSacnt_empid.Text);
                lg.username = txtUSacnt_username.Text;
                lg.pwd = txtUSacnt_pwd.Text;
                if (check_admin.Checked)
                {
                    lg.user_type = true;
                }
                else
                    lg.user_type = false;

               if(lg.add_users())
                {
                    MessageBox.Show("User account created.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
               else
                    MessageBox.Show("Failed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception gfd)
            {

                throw;
            }
        }
        private bool validate_search_employee()
        {


            Buisness_Logic.validation val1 = new Buisness_Logic.validation();
            bool name, nic, empid;

            if (string.IsNullOrWhiteSpace(txtUSacnt_empid.Text) && string.IsNullOrWhiteSpace(txtUSacnt_nic.Text) )
            {
                MessageBox.Show("Please enter employee ID or NIC or name to search employee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {

                // Member ID
                if (!txtUSacnt_empid.Text.All(char.IsDigit) && !string.IsNullOrWhiteSpace(txtUSacnt_empid.Text))
                {
                    this.errorProvider1.SetError(txtUSacnt_empid, "Employee ID is invalid.");
                    empid = false;
                }
                else
                {
                    this.errorProvider1.SetError(txtUSacnt_empid, (string)null);
                    empid = true;
                }

              
                //NIC
                if (!val1.IsNIC(txtUSacnt_nic.Text) && !string.IsNullOrWhiteSpace(txtUSacnt_nic.Text))
                {
                    this.errorProvider1.SetError(txtUSacnt_nic, "NIC is invalid.");
                    nic = false;
                }
                else
                {
                    this.errorProvider1.SetError(txtUSacnt_nic, (string)null);
                    nic = true;
                }




                //**** main returning part
                if (empid == true  || nic == true) return true;
                else return false;
            }
        }


        private void btnserch_Click(object sender, EventArgs e)
        {
            if (validate_search_employee())
            {
                try
                {
                    Buisness_Logic.employee emp = new Buisness_Logic.employee();

                    emp.empID = (string.IsNullOrEmpty(txtUSacnt_empid.Text) ? 0 : int.Parse(txtUSacnt_empid.Text));
                    emp.nic = txtUSacnt_nic.Text;
                    emp.name = txtusre_name.Text;


                    Buisness_Logic.EmployeeRepository emprt = new Buisness_Logic.EmployeeRepository();


                    if (emprt.searchEMP(emp))
                    {

                        txtUSacnt_empid.Text = emp.empID.ToString();

                        txtUSacnt_username.Text = emp.name.Replace(" ", "_");

                        txtUSacnt_nic.Text = emp.nic;

                        txtusre_name.Text = emp.name;
                       
                   
                        MessageBox.Show("Success", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception exy)
                {
                    MessageBox.Show(exy.Message, "Data Insertion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }
        }

        private void fsdfdsfds_Click(object sender, EventArgs e)
        {
            try
            {
                Buisness_Logic.service_repository ser = new Buisness_Logic.service_repository();
                dataGrd_us.DataSource = ser.search_users();
            }
            catch (Exception sf)
            {

                throw;
            }

        }

        private void dataGrd_us_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGrd_us.Rows[e.RowIndex];
                    txtUSacnt_pwd.Text = row.Cells[1].Value.ToString();
                    txtUSacnt_empid.Text = row.Cells[2].Value.ToString();
                    txtUSacnt_username.Text = row.Cells[0].Value.ToString();
                    bool c = (bool)row.Cells[3].Value;
                    if (c == true)
                    {
                        check_admin.Checked = true;


                    }
                    else
                    {
                        check_admin.Checked = false;
                    }
                    
          
                
                }
            }
            catch (Exception ecell)
            {

                throw;
            }
        }
    }
}
