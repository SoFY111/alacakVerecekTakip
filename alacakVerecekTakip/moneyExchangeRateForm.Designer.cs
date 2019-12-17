namespace alacakVerecekTakip
{
    partial class moneyExchangeRateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(moneyExchangeRateForm));
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.connectSituation = new MetroFramework.Controls.MetroTile();
            this.baseMoneyLabel = new MetroFramework.Controls.MetroLabel();
            this.baseMoneyTypeCombo = new MetroFramework.Controls.MetroComboBox();
            this.exchangeMoneyLabel1 = new MetroFramework.Controls.MetroLabel();
            this.baseMoneyTypeButton = new MetroFramework.Controls.MetroButton();
            this.exchangeMoneyGroup = new System.Windows.Forms.GroupBox();
            this.exchangeMoneyResultLabel = new MetroFramework.Controls.MetroLabel();
            this.saveExchangeMoneyRateButton = new MetroFramework.Controls.MetroTile();
            this.exchangeRateText = new MetroFramework.Controls.MetroTextBox();
            this.exchangeMoneyCombo = new MetroFramework.Controls.MetroComboBox();
            this.exchangeMoneyLabel2 = new MetroFramework.Controls.MetroLabel();
            this.editMoneyBalanceButton = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.exchangeMoneyGroup.SuspendLayout();
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
            this.connectSituation.Location = new System.Drawing.Point(21, 287);
            this.connectSituation.Name = "connectSituation";
            this.connectSituation.Size = new System.Drawing.Size(18, 18);
            this.connectSituation.TabIndex = 11;
            this.connectSituation.UseCustomBackColor = true;
            this.connectSituation.UseSelectable = true;
            // 
            // baseMoneyLabel
            // 
            this.baseMoneyLabel.AutoSize = true;
            this.baseMoneyLabel.Location = new System.Drawing.Point(58, 77);
            this.baseMoneyLabel.Name = "baseMoneyLabel";
            this.baseMoneyLabel.Size = new System.Drawing.Size(143, 19);
            this.baseMoneyLabel.TabIndex = 12;
            this.baseMoneyLabel.Text = "Baz Alınacak Para Türü:";
            // 
            // baseMoneyTypeCombo
            // 
            this.baseMoneyTypeCombo.FormattingEnabled = true;
            this.baseMoneyTypeCombo.ItemHeight = 23;
            this.baseMoneyTypeCombo.Location = new System.Drawing.Point(201, 72);
            this.baseMoneyTypeCombo.Name = "baseMoneyTypeCombo";
            this.baseMoneyTypeCombo.Size = new System.Drawing.Size(166, 29);
            this.baseMoneyTypeCombo.TabIndex = 13;
            this.baseMoneyTypeCombo.UseSelectable = true;
            this.baseMoneyTypeCombo.SelectedIndexChanged += new System.EventHandler(this.baseMoneyTypeCombo_SelectedIndexChanged);
            // 
            // exchangeMoneyLabel1
            // 
            this.exchangeMoneyLabel1.AutoSize = true;
            this.exchangeMoneyLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.exchangeMoneyLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.exchangeMoneyLabel1.Location = new System.Drawing.Point(18, 49);
            this.exchangeMoneyLabel1.Name = "exchangeMoneyLabel1";
            this.exchangeMoneyLabel1.Size = new System.Drawing.Size(27, 25);
            this.exchangeMoneyLabel1.TabIndex = 14;
            this.exchangeMoneyLabel1.Text = "1 ";
            // 
            // baseMoneyTypeButton
            // 
            this.baseMoneyTypeButton.BackColor = System.Drawing.Color.Silver;
            this.baseMoneyTypeButton.Enabled = false;
            this.baseMoneyTypeButton.ForeColor = System.Drawing.Color.Black;
            this.baseMoneyTypeButton.Location = new System.Drawing.Point(373, 72);
            this.baseMoneyTypeButton.Name = "baseMoneyTypeButton";
            this.baseMoneyTypeButton.Size = new System.Drawing.Size(87, 29);
            this.baseMoneyTypeButton.TabIndex = 15;
            this.baseMoneyTypeButton.Text = "KAYDET";
            this.baseMoneyTypeButton.UseCustomBackColor = true;
            this.baseMoneyTypeButton.UseCustomForeColor = true;
            this.baseMoneyTypeButton.UseSelectable = true;
            this.baseMoneyTypeButton.Click += new System.EventHandler(this.baseStandartMoneyTypeButton_Click);
            // 
            // exchangeMoneyGroup
            // 
            this.exchangeMoneyGroup.Controls.Add(this.exchangeMoneyResultLabel);
            this.exchangeMoneyGroup.Controls.Add(this.saveExchangeMoneyRateButton);
            this.exchangeMoneyGroup.Controls.Add(this.exchangeRateText);
            this.exchangeMoneyGroup.Controls.Add(this.exchangeMoneyCombo);
            this.exchangeMoneyGroup.Controls.Add(this.exchangeMoneyLabel2);
            this.exchangeMoneyGroup.Controls.Add(this.exchangeMoneyLabel1);
            this.exchangeMoneyGroup.Enabled = false;
            this.exchangeMoneyGroup.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.exchangeMoneyGroup.ForeColor = System.Drawing.Color.Silver;
            this.exchangeMoneyGroup.Location = new System.Drawing.Point(58, 144);
            this.exchangeMoneyGroup.Name = "exchangeMoneyGroup";
            this.exchangeMoneyGroup.Size = new System.Drawing.Size(402, 146);
            this.exchangeMoneyGroup.TabIndex = 16;
            this.exchangeMoneyGroup.TabStop = false;
            this.exchangeMoneyGroup.Text = "Kurları Değiştir";
            // 
            // exchangeMoneyResultLabel
            // 
            this.exchangeMoneyResultLabel.AutoSize = true;
            this.exchangeMoneyResultLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.exchangeMoneyResultLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.exchangeMoneyResultLabel.Location = new System.Drawing.Point(18, 104);
            this.exchangeMoneyResultLabel.Name = "exchangeMoneyResultLabel";
            this.exchangeMoneyResultLabel.Size = new System.Drawing.Size(0, 0);
            this.exchangeMoneyResultLabel.TabIndex = 19;
            // 
            // saveExchangeMoneyRateButton
            // 
            this.saveExchangeMoneyRateButton.ActiveControl = null;
            this.saveExchangeMoneyRateButton.BackColor = System.Drawing.Color.Silver;
            this.saveExchangeMoneyRateButton.Location = new System.Drawing.Point(313, 49);
            this.saveExchangeMoneyRateButton.Name = "saveExchangeMoneyRateButton";
            this.saveExchangeMoneyRateButton.Size = new System.Drawing.Size(33, 30);
            this.saveExchangeMoneyRateButton.TabIndex = 18;
            this.saveExchangeMoneyRateButton.TileImage = global::alacakVerecekTakip.Properties.Resources.OK4;
            this.saveExchangeMoneyRateButton.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.saveExchangeMoneyRateButton.UseCustomBackColor = true;
            this.saveExchangeMoneyRateButton.UseCustomForeColor = true;
            this.saveExchangeMoneyRateButton.UseSelectable = true;
            this.saveExchangeMoneyRateButton.UseTileImage = true;
            this.saveExchangeMoneyRateButton.Click += new System.EventHandler(this.saveExchangeMoneyRateButton_Click);
            // 
            // exchangeRateText
            // 
            // 
            // 
            // 
            this.exchangeRateText.CustomButton.Image = null;
            this.exchangeRateText.CustomButton.Location = new System.Drawing.Point(22, 1);
            this.exchangeRateText.CustomButton.Name = "";
            this.exchangeRateText.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.exchangeRateText.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.exchangeRateText.CustomButton.TabIndex = 1;
            this.exchangeRateText.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.exchangeRateText.CustomButton.UseSelectable = true;
            this.exchangeRateText.CustomButton.Visible = false;
            this.exchangeRateText.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.exchangeRateText.Lines = new string[0];
            this.exchangeRateText.Location = new System.Drawing.Point(161, 49);
            this.exchangeRateText.MaxLength = 32767;
            this.exchangeRateText.Name = "exchangeRateText";
            this.exchangeRateText.PasswordChar = '\0';
            this.exchangeRateText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.exchangeRateText.SelectedText = "";
            this.exchangeRateText.SelectionLength = 0;
            this.exchangeRateText.SelectionStart = 0;
            this.exchangeRateText.ShortcutsEnabled = true;
            this.exchangeRateText.Size = new System.Drawing.Size(50, 29);
            this.exchangeRateText.TabIndex = 17;
            this.exchangeRateText.UseSelectable = true;
            this.exchangeRateText.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.exchangeRateText.WaterMarkFont = new System.Drawing.Font("Century Gothic", 25F, System.Drawing.FontStyle.Italic);
            this.exchangeRateText.TextChanged += new System.EventHandler(this.exchangeRateText_TextChanged);
            this.exchangeRateText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.exchangeRateText_KeyPress);
            // 
            // exchangeMoneyCombo
            // 
            this.exchangeMoneyCombo.FormattingEnabled = true;
            this.exchangeMoneyCombo.ItemHeight = 23;
            this.exchangeMoneyCombo.Location = new System.Drawing.Point(40, 49);
            this.exchangeMoneyCombo.Name = "exchangeMoneyCombo";
            this.exchangeMoneyCombo.Size = new System.Drawing.Size(115, 29);
            this.exchangeMoneyCombo.TabIndex = 13;
            this.exchangeMoneyCombo.UseSelectable = true;
            this.exchangeMoneyCombo.SelectedIndexChanged += new System.EventHandler(this.exchangeMoneyCombo_SelectedIndexChanged);
            // 
            // exchangeMoneyLabel2
            // 
            this.exchangeMoneyLabel2.AutoSize = true;
            this.exchangeMoneyLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.exchangeMoneyLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.exchangeMoneyLabel2.Location = new System.Drawing.Point(217, 50);
            this.exchangeMoneyLabel2.Name = "exchangeMoneyLabel2";
            this.exchangeMoneyLabel2.Size = new System.Drawing.Size(20, 25);
            this.exchangeMoneyLabel2.TabIndex = 16;
            this.exchangeMoneyLabel2.Text = "*";
            // 
            // editMoneyBalanceButton
            // 
            this.editMoneyBalanceButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.editMoneyBalanceButton.ForeColor = System.Drawing.Color.White;
            this.editMoneyBalanceButton.Location = new System.Drawing.Point(373, 110);
            this.editMoneyBalanceButton.Name = "editMoneyBalanceButton";
            this.editMoneyBalanceButton.Size = new System.Drawing.Size(87, 35);
            this.editMoneyBalanceButton.TabIndex = 15;
            this.editMoneyBalanceButton.Text = "Kur Düzenle";
            this.editMoneyBalanceButton.UseCustomBackColor = true;
            this.editMoneyBalanceButton.UseCustomForeColor = true;
            this.editMoneyBalanceButton.UseSelectable = true;
            this.editMoneyBalanceButton.Click += new System.EventHandler(this.editMoneyBalanceButton_Click);
            // 
            // moneyExchangeRateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 317);
            this.Controls.Add(this.exchangeMoneyGroup);
            this.Controls.Add(this.editMoneyBalanceButton);
            this.Controls.Add(this.baseMoneyTypeButton);
            this.Controls.Add(this.baseMoneyTypeCombo);
            this.Controls.Add(this.baseMoneyLabel);
            this.Controls.Add(this.connectSituation);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "moneyExchangeRateForm";
            this.Resizable = false;
            this.Text = "Para Kuru Ayarlama";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.moneyExchangeRateForm_FormClosing);
            this.Load += new System.EventHandler(this.moneyExchangeRate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.exchangeMoneyGroup.ResumeLayout(false);
            this.exchangeMoneyGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroTile connectSituation;
        private MetroFramework.Controls.MetroComboBox baseMoneyTypeCombo;
        private MetroFramework.Controls.MetroLabel baseMoneyLabel;
        private MetroFramework.Controls.MetroLabel exchangeMoneyLabel1;
        private MetroFramework.Controls.MetroButton baseMoneyTypeButton;
        private System.Windows.Forms.GroupBox exchangeMoneyGroup;
        private MetroFramework.Controls.MetroTextBox exchangeRateText;
        private MetroFramework.Controls.MetroLabel exchangeMoneyLabel2;
        private MetroFramework.Controls.MetroTile saveExchangeMoneyRateButton;
        private MetroFramework.Controls.MetroLabel exchangeMoneyResultLabel;
        private MetroFramework.Controls.MetroComboBox exchangeMoneyCombo;
        private MetroFramework.Controls.MetroButton editMoneyBalanceButton;
    }
}