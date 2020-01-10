namespace alacakVerecekTakip
{
    partial class changeThemeUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(changeThemeUserControl));
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.darkLightThemeChangerButton = new MetroFramework.Controls.MetroTile();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // darkLightThemeChangerButton
            // 
            this.darkLightThemeChangerButton.ActiveControl = null;
            this.darkLightThemeChangerButton.Location = new System.Drawing.Point(228, 134);
            this.darkLightThemeChangerButton.Name = "darkLightThemeChangerButton";
            this.darkLightThemeChangerButton.Size = new System.Drawing.Size(123, 105);
            this.darkLightThemeChangerButton.TabIndex = 6;
            this.darkLightThemeChangerButton.Text = "Koyu Mod";
            this.darkLightThemeChangerButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.darkLightThemeChangerButton.TileImage = ((System.Drawing.Image)(resources.GetObject("darkLightThemeChangerButton.TileImage")));
            this.darkLightThemeChangerButton.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.darkLightThemeChangerButton.UseSelectable = true;
            this.darkLightThemeChangerButton.UseTileImage = true;
            this.darkLightThemeChangerButton.Click += new System.EventHandler(this.darkLightThemeChangerButton_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(162, 94);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(256, 25);
            this.metroLabel1.TabIndex = 7;
            this.metroLabel1.Text = "Temayı Değiştirmek İçin Basınız";
            // 
            // changeThemeUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.darkLightThemeChangerButton);
            this.Name = "changeThemeUserControl";
            this.Size = new System.Drawing.Size(577, 420);
            this.Load += new System.EventHandler(this.changeThemeUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTile darkLightThemeChangerButton;
    }
}
