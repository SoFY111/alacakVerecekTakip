namespace alacakVerecekTakip
{
    partial class editInstallmentCountUserControl
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
            this.showInstallmentCountListView = new MetroFramework.Controls.MetroListView();
            this.inputTextBox = new MetroFramework.Controls.MetroTextBox();
            this.deleteButton = new MetroFramework.Controls.MetroTile();
            this.addButton = new MetroFramework.Controls.MetroTile();
            this.cancelButton = new MetroFramework.Controls.MetroTile();
            this.OKButton = new MetroFramework.Controls.MetroTile();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // showInstallmentCountListView
            // 
            this.showInstallmentCountListView.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.showInstallmentCountListView.FullRowSelect = true;
            this.showInstallmentCountListView.Location = new System.Drawing.Point(136, 111);
            this.showInstallmentCountListView.Name = "showInstallmentCountListView";
            this.showInstallmentCountListView.OwnerDraw = true;
            this.showInstallmentCountListView.Size = new System.Drawing.Size(286, 197);
            this.showInstallmentCountListView.TabIndex = 0;
            this.showInstallmentCountListView.UseCompatibleStateImageBehavior = false;
            this.showInstallmentCountListView.UseSelectable = true;
            // 
            // inputTextBox
            // 
            this.inputTextBox.BackColor = System.Drawing.Color.Silver;
            // 
            // 
            // 
            this.inputTextBox.CustomButton.Image = null;
            this.inputTextBox.CustomButton.Location = new System.Drawing.Point(184, 2);
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
            this.inputTextBox.Location = new System.Drawing.Point(136, 80);
            this.inputTextBox.MaxLength = 32767;
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.PasswordChar = '\0';
            this.inputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.inputTextBox.SelectedText = "";
            this.inputTextBox.SelectionLength = 0;
            this.inputTextBox.SelectionStart = 0;
            this.inputTextBox.ShortcutsEnabled = true;
            this.inputTextBox.Size = new System.Drawing.Size(210, 28);
            this.inputTextBox.TabIndex = 8;
            this.inputTextBox.UseCustomBackColor = true;
            this.inputTextBox.UseCustomForeColor = true;
            this.inputTextBox.UseSelectable = true;
            this.inputTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.inputTextBox.WaterMarkFont = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.inputTextBox.TextChanged += new System.EventHandler(this.inputTextBox_TextChanged);
            this.inputTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputTextBox_KeyPress);
            // 
            // deleteButton
            // 
            this.deleteButton.ActiveControl = null;
            this.deleteButton.Location = new System.Drawing.Point(244, 34);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(102, 40);
            this.deleteButton.TabIndex = 10;
            this.deleteButton.Text = "Sil";
            this.deleteButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.deleteButton.UseSelectable = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // addButton
            // 
            this.addButton.ActiveControl = null;
            this.addButton.Location = new System.Drawing.Point(136, 34);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(102, 40);
            this.addButton.TabIndex = 9;
            this.addButton.Text = "Ekle";
            this.addButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.addButton.UseSelectable = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.ActiveControl = null;
            this.cancelButton.BackColor = System.Drawing.Color.Silver;
            this.cancelButton.Enabled = false;
            this.cancelButton.Location = new System.Drawing.Point(389, 80);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(0);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(33, 28);
            this.cancelButton.TabIndex = 13;
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
            this.OKButton.Location = new System.Drawing.Point(349, 80);
            this.OKButton.Margin = new System.Windows.Forms.Padding(0);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(33, 28);
            this.OKButton.TabIndex = 12;
            this.OKButton.TileImage = global::alacakVerecekTakip.Properties.Resources.OK4;
            this.OKButton.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.OKButton.UseCustomBackColor = true;
            this.OKButton.UseSelectable = true;
            this.OKButton.UseTileImage = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // editInstallmentCountUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.showInstallmentCountListView);
            this.Name = "editInstallmentCountUserControl";
            this.Size = new System.Drawing.Size(550, 370);
            this.Load += new System.EventHandler(this.editInstallmentCountUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroListView showInstallmentCountListView;
        private MetroFramework.Controls.MetroTextBox inputTextBox;
        private MetroFramework.Controls.MetroTile deleteButton;
        private MetroFramework.Controls.MetroTile addButton;
        private MetroFramework.Controls.MetroTile cancelButton;
        private MetroFramework.Controls.MetroTile OKButton;
    }
}
