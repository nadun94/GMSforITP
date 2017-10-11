using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace GymMSystem.Buisness_Logic
{
    class validation
    {

        public bool IsNumeric(string number,string no)
        {
           // number.ToString();
            bool x = Regex.Match(number, @"^([1-9][0-9]*)$").Success;

            if (x) return true;
            else
            {
                MessageBox.Show(no+" is not in correct format.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            

            

        }
        public  bool IsEmail1(string email)
        {

            const string MatchEmailPattern =
                                    @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
                                    + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
			                	    [0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
                                    + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				                    [0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
                                    + @"([a-zA-Z0-9]+[\w-]+\.)+[a-zA-Z]{1}[a-zA-Z0-9-]{1,23})$";




            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Email feild is empty!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return true;
            }
            else
            {
                if (Regex.IsMatch(email, MatchEmailPattern) && email != null)
                    return true;


                else
                {
                    MessageBox.Show("Email is invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
                   
                 

        }
        public bool IsEmail2(string email)
        {

            const string MatchEmailPattern =
                                    @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
                                    + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
			                	    [0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
                                    + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				                    [0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
                                    + @"([a-zA-Z0-9]+[\w-]+\.)+[a-zA-Z]{1}[a-zA-Z0-9-]{1,23})$";



         if (Regex.IsMatch(email, MatchEmailPattern) && email != null)
                return true;


            else
            {
                MessageBox.Show("Email is invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }



        }


        public bool IsPhone(string phone)
        {




            if (string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("Phone number is not insertd!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }


            else
            {//Regex.Match(phone, @"^(\+[0-9]{10})$").Success
                if (phone.All(char.IsNumber) && phone != null)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Phone number is invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }









        }

        public bool IsWord(string word, string wordName)
        {

            if(!string.IsNullOrWhiteSpace(word)){

                if (word.All(char.IsLetter))
                {

                    return true;
                }
                else
                {
                    MessageBox.Show(wordName + " should be letters only.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;

                }

            }
            else
            {
                
                MessageBox.Show(wordName +" can not be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //Regex.Match(word, @"\w * ").Success;
        }


        //public bool IsName(string name)
        //{
        //    //if (string.IsNullOrWhiteSpace(name))
        //    //{
        //    //    MessageBox.Show("Name can not be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    //    return false;
        //    //}
        //    //else
        //    if (IsWord(name))
        //        return true;

        //    else
        //    {
        //        MessageBox.Show("Name  is invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }

        //}

        public bool IsNIC (string nic)
        {

            bool condition = ((nic.Count(char.IsDigit) == 9) 
                && nic.EndsWith("X", StringComparison.OrdinalIgnoreCase) 
                || nic.EndsWith("V", StringComparison.OrdinalIgnoreCase) 
                && (nic[2] !='4' && nic[2] != '9' ));

            if (!string.IsNullOrWhiteSpace(nic))
            {
               
                if (condition)
                    return true;

                else
                {
                    MessageBox.Show("NIC  is invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                
            }
            else
            {
               // MessageBox.Show("NIC is not inserted!", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return true;
            }



        }

        public bool IsAddress(string address)
        {
            bool chkAddress = address.All(char.IsLetterOrDigit);
                //Regex.Match(address, @"\d{ 1,5}\s\w.\s(\b\w *\b\s){ 1,2}\w *\.) + (?:[A-Z][a-z.-]+[ ]?)+| (?:[A-Z][a-z.-]+[ ]?)+(?:[A-Z][a-z.-]+[ ]?)$").Success;
            if (string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show("Address can not be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                if (chkAddress)
                    return true;
                else
                {
                    MessageBox.Show("Address  is invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
        }

       
        
        public bool IsHeight(string height)
        {
            if (!height.All(char.IsDigit))
            {
                MessageBox.Show("Height should be a numeric value!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (double.Parse(height) > 250)
            {
                MessageBox.Show("Height should be less than the entered value!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
                return true;
             
        }

        public bool IsWeight(string weight)
        {
            if (!weight.All(char.IsDigit))
            {
                MessageBox.Show("Weight should be a numeric value!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (double.Parse(weight) > 500)
            {
                MessageBox.Show("Weight should be less than the entered value!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
                return true;

        }
    }
}
