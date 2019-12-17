namespace alacakVerecekTakip
{
    partial class userSettingsForm
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
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.connectSituation = new MetroFramework.Controls.MetroTile();
            this.usernameGroupBox = new System.Windows.Forms.GroupBox();
            this.newNameLabel = new MetroFramework.Controls.MetroLabel();
            this.saveNewNameButton = new MetroFramework.Controls.MetroTile();
            this.oldNameLabel = new MetroFramework.Controls.MetroLabel();
            this.newNameText = new MetroFramework.Controls.MetroTextBox();
            this.oldNameText = new MetroFramework.Controls.MetroTextBox();
            this.passwordGroupBox = new System.Windows.Forms.GroupBox();
            this.saveNewPasswordButton = new MetroFramework.Controls.MetroTile();
            this.againNewPasswordText = new MetroFramework.Controls.MetroTextBox();
            this.againNewPasswordLabel = new MetroFramework.Controls.MetroLabel();
            this.newPasswordText = new MetroFramework.Controls.MetroTextBox();
            this.newPasswordLabel = new MetroFramework.Controls.MetroLabel();
            this.oldPasswordText = new MetroFramework.Controls.MetroTextBox();
            this.oldPasswordLabel = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.usernameGroupBox.SuspendLayout();
            this.passwordGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // connectSituation
            // 
            this.connectSituation.ActiveControl = null;
            this.connectSituation.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.connectSituation.ForeColor = System.Drawing.Color.Lime;
            this.connectSituation.Location = new System.Drawing.Point(23, 352);
            this.connectSituation.Name = "connectSituation";
            this.connectSituation.Size = new System.Drawing.Size(18, 18);
            this.connectSituation.TabIndex = 9;
            this.connectSituation.UseCustomBackColor = true;
            this.connectSituation.UseSelectable = true;
            // 
            // usernameGroupBox
            // 
            this.usernameGroupBox.Controls.Add(this.newNameLabel);
            this.usernameGroupBox.Controls.Add(this.saveNewNameButton);
            this.usernameGroupBox.Controls.Add(this.oldNameLabel);
            this.usernameGroupBox.Controls.Add(this.newNameText);
            this.usernameGroupBox.Controls.Add(this.oldNameText);
            this.usernameGroupBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.usernameGroupBox.ForeColor = System.Drawing.Color.Black;
            this.usernameGroupBox.Location = new System.Drawing.Point(23, 63);
            this.usernameGroupBox.Name = "usernameGroupBox";
            this.usernameGroupBox.Size = new System.Drawing.Size(661, 98);
            this.usernameGroupBox.TabIndex = 10;
            this.usernameGroupBox.TabStop = false;
            this.usernameGroupBox.Text = "Kullanıcı Adı Düzenle";
            // 
            // newNameLabel
            // 
            this.newNameLabel.AutoSize = true;
            this.newNameLabel.Location = new System.Drawing.Point(245, 42);
            this.newNameLabel.Name = "newNameLabel";
            this.newNameLabel.Size = new System.Drawing.Size(109, 19);
            this.newNameLabel.TabIndex = 3;
            this.newNameLabel.Text = "Yeni Kullanıcı Adı:";
            // 
            // saveNewNameButton
            // 
            this.saveNewNameButton.ActiveControl = null;
            this.saveNewNameButton.Location = new System.Drawing.Point(486, 37);
            this.saveNewNameButton.Name = "saveNewNameButton";
            this.saveNewNameButton.Size = new System.Drawing.Size(162, 32);
            this.saveNewNameButton.TabIndex = 11;
            this.saveNewNameButton.Text = "KAYDET";
            this.saveNewNameButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.saveNewNameButton.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.saveNewNameButton.TileTextFontSize = MetroFramework.MetroTileTextSize.Small;
            this.saveNewNameButton.UseSelectable = true;
            this.saveNewNameButton.Click += new System.EventHandler(this.saveNewNameButton_Click);
            // 
            // oldNameLabel
            // 
            this.oldNameLabel.AutoSize = true;
            this.oldNameLabel.Location = new System.Drawing.Point(10, 43);
            this.oldNameLabel.Name = "oldNameLabel";
            this.oldNameLabel.Size = new System.Drawing.Size(107, 19);
            this.oldNameLabel.TabIndex = 2;
            this.oldNameLabel.Text = "Eski Kullanıcı Adı:";
            // 
            // newNameText
            // 
            // 
            // 
            // 
            this.newNameText.CustomButton.Image = null;
            this.newNameText.CustomButton.Location = new System.Drawing.Point(94, 2);
            this.newNameText.CustomButton.Name = "";
            this.newNameText.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.newNameText.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.newNameText.CustomButton.TabIndex = 1;
            this.newNameText.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.newNameText.CustomButton.UseSelectable = true;
            this.newNameText.CustomButton.Visible = false;
            this.newNameText.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.newNameText.Lines = new string[0];
            this.newNameText.Location = new System.Drawing.Point(360, 39);
            this.newNameText.MaxLength = 32767;
            this.newNameText.Name = "newNameText";
            this.newNameText.PasswordChar = '\0';
            this.newNameText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.newNameText.SelectedText = "";
            this.newNameText.SelectionLength = 0;
            this.newNameText.SelectionStart = 0;
            this.newNameText.ShortcutsEnabled = true;
            this.newNameText.Size = new System.Drawing.Size(120, 28);
            this.newNameText.TabIndex = 1;
            this.newNameText.UseSelectable = true;
            this.newNameText.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.newNameText.WaterMarkFont = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            // 
            // oldNameText
            // 
            // 
            // 
            // 
            this.oldNameText.CustomButton.Image = null;
            this.oldNameText.CustomButton.Location = new System.Drawing.Point(94, 2);
            this.oldNameText.CustomButton.Name = "";
            this.oldNameText.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.oldNameText.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.oldNameText.CustomButton.TabIndex = 1;
            this.oldNameText.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.oldNameText.CustomButton.UseSelectable = true;
            this.oldNameText.CustomButton.Visible = false;
            this.oldNameText.Enabled = false;
            this.oldNameText.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.oldNameText.Lines = new string[0];
            this.oldNameText.Location = new System.Drawing.Point(123, 39);
            this.oldNameText.MaxLength = 32767;
            this.oldNameText.Name = "oldNameText";
            this.oldNameText.PasswordChar = '\0';
            this.oldNameText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.oldNameText.SelectedText = "";
            this.oldNameText.SelectionLength = 0;
            this.oldNameText.SelectionStart = 0;
            this.oldNameText.ShortcutsEnabled = true;
            this.oldNameText.Size = new System.Drawing.Size(120, 28);
            this.oldNameText.TabIndex = 0;
            this.oldNameText.UseSelectable = true;
            this.oldNameText.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.oldNameText.WaterMarkFont = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            // 
            // passwordGroupBox
            // 
            this.passwordGroupBox.Controls.Add(this.saveNewPasswordButton);
            this.passwordGroupBox.Controls.Add(this.againNewPasswordText);
            this.passwordGroupBox.Controls.Add(this.againNewPasswordLabel);
            this.passwordGroupBox.Controls.Add(this.newPasswordText);
            this.passwordGroupBox.Controls.Add(this.newPasswordLabel);
            this.passwordGroupBox.Controls.Add(this.oldPasswordText);
            this.passwordGroupBox.Controls.Add(this.oldPasswordLabel);
            this.passwordGroupBox.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.passwordGroupBox.Location = new System.Drawing.Point(23, 167);
            this.passwordGroupBox.Name = "passwordGroupBox";
            this.passwordGroupBox.Size = new System.Drawing.Size(661, 179);
            this.passwordGroupBox.TabIndex = 11;
            this.passwordGroupBox.TabStop = false;
            this.passwordGroupBox.Text = "Şifre Düzenle";
            // 
            // saveNewPasswordButton
            // 
            this.saveNewPasswordButton.ActiveControl = null;
            this.saveNewPasswordButton.Location = new System.Drawing.Point(277, 132);
            this.saveNewPasswordButton.Name = "saveNewPasswordButton";
            this.saveNewPasswordButton.Size = new System.Drawing.Size(120, 32);
            this.saveNewPasswordButton.TabIndex = 12;
            this.saveNewPasswordButton.Text = "KAYDET";
            this.saveNewPasswordButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.saveNewPasswordButton.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.saveNewPasswordButton.TileTextFontSize = MetroFramework.MetroTileTextSize.Small;
            this.saveNewPasswordButton.UseSelectable = true;
            this.saveNewPasswordButton.Click += new System.EventHandler(this.saveNewPasswordButton_Click);
            // 
            // againNewPasswordText
            // 
            // 
            // 
            // 
            this.againNewPasswordText.CustomButton.Image = null;
            this.againNewPasswordText.CustomButton.Location = new System.Drawing.Point(94, 2);
            this.againNewPasswordText.CustomButton.Name = "";
            this.againNewPasswordText.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.againNewPasswordText.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.againNewPasswordText.CustomButton.TabIndex = 1;
            this.againNewPasswordText.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.againNewPasswordText.CustomButton.UseSelectable = true;
            this.againNewPasswordText.CustomButton.Visible = false;
            this.againNewPasswordText.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.againNewPasswordText.Lines = new string[0];
            this.againNewPasswordText.Location = new System.Drawing.Point(277, 98);
            this.againNewPasswordText.MaxLength = 32767;
            this.againNewPasswordText.Name = "againNewPasswordText";
            this.againNewPasswordText.PasswordChar = '*';
            this.againNewPasswordText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.againNewPasswordText.SelectedText = "";
            this.againNewPasswordText.SelectionLength = 0;
            this.againNewPasswordText.SelectionStart = 0;
            this.againNewPasswordText.ShortcutsEnabled = true;
            this.againNewPasswordText.Size = new System.Drawing.Size(120, 28);
            this.againNewPasswordText.TabIndex = 5;
            this.againNewPasswordText.UseSelectable = true;
            this.againNewPasswordText.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.againNewPasswordText.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // againNewPasswordLabel
            // 
            this.againNewPasswordLabel.AutoSize = true;
            this.againNewPasswordLabel.Location = new System.Drawing.Point(171, 102);
            this.againNewPasswordLabel.Name = "againNewPasswordLabel";
            this.againNewPasswordLabel.Size = new System.Drawing.Size(105, 19);
            this.againNewPasswordLabel.TabIndex = 4;
            this.againNewPasswordLabel.Text = "Yeni Şifre Tekrar:";
            // 
            // newPasswordText
            // 
            // 
            // 
            // 
            this.newPasswordText.CustomButton.Image = null;
            this.newPasswordText.CustomButton.Location = new System.Drawing.Point(94, 2);
            this.newPasswordText.CustomButton.Name = "";
            this.newPasswordText.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.newPasswordText.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.newPasswordText.CustomButton.TabIndex = 1;
            this.newPasswordText.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.newPasswordText.CustomButton.UseSelectable = true;
            this.newPasswordText.CustomButton.Visible = false;
            this.newPasswordText.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.newPasswordText.Lines = new string[0];
            this.newPasswordText.Location = new System.Drawing.Point(277, 64);
            this.newPasswordText.MaxLength = 32767;
            this.newPasswordText.Name = "newPasswordText";
            this.newPasswordText.PasswordChar = '*';
            this.newPasswordText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.newPasswordText.SelectedText = "";
            this.newPasswordText.SelectionLength = 0;
            this.newPasswordText.SelectionStart = 0;
            this.newPasswordText.ShortcutsEnabled = true;
            this.newPasswordText.Size = new System.Drawing.Size(120, 28);
            this.newPasswordText.TabIndex = 3;
            this.newPasswordText.UseSelectable = true;
            this.newPasswordText.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.newPasswordText.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // newPasswordLabel
            // 
            this.newPasswordLabel.AutoSize = true;
            this.newPasswordLabel.Location = new System.Drawing.Point(210, 69);
            this.newPasswordLabel.Name = "newPasswordLabel";
            this.newPasswordLabel.Size = new System.Drawing.Size(65, 19);
            this.newPasswordLabel.TabIndex = 2;
            this.newPasswordLabel.Text = "Yeni Şifre:";
            // 
            // oldPasswordText
            // 
            // 
            // 
            // 
            this.oldPasswordText.CustomButton.Image = null;
            this.oldPasswordText.CustomButton.Location = new System.Drawing.Point(94, 2);
            this.oldPasswordText.CustomButton.Name = "";
            this.oldPasswordText.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.oldPasswordText.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.oldPasswordText.CustomButton.TabIndex = 1;
            this.oldPasswordText.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.oldPasswordText.CustomButton.UseSelectable = true;
            this.oldPasswordText.CustomButton.Visible = false;
            this.oldPasswordText.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.oldPasswordText.Lines = new string[0];
            this.oldPasswordText.Location = new System.Drawing.Point(277, 30);
            this.oldPasswordText.MaxLength = 32767;
            this.oldPasswordText.Name = "oldPasswordText";
            this.oldPasswordText.PasswordChar = '*';
            this.oldPasswordText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.oldPasswordText.SelectedText = "";
            this.oldPasswordText.SelectionLength = 0;
            this.oldPasswordText.SelectionStart = 0;
            this.oldPasswordText.ShortcutsEnabled = true;
            this.oldPasswordText.Size = new System.Drawing.Size(120, 28);
            this.oldPasswordText.TabIndex = 1;
            this.oldPasswordText.UseSelectable = true;
            this.oldPasswordText.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.oldPasswordText.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // oldPasswordLabel
            // 
            this.oldPasswordLabel.AutoSize = true;
            this.oldPasswordLabel.Location = new System.Drawing.Point(212, 34);
            this.oldPasswordLabel.Name = "oldPasswordLabel";
            this.oldPasswordLabel.Size = new System.Drawing.Size(63, 19);
            this.oldPasswordLabel.TabIndex = 0;
            this.oldPasswordLabel.Text = "Eski Şifre:";
            // 
            // userSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 379);
            this.Controls.Add(this.passwordGroupBox);
            this.Controls.Add(this.usernameGroupBox);
            this.Controls.Add(this.connectSituation);
            this.Name = "userSettings";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "Kullanıcı Ayarları";
            this.Load += new System.EventHandler(this.userSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.usernameGroupBox.ResumeLayout(false);
            this.usernameGroupBox.PerformLayout();
            this.passwordGroupBox.ResumeLayout(false);
            this.passwordGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroTile connectSituation;
        private System.Windows.Forms.GroupBox usernameGroupBox;
        private MetroFramework.Controls.MetroTextBox oldNameText;
        private MetroFramework.Controls.MetroLabel newNameLabel;
        private MetroFramework.Controls.MetroLabel oldNameLabel;
        private MetroFramework.Controls.MetroTextBox newNameText;
        private MetroFramework.Controls.MetroTile saveNewNameButton;
        private System.Windows.Forms.GroupBox passwordGroupBox;
        private MetroFramework.Controls.MetroLabel oldPasswordLabel;
        private MetroFramework.Controls.MetroTextBox againNewPasswordText;
        private MetroFramework.Controls.MetroLabel againNewPasswordLabel;
        private MetroFramework.Controls.MetroTextBox newPasswordText;
        private MetroFramework.Controls.MetroLabel newPasswordLabel;
        private MetroFramework.Controls.MetroTextBox oldPasswordText;
        private MetroFramework.Controls.MetroTile saveNewPasswordButton;
    }
}