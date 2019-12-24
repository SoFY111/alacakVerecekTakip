namespace alacakVerecekTakip
{
    partial class inComingMoneyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(inComingMoneyForm));
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.customerNameAndSurnameComboLabel = new MetroFramework.Controls.MetroLabel();
            this.customerNameAndSurnameCombo = new MetroFramework.Controls.MetroComboBox();
            this.connectSituation = new MetroFramework.Controls.MetroTile();
            this.helpPictureBox = new System.Windows.Forms.PictureBox();
            this.customerDebtListCombo = new MetroFramework.Controls.MetroComboBox();
            this.customerDebtListComboLabel = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // customerNameAndSurnameComboLabel
            // 
            this.customerNameAndSurnameComboLabel.AutoSize = true;
            this.customerNameAndSurnameComboLabel.Location = new System.Drawing.Point(101, 95);
            this.customerNameAndSurnameComboLabel.Name = "customerNameAndSurnameComboLabel";
            this.customerNameAndSurnameComboLabel.Size = new System.Drawing.Size(122, 19);
            this.customerNameAndSurnameComboLabel.TabIndex = 0;
            this.customerNameAndSurnameComboLabel.Text = "Para Veren Müşteri:";
            // 
            // customerNameAndSurnameCombo
            // 
            this.customerNameAndSurnameCombo.FormattingEnabled = true;
            this.customerNameAndSurnameCombo.ItemHeight = 23;
            this.customerNameAndSurnameCombo.Location = new System.Drawing.Point(223, 91);
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
            this.connectSituation.Location = new System.Drawing.Point(201, 36);
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
            this.helpPictureBox.Location = new System.Drawing.Point(133, 25);
            this.helpPictureBox.Name = "helpPictureBox";
            this.helpPictureBox.Size = new System.Drawing.Size(25, 25);
            this.helpPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.helpPictureBox.TabIndex = 12;
            this.helpPictureBox.TabStop = false;
            // 
            // customerDebtListCombo
            // 
            this.customerDebtListCombo.FormattingEnabled = true;
            this.customerDebtListCombo.ItemHeight = 23;
            this.customerDebtListCombo.Location = new System.Drawing.Point(223, 126);
            this.customerDebtListCombo.Name = "customerDebtListCombo";
            this.customerDebtListCombo.Size = new System.Drawing.Size(228, 29);
            this.customerDebtListCombo.TabIndex = 1;
            this.customerDebtListCombo.UseSelectable = true;
            // 
            // customerDebtListComboLabel
            // 
            this.customerDebtListComboLabel.AutoSize = true;
            this.customerDebtListComboLabel.Location = new System.Drawing.Point(101, 130);
            this.customerDebtListComboLabel.Name = "customerDebtListComboLabel";
            this.customerDebtListComboLabel.Size = new System.Drawing.Size(14, 19);
            this.customerDebtListComboLabel.TabIndex = 0;
            this.customerDebtListComboLabel.Text = "s";
            // 
            // inComingMoneyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 695);
            this.Controls.Add(this.connectSituation);
            this.Controls.Add(this.helpPictureBox);
            this.Controls.Add(this.customerDebtListComboLabel);
            this.Controls.Add(this.customerNameAndSurnameComboLabel);
            this.Controls.Add(this.customerDebtListCombo);
            this.Controls.Add(this.customerNameAndSurnameCombo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "inComingMoneyForm";
            this.Text = "Gelir Ekle";
            this.Load += new System.EventHandler(this.inComingMoneyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroLabel customerNameAndSurnameComboLabel;
        private MetroFramework.Controls.MetroComboBox customerNameAndSurnameCombo;
        private MetroFramework.Controls.MetroTile connectSituation;
        private System.Windows.Forms.PictureBox helpPictureBox;
        private MetroFramework.Controls.MetroLabel customerDebtListComboLabel;
        private MetroFramework.Controls.MetroComboBox customerDebtListCombo;
    }
}