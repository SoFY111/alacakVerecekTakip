namespace alacakVerecekTakip
{
    partial class cashInflowForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cashInflowForm));
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.bankTypesCombo = new MetroFramework.Controls.MetroComboBox();
            this.moneyTypesCombo = new MetroFramework.Controls.MetroComboBox();
            this.addMoneyCountText = new MetroFramework.Controls.MetroTextBox();
            this.moneyNumberToWordRichText = new System.Windows.Forms.RichTextBox();
            this.saveButton = new MetroFramework.Controls.MetroTile();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.connectSituation = new MetroFramework.Controls.MetroTile();
            this.helpPictureBox = new System.Windows.Forms.PictureBox();
            this.OKButton = new MetroFramework.Controls.MetroTile();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // bankTypesCombo
            // 
            this.bankTypesCombo.FormattingEnabled = true;
            this.bankTypesCombo.ItemHeight = 23;
            this.bankTypesCombo.Location = new System.Drawing.Point(146, 97);
            this.bankTypesCombo.Name = "bankTypesCombo";
            this.bankTypesCombo.Size = new System.Drawing.Size(202, 29);
            this.bankTypesCombo.TabIndex = 0;
            this.bankTypesCombo.UseSelectable = true;
            this.bankTypesCombo.SelectedIndexChanged += new System.EventHandler(this.bankTypesCombo_SelectedIndexChanged);
            // 
            // moneyTypesCombo
            // 
            this.moneyTypesCombo.Enabled = false;
            this.moneyTypesCombo.FormattingEnabled = true;
            this.moneyTypesCombo.ItemHeight = 23;
            this.moneyTypesCombo.Location = new System.Drawing.Point(146, 132);
            this.moneyTypesCombo.Name = "moneyTypesCombo";
            this.moneyTypesCombo.Size = new System.Drawing.Size(202, 29);
            this.moneyTypesCombo.TabIndex = 0;
            this.moneyTypesCombo.UseSelectable = true;
            this.moneyTypesCombo.SelectedIndexChanged += new System.EventHandler(this.moneyTypesCombo_SelectedIndexChanged);
            // 
            // addMoneyCountText
            // 
            // 
            // 
            // 
            this.addMoneyCountText.CustomButton.Image = null;
            this.addMoneyCountText.CustomButton.Location = new System.Drawing.Point(174, 1);
            this.addMoneyCountText.CustomButton.Name = "";
            this.addMoneyCountText.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.addMoneyCountText.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.addMoneyCountText.CustomButton.TabIndex = 1;
            this.addMoneyCountText.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.addMoneyCountText.CustomButton.UseSelectable = true;
            this.addMoneyCountText.CustomButton.Visible = false;
            this.addMoneyCountText.Enabled = false;
            this.addMoneyCountText.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.addMoneyCountText.Lines = new string[0];
            this.addMoneyCountText.Location = new System.Drawing.Point(146, 168);
            this.addMoneyCountText.MaxLength = 32767;
            this.addMoneyCountText.Name = "addMoneyCountText";
            this.addMoneyCountText.PasswordChar = '\0';
            this.addMoneyCountText.PromptText = "Orn:123,45";
            this.addMoneyCountText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.addMoneyCountText.SelectedText = "";
            this.addMoneyCountText.SelectionLength = 0;
            this.addMoneyCountText.SelectionStart = 0;
            this.addMoneyCountText.ShortcutsEnabled = true;
            this.addMoneyCountText.Size = new System.Drawing.Size(202, 29);
            this.addMoneyCountText.TabIndex = 1;
            this.addMoneyCountText.UseSelectable = true;
            this.addMoneyCountText.WaterMark = "Orn:123,45";
            this.addMoneyCountText.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.addMoneyCountText.WaterMarkFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.addMoneyCountText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.addMoneyCountText_KeyPress);
            // 
            // moneyNumberToWordRichText
            // 
            this.moneyNumberToWordRichText.BackColor = System.Drawing.Color.White;
            this.moneyNumberToWordRichText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.moneyNumberToWordRichText.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.moneyNumberToWordRichText.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.moneyNumberToWordRichText.Location = new System.Drawing.Point(146, 203);
            this.moneyNumberToWordRichText.Name = "moneyNumberToWordRichText";
            this.moneyNumberToWordRichText.ReadOnly = true;
            this.moneyNumberToWordRichText.Size = new System.Drawing.Size(202, 116);
            this.moneyNumberToWordRichText.TabIndex = 2;
            this.moneyNumberToWordRichText.Text = "";
            // 
            // saveButton
            // 
            this.saveButton.ActiveControl = null;
            this.saveButton.BackColor = System.Drawing.Color.Silver;
            this.saveButton.Enabled = false;
            this.saveButton.ForeColor = System.Drawing.Color.White;
            this.saveButton.Location = new System.Drawing.Point(146, 339);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(202, 40);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "EKLE";
            this.saveButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.saveButton.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.saveButton.UseCustomBackColor = true;
            this.saveButton.UseCustomForeColor = true;
            this.saveButton.UseSelectable = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(39, 102);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(107, 19);
            this.metroLabel1.TabIndex = 12;
            this.metroLabel1.Text = "Eklenecek Banka:";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(20, 138);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(126, 19);
            this.metroLabel2.TabIndex = 12;
            this.metroLabel2.Text = "Eklenecek Para Türü:";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(36, 173);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(110, 19);
            this.metroLabel3.TabIndex = 12;
            this.metroLabel3.Text = "Eklenecek Miktar:";
            // 
            // connectSituation
            // 
            this.connectSituation.ActiveControl = null;
            this.connectSituation.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.connectSituation.ForeColor = System.Drawing.Color.Lime;
            this.connectSituation.Location = new System.Drawing.Point(16, 377);
            this.connectSituation.Name = "connectSituation";
            this.connectSituation.Size = new System.Drawing.Size(18, 18);
            this.connectSituation.TabIndex = 13;
            this.connectSituation.UseCustomBackColor = true;
            this.connectSituation.UseSelectable = true;
            // 
            // helpPictureBox
            // 
            this.helpPictureBox.Image = global::alacakVerecekTakip.Properties.Resources.help;
            this.helpPictureBox.Location = new System.Drawing.Point(183, 26);
            this.helpPictureBox.Name = "helpPictureBox";
            this.helpPictureBox.Size = new System.Drawing.Size(25, 25);
            this.helpPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.helpPictureBox.TabIndex = 15;
            this.helpPictureBox.TabStop = false;
            // 
            // OKButton
            // 
            this.OKButton.ActiveControl = null;
            this.OKButton.BackColor = System.Drawing.Color.Silver;
            this.OKButton.Enabled = false;
            this.OKButton.Location = new System.Drawing.Point(361, 168);
            this.OKButton.Margin = new System.Windows.Forms.Padding(0);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(33, 28);
            this.OKButton.TabIndex = 2;
            this.OKButton.TileImage = global::alacakVerecekTakip.Properties.Resources.OK4;
            this.OKButton.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.OKButton.UseCustomBackColor = true;
            this.OKButton.UseSelectable = true;
            this.OKButton.UseTileImage = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // cashInflowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 408);
            this.Controls.Add(this.helpPictureBox);
            this.Controls.Add(this.connectSituation);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.moneyNumberToWordRichText);
            this.Controls.Add(this.addMoneyCountText);
            this.Controls.Add(this.moneyTypesCombo);
            this.Controls.Add(this.bankTypesCombo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "cashInflowForm";
            this.Resizable = false;
            this.Text = "Kasa Para Girişi";
            this.Load += new System.EventHandler(this.cashInflowForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroTextBox addMoneyCountText;
        private MetroFramework.Controls.MetroComboBox moneyTypesCombo;
        private MetroFramework.Controls.MetroComboBox bankTypesCombo;
        private MetroFramework.Controls.MetroTile saveButton;
        private System.Windows.Forms.RichTextBox moneyNumberToWordRichText;
        private MetroFramework.Controls.MetroTile OKButton;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTile connectSituation;
        private System.Windows.Forms.PictureBox helpPictureBox;
    }
}