namespace alacakVerecekTakip
{
    partial class loginScreenForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loginScreenForm));
            this.usernameLabel = new MetroFramework.Controls.MetroLabel();
            this.passwordLabel = new MetroFramework.Controls.MetroLabel();
            this.usernameInputText = new MetroFramework.Controls.MetroTextBox();
            this.passwordInputText = new MetroFramework.Controls.MetroTextBox();
            this.loginButton = new MetroFramework.Controls.MetroTile();
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.copyrightLabel = new MetroFramework.Controls.MetroLabel();
            this.programNameLabel = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.usernameLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.usernameLabel.Location = new System.Drawing.Point(38, 91);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(107, 25);
            this.usernameLabel.TabIndex = 98;
            this.usernameLabel.Text = "Kullanıcı Adı";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.passwordLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.passwordLabel.Location = new System.Drawing.Point(98, 132);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(47, 25);
            this.passwordLabel.TabIndex = 99;
            this.passwordLabel.Text = "Şifre";
            // 
            // usernameInputText
            // 
            // 
            // 
            // 
            this.usernameInputText.CustomButton.Image = null;
            this.usernameInputText.CustomButton.Location = new System.Drawing.Point(156, 1);
            this.usernameInputText.CustomButton.Name = "";
            this.usernameInputText.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.usernameInputText.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.usernameInputText.CustomButton.TabIndex = 1;
            this.usernameInputText.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.usernameInputText.CustomButton.UseSelectable = true;
            this.usernameInputText.CustomButton.Visible = false;
            this.usernameInputText.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.usernameInputText.Lines = new string[0];
            this.usernameInputText.Location = new System.Drawing.Point(151, 87);
            this.usernameInputText.MaxLength = 32767;
            this.usernameInputText.Name = "usernameInputText";
            this.usernameInputText.PasswordChar = '\0';
            this.usernameInputText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.usernameInputText.SelectedText = "";
            this.usernameInputText.SelectionLength = 0;
            this.usernameInputText.SelectionStart = 0;
            this.usernameInputText.ShortcutsEnabled = true;
            this.usernameInputText.Size = new System.Drawing.Size(190, 35);
            this.usernameInputText.TabIndex = 0;
            this.usernameInputText.UseSelectable = true;
            this.usernameInputText.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.usernameInputText.WaterMarkFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.usernameInputText.TextChanged += new System.EventHandler(this.usernameInputText_TextChanged);
            // 
            // passwordInputText
            // 
            // 
            // 
            // 
            this.passwordInputText.CustomButton.Image = null;
            this.passwordInputText.CustomButton.Location = new System.Drawing.Point(156, 1);
            this.passwordInputText.CustomButton.Name = "";
            this.passwordInputText.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.passwordInputText.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.passwordInputText.CustomButton.TabIndex = 1;
            this.passwordInputText.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.passwordInputText.CustomButton.UseSelectable = true;
            this.passwordInputText.CustomButton.Visible = false;
            this.passwordInputText.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.passwordInputText.Lines = new string[0];
            this.passwordInputText.Location = new System.Drawing.Point(151, 128);
            this.passwordInputText.MaxLength = 32767;
            this.passwordInputText.Name = "passwordInputText";
            this.passwordInputText.PasswordChar = '*';
            this.passwordInputText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.passwordInputText.SelectedText = "";
            this.passwordInputText.SelectionLength = 0;
            this.passwordInputText.SelectionStart = 0;
            this.passwordInputText.ShortcutsEnabled = true;
            this.passwordInputText.Size = new System.Drawing.Size(190, 35);
            this.passwordInputText.TabIndex = 1;
            this.passwordInputText.UseSelectable = true;
            this.passwordInputText.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.passwordInputText.WaterMarkFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic);
            this.passwordInputText.TextChanged += new System.EventHandler(this.passwordInputText_TextChanged);
            // 
            // loginButton
            // 
            this.loginButton.ActiveControl = null;
            this.loginButton.BackColor = System.Drawing.Color.Silver;
            this.loginButton.Enabled = false;
            this.loginButton.Location = new System.Drawing.Point(236, 169);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(105, 47);
            this.loginButton.TabIndex = 2;
            this.loginButton.Text = "Giriş Yap";
            this.loginButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.loginButton.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.loginButton.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.loginButton.UseCustomBackColor = true;
            this.loginButton.UseSelectable = true;
            this.loginButton.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // pic1
            // 
            this.pic1.Image = ((System.Drawing.Image)(resources.GetObject("pic1.Image")));
            this.pic1.Location = new System.Drawing.Point(347, 75);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(170, 137);
            this.pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic1.TabIndex = 5;
            this.pic1.TabStop = false;
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // copyrightLabel
            // 
            this.copyrightLabel.AutoSize = true;
            this.copyrightLabel.BackColor = System.Drawing.Color.Silver;
            this.copyrightLabel.FontSize = MetroFramework.MetroLabelSize.Small;
            this.copyrightLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.copyrightLabel.Location = new System.Drawing.Point(328, 246);
            this.copyrightLabel.Name = "copyrightLabel";
            this.copyrightLabel.Size = new System.Drawing.Size(209, 15);
            this.copyrightLabel.TabIndex = 100;
            this.copyrightLabel.Text = "DNT Yazılım © 2019 - Tüm Hakları Saklıdır.";
            this.copyrightLabel.UseCustomForeColor = true;
            // 
            // programNameLabel
            // 
            this.programNameLabel.AutoSize = true;
            this.programNameLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.programNameLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.programNameLabel.ForeColor = System.Drawing.Color.Black;
            this.programNameLabel.Location = new System.Drawing.Point(176, 26);
            this.programNameLabel.Name = "programNameLabel";
            this.programNameLabel.Size = new System.Drawing.Size(329, 25);
            this.programNameLabel.TabIndex = 101;
            this.programNameLabel.Text = "ALACAK VERECEK TAKİP OTOMASYONU";
            // 
            // loginScreen
            // 
            this.AcceptButton = this.loginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 266);
            this.Controls.Add(this.programNameLabel);
            this.Controls.Add(this.copyrightLabel);
            this.Controls.Add(this.pic1);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.passwordInputText);
            this.Controls.Add(this.usernameInputText);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "loginScreen";
            this.Resizable = false;
            this.Text = "Giriş Yap";
            this.Load += new System.EventHandler(this.loginScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel usernameLabel;
        private MetroFramework.Controls.MetroLabel passwordLabel;
        private MetroFramework.Controls.MetroTextBox usernameInputText;
        private MetroFramework.Controls.MetroTextBox passwordInputText;
        private MetroFramework.Controls.MetroTile loginButton;
        private System.Windows.Forms.PictureBox pic1;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroLabel copyrightLabel;
        private MetroFramework.Controls.MetroLabel programNameLabel;
    }
}