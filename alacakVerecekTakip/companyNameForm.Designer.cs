namespace alacakVerecekTakip
{
    partial class companyNameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(companyNameForm));
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.companyNameInputText = new MetroFramework.Controls.MetroTextBox();
            this.saveButton = new MetroFramework.Controls.MetroTile();
            this.connectSituation = new MetroFramework.Controls.MetroTile();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // companyNameInputText
            // 
            // 
            // 
            // 
            this.companyNameInputText.CustomButton.Image = null;
            this.companyNameInputText.CustomButton.Location = new System.Drawing.Point(391, 1);
            this.companyNameInputText.CustomButton.Name = "";
            this.companyNameInputText.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.companyNameInputText.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.companyNameInputText.CustomButton.TabIndex = 1;
            this.companyNameInputText.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.companyNameInputText.CustomButton.UseSelectable = true;
            this.companyNameInputText.CustomButton.Visible = false;
            this.companyNameInputText.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.companyNameInputText.Lines = new string[0];
            this.companyNameInputText.Location = new System.Drawing.Point(51, 121);
            this.companyNameInputText.MaxLength = 55;
            this.companyNameInputText.Name = "companyNameInputText";
            this.companyNameInputText.PasswordChar = '\0';
            this.companyNameInputText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.companyNameInputText.SelectedText = "";
            this.companyNameInputText.SelectionLength = 0;
            this.companyNameInputText.SelectionStart = 0;
            this.companyNameInputText.ShortcutsEnabled = true;
            this.companyNameInputText.ShowClearButton = true;
            this.companyNameInputText.Size = new System.Drawing.Size(425, 35);
            this.companyNameInputText.TabIndex = 0;
            this.companyNameInputText.UseSelectable = true;
            this.companyNameInputText.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.companyNameInputText.WaterMarkFont = new System.Drawing.Font("Century Gothic", 75F, System.Drawing.FontStyle.Italic);
            this.companyNameInputText.TextChanged += new System.EventHandler(this.companyNameInputText_TextChanged);
            // 
            // saveButton
            // 
            this.saveButton.ActiveControl = null;
            this.saveButton.BackColor = System.Drawing.Color.Silver;
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(380, 162);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(96, 40);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "KAYDET";
            this.saveButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.saveButton.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.saveButton.UseCustomBackColor = true;
            this.saveButton.UseSelectable = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // connectSituation
            // 
            this.connectSituation.ActiveControl = null;
            this.connectSituation.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.connectSituation.ForeColor = System.Drawing.Color.Lime;
            this.connectSituation.Location = new System.Drawing.Point(12, 271);
            this.connectSituation.Name = "connectSituation";
            this.connectSituation.Size = new System.Drawing.Size(18, 18);
            this.connectSituation.TabIndex = 9;
            this.connectSituation.UseCustomBackColor = true;
            this.connectSituation.UseSelectable = true;
            // 
            // companyNameForm
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 296);
            this.Controls.Add(this.connectSituation);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.companyNameInputText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "companyNameForm";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "Firma İsmi Değiştir";
            this.Load += new System.EventHandler(this.companyNameForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroTextBox companyNameInputText;
        private MetroFramework.Controls.MetroTile saveButton;
        private MetroFramework.Controls.MetroTile connectSituation;
    }
}