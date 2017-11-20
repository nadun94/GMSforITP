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

namespace GymMSystem
{
    public partial class Main : MetroForm   
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        

        private void panel6_MouseClick(object sender, MouseEventArgs e)
        {

           
        }

        private void panel8_MouseClick(object sender, MouseEventArgs e)
        {
            Interfaces.Settings sett = new Interfaces.Settings();
            this.Hide();
            sett.Show();
        }

        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {
            Interfaces.subGUImembercs sub = new Interfaces.subGUImembercs();
            this.Hide();
            sub.Show();

        }

        private void panel7_MouseClick(object sender, MouseEventArgs e)
        {
            Interfaces.Finance fin = new Interfaces.Finance();
            this.Hide();
            fin.Show();
        }

        private void panel9_MouseClick(object sender, MouseEventArgs e)
        {
            Interfaces.inventory inv = new Interfaces.inventory();
            this.Hide();
            inv.Show();
        }

        private void panel4_MouseClick(object sender, MouseEventArgs e)
        {
            Interfaces.Emplyee emp = new Interfaces.Emplyee();
            this.Hide();
            emp.Show();
        }

        private void panel5_MouseClick(object sender, MouseEventArgs e)
        {
            Interfaces.salesManagement ss = new Interfaces.salesManagement();
            this.Hide();
            ss.Show();
        }

        private void panel10_MouseClick(object sender, MouseEventArgs e)
        {
            Interfaces.dashBoard dbd = new Interfaces.dashBoard();
            this.Hide();
            dbd.Show();
        }

        private void pan_Execises_MouseClick(object sender, MouseEventArgs e)
        {
            Interfaces.workouts tr = new Interfaces.workouts();
            this.Hide();
            tr.Show();

        }
    }
}
