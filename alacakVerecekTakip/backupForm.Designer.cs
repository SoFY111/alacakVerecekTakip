namespace alacakVerecekTakip
{
    partial class backupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(backupForm));
            this.autoBackupGroup = new System.Windows.Forms.GroupBox();
            this.saveAutoBackupSettingsButton = new MetroFramework.Controls.MetroButton();
            this.everyTimeAutoBackupCheck = new MetroFramework.Controls.MetroCheckBox();
            this.everyTimeAutoBackupLabel = new MetroFramework.Controls.MetroLabel();
            this.autoBackupFrequencyCombo = new MetroFramework.Controls.MetroComboBox();
            this.autoBackupFrequencyLabel = new MetroFramework.Controls.MetroLabel();
            this.isAutoBackupLabel = new MetroFramework.Controls.MetroLabel();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.autoBackUpToggle = new MetroFramework.Controls.MetroToggle();
            this.onceBackupGroup = new System.Windows.Forms.GroupBox();
            this.onceBackupButton = new MetroFramework.Controls.MetroButton();
            this.onceBackupPathText = new MetroFramework.Controls.MetroTextBox();
            this.onceBackupPathLabel = new MetroFramework.Controls.MetroLabel();
            this.connectSituation = new MetroFramework.Controls.MetroTile();
            this.openBackupGroup = new System.Windows.Forms.GroupBox();
            this.openBackupButton = new MetroFramework.Controls.MetroButton();
            this.openBackupPathText = new MetroFramework.Controls.MetroTextBox();
            this.openBackupLabel = new MetroFramework.Controls.MetroLabel();
            this.infoLabel = new MetroFramework.Controls.MetroLabel();
            this.autoBackupGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.onceBackupGroup.SuspendLayout();
            this.openBackupGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // autoBackupGroup
            // 
            this.autoBackupGroup.Controls.Add(this.infoLabel);
            this.autoBackupGroup.Controls.Add(this.saveAutoBackupSettingsButton);
            this.autoBackupGroup.Controls.Add(this.everyTimeAutoBackupCheck);
            this.autoBackupGroup.Controls.Add(this.everyTimeAutoBackupLabel);
            this.autoBackupGroup.Controls.Add(this.autoBackupFrequencyCombo);
            this.autoBackupGroup.Controls.Add(this.autoBackupFrequencyLabel);
            this.autoBackupGroup.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.autoBackupGroup.ForeColor = System.Drawing.Color.DarkGray;
            this.autoBackupGroup.Location = new System.Drawing.Point(46, 105);
            this.autoBackupGroup.Name = "autoBackupGroup";
            this.autoBackupGroup.Size = new System.Drawing.Size(713, 133);
            this.autoBackupGroup.TabIndex = 0;
            this.autoBackupGroup.TabStop = false;
            this.autoBackupGroup.Text = "Otmatik Yedekeleme Ayarları";
            // 
            // saveAutoBackupSettingsButton
            // 
            this.saveAutoBackupSettingsButton.BackColor = System.Drawing.Color.Silver;
            this.saveAutoBackupSettingsButton.Enabled = false;
            this.saveAutoBackupSettingsButton.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.saveAutoBackupSettingsButton.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.saveAutoBackupSettingsButton.ForeColor = System.Drawing.Color.White;
            this.saveAutoBackupSettingsButton.Location = new System.Drawing.Point(597, 78);
            this.saveAutoBackupSettingsButton.Name = "saveAutoBackupSettingsButton";
            this.saveAutoBackupSettingsButton.Size = new System.Drawing.Size(75, 25);
            this.saveAutoBackupSettingsButton.TabIndex = 7;
            this.saveAutoBackupSettingsButton.Text = "KAYDET";
            this.saveAutoBackupSettingsButton.UseCustomBackColor = true;
            this.saveAutoBackupSettingsButton.UseCustomForeColor = true;
            this.saveAutoBackupSettingsButton.UseSelectable = true;
            this.saveAutoBackupSettingsButton.Click += new System.EventHandler(this.saveAutoBackupSettings_Click);
            // 
            // everyTimeAutoBackupCheck
            // 
            this.everyTimeAutoBackupCheck.AutoSize = true;
            this.everyTimeAutoBackupCheck.BackColor = System.Drawing.Color.Transparent;
            this.everyTimeAutoBackupCheck.BackgroundImage = global::alacakVerecekTakip.Properties.Resources.ok;
            this.everyTimeAutoBackupCheck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.everyTimeAutoBackupCheck.Checked = true;
            this.everyTimeAutoBackupCheck.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.everyTimeAutoBackupCheck.Enabled = false;
            this.everyTimeAutoBackupCheck.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.everyTimeAutoBackupCheck.Location = new System.Drawing.Point(640, 36);
            this.everyTimeAutoBackupCheck.Name = "everyTimeAutoBackupCheck";
            this.everyTimeAutoBackupCheck.Size = new System.Drawing.Size(45, 19);
            this.everyTimeAutoBackupCheck.TabIndex = 6;
            this.everyTimeAutoBackupCheck.Text = "     ";
            this.everyTimeAutoBackupCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.everyTimeAutoBackupCheck.UseCustomBackColor = true;
            this.everyTimeAutoBackupCheck.UseCustomForeColor = true;
            this.everyTimeAutoBackupCheck.UseSelectable = true;
            this.everyTimeAutoBackupCheck.CheckedChanged += new System.EventHandler(this.everyTimeAutoBackupCheck_CheckedChanged);
            // 
            // everyTimeAutoBackupLabel
            // 
            this.everyTimeAutoBackupLabel.AutoSize = true;
            this.everyTimeAutoBackupLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.everyTimeAutoBackupLabel.Location = new System.Drawing.Point(378, 35);
            this.everyTimeAutoBackupLabel.Name = "everyTimeAutoBackupLabel";
            this.everyTimeAutoBackupLabel.Size = new System.Drawing.Size(257, 19);
            this.everyTimeAutoBackupLabel.TabIndex = 5;
            this.everyTimeAutoBackupLabel.Text = "Program Her Açıldığında ve Kapandığında";
            this.everyTimeAutoBackupLabel.UseCustomForeColor = true;
            // 
            // autoBackupFrequencyCombo
            // 
            this.autoBackupFrequencyCombo.Enabled = false;
            this.autoBackupFrequencyCombo.ForeColor = System.Drawing.Color.Silver;
            this.autoBackupFrequencyCombo.FormattingEnabled = true;
            this.autoBackupFrequencyCombo.ItemHeight = 23;
            this.autoBackupFrequencyCombo.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "7",
            "10",
            "15",
            "30"});
            this.autoBackupFrequencyCombo.Location = new System.Drawing.Point(206, 30);
            this.autoBackupFrequencyCombo.Name = "autoBackupFrequencyCombo";
            this.autoBackupFrequencyCombo.Size = new System.Drawing.Size(161, 29);
            this.autoBackupFrequencyCombo.TabIndex = 4;
            this.autoBackupFrequencyCombo.UseSelectable = true;
            // 
            // autoBackupFrequencyLabel
            // 
            this.autoBackupFrequencyLabel.AutoSize = true;
            this.autoBackupFrequencyLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.autoBackupFrequencyLabel.Location = new System.Drawing.Point(59, 35);
            this.autoBackupFrequencyLabel.Name = "autoBackupFrequencyLabel";
            this.autoBackupFrequencyLabel.Size = new System.Drawing.Size(150, 19);
            this.autoBackupFrequencyLabel.TabIndex = 1;
            this.autoBackupFrequencyLabel.Text = "Yedekleme Sıklığı(Ayda):";
            this.autoBackupFrequencyLabel.UseCustomForeColor = true;
            // 
            // isAutoBackupLabel
            // 
            this.isAutoBackupLabel.AutoSize = true;
            this.isAutoBackupLabel.Location = new System.Drawing.Point(46, 80);
            this.isAutoBackupLabel.Name = "isAutoBackupLabel";
            this.isAutoBackupLabel.Size = new System.Drawing.Size(198, 19);
            this.isAutoBackupLabel.TabIndex = 1;
            this.isAutoBackupLabel.Text = "Otamatik Yedekleme Yapılsın Mı:";
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // autoBackUpToggle
            // 
            this.autoBackUpToggle.AutoSize = true;
            this.autoBackUpToggle.Location = new System.Drawing.Point(242, 82);
            this.autoBackUpToggle.Name = "autoBackUpToggle";
            this.autoBackUpToggle.Size = new System.Drawing.Size(80, 17);
            this.autoBackUpToggle.TabIndex = 2;
            this.autoBackUpToggle.Tag = "";
            this.autoBackUpToggle.Text = "Off";
            this.autoBackUpToggle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.autoBackUpToggle.UseSelectable = true;
            this.autoBackUpToggle.CheckedChanged += new System.EventHandler(this.autoBackUpToggle_CheckedChanged);
            // 
            // onceBackupGroup
            // 
            this.onceBackupGroup.Controls.Add(this.onceBackupButton);
            this.onceBackupGroup.Controls.Add(this.onceBackupPathText);
            this.onceBackupGroup.Controls.Add(this.onceBackupPathLabel);
            this.onceBackupGroup.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.onceBackupGroup.Location = new System.Drawing.Point(46, 244);
            this.onceBackupGroup.Name = "onceBackupGroup";
            this.onceBackupGroup.Size = new System.Drawing.Size(713, 82);
            this.onceBackupGroup.TabIndex = 3;
            this.onceBackupGroup.TabStop = false;
            this.onceBackupGroup.Text = "Yedek Al";
            // 
            // onceBackupButton
            // 
            this.onceBackupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.onceBackupButton.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.onceBackupButton.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.onceBackupButton.ForeColor = System.Drawing.Color.White;
            this.onceBackupButton.Location = new System.Drawing.Point(597, 29);
            this.onceBackupButton.Name = "onceBackupButton";
            this.onceBackupButton.Size = new System.Drawing.Size(75, 25);
            this.onceBackupButton.TabIndex = 3;
            this.onceBackupButton.Text = "Seç";
            this.onceBackupButton.UseCustomBackColor = true;
            this.onceBackupButton.UseCustomForeColor = true;
            this.onceBackupButton.UseSelectable = true;
            this.onceBackupButton.Click += new System.EventHandler(this.onceBackupButton_Click);
            // 
            // onceBackupPathText
            // 
            // 
            // 
            // 
            this.onceBackupPathText.CustomButton.Image = null;
            this.onceBackupPathText.CustomButton.Location = new System.Drawing.Point(361, 1);
            this.onceBackupPathText.CustomButton.Name = "";
            this.onceBackupPathText.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.onceBackupPathText.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.onceBackupPathText.CustomButton.TabIndex = 1;
            this.onceBackupPathText.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.onceBackupPathText.CustomButton.UseSelectable = true;
            this.onceBackupPathText.CustomButton.Visible = false;
            this.onceBackupPathText.Enabled = false;
            this.onceBackupPathText.Lines = new string[0];
            this.onceBackupPathText.Location = new System.Drawing.Point(206, 29);
            this.onceBackupPathText.MaxLength = 32767;
            this.onceBackupPathText.Name = "onceBackupPathText";
            this.onceBackupPathText.PasswordChar = '\0';
            this.onceBackupPathText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.onceBackupPathText.SelectedText = "";
            this.onceBackupPathText.SelectionLength = 0;
            this.onceBackupPathText.SelectionStart = 0;
            this.onceBackupPathText.ShortcutsEnabled = true;
            this.onceBackupPathText.Size = new System.Drawing.Size(385, 25);
            this.onceBackupPathText.TabIndex = 2;
            this.onceBackupPathText.UseSelectable = true;
            this.onceBackupPathText.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.onceBackupPathText.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // onceBackupPathLabel
            // 
            this.onceBackupPathLabel.AutoSize = true;
            this.onceBackupPathLabel.Location = new System.Drawing.Point(30, 31);
            this.onceBackupPathLabel.Name = "onceBackupPathLabel";
            this.onceBackupPathLabel.Size = new System.Drawing.Size(177, 19);
            this.onceBackupPathLabel.TabIndex = 0;
            this.onceBackupPathLabel.Text = "Yedeklemenin Yapılacağı Yer:";
            // 
            // connectSituation
            // 
            this.connectSituation.ActiveControl = null;
            this.connectSituation.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.connectSituation.ForeColor = System.Drawing.Color.Lime;
            this.connectSituation.Location = new System.Drawing.Point(23, 429);
            this.connectSituation.Name = "connectSituation";
            this.connectSituation.Size = new System.Drawing.Size(18, 18);
            this.connectSituation.TabIndex = 12;
            this.connectSituation.UseCustomBackColor = true;
            this.connectSituation.UseSelectable = true;
            // 
            // openBackupGroup
            // 
            this.openBackupGroup.Controls.Add(this.openBackupButton);
            this.openBackupGroup.Controls.Add(this.openBackupPathText);
            this.openBackupGroup.Controls.Add(this.openBackupLabel);
            this.openBackupGroup.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.openBackupGroup.Location = new System.Drawing.Point(46, 332);
            this.openBackupGroup.Name = "openBackupGroup";
            this.openBackupGroup.Size = new System.Drawing.Size(713, 82);
            this.openBackupGroup.TabIndex = 13;
            this.openBackupGroup.TabStop = false;
            this.openBackupGroup.Text = "Yedeği Yükle";
            // 
            // openBackupButton
            // 
            this.openBackupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.openBackupButton.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.openBackupButton.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.openBackupButton.ForeColor = System.Drawing.Color.White;
            this.openBackupButton.Location = new System.Drawing.Point(597, 29);
            this.openBackupButton.Name = "openBackupButton";
            this.openBackupButton.Size = new System.Drawing.Size(75, 25);
            this.openBackupButton.TabIndex = 3;
            this.openBackupButton.Text = "Seç";
            this.openBackupButton.UseCustomBackColor = true;
            this.openBackupButton.UseCustomForeColor = true;
            this.openBackupButton.UseSelectable = true;
            this.openBackupButton.Click += new System.EventHandler(this.openBackupButton_Click);
            // 
            // openBackupPathText
            // 
            // 
            // 
            // 
            this.openBackupPathText.CustomButton.Image = null;
            this.openBackupPathText.CustomButton.Location = new System.Drawing.Point(361, 1);
            this.openBackupPathText.CustomButton.Name = "";
            this.openBackupPathText.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.openBackupPathText.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.openBackupPathText.CustomButton.TabIndex = 1;
            this.openBackupPathText.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.openBackupPathText.CustomButton.UseSelectable = true;
            this.openBackupPathText.CustomButton.Visible = false;
            this.openBackupPathText.Enabled = false;
            this.openBackupPathText.Lines = new string[0];
            this.openBackupPathText.Location = new System.Drawing.Point(206, 29);
            this.openBackupPathText.MaxLength = 32767;
            this.openBackupPathText.Name = "openBackupPathText";
            this.openBackupPathText.PasswordChar = '\0';
            this.openBackupPathText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.openBackupPathText.SelectedText = "";
            this.openBackupPathText.SelectionLength = 0;
            this.openBackupPathText.SelectionStart = 0;
            this.openBackupPathText.ShortcutsEnabled = true;
            this.openBackupPathText.Size = new System.Drawing.Size(385, 25);
            this.openBackupPathText.TabIndex = 2;
            this.openBackupPathText.UseSelectable = true;
            this.openBackupPathText.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.openBackupPathText.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // openBackupLabel
            // 
            this.openBackupLabel.AutoSize = true;
            this.openBackupLabel.Location = new System.Drawing.Point(68, 31);
            this.openBackupLabel.Name = "openBackupLabel";
            this.openBackupLabel.Size = new System.Drawing.Size(137, 19);
            this.openBackupLabel.TabIndex = 0;
            this.openBackupLabel.Text = "Kaynak Yedek Dosyası:";
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.infoLabel.Location = new System.Drawing.Point(157, 81);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(440, 19);
            this.infoLabel.TabIndex = 8;
            this.infoLabel.Text = "Otamatik yedeklemeler \'C:\\AlacakVerecekTakipYedek\' klasörüne yedeklenir";
            this.infoLabel.UseCustomForeColor = true;
            // 
            // backupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 461);
            this.Controls.Add(this.openBackupGroup);
            this.Controls.Add(this.connectSituation);
            this.Controls.Add(this.onceBackupGroup);
            this.Controls.Add(this.autoBackUpToggle);
            this.Controls.Add(this.isAutoBackupLabel);
            this.Controls.Add(this.autoBackupGroup);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "backupForm";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "Yedekleme Ayarları";
            this.Load += new System.EventHandler(this.backupForm_Load);
            this.autoBackupGroup.ResumeLayout(false);
            this.autoBackupGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.onceBackupGroup.ResumeLayout(false);
            this.onceBackupGroup.PerformLayout();
            this.openBackupGroup.ResumeLayout(false);
            this.openBackupGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox autoBackupGroup;
        private MetroFramework.Controls.MetroLabel isAutoBackupLabel;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroToggle autoBackUpToggle;
        private MetroFramework.Controls.MetroLabel autoBackupFrequencyLabel;
        private MetroFramework.Controls.MetroCheckBox everyTimeAutoBackupCheck;
        private MetroFramework.Controls.MetroLabel everyTimeAutoBackupLabel;
        private MetroFramework.Controls.MetroComboBox autoBackupFrequencyCombo;
        private System.Windows.Forms.GroupBox onceBackupGroup;
        private MetroFramework.Controls.MetroButton onceBackupButton;
        private MetroFramework.Controls.MetroTextBox onceBackupPathText;
        private MetroFramework.Controls.MetroLabel onceBackupPathLabel;
        private MetroFramework.Controls.MetroTile connectSituation;
        private MetroFramework.Controls.MetroButton saveAutoBackupSettingsButton;
        private System.Windows.Forms.GroupBox openBackupGroup;
        private MetroFramework.Controls.MetroButton openBackupButton;
        private MetroFramework.Controls.MetroTextBox openBackupPathText;
        private MetroFramework.Controls.MetroLabel openBackupLabel;
        private MetroFramework.Controls.MetroLabel infoLabel;
    }
}