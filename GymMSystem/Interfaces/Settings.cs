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
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }

        private void btnHome_settings_Click(object sender, EventArgs e)
        {
            Main setmai = new Main();
            this.Hide();
            setmai.Show();
        }

        private void btnTheme_Click(object sender, EventArgs e)
        {

        }
    }
}
