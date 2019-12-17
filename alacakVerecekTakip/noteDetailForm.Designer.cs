namespace alacakVerecekTakip
{
    partial class noteDetailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(noteDetailForm));
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.connectSituation = new MetroFramework.Controls.MetroTile();
            this.noteTitleLabel = new MetroFramework.Controls.MetroLabel();
            this.noteTitleText = new MetroFramework.Controls.MetroTextBox();
            this.notePriorityLabel = new MetroFramework.Controls.MetroLabel();
            this.notePriorityCombo = new MetroFramework.Controls.MetroComboBox();
            this.noteDiscriptionLabel = new MetroFramework.Controls.MetroLabel();
            this.noteDiscriptionRichText = new System.Windows.Forms.RichTextBox();
            this.saveButton = new MetroFramework.Controls.MetroTile();
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
            this.connectSituation.Location = new System.Drawing.Point(23, 422);
            this.connectSituation.Name = "connectSituation";
            this.connectSituation.Size = new System.Drawing.Size(18, 18);
            this.connectSituation.TabIndex = 12;
            this.connectSituation.UseCustomBackColor = true;
            this.connectSituation.UseSelectable = true;
            // 
            // noteTitleLabel
            // 
            this.noteTitleLabel.AutoSize = true;
            this.noteTitleLabel.Location = new System.Drawing.Point(92, 82);
            this.noteTitleLabel.Name = "noteTitleLabel";
            this.noteTitleLabel.Size = new System.Drawing.Size(75, 19);
            this.noteTitleLabel.TabIndex = 13;
            this.noteTitleLabel.Text = "Not Başlığı:";
            // 
            // noteTitleText
            // 
            // 
            // 
            // 
            this.noteTitleText.CustomButton.Image = null;
            this.noteTitleText.CustomButton.Location = new System.Drawing.Point(147, 2);
            this.noteTitleText.CustomButton.Name = "";
            this.noteTitleText.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.noteTitleText.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.noteTitleText.CustomButton.TabIndex = 1;
            this.noteTitleText.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.noteTitleText.CustomButton.UseSelectable = true;
            this.noteTitleText.CustomButton.Visible = false;
            this.noteTitleText.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.noteTitleText.Lines = new string[0];
            this.noteTitleText.Location = new System.Drawing.Point(170, 77);
            this.noteTitleText.MaxLength = 32767;
            this.noteTitleText.Name = "noteTitleText";
            this.noteTitleText.PasswordChar = '\0';
            this.noteTitleText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.noteTitleText.SelectedText = "";
            this.noteTitleText.SelectionLength = 0;
            this.noteTitleText.SelectionStart = 0;
            this.noteTitleText.ShortcutsEnabled = true;
            this.noteTitleText.Size = new System.Drawing.Size(175, 30);
            this.noteTitleText.TabIndex = 14;
            this.noteTitleText.UseSelectable = true;
            this.noteTitleText.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.noteTitleText.WaterMarkFont = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            // 
            // notePriorityLabel
            // 
            this.notePriorityLabel.AutoSize = true;
            this.notePriorityLabel.Location = new System.Drawing.Point(86, 128);
            this.notePriorityLabel.Name = "notePriorityLabel";
            this.notePriorityLabel.Size = new System.Drawing.Size(81, 19);
            this.notePriorityLabel.TabIndex = 15;
            this.notePriorityLabel.Text = "Not Öncelik:";
            // 
            // notePriorityCombo
            // 
            this.notePriorityCombo.FormattingEnabled = true;
            this.notePriorityCombo.ItemHeight = 23;
            this.notePriorityCombo.Items.AddRange(new object[] {
            "!",
            "!!",
            "!!!"});
            this.notePriorityCombo.Location = new System.Drawing.Point(170, 123);
            this.notePriorityCombo.Name = "notePriorityCombo";
            this.notePriorityCombo.Size = new System.Drawing.Size(175, 29);
            this.notePriorityCombo.TabIndex = 16;
            this.notePriorityCombo.UseSelectable = true;
            // 
            // noteDiscriptionLabel
            // 
            this.noteDiscriptionLabel.AutoSize = true;
            this.noteDiscriptionLabel.Location = new System.Drawing.Point(133, 178);
            this.noteDiscriptionLabel.Name = "noteDiscriptionLabel";
            this.noteDiscriptionLabel.Size = new System.Drawing.Size(34, 19);
            this.noteDiscriptionLabel.TabIndex = 17;
            this.noteDiscriptionLabel.Text = "Not:";
            // 
            // noteDiscriptionRichText
            // 
            this.noteDiscriptionRichText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.noteDiscriptionRichText.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.noteDiscriptionRichText.Location = new System.Drawing.Point(170, 178);
            this.noteDiscriptionRichText.Name = "noteDiscriptionRichText";
            this.noteDiscriptionRichText.Size = new System.Drawing.Size(249, 185);
            this.noteDiscriptionRichText.TabIndex = 18;
            this.noteDiscriptionRichText.Text = "";
            // 
            // saveButton
            // 
            this.saveButton.ActiveControl = null;
            this.saveButton.Location = new System.Drawing.Point(279, 369);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(140, 40);
            this.saveButton.TabIndex = 19;
            this.saveButton.Text = "KAYDET";
            this.saveButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.saveButton.UseSelectable = true;
            this.saveButton.Visible = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // noteDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 450);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.noteDiscriptionRichText);
            this.Controls.Add(this.noteDiscriptionLabel);
            this.Controls.Add(this.notePriorityCombo);
            this.Controls.Add(this.notePriorityLabel);
            this.Controls.Add(this.noteTitleText);
            this.Controls.Add(this.noteTitleLabel);
            this.Controls.Add(this.connectSituation);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "noteDetailForm";
            this.Resizable = false;
            this.Text = "Not Ayrıntısı";
            this.Load += new System.EventHandler(this.notDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroTile connectSituation;
        private MetroFramework.Controls.MetroLabel noteTitleLabel;
        private MetroFramework.Controls.MetroTextBox noteTitleText;
        private MetroFramework.Controls.MetroLabel notePriorityLabel;
        private MetroFramework.Controls.MetroComboBox notePriorityCombo;
        private MetroFramework.Controls.MetroLabel noteDiscriptionLabel;
        private System.Windows.Forms.RichTextBox noteDiscriptionRichText;
        private MetroFramework.Controls.MetroTile saveButton;
    }
}