namespace alacakVerecekTakip
{
    partial class debtTransactionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(debtTransactionsForm));
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.connectSituation = new MetroFramework.Controls.MetroTile();
            this.helpPictureBox = new System.Windows.Forms.PictureBox();
            this.customersComboLabel = new MetroFramework.Controls.MetroLabel();
            this.customersCombo = new MetroFramework.Controls.MetroComboBox();
            this.moneyValText = new MetroFramework.Controls.MetroTextBox();
            this.moneyValTextLabel = new MetroFramework.Controls.MetroLabel();
            this.bankTypesCombo = new MetroFramework.Controls.MetroComboBox();
            this.bankTypeComboLabel = new MetroFramework.Controls.MetroLabel();
            this.barrowRadio = new MetroFramework.Controls.MetroRadioButton();
            this.loanRadio = new MetroFramework.Controls.MetroRadioButton();
            this.moneyTypesCombo = new MetroFramework.Controls.MetroComboBox();
            this.moneyTypeComboLabel = new MetroFramework.Controls.MetroLabel();
            this.OKButton = new MetroFramework.Controls.MetroTile();
            this.moneyNumberToWordRichText = new System.Windows.Forms.RichTextBox();
            this.dateCombo = new MetroFramework.Controls.MetroDateTime();
            this.dateComboLabel = new MetroFramework.Controls.MetroLabel();
            this.saveButton = new MetroFramework.Controls.MetroButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.transactionTypeLabel = new MetroFramework.Controls.MetroLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.installmentCountLabel = new MetroFramework.Controls.MetroLabel();
            this.cashPaymentRadio = new MetroFramework.Controls.MetroRadioButton();
            this.installmentPaymentRadio = new MetroFramework.Controls.MetroRadioButton();
            this.installmentCountCombo = new MetroFramework.Controls.MetroComboBox();
            this.monthlyPaymentLabel = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpPictureBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.connectSituation.Location = new System.Drawing.Point(23, 592);
            this.connectSituation.Name = "connectSituation";
            this.connectSituation.Size = new System.Drawing.Size(18, 18);
            this.connectSituation.TabIndex = 99999999;
            this.connectSituation.UseCustomBackColor = true;
            this.connectSituation.UseSelectable = true;
            // 
            // helpPictureBox
            // 
            this.helpPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.helpPictureBox.Image = global::alacakVerecekTakip.Properties.Resources.help;
            this.helpPictureBox.Location = new System.Drawing.Point(170, 27);
            this.helpPictureBox.Name = "helpPictureBox";
            this.helpPictureBox.Size = new System.Drawing.Size(25, 25);
            this.helpPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.helpPictureBox.TabIndex = 13;
            this.helpPictureBox.TabStop = false;
            // 
            // customersComboLabel
            // 
            this.customersComboLabel.AutoSize = true;
            this.customersComboLabel.Location = new System.Drawing.Point(85, 144);
            this.customersComboLabel.Name = "customersComboLabel";
            this.customersComboLabel.Size = new System.Drawing.Size(71, 19);
            this.customersComboLabel.TabIndex = 14;
            this.customersComboLabel.Text = "Müşteriler:";
            // 
            // customersCombo
            // 
            this.customersCombo.FormattingEnabled = true;
            this.customersCombo.ItemHeight = 23;
            this.customersCombo.Location = new System.Drawing.Point(156, 140);
            this.customersCombo.Name = "customersCombo";
            this.customersCombo.Size = new System.Drawing.Size(200, 29);
            this.customersCombo.TabIndex = 3;
            this.customersCombo.UseSelectable = true;
            // 
            // moneyValText
            // 
            // 
            // 
            // 
            this.moneyValText.CustomButton.Image = null;
            this.moneyValText.CustomButton.Location = new System.Drawing.Point(172, 1);
            this.moneyValText.CustomButton.Name = "";
            this.moneyValText.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.moneyValText.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.moneyValText.CustomButton.TabIndex = 1;
            this.moneyValText.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.moneyValText.CustomButton.UseSelectable = true;
            this.moneyValText.CustomButton.Visible = false;
            this.moneyValText.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.moneyValText.Lines = new string[0];
            this.moneyValText.Location = new System.Drawing.Point(156, 245);
            this.moneyValText.MaxLength = 32767;
            this.moneyValText.Name = "moneyValText";
            this.moneyValText.PasswordChar = '\0';
            this.moneyValText.PromptText = "Örn:123,45";
            this.moneyValText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.moneyValText.SelectedText = "";
            this.moneyValText.SelectionLength = 0;
            this.moneyValText.SelectionStart = 0;
            this.moneyValText.ShortcutsEnabled = true;
            this.moneyValText.Size = new System.Drawing.Size(200, 29);
            this.moneyValText.TabIndex = 6;
            this.moneyValText.UseSelectable = true;
            this.moneyValText.WaterMark = "Örn:123,45";
            this.moneyValText.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.moneyValText.WaterMarkFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.moneyValText.TextChanged += new System.EventHandler(this.moneyValText_TextChanged);
            this.moneyValText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.moneyNumberToWordRichText_KeyPress);
            // 
            // moneyValTextLabel
            // 
            this.moneyValTextLabel.AutoSize = true;
            this.moneyValTextLabel.Location = new System.Drawing.Point(74, 249);
            this.moneyValTextLabel.Name = "moneyValTextLabel";
            this.moneyValTextLabel.Size = new System.Drawing.Size(82, 19);
            this.moneyValTextLabel.TabIndex = 14;
            this.moneyValTextLabel.Text = "Para Miktarı:";
            // 
            // bankTypesCombo
            // 
            this.bankTypesCombo.FormattingEnabled = true;
            this.bankTypesCombo.ItemHeight = 23;
            this.bankTypesCombo.Location = new System.Drawing.Point(156, 175);
            this.bankTypesCombo.Name = "bankTypesCombo";
            this.bankTypesCombo.Size = new System.Drawing.Size(200, 29);
            this.bankTypesCombo.TabIndex = 4;
            this.bankTypesCombo.UseSelectable = true;
            // 
            // bankTypeComboLabel
            // 
            this.bankTypeComboLabel.AutoSize = true;
            this.bankTypeComboLabel.Location = new System.Drawing.Point(81, 179);
            this.bankTypeComboLabel.Name = "bankTypeComboLabel";
            this.bankTypeComboLabel.Size = new System.Drawing.Size(75, 19);
            this.bankTypeComboLabel.TabIndex = 14;
            this.bankTypeComboLabel.Text = "Banka Türü:";
            // 
            // barrowRadio
            // 
            this.barrowRadio.AutoSize = true;
            this.barrowRadio.Location = new System.Drawing.Point(125, 17);
            this.barrowRadio.Name = "barrowRadio";
            this.barrowRadio.Size = new System.Drawing.Size(61, 15);
            this.barrowRadio.TabIndex = 2;
            this.barrowRadio.Tag = "transactionTypeRadios";
            this.barrowRadio.Text = "Borç Al";
            this.barrowRadio.UseSelectable = true;
            // 
            // loanRadio
            // 
            this.loanRadio.AutoSize = true;
            this.loanRadio.Checked = true;
            this.loanRadio.Location = new System.Drawing.Point(14, 17);
            this.loanRadio.Name = "loanRadio";
            this.loanRadio.Size = new System.Drawing.Size(66, 15);
            this.loanRadio.TabIndex = 1;
            this.loanRadio.TabStop = true;
            this.loanRadio.Tag = "transactionTypeRadios";
            this.loanRadio.Text = "Borç Ver";
            this.loanRadio.UseSelectable = true;
            // 
            // moneyTypesCombo
            // 
            this.moneyTypesCombo.FormattingEnabled = true;
            this.moneyTypesCombo.ItemHeight = 23;
            this.moneyTypesCombo.Location = new System.Drawing.Point(156, 210);
            this.moneyTypesCombo.Name = "moneyTypesCombo";
            this.moneyTypesCombo.Size = new System.Drawing.Size(200, 29);
            this.moneyTypesCombo.TabIndex = 5;
            this.moneyTypesCombo.UseSelectable = true;
            // 
            // moneyTypeComboLabel
            // 
            this.moneyTypeComboLabel.AutoSize = true;
            this.moneyTypeComboLabel.Location = new System.Drawing.Point(90, 214);
            this.moneyTypeComboLabel.Name = "moneyTypeComboLabel";
            this.moneyTypeComboLabel.Size = new System.Drawing.Size(66, 19);
            this.moneyTypeComboLabel.TabIndex = 14;
            this.moneyTypeComboLabel.Text = "Para Türü:";
            // 
            // OKButton
            // 
            this.OKButton.ActiveControl = null;
            this.OKButton.BackColor = System.Drawing.Color.Silver;
            this.OKButton.Enabled = false;
            this.OKButton.Location = new System.Drawing.Point(359, 245);
            this.OKButton.Margin = new System.Windows.Forms.Padding(0);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(33, 28);
            this.OKButton.TabIndex = 7;
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
            this.moneyNumberToWordRichText.Location = new System.Drawing.Point(156, 280);
            this.moneyNumberToWordRichText.Name = "moneyNumberToWordRichText";
            this.moneyNumberToWordRichText.ReadOnly = true;
            this.moneyNumberToWordRichText.Size = new System.Drawing.Size(200, 127);
            this.moneyNumberToWordRichText.TabIndex = 10000;
            this.moneyNumberToWordRichText.Text = "";
            this.moneyNumberToWordRichText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.moneyNumberToWordRichText_KeyPress);
            // 
            // dateCombo
            // 
            this.dateCombo.Location = new System.Drawing.Point(156, 528);
            this.dateCombo.MinimumSize = new System.Drawing.Size(0, 29);
            this.dateCombo.Name = "dateCombo";
            this.dateCombo.Size = new System.Drawing.Size(200, 29);
            this.dateCombo.TabIndex = 8;
            // 
            // dateComboLabel
            // 
            this.dateComboLabel.AutoSize = true;
            this.dateComboLabel.Location = new System.Drawing.Point(27, 534);
            this.dateComboLabel.Name = "dateComboLabel";
            this.dateComboLabel.Size = new System.Drawing.Size(129, 19);
            this.dateComboLabel.TabIndex = 14;
            this.dateComboLabel.Text = "Borç Ödenme Tarihi:";
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.Silver;
            this.saveButton.Enabled = false;
            this.saveButton.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.saveButton.ForeColor = System.Drawing.Color.White;
            this.saveButton.Location = new System.Drawing.Point(156, 563);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(200, 38);
            this.saveButton.TabIndex = 9;
            this.saveButton.Text = "KAYDET";
            this.saveButton.UseCustomBackColor = true;
            this.saveButton.UseCustomForeColor = true;
            this.saveButton.UseSelectable = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.loanRadio);
            this.groupBox2.Controls.Add(this.barrowRadio);
            this.groupBox2.Location = new System.Drawing.Point(156, 90);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 44);
            this.groupBox2.TabIndex = 100000001;
            this.groupBox2.TabStop = false;
            // 
            // transactionTypeLabel
            // 
            this.transactionTypeLabel.AutoSize = true;
            this.transactionTypeLabel.Location = new System.Drawing.Point(89, 106);
            this.transactionTypeLabel.Name = "transactionTypeLabel";
            this.transactionTypeLabel.Size = new System.Drawing.Size(67, 19);
            this.transactionTypeLabel.TabIndex = 14;
            this.transactionTypeLabel.Text = "İşlem Tipi:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.installmentCountLabel);
            this.groupBox1.Controls.Add(this.cashPaymentRadio);
            this.groupBox1.Controls.Add(this.installmentPaymentRadio);
            this.groupBox1.Controls.Add(this.installmentCountCombo);
            this.groupBox1.Controls.Add(this.monthlyPaymentLabel);
            this.groupBox1.Location = new System.Drawing.Point(156, 413);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 109);
            this.groupBox1.TabIndex = 100000002;
            this.groupBox1.TabStop = false;
            // 
            // installmentCountLabel
            // 
            this.installmentCountLabel.AutoSize = true;
            this.installmentCountLabel.Enabled = false;
            this.installmentCountLabel.Location = new System.Drawing.Point(21, 52);
            this.installmentCountLabel.Name = "installmentCountLabel";
            this.installmentCountLabel.Size = new System.Drawing.Size(77, 19);
            this.installmentCountLabel.TabIndex = 14;
            this.installmentCountLabel.Text = "Taksit Tutarı:";
            // 
            // cashPaymentRadio
            // 
            this.cashPaymentRadio.AutoSize = true;
            this.cashPaymentRadio.Checked = true;
            this.cashPaymentRadio.Location = new System.Drawing.Point(14, 18);
            this.cashPaymentRadio.Name = "cashPaymentRadio";
            this.cashPaymentRadio.Size = new System.Drawing.Size(51, 15);
            this.cashPaymentRadio.TabIndex = 1;
            this.cashPaymentRadio.TabStop = true;
            this.cashPaymentRadio.Tag = "paymentRadios";
            this.cashPaymentRadio.Text = "Peşin";
            this.cashPaymentRadio.UseSelectable = true;
            // 
            // installmentPaymentRadio
            // 
            this.installmentPaymentRadio.AutoSize = true;
            this.installmentPaymentRadio.Location = new System.Drawing.Point(125, 18);
            this.installmentPaymentRadio.Name = "installmentPaymentRadio";
            this.installmentPaymentRadio.Size = new System.Drawing.Size(52, 15);
            this.installmentPaymentRadio.TabIndex = 2;
            this.installmentPaymentRadio.Tag = "paymentRadios";
            this.installmentPaymentRadio.Text = "Taksit";
            this.installmentPaymentRadio.UseSelectable = true;
            this.installmentPaymentRadio.CheckedChanged += new System.EventHandler(this.installmentPaymentRadio_CheckedChanged);
            // 
            // installmentCountCombo
            // 
            this.installmentCountCombo.Enabled = false;
            this.installmentCountCombo.FormattingEnabled = true;
            this.installmentCountCombo.ItemHeight = 23;
            this.installmentCountCombo.Location = new System.Drawing.Point(98, 48);
            this.installmentCountCombo.Name = "installmentCountCombo";
            this.installmentCountCombo.Size = new System.Drawing.Size(88, 29);
            this.installmentCountCombo.TabIndex = 3;
            this.installmentCountCombo.UseSelectable = true;
            this.installmentCountCombo.SelectedIndexChanged += new System.EventHandler(this.installmentCountCombo_SelectedIndexChanged);
            // 
            // monthlyPaymentLabel
            // 
            this.monthlyPaymentLabel.AutoSize = true;
            this.monthlyPaymentLabel.Location = new System.Drawing.Point(8, 80);
            this.monthlyPaymentLabel.MaximumSize = new System.Drawing.Size(190, 0);
            this.monthlyPaymentLabel.Name = "monthlyPaymentLabel";
            this.monthlyPaymentLabel.Size = new System.Drawing.Size(0, 0);
            this.monthlyPaymentLabel.TabIndex = 14;
            // 
            // debtTransactionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 633);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.transactionTypeLabel);
            this.Controls.Add(this.dateComboLabel);
            this.Controls.Add(this.dateCombo);
            this.Controls.Add(this.moneyNumberToWordRichText);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.moneyValTextLabel);
            this.Controls.Add(this.moneyValText);
            this.Controls.Add(this.moneyTypeComboLabel);
            this.Controls.Add(this.bankTypeComboLabel);
            this.Controls.Add(this.customersComboLabel);
            this.Controls.Add(this.moneyTypesCombo);
            this.Controls.Add(this.bankTypesCombo);
            this.Controls.Add(this.customersCombo);
            this.Controls.Add(this.helpPictureBox);
            this.Controls.Add(this.connectSituation);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "debtTransactionsForm";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "Borç İşlemleri";
            this.Load += new System.EventHandler(this.sellForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpPictureBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroTile connectSituation;
        private System.Windows.Forms.PictureBox helpPictureBox;
        private MetroFramework.Controls.MetroTextBox moneyValText;
        private MetroFramework.Controls.MetroLabel moneyValTextLabel;
        private MetroFramework.Controls.MetroLabel customersComboLabel;
        private MetroFramework.Controls.MetroComboBox customersCombo;
        private MetroFramework.Controls.MetroRadioButton loanRadio;
        private MetroFramework.Controls.MetroRadioButton barrowRadio;
        private MetroFramework.Controls.MetroLabel bankTypeComboLabel;
        private MetroFramework.Controls.MetroComboBox bankTypesCombo;
        private MetroFramework.Controls.MetroLabel moneyTypeComboLabel;
        private MetroFramework.Controls.MetroComboBox moneyTypesCombo;
        private MetroFramework.Controls.MetroTile OKButton;
        private System.Windows.Forms.RichTextBox moneyNumberToWordRichText;
        private MetroFramework.Controls.MetroLabel dateComboLabel;
        private MetroFramework.Controls.MetroDateTime dateCombo;
        private MetroFramework.Controls.MetroButton saveButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private MetroFramework.Controls.MetroLabel transactionTypeLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroLabel installmentCountLabel;
        private MetroFramework.Controls.MetroRadioButton cashPaymentRadio;
        private MetroFramework.Controls.MetroRadioButton installmentPaymentRadio;
        private MetroFramework.Controls.MetroComboBox installmentCountCombo;
        private MetroFramework.Controls.MetroLabel monthlyPaymentLabel;
    }
}