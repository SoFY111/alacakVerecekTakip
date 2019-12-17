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
    public partial class bankTypesForm : MetroFramework.Forms.MetroForm
    {
        public bankTypesForm()
        {
            InitializeComponent();
        }

        methods funcs = new methods();
        SqlConnection baglanti = methods.baglanti;
        static string oldBankName;
        string theme;
        bool isAdd = false, isEdit = false;

        private void fillBankTypesListViewColumn()
        {
            bankTypesListView.Items.Clear();
            bankTypesListView.View = View.Details;
            bankTypesListView.GridLines = true;
            bankTypesListView.Columns.Add("Banka Türü");
        }

        private void fillBankTypesListViewItems()
        {
            bankTypesListView.Items.Clear();
            SqlCommand fillBankTypesListViewItemsCommand = new SqlCommand("SELECT * FROM bankTypes ORDER BY bankTypeName ASC ", baglanti);
            SqlDataReader sdr = fillBankTypesListViewItemsCommand.ExecuteReader();
            ListViewItem li = new ListViewItem();
            while (sdr.Read()){
                li = bankTypesListView.Items.Add(sdr.GetString(1).ToString());
            }
            sdr.Close();
            bankTypesListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private bool isBankTypeWas(string bankName)
        {
            bool isBankTypeWas = false;
            SqlCommand bankTypeWas = new SqlCommand("SELECT * FROM bankTypes WHERE bankTypeName = @bankTypeName", baglanti);
            bankTypeWas.Parameters.AddWithValue("@bankTypeName", bankName);
            SqlDataReader sdr = bankTypeWas.ExecuteReader();
            while (sdr.Read()) {
                isBankTypeWas = true;
            }
            sdr.Close();
            return isBankTypeWas;
        }
        private bool addBank(string bankName)
        {
            SqlCommand addBankCommand = new SqlCommand("INSERT INTO bankTypes VALUES(@bankName)", baglanti);
            addBankCommand.Parameters.AddWithValue("@bankName", bankName);
            int retAddBankTypeVal = addBankCommand.ExecuteNonQuery();
            if (retAddBankTypeVal == 1) return true;
            else return false;
        }

        private bool updateBankTypeName(string newBankName, string oldBankName)
        {
            SqlCommand updateBankTypeNameCommand = new SqlCommand("UPDATE bankTypes SET bankTypeName = @newBankName WHERE bankTypeName = @oldBankName", baglanti);
            updateBankTypeNameCommand.Parameters.AddWithValue("@newBankName", newBankName);
            updateBankTypeNameCommand.Parameters.AddWithValue("@oldBankName", oldBankName);
            int retUpdateBankTypeNameVal = updateBankTypeNameCommand.ExecuteNonQuery();
            if (retUpdateBankTypeNameVal == 1) return true;
            else return false;
        }

        private bool deleteBankType(string bankName)
        {
            SqlCommand deleteBankTypeCommand = new SqlCommand("DELETE FROM bankTypes WHERE bankTypeName = @bankName", baglanti);
            deleteBankTypeCommand.Parameters.AddWithValue("@bankName", bankName);
            int retDeleteBankTypeCommandVal = deleteBankTypeCommand.ExecuteNonQuery();
            if (retDeleteBankTypeCommandVal == 1) return true;
            else return false;
        }

        private void bankTypesForm_Load(object sender, EventArgs e)
        {
            this.StyleManager = metroStyleManager1;
            theme = funcs.themeChanger(0);

            if (theme == "light") metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Light;
            else metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;

            if (funcs.isConnect(baglanti) == true)
            {
                connectSituation.BackColor = Color.Lime;
                funcs.setToolTip(connectSituation, "Veri Tabanı Bağlantısı Var");
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Veri Tabanı Bağlantısı Kurulamadığından Dolayı Program Kapatılıyor..", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            fillBankTypesListViewColumn();
            fillBankTypesListViewItems();
        }

        private void bankTypesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bankTypesListView.SelectedItems.Count > 0) inputTextBox.Text = bankTypesListView.SelectedItems[0].Text;
        }

        private void addBankTypeButton_Click(object sender, EventArgs e)
        {
            isAdd = true;
            inputTextBox.Enabled = true;
            OKButton.Enabled = true;
            cancelButton.Enabled = true;
            addBankTypeButton.Enabled = false;
            editBankTypeButton.Enabled = false;
            deleteBankTypeButton.Enabled = false;

            inputTextBox.Text = "";

            inputTextBox.BackColor = Color.White;
            inputTextBox.ForeColor = Color.Black;
            OKButton.BackColor = Color.FromArgb(0, 174, 219);
            cancelButton.BackColor = Color.FromArgb(0, 174, 219);
        }

        private void editBankTypeButton_Click(object sender, EventArgs e)
        {
            if (inputTextBox.Text != ""){

                oldBankName = inputTextBox.Text;
                isEdit = true;
                inputTextBox.Enabled = true;
                OKButton.Enabled = true;
                cancelButton.Enabled = true;
                addBankTypeButton.Enabled = false;
                editBankTypeButton.Enabled = false;
                deleteBankTypeButton.Enabled = false;

                bankTypesListView.Enabled = false;

                inputTextBox.BackColor = Color.White;
                inputTextBox.ForeColor = Color.Black;
                OKButton.BackColor = Color.FromArgb(0, 174, 219);
                cancelButton.BackColor = Color.FromArgb(0, 174, 219);
            }
            else MetroFramework.MetroMessageBox.Show(this, "Lütfen bir banka türü seçiniz...", "UYARI!", MessageBoxButtons.OK);

        }

        private void deleteBankTypeButton_Click(object sender, EventArgs e)
        {
            if (bankTypesListView.SelectedItems.Count > 0){
                DialogResult isDeleteSure = MetroFramework.MetroMessageBox.Show(this, "'" + bankTypesListView.SelectedItems[0].Text + "' adlı bankayı silmek istediğinizden emin misiniz?","DİKKAT!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                if (isDeleteSure == DialogResult.Yes){
                    if (deleteBankType(bankTypesListView.SelectedItems[0].Text)){
                        MetroFramework.MetroMessageBox.Show(this, "Banka türü silindi...", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        funcs.addHistory("'" + bankTypesListView.SelectedItems[0].Text + "' adlı banka türü silindi.", 3);
                        fillBankTypesListViewItems();
                    }
                    else MetroFramework.MetroMessageBox.Show(this, "Banka türü silinemedi...", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else MetroFramework.MetroMessageBox.Show(this, "Herhangi bir banka türü seçmediniz...","BİLGİ!!!", MessageBoxButtons.OK);

        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (isAdd){
                isAdd = false;
                if (!isBankTypeWas(inputTextBox.Text)){
                    if (addBank(inputTextBox.Text)) {
                        MetroFramework.MetroMessageBox.Show(this, "Banka türü eklendi...", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fillBankTypesListViewItems();
                        funcs.addHistory("'" + inputTextBox.Text + "' adlı banka türü eklendi.", 3);

                        if (anasayfa.mainpagePanel1.Controls.Contains(cashBalanceUserControl.Instance))
                        {
                            anasayfa.mainpagePanel1.Controls.Clear();
                            cashBalanceUserControl.reloadForm();
                            anasayfa.mainpagePanel1.Controls.Add(cashBalanceUserControl.Instance);
                        }

                        bankTypesListView.Enabled = true;

                        editBankTypeButton.Enabled = true;
                        deleteBankTypeButton.Enabled = true;

                        inputTextBox.ForeColor = Color.FromArgb(109, 109, 109);
                        inputTextBox.BackColor = Color.Silver;
                        OKButton.BackColor = Color.Silver;
                        cancelButton.BackColor = Color.Silver;

                        inputTextBox.Text = "";

                        inputTextBox.Enabled = false;
                        OKButton.Enabled = false;
                        cancelButton.Enabled = false;
                    }
                    else MetroFramework.MetroMessageBox.Show(this, "Banka türü eklenemedi...", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MetroFramework.MetroMessageBox.Show(this, "Aynı isimde zaten bir banka türü mevcut. ","BİLGİ!!!",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (isEdit)
            {
                if (updateBankTypeName(inputTextBox.Text, bankTypesListView.SelectedItems[0].Text))
                {
                    MetroFramework.MetroMessageBox.Show(this, "Banka ismi değiştirildi...", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillBankTypesListViewItems();
                    funcs.addHistory("'" + oldBankName + "' olan banka ismi '" + inputTextBox.Text + "' ile değiştirildi.", 3);

                    if (anasayfa.mainpagePanel1.Controls.Contains(cashBalanceUserControl.Instance))
                    {
                        anasayfa.mainpagePanel1.Controls.Clear();
                        cashBalanceUserControl.reloadForm();
                        anasayfa.mainpagePanel1.Controls.Add(cashBalanceUserControl.Instance);
                    }

                    bankTypesListView.Enabled = true;

                    addBankTypeButton.Enabled = true;
                    deleteBankTypeButton.Enabled = true;

                    inputTextBox.ForeColor = Color.FromArgb(109, 109, 109);
                    inputTextBox.BackColor = Color.Silver;
                    OKButton.BackColor = Color.Silver;
                    cancelButton.BackColor = Color.Silver;

                    inputTextBox.Text = "";

                    inputTextBox.Enabled = false;
                    OKButton.Enabled = false;
                    cancelButton.Enabled = false;
                }
                else MetroFramework.MetroMessageBox.Show(this, "Banka ismi değiştirilemedi...", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            addBankTypeButton.Enabled = true;
            editBankTypeButton.Enabled = true;
            deleteBankTypeButton.Enabled = true;

            OKButton.Enabled = false;
            cancelButton.Enabled = false;
            inputTextBox.Enabled = false;

            bankTypesListView.Enabled = true;

            inputTextBox.Text = "";
            inputTextBox.BackColor = Color.Silver;
            inputTextBox.ForeColor = Color.FromArgb(109, 109, 109);
            OKButton.BackColor = Color.Silver;
            cancelButton.BackColor = Color.Silver;

            isAdd = false;
            isEdit = false;
        }
    }
}
