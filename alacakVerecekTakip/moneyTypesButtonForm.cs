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
    public partial class moneyTypesButtonForm : MetroFramework.Forms.MetroForm
    {
        public moneyTypesButtonForm()
        {
            InitializeComponent();
        }

        methods funcs = new methods();
        SqlConnection baglanti = methods.baglanti;
        debtTransactionsMethods debtTransactionFuncs = new debtTransactionsMethods();
        bool isAdd = false, isEdit = false, isDelete = false;
        string theme;
        private void moneyTypesTableFillColumn(){//para türleri listView'ine sütunları ekleme
            moneyTypesListView.Items.Clear();
            moneyTypesListView.View = View.Details;
            moneyTypesListView.GridLines = true;
            moneyTypesListView.Columns.Add("Id", 60);
            moneyTypesListView.Columns.Add("Para Türü", 150);
        }

        private void moneyTypesTableUpdateItems(){//para türleri listView'ina bilgileri doldurma
            moneyTypesListView.Items.Clear();

            SqlCommand komut = new SqlCommand("SELECT * FROM moneyTypesTable", baglanti);
            SqlDataReader rdr = komut.ExecuteReader();
            ListViewItem li = new ListViewItem();
            while (rdr.Read()){
                li = moneyTypesListView.Items.Add(rdr.GetInt32(0).ToString());
                li.SubItems.Add(rdr.GetString(1));
            }
            rdr.Close();
            //moneyTypesListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            moneyTypesListView.AutoResizeColumn(1,ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private bool addMoneyRowDatabase(string moneyName)
        {//para türleri tablosuna para ekleme işlemi
            bool durum = false;

            SqlCommand addCommand = new SqlCommand("INSERT INTO moneyTypesTable VALUES(@moneyTypeName, 0)", baglanti);
            addCommand.Parameters.AddWithValue("@moneyTypeName", moneyName);
            int retAddCommandValue = addCommand.ExecuteNonQuery();

            if (retAddCommandValue == 1) {

                int moneyTypeId = debtTransactionFuncs.moneyNameToId(moneyName);
                SqlCommand addSumAllMoneyTableCommand = new SqlCommand("INSERT INTO sumAllMoney VALUES(@moneyTypeId, 0)", baglanti);
                addSumAllMoneyTableCommand.Parameters.AddWithValue("@moneyTypeId", moneyTypeId);

                int retAddSumAllMoneyTableCommandVal = addSumAllMoneyTableCommand.ExecuteNonQuery();
                if (retAddSumAllMoneyTableCommandVal == 1) {

                    int baseMoneyId = selectBaseMoneyId();
                    SqlCommand addExchangeRateTableCommand = new SqlCommand("INSERT INTO exchangeRateTable VALUES(@exchangedMoneyType, @exchangeMoneyType, 0)", baglanti);
                    addExchangeRateTableCommand.Parameters.AddWithValue("@exchangedMoneyType", baseMoneyId);
                    addExchangeRateTableCommand.Parameters.AddWithValue("@exchangeMoneyType", moneyTypeId);

                    int retAddExchangeRateTableCommandVal = addExchangeRateTableCommand.ExecuteNonQuery();
                    if (retAddExchangeRateTableCommandVal == 1) {
                        SqlCommand addMoneyFundsTableCommand = new SqlCommand("INSERT INTO moneyFunds VALUES(0, @moneyId, 1, 0, @date);", baglanti);
                        addMoneyFundsTableCommand.Parameters.AddWithValue("@moneyId", moneyTypeId);
                        addMoneyFundsTableCommand.Parameters.AddWithValue("@date", Convert.ToDateTime(DateTime.Now));
                        int retAddMoneyFundsTableCommandVal = addMoneyFundsTableCommand.ExecuteNonQuery();
                        if (retAddMoneyFundsTableCommandVal == 1) {
                            SqlCommand addMoneyFundsTableCommand2 = new SqlCommand("INSERT INTO moneyFunds VALUES(0, @moneyId, 1, 1, @date);", baglanti);
                            addMoneyFundsTableCommand2.Parameters.AddWithValue("@moneyId", moneyTypeId);
                            addMoneyFundsTableCommand2.Parameters.AddWithValue("@date", Convert.ToDateTime(DateTime.Now));
                            int retAddMoneyFundsTableCommandVal2 = addMoneyFundsTableCommand2.ExecuteNonQuery();
                            if (retAddMoneyFundsTableCommandVal2 == 1) return true;
                            else return false;
                        }
                        else return false;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }

        private int selectBaseMoneyId()
        {
            int baseMoneyId = 0;
            SqlCommand selectBaseMoneyIdCommand = new SqlCommand("SELECT * FROM moneyTypesTable WHERE isBaseMoney = 1", baglanti);
            SqlDataReader sdr = selectBaseMoneyIdCommand.ExecuteReader();
            while (sdr.Read())
            {
                baseMoneyId = Convert.ToInt32(sdr["moneyId"]);
            }
            sdr.Close();
            return baseMoneyId;
        }


        private bool editMoneyRow(string replaceMoneyName, string newMoneyName)
        {//Seçilen pararnın güncellenmesi işlemi
            SqlCommand editMoneyCommand = new SqlCommand("UPDATE moneyTypesTable SET moneyName=@moneyTypeName WHERE moneyName = '" + replaceMoneyName + "';", baglanti);
            editMoneyCommand.Parameters.AddWithValue("@moneyTypeName", newMoneyName);
            int retEditCommandValue = editMoneyCommand.ExecuteNonQuery();
            if (retEditCommandValue == 1) return true;
            else return false;
        }

        private bool deleteMoneyType(int moneyId)
        {
            SqlCommand deleteExchangeRateTableCommand = new SqlCommand("DELETE FROM exchangeRateTable WHERE exchangeMoneyType = @moneyId", baglanti);
            deleteExchangeRateTableCommand.Parameters.AddWithValue("@moneyId", moneyId);

            int retDeleteExchangeRateTableCommandVal = deleteExchangeRateTableCommand.ExecuteNonQuery();
            if (retDeleteExchangeRateTableCommandVal == 1){
                SqlCommand deletesummAllMoneyCommand = new SqlCommand("DELETE FROM sumAllMoney WHERE moneyTypeId = @moneyId", baglanti);
                deletesummAllMoneyCommand.Parameters.AddWithValue("@moneyId", moneyId);

                int retDeletesummAllMoneyCommandVal = deletesummAllMoneyCommand.ExecuteNonQuery();
                if (retDeletesummAllMoneyCommandVal == 1){
                    SqlCommand deleteMoneyTypeCommand = new SqlCommand("DELETE FROM moneyTypesTable WHERE moneyId = @deletingMoneyId", baglanti);
                    deleteMoneyTypeCommand.Parameters.AddWithValue("@deletingMoneyId", moneyId);

                    int retDeleteMoneyTypeCommandVal = deleteMoneyTypeCommand.ExecuteNonQuery();
                    if (retDeleteMoneyTypeCommandVal == 1) {
                        SqlCommand deleteMoneyFundsTableCommand = new SqlCommand("DELETE FROM moneyFunds WHERE moneyTypeId = @moneyId", baglanti);
                        deleteMoneyFundsTableCommand.Parameters.AddWithValue("@moneyId", moneyId);
                        int retDeleteMoneyFundsTableCommandVal = deleteMoneyFundsTableCommand.ExecuteNonQuery();
                        if (retDeleteMoneyFundsTableCommandVal > 1) return true;
                        else return false;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }

        private bool itHasMoneyThisType(string moneyName) {
            int moneyId = debtTransactionFuncs.moneyNameToId(moneyName);
            double sumDebt = 0, sumMydebt = 0;
            SqlCommand itHasMoneyThisTypeCommand = new SqlCommand("SELECT * FROM moneyFunds WHERE moneyTypeId = @moneyId", baglanti);
            itHasMoneyThisTypeCommand.Parameters.AddWithValue("@moneyId", moneyId);
            SqlDataReader sdr = itHasMoneyThisTypeCommand.ExecuteReader();
            while (sdr.Read()){
                if (Convert.ToInt32(sdr["transactionType"]) == 0) {
                    sumMydebt += Convert.ToDouble(sdr["moneyVal"]);
                }
                else if (Convert.ToInt32(sdr["transactionType"]) == 1){
                    sumDebt += Convert.ToDouble(sdr["moneyVal"]);
                }
            }

            sdr.Close();
            if (sumDebt != sumMydebt) return false;
            else return true;
        }

        private void moneyTypesButtonForm_Load(object sender, EventArgs e)
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

            moneyTypesTableFillColumn();
            moneyTypesTableUpdateItems();
            inputTextBox.Enabled = false;
            OKButton.Enabled = false;
            cancelButton.Enabled = false;
        }

        
        private void addButton_Click(object sender, EventArgs e){
            isAdd = true;
            moneyTypesListView.Enabled = false;
            editButton.Enabled = false;
            deleteButton.Enabled = false;
            openMoneyExchangeRateFormButton.Enabled = false;
            inputTextBox.Enabled = true;
            inputTextBox.Text = "";
            inputTextBox.BackColor = Color.White;
            OKButton.Enabled = true;
            OKButton.BackColor = Color.FromArgb(0, 174, 219);
            cancelButton.Enabled = true;
            cancelButton.BackColor = Color.FromArgb(0, 174, 219);
        }

        private void editButton_Click(object sender, EventArgs e){
            if (inputTextBox.Text != ""){
                isEdit = true;
                moneyTypesListView.Enabled = true;
                addButton.Enabled = false;
                deleteButton.Enabled = false;
                openMoneyExchangeRateFormButton.Enabled = false;
                inputTextBox.Enabled = true;
                inputTextBox.BackColor = Color.White;
                inputTextBox.ForeColor = Color.Black;
                OKButton.Enabled = true;
                OKButton.BackColor = Color.FromArgb(0, 174, 219);
                cancelButton.Enabled = true;
                cancelButton.BackColor = Color.FromArgb(0, 174, 219);
            }
            else MetroFramework.MetroMessageBox.Show(this, "Lütfen Bir Para Birimi Seçiniz...", "UYARI!", MessageBoxButtons.OK);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (moneyTypesListView.SelectedItems.Count > 0){
                if (itHasMoneyThisType(moneyTypesListView.SelectedItems[0].SubItems[1].Text)) { 
                    DialogResult isSureness = MetroFramework.MetroMessageBox.Show(this, "'"+ moneyTypesListView.SelectedItems[0].SubItems[1].Text + "' silmek istediğinize emin misiniz?", "DİKKAT!!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (isSureness == DialogResult.Yes){
                        bool isDeleteComplate = deleteMoneyType(Convert.ToInt32(moneyTypesListView.SelectedItems[0].SubItems[0].Text));
                        if (isDeleteComplate == true){
                            MetroFramework.MetroMessageBox.Show(this, "Para türü başarılı bir şekilde silindi..", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            funcs.addHistory("'" + moneyTypesListView.SelectedItems[0].SubItems[1].Text + "' adlı para türü silindi.", 3);
                            moneyTypesTableUpdateItems();

                            debtTransactionFuncs.reloadMainPagePanelUserControls();
                        }
                        else MetroFramework.MetroMessageBox.Show(this, "Para türü silinemedi..", "BİLGİ!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else MetroFramework.MetroMessageBox.Show(this, "'" + moneyTypesListView.SelectedItems[0].SubItems[1].Text + "' para türünden varlığa sahipsiniz. Silemezsiniz..", "BİLGİ!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MetroFramework.MetroMessageBox.Show(this, "Lütfen bir para türü seçin..", "BİLGİ!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cancelButton_Click(object sender, EventArgs e){
            moneyTypesListView.Enabled = true;
            addButton.Enabled = true;
            editButton.Enabled = true;
            deleteButton.Enabled = true;
            openMoneyExchangeRateFormButton.Enabled = true;
            inputTextBox.BackColor = Color.Silver;
            inputTextBox.Enabled = false;
            inputTextBox.ForeColor = Color.FromArgb(109, 109, 109);
            OKButton.BackColor = Color.Silver;
            OKButton.Enabled = false;
            cancelButton.BackColor = Color.Silver;
            cancelButton.Enabled = false;
            inputTextBox.Text = "";
            isAdd = false;
            isEdit = false;
            isDelete = false;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            moneyExchangeRateForm moneyExchangeRateForm = new moneyExchangeRateForm();
            moneyExchangeRateForm.ShowDialog();
        }

        private void moneyTypesListView_Click(object sender, EventArgs e){
            if (moneyTypesListView.SelectedItems.Count > 0) inputTextBox.Text = moneyTypesListView.SelectedItems[0].SubItems[1].Text;
        }

        private void OKButton_Click(object sender, EventArgs e){
            if (isAdd){//eğer 'EKLE' butonuna basıldıysa bu if bloğu çalışacak ve addMoneyRowDatabase methodu ile 
                       // Veri tabanına ekleme işlemi yapılacak, eğer bu method'dan true gelirse
                       // ekrana messagaBox ile bilgi gelecek
                bool isAddComplate = addMoneyRowDatabase(inputTextBox.Text);
                if (isAddComplate == true){
                    isAdd = false;
                    MetroFramework.MetroMessageBox.Show(this, "Para Türü Eklendi.\nKur Dengesi formuna giderek baz alıancak para türü ile arasında ki farkı giriniz..", "BİLGİ!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    funcs.addHistory("'" + inputTextBox.Text + "' adlı para türü eklendi.", 3);
                    moneyTypesTableUpdateItems();

                    inputTextBox.Text = "";
                    inputTextBox.Enabled = false;
                    inputTextBox.BackColor = Color.Silver;
                    inputTextBox.ForeColor = Color.FromArgb(109, 109, 109);
                    moneyTypesListView.Enabled = true;
                    OKButton.Enabled = false;
                    OKButton.BackColor = Color.Silver;
                    cancelButton.Enabled = false;
                    cancelButton.BackColor = Color.Silver;
                    addButton.Enabled = true;
                    editButton.Enabled = true;
                    deleteButton.Enabled = true;

                    debtTransactionFuncs.reloadMainPagePanelUserControls();

                    moneyExchangeRateForm moneyExchangeRateForm = new moneyExchangeRateForm();
                    moneyExchangeRateForm.ShowDialog();
                }
                else MetroFramework.MetroMessageBox.Show(this, "Para Eklenemedi...", "BİLGİ!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (isEdit){
                bool isEditComplate = editMoneyRow(moneyTypesListView.SelectedItems[0].SubItems[1].Text, inputTextBox.Text);
                if (isEditComplate == true){
                    isEdit = false;

                    MetroFramework.MetroMessageBox.Show(this, "Para Türü Düzenlendi...", "BİLGİ!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    funcs.addHistory("'"+ moneyTypesListView.SelectedItems[0].SubItems[1].Text + "' adlı para türü '" + inputTextBox.Text + "' olarak düzenlendi.", 3);
                    moneyTypesTableUpdateItems();

                    inputTextBox.Text = "";
                    inputTextBox.Enabled = false;
                    inputTextBox.BackColor = Color.Silver;
                    inputTextBox.ForeColor = Color.FromArgb(109, 109, 109);
                    OKButton.Enabled = false;
                    OKButton.BackColor = Color.Silver;
                    cancelButton.Enabled = false;
                    cancelButton.BackColor = Color.Silver;
                    addButton.Enabled = true;
                    editButton.Enabled = true;
                    deleteButton.Enabled = true;

                    debtTransactionFuncs.reloadMainPagePanelUserControls();
                }
                else MetroFramework.MetroMessageBox.Show(this, "Para türü düzenlenemedi...", "BİLGİ!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
