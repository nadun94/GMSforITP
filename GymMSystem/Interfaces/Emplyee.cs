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
using System.Globalization;

namespace GymMSystem.Interfaces
{
    public partial class Emplyee : MetroForm
    {
        public Emplyee()
        {
            InitializeComponent();
        }

        private void Emplyee_Load(object sender, EventArgs e)
        {
            Buisness_Logic.EmployeeRepository er = new Buisness_Logic.EmployeeRepository();
            dataGridEmp.DataSource = er.searchEMP_for_datagrid();
            this.dataGridEmp.Columns[11].Visible = false;
        }
        private Buisness_Logic.empAttendence transport1 = null;

        private bool validateEmp()
        {
            Buisness_Logic.validation val1 = new Buisness_Logic.validation();
            bool phone, email, address, name, nic, gender, dob, pp;

            //phone
            if (!val1.IsPhone(txtEmp1_phone.Text))
            {
                this.errorProvider1.SetError(txtEmp1_phone, "Phone is invalid.");
                phone = false;
            }
            else
            {
                this.errorProvider1.SetError(txtEmp1_phone, (string)null);
                phone = true;
            }

            //Email

            if (!val1.IsEmail2(txtEmp1_email.Text))
            {

                this.errorProvider1.SetError(txtEmp1_email, "Email is invalid.");
                email = false;

            }
            else
            {
                this.errorProvider1.SetError(txtEmp1_email, (string)null);
                email = true;

            }

            //Name
            if (!val1.IsName(txtEmp1_name.Text) && string.IsNullOrWhiteSpace(txtEmp1_name.Text))
            {

                this.errorProvider1.SetError(txtEmp1_name, "Name is invalid.");
                name = false;

            }
            else
            {
                this.errorProvider1.SetError(txtEmp1_name, (string)null);
                name = true;

            }
            //NIC
            if (!val1.IsNIC(txtEmp_nic.Text))
            {
                this.errorProvider1.SetError(txtEmp_nic, "NIC is invalid.");
                nic = false;
            }
            else
            {
                this.errorProvider1.SetError(txtEmp_nic, (string)null);
                nic = true;
            }
            //address
            if (!val1.IsAddress(txtEmp1_address.Text))
            {
                this.errorProvider1.SetError(txtEmp1_address, "Address is invalid.");
                address = false;
            }
            else
            {
                this.errorProvider1.SetError(txtEmp1_address, (string)null);
                address = true;
            }
            //gender
            if (cmbEmp1_gender.SelectedIndex.Equals(-1))
            {
                this.errorProvider1.SetError(cmbEmp1_gender, "Gender is not selected.");
                gender = false;
            }
            else
            {
                this.errorProvider1.SetError(cmbEmp1_gender, (string)null);
                gender = true;
            }
            //post
            if (cmbEmp1_post.SelectedIndex.Equals(-1))
            {
                this.errorProvider1.SetError(cmbEmp1_post, "Post is not selected.");
                pp = false;
            }
            else
            {
                this.errorProvider1.SetError(cmbEmp1_post, (string)null);
                pp = true;
            }

            //dob
            if (dateTimePickeremp.Value >= DateTime.Today)
            {
                this.errorProvider1.SetError(dateTimePickeremp, "DOB is invalid.");
                dob = false;
            }
            else
            {
                this.errorProvider1.SetError(dateTimePickeremp, (string)null);
                dob = true;
            }

            //resume


            //**** main returning part
            if (phone == true && email == true && name == true && nic == true && gender == true && dob == true && address == true && pp == true) return true;
            else return false;


        }
        private void btnEmp1_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateEmp())
                {
                    Buisness_Logic.employee emp = new Buisness_Logic.employee();

                    emp.name = txtEmp1_name.Text;
                    emp.address = txtEmp1_address.Text;
                    emp.dob = dateTimePickeremp.Value.ToShortDateString();

                    //initialize image

                    MemoryStream memt1p1 = new MemoryStream();
                    picuturebox_emp1.Image.Save(memt1p1, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] photo_memt1 = memt1p1.ToArray();
                    emp.phone = txtEmp1_phone.Text;
                    emp.photo = photo_memt1;
                    emp.nic = txtEmp_nic.Text;
                    emp.position = cmbEmp1_post.SelectedItem.ToString();
                    emp.joinedDate = txtEmp1_jdate.Text;
                    emp.gender = cmbEmp1_gender.SelectedItem.ToString();
                    emp.email = txtEmp1_email.Text;
                    emp.profile = txtEmp1_resume.Text;

                    Buisness_Logic.EmployeeRepository empr = new Buisness_Logic.EmployeeRepository();


                    if (empr.addEmployee(emp))
                    {
                        MessageBox.Show("Success", "Data Insertion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed", "Data Insertion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }


            }
            catch (Exception exb)
            {
                MessageBox.Show(exb.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void btn_emp1_browse_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialogEmp.Filter = "Image files | *.jpg; *.PNG; *.gif; *.BMP";
                DialogResult drMem1 = openFileDialogEmp.ShowDialog();

                if (drMem1 == DialogResult.OK)
                {
                    picuturebox_emp1.SizeMode = PictureBoxSizeMode.StretchImage;
                    picuturebox_emp1.Image = Image.FromFile(openFileDialogEmp.FileName);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnAtSerchM_Click(object sender, EventArgs e)
        {
            try
            {
                Buisness_Logic.empAttendence ea1 = new Buisness_Logic.empAttendence();

                ea1.empID = int.Parse(txtEmpIDatte.Text);
                ea1.theDay = DateTime.Today.ToShortDateString();

                Buisness_Logic.empAttendence_repository emarep2 = new Buisness_Logic.empAttendence_repository();

                if (emarep2.searchMemAt(ea1))
                {
                    MessageBox.Show("Employee attendence record found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtStartTime.Text = ea1.startTime;
                    txtempAT_theday.Text = ea1.theDay;
                    if (string.IsNullOrWhiteSpace(ea1.endTime))
                    {

                    }else
                    {
                        textAtEndTime.Text = ea1.endTime;
                        textAtTotalHr.Text = ea1.hoursWorked.ToString();
                        textAtExtraHr.Text = ea1.extraHours.ToString();
                    }
                    


                }
                else
                {
                    MessageBox.Show("No record found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                transport1 = ea1;
            }
            catch (Exception es)
            {

                throw;
            }
        }

        private void btnAtAdStrtTime_Click(object sender, EventArgs e)
        {
            try
            {

                Buisness_Logic.empAttendence em = new Buisness_Logic.empAttendence();

                em.empID = int.Parse(txtEmpIDatte.Text);
                em.theDay = txtempAT_theday.Text;
                em.startTime = txtStartTime.Text;

                Buisness_Logic.empAttendence_repository emprep = new Buisness_Logic.empAttendence_repository();

                if (emprep.addStartTime(em))
                {
                    MessageBox.Show("Success", "Start time and day are added to the database.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    MessageBox.Show("Failed.", "Data Insertion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }









            }
            catch (Exception ew)
            {

                throw;
            }
        }

        private void btnCalcHours_Click(object sender, EventArgs e)
        {
            try
            {
                txtempAT_theday.Text = DateTime.Today.ToShortDateString();
                txtStartTime.Text = DateTime.Now.ToShortTimeString();
            }
            catch (Exception etu)
            {

                throw;
            }
        }

        private void btnAtAdEndTime_Click(object sender, EventArgs e)
        {
            try
            {


                Buisness_Logic.empAttendence em1 = new Buisness_Logic.empAttendence();

                em1.empID = int.Parse(txtEmpIDatte.Text);
                em1.theDay = txtempAT_theday.Text;
                em1.startTime = txtStartTime.Text;
                em1.endTime = textAtEndTime.Text;

                Buisness_Logic.empAttendence_repository emprep1 = new Buisness_Logic.empAttendence_repository();

                if (emprep1.addEndTime(em1))
                {
                    MessageBox.Show("Success", "Data Insertion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textAtTotalHr.Text = em1.hoursWorked.ToString();

                }
                else
                {

                    MessageBox.Show("Failed.", "Data Insertion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }









            }
            catch (Exception ew)
            {

                throw;
            }
        }


        //validate employee search

        private bool validate_search_employee()
        {


            Buisness_Logic.validation val1 = new Buisness_Logic.validation();
            bool name, nic, empid;

            if (string.IsNullOrWhiteSpace(txtEmp2_empid.Text) && string.IsNullOrWhiteSpace(txtEmp2_nic.Text) && string.IsNullOrWhiteSpace(txtEmp2_name.Text))
            {
                MessageBox.Show("Please enter employee ID or NIC or name to search employee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {

                // Member ID
                if (!txtEmp2_empid.Text.All(char.IsDigit) && !string.IsNullOrWhiteSpace(txtEmp2_empid.Text))
                {
                    this.errorProvider1.SetError(txtEmp2_empid, "Employee ID is invalid.");
                    empid = false;
                }
                else
                {
                    this.errorProvider1.SetError(txtEmp2_empid, (string)null);
                    empid = true;
                }

                //Name
                if (!val1.IsName(txtEmp2_name.Text) && !string.IsNullOrWhiteSpace(txtEmp2_name.Text))
                {

                    this.errorProvider1.SetError(txtEmp2_name, "Name is invalid.");
                    name = false;

                }
                else
                {
                    this.errorProvider1.SetError(txtEmp2_name, (string)null);
                    name = true;

                }
                //NIC
                if (!val1.IsNIC(txtEmp2_nic.Text) && !string.IsNullOrWhiteSpace(txtEmp2_nic.Text))
                {
                    this.errorProvider1.SetError(txtEmp2_nic, "NIC is invalid.");
                    nic = false;
                }
                else
                {
                    this.errorProvider1.SetError(txtEmp2_nic, (string)null);
                    nic = true;
                }




                //**** main returning part
                if (empid == true || name == true || nic == true) return true;
                else return false;
            }
        }


        private void btnEMP2_search_Click(object sender, EventArgs e)
        {
            if (validate_search_employee())
            {
                try
                {
                    Buisness_Logic.employee emp = new Buisness_Logic.employee();

                    emp.empID = (string.IsNullOrEmpty(txtEmp2_empid.Text) ? 0 : int.Parse(txtEmp2_empid.Text));
                    emp.name = txtEmp2_name.Text;
                    emp.nic = txtEmp2_nic.Text;


                    Buisness_Logic.EmployeeRepository emprt = new Buisness_Logic.EmployeeRepository();

                    if (emprt.searchEMP(emp))
                    {
                        txtEmp2_address.Text = emp.address;
                        txtEmp2_dob.Text = emp.dob;
                        txtEmp2_email.Text = emp.email;
                        txtEmp2_empid.Text = emp.empID.ToString();
                        txtEmp2_jDate.Text = emp.joinedDate;
                        txtEmp2_name.Text = emp.name;
                        txtEmp2_nic.Text = emp.nic;
                        txtEmp2_phone.Text = emp.phone.ToString();
                        txtEmp2_profile.Text = emp.profile;
                        cmbEMP2_gender.SelectedItem = emp.gender;
                        cmbEMP2_post.SelectedItem = emp.position;
                        pictureBoxEmp2.SizeMode = PictureBoxSizeMode.StretchImage;

                        MemoryStream ms2 = new MemoryStream(emp.photo);
                        // ms1.ToArray();
                        ms2.Position = 0;

                        ms2.Read(emp.photo, 0, emp.photo.Length);
                        pictureBoxEmp2.Image = Image.FromStream(ms2);


                        MessageBox.Show("Success", "Data Insertion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed.", "Data Insertion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception exy)
                {
                    MessageBox.Show(exy.Message, "Data Insertion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }
        }

        private void btnEMP2_clear_Click(object sender, EventArgs e)
        {

            txtEmp2_address.Text = "";
            txtEmp2_dob.Text = "";
            txtEmp2_email.Text = "";
            txtEmp2_empid.Text = "";
            txtEmp2_jDate.Text = "";
            txtEmp2_name.Text = "";
            txtEmp2_nic.Text = "";
            txtEmp2_phone.Text = "";
            txtEmp2_profile.Text = "";
            cmbEMP2_gender.SelectedItem = null;
            cmbEMP2_post.SelectedItem = null;
            pictureBoxEmp2.Image = null;
        }

        private void btnHome_emp_Click(object sender, EventArgs e)
        {
            Main empmain = new Main();
            this.Hide();
            empmain.Show();
        }

        //validate update employee part
        private bool validateUpdate_employee()
        {
            Buisness_Logic.validation val1 = new Buisness_Logic.validation();
            bool phone, email, address, name, nic, gender, dob, jdate, profile, position;

            //phone
            if (!val1.IsPhone(txtEmp2_phone.Text))
            {
                this.errorProvider1.SetError(txtEmp2_phone, "Phone is invalid.");
                phone = false;
            }
            else
            {
                this.errorProvider1.SetError(txtEmp2_phone, (string)null);
                phone = true;
            }

            //Email

            if (!val1.IsEmail2(txtEmp2_email.Text))
            {

                this.errorProvider1.SetError(txtEmp2_email, "Email is invalid.");
                email = false;

            }
            else
            {
                this.errorProvider1.SetError(txtEmp2_email, (string)null);
                email = true;

            }

            //Name
            if (!val1.IsName(txtEmp2_name.Text) && string.IsNullOrWhiteSpace(txtEmp2_name.Text))
            {

                this.errorProvider1.SetError(txtEmp2_name, "Name is invalid.");
                name = false;

            }
            else
            {
                this.errorProvider1.SetError(txtEmp2_name, (string)null);
                name = true;

            }
            //NIC
            if (!val1.IsNIC(txtEmp2_nic.Text))
            {
                this.errorProvider1.SetError(txtEmp2_nic, "NIC is invalid.");
                nic = false;
            }
            else
            {
                this.errorProvider1.SetError(txtEmp2_nic, (string)null);
                nic = true;
            }
            //address
            if (!val1.IsAddress(txtEmp2_address.Text))
            {
                this.errorProvider1.SetError(txtEmp2_address, "Address is invalid.");
                address = false;
            }
            else
            {
                this.errorProvider1.SetError(txtEmp2_address, (string)null);
                address = true;
            }
            //gender
            if (cmbEMP2_gender.SelectedIndex.Equals(-1))
            {
                this.errorProvider1.SetError(cmbEMP2_gender, "Gender is not selected.");
                gender = false;
            }
            else
            {
                this.errorProvider1.SetError(cmbEMP2_gender, (string)null);
                gender = true;
            }
            //post or position of the employee
            if (cmbEMP2_post.SelectedIndex.Equals(-1))
            {
                this.errorProvider1.SetError(cmbEMP2_post, "Employee post is not selected.");
                position = false;
            }
            else
            {
                this.errorProvider1.SetError(cmbEMP2_post, (string)null);
                position = true;
            }

            //dob
            DateTime dt;
            if (DateTime.TryParse(txtEmp2_dob.Text, out dt) && dt > DateTime.Today)
            {
                this.errorProvider1.SetError(txtEmp2_dob, "DOB is invalid.");
                dob = false;
            }
            else
            {
                this.errorProvider1.SetError(txtEmp2_dob, (string)null);
                dob = true;
            }

            //joined date
            DateTime dt1;
            if (DateTime.TryParse(txtEmp2_jDate.Text, out dt1) && dt1 > DateTime.Today)
            {
                this.errorProvider1.SetError(txtEmp2_jDate, "Joined date is invalid.");
                jdate = false;
            }
            else
            {
                this.errorProvider1.SetError(txtEmp2_jDate, (string)null);
                jdate = true;
            }

            //profile of the employee
            if (!val1.IsAlphaNumeric(txtEmp2_profile.Text))
            {

                this.errorProvider1.SetError(txtEmp2_profile, "Pofile is invalid.");
                profile = false;

            }
            else
            {
                this.errorProvider1.SetError(txtEmp2_profile, (string)null);
                profile = true;

            }

            //**** main returning part
            if (phone == true && email == true && name == true && nic == true && gender == true && position == true && dob && jdate == true && profile == true && address == true) return true;
            else return false;

        }
        private void btnEMP2_update_Click(object sender, EventArgs e)
        {
            if (validateUpdate_employee())
            {
                Buisness_Logic.employee gm = new Buisness_Logic.employee();

                MemoryStream memt1p2 = new MemoryStream();
                pictureBoxEmp2.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxEmp2.Image.Save(memt1p2, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] photo_memt2 = memt1p2.ToArray();

                gm.empID = int.Parse(txtEmp2_empid.Text);
                gm.name = txtEmp2_name.Text;
                gm.nic = txtEmp2_nic.Text;
                gm.phone = txtEmp2_phone.Text;


                gm.address = txtEmp2_address.Text;

                gm.gender = cmbEMP2_gender.SelectedItem.ToString();
                gm.position = cmbEMP2_post.SelectedItem.ToString();
                gm.dob = txtEmp2_dob.Text;
                gm.joinedDate = txtEmp2_jDate.Text;
                gm.profile = txtEmp2_profile.Text;
                gm.photo = photo_memt2;
                gm.email = txtEmp2_email.Text;

                Buisness_Logic.EmployeeRepository grup = new Buisness_Logic.EmployeeRepository();

                if (grup.update_employee(gm))
                {
                    MessageBox.Show("Employee detail updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //datagridm3refresh();
                }
            }

        }

        private void btnEMP2_browse_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialogEmp.Filter = "Image files | *.jpg; *.PNG; *.gif; *.BMP";
                DialogResult drMem1 = openFileDialogEmp.ShowDialog();

                if (drMem1 == DialogResult.OK)
                {
                    pictureBoxEmp2.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBoxEmp2.Image = Image.FromFile(openFileDialogEmp.FileName);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnEMP2_delete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtEmp2_empid.Text))
            {
                try
                {


                    int empid = int.Parse(txtEmp2_empid.Text);

                    Buisness_Logic.EmployeeRepository grd = new Buisness_Logic.EmployeeRepository();

                    if (grd.deleteEmployee(empid))
                    {
                        MessageBox.Show("Record deleted.", "Information.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //datagridm3refresh();
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

        private void btnGenEndTime_Click(object sender, EventArgs e)
        {
            try
            {

                textAtEndTime.Text = DateTime.Now.ToShortTimeString();
            }
            catch (Exception tu)
            {

                throw;
            }
        }

        private void btncalculate_Hours_Click(object sender, EventArgs e)
        {


            Buisness_Logic.empAttendence em1 = new Buisness_Logic.empAttendence();

       
            em1.startTime = txtStartTime.Text;
            em1.endTime = textAtEndTime.Text;

           // Buisness_Logic.empAttendence_repository emprep1 = new Buisness_Logic.empAttendence_repository();

           //DateTime st= DateTime.ParseExact(" "+em1.startTime, " h:mm tt", CultureInfo.InvariantCulture);
           // DateTime et = DateTime.ParseExact(" " + em1.endTime, " h:mm tt", CultureInfo.InvariantCulture);
           // TimeSpan dif = et - st;
           // string y = dif.ToString(@"hh\:mm");
            textAtTotalHr.Text =em1.hoursWorked.ToString();
            textAtExtraHr.Text = em1.extraHours.ToString();

        }

        private void btnPrSearch_Click(object sender, EventArgs e)
        {
            int monthInDigit = DateTime.ParseExact(cmbFin1_month.SelectedItem.ToString(), "MMMM", CultureInfo.InvariantCulture).Month;
            int year = int.Parse(metroTextBox1.Text);
            int eid = int.Parse(textPrEid.Text);
            Buisness_Logic.employee emp = new Buisness_Logic.employee();
            Buisness_Logic.salary b = new Buisness_Logic.salary();
            if (emp.calculate_salaryl(monthInDigit, year, eid, b))
            {
                MessageBox.Show("Successfull");
                textPrTotHrWrk.Text = b.tot_hours.ToString();
                textPrTotExHrWrk.Text = b.extr_hours.ToString();


            }
            else
            {

            }
        }

        private void btnPrAdd_Click(object sender, EventArgs e)
        {

        }

        private void dataGridEmp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridEmp.Rows[e.RowIndex];
                    txtEmp2_jDate.Text = row.Cells[10].Value.ToString();
                    txtEmp2_name.Text = row.Cells[1].Value.ToString();
                    txtEmp2_nic.Text = row.Cells[3].Value.ToString();
                    txtEmp2_address.Text = row.Cells[4].Value.ToString();
                    cmbEMP2_gender.SelectedItem = row.Cells[5].Value.ToString();
                    txtEmp2_dob.Text = row.Cells[2].Value.ToString();
                    txtEmp2_phone.Text = row.Cells[7].Value.ToString();
                    txtEmp2_email.Text = row.Cells[6].Value.ToString();
                    cmbEMP2_post.SelectedItem = row.Cells[8].Value.ToString();
                    txtEmp2_profile.Text = row.Cells[9].Value.ToString();
                    txtEmp2_empid.Text = row.Cells[0].Value.ToString();


                    byte[] picdg = (byte[])row.Cells[11].Value;
                    pictureBoxEmp2.SizeMode = PictureBoxSizeMode.StretchImage;

                    MemoryStream msdg1 = new MemoryStream(picdg);
                    msdg1.Position = 0;

                    msdg1.Read(picdg, 0, picdg.Length);
                    pictureBoxEmp2.Image = Image.FromStream(msdg1);
                    pictureBoxEmp2.Refresh();

                }
            }
            catch (Exception ecell)
            {

                throw;
            }
        }

        private void btnEmp1_clear_Click(object sender, EventArgs e)
        {
            txtEmp1_name.Text = "";
            txtEmp1_address.Text = "";
            txtEmp1_jdate.Text = "";
            txtEmp_nic.Text = "";
            txtEmp1_phone.Text = "";
            txtEmp1_email.Text = "";
            txtEmp1_resume.Text = "";
            picuturebox_emp1.Image = null;
            picuturebox_emp1.Refresh();

        }

        private void txtEmp1_email_Click(object sender, EventArgs e)
        {

        }
    }
}
