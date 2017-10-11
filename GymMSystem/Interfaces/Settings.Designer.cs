namespace GymMSystem.Interfaces
{
    partial class Settings
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
            this.settingsTab = new MetroFramework.Controls.MetroTabControl();
            this.employeeTab = new MetroFramework.Controls.MetroTabPage();
            this.btnHome_settings = new MetroFramework.Controls.MetroTile();
            this.settingsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // settingsTab
            // 
            this.settingsTab.Controls.Add(this.employeeTab);
            this.settingsTab.FontSize = MetroFramework.MetroTabControlSize.Tall;
            this.settingsTab.FontWeight = MetroFramework.MetroTabControlWeight.Bold;
            this.settingsTab.ItemSize = new System.Drawing.Size(200, 70);
            this.settingsTab.Location = new System.Drawing.Point(35, 61);
            this.settingsTab.Margin = new System.Windows.Forms.Padding(4, 12, 4, 4);
            this.settingsTab.Name = "settingsTab";
            this.settingsTab.SelectedIndex = 0;
            this.settingsTab.Size = new System.Drawing.Size(1586, 756);
            this.settingsTab.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.settingsTab.Style = MetroFramework.MetroColorStyle.Magenta;
            this.settingsTab.TabIndex = 2;
            this.settingsTab.TabStop = false;
            this.settingsTab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.settingsTab.UseSelectable = true;
            // 
            // employeeTab
            // 
            this.employeeTab.HorizontalScrollbarBarColor = true;
            this.employeeTab.HorizontalScrollbarHighlightOnWheel = false;
            this.employeeTab.HorizontalScrollbarSize = 10;
            this.employeeTab.Location = new System.Drawing.Point(4, 74);
            this.employeeTab.Name = "employeeTab";
            this.employeeTab.Size = new System.Drawing.Size(1578, 678);
            this.employeeTab.TabIndex = 5;
            this.employeeTab.Text = "Settings";
            this.employeeTab.Theme = MetroFramework.MetroThemeStyle.Light;
            this.employeeTab.VerticalScrollbarBarColor = true;
            this.employeeTab.VerticalScrollbarHighlightOnWheel = false;
            this.employeeTab.VerticalScrollbarSize = 10;
            // 
            // btnHome_settings
            // 
            this.btnHome_settings.ActiveControl = null;
            this.btnHome_settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHome_settings.Location = new System.Drawing.Point(1254, 44);
            this.btnHome_settings.Margin = new System.Windows.Forms.Padding(2);
            this.btnHome_settings.Name = "btnHome_settings";
            this.btnHome_settings.Size = new System.Drawing.Size(100, 47);
            this.btnHome_settings.Style = MetroFramework.MetroColorStyle.Yellow;
            this.btnHome_settings.TabIndex = 45;
            this.btnHome_settings.Text = "Home";
            this.btnHome_settings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnHome_settings.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnHome_settings.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.btnHome_settings.UseSelectable = true;
            this.btnHome_settings.Click += new System.EventHandler(this.btnHome_settings_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1657, 878);
            this.Controls.Add(this.btnHome_settings);
            this.Controls.Add(this.settingsTab);
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.settingsTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl settingsTab;
        private MetroFramework.Controls.MetroTabPage employeeTab;
        private MetroFramework.Controls.MetroTile btnHome_settings;
    }
}