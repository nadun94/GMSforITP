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
using System.Data.SqlClient;
using System.Data;


namespace GymMSystem.Interfaces
{
    public partial class workouts : MetroForm
    {
        public workouts()
        {
            InitializeComponent();
        }

        private void database_refresh()
        {
            DataLayer.dbConnect con = new DataLayer.dbConnect();
            con.openConnection();

            string q1 = "select * from tbl_exercise";

            SqlCommand cmd = new SqlCommand(q1, con.getConnection());

            DataTable dtq = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd);
            comboW1_name.Refresh();
            da1.Fill(dtq);

            if (dtq.Rows.Count > 0)
            {
                for (int i = 0; i < dtq.Rows.Count; i++)
                {
                    comboW1_name.Items.Add(dtq.Rows[i]["name"].ToString());

                }
            }


            // for dataGridView
            dataGrid_exercise.DataSource = dtq;
            this.dataGrid_exercise.Columns[1].Visible = false;
            con.closeConnection();
        }
        private void workouts_Load(object sender, EventArgs e)
        {

            database_refresh();
        }

        private void btnHome_workouts_Click(object sender, EventArgs e)
        {
            Main wma = new Main();
            this.Hide();
            wma.Show();

        }
        private bool validateExercise()
        {

            bool exname, type, des,eq,ad;
            try
            {
               
                Buisness_Logic.validation val1 = new Buisness_Logic.validation();
                      //Name
            if (!val1.IsName(txtEx1_name.Text) && string.IsNullOrWhiteSpace(txtEx1_name.Text))
                {

                    this.errorProvider1.SetError(txtEx1_name, "Exercise name is invalid.");
                    exname = false;

                }
                else
                {
                    this.errorProvider1.SetError(txtEx1_name, (string)null);
                    exname = true;

                }
            //description
                if (!val1.IsWord(txtEx2_description.Text) && string.IsNullOrWhiteSpace(txtEx2_description.Text))
                {

                    this.errorProvider1.SetError(txtEx2_description, "Exercise description is invalid.");
                    des = false;

                }
                else
                {
                    this.errorProvider1.SetError(txtEx2_description, (string)null);
                    des = true;

                }
                //type
                if (cmbWork_cato.SelectedIndex.Equals(-1))
                {
                    this.errorProvider1.SetError(cmbWork_cato, "Exercise category is not selected.");
                    type = false;
                }
                else
                {
                    this.errorProvider1.SetError(cmbWork_cato, (string)null);
                    type = true;
                }
                //equipments
               
                if (!val1.IsWord(txtEx1_equi.Text) )
                {

                    this.errorProvider1.SetError(txtEx1_equi, "Equipment name is invalid.");
                    eq = false;

                }
                else
                {
                    this.errorProvider1.SetError(txtEx1_equi, (string)null);
                    eq = true;

                }

                //additional
               
                if (!val1.IsWord(txtEx1_Addionaequi.Text))
                {

                    this.errorProvider1.SetError(txtEx1_Addionaequi, "Additional equipment name is invalid.");
                    ad = false;

                }
                else
                {
                    this.errorProvider1.SetError(txtEx1_Addionaequi, (string)null);
                    ad = true;

                }


            }
            catch (Exception fd)
            {

                throw;
            }

            if (type == true && exname == true && des == true ) return true;
            else return false;
        }

        private void btnexercise_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateExercise())
                {
                    Buisness_Logic.exercise exercise1 = new Buisness_Logic.exercise();

                    exercise1.name = txtEx1_name.Text;
                    exercise1.description = txtEx2_description.Text;
                    exercise1.type = cmbWork_cato.SelectedItem.ToString();
                    exercise1.equipment = txtEx1_equi.Text;
                    exercise1.additional_equipment = txtEx1_Addionaequi.Text;
                    if (exercise1.addExercise())
                    {
                        MessageBox.Show(("Sucessfully Added!"), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        database_refresh();
                    }
                    else
                    {
                        MessageBox.Show(("Failed."), "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                   


                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void btnexercise_clear_Click(object sender, EventArgs e)
        {
            txtEx1_name.Clear();
            txtEx2_description.Clear();
        }

        private void btnworkout_save_Click(object sender, EventArgs e)
        {
            try
            {

                Buisness_Logic.workout wo = new Buisness_Logic.workout();

                wo.workout_name = txtW3_Wname.Text;
                wo.type = txtW6_type.Text;
                wo.exName = comboW1_name.SelectedItem.ToString();
                wo.BMI_rate = double.Parse(txtW2_bmi.Text);
                wo.fat_level = double.Parse(txtW4_fat.Text);
                wo.repeats = int.Parse(txtW5_sets.Text);
                wo.interval_days = txtW3_schedule.Text;


                Buisness_Logic.workout_repository wr = new Buisness_Logic.workout_repository();


                if (wr.addWorkouts(wo))
                {
                    MessageBox.Show("Succesfull.", "Data Insertion.", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                else
                {
                    MessageBox.Show("Unsucesfull.", "Data Insertion.", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }
            catch (Exception exp)
            {

                throw;
            }

        }

        private void btnworkout_clear_Click(object sender, EventArgs e)
        {
            comboW1_name.SelectedIndex = -1;
            txtW3_Wname.Clear();
            txtW6_type.Clear();
            txtW2_bmi.Clear();
            txtW4_fat.Clear();
            txtW3_schedule.Clear();
            txtW5_sets.Clear();
        }

        private void btnworkout_search_Click(object sender, EventArgs e)
        {
            try
            {
                Buisness_Logic.workout wrk = new Buisness_Logic.workout();

                wrk.workout_name = txtW3_Wname.Text;
                //wo1.type = txtW6_type.Text;
                //wo1.exName = comboW1_name.SelectedItem.ToString();
                //wo1.BMI_rate = double.Parse(txtW2_bmi.Text);
                //wo1.fat_level = double.Parse(txtW4_fat.Text);
                //wo1.repeats = int.Parse(txtW5_sets.Text);
                //wo1.interval_days = txtW3_schedule.Text;

                Buisness_Logic.workout_repository wo1 = new Buisness_Logic.workout_repository();



                if (wo1.searchWorkouts(wrk))
                {

                    txtW6_type.Text = wrk.type;
                    txtW2_bmi.Text = wrk.BMI_rate.ToString();
                    txtW4_fat.Text = wrk.fat_level.ToString();
                    txtW5_sets.Text = wrk.repeats.ToString();
                    txtW3_schedule.Text = wrk.interval_days.ToString();

                    MessageBox.Show("Succesfull.", "Data Insertion.", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                else
                {
                    MessageBox.Show("Unsucesfull.", "Data Insertion.", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception exp)
            {

                throw;
            }

        }

        private void btnworkout_update_Click(object sender, EventArgs e)
        {

        }

        private void exersixeTab_Click(object sender, EventArgs e)
        {

        }

        private void dataGrid_exercise_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGrid_exercise.Rows[e.RowIndex];
                    txtEx1_name.Text = row.Cells[0].Value.ToString();
                    txtEx2_description.Text = row.Cells[1].Value.ToString();
                    cmbWork_cato.SelectedItem = row.Cells[2].Value.ToString();
                    
                }
            }
            catch (Exception ecell)
            {

                throw;
            }
        }
    }
}
