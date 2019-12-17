namespace alacakVerecekTakip
{
    partial class addNoteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addNoteForm));
            this.noteTitleLabel = new MetroFramework.Controls.MetroLabel();
            this.notePriorityLabel = new MetroFramework.Controls.MetroLabel();
            this.noteLabel = new MetroFramework.Controls.MetroLabel();
            this.noteTitleText = new MetroFramework.Controls.MetroTextBox();
            this.notePriorityCombo = new MetroFramework.Controls.MetroComboBox();
            this.noteRichText = new System.Windows.Forms.RichTextBox();
            this.saveButton = new MetroFramework.Controls.MetroTile();
            this.connectSituation = new MetroFramework.Controls.MetroTile();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // noteTitleLabel
            // 
            this.noteTitleLabel.AutoSize = true;
            this.noteTitleLabel.Location = new System.Drawing.Point(94, 105);
            this.noteTitleLabel.Name = "noteTitleLabel";
            this.noteTitleLabel.Size = new System.Drawing.Size(75, 19);
            this.noteTitleLabel.TabIndex = 0;
            this.noteTitleLabel.Text = "Not Başlığı:";
            // 
            // notePriorityLabel
            // 
            this.notePriorityLabel.AutoSize = true;
            this.notePriorityLabel.Location = new System.Drawing.Point(83, 155);
            this.notePriorityLabel.Name = "notePriorityLabel";
            this.notePriorityLabel.Size = new System.Drawing.Size(86, 19);
            this.notePriorityLabel.TabIndex = 1;
            this.notePriorityLabel.Text = "Not Önceliği:";
            // 
            // noteLabel
            // 
            this.noteLabel.AutoSize = true;
            this.noteLabel.Location = new System.Drawing.Point(135, 193);
            this.noteLabel.Name = "noteLabel";
            this.noteLabel.Size = new System.Drawing.Size(34, 19);
            this.noteLabel.TabIndex = 2;
            this.noteLabel.Text = "Not:";
            // 
            // noteTitleText
            // 
            // 
            // 
            // 
            this.noteTitleText.CustomButton.Image = null;
            this.noteTitleText.CustomButton.Location = new System.Drawing.Point(157, 2);
            this.noteTitleText.CustomButton.Name = "";
            this.noteTitleText.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.noteTitleText.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.noteTitleText.CustomButton.TabIndex = 1;
            this.noteTitleText.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.noteTitleText.CustomButton.UseSelectable = true;
            this.noteTitleText.CustomButton.Visible = false;
            this.noteTitleText.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.noteTitleText.Lines = new string[0];
            this.noteTitleText.Location = new System.Drawing.Point(175, 99);
            this.noteTitleText.MaxLength = 32767;
            this.noteTitleText.Name = "noteTitleText";
            this.noteTitleText.PasswordChar = '\0';
            this.noteTitleText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.noteTitleText.SelectedText = "";
            this.noteTitleText.SelectionLength = 0;
            this.noteTitleText.SelectionStart = 0;
            this.noteTitleText.ShortcutsEnabled = true;
            this.noteTitleText.Size = new System.Drawing.Size(185, 30);
            this.noteTitleText.TabIndex = 3;
            this.noteTitleText.UseSelectable = true;
            this.noteTitleText.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.noteTitleText.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // notePriorityCombo
            // 
            this.notePriorityCombo.FormattingEnabled = true;
            this.notePriorityCombo.ItemHeight = 23;
            this.notePriorityCombo.Items.AddRange(new object[] {
            "!",
            "!!",
            "!!!"});
            this.notePriorityCombo.Location = new System.Drawing.Point(175, 145);
            this.notePriorityCombo.Name = "notePriorityCombo";
            this.notePriorityCombo.Size = new System.Drawing.Size(185, 29);
            this.notePriorityCombo.TabIndex = 4;
            this.notePriorityCombo.UseSelectable = true;
            // 
            // noteRichText
            // 
            this.noteRichText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.noteRichText.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.noteRichText.Location = new System.Drawing.Point(175, 193);
            this.noteRichText.Name = "noteRichText";
            this.noteRichText.Size = new System.Drawing.Size(249, 185);
            this.noteRichText.TabIndex = 5;
            this.noteRichText.Text = "";
            // 
            // saveButton
            // 
            this.saveButton.ActiveControl = null;
            this.saveButton.Location = new System.Drawing.Point(284, 396);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(140, 40);
            this.saveButton.TabIndex = 20;
            this.saveButton.Text = "KAYDET";
            this.saveButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.saveButton.UseSelectable = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // connectSituation
            // 
            this.connectSituation.ActiveControl = null;
            this.connectSituation.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.connectSituation.ForeColor = System.Drawing.Color.Lime;
            this.connectSituation.Location = new System.Drawing.Point(12, 450);
            this.connectSituation.Name = "connectSituation";
            this.connectSituation.Size = new System.Drawing.Size(18, 18);
            this.connectSituation.TabIndex = 21;
            this.connectSituation.UseCustomBackColor = true;
            this.connectSituation.UseSelectable = true;
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // addNoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 476);
            this.Controls.Add(this.connectSituation);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.noteRichText);
            this.Controls.Add(this.notePriorityCombo);
            this.Controls.Add(this.noteTitleText);
            this.Controls.Add(this.noteLabel);
            this.Controls.Add(this.notePriorityLabel);
            this.Controls.Add(this.noteTitleLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "addNoteForm";
            this.Resizable = false;
            this.Text = "Not Ekle";
            this.Load += new System.EventHandler(this.addNote_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel noteTitleLabel;
        private MetroFramework.Controls.MetroLabel notePriorityLabel;
        private MetroFramework.Controls.MetroLabel noteLabel;
        private MetroFramework.Controls.MetroTextBox noteTitleText;
        private MetroFramework.Controls.MetroComboBox notePriorityCombo;
        private System.Windows.Forms.RichTextBox noteRichText;
        private MetroFramework.Controls.MetroTile saveButton;
        private MetroFramework.Controls.MetroTile connectSituation;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
    }
}