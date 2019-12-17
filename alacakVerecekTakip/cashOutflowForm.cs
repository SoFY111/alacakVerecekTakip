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
        SqlConnection baglanti = methods.baglanti;
        public static string companyName;
        string theme;

        private string translateNumberToWord(double moneyVal1)
        {
            string sTutar = Convert.ToInt32(moneyVal1).ToString("F2").Replace('.', ','); // Replace('.',',') ondalık ayracının . olma durumu için            
            string lira = sTutar.Substring(0, sTutar.IndexOf(',')); //tutarın tam kısmı
            string kurus = sTutar.Substring(sTutar.IndexOf(',') + 1, 2);
            string yazi = "";

            string[] birler = { "", "bir", "iki", "üç", "dört", "beş", "altı", "yedi", "sekiz", "dokuz" };
            string[] onlar = { "", "on", "yirmi", "otuz", "kırk", "elli", "altmış", "yetmiş", "seksen", "doksan" };
            string[] binler = { "katrilyon", "trilyon", "milyar", "milyon", "bin", "" }; //KATRİLYON'un önüne ekleme yapılarak artırabilir.

            int grupSayisi = 6;
            lira = lira.PadLeft(grupSayisi * 3, '0');
            string grupDegeri;

            for (int i = 0; i < grupSayisi * 3; i += 3)
            {
                grupDegeri = "";

                if (lira.Substring(i, 1) != "0") grupDegeri += birler[Convert.ToInt32(lira.Substring(i, 1))] + "yüz"; //yüzler                
                if (grupDegeri == "biryüz") grupDegeri = "yüz";

                grupDegeri += onlar[Convert.ToInt32(lira.Substring(i + 1, 1))]; //onlar
                grupDegeri += birler[Convert.ToInt32(lira.Substring(i + 2, 1))]; //birler                

                if (grupDegeri != "") grupDegeri += binler[i / 3];
                if (grupDegeri == "birbin") grupDegeri = "bin";

                if (grupDegeri != "") yazi += grupDegeri + " ";
            }
            return yazi;
        }

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

            int bankTypeId = bankNameToBankId(bankName);
            int moneyTypeId = moneyNameToMoneyId(moneyTypeName);
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

        private int bankNameToBankId(string bankName)
        {
            int bankId = 0;
            SqlCommand bankNameToBankIdCommand = new SqlCommand("SELECT * FROM bankTypes WHERE bankTypeName = @bankName", baglanti);
            bankNameToBankIdCommand.Parameters.AddWithValue("@bankName", bankName);
            SqlDataReader sdr = bankNameToBankIdCommand.ExecuteReader();
            while (sdr.Read()){
                bankId = Convert.ToInt32(sdr["bankTypeId"]);
            }
            sdr.Close();
            return bankId;
        }

        private int moneyNameToMoneyId(string moneyTypeName)
        {
            int moneyTypeId = 0;
            SqlCommand moneyNameToMoneyIdCommand = new SqlCommand("SELECT * FROM moneyTypesTable WHERE moneyName = @moneyTypeName", baglanti);
            moneyNameToMoneyIdCommand.Parameters.AddWithValue("@moneyTypeName", moneyTypeName);
            SqlDataReader sdr = moneyNameToMoneyIdCommand.ExecuteReader();
            while (sdr.Read()){
                moneyTypeId = Convert.ToInt32(sdr["moneyId"]);
            }
            sdr.Close();
            return moneyTypeId;
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
                    if (afterPoint == 0) moneyNumberToWordRichText.Text = translateNumberToWord(moneyVal1) + " " + (moneyTypesCombo.SelectedItem.ToString()).ToLowerInvariant() + " sıfır kuruş";
                    else moneyNumberToWordRichText.Text = translateNumberToWord(moneyVal1) + " " + (moneyTypesCombo.SelectedItem.ToString()).ToLowerInvariant() + " " + translateNumberToWord(afterPoint) + " kuruş";

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
                }
                else MetroFramework.MetroMessageBox.Show(this, "Para çıkarılımadı...", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
