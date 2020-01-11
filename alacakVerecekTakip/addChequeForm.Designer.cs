namespace alacakVerecekTakip
{
    partial class addChequeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addChequeForm));
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.bankOfChequeLabel = new MetroFramework.Controls.MetroLabel();
            this.bankChequeCombo = new MetroFramework.Controls.MetroComboBox();
            this.chequeBankCodeText = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.chequeValText = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.OKButton = new MetroFramework.Controls.MetroTile();
            this.moneyNumberToWordRichText = new System.Windows.Forms.RichTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.drawingDateTime = new MetroFramework.Controls.MetroDateTime();
            this.recipientNameText = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.drawingNameText = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.saveButton = new MetroFramework.Controls.MetroButton();
            this.connectSituation = new MetroFramework.Controls.MetroTile();
            this.helpPictureBox = new System.Windows.Forms.PictureBox();
            this.moneyTypesComboLabel = new MetroFramework.Controls.MetroLabel();
            this.moneyTypesCombo = new MetroFramework.Controls.MetroComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // bankOfChequeLabel
            // 
            this.bankOfChequeLabel.AutoSize = true;
            this.bankOfChequeLabel.Location = new System.Drawing.Point(121, 95);
            this.bankOfChequeLabel.Name = "bankOfChequeLabel";
            this.bankOfChequeLabel.Size = new System.Drawing.Size(81, 19);
            this.bankOfChequeLabel.TabIndex = 2;
            this.bankOfChequeLabel.Text = "Çek Bankası:";
            // 
            // bankChequeCombo
            // 
            this.bankChequeCombo.FormattingEnabled = true;
            this.bankChequeCombo.ItemHeight = 23;
            this.bankChequeCombo.Location = new System.Drawing.Point(201, 90);
            this.bankChequeCombo.Name = "bankChequeCombo";
            this.bankChequeCombo.Size = new System.Drawing.Size(200, 29);
            this.bankChequeCombo.TabIndex = 0;
            this.bankChequeCombo.UseSelectable = true;
            // 
            // chequeBankCodeText
            // 
            // 
            // 
            // 
            this.chequeBankCodeText.CustomButton.Image = null;
            this.chequeBankCodeText.CustomButton.Location = new System.Drawing.Point(174, 2);
            this.chequeBankCodeText.CustomButton.Name = "";
            this.chequeBankCodeText.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.chequeBankCodeText.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.chequeBankCodeText.CustomButton.TabIndex = 1;
            this.chequeBankCodeText.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.chequeBankCodeText.CustomButton.UseSelectable = true;
            this.chequeBankCodeText.CustomButton.Visible = false;
            this.chequeBankCodeText.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.chequeBankCodeText.Lines = new string[0];
            this.chequeBankCodeText.Location = new System.Drawing.Point(201, 160);
            this.chequeBankCodeText.MaxLength = 32767;
            this.chequeBankCodeText.Name = "chequeBankCodeText";
            this.chequeBankCodeText.PasswordChar = '\0';
            this.chequeBankCodeText.PromptText = "Örn:6001";
            this.chequeBankCodeText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.chequeBankCodeText.SelectedText = "";
            this.chequeBankCodeText.SelectionLength = 0;
            this.chequeBankCodeText.SelectionStart = 0;
            this.chequeBankCodeText.ShortcutsEnabled = true;
            this.chequeBankCodeText.Size = new System.Drawing.Size(200, 28);
            this.chequeBankCodeText.TabIndex = 2;
            this.chequeBankCodeText.UseSelectable = true;
            this.chequeBankCodeText.WaterMark = "Örn:6001";
            this.chequeBankCodeText.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.chequeBankCodeText.WaterMarkFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chequeBankCodeText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.bankOfChequeCodeText_KeyPress);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(68, 164);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(132, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Çek Bankasının Kodu:";
            // 
            // chequeValText
            // 
            // 
            // 
            // 
            this.chequeValText.CustomButton.Image = null;
            this.chequeValText.CustomButton.Location = new System.Drawing.Point(174, 2);
            this.chequeValText.CustomButton.Name = "";
            this.chequeValText.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.chequeValText.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.chequeValText.CustomButton.TabIndex = 1;
            this.chequeValText.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.chequeValText.CustomButton.UseSelectable = true;
            this.chequeValText.CustomButton.Visible = false;
            this.chequeValText.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.chequeValText.Lines = new string[0];
            this.chequeValText.Location = new System.Drawing.Point(201, 194);
            this.chequeValText.MaxLength = 32767;
            this.chequeValText.Name = "chequeValText";
            this.chequeValText.PasswordChar = '\0';
            this.chequeValText.PromptText = "Örn:123,45";
            this.chequeValText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.chequeValText.SelectedText = "";
            this.chequeValText.SelectionLength = 0;
            this.chequeValText.SelectionStart = 0;
            this.chequeValText.ShortcutsEnabled = true;
            this.chequeValText.Size = new System.Drawing.Size(200, 28);
            this.chequeValText.TabIndex = 3;
            this.chequeValText.UseSelectable = true;
            this.chequeValText.WaterMark = "Örn:123,45";
            this.chequeValText.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.chequeValText.WaterMarkFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chequeValText.TextChanged += new System.EventHandler(this.chequeValText_TextChanged);
            this.chequeValText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chequeValText_KeyPress);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(124, 198);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(77, 19);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "Çek Değeri:";
            // 
            // OKButton
            // 
            this.OKButton.ActiveControl = null;
            this.OKButton.BackColor = System.Drawing.Color.Silver;
            this.OKButton.Enabled = false;
            this.OKButton.Location = new System.Drawing.Point(404, 194);
            this.OKButton.Margin = new System.Windows.Forms.Padding(0);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(33, 28);
            this.OKButton.TabIndex = 3;
            this.OKButton.TileImage = global::alacakVerecekTakip.Properties.Resources.OK4;
            this.OKButton.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.OKButton.UseCustomBackColor = true;
            this.OKButton.UseSelectable = true;
            this.OKButton.UseTileImage = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // moneyNumberToWordRichText
            // 
            this.moneyNumberToWordRichText.BackColor = System.Drawing.Color.White;
            this.moneyNumberToWordRichText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.moneyNumberToWordRichText.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.moneyNumberToWordRichText.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.moneyNumberToWordRichText.Location = new System.Drawing.Point(201, 228);
            this.moneyNumberToWordRichText.Name = "moneyNumberToWordRichText";
            this.moneyNumberToWordRichText.ReadOnly = true;
            this.moneyNumberToWordRichText.Size = new System.Drawing.Size(200, 127);
            this.moneyNumberToWordRichText.TabIndex = 9999;
            this.moneyNumberToWordRichText.Text = "";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(118, 366);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(83, 19);
            this.metroLabel3.TabIndex = 2;
            this.metroLabel3.Text = "Keşide Tarihi:";
            // 
            // drawingDateTime
            // 
            this.drawingDateTime.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.drawingDateTime.Location = new System.Drawing.Point(201, 361);
            this.drawingDateTime.MinimumSize = new System.Drawing.Size(0, 29);
            this.drawingDateTime.Name = "drawingDateTime";
            this.drawingDateTime.Size = new System.Drawing.Size(200, 29);
            this.drawingDateTime.TabIndex = 4;
            this.drawingDateTime.ValueChanged += new System.EventHandler(this.drawingDateTime_ValueChanged);
            // 
            // recipientNameText
            // 
            // 
            // 
            // 
            this.recipientNameText.CustomButton.Image = null;
            this.recipientNameText.CustomButton.Location = new System.Drawing.Point(174, 2);
            this.recipientNameText.CustomButton.Name = "";
            this.recipientNameText.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.recipientNameText.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.recipientNameText.CustomButton.TabIndex = 1;
            this.recipientNameText.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.recipientNameText.CustomButton.UseSelectable = true;
            this.recipientNameText.CustomButton.Visible = false;
            this.recipientNameText.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.recipientNameText.Lines = new string[0];
            this.recipientNameText.Location = new System.Drawing.Point(201, 430);
            this.recipientNameText.MaxLength = 32767;
            this.recipientNameText.Name = "recipientNameText";
            this.recipientNameText.PasswordChar = '\0';
            this.recipientNameText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.recipientNameText.SelectedText = "";
            this.recipientNameText.SelectionLength = 0;
            this.recipientNameText.SelectionStart = 0;
            this.recipientNameText.ShortcutsEnabled = true;
            this.recipientNameText.Size = new System.Drawing.Size(200, 28);
            this.recipientNameText.TabIndex = 6;
            this.recipientNameText.UseSelectable = true;
            this.recipientNameText.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.recipientNameText.WaterMarkFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.recipientNameText.TextChanged += new System.EventHandler(this.recipientNameText_TextChanged);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(26, 393);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(176, 19);
            this.metroLabel5.TabIndex = 0;
            this.metroLabel5.Text = "Çeki Verenin İsmi ve Soyismi:";
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel6.Location = new System.Drawing.Point(113, 409);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(88, 15);
            this.metroLabel6.TabIndex = 0;
            this.metroLabel6.Text = "(veya Şirket İsmi)";
            // 
            // drawingNameText
            // 
            // 
            // 
            // 
            this.drawingNameText.CustomButton.Image = null;
            this.drawingNameText.CustomButton.Location = new System.Drawing.Point(174, 2);
            this.drawingNameText.CustomButton.Name = "";
            this.drawingNameText.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.drawingNameText.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.drawingNameText.CustomButton.TabIndex = 1;
            this.drawingNameText.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.drawingNameText.CustomButton.UseSelectable = true;
            this.drawingNameText.CustomButton.Visible = false;
            this.drawingNameText.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.drawingNameText.Lines = new string[0];
            this.drawingNameText.Location = new System.Drawing.Point(201, 396);
            this.drawingNameText.MaxLength = 32767;
            this.drawingNameText.Name = "drawingNameText";
            this.drawingNameText.PasswordChar = '\0';
            this.drawingNameText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.drawingNameText.SelectedText = "";
            this.drawingNameText.SelectionLength = 0;
            this.drawingNameText.SelectionStart = 0;
            this.drawingNameText.ShortcutsEnabled = true;
            this.drawingNameText.Size = new System.Drawing.Size(200, 28);
            this.drawingNameText.TabIndex = 5;
            this.drawingNameText.UseSelectable = true;
            this.drawingNameText.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.drawingNameText.WaterMarkFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.drawingNameText.TextChanged += new System.EventHandler(this.drawingNameText_TextChanged);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(33, 427);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(169, 19);
            this.metroLabel4.TabIndex = 0;
            this.metroLabel4.Text = "Çeki Alanın İsmi ve Soyisim:";
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel7.Location = new System.Drawing.Point(113, 443);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(88, 15);
            this.metroLabel7.TabIndex = 0;
            this.metroLabel7.Text = "(veya Şirket İsmi)";
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.Silver;
            this.saveButton.Enabled = false;
            this.saveButton.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.saveButton.ForeColor = System.Drawing.Color.White;
            this.saveButton.Location = new System.Drawing.Point(201, 466);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(200, 38);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "KAYDET";
            this.saveButton.UseCustomBackColor = true;
            this.saveButton.UseCustomForeColor = true;
            this.saveButton.UseSelectable = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // connectSituation
            // 
            this.connectSituation.ActiveControl = null;
            this.connectSituation.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.connectSituation.ForeColor = System.Drawing.Color.Lime;
            this.connectSituation.Location = new System.Drawing.Point(10, 532);
            this.connectSituation.Name = "connectSituation";
            this.connectSituation.Size = new System.Drawing.Size(18, 18);
            this.connectSituation.TabIndex = 14;
            this.connectSituation.UseCustomBackColor = true;
            this.connectSituation.UseSelectable = true;
            // 
            // helpPictureBox
            // 
            this.helpPictureBox.Image = global::alacakVerecekTakip.Properties.Resources.help;
            this.helpPictureBox.Location = new System.Drawing.Point(128, 25);
            this.helpPictureBox.Name = "helpPictureBox";
            this.helpPictureBox.Size = new System.Drawing.Size(25, 25);
            this.helpPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.helpPictureBox.TabIndex = 16;
            this.helpPictureBox.TabStop = false;
            // 
            // moneyTypesComboLabel
            // 
            this.moneyTypesComboLabel.AutoSize = true;
            this.moneyTypesComboLabel.Location = new System.Drawing.Point(136, 130);
            this.moneyTypesComboLabel.Name = "moneyTypesComboLabel";
            this.moneyTypesComboLabel.Size = new System.Drawing.Size(66, 19);
            this.moneyTypesComboLabel.TabIndex = 2;
            this.moneyTypesComboLabel.Text = "Para Türü:";
            // 
            // moneyTypesCombo
            // 
            this.moneyTypesCombo.FormattingEnabled = true;
            this.moneyTypesCombo.ItemHeight = 23;
            this.moneyTypesCombo.Location = new System.Drawing.Point(201, 125);
            this.moneyTypesCombo.Name = "moneyTypesCombo";
            this.moneyTypesCombo.Size = new System.Drawing.Size(200, 29);
            this.moneyTypesCombo.TabIndex = 1;
            this.moneyTypesCombo.UseSelectable = true;
            // 
            // addChequeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 555);
            this.Controls.Add(this.helpPictureBox);
            this.Controls.Add(this.connectSituation);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.drawingDateTime);
            this.Controls.Add(this.moneyNumberToWordRichText);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.moneyTypesCombo);
            this.Controls.Add(this.bankChequeCombo);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.moneyTypesComboLabel);
            this.Controls.Add(this.chequeValText);
            this.Controls.Add(this.bankOfChequeLabel);
            this.Controls.Add(this.recipientNameText);
            this.Controls.Add(this.chequeBankCodeText);
            this.Controls.Add(this.drawingNameText);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel5);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "addChequeForm";
            this.Text = "Çek ";
            this.Load += new System.EventHandler(this.addChequeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroComboBox bankChequeCombo;
        private MetroFramework.Controls.MetroLabel bankOfChequeLabel;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox chequeBankCodeText;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox chequeValText;
        private MetroFramework.Controls.MetroTile OKButton;
        private MetroFramework.Controls.MetroDateTime drawingDateTime;
        private System.Windows.Forms.RichTextBox moneyNumberToWordRichText;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroButton saveButton;
        private MetroFramework.Controls.MetroTextBox recipientNameText;
        private MetroFramework.Controls.MetroTextBox drawingNameText;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroTile connectSituation;
        private System.Windows.Forms.PictureBox helpPictureBox;
        private MetroFramework.Controls.MetroComboBox moneyTypesCombo;
        private MetroFramework.Controls.MetroLabel moneyTypesComboLabel;
    }
}