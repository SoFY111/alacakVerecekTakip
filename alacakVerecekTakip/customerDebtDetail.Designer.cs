namespace alacakVerecekTakip
{
    partial class customerDebtDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(customerDebtDetail));
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.connectSituation = new MetroFramework.Controls.MetroTile();
            this.helpPictureBox = new System.Windows.Forms.PictureBox();
            this.customerReliabiltyLabel = new MetroFramework.Controls.MetroLabel();
            this.customerPhoneText = new System.Windows.Forms.MaskedTextBox();
            this.customerAdressRichText = new System.Windows.Forms.RichTextBox();
            this.customerAdressLabel = new MetroFramework.Controls.MetroLabel();
            this.customerMailLabel = new MetroFramework.Controls.MetroLabel();
            this.customerPhoneLabel = new MetroFramework.Controls.MetroLabel();
            this.customerSurnameLabel = new MetroFramework.Controls.MetroLabel();
            this.customerNameLabel = new MetroFramework.Controls.MetroLabel();
            this.customerMailText = new MetroFramework.Controls.MetroTextBox();
            this.customerSurnameText = new MetroFramework.Controls.MetroTextBox();
            this.customerNameText = new MetroFramework.Controls.MetroTextBox();
            this.customerIdText = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.customerReliabiltyText = new MetroFramework.Controls.MetroTextBox();
            this.customerTransactionListView = new MetroFramework.Controls.MetroListView();
            this.customerTransactionListViewLabel = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpPictureBox)).BeginInit();
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
            this.connectSituation.Location = new System.Drawing.Point(10, 732);
            this.connectSituation.Name = "connectSituation";
            this.connectSituation.Size = new System.Drawing.Size(18, 18);
            this.connectSituation.TabIndex = 13;
            this.connectSituation.UseCustomBackColor = true;
            this.connectSituation.UseSelectable = true;
            // 
            // helpPictureBox
            // 
            this.helpPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.helpPictureBox.Image = global::alacakVerecekTakip.Properties.Resources.help;
            this.helpPictureBox.Location = new System.Drawing.Point(176, 26);
            this.helpPictureBox.Name = "helpPictureBox";
            this.helpPictureBox.Size = new System.Drawing.Size(25, 25);
            this.helpPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.helpPictureBox.TabIndex = 12;
            this.helpPictureBox.TabStop = false;
            // 
            // customerReliabiltyLabel
            // 
            this.customerReliabiltyLabel.AutoSize = true;
            this.customerReliabiltyLabel.Location = new System.Drawing.Point(32, 409);
            this.customerReliabiltyLabel.Name = "customerReliabiltyLabel";
            this.customerReliabiltyLabel.Size = new System.Drawing.Size(172, 19);
            this.customerReliabiltyLabel.TabIndex = 20;
            this.customerReliabiltyLabel.Text = "Müşteri Güvenilirlik Durumu:";
            // 
            // customerPhoneText
            // 
            this.customerPhoneText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customerPhoneText.Enabled = false;
            this.customerPhoneText.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.customerPhoneText.Location = new System.Drawing.Point(204, 197);
            this.customerPhoneText.Mask = "+99 (999) 000-0000";
            this.customerPhoneText.Name = "customerPhoneText";
            this.customerPhoneText.ReadOnly = true;
            this.customerPhoneText.Size = new System.Drawing.Size(200, 27);
            this.customerPhoneText.TabIndex = 16;
            // 
            // customerAdressRichText
            // 
            this.customerAdressRichText.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.customerAdressRichText.Location = new System.Drawing.Point(204, 266);
            this.customerAdressRichText.Name = "customerAdressRichText";
            this.customerAdressRichText.ReadOnly = true;
            this.customerAdressRichText.Size = new System.Drawing.Size(200, 132);
            this.customerAdressRichText.TabIndex = 18;
            this.customerAdressRichText.Text = "";
            // 
            // customerAdressLabel
            // 
            this.customerAdressLabel.AutoSize = true;
            this.customerAdressLabel.Location = new System.Drawing.Point(112, 266);
            this.customerAdressLabel.Name = "customerAdressLabel";
            this.customerAdressLabel.Size = new System.Drawing.Size(93, 19);
            this.customerAdressLabel.TabIndex = 21;
            this.customerAdressLabel.Text = "Müşteri Adres:";
            // 
            // customerMailLabel
            // 
            this.customerMailLabel.AutoSize = true;
            this.customerMailLabel.Location = new System.Drawing.Point(120, 235);
            this.customerMailLabel.Name = "customerMailLabel";
            this.customerMailLabel.Size = new System.Drawing.Size(84, 19);
            this.customerMailLabel.TabIndex = 22;
            this.customerMailLabel.Text = "Müşteri Mail:";
            // 
            // customerPhoneLabel
            // 
            this.customerPhoneLabel.AutoSize = true;
            this.customerPhoneLabel.Location = new System.Drawing.Point(104, 200);
            this.customerPhoneLabel.Name = "customerPhoneLabel";
            this.customerPhoneLabel.Size = new System.Drawing.Size(100, 19);
            this.customerPhoneLabel.TabIndex = 23;
            this.customerPhoneLabel.Text = "Müşteri Telefon:";
            // 
            // customerSurnameLabel
            // 
            this.customerSurnameLabel.AutoSize = true;
            this.customerSurnameLabel.Location = new System.Drawing.Point(106, 165);
            this.customerSurnameLabel.Name = "customerSurnameLabel";
            this.customerSurnameLabel.Size = new System.Drawing.Size(98, 19);
            this.customerSurnameLabel.TabIndex = 24;
            this.customerSurnameLabel.Text = "Müşteri Soyadı:";
            // 
            // customerNameLabel
            // 
            this.customerNameLabel.AutoSize = true;
            this.customerNameLabel.Location = new System.Drawing.Point(125, 130);
            this.customerNameLabel.Name = "customerNameLabel";
            this.customerNameLabel.Size = new System.Drawing.Size(79, 19);
            this.customerNameLabel.TabIndex = 25;
            this.customerNameLabel.Text = "Müşteri Adı:";
            // 
            // customerMailText
            // 
            // 
            // 
            // 
            this.customerMailText.CustomButton.Image = null;
            this.customerMailText.CustomButton.Location = new System.Drawing.Point(172, 1);
            this.customerMailText.CustomButton.Name = "";
            this.customerMailText.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.customerMailText.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.customerMailText.CustomButton.TabIndex = 1;
            this.customerMailText.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.customerMailText.CustomButton.UseSelectable = true;
            this.customerMailText.CustomButton.Visible = false;
            this.customerMailText.Enabled = false;
            this.customerMailText.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.customerMailText.Lines = new string[0];
            this.customerMailText.Location = new System.Drawing.Point(204, 230);
            this.customerMailText.MaxLength = 32767;
            this.customerMailText.Name = "customerMailText";
            this.customerMailText.PasswordChar = '\0';
            this.customerMailText.ReadOnly = true;
            this.customerMailText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.customerMailText.SelectedText = "";
            this.customerMailText.SelectionLength = 0;
            this.customerMailText.SelectionStart = 0;
            this.customerMailText.ShortcutsEnabled = true;
            this.customerMailText.Size = new System.Drawing.Size(200, 29);
            this.customerMailText.TabIndex = 17;
            this.customerMailText.UseSelectable = true;
            this.customerMailText.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.customerMailText.WaterMarkFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            // 
            // customerSurnameText
            // 
            // 
            // 
            // 
            this.customerSurnameText.CustomButton.Image = null;
            this.customerSurnameText.CustomButton.Location = new System.Drawing.Point(172, 1);
            this.customerSurnameText.CustomButton.Name = "";
            this.customerSurnameText.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.customerSurnameText.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.customerSurnameText.CustomButton.TabIndex = 1;
            this.customerSurnameText.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.customerSurnameText.CustomButton.UseSelectable = true;
            this.customerSurnameText.CustomButton.Visible = false;
            this.customerSurnameText.Enabled = false;
            this.customerSurnameText.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.customerSurnameText.Lines = new string[0];
            this.customerSurnameText.Location = new System.Drawing.Point(204, 160);
            this.customerSurnameText.MaxLength = 32767;
            this.customerSurnameText.Name = "customerSurnameText";
            this.customerSurnameText.PasswordChar = '\0';
            this.customerSurnameText.ReadOnly = true;
            this.customerSurnameText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.customerSurnameText.SelectedText = "";
            this.customerSurnameText.SelectionLength = 0;
            this.customerSurnameText.SelectionStart = 0;
            this.customerSurnameText.ShortcutsEnabled = true;
            this.customerSurnameText.Size = new System.Drawing.Size(200, 29);
            this.customerSurnameText.TabIndex = 15;
            this.customerSurnameText.UseSelectable = true;
            this.customerSurnameText.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.customerSurnameText.WaterMarkFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            // 
            // customerNameText
            // 
            // 
            // 
            // 
            this.customerNameText.CustomButton.Image = null;
            this.customerNameText.CustomButton.Location = new System.Drawing.Point(172, 1);
            this.customerNameText.CustomButton.Name = "";
            this.customerNameText.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.customerNameText.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.customerNameText.CustomButton.TabIndex = 1;
            this.customerNameText.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.customerNameText.CustomButton.UseSelectable = true;
            this.customerNameText.CustomButton.Visible = false;
            this.customerNameText.Enabled = false;
            this.customerNameText.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.customerNameText.Lines = new string[0];
            this.customerNameText.Location = new System.Drawing.Point(204, 125);
            this.customerNameText.MaxLength = 32767;
            this.customerNameText.Name = "customerNameText";
            this.customerNameText.PasswordChar = '\0';
            this.customerNameText.ReadOnly = true;
            this.customerNameText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.customerNameText.SelectedText = "";
            this.customerNameText.SelectionLength = 0;
            this.customerNameText.SelectionStart = 0;
            this.customerNameText.ShortcutsEnabled = true;
            this.customerNameText.Size = new System.Drawing.Size(200, 29);
            this.customerNameText.TabIndex = 14;
            this.customerNameText.UseSelectable = true;
            this.customerNameText.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.customerNameText.WaterMarkFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            // 
            // customerIdText
            // 
            // 
            // 
            // 
            this.customerIdText.CustomButton.Image = null;
            this.customerIdText.CustomButton.Location = new System.Drawing.Point(172, 1);
            this.customerIdText.CustomButton.Name = "";
            this.customerIdText.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.customerIdText.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.customerIdText.CustomButton.TabIndex = 1;
            this.customerIdText.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.customerIdText.CustomButton.UseSelectable = true;
            this.customerIdText.CustomButton.Visible = false;
            this.customerIdText.Enabled = false;
            this.customerIdText.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.customerIdText.Lines = new string[0];
            this.customerIdText.Location = new System.Drawing.Point(204, 90);
            this.customerIdText.MaxLength = 32767;
            this.customerIdText.Name = "customerIdText";
            this.customerIdText.PasswordChar = '\0';
            this.customerIdText.ReadOnly = true;
            this.customerIdText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.customerIdText.SelectedText = "";
            this.customerIdText.SelectionLength = 0;
            this.customerIdText.SelectionStart = 0;
            this.customerIdText.ShortcutsEnabled = true;
            this.customerIdText.Size = new System.Drawing.Size(200, 29);
            this.customerIdText.TabIndex = 14;
            this.customerIdText.UseSelectable = true;
            this.customerIdText.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.customerIdText.WaterMarkFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(134, 95);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(70, 19);
            this.metroLabel1.TabIndex = 25;
            this.metroLabel1.Text = "Müşteri Id:";
            // 
            // customerReliabiltyText
            // 
            // 
            // 
            // 
            this.customerReliabiltyText.CustomButton.Image = null;
            this.customerReliabiltyText.CustomButton.Location = new System.Drawing.Point(172, 1);
            this.customerReliabiltyText.CustomButton.Name = "";
            this.customerReliabiltyText.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.customerReliabiltyText.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.customerReliabiltyText.CustomButton.TabIndex = 1;
            this.customerReliabiltyText.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.customerReliabiltyText.CustomButton.UseSelectable = true;
            this.customerReliabiltyText.CustomButton.Visible = false;
            this.customerReliabiltyText.Enabled = false;
            this.customerReliabiltyText.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.customerReliabiltyText.Lines = new string[0];
            this.customerReliabiltyText.Location = new System.Drawing.Point(204, 404);
            this.customerReliabiltyText.MaxLength = 32767;
            this.customerReliabiltyText.Name = "customerReliabiltyText";
            this.customerReliabiltyText.PasswordChar = '\0';
            this.customerReliabiltyText.ReadOnly = true;
            this.customerReliabiltyText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.customerReliabiltyText.SelectedText = "";
            this.customerReliabiltyText.SelectionLength = 0;
            this.customerReliabiltyText.SelectionStart = 0;
            this.customerReliabiltyText.ShortcutsEnabled = true;
            this.customerReliabiltyText.Size = new System.Drawing.Size(200, 29);
            this.customerReliabiltyText.TabIndex = 17;
            this.customerReliabiltyText.UseSelectable = true;
            this.customerReliabiltyText.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.customerReliabiltyText.WaterMarkFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            // 
            // customerTransactionListView
            // 
            this.customerTransactionListView.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.customerTransactionListView.FullRowSelect = true;
            this.customerTransactionListView.Location = new System.Drawing.Point(463, 90);
            this.customerTransactionListView.Name = "customerTransactionListView";
            this.customerTransactionListView.OwnerDraw = true;
            this.customerTransactionListView.Size = new System.Drawing.Size(736, 315);
            this.customerTransactionListView.TabIndex = 26;
            this.customerTransactionListView.UseCompatibleStateImageBehavior = false;
            this.customerTransactionListView.UseSelectable = true;
            // 
            // customerTransactionListViewLabel
            // 
            this.customerTransactionListViewLabel.AutoSize = true;
            this.customerTransactionListViewLabel.Location = new System.Drawing.Point(463, 411);
            this.customerTransactionListViewLabel.Name = "customerTransactionListViewLabel";
            this.customerTransactionListViewLabel.Size = new System.Drawing.Size(0, 0);
            this.customerTransactionListViewLabel.TabIndex = 27;
            // 
            // customerDebtDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 760);
            this.Controls.Add(this.customerTransactionListViewLabel);
            this.Controls.Add(this.customerTransactionListView);
            this.Controls.Add(this.customerReliabiltyLabel);
            this.Controls.Add(this.customerPhoneText);
            this.Controls.Add(this.customerAdressRichText);
            this.Controls.Add(this.customerAdressLabel);
            this.Controls.Add(this.customerMailLabel);
            this.Controls.Add(this.customerPhoneLabel);
            this.Controls.Add(this.customerSurnameLabel);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.customerNameLabel);
            this.Controls.Add(this.customerReliabiltyText);
            this.Controls.Add(this.customerMailText);
            this.Controls.Add(this.customerSurnameText);
            this.Controls.Add(this.customerIdText);
            this.Controls.Add(this.customerNameText);
            this.Controls.Add(this.connectSituation);
            this.Controls.Add(this.helpPictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "customerDebtDetail";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "Borç Ayrıntıları";
            this.Load += new System.EventHandler(this.customerDebtDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroTile connectSituation;
        private System.Windows.Forms.PictureBox helpPictureBox;
        private MetroFramework.Controls.MetroLabel customerReliabiltyLabel;
        private System.Windows.Forms.MaskedTextBox customerPhoneText;
        private System.Windows.Forms.RichTextBox customerAdressRichText;
        private MetroFramework.Controls.MetroLabel customerAdressLabel;
        private MetroFramework.Controls.MetroLabel customerMailLabel;
        private MetroFramework.Controls.MetroLabel customerPhoneLabel;
        private MetroFramework.Controls.MetroLabel customerSurnameLabel;
        private MetroFramework.Controls.MetroLabel customerNameLabel;
        private MetroFramework.Controls.MetroTextBox customerMailText;
        private MetroFramework.Controls.MetroTextBox customerSurnameText;
        private MetroFramework.Controls.MetroTextBox customerNameText;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox customerIdText;
        private MetroFramework.Controls.MetroTextBox customerReliabiltyText;
        private MetroFramework.Controls.MetroLabel customerTransactionListViewLabel;
        private MetroFramework.Controls.MetroListView customerTransactionListView;
    }
}