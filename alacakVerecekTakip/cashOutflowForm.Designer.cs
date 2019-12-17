namespace alacakVerecekTakip
{
    partial class cashOutflowForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cashOutflowForm));
            this.helpPictureBox = new System.Windows.Forms.PictureBox();
            this.connectSituation = new MetroFramework.Controls.MetroTile();
            this.moneyCountLabel = new MetroFramework.Controls.MetroLabel();
            this.moneyTypesComboLabel = new MetroFramework.Controls.MetroLabel();
            this.bankTypeComboLabel = new MetroFramework.Controls.MetroLabel();
            this.OKButton = new MetroFramework.Controls.MetroTile();
            this.saveButton = new MetroFramework.Controls.MetroTile();
            this.moneyNumberToWordRichText = new System.Windows.Forms.RichTextBox();
            this.addMoneyCountText = new MetroFramework.Controls.MetroTextBox();
            this.moneyTypesCombo = new MetroFramework.Controls.MetroComboBox();
            this.bankTypesCombo = new MetroFramework.Controls.MetroComboBox();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.helpPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // helpPictureBox
            // 
            this.helpPictureBox.Image = global::alacakVerecekTakip.Properties.Resources.help;
            this.helpPictureBox.Location = new System.Drawing.Point(188, 27);
            this.helpPictureBox.Name = "helpPictureBox";
            this.helpPictureBox.Size = new System.Drawing.Size(25, 25);
            this.helpPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.helpPictureBox.TabIndex = 26;
            this.helpPictureBox.TabStop = false;
            // 
            // connectSituation
            // 
            this.connectSituation.ActiveControl = null;
            this.connectSituation.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.connectSituation.ForeColor = System.Drawing.Color.Lime;
            this.connectSituation.Location = new System.Drawing.Point(13, 378);
            this.connectSituation.Name = "connectSituation";
            this.connectSituation.Size = new System.Drawing.Size(18, 18);
            this.connectSituation.TabIndex = 25;
            this.connectSituation.UseCustomBackColor = true;
            this.connectSituation.UseSelectable = true;
            // 
            // moneyCountLabel
            // 
            this.moneyCountLabel.AutoSize = true;
            this.moneyCountLabel.Location = new System.Drawing.Point(34, 174);
            this.moneyCountLabel.Name = "moneyCountLabel";
            this.moneyCountLabel.Size = new System.Drawing.Size(121, 19);
            this.moneyCountLabel.TabIndex = 22;
            this.moneyCountLabel.Text = "Çıkartılacak Miktar:";
            // 
            // moneyTypesComboLabel
            // 
            this.moneyTypesComboLabel.AutoSize = true;
            this.moneyTypesComboLabel.Location = new System.Drawing.Point(18, 139);
            this.moneyTypesComboLabel.Name = "moneyTypesComboLabel";
            this.moneyTypesComboLabel.Size = new System.Drawing.Size(137, 19);
            this.moneyTypesComboLabel.TabIndex = 23;
            this.moneyTypesComboLabel.Text = "Çıkartılacak Para Türü:";
            // 
            // bankTypeComboLabel
            // 
            this.bankTypeComboLabel.AutoSize = true;
            this.bankTypeComboLabel.Location = new System.Drawing.Point(37, 103);
            this.bankTypeComboLabel.Name = "bankTypeComboLabel";
            this.bankTypeComboLabel.Size = new System.Drawing.Size(118, 19);
            this.bankTypeComboLabel.TabIndex = 24;
            this.bankTypeComboLabel.Text = "Çıkartılacak Banka:";
            // 
            // OKButton
            // 
            this.OKButton.ActiveControl = null;
            this.OKButton.BackColor = System.Drawing.Color.Silver;
            this.OKButton.Enabled = false;
            this.OKButton.Location = new System.Drawing.Point(370, 169);
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
            // saveButton
            // 
            this.saveButton.ActiveControl = null;
            this.saveButton.BackColor = System.Drawing.Color.Silver;
            this.saveButton.Enabled = false;
            this.saveButton.ForeColor = System.Drawing.Color.White;
            this.saveButton.Location = new System.Drawing.Point(155, 340);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(202, 40);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "ÇIKAR";
            this.saveButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.saveButton.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.saveButton.UseCustomBackColor = true;
            this.saveButton.UseCustomForeColor = true;
            this.saveButton.UseSelectable = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // moneyNumberToWordRichText
            // 
            this.moneyNumberToWordRichText.BackColor = System.Drawing.Color.White;
            this.moneyNumberToWordRichText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.moneyNumberToWordRichText.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.moneyNumberToWordRichText.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.moneyNumberToWordRichText.Location = new System.Drawing.Point(155, 204);
            this.moneyNumberToWordRichText.Name = "moneyNumberToWordRichText";
            this.moneyNumberToWordRichText.ReadOnly = true;
            this.moneyNumberToWordRichText.Size = new System.Drawing.Size(202, 116);
            this.moneyNumberToWordRichText.TabIndex = 19;
            this.moneyNumberToWordRichText.Text = "";
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
            this.addMoneyCountText.Location = new System.Drawing.Point(155, 169);
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
            this.addMoneyCountText.TabIndex = 2;
            this.addMoneyCountText.UseSelectable = true;
            this.addMoneyCountText.WaterMark = "Orn:123,45";
            this.addMoneyCountText.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.addMoneyCountText.WaterMarkFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.addMoneyCountText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.addMoneyCountText_KeyPress);
            // 
            // moneyTypesCombo
            // 
            this.moneyTypesCombo.Enabled = false;
            this.moneyTypesCombo.FormattingEnabled = true;
            this.moneyTypesCombo.ItemHeight = 23;
            this.moneyTypesCombo.Location = new System.Drawing.Point(155, 133);
            this.moneyTypesCombo.Name = "moneyTypesCombo";
            this.moneyTypesCombo.Size = new System.Drawing.Size(202, 29);
            this.moneyTypesCombo.TabIndex = 1;
            this.moneyTypesCombo.UseSelectable = true;
            this.moneyTypesCombo.SelectedIndexChanged += new System.EventHandler(this.moneyTypesCombo_SelectedIndexChanged);
            // 
            // bankTypesCombo
            // 
            this.bankTypesCombo.FormattingEnabled = true;
            this.bankTypesCombo.ItemHeight = 23;
            this.bankTypesCombo.Location = new System.Drawing.Point(155, 98);
            this.bankTypesCombo.Name = "bankTypesCombo";
            this.bankTypesCombo.Size = new System.Drawing.Size(202, 29);
            this.bankTypesCombo.TabIndex = 0;
            this.bankTypesCombo.UseSelectable = true;
            this.bankTypesCombo.SelectedIndexChanged += new System.EventHandler(this.bankTypesCombo_SelectedIndexChanged);
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // cashOutflowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 408);
            this.Controls.Add(this.helpPictureBox);
            this.Controls.Add(this.connectSituation);
            this.Controls.Add(this.moneyCountLabel);
            this.Controls.Add(this.moneyTypesComboLabel);
            this.Controls.Add(this.bankTypeComboLabel);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.moneyNumberToWordRichText);
            this.Controls.Add(this.addMoneyCountText);
            this.Controls.Add(this.moneyTypesCombo);
            this.Controls.Add(this.bankTypesCombo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "cashOutflowForm";
            this.Text = "Kasa Para Çıkışı";
            this.Load += new System.EventHandler(this.cashOutflowForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.helpPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox helpPictureBox;
        private MetroFramework.Controls.MetroTile connectSituation;
        private MetroFramework.Controls.MetroLabel moneyCountLabel;
        private MetroFramework.Controls.MetroLabel moneyTypesComboLabel;
        private MetroFramework.Controls.MetroLabel bankTypeComboLabel;
        private MetroFramework.Controls.MetroTile OKButton;
        private MetroFramework.Controls.MetroTile saveButton;
        private System.Windows.Forms.RichTextBox moneyNumberToWordRichText;
        private MetroFramework.Controls.MetroTextBox addMoneyCountText;
        private MetroFramework.Controls.MetroComboBox moneyTypesCombo;
        private MetroFramework.Controls.MetroComboBox bankTypesCombo;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
    }
}