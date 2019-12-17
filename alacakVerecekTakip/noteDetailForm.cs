using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace alacakVerecekTakip
{
    public partial class noteDetailForm : MetroFramework.Forms.MetroForm
    {
        public noteDetailForm()
        {
            InitializeComponent();
        }

        methods funcs = new methods();
        SqlConnection baglanti = methods.baglanti;
        public static bool isEdit2 = false;
        string theme;
        
        private void fillTheBlanks(int selectedNote)
        {
            int notePriorityComboValue = 1;

            SqlCommand fillTheBlanksCommand = new SqlCommand("SELECT * FROM notes WHERE noteId=@selectedNoteId", baglanti);
            fillTheBlanksCommand.Parameters.AddWithValue("@selectedNoteId", selectedNote);
            SqlDataReader sdr = fillTheBlanksCommand.ExecuteReader();

            while (sdr.Read()){
                this.Text += " - " + sdr["noteTitle"].ToString();
                noteTitleText.Text = sdr["noteTitle"].ToString();
                notePriorityComboValue = Convert.ToInt32(sdr["notePriority"]);
                noteDiscriptionRichText.Text = sdr["noteDiscription"].ToString();
            }
            sdr.Close();

            if (notePriorityComboValue == 1) notePriorityCombo.SelectedIndex = 0;
            if (notePriorityComboValue == 2) notePriorityCombo.SelectedIndex = 1;
            if (notePriorityComboValue == 3) notePriorityCombo.SelectedIndex = 2;

        }

        private bool updateNote(int selectedNote, string newNoteTitle, string newNotePriority, string newNoteDiscription)
        {
            try{
                int newNotePriorityValue = 0;
                if (newNotePriority == "!") newNotePriorityValue = 1;
                else if (newNotePriority == "!!") newNotePriorityValue = 2;
                else if (newNotePriority == "!!!") newNotePriorityValue = 3;
                
                SqlCommand updateNoteCommand = new SqlCommand("UPDATE notes SET noteTitle = @newNoteTitle, notePriority = @newNotePriority, noteDiscription = @newNoteDiscription WHERE noteId = @noteId", baglanti);
                updateNoteCommand.Parameters.AddWithValue("@newNoteTitle", newNoteTitle);
                updateNoteCommand.Parameters.AddWithValue("@newNotePriority", newNotePriorityValue);
                updateNoteCommand.Parameters.AddWithValue("@newNoteDiscription", newNoteDiscription);
                updateNoteCommand.Parameters.AddWithValue("@noteId", selectedNote);
                int retUpdateNoteCommandVal = updateNoteCommand.ExecuteNonQuery();
                if (retUpdateNoteCommandVal == 1) return true;
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void notDetail_Load(object sender, EventArgs e)
        {
            this.StyleManager = metroStyleManager1;
            theme = funcs.themeChanger(0);
            if (theme == "light")   metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Light;
            else metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;

            if (funcs.isConnect(baglanti) == true){
                connectSituation.BackColor = Color.Lime;
                funcs.setToolTip(connectSituation, "Veri Tabanı Bağlantısı Var");
            }
            else{
                MetroFramework.MetroMessageBox.Show(this, "Veri Tabanı Bağlantısı Kurulamadığından Dolayı Program Kapatılıyor..", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            fillTheBlanks(notesForm.selectedNote);

            if (notesForm.isEdit){
                this.Text += "Düzenle - ";
                noteTitleText.Enabled = true;
                notePriorityCombo.Enabled = true;
                noteDiscriptionRichText.Enabled = true;
                saveButton.Visible = true;   
            }
            else{
                noteTitleText.Enabled = false;
                notePriorityCombo.Enabled = false;
                noteDiscriptionRichText.Enabled = false;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            bool isUpdateComplate = updateNote(notesForm.selectedNote, (noteTitleText.Text).ToLower(), (notePriorityCombo.Text), noteDiscriptionRichText.Text);
            if (isUpdateComplate){
                MetroFramework.MetroMessageBox.Show(this, "Not Güncellendi..", "Bilgi!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                funcs.addHistory("'" + noteTitleText.Text + "' başlıklı not güncellendi", 4);
                isEdit2 = true;
                Hide();
            }
            else MetroFramework.MetroMessageBox.Show(this, "Not Güncellenemedi..", "Bilgi!!", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }
    }
}
