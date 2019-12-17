namespace alacakVerecekTakip
{
    partial class chequeTransactionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(chequeTransactionsForm));
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroListView1 = new MetroFramework.Controls.MetroListView();
            this.metroTile2 = new MetroFramework.Controls.MetroTile();
            this.addChequeButton = new MetroFramework.Controls.MetroTile();
            this.helpPictureBox = new System.Windows.Forms.PictureBox();
            this.drawChequeButton = new MetroFramework.Controls.MetroTile();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // metroListView1
            // 
            this.metroListView1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.metroListView1.FullRowSelect = true;
            this.metroListView1.Location = new System.Drawing.Point(53, 135);
            this.metroListView1.Name = "metroListView1";
            this.metroListView1.OwnerDraw = true;
            this.metroListView1.Size = new System.Drawing.Size(433, 274);
            this.metroListView1.TabIndex = 1;
            this.metroListView1.UseCompatibleStateImageBehavior = false;
            this.metroListView1.UseSelectable = true;
            // 
            // metroTile2
            // 
            this.metroTile2.ActiveControl = null;
            this.metroTile2.Location = new System.Drawing.Point(300, 78);
            this.metroTile2.Name = "metroTile2";
            this.metroTile2.Size = new System.Drawing.Size(186, 51);
            this.metroTile2.TabIndex = 2;
            this.metroTile2.Text = "Çek İle Ödeme Yap";
            this.metroTile2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroTile2.TileImage = global::alacakVerecekTakip.Properties.Resources.dischargeDebt;
            this.metroTile2.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroTile2.UseSelectable = true;
            this.metroTile2.UseTileImage = true;
            // 
            // addChequeButton
            // 
            this.addChequeButton.ActiveControl = null;
            this.addChequeButton.Location = new System.Drawing.Point(181, 78);
            this.addChequeButton.Name = "addChequeButton";
            this.addChequeButton.Size = new System.Drawing.Size(113, 51);
            this.addChequeButton.TabIndex = 0;
            this.addChequeButton.Text = "Çek Al";
            this.addChequeButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addChequeButton.TileImage = global::alacakVerecekTakip.Properties.Resources.addIcon;
            this.addChequeButton.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addChequeButton.UseSelectable = true;
            this.addChequeButton.UseTileImage = true;
            this.addChequeButton.Click += new System.EventHandler(this.addChequeButton_Click);
            // 
            // helpPictureBox
            // 
            this.helpPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.helpPictureBox.Image = global::alacakVerecekTakip.Properties.Resources.help;
            this.helpPictureBox.Location = new System.Drawing.Point(168, 26);
            this.helpPictureBox.Name = "helpPictureBox";
            this.helpPictureBox.Size = new System.Drawing.Size(25, 25);
            this.helpPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.helpPictureBox.TabIndex = 3;
            this.helpPictureBox.TabStop = false;
            // 
            // drawChequeButton
            // 
            this.drawChequeButton.ActiveControl = null;
            this.drawChequeButton.Location = new System.Drawing.Point(53, 78);
            this.drawChequeButton.Name = "drawChequeButton";
            this.drawChequeButton.Size = new System.Drawing.Size(122, 51);
            this.drawChequeButton.TabIndex = 0;
            this.drawChequeButton.Text = "Çek Ver";
            this.drawChequeButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.drawChequeButton.TileImage = global::alacakVerecekTakip.Properties.Resources.addIcon;
            this.drawChequeButton.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.drawChequeButton.UseSelectable = true;
            this.drawChequeButton.UseTileImage = true;
            this.drawChequeButton.Click += new System.EventHandler(this.drawChequeButton_Click);
            // 
            // chequeTransactionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 445);
            this.Controls.Add(this.helpPictureBox);
            this.Controls.Add(this.metroTile2);
            this.Controls.Add(this.metroListView1);
            this.Controls.Add(this.drawChequeButton);
            this.Controls.Add(this.addChequeButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "chequeTransactionsForm";
            this.Resizable = false;
            this.Text = "Çek İşlemleri";
            this.Load += new System.EventHandler(this.chequeTransactions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroTile addChequeButton;
        private MetroFramework.Controls.MetroTile metroTile2;
        private MetroFramework.Controls.MetroListView metroListView1;
        private System.Windows.Forms.PictureBox helpPictureBox;
        private MetroFramework.Controls.MetroTile drawChequeButton;
    }
}