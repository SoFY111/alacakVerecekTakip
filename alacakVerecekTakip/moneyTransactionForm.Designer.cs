﻿namespace alacakVerecekTakip
{
    partial class moneyTransactionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(moneyTransactionForm));
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.customerNameAndSurnameComboLabel = new MetroFramework.Controls.MetroLabel();
            this.customerNameAndSurnameCombo = new MetroFramework.Controls.MetroComboBox();
            this.connectSituation = new MetroFramework.Controls.MetroTile();
            this.customerDebtListCombo = new MetroFramework.Controls.MetroComboBox();
            this.customerDebtListView = new MetroFramework.Controls.MetroListView();
            this.bankTypesText1 = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.moneyTypesText1 = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.moneyNumberToWordRichText = new System.Windows.Forms.RichTextBox();
            this.moneyValText = new MetroFramework.Controls.MetroTextBox();
            this.moneyNumberToWordRichText1 = new System.Windows.Forms.RichTextBox();
            this.moneyValText1 = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.inputMoneyVal = new MetroFramework.Controls.MetroTextBox();
            this.moneyNumberToWordRichText2 = new System.Windows.Forms.RichTextBox();
            this.OKButton = new MetroFramework.Controls.MetroTile();
            this.saveButton = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // customerNameAndSurnameComboLabel
            // 
            this.customerNameAndSurnameComboLabel.AutoSize = true;
            this.customerNameAndSurnameComboLabel.Location = new System.Drawing.Point(239, 95);
            this.customerNameAndSurnameComboLabel.Name = "customerNameAndSurnameComboLabel";
            this.customerNameAndSurnameComboLabel.Size = new System.Drawing.Size(122, 19);
            this.customerNameAndSurnameComboLabel.TabIndex = 0;
            this.customerNameAndSurnameComboLabel.Text = "Para Veren Müşteri:";
            // 
            // customerNameAndSurnameCombo
            // 
            this.customerNameAndSurnameCombo.FormattingEnabled = true;
            this.customerNameAndSurnameCombo.ItemHeight = 23;
            this.customerNameAndSurnameCombo.Location = new System.Drawing.Point(361, 91);
            this.customerNameAndSurnameCombo.Name = "customerNameAndSurnameCombo";
            this.customerNameAndSurnameCombo.Size = new System.Drawing.Size(228, 29);
            this.customerNameAndSurnameCombo.TabIndex = 1;
            this.customerNameAndSurnameCombo.UseSelectable = true;
            this.customerNameAndSurnameCombo.SelectedIndexChanged += new System.EventHandler(this.customerNameAndSurnameCombo_SelectedIndexChanged);
            // 
            // connectSituation
            // 
            this.connectSituation.ActiveControl = null;
            this.connectSituation.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.connectSituation.ForeColor = System.Drawing.Color.Lime;
            this.connectSituation.Location = new System.Drawing.Point(23, 717);
            this.connectSituation.Name = "connectSituation";
            this.connectSituation.Size = new System.Drawing.Size(18, 18);
            this.connectSituation.TabIndex = 13;
            this.connectSituation.UseCustomBackColor = true;
            this.connectSituation.UseSelectable = true;
            // 
            // customerDebtListCombo
            // 
            this.customerDebtListCombo.FormattingEnabled = true;
            this.customerDebtListCombo.ItemHeight = 23;
            this.customerDebtListCombo.Location = new System.Drawing.Point(361, 126);
            this.customerDebtListCombo.Name = "customerDebtListCombo";
            this.customerDebtListCombo.Size = new System.Drawing.Size(364, 29);
            this.customerDebtListCombo.TabIndex = 2;
            this.customerDebtListCombo.UseSelectable = true;
            this.customerDebtListCombo.SelectedIndexChanged += new System.EventHandler(this.customerDebtListCombo_SelectedIndexChanged);
            // 
            // customerDebtListView
            // 
            this.customerDebtListView.BackColor = System.Drawing.SystemColors.Window;
            this.customerDebtListView.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.customerDebtListView.FullRowSelect = true;
            this.customerDebtListView.Location = new System.Drawing.Point(119, 161);
            this.customerDebtListView.MultiSelect = false;
            this.customerDebtListView.Name = "customerDebtListView";
            this.customerDebtListView.OwnerDraw = true;
            this.customerDebtListView.Size = new System.Drawing.Size(900, 185);
            this.customerDebtListView.TabIndex = 3;
            this.customerDebtListView.UseCompatibleStateImageBehavior = false;
            this.customerDebtListView.UseSelectable = true;
            this.customerDebtListView.SelectedIndexChanged += new System.EventHandler(this.customerDebtListView_SelectedIndexChanged);
            // 
            // bankTypesText1
            // 
            // 
            // 
            // 
            this.bankTypesText1.CustomButton.Image = null;
            this.bankTypesText1.CustomButton.Location = new System.Drawing.Point(200, 1);
            this.bankTypesText1.CustomButton.Name = "";
            this.bankTypesText1.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.bankTypesText1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.bankTypesText1.CustomButton.TabIndex = 1;
            this.bankTypesText1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.bankTypesText1.CustomButton.UseSelectable = true;
            this.bankTypesText1.CustomButton.Visible = false;
            this.bankTypesText1.Enabled = false;
            this.bankTypesText1.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.bankTypesText1.Lines = new string[0];
            this.bankTypesText1.Location = new System.Drawing.Point(201, 385);
            this.bankTypesText1.MaxLength = 32767;
            this.bankTypesText1.Name = "bankTypesText1";
            this.bankTypesText1.PasswordChar = '\0';
            this.bankTypesText1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.bankTypesText1.SelectedText = "";
            this.bankTypesText1.SelectionLength = 0;
            this.bankTypesText1.SelectionStart = 0;
            this.bankTypesText1.ShortcutsEnabled = true;
            this.bankTypesText1.Size = new System.Drawing.Size(228, 29);
            this.bankTypesText1.TabIndex = 4;
            this.bankTypesText1.UseSelectable = true;
            this.bankTypesText1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.bankTypesText1.WaterMarkFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(31, 389);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(170, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Para Yatıralacak Banka Türü:";
            // 
            // moneyTypesText1
            // 
            // 
            // 
            // 
            this.moneyTypesText1.CustomButton.Image = null;
            this.moneyTypesText1.CustomButton.Location = new System.Drawing.Point(200, 1);
            this.moneyTypesText1.CustomButton.Name = "";
            this.moneyTypesText1.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.moneyTypesText1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.moneyTypesText1.CustomButton.TabIndex = 1;
            this.moneyTypesText1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.moneyTypesText1.CustomButton.UseSelectable = true;
            this.moneyTypesText1.CustomButton.Visible = false;
            this.moneyTypesText1.Enabled = false;
            this.moneyTypesText1.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.moneyTypesText1.Lines = new string[0];
            this.moneyTypesText1.Location = new System.Drawing.Point(201, 420);
            this.moneyTypesText1.MaxLength = 32767;
            this.moneyTypesText1.Name = "moneyTypesText1";
            this.moneyTypesText1.PasswordChar = '\0';
            this.moneyTypesText1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.moneyTypesText1.SelectedText = "";
            this.moneyTypesText1.SelectionLength = 0;
            this.moneyTypesText1.SelectionStart = 0;
            this.moneyTypesText1.ShortcutsEnabled = true;
            this.moneyTypesText1.Size = new System.Drawing.Size(228, 29);
            this.moneyTypesText1.TabIndex = 5;
            this.moneyTypesText1.UseSelectable = true;
            this.moneyTypesText1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.moneyTypesText1.WaterMarkFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(70, 424);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(131, 19);
            this.metroLabel2.TabIndex = 0;
            this.metroLabel2.Text = "Yatıralacak Para Türü:";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(5, 459);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(196, 19);
            this.metroLabel3.TabIndex = 0;
            this.metroLabel3.Text = "Yatırılması Gereken Para Miktarı:";
            // 
            // moneyNumberToWordRichText
            // 
            this.moneyNumberToWordRichText.BackColor = System.Drawing.Color.White;
            this.moneyNumberToWordRichText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.moneyNumberToWordRichText.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.moneyNumberToWordRichText.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.moneyNumberToWordRichText.Location = new System.Drawing.Point(201, 490);
            this.moneyNumberToWordRichText.Name = "moneyNumberToWordRichText";
            this.moneyNumberToWordRichText.ReadOnly = true;
            this.moneyNumberToWordRichText.Size = new System.Drawing.Size(228, 102);
            this.moneyNumberToWordRichText.TabIndex = 10003;
            this.moneyNumberToWordRichText.Text = "";
            // 
            // moneyValText
            // 
            // 
            // 
            // 
            this.moneyValText.CustomButton.Image = null;
            this.moneyValText.CustomButton.Location = new System.Drawing.Point(200, 1);
            this.moneyValText.CustomButton.Name = "";
            this.moneyValText.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.moneyValText.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.moneyValText.CustomButton.TabIndex = 1;
            this.moneyValText.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.moneyValText.CustomButton.UseSelectable = true;
            this.moneyValText.CustomButton.Visible = false;
            this.moneyValText.Enabled = false;
            this.moneyValText.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.moneyValText.Lines = new string[0];
            this.moneyValText.Location = new System.Drawing.Point(201, 455);
            this.moneyValText.MaxLength = 32767;
            this.moneyValText.Name = "moneyValText";
            this.moneyValText.PasswordChar = '\0';
            this.moneyValText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.moneyValText.SelectedText = "";
            this.moneyValText.SelectionLength = 0;
            this.moneyValText.SelectionStart = 0;
            this.moneyValText.ShortcutsEnabled = true;
            this.moneyValText.Size = new System.Drawing.Size(228, 29);
            this.moneyValText.TabIndex = 19999;
            this.moneyValText.UseSelectable = true;
            this.moneyValText.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.moneyValText.WaterMarkFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            // 
            // moneyNumberToWordRichText1
            // 
            this.moneyNumberToWordRichText1.BackColor = System.Drawing.Color.White;
            this.moneyNumberToWordRichText1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.moneyNumberToWordRichText1.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.moneyNumberToWordRichText1.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.moneyNumberToWordRichText1.Location = new System.Drawing.Point(201, 633);
            this.moneyNumberToWordRichText1.Name = "moneyNumberToWordRichText1";
            this.moneyNumberToWordRichText1.ReadOnly = true;
            this.moneyNumberToWordRichText1.Size = new System.Drawing.Size(228, 102);
            this.moneyNumberToWordRichText1.TabIndex = 10006;
            this.moneyNumberToWordRichText1.Text = "";
            // 
            // moneyValText1
            // 
            // 
            // 
            // 
            this.moneyValText1.CustomButton.Image = null;
            this.moneyValText1.CustomButton.Location = new System.Drawing.Point(200, 1);
            this.moneyValText1.CustomButton.Name = "";
            this.moneyValText1.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.moneyValText1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.moneyValText1.CustomButton.TabIndex = 1;
            this.moneyValText1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.moneyValText1.CustomButton.UseSelectable = true;
            this.moneyValText1.CustomButton.Visible = false;
            this.moneyValText1.Enabled = false;
            this.moneyValText1.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.moneyValText1.Lines = new string[0];
            this.moneyValText1.Location = new System.Drawing.Point(201, 598);
            this.moneyValText1.MaxLength = 32767;
            this.moneyValText1.Name = "moneyValText1";
            this.moneyValText1.PasswordChar = '\0';
            this.moneyValText1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.moneyValText1.SelectedText = "";
            this.moneyValText1.SelectionLength = 0;
            this.moneyValText1.SelectionStart = 0;
            this.moneyValText1.ShortcutsEnabled = true;
            this.moneyValText1.Size = new System.Drawing.Size(228, 29);
            this.moneyValText1.TabIndex = 199999;
            this.moneyValText1.UseSelectable = true;
            this.moneyValText1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.moneyValText1.WaterMarkFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(26, 602);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(175, 19);
            this.metroLabel4.TabIndex = 10004;
            this.metroLabel4.Text = "Şimdiye Kadar Yatırılan Para:";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(173, 353);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(250, 19);
            this.metroLabel5.TabIndex = 200000;
            this.metroLabel5.Text = "Şimdiye kadar yatırılan toplam  para ........";
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(607, 389);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(143, 19);
            this.metroLabel6.TabIndex = 0;
            this.metroLabel6.Text = "Yatırılacak Para Miktarı:";
            // 
            // inputMoneyVal
            // 
            // 
            // 
            // 
            this.inputMoneyVal.CustomButton.Image = null;
            this.inputMoneyVal.CustomButton.Location = new System.Drawing.Point(200, 1);
            this.inputMoneyVal.CustomButton.Name = "";
            this.inputMoneyVal.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.inputMoneyVal.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.inputMoneyVal.CustomButton.TabIndex = 1;
            this.inputMoneyVal.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.inputMoneyVal.CustomButton.UseSelectable = true;
            this.inputMoneyVal.CustomButton.Visible = false;
            this.inputMoneyVal.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.inputMoneyVal.Lines = new string[0];
            this.inputMoneyVal.Location = new System.Drawing.Point(750, 385);
            this.inputMoneyVal.MaxLength = 32767;
            this.inputMoneyVal.Name = "inputMoneyVal";
            this.inputMoneyVal.PasswordChar = '\0';
            this.inputMoneyVal.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.inputMoneyVal.SelectedText = "";
            this.inputMoneyVal.SelectionLength = 0;
            this.inputMoneyVal.SelectionStart = 0;
            this.inputMoneyVal.ShortcutsEnabled = true;
            this.inputMoneyVal.Size = new System.Drawing.Size(228, 29);
            this.inputMoneyVal.TabIndex = 19999;
            this.inputMoneyVal.UseSelectable = true;
            this.inputMoneyVal.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.inputMoneyVal.WaterMarkFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.inputMoneyVal.TextChanged += new System.EventHandler(this.inputMoneyVal_TextChanged);
            this.inputMoneyVal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputMoneyVal_KeyPress);
            // 
            // moneyNumberToWordRichText2
            // 
            this.moneyNumberToWordRichText2.BackColor = System.Drawing.Color.White;
            this.moneyNumberToWordRichText2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.moneyNumberToWordRichText2.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.moneyNumberToWordRichText2.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.moneyNumberToWordRichText2.Location = new System.Drawing.Point(750, 420);
            this.moneyNumberToWordRichText2.Name = "moneyNumberToWordRichText2";
            this.moneyNumberToWordRichText2.ReadOnly = true;
            this.moneyNumberToWordRichText2.Size = new System.Drawing.Size(228, 102);
            this.moneyNumberToWordRichText2.TabIndex = 10003;
            this.moneyNumberToWordRichText2.Text = "";
            // 
            // OKButton
            // 
            this.OKButton.ActiveControl = null;
            this.OKButton.BackColor = System.Drawing.Color.Silver;
            this.OKButton.Enabled = false;
            this.OKButton.Location = new System.Drawing.Point(981, 385);
            this.OKButton.Margin = new System.Windows.Forms.Padding(0);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(33, 29);
            this.OKButton.TabIndex = 200001;
            this.OKButton.TileImage = global::alacakVerecekTakip.Properties.Resources.OK4;
            this.OKButton.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.OKButton.UseCustomBackColor = true;
            this.OKButton.UseSelectable = true;
            this.OKButton.UseTileImage = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.Silver;
            this.saveButton.Enabled = false;
            this.saveButton.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.saveButton.ForeColor = System.Drawing.Color.White;
            this.saveButton.Location = new System.Drawing.Point(750, 528);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(228, 41);
            this.saveButton.TabIndex = 200002;
            this.saveButton.Text = "Geliri Ekle";
            this.saveButton.UseCustomBackColor = true;
            this.saveButton.UseCustomForeColor = true;
            this.saveButton.UseSelectable = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // moneyTransactionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 750);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.moneyNumberToWordRichText1);
            this.Controls.Add(this.moneyValText1);
            this.Controls.Add(this.moneyNumberToWordRichText2);
            this.Controls.Add(this.inputMoneyVal);
            this.Controls.Add(this.moneyNumberToWordRichText);
            this.Controls.Add(this.moneyValText);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.moneyTypesText1);
            this.Controls.Add(this.bankTypesText1);
            this.Controls.Add(this.customerDebtListView);
            this.Controls.Add(this.connectSituation);
            this.Controls.Add(this.customerNameAndSurnameComboLabel);
            this.Controls.Add(this.customerDebtListCombo);
            this.Controls.Add(this.customerNameAndSurnameCombo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "moneyTransactionForm";
            this.Text = "Gelir Ekle";
            this.Load += new System.EventHandler(this.inComingMoneyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroLabel customerNameAndSurnameComboLabel;
        private MetroFramework.Controls.MetroComboBox customerNameAndSurnameCombo;
        private MetroFramework.Controls.MetroTile connectSituation;
        private MetroFramework.Controls.MetroComboBox customerDebtListCombo;
        private MetroFramework.Controls.MetroListView customerDebtListView;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox bankTypesText1;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox moneyTypesText1;
        private System.Windows.Forms.RichTextBox moneyNumberToWordRichText;
        private MetroFramework.Controls.MetroTextBox moneyValText;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private System.Windows.Forms.RichTextBox moneyNumberToWordRichText1;
        private MetroFramework.Controls.MetroTextBox moneyValText1;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private System.Windows.Forms.RichTextBox moneyNumberToWordRichText2;
        private MetroFramework.Controls.MetroTextBox inputMoneyVal;
        private MetroFramework.Controls.MetroTile OKButton;
        private MetroFramework.Controls.MetroButton saveButton;
    }
}