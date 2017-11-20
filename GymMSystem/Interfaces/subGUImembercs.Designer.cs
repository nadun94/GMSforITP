namespace GymMSystem.Interfaces
{
    partial class subGUImembercs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(subGUImembercs));
            this.PaneLSubAeor = new System.Windows.Forms.Panel();
            this.panelSubGm = new System.Windows.Forms.Panel();
            this.btnHome_settings = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // PaneLSubAeor
            // 
            this.PaneLSubAeor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PaneLSubAeor.BackColor = System.Drawing.Color.Transparent;
            this.PaneLSubAeor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PaneLSubAeor.BackgroundImage")));
            this.PaneLSubAeor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PaneLSubAeor.Location = new System.Drawing.Point(401, 173);
            this.PaneLSubAeor.Margin = new System.Windows.Forms.Padding(2);
            this.PaneLSubAeor.Name = "PaneLSubAeor";
            this.PaneLSubAeor.Size = new System.Drawing.Size(134, 161);
            this.PaneLSubAeor.TabIndex = 7;
            this.PaneLSubAeor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PaneLSubAeor_MouseClick);
            // 
            // panelSubGm
            // 
            this.panelSubGm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelSubGm.BackColor = System.Drawing.Color.Transparent;
            this.panelSubGm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelSubGm.BackgroundImage")));
            this.panelSubGm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelSubGm.Location = new System.Drawing.Point(62, 173);
            this.panelSubGm.Margin = new System.Windows.Forms.Padding(2);
            this.panelSubGm.Name = "panelSubGm";
            this.panelSubGm.Size = new System.Drawing.Size(134, 161);
            this.panelSubGm.TabIndex = 8;
            this.panelSubGm.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelSubGm_MouseClick);
            // 
            // btnHome_settings
            // 
            this.btnHome_settings.ActiveControl = null;
            this.btnHome_settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHome_settings.Location = new System.Drawing.Point(234, 380);
            this.btnHome_settings.Margin = new System.Windows.Forms.Padding(2);
            this.btnHome_settings.Name = "btnHome_settings";
            this.btnHome_settings.Size = new System.Drawing.Size(118, 105);
            this.btnHome_settings.Style = MetroFramework.MetroColorStyle.Lime;
            this.btnHome_settings.TabIndex = 46;
            this.btnHome_settings.Text = "Home";
            this.btnHome_settings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnHome_settings.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnHome_settings.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.btnHome_settings.UseSelectable = true;
            this.btnHome_settings.Click += new System.EventHandler(this.btnHome_settings_Click);
            // 
            // subGUImembercs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 507);
            this.Controls.Add(this.btnHome_settings);
            this.Controls.Add(this.panelSubGm);
            this.Controls.Add(this.PaneLSubAeor);
            this.Name = "subGUImembercs";
            this.Load += new System.EventHandler(this.subGUImembercs_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PaneLSubAeor;
        private System.Windows.Forms.Panel panelSubGm;
        private MetroFramework.Controls.MetroTile btnHome_settings;
    }
}