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
    public partial class Finance : MetroForm
    {
        public Finance()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }

        private void btnFinHome_Click(object sender, EventArgs e)
        {
            Main fm = new Main();
            this.Hide();
            fm.Show();
        }
    }
}
