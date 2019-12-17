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
    public partial class addNoteForm : MetroFramework.Forms.MetroForm
    {
        public addNoteForm()
        {
            InitializeComponent();
        }

        methods funcs = new methods();
        SqlConnection baglanti = methods.baglanti;
        string theme;

        private bool addNote(string noteTitle, string notePriority, string noteDiscription)
        {
            int notePriorityVal = 0;
            if (notePriority == "!") notePriorityVal = 1;
            else if (notePriority == "!!") notePriorityVal = 2;
            else if (notePriority == "!!!") notePriorityVal = 3;

            SqlCommand addNoteCommand = new SqlCommand("INSERT INTO notes VALUES(@notePriority, @noteTitle, @noteDiscription)", baglanti);
            addNoteCommand.Parameters.AddWithValue("@notePriority", notePriorityVal);
            addNoteCommand.Parameters.AddWithValue("@noteTitle", noteTitle);
            addNoteCommand.Parameters.AddWithValue("@noteDiscription", noteDiscription);
            int retAddNoteCommandVal = addNoteCommand.ExecuteNonQuery();
            if (retAddNoteCommandVal == 1) return true;
            else return false;
        }

        private void addNote_Load(object sender, EventArgs e)
        {
            this.StyleManager = metroStyleManager1;
            theme = funcs.themeChanger(0);
            if (theme == "light") metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Light;
            else metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;

            if (funcs.isConnect(baglanti) == true){
                connectSituation.BackColor = Color.Lime;
                funcs.setToolTip(connectSituation, "Veri Tabanı Bağlantısı Var");
            }
            else{
                MetroFramework.MetroMessageBox.Show(this, "Veri Tabanı Bağlantısı Kurulamadığından Dolayı Program Kapatılıyor..", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            bool isAdd = addNote(noteTitleText.Text, notePriorityCombo.Text, noteRichText.Text);
            if (isAdd) {
                MetroFramework.MetroMessageBox.Show(this, "Not Eklendi.", "BİLGİ!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                funcs.addHistory("'" + noteTitleText.Text + "' başlıklı not eklendi.", 4);
            }
            else MetroFramework.MetroMessageBox.Show(this, "Not Eklenemedi.", "BİLGİ!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.Close();
        }
    }
}
