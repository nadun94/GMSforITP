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

        private void btnOS1_Save_Click(object sender, EventArgs e)
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
            try
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
            catch (Exception dsf)
            {

                throw;
            }
        }
    }
}
