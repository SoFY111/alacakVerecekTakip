using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace alacakVerecekTakip
{
    public partial class editInstallmentCountUserControl : MetroFramework.Controls.MetroUserControl
    {

        private static editInstallmentCountUserControl _instance;
        public static editInstallmentCountUserControl Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new editInstallmentCountUserControl();
                return _instance;
            }
        }

        public editInstallmentCountUserControl()
        {
            InitializeComponent();
        }

        methods funcs = new methods();
        SqlConnection baglanti = methods.baglanti;
        public static int selectedHistory;
        string theme;

        private void fillShowInstallmentCountListViewColumn()
        {
            showInstallmentCountListView.Items.Clear();
            showInstallmentCountListView.View = View.Details;
            showInstallmentCountListView.GridLines = true;
            showInstallmentCountListView.Columns.Add("Taksit Tutarı");
            showInstallmentCountListView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void fillShowInstallmentCountListViewItems() 
        {
            showInstallmentCountListView.Items.Clear();
            SqlCommand fillShowInstallmentCountListViewItemsCommand = new SqlCommand("SELECT * FROM installmentCount", baglanti);
            SqlDataReader sdr = fillShowInstallmentCountListViewItemsCommand.ExecuteReader();
            ListViewItem li = new ListViewItem();
            while (sdr.Read()){
                li = showInstallmentCountListView.Items.Add(sdr["installmentCount"].ToString());
            }
            sdr.Close();
        }

        private bool addInstallmentCount(int installmentCount)
        {
            SqlCommand addInstallmentCountCommand = new SqlCommand("INSERT INTO installmentCount VALUES(@installmentCount)", baglanti);
            addInstallmentCountCommand.Parameters.AddWithValue("@installmentCount", installmentCount);
            int retAddInstallmentCountCommandVal = addInstallmentCountCommand.ExecuteNonQuery();
            if (retAddInstallmentCountCommandVal == 1) return true;
            else return false;
        }

        private bool itHasInstallmentCount(int installmentCount)
        {
            bool returnedVal = false;
            SqlCommand itHasInstallmentCountCommand = new SqlCommand("SELECT * FROM installmentCount WHERE installmentCount = @installmentCount", baglanti);
            itHasInstallmentCountCommand.Parameters.AddWithValue("@installmentCount", installmentCount);
            SqlDataReader sdr = itHasInstallmentCountCommand.ExecuteReader();
            while (sdr.Read())
            {
                returnedVal = true;
            }
            sdr.Close();

            return returnedVal;
        }

        private bool deleteInstallmentCount(int installmentCount)
        {
            SqlCommand deleteInstallmentCountCommand = new SqlCommand("DELETE FROM installmentCount WHERE installmentCount = @installmentCount", baglanti);
            deleteInstallmentCountCommand.Parameters.AddWithValue("@installmentCount", installmentCount);
            int retDeleteInstallmentCountCommandVal = deleteInstallmentCountCommand.ExecuteNonQuery();
            if (retDeleteInstallmentCountCommandVal == 1) return true;
            else return false;
        }

        private void editInstallmentCountUserControl_Load(object sender, EventArgs e)
        {
            this.StyleManager = metroStyleManager1;
            theme = funcs.themeChanger(0);

            if (theme == "light") metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Light;
            else metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            if (funcs.isConnect(baglanti) == true) { }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Veri Tabanı Bağlantısı Kurulamadığından Dolayı Program Kapatılıyor..", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            if (metroStyleManager1.Theme == MetroFramework.MetroThemeStyle.Dark)
            {

            }
            else
            {

            }

            fillShowInstallmentCountListViewColumn();
            fillShowInstallmentCountListViewItems();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (showInstallmentCountListView.SelectedItems.Count > 0){
                DialogResult isRestart = MetroFramework.MetroMessageBox.Show(this, "Silmek istediğinize emin misiniz?", "DİKKAT!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (isRestart == DialogResult.Yes){
                    if (deleteInstallmentCount(Convert.ToInt32(showInstallmentCountListView.SelectedItems[0].Text))){
                        MetroFramework.MetroMessageBox.Show(this, "Taksit tutarı başarılı bir şekilde silindi.", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        funcs.addHistory("'" + showInstallmentCountListView.SelectedItems[0].Text + "' başarılı bir şekilde silindi." , 4);

                        showInstallmentCountListView.Clear();
                        fillShowInstallmentCountListViewItems();
                    }
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            inputTextBox.Enabled = true;
            deleteButton.Enabled = false;
            OKButton.Enabled = true;
            cancelButton.Enabled = true;

            deleteButton.BackColor = Color.Silver;
            inputTextBox.BackColor = Color.White;
            OKButton.BackColor = Color.FromArgb(0, 174, 219);
            cancelButton.BackColor = Color.FromArgb(0, 174, 219);
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (inputTextBox.Text != ""){
                if (!itHasInstallmentCount(Convert.ToInt32(inputTextBox.Text))){
                    if (addInstallmentCount(Convert.ToInt32(inputTextBox.Text))){
                        MetroFramework.MetroMessageBox.Show(this, "Taksit tutarı başarılı bir şekilde eklendi.", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        funcs.addHistory("'" + inputTextBox.Text + "' başarılı bir şekilde eklendi.", 4);

                        fillShowInstallmentCountListViewItems();
                    }
                }
                else MetroFramework.MetroMessageBox.Show(this, "Bu miktarda taksit tutarınız vardır..", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MetroFramework.MetroMessageBox.Show(this, "Lütfen bir taksit tutarı  giriniz.", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            deleteButton.Enabled = true;
            inputTextBox.Enabled = false;
            OKButton.Enabled = false;
            cancelButton.Enabled = false;

            deleteButton.BackColor = Color.FromArgb(0, 174, 219);
            inputTextBox.BackColor = Color.Silver;
            OKButton.BackColor = Color.Silver;
            cancelButton.BackColor = Color.Silver;

            inputTextBox.Text = "";
        }

        private void inputTextBox_TextChanged(object sender, EventArgs e)
        {
            if (inputTextBox.Text == ""){
                OKButton.Enabled = false;
                OKButton.BackColor = Color.Silver;
            }
            else
            {
                OKButton.Enabled = true;
                OKButton.BackColor = Color.FromArgb(0, 174, 219);
            }
        }

        private void inputTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08)
            {
                e.Handled = true;
            }
            
        }
    }
}
