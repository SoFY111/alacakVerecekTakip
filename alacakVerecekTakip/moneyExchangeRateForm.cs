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
    public partial class moneyExchangeRateForm : MetroFramework.Forms.MetroForm
    {
        public moneyExchangeRateForm()
        {
            InitializeComponent();
        }

        methods funcs = new methods();
        SqlConnection baglanti = methods.baglanti;
        debtTransactionsMethods debtTransactionFuncs = new debtTransactionsMethods();
        string theme;
        bool isEditMoneyRate = false;

        private string selectBaseMoneyType()
        {
            /*
             * İlk önce daha önceden belirlenmiş baz alınacak parayı seçiyoruz.
             * */
            string baseMoney = "";
            SqlCommand selectBaseMoneyTypeCommand = new SqlCommand("SELECT * FROM moneyTypesTable WHERE isBaseMoney = 1", baglanti);
            SqlDataReader sdr = selectBaseMoneyTypeCommand.ExecuteReader();
            while (sdr.Read()){
                baseMoney = sdr["moneyName"].ToString();
            }
            sdr.Close();
            return baseMoney;
        }

        private int oldBaseMoneyId()
        {
            int baseMoneyId = 0;
            SqlCommand selectBaseMoneyTypeCommand = new SqlCommand("SELECT * FROM moneyTypesTable WHERE isBaseMoney = 1", baglanti);
            SqlDataReader sdr = selectBaseMoneyTypeCommand.ExecuteReader();
            while (sdr.Read()){
                baseMoneyId = Convert.ToInt32(sdr["moneyId"]);
            }
            sdr.Close();
            return baseMoneyId;
        }

        private bool updateBaseMoneyType(string newBaseMoneyType)
        {// Eski standart paranın isBaseMoney sütununda ki değeri 0 yapıyoruz ondan sonra yenisini 1 yapıyoruz.
            string olBaseMoneyType = selectBaseMoneyType();
            int newBaseMoneyTypeIdd = newBaseMoneyTypeId(newBaseMoneyType);
            int oldBaseMoneyIdd = oldBaseMoneyId();
            string[] exchangeMoneyName = findExchangeMoneyFromIdToName();
            char ayrac = '-';
            bool durum = false;

            SqlCommand updateOldBaseMoneyTypeCommand = new SqlCommand("UPDATE moneyTypesTable SET isBaseMoney = 0 WHERE moneyName = @oldBaseMoneyType", baglanti);
            updateOldBaseMoneyTypeCommand.Parameters.AddWithValue("@oldBaseMoneyType", olBaseMoneyType);
            int retUpdateOldBaseMoneyTypeCommandVal = updateOldBaseMoneyTypeCommand.ExecuteNonQuery();

            if (retUpdateOldBaseMoneyTypeCommandVal == 1){

                SqlCommand updateBaseMoneyCommand = new SqlCommand("UPDATE moneyTypesTable SET isBaseMoney = 1 WHERE moneyName = @newBaseMoneyType", baglanti);
                updateBaseMoneyCommand.Parameters.AddWithValue("@newBaseMoneyType", newBaseMoneyType);
                int retUpdateBaseMoneyCommandVal = updateBaseMoneyCommand.ExecuteNonQuery();

                if (retUpdateBaseMoneyCommandVal == 1){
                    SqlCommand deleteOldExchangeTableCommand = new SqlCommand("DELETE FROM exchangeRateTable", baglanti);

                    int retDeleteOldExchangeTableCommandVal = deleteOldExchangeTableCommand.ExecuteNonQuery();
                    if (retDeleteOldExchangeTableCommandVal > 0){
                        for (int i = 0; i < exchangeMoneyName.Length; i++){
                            string[] exchangeMoneyCleanName = exchangeMoneyName[i].Split(ayrac);
                            if (newBaseMoneyTypeIdd == Convert.ToInt32(exchangeMoneyCleanName[0])){
                                continue;
                            }
                            else{
                                SqlCommand newExchangeRateTable = new SqlCommand("INSERT INTO exchangeRateTable VALUES(@exchangedMoneyType, @exchangeMoneyType, @exchangeRate);", baglanti);
                                newExchangeRateTable.Parameters.AddWithValue("@exchangedMoneyType", newBaseMoneyTypeIdd);
                                newExchangeRateTable.Parameters.AddWithValue("@exchangeMoneyType", Convert.ToInt32(exchangeMoneyCleanName[0]));
                                newExchangeRateTable.Parameters.AddWithValue("@exchangeRate", 0);
                                int retNewExchangeRateTableVal = newExchangeRateTable.ExecuteNonQuery();
                                if (retNewExchangeRateTableVal == 1){
                                    durum = true;
                                }
                                else durum = false;
                            }
                        }
                    }
                    else durum = false;
                }
                else durum = false;
            }
            else durum = false;
            return durum;
        }

        private void fillBaseMoneyTypeCombo()
        {
            SqlCommand fillStandartMoneyTypeComboCommand = new SqlCommand("SELECT * FROM moneyTypesTable", baglanti);
            SqlDataReader sdr = fillStandartMoneyTypeComboCommand.ExecuteReader();
            while (sdr.Read()){
                baseMoneyTypeCombo.Items.Add(sdr["moneyName"].ToString());
            }
            sdr.Close();
        }

        private void addExchangeRateZeroMoney()
        {
            /*
             * exchangeRate 'i 0 olan para türlerini seçiyoruz 
             * */
            exchangeMoneyCombo.Items.Clear();

            string[] exchangeMoneyName = findExchangeMoneyFromIdToName();
            char ayrac = '-';

            SqlCommand addExchangeRateZeroMoneyCommand = new SqlCommand("SELECT * FROM exchangeRateTable WHERE exchangeRate = 0", baglanti);
            SqlDataReader sdr = addExchangeRateZeroMoneyCommand.ExecuteReader();
            while (sdr.Read()){
                for (int i = 0; i < exchangeMoneyName.Length; i++){
                    string[] exchangeMoneyCleanName = exchangeMoneyName[i].Split(ayrac);
                    if (Convert.ToInt32(sdr["exchangeMoneyType"]) == Convert.ToInt32(exchangeMoneyCleanName[0])) {
                        exchangeMoneyCombo.Items.Add(exchangeMoneyCleanName[1]);
                    }
                }
            }
            sdr.Close();
        }

        private void addExchangeRateMoney()
        {
            exchangeMoneyCombo.Items.Clear();

            string[] exchangeMoneyName = findExchangeMoneyFromIdToName();
            char ayrac = '-';

            SqlCommand addExchangeRateMoneyCommand = new SqlCommand("SELECT * FROM exchangeRateTable", baglanti);
            SqlDataReader sdr = addExchangeRateMoneyCommand.ExecuteReader();
            while (sdr.Read()){
                for (int i = 0; i < exchangeMoneyName.Length; i++){
                    string[] exchangeMoneyCleanName = exchangeMoneyName[i].Split(ayrac);
                    if (Convert.ToInt32(sdr["exchangeMoneyType"]) == Convert.ToInt32(exchangeMoneyCleanName[0])){
                        exchangeMoneyCombo.Items.Add(exchangeMoneyCleanName[1]);
                    }
                }
            }
            sdr.Close();
        }

        private string[] findExchangeMoneyFromIdToName()
        {
            /*
             * exchangeRateTable tablomuzda bütün değerler int(id) olduğundan dolayı 
             * onları string'e dönüştürmek için moneyTypes tablosunu id ile birlikte
             * ismini bir diziye aktarıyoruz. Bunu kullanmak için stringlerde kullanılan
             * Split() metodunu çağırıyoruz.
             * */
            int moneyCount1 = moneyCount(), moneyCount2 = 0;
            string[] exchangeMoneyName = new string[moneyCount1];

            SqlCommand findExchangeMoneyFromIdToNameCommand = new SqlCommand("SELECT * FROM moneyTypesTable", baglanti);
            SqlDataReader sdr = findExchangeMoneyFromIdToNameCommand.ExecuteReader();
            while (sdr.Read()){
                if(moneyCount2 <= moneyCount1){
                    exchangeMoneyName[moneyCount2] = (sdr["moneyId"].ToString()) + "-" + sdr["moneyName"].ToString();
                    moneyCount2++;
                }
            }
            sdr.Close();
            return exchangeMoneyName;
        }

        private int moneyCount()
        {
            int moneyCountt = 0;
            SqlCommand moneyCountCommand = new SqlCommand("SELECT * FROM moneyTypesTable", baglanti);
            SqlDataReader sdr = moneyCountCommand.ExecuteReader();
            while (sdr.Read()){
                moneyCountt++;
            }
            sdr.Close();
            return moneyCountt;
        }

        private int newBaseMoneyTypeId(string newBaseMoneyType)
        {
            int id = 0;
            SqlCommand newBaseMoneyTypeIdCommand = new SqlCommand("SELECT * FROM moneyTypesTable WHERE moneyName = @newBaseMoneyType", baglanti);
            newBaseMoneyTypeIdCommand.Parameters.AddWithValue("@newBaseMoneyType", newBaseMoneyType);
            SqlDataReader sdr = newBaseMoneyTypeIdCommand.ExecuteReader();
            while (sdr.Read()){
                id = Convert.ToInt32(sdr["moneyId"]);
            }
            sdr.Close();
            return id;
        }

        private bool isZeroRate()
        {
            bool isReturned = false;
            SqlCommand isZeroRateCommand = new SqlCommand("SELECT * FROM exchangeRateTable WHERE exchangeRate = 0", baglanti);
            try{
                SqlDataReader sdr = isZeroRateCommand.ExecuteReader();

                while (sdr.Read()){
                    isReturned = true;
                }
                sdr.Close();
                return isReturned;
            }
            catch (Exception ex){
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        private bool addExchangeRate(string exchangeMoneyType, double exchangeRate)
        {
            double exchangeMoneyTypeId = 0;
            string[] exchangeMoneyTypeArray = findExchangeMoneyFromIdToName();
            char ayrac = '-';
            for (int i = 0; i < exchangeMoneyTypeArray.Length; i++){
                string[] exchangeMoneyCleanName = exchangeMoneyTypeArray[i].Split(ayrac);
                if (exchangeMoneyType == exchangeMoneyCleanName[1]){
                    exchangeMoneyTypeId = Convert.ToInt32(exchangeMoneyCleanName[0]);
                    break;
                }
            }

            SqlCommand addExchangeRateCommand = new SqlCommand("UPDATE exchangeRateTable SET exchangeRate = @exchangeRate WHERE exchangeMoneyType = @exchangeMoneyTypeId", baglanti);
            addExchangeRateCommand.Parameters.AddWithValue("@exchangeRate", exchangeRate);
            addExchangeRateCommand.Parameters.AddWithValue("@exchangeMoneyTypeId", exchangeMoneyTypeId);
            int retAddExchangeRateCommandVal = addExchangeRateCommand.ExecuteNonQuery();
            if (retAddExchangeRateCommandVal == 1) return true;
            else return false;
        }

        private double moneyRate(string exchangeMoneyNameRate)
        {
            double moneyRate = 0;
            int exchangeMoneyId = 0;
            string[] exchangeMoneyRateName = findExchangeMoneyFromIdToName();

            for (int  i= 0; i < exchangeMoneyRateName.Length; i++)
            {
                string[] exchangeMoneyRateCleanName = exchangeMoneyRateName[i].Split('-');
                if (exchangeMoneyRateCleanName[1] == exchangeMoneyNameRate) {
                    exchangeMoneyId = Convert.ToInt32(exchangeMoneyRateCleanName[0]);
                    break;
                }
            }

            SqlCommand moneyRateCommand = new SqlCommand("SELECT * FROM exchangeRateTable WHERE exchangeMoneyType = @exchangeMoneyTypeId", baglanti);
            moneyRateCommand.Parameters.AddWithValue("@exchangeMoneyTypeId", exchangeMoneyId);
            SqlDataReader sdr = moneyRateCommand.ExecuteReader();
            while (sdr.Read()){
                moneyRate = Convert.ToDouble(sdr["exchangeRate"]);
            }
            sdr.Close();
            return moneyRate;
        }

        private void moneyExchangeRate_Load(object sender, EventArgs e)
        {
            this.StyleManager = metroStyleManager1;
            theme = funcs.themeChanger(0);

            if (theme == "light"){
                metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Light;
                exchangeMoneyGroup.ForeColor = Color.Black;
            }
            else{
                metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
                exchangeMoneyGroup.ForeColor = Color.FromArgb(170, 170, 170);
            }

            if (funcs.isConnect(baglanti) == true){
                connectSituation.BackColor = Color.Lime;
                funcs.setToolTip(connectSituation, "Veri Tabanı Bağlantısı Var");
            }
            else{
                MetroFramework.MetroMessageBox.Show(this, "Veri Tabanı Bağlantısı Kurulamadığından Dolayı Program Kapatılıyor..", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            fillBaseMoneyTypeCombo();
            baseMoneyTypeCombo.SelectedItem = selectBaseMoneyType();
            exchangeMoneyLabel2.Text = selectBaseMoneyType();

            if (isZeroRate()){
                exchangeMoneyGroup.Enabled = true;
                saveExchangeMoneyRateButton.BackColor = Color.FromArgb(0, 174, 219);
                addExchangeRateZeroMoney();
            }
            else{
                exchangeMoneyGroup.Enabled = false;
                saveExchangeMoneyRateButton.BackColor = Color.FromArgb(170, 170, 170);
            }
        }

        private void baseMoneyTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (baseMoneyTypeCombo.SelectedItem.ToString() != selectBaseMoneyType()){
                baseMoneyTypeButton.Enabled = true;
                baseMoneyTypeButton.BackColor = Color.FromArgb(0, 174, 219);
                baseMoneyTypeButton.ForeColor = Color.White;
            }
            else{
                baseMoneyTypeButton.Enabled = false;
                baseMoneyTypeButton.BackColor = Color.Silver;
                baseMoneyTypeButton.ForeColor = Color.Black;
            }
        }

        private void baseStandartMoneyTypeButton_Click(object sender, EventArgs e)
        {
            bool isUpdateBaseMoneyTypeComplated = updateBaseMoneyType(baseMoneyTypeCombo.SelectedItem.ToString());
            if (isUpdateBaseMoneyTypeComplated) {
                MetroFramework.MetroMessageBox.Show(this, "Baz alıncak para değiştirildi.\nLütfen kur değerlerini giriniz...", "BİGLİ!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                funcs.addHistory("Baz alınacak para '" + baseMoneyTypeCombo.SelectedItem.ToString() + "' olarak değiştirildi.", 3);

                debtTransactionFuncs.reloadMainPagePanelUserControls();

                baseMoneyTypeButton.Enabled = false;
                exchangeMoneyGroup.Enabled = true;
                saveExchangeMoneyRateButton.BackColor = Color.FromArgb(0, 174, 219);
                exchangeMoneyLabel2.Text = selectBaseMoneyType();
                addExchangeRateZeroMoney();
            }
            else MetroFramework.MetroMessageBox.Show(this, "Baz alıncak para değiştirlemedi...", "BİLGİ!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void exchangeMoneyCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            exchangeRateText.Text = moneyRate(exchangeMoneyCombo.SelectedItem.ToString()).ToString();
            if (exchangeMoneyCombo.SelectedIndex.ToString() != "" && exchangeRateText.Text != ""){
                exchangeMoneyResultLabel.Text = "1 " + exchangeMoneyCombo.SelectedItem.ToString() + " * " + exchangeRateText.Text + " = " + ((Convert.ToDouble(exchangeRateText.Text)) * 1).ToString() + " " + selectBaseMoneyType();
                saveExchangeMoneyRateButton.Enabled = true;
                saveExchangeMoneyRateButton.BackColor = Color.FromArgb(0, 174, 219);
            }
            else{
                saveExchangeMoneyRateButton.Enabled = false;
                saveExchangeMoneyRateButton.BackColor = Color.FromArgb(170, 170, 170);
            }
        }

        private void exchangeRateText_TextChanged(object sender, EventArgs e)
        {
            if (exchangeMoneyCombo.SelectedIndex.ToString() != "" && exchangeRateText.Text != ""){
                try{
                    exchangeMoneyResultLabel.Text = "1 " + exchangeMoneyCombo.SelectedItem.ToString() + " * " + exchangeRateText.Text + " = " + ((Convert.ToDouble(exchangeRateText.Text)) * 1).ToString() + " " + selectBaseMoneyType();

                }
                catch (Exception){
                    //throw;
                }
                saveExchangeMoneyRateButton.Enabled = true;
                saveExchangeMoneyRateButton.BackColor = Color.FromArgb(0, 174, 219);
            }
            else{
                saveExchangeMoneyRateButton.Enabled = false;
                saveExchangeMoneyRateButton.BackColor = Color.FromArgb(170, 170, 170);
            }
        }

        private void saveExchangeMoneyRateButton_Click(object sender, EventArgs e)
        {
            if (exchangeMoneyCombo.SelectedIndex.ToString() != "" && exchangeRateText.Text != ""){
                bool addExchangeRateComplated = addExchangeRate(exchangeMoneyCombo.SelectedItem.ToString(), Convert.ToDouble(exchangeRateText.Text));
                if (addExchangeRateComplated){
                    if (isEditMoneyRate){
                        MetroFramework.MetroMessageBox.Show(this, "Kur Düzenlendi...", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        funcs.addHistory("1 " + exchangeMoneyCombo.SelectedItem.ToString() + " * " + exchangeRateText.Text + " = " + ((Convert.ToDouble(exchangeRateText.Text)) * 1).ToString() + " " + selectBaseMoneyType() + ", olarak düzenlendi.", 3);
                        isEditMoneyRate = false;

                        debtTransactionFuncs.reloadMainPagePanelUserControls();
                    }
                    else {
                        MetroFramework.MetroMessageBox.Show(this, "Kur eklendi...", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        funcs.addHistory("1 " + exchangeMoneyCombo.SelectedItem.ToString() + " * " + exchangeRateText.Text + " = " + ((Convert.ToDouble(exchangeRateText.Text)) * 1).ToString() + " " + selectBaseMoneyType() + ", olarak eklendi..", 3);

                        debtTransactionFuncs.reloadMainPagePanelUserControls();
                    }
                    if (isZeroRate()){
                        addExchangeRateZeroMoney();
                    }
                    else{
                        exchangeMoneyGroup.Enabled = false;
                        saveExchangeMoneyRateButton.BackColor = Color.FromArgb(170, 170, 170);
                    }
                }
                else MetroFramework.MetroMessageBox.Show(this, "Kur eklenmedi...", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exchangeRateText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 44 && (int)e.KeyChar <= 57){
                e.Handled = false;//eğer rakamsa  yazdır.
            }
            else if ((int)e.KeyChar == 8){
                e.Handled = false;//eğer basılan tuş backspace ise yazdır.
            }
            else{
                e.Handled = true;//bunların dışındaysa hiçbirisini yazdırma
            }
        }

        private void editMoneyBalanceButton_Click(object sender, EventArgs e)
        {
            addExchangeRateMoney();
            exchangeMoneyGroup.Enabled = true;
            isEditMoneyRate = true;
        }

        private void moneyExchangeRateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isZeroRate() == false){
                e.Cancel = false;
            }
            else {
                MetroFramework.MetroMessageBox.Show(this, "Herhangi bir para türünün kur dengesi 0 olamaz, lütfen düzeltin ve öyle devam edin...", "BİLGİ!!!",MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }
    }
}
