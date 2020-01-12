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
            this.chequeListView = new MetroFramework.Controls.MetroListView();
            this.addChequeButton = new MetroFramework.Controls.MetroTile();
            this.drawChequeButton = new MetroFramework.Controls.MetroTile();
            this.connectSituation = new MetroFramework.Controls.MetroTile();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // chequeListView
            // 
            this.chequeListView.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.chequeListView.FullRowSelect = true;
            this.chequeListView.Location = new System.Drawing.Point(53, 135);
            this.chequeListView.Name = "chequeListView";
            this.chequeListView.OwnerDraw = true;
            this.chequeListView.Size = new System.Drawing.Size(1272, 422);
            this.chequeListView.TabIndex = 1;
            this.chequeListView.UseCompatibleStateImageBehavior = false;
            this.chequeListView.UseSelectable = true;
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
            // connectSituation
            // 
            this.connectSituation.ActiveControl = null;
            this.connectSituation.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.connectSituation.ForeColor = System.Drawing.Color.Lime;
            this.connectSituation.Location = new System.Drawing.Point(21, 577);
            this.connectSituation.Name = "connectSituation";
            this.connectSituation.Size = new System.Drawing.Size(18, 18);
            this.connectSituation.TabIndex = 13;
            this.connectSituation.UseCustomBackColor = true;
            this.connectSituation.UseSelectable = true;
            // 
            // chequeTransactionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1388, 606);
            this.Controls.Add(this.connectSituation);
            this.Controls.Add(this.chequeListView);
            this.Controls.Add(this.drawChequeButton);
            this.Controls.Add(this.addChequeButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "chequeTransactionsForm";
            this.Resizable = false;
            this.Text = "Çek İşlemleri";
            this.Load += new System.EventHandler(this.chequeTransactions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroTile addChequeButton;
        private MetroFramework.Controls.MetroListView chequeListView;
        private MetroFramework.Controls.MetroTile drawChequeButton;
        private MetroFramework.Controls.MetroTile connectSituation;
    }
}