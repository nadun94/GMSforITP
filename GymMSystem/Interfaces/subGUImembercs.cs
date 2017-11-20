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

namespace GymMSystem.Interfaces
{
    public partial class subGUImembercs : MetroForm
    {
        public subGUImembercs()
        {
            InitializeComponent();
        }

        private void subGUImembercs_Load(object sender, EventArgs e)
        {

        }

        private void PaneLSubAeor_MouseClick(object sender, MouseEventArgs e)
        {
            //window changing
           OtherServices ot = new OtherServices();

            this.Hide();
            ot.Show();
        }

        private void panelSubGm_MouseClick(object sender, MouseEventArgs e)
        {
            Interfaces.Members mem = new Interfaces.Members();
            this.Hide();
            mem.Show();
        }

        private void btnHome_settings_Click(object sender, EventArgs e)
        {
            Main mn = new Main();
            this.Hide();
            mn.Show();
        }
    }
}
