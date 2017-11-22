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
using System.Data;
using System.Data.SqlClient;



namespace GymMSystem.Interfaces
{
    public partial class Finance : MetroForm
    {
        public Finance()
        {
            InitializeComponent();
        }

        private void dataGrid_generation_gym()
        {
            DataLayer.dbConnect con = new DataLayer.dbConnect();
            con.openConnection();

            string q = "select * from gym_income";
            SqlCommand cmd = new SqlCommand(q, con.getConnection());

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);

            dataGridFin1.DataSource = dt;
        }
        private void Settings_Load(object sender, EventArgs e)
        {

            dataGrid_generation_gym();
            this.StyleManager = metroStyleManager_fin;
           string year =  DateTime.Now.Year.ToString();
            string month = DateTime.Now.ToString("MMMM");
            year = txtFin_fitYear.Text = year;

            cmbFin1_month.SelectedItem = month;
            txtsalesyear.Text = year;
            cmbFin2_month.SelectedItem = month;
            txtos_year.Text = year;
           




            //cmbFin1_month.Refresh();
        }

        private void btnFinHome_Click(object sender, EventArgs e)
        {
            Main fm = new Main();
            this.Hide();
            fm.Show();
        }

        public bool validatefitness_Year() {

          

            bool exname, type;
            try
            {

                Buisness_Logic.validation val1 = new Buisness_Logic.validation();
                //Year
                if (!val1.IsNumeric(txtFin_fitYear.Text) && string.IsNullOrWhiteSpace(txtFin_fitYear.Text))
                {

                    this.errorProvider1.SetError(txtFin_fitYear, " Year is invalid.");
                    exname = false;

                }
                else
                {
                    this.errorProvider1.SetError(txtFin_fitYear, (string)null);
                    exname = true;

                }
               
                //month
                if (cmbFin1_month.SelectedIndex.Equals(-1))
                {
                    this.errorProvider1.SetError(cmbFin1_month, "Month is not selected.");
                    type = false;
                }
                else
                {
                    this.errorProvider1.SetError(cmbFin1_month, (string)null);
                    type = true;
                }
                


            }
            catch (Exception fd)
            {

                throw;
            }

            if (type == true && exname == true) return true;
            else return false;
        


    }

