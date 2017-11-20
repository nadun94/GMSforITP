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
    public partial class Login : MetroForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
        Buisness_Logic.login lg = new Buisness_Logic.login();
       

        private void btnLogin_Click_1(object sender, EventArgs e)
        {

            try
            {


                lg.username = txtLogUsename.Text;
                lg.pwd = txtLogPwd.Text;

                if (lg.do_log())
                {
                    Buisness_Logic.global.sglobal = lg;
                    MessageBox.Show("Login successful.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Main mm = new Main();
                   
                    this.Hide();
                    mm.Show();
                }
                else
                {
                    MessageBox.Show("Login Failed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLogPwd.Text = "";
                    txtLogUsename.Text = "";
                    txtLogUsename.Focus();
                }
            }
            catch (Exception ffd)
            {

                throw;
            }
        }

        private void btnLogClear_Click(object sender, EventArgs e)
        {

        }
    }
}
