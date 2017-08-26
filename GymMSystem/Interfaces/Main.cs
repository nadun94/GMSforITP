﻿using System;
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

            //window changing
            Interfaces.OtherServices ot = new Interfaces.OtherServices();

            this.Hide();
            ot.Show();
        }

        private void panel8_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {
            Interfaces.Members mem = new Interfaces.Members();
            this.Hide();
            mem.Show();
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
    }
}
