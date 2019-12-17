namespace alacakVerecekTakip
{
    partial class moneyTypesButtonForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(moneyTypesButtonForm));
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.addButton = new MetroFramework.Controls.MetroTile();
            this.editButton = new MetroFramework.Controls.MetroTile();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.deleteButton = new MetroFramework.Controls.MetroTile();
            this.openMoneyExchangeRateFormButton = new MetroFramework.Controls.MetroTile();
            this.connectSituation = new MetroFramework.Controls.MetroTile();
            this.moneyTypesListView = new MetroFramework.Controls.MetroListView();
            this.cancelButton = new MetroFramework.Controls.MetroTile();
            this.OKButton = new MetroFramework.Controls.MetroTile();
            this.inputTextBox = new MetroFramework.Controls.MetroTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // addButton
            // 
            this.addButton.ActiveControl = null;
            this.addButton.Location = new System.Drawing.Point(71, 63);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(102, 40);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Ekle";
            this.addButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.addButton.UseSelectable = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // editButton
            // 
            this.editButton.ActiveControl = null;
            this.editButton.Location = new System.Drawing.Point(179, 63);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(102, 40);
            this.editButton.TabIndex = 3;
            this.editButton.Text = "Düzenle";
            this.editButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.editButton.UseSelectable = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(208, 155);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(149, 19);
            this.metroLabel1.TabIndex = 4;
            this.metroLabel1.Text = "MEVCUT PARA TÜRLERİ";
            // 
            // deleteButton
            // 
            this.deleteButton.ActiveControl = null;
            this.deleteButton.Location = new System.Drawing.Point(287, 63);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(102, 40);
            this.deleteButton.TabIndex = 5;
            this.deleteButton.Text = "Sil";
            this.deleteButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.deleteButton.UseSelectable = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // openMoneyExchangeRateFormButton
            // 
            this.openMoneyExchangeRateFormButton.ActiveControl = null;
            this.openMoneyExchangeRateFormButton.Location = new System.Drawing.Point(395, 63);
            this.openMoneyExchangeRateFormButton.Name = "openMoneyExchangeRateFormButton";
            this.openMoneyExchangeRateFormButton.Size = new System.Drawing.Size(102, 40);
            this.openMoneyExchangeRateFormButton.TabIndex = 6;
            this.openMoneyExchangeRateFormButton.Text = "Kur Dengesi";
            this.openMoneyExchangeRateFormButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.openMoneyExchangeRateFormButton.UseSelectable = true;
            this.openMoneyExchangeRateFormButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // connectSituation
            // 
            this.connectSituation.ActiveControl = null;
            this.connectSituation.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.connectSituation.ForeColor = System.Drawing.Color.Lime;
            this.connectSituation.Location = new System.Drawing.Point(12, 533);
            this.connectSituation.Name = "connectSituation";
            this.connectSituation.Size = new System.Drawing.Size(18, 18);
            this.connectSituation.TabIndex = 8;
            this.connectSituation.UseCustomBackColor = true;
            this.connectSituation.UseSelectable = true;
            // 
            // moneyTypesListView
            // 
            this.moneyTypesListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.moneyTypesListView.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.moneyTypesListView.AllowSorting = true;
            this.moneyTypesListView.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.moneyTypesListView.FullRowSelect = true;
            this.moneyTypesListView.HoverSelection = true;
            this.moneyTypesListView.Location = new System.Drawing.Point(158, 177);
            this.moneyTypesListView.MultiSelect = false;
            this.moneyTypesListView.Name = "moneyTypesListView";
            this.moneyTypesListView.OwnerDraw = true;
            this.moneyTypesListView.Size = new System.Drawing.Size(244, 343);
            this.moneyTypesListView.TabIndex = 9;
            this.moneyTypesListView.UseCompatibleStateImageBehavior = false;
            this.moneyTypesListView.UseSelectable = true;
            this.moneyTypesListView.View = System.Windows.Forms.View.Details;
            this.moneyTypesListView.Click += new System.EventHandler(this.moneyTypesListView_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.ActiveControl = null;
            this.cancelButton.BackColor = System.Drawing.Color.Silver;
            this.cancelButton.Enabled = false;
            this.cancelButton.Location = new System.Drawing.Point(464, 109);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(0);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(33, 28);
            this.cancelButton.TabIndex = 11;
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
            this.OKButton.Location = new System.Drawing.Point(419, 109);
            this.OKButton.Margin = new System.Windows.Forms.Padding(0);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(33, 28);
            this.OKButton.TabIndex = 10;
            this.OKButton.TileImage = global::alacakVerecekTakip.Properties.Resources.OK4;
            this.OKButton.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.OKButton.UseCustomBackColor = true;
            this.OKButton.UseSelectable = true;
            this.OKButton.UseTileImage = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
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
            this.inputTextBox.Location = new System.Drawing.Point(71, 109);
            this.inputTextBox.MaxLength = 32767;
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.PasswordChar = '\0';
            this.inputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.inputTextBox.SelectedText = "";
            this.inputTextBox.SelectionLength = 0;
            this.inputTextBox.SelectionStart = 0;
            this.inputTextBox.ShortcutsEnabled = true;
            this.inputTextBox.Size = new System.Drawing.Size(342, 28);
            this.inputTextBox.TabIndex = 7;
            this.inputTextBox.UseCustomBackColor = true;
            this.inputTextBox.UseCustomForeColor = true;
            this.inputTextBox.UseSelectable = true;
            this.inputTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.inputTextBox.WaterMarkFont = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            // 
            // moneyTypesButtonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 558);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.moneyTypesListView);
            this.Controls.Add(this.connectSituation);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.openMoneyExchangeRateFormButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.addButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "moneyTypesButtonForm";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "Para Türleri";
            this.Load += new System.EventHandler(this.moneyTypesButtonForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroTile editButton;
        private MetroFramework.Controls.MetroTile addButton;
        private MetroFramework.Controls.MetroTile openMoneyExchangeRateFormButton;
        private MetroFramework.Controls.MetroTile deleteButton;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTile connectSituation;
        private MetroFramework.Controls.MetroListView moneyTypesListView;
        private MetroFramework.Controls.MetroTile OKButton;
        private MetroFramework.Controls.MetroTile cancelButton;
        private MetroFramework.Controls.MetroTextBox inputTextBox;
    }
}