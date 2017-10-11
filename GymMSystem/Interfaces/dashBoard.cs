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
    public partial class dashBoard : MetroForm
    {
        public dashBoard()
        {
            InitializeComponent();
        }

        private void dashBoard_Load(object sender, EventArgs e)
        {

        }

        private void btnHome_dashBoard_Click(object sender, EventArgs e)
        {
            Main dma = new Main();
            this.Hide();
            dma.Show();

        }
    }
}
