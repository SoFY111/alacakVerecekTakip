using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace alacakVerecekTakip
{
    public partial class addChequeForm : MetroFramework.Forms.MetroForm
    {
        public addChequeForm()
        {
            InitializeComponent();
        }

        methods funcs = new methods();
        SqlConnection baglanti = methods.baglanti;
        public static string companyName;
        static int chequeTransactionsType;
        string theme;

        private void fillBankOfChequeCombo()
        {
            SqlCommand fillBankOfChequeComboCommand = new SqlCommand("SELECT * FROM bankTypes", baglanti);
            SqlDataReader sdr = fillBankOfChequeComboCommand.ExecuteReader();
            while (sdr.Read())
            {
                bankChequeCombo.Items.Add(sdr["bankTypeName"]);
            }
            sdr.Close();
            bankChequeCombo.SelectedIndex = 0;
        }

        private void fillMoneyTypesCombo()
        {
            SqlCommand fillBankOfChequeComboCommand = new SqlCommand("SELECT * FROM moneyTypesTable", baglanti);
            SqlDataReader sdr = fillBankOfChequeComboCommand.ExecuteReader();
            while (sdr.Read())
            {
                moneyTypesCombo.Items.Add(sdr["moneyName"]);
            }
            sdr.Close();
            moneyTypesCombo.SelectedIndex = 0;
        }

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

        private bool addCheque(string chequeBankType, string chequeMoneyType, int chequeBankCode, double chequeVal, DateTime chequeDrawingDate, string chequeDrawingName, string chequeRecipientName, int chequeTransactionsType)
        {
            /*
             * chequeTransaction => 0 Çek zamanı geçmiş
             * chequeTransaction => 1 Çek zamanı gelmemiş
             * chequeTransaction => 2 Çek verilmiş
             * chequeTransaction => 3 Çek başkasına verilerek borç kapatılmış
             * 
             * */

            int bankId = bankNametoId(chequeBankType), moneyId = moneyNametoId(chequeMoneyType);
            string[] cleanDate1 = chequeDrawingDate.ToString().Split(' ');
            string[] cleanDate2 = cleanDate1[0].Split('.');
            string cleanDate3 = cleanDate2[2] + "-" + cleanDate2[1] + "-" + cleanDate2[0] + " 00:00:00.00";
            SqlCommand addChequeCommand = new SqlCommand("INSERT INTO chequeInfo VALUES(@chequeBankId, @chequeMoneyId, @chequeBankCode, @chequeVal, @chequeDrawingDate, @chequeDrawingName, @chequeRecipientName, @chequeTransactions)", baglanti);
            addChequeCommand.Parameters.AddWithValue("@chequeBankId", bankId);
            addChequeCommand.Parameters.AddWithValue("@chequeMoneyId", moneyId);
            addChequeCommand.Parameters.AddWithValue("@chequeBankCode", chequeBankCode);
            addChequeCommand.Parameters.AddWithValue("@chequeVal", chequeVal);
            addChequeCommand.Parameters.AddWithValue("@chequeDrawingDate", Convert.ToDateTime(cleanDate3));
            addChequeCommand.Parameters.AddWithValue("@chequeDrawingName", chequeDrawingName);
            addChequeCommand.Parameters.AddWithValue("@chequeRecipientName", chequeRecipientName);
            addChequeCommand.Parameters.AddWithValue("@chequeTransactions", chequeTransactionsType);
            int retAddChequeCommandVal = addChequeCommand.ExecuteNonQuery();
            if (retAddChequeCommandVal == 1) return true;
            else return false;
        }

        private int bankNametoId(string bankName)
        {
            int bankId = 0;
            SqlCommand bankNametoIdCommand = new SqlCommand("SELECT * FROM bankTypes WHERE bankTypeName = @bankTypeName", baglanti);
            bankNametoIdCommand.Parameters.AddWithValue("@bankTypeName", bankName);
            SqlDataReader sdr = bankNametoIdCommand.ExecuteReader();
            while (sdr.Read())
            {
                bankId = Convert.ToInt32(sdr["bankTypeId"]);
            }
            sdr.Close();
            return bankId;
        }
        private int moneyNametoId(string moneyTypeName)
        {
            int moneyId = 0;
            SqlCommand bankNametoIdCommand = new SqlCommand("SELECT * FROM moneyTypesTable WHERE moneyName = @moneyTypeName", baglanti);
            bankNametoIdCommand.Parameters.AddWithValue("@moneyTypeName", moneyTypeName);
            SqlDataReader sdr = bankNametoIdCommand.ExecuteReader();
            while (sdr.Read())
            {
                moneyId = Convert.ToInt32(sdr["moneyId"]);
            }
            sdr.Close();
            return moneyId;
        }

        private void addChequeForm_Load(object sender, EventArgs e)
        {
            this.StyleManager = metroStyleManager1;
            theme = funcs.themeChanger(0);

            if (theme == "light")
            {
                metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Light;
                moneyNumberToWordRichText.BackColor = Color.WhiteSmoke;
                moneyNumberToWordRichText.ForeColor = Color.Black;

                helpPictureBox.Image = alacakVerecekTakip.Properties.Resources.help;
            }
            else
            {
                metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
                moneyNumberToWordRichText.BackColor = Color.FromArgb(17, 17, 17);
                moneyNumberToWordRichText.ForeColor = Color.FromArgb(170, 170, 170);

                helpPictureBox.Image = alacakVerecekTakip.Properties.Resources.helpWhite;
            }

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

            chequeTransactionsType = chequeTransactionsForm.chequeTransactionsType;

            fillBankOfChequeCombo();
            fillMoneyTypesCombo();
        }

        private void bankOfChequeCodeText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08)
            {
                e.Handled = true;
            }
        }

        bool pressThePoint = false;
        int digitAfterThePoint = 0;

        private void chequeValText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)44)
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)08)
            {
                chequeValText.Text = "";
                digitAfterThePoint = 0;
                pressThePoint = false;
            }
            else
            {
                if (pressThePoint)
                {
                    if (digitAfterThePoint < 2 && e.KeyChar != (char)44)
                    {
                        digitAfterThePoint++;
                    }
                    else e.Handled = true;
                }
                if (e.KeyChar == (char)44) pressThePoint = true;
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (chequeValText.Text != "")
            {
                string[] moneyVal;
                double moneyVal1, afterPoint;
                try
                {
                    moneyVal = chequeValText.Text.Split(',');
                    moneyVal1 = Convert.ToDouble(moneyVal[0]);
                    afterPoint = Convert.ToDouble(moneyVal[1]);
                }
                catch (Exception)
                {
                    moneyVal1 = Convert.ToDouble(chequeValText.Text);
                    afterPoint = 0;
                    //throw;
                }

                if (moneyVal1 > 99999999) MetroFramework.MetroMessageBox.Show(this, "Bir kerede en fazla 99.999.999 " + " lira" + " ekleyebilirsiniz.", "BİLGİ!!!", MessageBoxButtons.OK);
                else
                {
                    if (afterPoint == 0) moneyNumberToWordRichText.Text = translateNumberToWord(moneyVal1) + " " + (moneyTypesCombo.SelectedItem.ToString()).ToLowerInvariant() + " sıfır kuruş";
                    else moneyNumberToWordRichText.Text = translateNumberToWord(moneyVal1) + " " + (moneyTypesCombo.SelectedItem.ToString()).ToLowerInvariant() + " " + translateNumberToWord(afterPoint) + " kuruş";
                }
                drawingDateTime.Enabled = true;
            }
        }

        private void chequeValText_TextChanged(object sender, EventArgs e)
        {
            if (chequeValText.Text != "")
            {
                OKButton.Enabled = true;
                OKButton.BackColor = Color.FromArgb(0, 174, 219);
                OKButton.ForeColor = Color.White;
            }
            else
            {
                OKButton.Enabled = false;
                OKButton.BackColor = Color.Silver;
                OKButton.ForeColor = Color.White;
            }

            if (chequeValText.Text == "") drawingDateTime.Enabled = false;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string[] moneyVal;
            double moneyVal1, afterPoint;
            try
            {
                moneyVal = chequeValText.Text.Split(',');
                moneyVal1 = Convert.ToDouble(moneyVal[0]);
                afterPoint = Convert.ToDouble(moneyVal[1]);
            }
            catch (Exception)
            {
                moneyVal1 = Convert.ToDouble(chequeValText.Text);
                afterPoint = 0;
                //throw;
            }

            DialogResult isSure = MetroFramework.MetroMessageBox.Show(this, "'" + bankChequeCombo.SelectedItem.ToString() + "' adlı bankaya '" + (moneyVal1 + (afterPoint / 100)) + "(" + moneyNumberToWordRichText.Text + ")' değerinde çek almak istiyor musunuz?", "DİKKAT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (isSure == DialogResult.Yes)
            {
                if (addCheque(bankChequeCombo.SelectedItem.ToString(), moneyTypesCombo.SelectedItem.ToString(), Convert.ToInt32(chequeBankCodeText.Text), (moneyVal1 + (afterPoint / 100)), drawingDateTime.Value, drawingNameText.Text, recipientNameText.Text, chequeTransactionsType))
                {
                    MetroFramework.MetroMessageBox.Show(this, "Çek eklendi...", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    funcs.addHistory("'" + bankChequeCombo.SelectedItem.ToString() + "' adlı bankaya '" + (moneyVal1 + (afterPoint / 100)) + "(" + moneyNumberToWordRichText.Text + ")' değerinde '" + drawingNameText.Text + "' adlı kişisinden çek alındı.", 2);
                    if (anasayfa.mainpagePanel1.Controls.Contains(showChequesUserControl.Instance))
                    {
                        anasayfa.mainpagePanel1.Controls.Clear();
                        showChequesUserControl.reloadForm();
                        anasayfa.mainpagePanel1.Controls.Add(showChequesUserControl.Instance);
                    }
                }
                else MetroFramework.MetroMessageBox.Show(this, "Çek alınamadı...", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void drawingDateTime_ValueChanged(object sender, EventArgs e)
        {
            if (drawingDateTime.Value < DateTime.Now)
            {
                drawingDateTime.Value = DateTime.Now;
                MetroFramework.MetroMessageBox.Show(this, "Çek tarihi bugünden daha eski bir tarih olamaz.", "DİKKAT!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void drawingNameText_TextChanged(object sender, EventArgs e)
        {
            if (drawingNameText.Text != "" && recipientNameText.Text != "")
            {
                saveButton.Enabled = true;
                saveButton.BackColor = Color.FromArgb(0, 174, 219);
            }
            else
            {
                saveButton.Enabled = false;
                saveButton.BackColor = Color.FromArgb(170, 170, 170);
            }
        }

        private void recipientNameText_TextChanged(object sender, EventArgs e)
        {
            if (recipientNameText.Text != "" && drawingNameText.Text != "")
            {
                saveButton.Enabled = true;
                saveButton.BackColor = Color.FromArgb(0, 174, 219);
            }
            else
            {
                saveButton.Enabled = false;
                saveButton.BackColor = Color.FromArgb(170, 170, 170);
            }
        }
    }
}
