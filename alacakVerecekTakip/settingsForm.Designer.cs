namespace alacakVerecekTakip
{
    partial class settingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(settingsForm));
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.otherTransactionsSeprator = new ns1.BunifuSeparator();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.headerLabel = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.themeButton = new ns1.BunifuFlatButton();
            this.zeroButton = new ns1.BunifuFlatButton();
            this.installmentButton = new ns1.BunifuFlatButton();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.menuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // otherTransactionsSeprator
            // 
            this.otherTransactionsSeprator.BackColor = System.Drawing.Color.Transparent;
            this.otherTransactionsSeprator.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.otherTransactionsSeprator.LineThickness = 500;
            this.otherTransactionsSeprator.Location = new System.Drawing.Point(224, -1);
            this.otherTransactionsSeprator.Margin = new System.Windows.Forms.Padding(4);
            this.otherTransactionsSeprator.Name = "otherTransactionsSeprator";
            this.otherTransactionsSeprator.Size = new System.Drawing.Size(1, 446);
            this.otherTransactionsSeprator.TabIndex = 15;
            this.otherTransactionsSeprator.Transparency = 255;
            this.otherTransactionsSeprator.Vertical = false;
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.menuPanel.Controls.Add(this.themeButton);
            this.menuPanel.Controls.Add(this.zeroButton);
            this.menuPanel.Controls.Add(this.installmentButton);
            this.menuPanel.Controls.Add(this.headerLabel);
            this.menuPanel.Controls.Add(this.otherTransactionsSeprator);
            this.menuPanel.Location = new System.Drawing.Point(-1, 5);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(225, 445);
            this.menuPanel.TabIndex = 16;
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Century Gothic", 16F);
            this.headerLabel.Location = new System.Drawing.Point(24, 23);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(92, 25);
            this.headerLabel.TabIndex = 17;
            this.headerLabel.Text = "Ayarlar";
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.mainPanel.Location = new System.Drawing.Point(230, 60);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(550, 370);
            this.mainPanel.TabIndex = 17;
            // 
            // themeButton
            // 
            this.themeButton.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(219)))));
            this.themeButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.themeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.themeButton.BorderRadius = 0;
            this.themeButton.ButtonText = "Tema";
            this.themeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.themeButton.DisabledColor = System.Drawing.Color.Gray;
            this.themeButton.ForeColor = System.Drawing.Color.White;
            this.themeButton.Iconcolor = System.Drawing.Color.Transparent;
            this.themeButton.Iconimage = ((System.Drawing.Image)(resources.GetObject("themeButton.Iconimage")));
            this.themeButton.Iconimage_right = null;
            this.themeButton.Iconimage_right_Selected = null;
            this.themeButton.Iconimage_Selected = null;
            this.themeButton.IconMarginLeft = 0;
            this.themeButton.IconMarginRight = 0;
            this.themeButton.IconRightVisible = false;
            this.themeButton.IconRightZoom = 0D;
            this.themeButton.IconVisible = false;
            this.themeButton.IconZoom = 90D;
            this.themeButton.IsTab = false;
            this.themeButton.Location = new System.Drawing.Point(0, 94);
            this.themeButton.Name = "themeButton";
            this.themeButton.Normalcolor = System.Drawing.Color.WhiteSmoke;
            this.themeButton.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.themeButton.OnHoverTextColor = System.Drawing.Color.White;
            this.themeButton.selected = false;
            this.themeButton.Size = new System.Drawing.Size(223, 48);
            this.themeButton.TabIndex = 20;
            this.themeButton.Text = "Tema";
            this.themeButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.themeButton.Textcolor = System.Drawing.Color.Black;
            this.themeButton.TextFont = new System.Drawing.Font("Century Gothic", 10F);
            this.themeButton.Click += new System.EventHandler(this.themeButton_Click);
            // 
            // zeroButton
            // 
            this.zeroButton.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(219)))));
            this.zeroButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.zeroButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.zeroButton.BorderRadius = 0;
            this.zeroButton.ButtonText = "Sıfırla";
            this.zeroButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.zeroButton.DisabledColor = System.Drawing.Color.Gray;
            this.zeroButton.ForeColor = System.Drawing.Color.White;
            this.zeroButton.Iconcolor = System.Drawing.Color.Transparent;
            this.zeroButton.Iconimage = ((System.Drawing.Image)(resources.GetObject("zeroButton.Iconimage")));
            this.zeroButton.Iconimage_right = null;
            this.zeroButton.Iconimage_right_Selected = null;
            this.zeroButton.Iconimage_Selected = null;
            this.zeroButton.IconMarginLeft = 0;
            this.zeroButton.IconMarginRight = 0;
            this.zeroButton.IconRightVisible = false;
            this.zeroButton.IconRightZoom = 0D;
            this.zeroButton.IconVisible = false;
            this.zeroButton.IconZoom = 90D;
            this.zeroButton.IsTab = false;
            this.zeroButton.Location = new System.Drawing.Point(0, 209);
            this.zeroButton.Name = "zeroButton";
            this.zeroButton.Normalcolor = System.Drawing.Color.WhiteSmoke;
            this.zeroButton.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.zeroButton.OnHoverTextColor = System.Drawing.Color.White;
            this.zeroButton.selected = false;
            this.zeroButton.Size = new System.Drawing.Size(223, 48);
            this.zeroButton.TabIndex = 20;
            this.zeroButton.Text = "Sıfırla";
            this.zeroButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.zeroButton.Textcolor = System.Drawing.Color.Black;
            this.zeroButton.TextFont = new System.Drawing.Font("Century Gothic", 10F);
            this.zeroButton.Click += new System.EventHandler(this.zeroButton_Click);
            // 
            // installmentButton
            // 
            this.installmentButton.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(219)))));
            this.installmentButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.installmentButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.installmentButton.BorderRadius = 0;
            this.installmentButton.ButtonText = "Taksit Seçenekleri";
            this.installmentButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.installmentButton.DisabledColor = System.Drawing.Color.Gray;
            this.installmentButton.ForeColor = System.Drawing.Color.White;
            this.installmentButton.Iconcolor = System.Drawing.Color.Transparent;
            this.installmentButton.Iconimage = ((System.Drawing.Image)(resources.GetObject("installmentButton.Iconimage")));
            this.installmentButton.Iconimage_right = null;
            this.installmentButton.Iconimage_right_Selected = null;
            this.installmentButton.Iconimage_Selected = null;
            this.installmentButton.IconMarginLeft = 0;
            this.installmentButton.IconMarginRight = 0;
            this.installmentButton.IconRightVisible = false;
            this.installmentButton.IconRightZoom = 0D;
            this.installmentButton.IconVisible = false;
            this.installmentButton.IconZoom = 90D;
            this.installmentButton.IsTab = false;
            this.installmentButton.Location = new System.Drawing.Point(0, 153);
            this.installmentButton.Name = "installmentButton";
            this.installmentButton.Normalcolor = System.Drawing.Color.WhiteSmoke;
            this.installmentButton.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.installmentButton.OnHoverTextColor = System.Drawing.Color.White;
            this.installmentButton.selected = false;
            this.installmentButton.Size = new System.Drawing.Size(223, 48);
            this.installmentButton.TabIndex = 20;
            this.installmentButton.Text = "Taksit Seçenekleri";
            this.installmentButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.installmentButton.Textcolor = System.Drawing.Color.Black;
            this.installmentButton.TextFont = new System.Drawing.Font("Century Gothic", 10F);
            this.installmentButton.Click += new System.EventHandler(this.installmentButton_Click);
            // 
            // settingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.menuPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "settingsForm";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Load += new System.EventHandler(this.settingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.menuPanel.ResumeLayout(false);
            this.menuPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private ns1.BunifuSeparator otherTransactionsSeprator;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Label headerLabel;
        private ns1.BunifuFlatButton installmentButton;
        private System.Windows.Forms.Panel mainPanel;
        private ns1.BunifuFlatButton themeButton;
        private ns1.BunifuFlatButton zeroButton;
    }
}