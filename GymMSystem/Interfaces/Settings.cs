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
            this.StyleManager = metroStyleManager1;
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

        private  void btnTheme_Click(object sender, EventArgs e)
        {
            metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            themCarrier tc = new themCarrier();
            tc.theme();
        }

        private void btnwhitetheme_Click(object sender, EventArgs e)
        {
            metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Light;
        }

        private void cmbtheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbtheme.SelectedIndex) {

                case 0:
                    metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
                    break;
                case 1:
                    metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Light;
                    break;
            }

        }
    }
}
