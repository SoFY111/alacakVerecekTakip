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
    public partial class cashOutflowForm : MetroFramework.Forms.MetroForm
    {
        public cashOutflowForm()
        {
            InitializeComponent();
        }

        methods funcs = new methods();
        debtTransactionsMethods debtTransactionFuncs = new debtTransactionsMethods();
        SqlConnection baglanti = methods.baglanti;
        public static string companyName;
        string theme;

        private void fillBankTypesCombo()
        {
            SqlCommand fillBankTypesComboCommand = new SqlCommand("SELECT * FROM bankTypes", baglanti);
            SqlDataReader sdr = fillBankTypesComboCommand.ExecuteReader();
            while (sdr.Read()){
                bankTypesCombo.Items.Add(sdr["bankTypeName"]);
            }
            sdr.Close();
        }

        private void fillMoneyTypesCombo()
        {
            SqlCommand fillBankTypesComboCommand = new SqlCommand("SELECT * FROM moneyTypesTable", baglanti);
            SqlDataReader sdr = fillBankTypesComboCommand.ExecuteReader();
            while (sdr.Read()){
                moneyTypesCombo.Items.Add(sdr["moneyName"]);
            }
            sdr.Close();
        }

        private bool minusMoneyValToBankAccount(string bankName, string moneyTypeName, double moneyVal)
        {
            /*
             * transactionType => 0 Kasadan Para Çıkışı
             * transactionType => 1 Kasaya Para Girişi 
             * */

            DateTime time = DateTime.Now;
            string nowTime = time.ToString("yyyy'/'MM'/'dd' 'HH':'mm':'ss");

            int bankTypeId = debtTransactionFuncs.bankNameToId(bankName);
            int moneyTypeId = debtTransactionFuncs.moneyNameToId(moneyTypeName);
            SqlCommand addMoneyValToBankAccountCommand = new SqlCommand("INSERT INTO moneyFunds VALUES(@bankId, @moneyId, @moneyVal, @transactionType, @dateNow)", baglanti);
            addMoneyValToBankAccountCommand.Parameters.AddWithValue("@bankId", bankTypeId);
            addMoneyValToBankAccountCommand.Parameters.AddWithValue("@moneyId", moneyTypeId);
            addMoneyValToBankAccountCommand.Parameters.AddWithValue("@moneyVal", moneyVal);
            addMoneyValToBankAccountCommand.Parameters.AddWithValue("@transactionType", 0);
            addMoneyValToBankAccountCommand.Parameters.AddWithValue("@dateNow", nowTime);
            int retAddMoneyValToBankAccountCommandVal = addMoneyValToBankAccountCommand.ExecuteNonQuery();
            if (retAddMoneyValToBankAccountCommandVal == 1){
                double sumMoneyVal = sumMoneyTypeVal(moneyTypeId);
                sumMoneyVal -= moneyVal;
                SqlCommand updateSumAllMoneyCommand = new SqlCommand("UPDATE sumAllMoney SET sumMoneyVal = @sumMoneyVal WHERE moneyTypeId = @moneyTypeId", baglanti);
                updateSumAllMoneyCommand.Parameters.AddWithValue("@sumMoneyVal", sumMoneyVal);
                updateSumAllMoneyCommand.Parameters.AddWithValue("@moneyTypeId", moneyTypeId);
                int retUpdateSumAllMoneyCommandVal = updateSumAllMoneyCommand.ExecuteNonQuery();
                if (retUpdateSumAllMoneyCommandVal == 1) return true;
                else return false;
            }
            else return false;
        }

        private double sumMoneyTypeVal(int moneyTypeId)
        {
            double sumMoney = 0;
            SqlCommand sumMoneyTypeValCommand = new SqlCommand("SELECT * FROM sumAllMoney WHERE moneyTypeId = @moneyTypeId", baglanti);
            sumMoneyTypeValCommand.Parameters.AddWithValue("@moneyTypeId", moneyTypeId);
            SqlDataReader sdr = sumMoneyTypeValCommand.ExecuteReader();
            while (sdr.Read()){
                sumMoney = Convert.ToDouble(sdr["sumMoneyVal"]);
            }
            sdr.Close();
            return sumMoney;
        }

        private bool doesItHaveEnoughMoney(string bankTypeName, string moneyTypeName, double moneyVal)
        {
            bool returnedVal = false;
            int bankId = debtTransactionFuncs.bankNameToId(bankTypeName), moneyId = debtTransactionFuncs.moneyNameToId(moneyTypeName);
            double sumMoney = 0;
            SqlCommand sumMoneyCommand = new SqlCommand("SELECT * FROM moneyFunds WHERE bankId = @bankId AND moneyTypeId = @moneyId", baglanti);
            sumMoneyCommand.Parameters.AddWithValue("@bankId", bankId);
            sumMoneyCommand.Parameters.AddWithValue("@moneyId", moneyId);
            SqlDataReader sdr = sumMoneyCommand.ExecuteReader();
            while (sdr.Read()){
                string[] moneyVal2;
                double moneyVal12, afterPoint2;
                try{
                    moneyVal2 = sdr["moneyVal"].ToString().Split(',');
                    moneyVal12 = Convert.ToDouble(moneyVal2[0]);
                    afterPoint2 = Convert.ToDouble(moneyVal2[1]);
                }
                catch (Exception){
                    moneyVal12 = Convert.ToDouble(sdr["moneyVal"].ToString());
                    afterPoint2 = 0;
                    //throw;
                }
                sumMoney += moneyVal12 + (afterPoint2 / 100);
            }
            sdr.Close();
            if (sumMoney < moneyVal) returnedVal = false;
            else returnedVal = true;

            return returnedVal;
        }

        private void cashOutflowForm_Load(object sender, EventArgs e)
        {
            this.StyleManager = metroStyleManager1;
            theme = funcs.themeChanger(0);

            if (theme == "light"){
                metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Light;
                moneyNumberToWordRichText.BackColor = Color.WhiteSmoke;
                moneyNumberToWordRichText.ForeColor = Color.Black;

                helpPictureBox.Image = alacakVerecekTakip.Properties.Resources.help;
            }
            else{
                metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
                moneyNumberToWordRichText.BackColor = Color.FromArgb(17, 17, 17);
                moneyNumberToWordRichText.ForeColor = Color.FromArgb(170, 170, 170);

                helpPictureBox.Image = alacakVerecekTakip.Properties.Resources.helpWhite;
            }

            if (funcs.isConnect(baglanti) == true){
                connectSituation.BackColor = Color.Lime;
                funcs.setToolTip(connectSituation, "Veri Tabanı Bağlantısı Var");
            }
            else{
                MetroFramework.MetroMessageBox.Show(this, "Veri Tabanı Bağlantısı Kurulamadığından Dolayı Program Kapatılıyor..", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            funcs.setToolTip(helpPictureBox, "Pencere açıldığında ilk önce parayı eklemek\nistediğiniz bankayı seçiniz. Banka türünü seçmeden\nbaşka işlem yapılamaz. Daha sonra eklemek istediğniz\npara türünü seçiniz.Para türünü seçtikten sonra\nmiktarı girebileciğiniz kısım aktif olacaktır.Eklemek istediğiniz\ntutarı giriniz. Eğer küsürat girmek istiyorsanız ',' koyunuz\nve sadece 0-99 arası bir sayı giriniz. Daha sonra para miktarının\nyanında ki butona basınız ve girdiğiniz miktarın doğru\nolup olmadığını kontrol ediniz. Eğer her şey doğru\ngirmişseniz 'EKLE' butonuna basarak para ekleme\nişlemini sonlandırın. ");

            fillBankTypesCombo();
            fillMoneyTypesCombo();
        }

        private void bankTypesCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            saveButton.Enabled = false;
            saveButton.BackColor = Color.FromArgb(170, 170, 170);
            if (bankTypesCombo.SelectedItem.ToString() != ""){
                bankTypesCombo.ForeColor = Color.Black;
                moneyTypesCombo.Enabled = true;
            }
        }

        private void moneyTypesCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            saveButton.Enabled = false;
            saveButton.BackColor = Color.FromArgb(170, 170, 170);
            if (moneyTypesCombo.SelectedItem.ToString() != ""){
                moneyTypesCombo.ForeColor = Color.Black;
                addMoneyCountText.Enabled = true;
                OKButton.Enabled = true;
                OKButton.BackColor = Color.FromArgb(0, 174, 219);
            }
        }

        bool pressThePoint = false;
        int digitAfterThePoint = 0;
        private void addMoneyCountText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)44){
                e.Handled = true;
            }
            if (e.KeyChar == (char)08){
                addMoneyCountText.Text = "";
                digitAfterThePoint = 0;
                pressThePoint = false;
            }
            else{
                if (pressThePoint){
                    if (digitAfterThePoint < 2 && e.KeyChar != (char)44){
                        digitAfterThePoint++;
                    }
                    else e.Handled = true;
                }
                if (e.KeyChar == (char)44) pressThePoint = true;
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (addMoneyCountText.Text != ""){
                string[] moneyVal;
                double moneyVal1, afterPoint;
                try{
                    moneyVal = addMoneyCountText.Text.Split(',');
                    moneyVal1 = Convert.ToDouble(moneyVal[0]);
                    afterPoint = Convert.ToDouble(moneyVal[1]);
                }
                catch (Exception){
                    moneyVal1 = Convert.ToDouble(addMoneyCountText.Text);
                    afterPoint = 0;
                    //throw;
                }


                if (moneyVal1 > 99999999) MetroFramework.MetroMessageBox.Show(this, "Bir kerede en fazla 99.999.999,00 " + " lira" + " ekleyebilirsiniz.", "BİLGİ!!!", MessageBoxButtons.OK);
                else{
                    if (afterPoint == 0) moneyNumberToWordRichText.Text = debtTransactionFuncs.translateNumberToWord(moneyVal1) + " " + (moneyTypesCombo.SelectedItem.ToString()).ToLowerInvariant() + " sıfır kuruş";
                    else moneyNumberToWordRichText.Text = debtTransactionFuncs.translateNumberToWord(moneyVal1) + " " + (moneyTypesCombo.SelectedItem.ToString()).ToLowerInvariant() + " " + debtTransactionFuncs.translateNumberToWord(afterPoint) + " kuruş";

                    saveButton.Enabled = true;
                    saveButton.BackColor = Color.FromArgb(0, 174, 219);
                    saveButton.ForeColor = Color.White;

                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string[] moneyVal;
            double moneyVal1, afterPoint;
            try{
                moneyVal = addMoneyCountText.Text.Split(',');
                moneyVal1 = Convert.ToDouble(moneyVal[0]);
                afterPoint = Convert.ToDouble(moneyVal[1]);
            }
            catch (Exception){
                moneyVal1 = Convert.ToDouble(addMoneyCountText.Text);
                afterPoint = 0;
                //throw;
            }
            
            if (doesItHaveEnoughMoney(bankTypesCombo.SelectedItem.ToString(), moneyTypesCombo.SelectedItem.ToString(), (moneyVal1 + (afterPoint / 100)))){
                DialogResult isSure = MetroFramework.MetroMessageBox.Show(this, "'" + bankTypesCombo.SelectedItem.ToString() + "' adlı bankadan '" + (moneyVal1 + (afterPoint / 100)) + "(" + moneyNumberToWordRichText.Text + ")' çıkarmak istiyor musunuz?", "DİKKAT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (isSure == DialogResult.Yes){
                    if (minusMoneyValToBankAccount(bankTypesCombo.SelectedItem.ToString(), moneyTypesCombo.SelectedItem.ToString(), (moneyVal1 + (afterPoint / 100)))){
                        MetroFramework.MetroMessageBox.Show(this, "Para çıkarıldı...", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        funcs.addHistory("'" + bankTypesCombo.SelectedItem.ToString() + "' adlı bankadan '" + (moneyVal1 + (afterPoint / 100)) + "(" + moneyNumberToWordRichText.Text + ")' çıkarıldı.", 3);
                        if (anasayfa.mainpagePanel1.Controls.Contains(cashBalanceUserControl.Instance)){
                            anasayfa.mainpagePanel1.Controls.Clear();
                            cashBalanceUserControl.reloadForm();
                            anasayfa.mainpagePanel1.Controls.Add(cashBalanceUserControl.Instance);
                        }
                        else if (anasayfa.mainpagePanel1.Controls.Contains(showCurrenctAccountsUserControl.Instance)){
                            anasayfa.mainpagePanel1.Controls.Clear();
                            showCurrenctAccountsUserControl.reloadForm();
                            anasayfa.mainpagePanel1.Controls.Add(showCurrenctAccountsUserControl.Instance);
                        }
                    }
                    else MetroFramework.MetroMessageBox.Show(this, "Para çıkarılımadı...", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else{
                MetroFramework.MetroMessageBox.Show(this, "Bu işlemi yapmak için yeterli bakiyeniz yok...", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                funcs.addHistory("'Kasa Para Çıkışı' işlemi yeterli bakiye olmadığı için iptal edildi.", 3);
            }
        }
    }
}

