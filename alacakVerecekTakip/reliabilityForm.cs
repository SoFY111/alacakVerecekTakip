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
    public partial class reliabilityForm : MetroFramework.Forms.MetroForm
    {
        public reliabilityForm()
        {
            InitializeComponent();
        }

        methods funcs = new methods();
        SqlConnection baglanti = methods.baglanti;
        string theme;

        private void fillReliabiltyListViewColumn()
        {
            reliabilityListView.Items.Clear();
            reliabilityListView.View = View.Details;
            reliabilityListView.GridLines = true;
            reliabilityListView.Columns.Add("Güvenilirlik Dereceleri");
        }

        private void fillReliabiltyListViewItems()
        {
            reliabilityListView.Items.Clear();
            SqlCommand fillReliabiltyListViewItemCommand = new SqlCommand("SELECT * FROM degreeOfReliabilty", baglanti);
            SqlDataReader sdr = fillReliabiltyListViewItemCommand.ExecuteReader();
            ListViewItem li = new ListViewItem();
            while (sdr.Read())
            {
                li = reliabilityListView.Items.Add(sdr.GetString(1));
            }
            sdr.Close();
            reliabilityListView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private bool editDegreeOfReliabiltyItem(string oldDegreeOfReliabiltyDiscription, string newDegreeOfReliabiltyDiscription)
        {
            SqlCommand editDegreeOfReliabiltyItemCommand = new SqlCommand("UPDATE degreeOfReliabilty SET degreeOfReliabiltyDiscription = @newDegreeOfReliabiltyDiscription WHERE degreeOfReliabiltyDiscription = @oldDegreeOfReliabiltyDiscription ", baglanti);
            editDegreeOfReliabiltyItemCommand.Parameters.AddWithValue("@newDegreeOfReliabiltyDiscription", newDegreeOfReliabiltyDiscription);
            editDegreeOfReliabiltyItemCommand.Parameters.AddWithValue("@oldDegreeOfReliabiltyDiscription", oldDegreeOfReliabiltyDiscription);
            int retEditDegreeOfReliabiltyItemCommandVal = editDegreeOfReliabiltyItemCommand.ExecuteNonQuery();
            if (retEditDegreeOfReliabiltyItemCommandVal == 1) return true;
            else return false;
        }

        private void reliabilityForm_Load(object sender, EventArgs e)
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

            fillReliabiltyListViewColumn();
            fillReliabiltyListViewItems();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (reliabilityListView.SelectedItems.Count > 0){
                if (inputTextBox.Text != ""){
                    inputTextBox.Enabled = true;
                    inputTextBox.BackColor = Color.White;
                    inputTextBox.ForeColor = Color.Black;
                    OKButton.Enabled = true;
                    OKButton.BackColor = Color.FromArgb(0, 174, 219);
                    cancelButton.Enabled = true;
                    cancelButton.BackColor = Color.FromArgb(0, 174, 219);
                }
            }
            else MetroFramework.MetroMessageBox.Show(this, "Lütfen Bir Güvenilirlik Durumu Seçiniz...", "UYARI!", MessageBoxButtons.OK);
        }

        private void reliabilityListView_Click(object sender, EventArgs e)
        {
            if (reliabilityListView.SelectedItems.Count > 0){
                inputTextBox.Text = (reliabilityListView.SelectedItems[0].SubItems[0].Text);
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if(editDegreeOfReliabiltyItem((reliabilityListView.SelectedItems[0].SubItems[0].Text), inputTextBox.Text)){
                MetroFramework.MetroMessageBox.Show(this, "Güvenilirlik Derecesinin İsmi Düzenlendi..", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                funcs.addHistory("'" + (reliabilityListView.SelectedItems[0].SubItems[0].Text) + "' olan  güvenilirlik derecesinin ismi '" + inputTextBox.Text + "' ile değiştirildi..", 4);
            }
            else MetroFramework.MetroMessageBox.Show(this, "Güvenilirlik derecesinin ismi düzenlenemedi..", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            inputTextBox.Text = "";
            fillReliabiltyListViewItems();
            inputTextBox.Text = "";
            inputTextBox.Enabled = false;
            inputTextBox.BackColor = Color.Silver;
            inputTextBox.ForeColor = Color.FromArgb(109, 109, 109);
            OKButton.BackColor = Color.Silver;
            OKButton.Enabled = false;
            cancelButton.BackColor = Color.Silver;
            cancelButton.Enabled = false;
            inputTextBox.Text = "";
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            inputTextBox.Enabled = false;
            inputTextBox.BackColor = Color.Silver;
            inputTextBox.ForeColor = Color.FromArgb(109, 109, 109);
            OKButton.BackColor = Color.Silver;
            OKButton.Enabled = false;
            cancelButton.BackColor = Color.Silver;
            cancelButton.Enabled = false;
            inputTextBox.Text = "";
        }
    }
}
