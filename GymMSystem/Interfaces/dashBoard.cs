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

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            Main ty = new Main();
            this.Hide();
            ty.Show();
        }
    }
}
