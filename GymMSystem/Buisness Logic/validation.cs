﻿using System;
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

        public bool IsNumeric(string number)
        {
            number.ToString();
            return Regex.Match(number, @"^([1-9][0-9]*)$").Success;

        }
        public  bool IsEmail(string email)
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
                MessageBox.Show("Email is not inserted!", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return true;
            }
            else if (Regex.IsMatch(email, MatchEmailPattern) && email!=null)
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
                MessageBox.Show("Phone number is not insertd!", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return true;
            }

            else if (IsNumeric(phone))
            {

                if (Regex.Match(phone, @"^(\+[0-9]{10})$").Success && phone != null)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Phone number is invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }


            }
            else
                return false;

            


           
        }

        public bool IsWord(string word)
        {

            return word.All(char.IsLetter);

            //Regex.Match(word, @"\w * ").Success;
        }


        public bool IsName(string name)
        {
            //if (string.IsNullOrWhiteSpace(name))
            //{
            //    MessageBox.Show("Name can not be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            //else
            if (IsWord(name))
                return true;

            else
            {
                MessageBox.Show("Name  is invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        public bool IsNIC (string nic)
        {

            bool condition = ((nic.Count(char.IsDigit) == 9) 
                && nic.EndsWith("X", StringComparison.OrdinalIgnoreCase) 
                || nic.EndsWith("V", StringComparison.OrdinalIgnoreCase) 
                && (nic[2] !='4' && nic[2] != '9' ));
            if (string.IsNullOrWhiteSpace(nic))
            {
                MessageBox.Show("NIC is not inserted!", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return true;
            }
            else if (condition)
                return true;

            else
            {
                MessageBox.Show("NIC  is invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


        }

        public bool IsAddress(string address)
        {
            bool chkAddress =  Regex.Match(address, @"\d{ 1,5}\s\w.\s(\b\w *\b\s){ 1,2}\w *\.) + (?:[A-Z][a-z.-]+[ ]?)+| (?:[A-Z][a-z.-]+[ ]?)+(?:[A-Z][a-z.-]+[ ]?)$").Success;

            if (string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show("Address can not be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (chkAddress)
                return true;
            else
            {
                MessageBox.Show("Address  is invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

       
        
        public bool IsHeight(string height)
        {
            if (!IsNumeric(height))
            {
                MessageBox.Show("Height should be a numeric value!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return false;
            }
            else if (double.Parse(height) > 250)
            {
                MessageBox.Show("Height should be less than the entered value!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return false;
            }
            else
                return true;
             
        }

        public bool IsWeight(string weight)
        {
            if (!IsNumeric(weight))
            {
                MessageBox.Show("Weight should be a numeric value!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return false;
            }
            else if (double.Parse(weight) > 500)
            {
                MessageBox.Show("Weight should be less than the entered value!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return false;
            }
            else
                return true;

        }
    }
}
