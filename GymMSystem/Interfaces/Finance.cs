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
    public partial class Finance : MetroForm
    {
        public Finance()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            this.StyleManager = metroStyleManager_fin;
           string year =  DateTime.Now.Year.ToString();
            string month = DateTime.Now.ToString("MMMM");
            year = txtFin_fitYear.Text = year;

            cmbFin1_month.SelectedItem = month;
            txtsalesyear.Text = year;
            cmbFin2_month.SelectedItem = month;




            //cmbFin1_month.Refresh();
        }

        private void btnFinHome_Click(object sender, EventArgs e)
        {
            Main fm = new Main();
            this.Hide();
            fm.Show();
        }

        public bool validatefitness_Year(string text) {

            if(string.IsNullOrWhiteSpace(text) ){

                MessageBox.Show("Enter the year.", "Infromation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else
            {if (!text.All(char.IsDigit))
                {
                    MessageBox.Show("Enter numbers only.", "Infromation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else return true;
               
            }
            
        }
        
        private void btnFIn1_check_Click(object sender, EventArgs e)
        {
            if (validatefitness_Year(txtFin_fitYear.Text))
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

        private void btnFin2_check_Click(object sender, EventArgs e)
        {
            if (validatefitness_Year(txtsalesyear.Text))
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
    }
}
