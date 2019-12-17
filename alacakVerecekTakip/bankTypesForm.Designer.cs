namespace alacakVerecekTakip
{
    partial class bankTypesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(bankTypesForm));
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.connectSituation = new MetroFramework.Controls.MetroTile();
            this.cancelButton = new MetroFramework.Controls.MetroTile();
            this.OKButton = new MetroFramework.Controls.MetroTile();
            this.bankTypesListView = new MetroFramework.Controls.MetroListView();
            this.inputTextBox = new MetroFramework.Controls.MetroTextBox();
            this.deleteBankTypeButton = new MetroFramework.Controls.MetroTile();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.editBankTypeButton = new MetroFramework.Controls.MetroTile();
            this.addBankTypeButton = new MetroFramework.Controls.MetroTile();
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
            this.connectSituation.Location = new System.Drawing.Point(23, 527);
            this.connectSituation.Name = "connectSituation";
            this.connectSituation.Size = new System.Drawing.Size(18, 18);
            this.connectSituation.TabIndex = 12;
            this.connectSituation.UseCustomBackColor = true;
            this.connectSituation.UseSelectable = true;
            // 
            // cancelButton
            // 
            this.cancelButton.ActiveControl = null;
            this.cancelButton.BackColor = System.Drawing.Color.Silver;
            this.cancelButton.Enabled = false;
            this.cancelButton.Location = new System.Drawing.Point(472, 118);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(0);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(33, 28);
            this.cancelButton.TabIndex = 21;
            this.cancelButton.TileImage = global::alacakVerecekTakip.Properties.Resources.cancel2;
            this.cancelButton.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cancelButton.UseCustomBackColor = true;
            this.cancelButton.UseSelectable = true;
            this.cancelButton.UseTileImage = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.ActiveControl = null;
            this.OKButton.BackColor = System.Drawing.Color.Silver;
            this.OKButton.Enabled = false;
            this.OKButton.Location = new System.Drawing.Point(427, 118);
            this.OKButton.Margin = new System.Windows.Forms.Padding(0);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(33, 28);
            this.OKButton.TabIndex = 20;
            this.OKButton.TileImage = global::alacakVerecekTakip.Properties.Resources.OK4;
            this.OKButton.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.OKButton.UseCustomBackColor = true;
            this.OKButton.UseSelectable = true;
            this.OKButton.UseTileImage = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // bankTypesListView
            // 
            this.bankTypesListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.bankTypesListView.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.bankTypesListView.AllowSorting = true;
            this.bankTypesListView.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.bankTypesListView.FullRowSelect = true;
            this.bankTypesListView.HoverSelection = true;
            this.bankTypesListView.Location = new System.Drawing.Point(148, 186);
            this.bankTypesListView.MultiSelect = false;
            this.bankTypesListView.Name = "bankTypesListView";
            this.bankTypesListView.OwnerDraw = true;
            this.bankTypesListView.Size = new System.Drawing.Size(273, 343);
            this.bankTypesListView.TabIndex = 19;
            this.bankTypesListView.UseCompatibleStateImageBehavior = false;
            this.bankTypesListView.UseSelectable = true;
            this.bankTypesListView.View = System.Windows.Forms.View.Details;
            this.bankTypesListView.SelectedIndexChanged += new System.EventHandler(this.bankTypesListView_SelectedIndexChanged);
            // 
            // inputTextBox
            // 
            this.inputTextBox.BackColor = System.Drawing.Color.Silver;
            // 
            // 
            // 
            this.inputTextBox.CustomButton.Image = null;
            this.inputTextBox.CustomButton.Location = new System.Drawing.Point(316, 2);
            this.inputTextBox.CustomButton.Name = "";
            this.inputTextBox.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.inputTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.inputTextBox.CustomButton.TabIndex = 1;
            this.inputTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.inputTextBox.CustomButton.UseSelectable = true;
            this.inputTextBox.CustomButton.Visible = false;
            this.inputTextBox.Enabled = false;
            this.inputTextBox.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.inputTextBox.Lines = new string[0];
            this.inputTextBox.Location = new System.Drawing.Point(79, 118);
            this.inputTextBox.MaxLength = 32767;
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.PasswordChar = '\0';
            this.inputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.inputTextBox.SelectedText = "";
            this.inputTextBox.SelectionLength = 0;
            this.inputTextBox.SelectionStart = 0;
            this.inputTextBox.ShortcutsEnabled = true;
            this.inputTextBox.Size = new System.Drawing.Size(342, 28);
            this.inputTextBox.TabIndex = 18;
            this.inputTextBox.UseCustomBackColor = true;
            this.inputTextBox.UseCustomForeColor = true;
            this.inputTextBox.UseSelectable = true;
            this.inputTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.inputTextBox.WaterMarkFont = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            // 
            // deleteBankTypeButton
            // 
            this.deleteBankTypeButton.ActiveControl = null;
            this.deleteBankTypeButton.Location = new System.Drawing.Point(367, 72);
            this.deleteBankTypeButton.Name = "deleteBankTypeButton";
            this.deleteBankTypeButton.Size = new System.Drawing.Size(138, 40);
            this.deleteBankTypeButton.TabIndex = 16;
            this.deleteBankTypeButton.Text = "Sil";
            this.deleteBankTypeButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.deleteBankTypeButton.UseSelectable = true;
            this.deleteBankTypeButton.Click += new System.EventHandler(this.deleteBankTypeButton_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(238, 164);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(104, 19);
            this.metroLabel1.TabIndex = 15;
            this.metroLabel1.Text = "BANKA TÜRLERİ";
            // 
            // editBankTypeButton
            // 
            this.editBankTypeButton.ActiveControl = null;
            this.editBankTypeButton.Location = new System.Drawing.Point(223, 72);
            this.editBankTypeButton.Name = "editBankTypeButton";
            this.editBankTypeButton.Size = new System.Drawing.Size(138, 40);
            this.editBankTypeButton.TabIndex = 14;
            this.editBankTypeButton.Text = "Düzenle";
            this.editBankTypeButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.editBankTypeButton.UseSelectable = true;
            this.editBankTypeButton.Click += new System.EventHandler(this.editBankTypeButton_Click);
            // 
            // addBankTypeButton
            // 
            this.addBankTypeButton.ActiveControl = null;
            this.addBankTypeButton.Location = new System.Drawing.Point(79, 72);
            this.addBankTypeButton.Name = "addBankTypeButton";
            this.addBankTypeButton.Size = new System.Drawing.Size(138, 40);
            this.addBankTypeButton.TabIndex = 13;
            this.addBankTypeButton.Text = "Ekle";
            this.addBankTypeButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.addBankTypeButton.UseSelectable = true;
            this.addBankTypeButton.Click += new System.EventHandler(this.addBankTypeButton_Click);
            // 
            // bankTypesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 558);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.bankTypesListView);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.deleteBankTypeButton);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.editBankTypeButton);
            this.Controls.Add(this.addBankTypeButton);
            this.Controls.Add(this.connectSituation);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "bankTypesForm";
            this.Text = "Banka Türleri";
            this.Load += new System.EventHandler(this.bankTypesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroTile connectSituation;
        private MetroFramework.Controls.MetroTile cancelButton;
        private MetroFramework.Controls.MetroTile OKButton;
        private MetroFramework.Controls.MetroListView bankTypesListView;
        private MetroFramework.Controls.MetroTextBox inputTextBox;
        private MetroFramework.Controls.MetroTile deleteBankTypeButton;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTile editBankTypeButton;
        private MetroFramework.Controls.MetroTile addBankTypeButton;
    }
}