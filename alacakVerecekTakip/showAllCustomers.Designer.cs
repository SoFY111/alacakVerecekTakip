namespace alacakVerecekTakip
{
    partial class showAllCustomers
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
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.helpPictureBox = new System.Windows.Forms.PictureBox();
            this.customerListView = new MetroFramework.Controls.MetroListView();
            this.customersListViewLabel = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // helpPictureBox
            // 
            this.helpPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.helpPictureBox.Image = global::alacakVerecekTakip.Properties.Resources.help;
            this.helpPictureBox.Location = new System.Drawing.Point(1298, 3);
            this.helpPictureBox.Name = "helpPictureBox";
            this.helpPictureBox.Size = new System.Drawing.Size(25, 25);
            this.helpPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.helpPictureBox.TabIndex = 7;
            this.helpPictureBox.TabStop = false;
            // 
            // customerListView
            // 
            this.customerListView.AllowSorting = true;
            this.customerListView.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.customerListView.FullRowSelect = true;
            this.customerListView.Location = new System.Drawing.Point(27, 62);
            this.customerListView.MultiSelect = false;
            this.customerListView.Name = "customerListView";
            this.customerListView.OwnerDraw = true;
            this.customerListView.Size = new System.Drawing.Size(1272, 406);
            this.customerListView.TabIndex = 8;
            this.customerListView.UseCompatibleStateImageBehavior = false;
            this.customerListView.UseSelectable = true;
            this.customerListView.View = System.Windows.Forms.View.Details;
            // 
            // customersListViewLabel
            // 
            this.customersListViewLabel.AutoSize = true;
            this.customersListViewLabel.Location = new System.Drawing.Point(619, 39);
            this.customersListViewLabel.Name = "customersListViewLabel";
            this.customersListViewLabel.Size = new System.Drawing.Size(89, 19);
            this.customersListViewLabel.TabIndex = 9;
            this.customersListViewLabel.Text = "Müşteri Listesi";
            // 
            // showAllCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.customersListViewLabel);
            this.Controls.Add(this.customerListView);
            this.Controls.Add(this.helpPictureBox);
            this.Name = "showAllCustomers";
            this.Size = new System.Drawing.Size(1326, 509);
            this.Load += new System.EventHandler(this.showAllCustomers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private System.Windows.Forms.PictureBox helpPictureBox;
        private MetroFramework.Controls.MetroListView customerListView;
        private MetroFramework.Controls.MetroLabel customersListViewLabel;
    }
}
