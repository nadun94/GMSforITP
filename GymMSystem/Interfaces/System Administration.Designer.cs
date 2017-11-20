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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.settingsTab = new MetroFramework.Controls.MetroTabControl();
            this.employeeTab = new MetroFramework.Controls.MetroTabPage();
            this.tabTheme = new MetroFramework.Controls.MetroTabPage();
            this.cmbtheme = new MetroFramework.Controls.MetroComboBox();
            this.btnwhitetheme = new MetroFramework.Controls.MetroTile();
            this.btnTheme = new MetroFramework.Controls.MetroTile();
            this.btnHome_settings = new MetroFramework.Controls.MetroTile();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.tab_OtherServices = new MetroFramework.Controls.MetroTabPage();
            this.dataGriddServices = new MetroFramework.Controls.MetroGrid();
            this.btnOS1_delete = new MetroFramework.Controls.MetroTile();
            this.btnOS1_update = new MetroFramework.Controls.MetroTile();
            this.btnOS1_clear = new MetroFramework.Controls.MetroTile();
            this.btnOS1_Save = new MetroFramework.Controls.MetroTile();
            this.cmbOS1_day = new MetroFramework.Controls.MetroComboBox();
            this.radio_mc = new MetroFramework.Controls.MetroRadioButton();
            this.radio_hc = new MetroFramework.Controls.MetroRadioButton();
            this.txtOS1_EndingTime = new MetroFramework.Controls.MetroTextBox();
            this.txtOS1_statingTime = new MetroFramework.Controls.MetroTextBox();
            this.lbl_monthlyRate = new MetroFramework.Controls.MetroLabel();
            this.txtOS1_Rate = new MetroFramework.Controls.MetroTextBox();
            this.lbl_hr = new MetroFramework.Controls.MetroLabel();
            this.txt_cordinator = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtOS1_name = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.BtnSearch = new MetroFramework.Controls.MetroTile();
            this.settingsTab.SuspendLayout();
            this.tabTheme.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.tab_OtherServices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGriddServices)).BeginInit();
            this.SuspendLayout();
            // 
            // settingsTab
            // 
            this.settingsTab.Controls.Add(this.employeeTab);
            this.settingsTab.Controls.Add(this.tabTheme);
            this.settingsTab.Controls.Add(this.tab_OtherServices);
            this.settingsTab.FontSize = MetroFramework.MetroTabControlSize.Tall;
            this.settingsTab.FontWeight = MetroFramework.MetroTabControlWeight.Bold;
            this.settingsTab.ItemSize = new System.Drawing.Size(200, 70);
            this.settingsTab.Location = new System.Drawing.Point(35, 61);
            this.settingsTab.Margin = new System.Windows.Forms.Padding(4, 12, 4, 4);
            this.settingsTab.Name = "settingsTab";
            this.settingsTab.SelectedIndex = 2;
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
            // tabTheme
            // 
            this.tabTheme.Controls.Add(this.cmbtheme);
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
            // cmbtheme
            // 
            this.cmbtheme.FormattingEnabled = true;
            this.cmbtheme.ItemHeight = 23;
            this.cmbtheme.Items.AddRange(new object[] {
            "Dark",
            "White"});
            this.cmbtheme.Location = new System.Drawing.Point(1013, 46);
            this.cmbtheme.Name = "cmbtheme";
            this.cmbtheme.Size = new System.Drawing.Size(202, 29);
            this.cmbtheme.TabIndex = 48;
            this.cmbtheme.UseSelectable = true;
            this.cmbtheme.SelectedIndexChanged += new System.EventHandler(this.cmbtheme_SelectedIndexChanged);
            // 
            // btnwhitetheme
            // 
            this.btnwhitetheme.ActiveControl = null;
            this.btnwhitetheme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnwhitetheme.Location = new System.Drawing.Point(497, 70);
            this.btnwhitetheme.Margin = new System.Windows.Forms.Padding(2);
            this.btnwhitetheme.Name = "btnwhitetheme";
            this.btnwhitetheme.Size = new System.Drawing.Size(348, 354);
            this.btnwhitetheme.Style = MetroFramework.MetroColorStyle.Orange;
            this.btnwhitetheme.TabIndex = 47;
            this.btnwhitetheme.Text = "White Theme";
            this.btnwhitetheme.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnwhitetheme.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnwhitetheme.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.btnwhitetheme.UseSelectable = true;
            this.btnwhitetheme.Click += new System.EventHandler(this.btnwhitetheme_Click);
            // 
            // btnTheme
            // 
            this.btnTheme.ActiveControl = null;
            this.btnTheme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTheme.Location = new System.Drawing.Point(50, 70);
            this.btnTheme.Margin = new System.Windows.Forms.Padding(2);
            this.btnTheme.Name = "btnTheme";
            this.btnTheme.Size = new System.Drawing.Size(345, 354);
            this.btnTheme.Style = MetroFramework.MetroColorStyle.Orange;
            this.btnTheme.TabIndex = 46;
            this.btnTheme.Text = "Black Theme";
            this.btnTheme.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnTheme.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnTheme.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.btnTheme.UseSelectable = true;
            this.btnTheme.Click += new System.EventHandler(this.btnTheme_Click);
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
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // tab_OtherServices
            // 
            this.tab_OtherServices.Controls.Add(this.BtnSearch);
            this.tab_OtherServices.Controls.Add(this.dataGriddServices);
            this.tab_OtherServices.Controls.Add(this.btnOS1_delete);
            this.tab_OtherServices.Controls.Add(this.btnOS1_update);
            this.tab_OtherServices.Controls.Add(this.btnOS1_clear);
            this.tab_OtherServices.Controls.Add(this.btnOS1_Save);
            this.tab_OtherServices.Controls.Add(this.cmbOS1_day);
            this.tab_OtherServices.Controls.Add(this.radio_mc);
            this.tab_OtherServices.Controls.Add(this.radio_hc);
            this.tab_OtherServices.Controls.Add(this.txtOS1_EndingTime);
            this.tab_OtherServices.Controls.Add(this.txtOS1_statingTime);
            this.tab_OtherServices.Controls.Add(this.lbl_monthlyRate);
            this.tab_OtherServices.Controls.Add(this.txtOS1_Rate);
            this.tab_OtherServices.Controls.Add(this.lbl_hr);
            this.tab_OtherServices.Controls.Add(this.txt_cordinator);
            this.tab_OtherServices.Controls.Add(this.metroLabel4);
            this.tab_OtherServices.Controls.Add(this.metroLabel3);
            this.tab_OtherServices.Controls.Add(this.metroLabel2);
            this.tab_OtherServices.Controls.Add(this.metroLabel1);
            this.tab_OtherServices.Controls.Add(this.txtOS1_name);
            this.tab_OtherServices.Controls.Add(this.metroLabel8);
            this.tab_OtherServices.HorizontalScrollbarBarColor = true;
            this.tab_OtherServices.HorizontalScrollbarHighlightOnWheel = false;
            this.tab_OtherServices.HorizontalScrollbarSize = 10;
            this.tab_OtherServices.Location = new System.Drawing.Point(4, 74);
            this.tab_OtherServices.Name = "tab_OtherServices";
            this.tab_OtherServices.Size = new System.Drawing.Size(1578, 678);
            this.tab_OtherServices.TabIndex = 7;
            this.tab_OtherServices.Text = "Services";
            this.tab_OtherServices.VerticalScrollbarBarColor = true;
            this.tab_OtherServices.VerticalScrollbarHighlightOnWheel = false;
            this.tab_OtherServices.VerticalScrollbarSize = 10;
            this.tab_OtherServices.Click += new System.EventHandler(this.tab_OtherServices_Click);
            // 
            // dataGriddServices
            // 
            this.dataGriddServices.AllowUserToResizeRows = false;
            this.dataGriddServices.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGriddServices.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGriddServices.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGriddServices.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGriddServices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGriddServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGriddServices.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGriddServices.EnableHeadersVisualStyles = false;
            this.dataGriddServices.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGriddServices.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGriddServices.Location = new System.Drawing.Point(255, 403);
            this.dataGriddServices.Name = "dataGriddServices";
            this.dataGriddServices.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGriddServices.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGriddServices.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGriddServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGriddServices.Size = new System.Drawing.Size(905, 302);
            this.dataGriddServices.TabIndex = 56;
            this.dataGriddServices.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGriddServices_CellClick);
            // 
            // btnOS1_delete
            // 
            this.btnOS1_delete.ActiveControl = null;
            this.btnOS1_delete.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnOS1_delete.Location = new System.Drawing.Point(1404, 246);
            this.btnOS1_delete.Margin = new System.Windows.Forms.Padding(2);
            this.btnOS1_delete.Name = "btnOS1_delete";
            this.btnOS1_delete.Size = new System.Drawing.Size(110, 43);
            this.btnOS1_delete.Style = MetroFramework.MetroColorStyle.Teal;
            this.btnOS1_delete.TabIndex = 55;
            this.btnOS1_delete.Text = "Delete";
            this.btnOS1_delete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOS1_delete.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnOS1_delete.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.btnOS1_delete.UseSelectable = true;
            // 
            // btnOS1_update
            // 
            this.btnOS1_update.ActiveControl = null;
            this.btnOS1_update.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnOS1_update.Location = new System.Drawing.Point(1404, 180);
            this.btnOS1_update.Margin = new System.Windows.Forms.Padding(2);
            this.btnOS1_update.Name = "btnOS1_update";
            this.btnOS1_update.Size = new System.Drawing.Size(110, 43);
            this.btnOS1_update.Style = MetroFramework.MetroColorStyle.Teal;
            this.btnOS1_update.TabIndex = 54;
            this.btnOS1_update.Text = "Update";
            this.btnOS1_update.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOS1_update.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnOS1_update.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.btnOS1_update.UseSelectable = true;
            this.btnOS1_update.Click += new System.EventHandler(this.btnOS1_update_Click);
            // 
            // btnOS1_clear
            // 
            this.btnOS1_clear.ActiveControl = null;
            this.btnOS1_clear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnOS1_clear.Location = new System.Drawing.Point(1228, 253);
            this.btnOS1_clear.Margin = new System.Windows.Forms.Padding(2);
            this.btnOS1_clear.Name = "btnOS1_clear";
            this.btnOS1_clear.Size = new System.Drawing.Size(110, 43);
            this.btnOS1_clear.Style = MetroFramework.MetroColorStyle.Teal;
            this.btnOS1_clear.TabIndex = 53;
            this.btnOS1_clear.Text = "Clear";
            this.btnOS1_clear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOS1_clear.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnOS1_clear.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.btnOS1_clear.UseSelectable = true;
            this.btnOS1_clear.Click += new System.EventHandler(this.btnOS1_clear_Click);
            // 
            // btnOS1_Save
            // 
            this.btnOS1_Save.ActiveControl = null;
            this.btnOS1_Save.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnOS1_Save.Location = new System.Drawing.Point(1228, 180);
            this.btnOS1_Save.Margin = new System.Windows.Forms.Padding(2);
            this.btnOS1_Save.Name = "btnOS1_Save";
            this.btnOS1_Save.Size = new System.Drawing.Size(110, 43);
            this.btnOS1_Save.Style = MetroFramework.MetroColorStyle.Teal;
            this.btnOS1_Save.TabIndex = 52;
            this.btnOS1_Save.Text = "Save";
            this.btnOS1_Save.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOS1_Save.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnOS1_Save.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.btnOS1_Save.UseSelectable = true;
            this.btnOS1_Save.Click += new System.EventHandler(this.btnOS1_Save_Click);
            // 
            // cmbOS1_day
            // 
            this.cmbOS1_day.FormattingEnabled = true;
            this.cmbOS1_day.ItemHeight = 23;
            this.cmbOS1_day.Items.AddRange(new object[] {
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday"});
            this.cmbOS1_day.Location = new System.Drawing.Point(822, 212);
            this.cmbOS1_day.Margin = new System.Windows.Forms.Padding(2);
            this.cmbOS1_day.Name = "cmbOS1_day";
            this.cmbOS1_day.Size = new System.Drawing.Size(162, 29);
            this.cmbOS1_day.TabIndex = 51;
            this.cmbOS1_day.Theme = MetroFramework.MetroThemeStyle.Light;
            this.cmbOS1_day.UseSelectable = true;
            // 
            // radio_mc
            // 
            this.radio_mc.AutoSize = true;
            this.radio_mc.Checked = true;
            this.radio_mc.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.radio_mc.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.radio_mc.Location = new System.Drawing.Point(705, 130);
            this.radio_mc.Margin = new System.Windows.Forms.Padding(2);
            this.radio_mc.Name = "radio_mc";
            this.radio_mc.Size = new System.Drawing.Size(246, 25);
            this.radio_mc.TabIndex = 50;
            this.radio_mc.TabStop = true;
            this.radio_mc.Text = "Monthly Chargin Services";
            this.radio_mc.Theme = MetroFramework.MetroThemeStyle.Light;
            this.radio_mc.UseSelectable = true;
            this.radio_mc.CheckedChanged += new System.EventHandler(this.radio_mc_CheckedChanged);
            // 
            // radio_hc
            // 
            this.radio_hc.AutoSize = true;
            this.radio_hc.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.radio_hc.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.radio_hc.Location = new System.Drawing.Point(406, 130);
            this.radio_hc.Margin = new System.Windows.Forms.Padding(2);
            this.radio_hc.Name = "radio_hc";
            this.radio_hc.Size = new System.Drawing.Size(243, 25);
            this.radio_hc.TabIndex = 49;
            this.radio_hc.Text = "Hourly Charging Services";
            this.radio_hc.Theme = MetroFramework.MetroThemeStyle.Light;
            this.radio_hc.UseSelectable = true;
            this.radio_hc.CheckedChanged += new System.EventHandler(this.radio_hc_CheckedChanged);
            // 
            // txtOS1_EndingTime
            // 
            // 
            // 
            // 
            this.txtOS1_EndingTime.CustomButton.Image = null;
            this.txtOS1_EndingTime.CustomButton.Location = new System.Drawing.Point(172, 1);
            this.txtOS1_EndingTime.CustomButton.Name = "";
            this.txtOS1_EndingTime.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtOS1_EndingTime.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtOS1_EndingTime.CustomButton.TabIndex = 1;
            this.txtOS1_EndingTime.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtOS1_EndingTime.CustomButton.UseSelectable = true;
            this.txtOS1_EndingTime.CustomButton.Visible = false;
            this.txtOS1_EndingTime.Lines = new string[0];
            this.txtOS1_EndingTime.Location = new System.Drawing.Point(822, 338);
            this.txtOS1_EndingTime.Margin = new System.Windows.Forms.Padding(2);
            this.txtOS1_EndingTime.MaxLength = 32767;
            this.txtOS1_EndingTime.Name = "txtOS1_EndingTime";
            this.txtOS1_EndingTime.PasswordChar = '\0';
            this.txtOS1_EndingTime.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtOS1_EndingTime.SelectedText = "";
            this.txtOS1_EndingTime.SelectionLength = 0;
            this.txtOS1_EndingTime.SelectionStart = 0;
            this.txtOS1_EndingTime.ShortcutsEnabled = true;
            this.txtOS1_EndingTime.Size = new System.Drawing.Size(194, 23);
            this.txtOS1_EndingTime.TabIndex = 47;
            this.txtOS1_EndingTime.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtOS1_EndingTime.UseSelectable = true;
            this.txtOS1_EndingTime.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtOS1_EndingTime.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtOS1_statingTime
            // 
            // 
            // 
            // 
            this.txtOS1_statingTime.CustomButton.Image = null;
            this.txtOS1_statingTime.CustomButton.Location = new System.Drawing.Point(172, 1);
            this.txtOS1_statingTime.CustomButton.Name = "";
            this.txtOS1_statingTime.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtOS1_statingTime.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtOS1_statingTime.CustomButton.TabIndex = 1;
            this.txtOS1_statingTime.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtOS1_statingTime.CustomButton.UseSelectable = true;
            this.txtOS1_statingTime.CustomButton.Visible = false;
            this.txtOS1_statingTime.Lines = new string[0];
            this.txtOS1_statingTime.Location = new System.Drawing.Point(822, 273);
            this.txtOS1_statingTime.Margin = new System.Windows.Forms.Padding(2);
            this.txtOS1_statingTime.MaxLength = 32767;
            this.txtOS1_statingTime.Name = "txtOS1_statingTime";
            this.txtOS1_statingTime.PasswordChar = '\0';
            this.txtOS1_statingTime.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtOS1_statingTime.SelectedText = "";
            this.txtOS1_statingTime.SelectionLength = 0;
            this.txtOS1_statingTime.SelectionStart = 0;
            this.txtOS1_statingTime.ShortcutsEnabled = true;
            this.txtOS1_statingTime.Size = new System.Drawing.Size(194, 23);
            this.txtOS1_statingTime.TabIndex = 46;
            this.txtOS1_statingTime.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtOS1_statingTime.UseSelectable = true;
            this.txtOS1_statingTime.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtOS1_statingTime.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lbl_monthlyRate
            // 
            this.lbl_monthlyRate.AutoSize = true;
            this.lbl_monthlyRate.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lbl_monthlyRate.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lbl_monthlyRate.Location = new System.Drawing.Point(240, 277);
            this.lbl_monthlyRate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_monthlyRate.Name = "lbl_monthlyRate";
            this.lbl_monthlyRate.Size = new System.Drawing.Size(128, 25);
            this.lbl_monthlyRate.Style = MetroFramework.MetroColorStyle.Black;
            this.lbl_monthlyRate.TabIndex = 43;
            this.lbl_monthlyRate.Text = "Fee per Month";
            this.lbl_monthlyRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_monthlyRate.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // txtOS1_Rate
            // 
            // 
            // 
            // 
            this.txtOS1_Rate.CustomButton.Image = null;
            this.txtOS1_Rate.CustomButton.Location = new System.Drawing.Point(172, 1);
            this.txtOS1_Rate.CustomButton.Name = "";
            this.txtOS1_Rate.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtOS1_Rate.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtOS1_Rate.CustomButton.TabIndex = 1;
            this.txtOS1_Rate.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtOS1_Rate.CustomButton.UseSelectable = true;
            this.txtOS1_Rate.CustomButton.Visible = false;
            this.txtOS1_Rate.Lines = new string[0];
            this.txtOS1_Rate.Location = new System.Drawing.Point(390, 279);
            this.txtOS1_Rate.Margin = new System.Windows.Forms.Padding(2);
            this.txtOS1_Rate.MaxLength = 32767;
            this.txtOS1_Rate.Name = "txtOS1_Rate";
            this.txtOS1_Rate.PasswordChar = '\0';
            this.txtOS1_Rate.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtOS1_Rate.SelectedText = "";
            this.txtOS1_Rate.SelectionLength = 0;
            this.txtOS1_Rate.SelectionStart = 0;
            this.txtOS1_Rate.ShortcutsEnabled = true;
            this.txtOS1_Rate.Size = new System.Drawing.Size(194, 23);
            this.txtOS1_Rate.TabIndex = 45;
            this.txtOS1_Rate.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtOS1_Rate.UseSelectable = true;
            this.txtOS1_Rate.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtOS1_Rate.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lbl_hr
            // 
            this.lbl_hr.AutoSize = true;
            this.lbl_hr.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lbl_hr.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lbl_hr.Location = new System.Drawing.Point(240, 275);
            this.lbl_hr.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_hr.Name = "lbl_hr";
            this.lbl_hr.Size = new System.Drawing.Size(105, 25);
            this.lbl_hr.Style = MetroFramework.MetroColorStyle.Black;
            this.lbl_hr.TabIndex = 42;
            this.lbl_hr.Text = "Hourly Rate";
            this.lbl_hr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_hr.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // txt_cordinator
            // 
            // 
            // 
            // 
            this.txt_cordinator.CustomButton.Image = null;
            this.txt_cordinator.CustomButton.Location = new System.Drawing.Point(172, 1);
            this.txt_cordinator.CustomButton.Name = "";
            this.txt_cordinator.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txt_cordinator.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_cordinator.CustomButton.TabIndex = 1;
            this.txt_cordinator.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_cordinator.CustomButton.UseSelectable = true;
            this.txt_cordinator.CustomButton.Visible = false;
            this.txt_cordinator.Lines = new string[0];
            this.txt_cordinator.Location = new System.Drawing.Point(390, 333);
            this.txt_cordinator.Margin = new System.Windows.Forms.Padding(2);
            this.txt_cordinator.MaxLength = 32767;
            this.txt_cordinator.Name = "txt_cordinator";
            this.txt_cordinator.PasswordChar = '\0';
            this.txt_cordinator.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_cordinator.SelectedText = "";
            this.txt_cordinator.SelectionLength = 0;
            this.txt_cordinator.SelectionStart = 0;
            this.txt_cordinator.ShortcutsEnabled = true;
            this.txt_cordinator.Size = new System.Drawing.Size(194, 23);
            this.txt_cordinator.TabIndex = 44;
            this.txt_cordinator.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_cordinator.UseSelectable = true;
            this.txt_cordinator.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_cordinator.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(717, 338);
            this.metroLabel4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(65, 25);
            this.metroLabel4.Style = MetroFramework.MetroColorStyle.Black;
            this.metroLabel4.TabIndex = 41;
            this.metroLabel4.Text = "End At";
            this.metroLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(717, 275);
            this.metroLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(90, 25);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Black;
            this.metroLabel3.TabIndex = 40;
            this.metroLabel3.Text = "Stating At";
            this.metroLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(716, 212);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(43, 25);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Black;
            this.metroLabel2.TabIndex = 39;
            this.metroLabel2.Text = "Day";
            this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(240, 333);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(97, 25);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Black;
            this.metroLabel1.TabIndex = 38;
            this.metroLabel1.Text = "Cordinator";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // txtOS1_name
            // 
            // 
            // 
            // 
            this.txtOS1_name.CustomButton.Image = null;
            this.txtOS1_name.CustomButton.Location = new System.Drawing.Point(172, 1);
            this.txtOS1_name.CustomButton.Name = "";
            this.txtOS1_name.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtOS1_name.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtOS1_name.CustomButton.TabIndex = 1;
            this.txtOS1_name.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtOS1_name.CustomButton.UseSelectable = true;
            this.txtOS1_name.CustomButton.Visible = false;
            this.txtOS1_name.Lines = new string[0];
            this.txtOS1_name.Location = new System.Drawing.Point(390, 209);
            this.txtOS1_name.Margin = new System.Windows.Forms.Padding(2);
            this.txtOS1_name.MaxLength = 32767;
            this.txtOS1_name.Name = "txtOS1_name";
            this.txtOS1_name.PasswordChar = '\0';
            this.txtOS1_name.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtOS1_name.SelectedText = "";
            this.txtOS1_name.SelectionLength = 0;
            this.txtOS1_name.SelectionStart = 0;
            this.txtOS1_name.ShortcutsEnabled = true;
            this.txtOS1_name.Size = new System.Drawing.Size(194, 23);
            this.txtOS1_name.TabIndex = 48;
            this.txtOS1_name.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtOS1_name.UseSelectable = true;
            this.txtOS1_name.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtOS1_name.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel8.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel8.Location = new System.Drawing.Point(240, 209);
            this.metroLabel8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(119, 25);
            this.metroLabel8.Style = MetroFramework.MetroColorStyle.Black;
            this.metroLabel8.TabIndex = 37;
            this.metroLabel8.Text = "Service Name";
            this.metroLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel8.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // BtnSearch
            // 
            this.BtnSearch.ActiveControl = null;
            this.BtnSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnSearch.Location = new System.Drawing.Point(1276, 320);
            this.BtnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(198, 43);
            this.BtnSearch.Style = MetroFramework.MetroColorStyle.Teal;
            this.BtnSearch.TabIndex = 57;
            this.BtnSearch.Text = "View Services";
            this.BtnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnSearch.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.BtnSearch.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.BtnSearch.UseSelectable = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
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
            this.Theme = MetroFramework.MetroThemeStyle.Default;
            this.Load += new System.EventHandler(this.Settings_Load);
            this.settingsTab.ResumeLayout(false);
            this.tabTheme.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.tab_OtherServices.ResumeLayout(false);
            this.tab_OtherServices.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGriddServices)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl settingsTab;
        private MetroFramework.Controls.MetroTabPage employeeTab;
        private MetroFramework.Controls.MetroTile btnHome_settings;
        private MetroFramework.Controls.MetroTabPage tabTheme;
        private MetroFramework.Controls.MetroTile btnwhitetheme;
        private MetroFramework.Controls.MetroTile btnTheme;
        private MetroFramework.Controls.MetroComboBox cmbtheme;
        public MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroTabPage tab_OtherServices;
        private MetroFramework.Controls.MetroGrid dataGriddServices;
        private MetroFramework.Controls.MetroTile btnOS1_delete;
        private MetroFramework.Controls.MetroTile btnOS1_update;
        private MetroFramework.Controls.MetroTile btnOS1_clear;
        private MetroFramework.Controls.MetroTile btnOS1_Save;
        private MetroFramework.Controls.MetroComboBox cmbOS1_day;
        private MetroFramework.Controls.MetroRadioButton radio_mc;
        private MetroFramework.Controls.MetroRadioButton radio_hc;
        private MetroFramework.Controls.MetroTextBox txtOS1_EndingTime;
        private MetroFramework.Controls.MetroTextBox txtOS1_statingTime;
        private MetroFramework.Controls.MetroLabel lbl_monthlyRate;
        private MetroFramework.Controls.MetroTextBox txtOS1_Rate;
        private MetroFramework.Controls.MetroLabel lbl_hr;
        private MetroFramework.Controls.MetroTextBox txt_cordinator;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtOS1_name;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroTile BtnSearch;
    }
}