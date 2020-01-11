namespace alacakVerecekTakip
{
    partial class showCurrenctAccountsUserControl
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
            this.customersListViewLabel = new MetroFramework.Controls.MetroLabel();
            this.currencyAccountListView = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.helpPictureBox.TabIndex = 8;
            this.helpPictureBox.TabStop = false;
            // 
            // customersListViewLabel
            // 
            this.customersListViewLabel.AutoSize = true;
            this.customersListViewLabel.Location = new System.Drawing.Point(618, 40);
            this.customersListViewLabel.Name = "customersListViewLabel";
            this.customersListViewLabel.Size = new System.Drawing.Size(88, 19);
            this.customersListViewLabel.TabIndex = 10;
            this.customersListViewLabel.Text = "Cari Hesaplar";
            // 
            // currencyAccountListView
            // 
            this.currencyAccountListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.currencyAccountListView.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.currencyAccountListView.FullRowSelect = true;
            this.currencyAccountListView.GridLines = true;
            this.currencyAccountListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.currencyAccountListView.HideSelection = false;
            this.currencyAccountListView.Location = new System.Drawing.Point(33, 62);
            this.currencyAccountListView.MultiSelect = false;
            this.currencyAccountListView.Name = "currencyAccountListView";
            this.currencyAccountListView.Size = new System.Drawing.Size(1256, 426);
            this.currencyAccountListView.TabIndex = 13;
            this.currencyAccountListView.UseCompatibleStateImageBehavior = false;
            this.currencyAccountListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "C";
            this.columnHeader3.Width = 10;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Para Türü";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader4.Width = 623;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Para Miktarı";
            this.columnHeader5.Width = 623;
            // 
            // showCurrenctAccountsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.currencyAccountListView);
            this.Controls.Add(this.customersListViewLabel);
            this.Controls.Add(this.helpPictureBox);
            this.Name = "showCurrenctAccountsUserControl";
            this.Size = new System.Drawing.Size(1326, 509);
            this.Load += new System.EventHandler(this.showCurrenctAccountsUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private System.Windows.Forms.PictureBox helpPictureBox;
        private MetroFramework.Controls.MetroLabel customersListViewLabel;
        private System.Windows.Forms.ListView currencyAccountListView;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}
