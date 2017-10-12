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
            this.tabTheme = new MetroFramework.Controls.MetroTabPage();
            this.btnTheme = new MetroFramework.Controls.MetroTile();
            this.btnwhitetheme = new MetroFramework.Controls.MetroTile();
            this.settingsTab.SuspendLayout();
            this.tabTheme.SuspendLayout();
            this.SuspendLayout();
            // 
            // settingsTab
            // 
            this.settingsTab.Controls.Add(this.employeeTab);
            this.settingsTab.Controls.Add(this.tabTheme);
            this.settingsTab.FontSize = MetroFramework.MetroTabControlSize.Tall;
            this.settingsTab.FontWeight = MetroFramework.MetroTabControlWeight.Bold;
            this.settingsTab.ItemSize = new System.Drawing.Size(200, 70);
            this.settingsTab.Location = new System.Drawing.Point(35, 61);
            this.settingsTab.Margin = new System.Windows.Forms.Padding(4, 12, 4, 4);
            this.settingsTab.Name = "settingsTab";
            this.settingsTab.SelectedIndex = 1;
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
            // tabTheme
            // 
            this.tabTheme.Controls.Add(this.btnwhitetheme);
            this.tabTheme.Controls.Add(this.btnTheme);
            this.tabTheme.HorizontalScrollbarBarColor = true;
            this.tabTheme.HorizontalScrollbarHighlightOnWheel = false;
            this.tabTheme.HorizontalScrollbarSize = 10;
            this.tabTheme.Location = new System.Drawing.Point(4, 74);
            this.tabTheme.Name = "tabTheme";
            this.tabTheme.Size = new System.Drawing.Size(1578, 678);
            this.tabTheme.TabIndex = 6;
            this.tabTheme.Text = "Appearance";
            this.tabTheme.VerticalScrollbarBarColor = true;
            this.tabTheme.VerticalScrollbarHighlightOnWheel = false;
            this.tabTheme.VerticalScrollbarSize = 10;
            // 
            // btnTheme
            // 
            this.btnTheme.ActiveControl = null;
            this.btnTheme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTheme.Location = new System.Drawing.Point(196, 113);
            this.btnTheme.Margin = new System.Windows.Forms.Padding(2);
            this.btnTheme.Name = "btnTheme";
            this.btnTheme.Size = new System.Drawing.Size(197, 173);
            this.btnTheme.Style = MetroFramework.MetroColorStyle.Red;
            this.btnTheme.TabIndex = 46;
            this.btnTheme.Text = "Black Theme";
            this.btnTheme.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnTheme.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnTheme.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.btnTheme.UseSelectable = true;
            this.btnTheme.Click += new System.EventHandler(this.btnTheme_Click);
            // 
            // btnwhitetheme
            // 
            this.btnwhitetheme.ActiveControl = null;
            this.btnwhitetheme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnwhitetheme.Location = new System.Drawing.Point(551, 113);
            this.btnwhitetheme.Margin = new System.Windows.Forms.Padding(2);
            this.btnwhitetheme.Name = "btnwhitetheme";
            this.btnwhitetheme.Size = new System.Drawing.Size(197, 173);
            this.btnwhitetheme.Style = MetroFramework.MetroColorStyle.Red;
            this.btnwhitetheme.TabIndex = 47;
            this.btnwhitetheme.Text = "White Theme";
            this.btnwhitetheme.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnwhitetheme.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnwhitetheme.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.btnwhitetheme.UseSelectable = true;
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
            this.tabTheme.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl settingsTab;
        private MetroFramework.Controls.MetroTabPage employeeTab;
        private MetroFramework.Controls.MetroTile btnHome_settings;
        private MetroFramework.Controls.MetroTabPage tabTheme;
        private MetroFramework.Controls.MetroTile btnwhitetheme;
        private MetroFramework.Controls.MetroTile btnTheme;
    }
}