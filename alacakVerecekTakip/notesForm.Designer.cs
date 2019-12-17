namespace alacakVerecekTakip
{
    partial class notesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(notesForm));
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.connectSituation = new MetroFramework.Controls.MetroTile();
            this.notesListView = new MetroFramework.Controls.MetroListView();
            this.deleteButton = new MetroFramework.Controls.MetroTile();
            this.titleLabel = new MetroFramework.Controls.MetroLabel();
            this.editButton = new MetroFramework.Controls.MetroTile();
            this.addButton = new MetroFramework.Controls.MetroTile();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
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
            this.connectSituation.Location = new System.Drawing.Point(13, 535);
            this.connectSituation.Name = "connectSituation";
            this.connectSituation.Size = new System.Drawing.Size(18, 18);
            this.connectSituation.TabIndex = 11;
            this.connectSituation.UseCustomBackColor = true;
            this.connectSituation.UseSelectable = true;
            // 
            // notesListView
            // 
            this.notesListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.notesListView.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.notesListView.AllowSorting = true;
            this.notesListView.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.notesListView.FullRowSelect = true;
            this.notesListView.HoverSelection = true;
            this.notesListView.Location = new System.Drawing.Point(86, 142);
            this.notesListView.MultiSelect = false;
            this.notesListView.Name = "notesListView";
            this.notesListView.OwnerDraw = true;
            this.notesListView.Size = new System.Drawing.Size(318, 377);
            this.notesListView.TabIndex = 18;
            this.notesListView.UseCompatibleStateImageBehavior = false;
            this.notesListView.UseSelectable = true;
            this.notesListView.View = System.Windows.Forms.View.Details;
            this.notesListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notesListView_MouseDoubleClick);
            // 
            // deleteButton
            // 
            this.deleteButton.ActiveControl = null;
            this.deleteButton.Location = new System.Drawing.Point(302, 77);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(102, 40);
            this.deleteButton.TabIndex = 15;
            this.deleteButton.Text = "Sil";
            this.deleteButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.deleteButton.UseSelectable = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.titleLabel.Location = new System.Drawing.Point(215, 120);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(60, 19);
            this.titleLabel.TabIndex = 14;
            this.titleLabel.Text = "NOTLAR";
            // 
            // editButton
            // 
            this.editButton.ActiveControl = null;
            this.editButton.Location = new System.Drawing.Point(194, 77);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(102, 40);
            this.editButton.TabIndex = 13;
            this.editButton.Text = "Düzenle";
            this.editButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.editButton.UseSelectable = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // addButton
            // 
            this.addButton.ActiveControl = null;
            this.addButton.Location = new System.Drawing.Point(86, 77);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(102, 40);
            this.addButton.TabIndex = 12;
            this.addButton.Text = "Ekle";
            this.addButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.addButton.UseSelectable = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // notesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 564);
            this.Controls.Add(this.notesListView);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.connectSituation);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "notesForm";
            this.Resizable = false;
            this.Text = "Notlar";
            this.Load += new System.EventHandler(this.notes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroTile connectSituation;
        private MetroFramework.Controls.MetroListView notesListView;
        private MetroFramework.Controls.MetroTile deleteButton;
        private MetroFramework.Controls.MetroLabel titleLabel;
        private MetroFramework.Controls.MetroTile editButton;
        private MetroFramework.Controls.MetroTile addButton;
    }
}