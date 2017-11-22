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
            comboW5_name.Refresh();
            da1.Fill(dtq);

            if (dtq.Rows.Count > 0)
            {
                for (int i = 0; i < dtq.Rows.Count; i++)
                {
                    comboW5_name.Items.Add(dtq.Rows[i]["name"].ToString());

                }
            }


            // for dataGridView
            dataGrid_exercise.DataSource = dtq;
            this.dataGrid_exercise.Columns[1].Visible = false;
            con.closeConnection();
        }

        private void workout_to_datagrid()
        {
            Buisness_Logic.workout_repository wr = new Buisness_Logic.workout_repository();
            dataGrid_workout.DataSource = wr.searchWorkouts_for_grid();
        }
        private void workouts_Load(object sender, EventArgs e)
        {
            
            database_refresh();
            workout_to_datagrid();
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
                wo.type = cmb_w5_type.SelectedItem.ToString();
               // from
                wo.BMI_rate_from = double.Parse(txtW2_bmi_from.Text);
                wo.fat_level_from = double.Parse(txtW4_fat_from.Text);

                //to 
                wo.BMI_rate_to = double.Parse(txtW2_bmi_to.Text);
                wo.fat_level_to = double.Parse(txtW4_fat_to.Text);

               
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
            comboW5_name.SelectedIndex = -1;
            txtW3_Wname.Clear();
            
        }

        private void btnworkout_search_Click(object sender, EventArgs e)
        {
            try
            {
                Buisness_Logic.workout wrk = new Buisness_Logic.workout();

                wrk.workout_name = txtW3_Wname.Text;
                wrk.exName = comboW5_name.SelectedItem.ToString();
                wrk.repeats = int.Parse(txtW5_sets.Text);

                Buisness_Logic.workout_repository wo1 = new Buisness_Logic.workout_repository();



                if (wo1.addExercises_to_workout(wrk))
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
                    txtEx1_Addionaequi.Text = row.Cells[4].Value.ToString(); 

                    txtEx1_equi.Text = row.Cells[3].Value.ToString();


                }
            }
            catch (Exception ecell)
            {

                throw;
            }
        }

        private void btnworkout_clear_1_Click(object sender, EventArgs e)
        {
            txtW3_Wname.Clear();
            cmb_w5_type.SelectedIndex = -1;
            txtW2_bmi_from.Clear();
            txtW4_fat_from.Clear();
            txtW3_schedule.Clear();
            txtW5_sets.Clear();
        }

        private void dataGrid_workout_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGrid_workout.Rows[e.RowIndex];
                    txtW3_Wname.Text = row.Cells[0].Value.ToString();
                    cmb_w5_type.SelectedItem = row.Cells[1].Value.ToString();
                     txtW2_bmi_from.Text = row.Cells[2].Value.ToString();
                    txtW3_schedule.Text = row.Cells[4].Value.ToString();

                    txtW4_fat_from.Text = row.Cells[3].Value.ToString();
                    txtW2_bmi_to.Text = row.Cells[5].Value.ToString();
                    txtW4_fat_to.Text = row.Cells[6].Value.ToString();

                    Buisness_Logic.workout_repository wr = new Buisness_Logic.workout_repository();

                    dataGrid_ex_list.DataSource = wr.getExercises_from_workoutGrid(txtW3_Wname.Text);



                }


            }
            catch (Exception ecell)
            {

                throw;
            }
        }

        private void dataGrid_ex_list_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGrid_ex_list.Rows[e.RowIndex];
                   
                    comboW5_name.SelectedItem = row.Cells[1].Value.ToString();
                    txtW5_sets.Text = row.Cells[2].Value.ToString();
                  
                }


            }
            catch (Exception ecell)
            {

                throw;
            }

        }

        private void btnGw_search_Click(object sender, EventArgs e)
        {
            try
            {
                Buisness_Logic.gymMemberRepository gr = new Buisness_Logic.gymMemberRepository();
             
                int regNo = string.IsNullOrWhiteSpace(txtgetW_memID.Text) ? 0 : int.Parse(txtgetW_memID.Text);
                string name = "";
                string nic = txtgetW_nic.Text;
                var gm= gr.search(regNo, name, nic);
                txtgetW_memID.Text = gm.MemberID.ToString();
                txtgetW_nic.Text = gm.nic;
                txtgetW_weight.Text = gm.weight.ToString();
                txtgetW_bmi.Text = gm.BMIratio.ToString();
                txtgetW_fat.Text = gm.fatLevel.ToString();
                txtgetW_height.Text = gm.height.ToString();
                //txtgetW_shedule.Text = 

            }
            catch (Exception fd)
            {

                throw;
            }
        }

        private void bnt_genwrfs_Click(object sender, EventArgs e)
        {       
            try
            { DataTable dt = new DataTable();

                double fat_to, fat_from, bmi_to, bmi_from;
                string workout_name;
                int match;
                bool test = false;
                double member_bmi, member_fat;
                member_bmi = double.Parse(txtgetW_bmi.Text);
                member_fat = double.Parse(txtgetW_fat.Text);
               
                Buisness_Logic.workout_repository wr = new Buisness_Logic.workout_repository();
                dt = wr.searchWorkouts_for_grid();

                if (dt.Rows.Count > 0)
                {
                    for(int i=0; i < dt.Rows.Count; i++)
                    {
                        bmi_from = (double)dt.Rows[i]["BMI_rate_from"];
                        bmi_to = (double)dt.Rows[i]["BMI_rate_to"];
                        fat_from = (double)dt.Rows[i]["fat_level_from"];
                        fat_to = (double)dt.Rows[i]["fat_level_to"];
                       
                       

                        if(member_bmi>= bmi_from && member_bmi<bmi_to && member_fat>=fat_from && member_fat< fat_to)
                        {
                            
                            match = i;
                            workout_name = dt.Rows[i]["w_name"].ToString();
                            // txtgw_workoutName.Text = dt.Rows[match]["w_name"].ToString();
                            MessageBox.Show("Workout generated.", "Information.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtgw_workoutName.Text = workout_name;
                            txtgetW_shedule.Text = dt.Rows[i]["interval_days"].ToString();
                            test = true;
                            break;
                        }
                        
                    }
                    if(test==false)
                        MessageBox.Show("No workout match found.", "Information.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception gf)
            {

                throw;
            }
        }

        private void btnGw_save_Click(object sender, EventArgs e)
        {
            string wk =txtgw_workoutName.Text;
            DataTable mem = new DataTable();
            mem.Columns.Add("memID", typeof(int));
            mem.Columns.Add("fat", typeof(double));
            mem.Columns.Add("bmi", typeof(double));

            double fat = double.Parse(txtgetW_fat.Text);
            double bmi = double.Parse(txtgetW_bmi.Text);
            int memid = int.Parse(txtgetW_memID.Text);

            mem.Rows.Add(memid, fat, bmi);
           

            Buisness_Logic.workout_repository wr = new Buisness_Logic.workout_repository();
            var dt_w = wr.searchWorkouts_for_report(wk);
            var dt_e = wr.getExercises_from_workoutGrid( wk);

            Workout_printUI fd = new Workout_printUI(dt_w,dt_e, mem);
            fd.Show();
        }
    }
}
