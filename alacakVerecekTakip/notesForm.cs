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
    public partial class notesForm : MetroFramework.Forms.MetroForm
    {
        public notesForm()
        {
            InitializeComponent();
        }

        methods funcs = new methods();
        SqlConnection baglanti = methods.baglanti;
        public static int selectedNote;
        public static bool isEdit = false;
        string theme;

        private void fillNotesListViewColumns()
        {
            notesListView.Items.Clear();
            notesListView.View = View.Details;
            notesListView.GridLines = true;
            notesListView.Columns.Add("Id", 60, HorizontalAlignment.Center);
            notesListView.Columns.Add("Öncelik", 50, HorizontalAlignment.Center);
            notesListView.Columns.Add("Not Başlığı", 150, HorizontalAlignment.Center);
        }

        private void fillNotesListViewItems()
        {/*
            İlk Önce ListView'da ki elemanları temizliyoruz 
            Çünkü temizlemezsek her elemanı olanların altına yerleştirir.
            Daha sonra note önceliğini !(1) olarak ayarlıyoruz çünkü eğer bunu yapmazsak
            Lokal dğeişken tanımladığımız için hata verecektir.
            Daha Sonra DataReader açarak SQL'den çektiğimiz bilgileri ListView'a yazdırıyoruz.
         */
            notesListView.Items.Clear();
            string notePriority = "!";
            SqlCommand fillNotesLWItemsCommand = new SqlCommand("SELECT * FROM notes",baglanti);
            SqlDataReader sdr = fillNotesLWItemsCommand.ExecuteReader();
            ListViewItem li = new ListViewItem();
            while (sdr.Read())
            {
                li = notesListView.Items.Add(sdr.GetInt32(0).ToString());
                if (sdr.GetInt32(1) == 1) notePriority = "!";
                else if (sdr.GetInt32(1) == 2) notePriority = "!!";
                else if (sdr.GetInt32(1) == 3) notePriority = "!!!";
                li.SubItems.Add(notePriority);
                li.SubItems.Add(sdr.GetString(2));
            }
            sdr.Close();
            notesListView.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private bool deleteNoteListViewItem(int deletingNote)
        {
            SqlCommand deleteNoteListViewItemCommand = new SqlCommand("DELETE FROM notes WHERE noteId = @deletingNoteId ", baglanti);
            deleteNoteListViewItemCommand.Parameters.AddWithValue("@deletingNoteId", deletingNote);
            int retDeleteNoteListViewVal = deleteNoteListViewItemCommand.ExecuteNonQuery();
            if (retDeleteNoteListViewVal == 1) return true;
            else return false;
        }

        private void notes_Load(object sender, EventArgs e)
        {/*
            Bütün formlar yüklendiği ilk anda statik bir değişken olan theme'yi kontrol eder
            eğer theme içinde ki değer Light'sa beyaz tema Dark'sa karanlık tema uygulanır
            daha sonra veri Tabanı ile herhabgi bir baglanti var mı diye kontrol edilir
            eğer varsa devam edilir yoksa kurulur.

            Daha sonra bu formda fillNotesListViewColumn methodu ile ListView'ın sütunları yerleştrilir
            fillNotesListViewItems methodu ile de bilgiler doldurulur.
        */
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

            fillNotesListViewColumns();
            fillNotesListViewItems();

        }
        private void editButton_Click(object sender, EventArgs e)
        {
            if (notesListView.SelectedItems.Count > 0){
                isEdit = true;
                selectedNote = Convert.ToInt32(notesListView.SelectedItems[0].SubItems[0].Text);
                noteDetailForm noteDetailForm = new noteDetailForm();
                noteDetailForm.ShowDialog();
                if(noteDetailForm.isEdit2 == true){
                    fillNotesListViewItems();
                    noteDetailForm.isEdit2 = false;
                }
            }
            else isEdit = false;
        }

        private void notesListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (notesListView.SelectedItems.Count > 0){
                isEdit = false;
                selectedNote = Convert.ToInt32(notesListView.SelectedItems[0].SubItems[0].Text);
                noteDetailForm noteDetailForm = new noteDetailForm();
                noteDetailForm.ShowDialog();
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            addNoteForm addNoteForm = new addNoteForm();
            addNoteForm.ShowDialog();
            fillNotesListViewItems();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            bool isDelete = deleteNoteListViewItem(Convert.ToInt32(notesListView.SelectedItems[0].SubItems[0].Text));
            if(isDelete == true){
                MetroFramework.MetroMessageBox.Show(this, "Not başarılı bir şekilde silindi..", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                funcs.addHistory("'" + notesListView.SelectedItems[0].SubItems[2].Text + "' başlıkl not silindi.", 4);
                fillNotesListViewItems();
            }
            else MetroFramework.MetroMessageBox.Show(this, "Not silinemedi..", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
