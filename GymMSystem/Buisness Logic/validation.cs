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


            //@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"

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

            const string MatchEmailPattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";



         if (Regex.IsMatch(email, MatchEmailPattern) && email != null)
                return true;


            else
            {
              //  MessageBox.Show("Email is invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }



        }


        public bool IsPhone(string phone)
        {

            const string MatchphonePattern = @"(^[0-9]{10}$)|(^\+[0-9]{2}\s+[0-9]{2}[0-9]{8}$)|(^[0-9]{3}-[0-9]{4}-[0-9]{4}$)";



            if (Regex.IsMatch(phone, MatchphonePattern) && phone != null)
                return true;


            else
            {
               
                return false;
            }

            //(^[0-9]{10}$)|(^\+[0-9]{2}\s+[0-9]{2}[0-9]{8}$)|(^[0-9]{3}-[0-9]{4}-[0-9]{4}$)


            //if (string.IsNullOrWhiteSpace(phone))
            //{
            //    MessageBox.Show("Phone number is not insertd!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return true;
            //}


            //else
            //{//Regex.Match(phone, @"^(\+[0-9]{10})$").Success
            //    if (phone.All(char.IsNumber) && phone != null)
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        MessageBox.Show("Phone number is invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return false;
            //    }
        }




        public bool IsName(string name)
        {
            

            const string MatchName = @"^[A-z][A-z|\.|\s]+$";
            


            if (Regex.IsMatch(name, MatchName) && name != null)
                return true;


            else return false;




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
                   // MessageBox.Show("NIC  is invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            //@"^[A-Za-z0-9]+(?:\s[A-Za-z0-9'_-]+)+$"

            const string MatchAddress = @"^[A-Za-z0-9]+(?:\s[A-Za-z0-9'_-]+)+$";



            if (Regex.IsMatch(address, MatchAddress) && address != null)
                return true;


            else return false;

        }


        const string matchnumeric = @"-?\d+(?:\.\d+)?";
        public bool IsHeight(string height)
        {
            
            if (!Regex.IsMatch(height, matchnumeric))
            {
            
                return false;
            }
            else if (double.Parse(height) > 250 || double.Parse(height)<=0)
            {
                MessageBox.Show("Height should be less than the entered value!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
                return true;
             
        }

        public bool IsWeight(string weight)
        {
            if (!Regex.IsMatch(weight, matchnumeric))
            {

                return false;
            }
            else if (double.Parse(weight) > 500 || double.Parse(weight)<=1)
            {
                MessageBox.Show("Weight should be less than the entered value!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
                return true;

        }
    }
}