    private void btnFIn1_check_Click(object sender, EventArgs e)
        {
            if (validatefitness_Year())
            {
                        try
                {
                    int monthInDigit = DateTime.ParseExact(cmbFin1_month.SelectedItem.ToString(), "MMMM", CultureInfo.InvariantCulture).Month;
                    int year = int.Parse(txtFin_fitYear.Text);


                    Buisness_Logic.finace_repository fr = new Buisness_Logic.finace_repository();
                    Buisness_Logic.Finance ff = new Buisness_Logic.Finance();


                    if (fr.getIncome(year, monthInDigit, ff))
                    {

                        double amount = ff.amount;
                        txtFin1_income.Text = amount.ToString();
                    }

                    else
                    {
                        MessageBox.Show("No income record found.", "Infromation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }



                }
                catch (Exception exf1)
                {

                    throw;
                }
            }
            
            
        }

        private void btnFiNFITaa_Click(object sender, EventArgs e)
        {

         
        }

        private void btnThismonthTOto_Click(object sender, EventArgs e)
        {
            try
            {

                Buisness_Logic.finace_repository fr = new Buisness_Logic.finace_repository();

                Buisness_Logic.Finance ff = new Buisness_Logic.Finance();
                if (fr.getIncome_thisMonth( ff))
                {

                    double amount = ff.amount;
                    txtFin1_income.Text = amount.ToString();
                }

                else
                {
                    MessageBox.Show("No income record found.", "Infromation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception dfde)
            {

                throw;
            }
        }

        private void btnFin1_clear_Click(object sender, EventArgs e)
        {
            txtFin_fitYear.Text = "";
            txtFin1_income.Text = "";

        }
        //validation for sales
        public bool validate_sales()
        {



            bool exname, type;
            try
            {

                Buisness_Logic.validation val1 = new Buisness_Logic.validation();
                //Year
                if (!val1.IsNumeric(txtsalesyear.Text) && string.IsNullOrWhiteSpace(txtsalesyear.Text))
                {

                    this.errorProvider1.SetError(txtsalesyear, " Year is invalid.");
                    exname = false;

                }
                else
                {
                    this.errorProvider1.SetError(txtsalesyear, (string)null);
                    exname = true;

                }

                //month
                if (cmbFin2_month.SelectedIndex.Equals(-1))
                {
                    this.errorProvider1.SetError(cmbFin2_month, "Month is not selected.");
                    type = false;
                }
                else
                {
                    this.errorProvider1.SetError(cmbFin2_month, (string)null);
                    type = true;
                }



            }
            catch (Exception fd)
            {

                throw;
            }

            if (type == true && exname == true) return true;
            else return false;



        }

        private void btnFin2_check_Click(object sender, EventArgs e)
        {
            if (validate_sales())
            {
                try
                {
                    int monthInDigit = DateTime.ParseExact(cmbFin2_month.SelectedItem.ToString(), "MMMM", CultureInfo.InvariantCulture).Month;
                    int year = int.Parse(txtsalesyear.Text);


                    Buisness_Logic.finace_repository fr = new Buisness_Logic.finace_repository();
                    Buisness_Logic.Finance ff = new Buisness_Logic.Finance();
                    double amount, expens;
                    bool t1 = false, t2 = false;
                    if (fr.getIncomeOfSales(year, monthInDigit, ff))
                    {

                         amount = ff.amount;
                        txtFin2_income.Text = amount.ToString();
                        t1 = true;
                    }

                    else
                    {
                        MessageBox.Show("No income record found.", "Infromation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        amount = 0;
                    }

                    if (fr.getExpenseOfSales(year, monthInDigit, ff))
                    {
                         expens = ff.expenditure;
                        txtFin2_expense.Text = expens.ToString();
                        t2 = true;
                    }
                    else
                    {
                        MessageBox.Show("No expense record found.", "Infromation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        expens = 0;
                       
                    }


                    if(t1==true && t2 == true)
                    {
                        txtFin2_revenue.Text = (amount - expens).ToString();

                    }
                    else
                    {
                        clearSales();
                    }



                }
                catch (Exception exf1)
                {

                    throw;
                }
            }
        }
        private void clearSales()
        {
            txtFin2_income.Text = "";
            txtFin2_expense.Text = "";
            txtFin2_revenue.Text = "";
            txtsalesyear.Text = "";
            cmbFin2_month.SelectedIndex = -1;
            cmbFin2_month.Refresh();
        }
        private void btnFin2_clear_Click(object sender, EventArgs e)
        {
            clearSales();
        }

        private void btnFin3_check_Click(object sender, EventArgs e)
        {
            if (validate_os())
            {
                try
                {

                    int year = int.Parse(txtos_year.Text);
                    string month = cmbFin3Month.SelectedItem.ToString();
                    double incm = double.Parse(txtFin3_income.Text);
                    string type = cmbFin3_serviceType.SelectedItem.ToString();
                    string q = "insert into other_sevieces_income values(@y,@m,@a,@p)";

                    DataLayer.dbConnect con = new DataLayer.dbConnect();
                    con.openConnection();

                    SqlCommand cmd = new SqlCommand(q, con.getConnection());

                    cmd.Parameters.AddWithValue("@y", year);
                    cmd.Parameters.AddWithValue("@m", month);
                    cmd.Parameters.AddWithValue("@a", incm);
                    cmd.Parameters.AddWithValue("@p", incm);


                    cmd.ExecuteNonQuery();


                    MessageBox.Show("Succesfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception fdf)
                {

                    throw;
                }
            }
        }

        private void btnos_thismonth_Click(object sender, EventArgs e)
        {
            

          
        }

        public bool validate_os()
        {



            bool exname, type,st;
            try
            {

                Buisness_Logic.validation val1 = new Buisness_Logic.validation();
                //Year
                if (!val1.IsNumeric(txtos_year.Text) && string.IsNullOrWhiteSpace(txtos_year.Text))
                {

                    this.errorProvider1.SetError(txtos_year, " Year is invalid.");
                    exname = false;

                }
                else
                {
                    this.errorProvider1.SetError(txtos_year, (string)null);
                    exname = true;

                }

                //month
                if (cmbFin3Month.SelectedIndex.Equals(-1))
                {
                    this.errorProvider1.SetError(cmbFin3Month, "Month is not selected.");
                    type = false;
                }
                else
                {
                    this.errorProvider1.SetError(cmbFin3Month, (string)null);
                    type = true;
                }


                //service type
                if (cmbFin3_serviceType.SelectedIndex.Equals(-1))
                {
                    this.errorProvider1.SetError(cmbFin3_serviceType, "Service type is not selected.");
                    st = false;
                }
                else
                {
                    this.errorProvider1.SetError(cmbFin3_serviceType, (string)null);
                    st = true;
                }
            }
            catch (Exception fd)
            {

                throw;
            }

            if (type == true && exname == true && st==true) return true;
            else return false;



        }


        private void btn_os_getINcome_Click(object sender, EventArgs e)
        {
            if (validate_os())
            {
                try
                {
                    int monthInDigit = DateTime.ParseExact(cmbFin3Month.SelectedItem.ToString(), "MMMM", CultureInfo.InvariantCulture).Month;
                    int year = int.Parse(txtos_year.Text);
                    string service_type = cmbFin3_serviceType.SelectedItem.ToString();

                    Buisness_Logic.finace_repository fr = new Buisness_Logic.finace_repository();
                    Buisness_Logic.Finance ff = new Buisness_Logic.Finance();
                    double amount;
                    bool t1 = false, t2 = false;
                    if (fr.getIncomeOfOs(year, monthInDigit, ff,service_type))
                    {

                        amount = ff.amount;
                        txtFin3_income.Text = amount.ToString();
                        t1 = true;
                    }

                    else
                    {
                        MessageBox.Show("No income record found.", "Infromation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        amount = 0;
                    }

                    //if (fr.getExpenseOfSales(year, monthInDigit, ff))
                    //{
                    //    expens = ff.expenditure;
                    //    txtFin2_expense.Text = expens.ToString();
                    //    t2 = true;
                    //}
                    //else
                    //{
                    //    MessageBox.Show("No expense record found.", "Infromation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    expens = 0;

                    //}


                    //if (t1 == true && t2 == true)
                    //{
                    //    txtFin2_revenue.Text = (amount - expens).ToString();

                    //}
                    //else
                    //{
                    //    clearSales();
                    //}



                }
                catch (Exception exf1)
                {

                    throw;
                }
            }
        }

        private void btnFin3_clear_Click(object sender, EventArgs e)
        {

        }

        private void btnFin5_Add_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception df)
            {

                throw;
            }
        }

        private void btnFitness_savetodb_Click(object sender, EventArgs e)
        {
            if (validatefitness_Year())
            {
                try
                {

                    int year = int.Parse(txtFin_fitYear.Text);
                    string month = cmbFin1_month.SelectedItem.ToString();
                    double amount = double.Parse(txtFin1_income.Text);
                    string q = "insert into gym_income values(@y,@m,@a)";

                    DataLayer.dbConnect con = new DataLayer.dbConnect();
                    con.openConnection();

                    SqlCommand cmd = new SqlCommand(q, con.getConnection());

                    cmd.Parameters.AddWithValue("@y", year);
                    cmd.Parameters.AddWithValue("@m", month);
                    cmd.Parameters.AddWithValue("@a", amount);

                    cmd.ExecuteNonQuery();


                    MessageBox.Show("Succesfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception fdf)
                {

                    throw;
                }
            }
        }

        private void gdgfdgaetg_Click(object sender, EventArgs e)
        {
            if (validate_sales())
            {
                try
                {

                    int year = int.Parse(txtsalesyear.Text);
                    string month = cmbFin2_month.SelectedItem.ToString();
                    double incm = double.Parse(txtFin2_income.Text);
                    double rev = double.Parse(txtFin2_revenue.Text);
                    double expen = double.Parse(txtFin2_expense.Text);
                    string q = "insert into sales_finance values(@y,@m,@a,@e,@r)";

                    DataLayer.dbConnect con = new DataLayer.dbConnect();
                    con.openConnection();

                    SqlCommand cmd = new SqlCommand(q, con.getConnection());

                    cmd.Parameters.AddWithValue("@y", year);
                    cmd.Parameters.AddWithValue("@m", month);
                    cmd.Parameters.AddWithValue("@a", incm);
                    cmd.Parameters.AddWithValue("@e", expen);
                    cmd.Parameters.AddWithValue("@r", rev);

                    cmd.ExecuteNonQuery();


                    MessageBox.Show("Succesfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception fdf)
                {

                    throw;
                }
            }
        }
    }
}
