namespace GymMSystem.Interfaces
{
    partial class dashBoard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dashBoard));
            this.panel8 = new System.Windows.Forms.Panel();
            this.lbldate = new System.Windows.Forms.Label();
            this.lblsecond = new System.Windows.Forms.Label();
            this.lbltime = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.panel13 = new System.Windows.Forms.Panel();
            this.pieChart2 = new LiveCharts.WinForms.PieChart();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.pieChart3 = new LiveCharts.WinForms.PieChart();
            this.panel10 = new System.Windows.Forms.Panel();
            this.cartesianChart2 = new LiveCharts.WinForms.CartesianChart();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.msmDash = new MetroFramework.Components.MetroStyleManager(this.components);
            this.btnHome_dashBoard = new MetroFramework.Controls.MetroTile();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel9.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.msmDash)).BeginInit();
            this.SuspendLayout();
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.panel8.Controls.Add(this.lbldate);
            this.panel8.Controls.Add(this.lblsecond);
            this.panel8.Controls.Add(this.lbltime);
            this.panel8.Controls.Add(this.pictureBox2);
            this.panel8.Controls.Add(this.label1);
            this.panel8.Location = new System.Drawing.Point(101, 50);
            this.panel8.Margin = new System.Windows.Forms.Padding(2);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(183, 457);
            this.panel8.TabIndex = 4;
            // 
            // lbldate
            // 
            this.lbldate.AutoSize = true;
            this.lbldate.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldate.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbldate.Location = new System.Drawing.Point(4, 420);
            this.lbldate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(187, 26);
            this.lbldate.TabIndex = 4;
            this.lbldate.Text = "AUGUST 26 2017";
            // 
            // lblsecond
            // 
            this.lblsecond.AutoSize = true;
            this.lblsecond.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsecond.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblsecond.Location = new System.Drawing.Point(114, 388);
            this.lblsecond.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblsecond.Name = "lblsecond";
            this.lblsecond.Size = new System.Drawing.Size(36, 25);
            this.lblsecond.TabIndex = 3;
            this.lblsecond.Text = "22";
            // 
            // lbltime
            // 
            this.lbltime.AutoSize = true;
            this.lbltime.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltime.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbltime.Location = new System.Drawing.Point(12, 381);
            this.lbltime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbltime.Name = "lbltime";
            this.lbltime.Size = new System.Drawing.Size(116, 37);
            this.lbltime.TabIndex = 2;
            this.lbltime.Text = "22 : 22";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(52, 86);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(36, 41);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dashboard";
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.panel9.Controls.Add(this.panel14);
            this.panel9.Controls.Add(this.panel13);
            this.panel9.Controls.Add(this.panel12);
            this.panel9.Controls.Add(this.panel11);
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Location = new System.Drawing.Point(287, 50);
            this.panel9.Margin = new System.Windows.Forms.Padding(2);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(574, 457);
            this.panel9.TabIndex = 5;
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            this.panel14.Controls.Add(this.cartesianChart1);
            this.panel14.Location = new System.Drawing.Point(310, 286);
            this.panel14.Margin = new System.Windows.Forms.Padding(2);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(262, 171);
            this.panel14.TabIndex = 3;
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.BackColor = System.Drawing.Color.Transparent;
            this.cartesianChart1.Location = new System.Drawing.Point(3, 16);
            this.cartesianChart1.Margin = new System.Windows.Forms.Padding(2);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(257, 143);
            this.cartesianChart1.TabIndex = 1;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            this.panel13.Controls.Add(this.pieChart2);
            this.panel13.Location = new System.Drawing.Point(2, 199);
            this.panel13.Margin = new System.Windows.Forms.Padding(2);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(306, 258);
            this.panel13.TabIndex = 1;
            // 
            // pieChart2
            // 
            this.pieChart2.BackColor = System.Drawing.Color.Transparent;
            this.pieChart2.Location = new System.Drawing.Point(28, 28);
            this.pieChart2.Margin = new System.Windows.Forms.Padding(2);
            this.pieChart2.Name = "pieChart2";
            this.pieChart2.Size = new System.Drawing.Size(275, 186);
            this.pieChart2.TabIndex = 0;
            this.pieChart2.Text = "pieChart2";
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            this.panel12.Location = new System.Drawing.Point(310, 150);
            this.panel12.Margin = new System.Windows.Forms.Padding(2);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(262, 132);
            this.panel12.TabIndex = 2;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            this.panel11.Controls.Add(this.pieChart3);
            this.panel11.Location = new System.Drawing.Point(310, 3);
            this.panel11.Margin = new System.Windows.Forms.Padding(2);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(264, 144);
            this.panel11.TabIndex = 1;
            // 
            // pieChart3
            // 
            this.pieChart3.BackColor = System.Drawing.Color.Transparent;
            this.pieChart3.Location = new System.Drawing.Point(65, 11);
            this.pieChart3.Margin = new System.Windows.Forms.Padding(2);
            this.pieChart3.Name = "pieChart3";
            this.pieChart3.Size = new System.Drawing.Size(178, 127);
            this.pieChart3.TabIndex = 1;
            this.pieChart3.Text = "pieChart3";
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            this.panel10.Controls.Add(this.cartesianChart2);
            this.panel10.Location = new System.Drawing.Point(2, 3);
            this.panel10.Margin = new System.Windows.Forms.Padding(2);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(306, 193);
            this.panel10.TabIndex = 0;
            // 
            // cartesianChart2
            // 
            this.cartesianChart2.BackColor = System.Drawing.Color.Transparent;
            this.cartesianChart2.Location = new System.Drawing.Point(13, 38);
            this.cartesianChart2.Margin = new System.Windows.Forms.Padding(2);
            this.cartesianChart2.Name = "cartesianChart2";
            this.cartesianChart2.Size = new System.Drawing.Size(276, 153);
            this.cartesianChart2.TabIndex = 0;
            this.cartesianChart2.Text = "cartesianChart2";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            // 
            // msmDash
            // 
            this.msmDash.Owner = this;
            this.msmDash.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // btnHome_dashBoard
            // 
            this.btnHome_dashBoard.ActiveControl = null;
            this.btnHome_dashBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHome_dashBoard.Location = new System.Drawing.Point(1277, 100);
            this.btnHome_dashBoard.Margin = new System.Windows.Forms.Padding(2);
            this.btnHome_dashBoard.Name = "btnHome_dashBoard";
            this.btnHome_dashBoard.Size = new System.Drawing.Size(100, 47);
            this.btnHome_dashBoard.Style = MetroFramework.MetroColorStyle.Yellow;
            this.btnHome_dashBoard.TabIndex = 46;
            this.btnHome_dashBoard.Text = "Home";
            this.btnHome_dashBoard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnHome_dashBoard.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnHome_dashBoard.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.btnHome_dashBoard.UseSelectable = true;
            this.btnHome_dashBoard.Click += new System.EventHandler(this.btnHome_dashBoard_Click);
            // 
            // dashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1657, 878);
            this.Controls.Add(this.btnHome_dashBoard);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel9);
            this.Name = "dashBoard";
            this.Text = "dashBoard";
            this.Load += new System.EventHandler(this.dashBoard_Load);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.msmDash)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label lbldate;
        private System.Windows.Forms.Label lblsecond;
        private System.Windows.Forms.Label lbltime;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel14;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private System.Windows.Forms.Panel panel13;
        private LiveCharts.WinForms.PieChart pieChart2;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel11;
        private LiveCharts.WinForms.PieChart pieChart3;
        private System.Windows.Forms.Panel panel10;
        private LiveCharts.WinForms.CartesianChart cartesianChart2;
        private System.Windows.Forms.Timer timer;
        private MetroFramework.Components.MetroStyleManager msmDash;
        private MetroFramework.Controls.MetroTile btnHome_dashBoard;
    }
}