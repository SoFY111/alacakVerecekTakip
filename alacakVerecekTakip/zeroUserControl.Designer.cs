namespace alacakVerecekTakip
{
    partial class zeroUserControl
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
            this.zeroButton = new MetroFramework.Controls.MetroTile();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // zeroButton
            // 
            this.zeroButton.ActiveControl = null;
            this.zeroButton.Location = new System.Drawing.Point(188, 135);
            this.zeroButton.Name = "zeroButton";
            this.zeroButton.Size = new System.Drawing.Size(169, 80);
            this.zeroButton.TabIndex = 0;
            this.zeroButton.Text = "SIFIRLA";
            this.zeroButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.zeroButton.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.zeroButton.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.zeroButton.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.zeroButton.UseSelectable = true;
            this.zeroButton.Click += new System.EventHandler(this.zeroButton_Click);
            // 
            // zeroUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.zeroButton);
            this.Name = "zeroUserControl";
            this.Size = new System.Drawing.Size(550, 370);
            this.Load += new System.EventHandler(this.zeroUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroTile zeroButton;
    }
}
