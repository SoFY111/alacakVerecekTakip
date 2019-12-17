namespace alacakVerecekTakip
{
    partial class allHistoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(allHistoryForm));
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.historyListView = new MetroFramework.Controls.MetroListView();
            this.connectSituation = new MetroFramework.Controls.MetroTile();
            this.ortderRransactionsLabel = new MetroFramework.Controls.MetroLabel();
            this.orderTransactionsCombo = new MetroFramework.Controls.MetroComboBox();
            this.headerLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // historyListView
            // 
            this.historyListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.historyListView.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.historyListView.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.historyListView.FullRowSelect = true;
            this.historyListView.HoverSelection = true;
            this.historyListView.Location = new System.Drawing.Point(57, 116);
            this.historyListView.MultiSelect = false;
            this.historyListView.Name = "historyListView";
            this.historyListView.OwnerDraw = true;
            this.historyListView.Size = new System.Drawing.Size(588, 428);
            this.historyListView.TabIndex = 10;
            this.historyListView.UseCompatibleStateImageBehavior = false;
            this.historyListView.UseSelectable = true;
            this.historyListView.View = System.Windows.Forms.View.Details;
            this.historyListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.historyListView_MouseDoubleClick);
            // 
            // connectSituation
            // 
            this.connectSituation.ActiveControl = null;
            this.connectSituation.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.connectSituation.ForeColor = System.Drawing.Color.Lime;
            this.connectSituation.Location = new System.Drawing.Point(12, 555);
            this.connectSituation.Name = "connectSituation";
            this.connectSituation.Size = new System.Drawing.Size(18, 18);
            this.connectSituation.TabIndex = 11;
            this.connectSituation.UseCustomBackColor = true;
            this.connectSituation.UseSelectable = true;
            // 
            // ortderRransactionsLabel
            // 
            this.ortderRransactionsLabel.AutoSize = true;
            this.ortderRransactionsLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.ortderRransactionsLabel.Location = new System.Drawing.Point(57, 82);
            this.ortderRransactionsLabel.Name = "ortderRransactionsLabel";
            this.ortderRransactionsLabel.Size = new System.Drawing.Size(156, 25);
            this.ortderRransactionsLabel.TabIndex = 12;
            this.ortderRransactionsLabel.Text = "İşlem\'e Göre Sırala:";
            // 
            // orderTransactionsCombo
            // 
            this.orderTransactionsCombo.FormattingEnabled = true;
            this.orderTransactionsCombo.ItemHeight = 23;
            this.orderTransactionsCombo.Items.AddRange(new object[] {
            "Hepsi"});
            this.orderTransactionsCombo.Location = new System.Drawing.Point(215, 81);
            this.orderTransactionsCombo.Name = "orderTransactionsCombo";
            this.orderTransactionsCombo.Size = new System.Drawing.Size(214, 29);
            this.orderTransactionsCombo.TabIndex = 13;
            this.orderTransactionsCombo.UseSelectable = true;
            this.orderTransactionsCombo.SelectedIndexChanged += new System.EventHandler(this.orderTransactionsCombo_SelectedIndexChanged);
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.headerLabel.ForeColor = System.Drawing.Color.DimGray;
            this.headerLabel.Location = new System.Drawing.Point(179, 20);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(177, 32);
            this.headerLabel.TabIndex = 15;
            this.headerLabel.Text = "Cari İşlemler";
            // 
            // allHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 582);
            this.Controls.Add(this.headerLabel);
            this.Controls.Add(this.orderTransactionsCombo);
            this.Controls.Add(this.ortderRransactionsLabel);
            this.Controls.Add(this.connectSituation);
            this.Controls.Add(this.historyListView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "allHistoryForm";
            this.Text = "İşlem Geçmişi -";
            this.Load += new System.EventHandler(this.allHistoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroListView historyListView;
        private MetroFramework.Controls.MetroTile connectSituation;
        private MetroFramework.Controls.MetroComboBox orderTransactionsCombo;
        private MetroFramework.Controls.MetroLabel ortderRransactionsLabel;
        private System.Windows.Forms.Label headerLabel;
    }
}