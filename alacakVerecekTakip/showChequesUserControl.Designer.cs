namespace alacakVerecekTakip
{
    partial class showChequesUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.chequeLabel = new MetroFramework.Controls.MetroLabel();
            this.chequeListView = new MetroFramework.Controls.MetroListView();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.showGetRadio = new MetroFramework.Controls.MetroRadioButton();
            this.showPayedChequeRadio = new MetroFramework.Controls.MetroRadioButton();
            this.helpPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // chequeLabel
            // 
            this.chequeLabel.AutoSize = true;
            this.chequeLabel.Location = new System.Drawing.Point(612, 40);
            this.chequeLabel.Name = "chequeLabel";
            this.chequeLabel.Size = new System.Drawing.Size(100, 19);
            this.chequeLabel.TabIndex = 5;
            this.chequeLabel.Text = "Aldığınız Çekler";
            // 
            // chequeListView
            // 
            this.chequeListView.AllowSorting = true;
            this.chequeListView.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.chequeListView.FullRowSelect = true;
            this.chequeListView.Location = new System.Drawing.Point(27, 62);
            this.chequeListView.MultiSelect = false;
            this.chequeListView.Name = "chequeListView";
            this.chequeListView.OwnerDraw = true;
            this.chequeListView.Size = new System.Drawing.Size(1272, 406);
            this.chequeListView.TabIndex = 4;
            this.chequeListView.UseCompatibleStateImageBehavior = false;
            this.chequeListView.UseSelectable = true;
            this.chequeListView.View = System.Windows.Forms.View.Details;
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // showGetRadio
            // 
            this.showGetRadio.AutoSize = true;
            this.showGetRadio.Checked = true;
            this.showGetRadio.Location = new System.Drawing.Point(27, 10);
            this.showGetRadio.Name = "showGetRadio";
            this.showGetRadio.Size = new System.Drawing.Size(152, 15);
            this.showGetRadio.TabIndex = 7;
            this.showGetRadio.TabStop = true;
            this.showGetRadio.Text = "Alınan Çekleri Görüntüle";
            this.showGetRadio.UseSelectable = true;
            this.showGetRadio.CheckedChanged += new System.EventHandler(this.showGetRadio_CheckedChanged);
            // 
            // showPayedChequeRadio
            // 
            this.showPayedChequeRadio.AutoSize = true;
            this.showPayedChequeRadio.Location = new System.Drawing.Point(27, 31);
            this.showPayedChequeRadio.Name = "showPayedChequeRadio";
            this.showPayedChequeRadio.Size = new System.Drawing.Size(153, 15);
            this.showPayedChequeRadio.TabIndex = 7;
            this.showPayedChequeRadio.Text = "Verilen Çekleri Görüntüle";
            this.showPayedChequeRadio.UseSelectable = true;
            this.showPayedChequeRadio.CheckedChanged += new System.EventHandler(this.showPayedChequeRadio_CheckedChanged);
            // 
            // helpPictureBox
            // 
            this.helpPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.helpPictureBox.Image = global::alacakVerecekTakip.Properties.Resources.help;
            this.helpPictureBox.Location = new System.Drawing.Point(1274, 21);
            this.helpPictureBox.Name = "helpPictureBox";
            this.helpPictureBox.Size = new System.Drawing.Size(25, 25);
            this.helpPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.helpPictureBox.TabIndex = 6;
            this.helpPictureBox.TabStop = false;
            // 
            // showChequesUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.showPayedChequeRadio);
            this.Controls.Add(this.showGetRadio);
            this.Controls.Add(this.helpPictureBox);
            this.Controls.Add(this.chequeLabel);
            this.Controls.Add(this.chequeListView);
            this.Name = "showChequesUserControl";
            this.Size = new System.Drawing.Size(1326, 509);
            this.Load += new System.EventHandler(this.showChequesUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel chequeLabel;
        private MetroFramework.Controls.MetroListView chequeListView;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private System.Windows.Forms.PictureBox helpPictureBox;
        private MetroFramework.Controls.MetroRadioButton showPayedChequeRadio;
        private MetroFramework.Controls.MetroRadioButton showGetRadio;
    }
}
