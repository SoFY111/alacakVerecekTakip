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
        debtTransactionsMethods debtTransactionFuncs = new debtTransactionsMethods();
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

        private bool addCheque(string chequeBankType, string chequeMoneyType, int chequeBankCode, double chequeVal, DateTime chequeDrawingDate, string chequeDrawingName, string chequeRecipientName, int chequeTransactionsType)
        {
            /*
             * chequeTransaction => 0 Çek zamanı geçmiş
             * chequeTransaction => 1 Çek zamanı gelmemiş
             * chequeTransaction => 2 Çek verilmiş
             * chequeTransaction => 3 Çek başkasına verilerek borç kapatılmış
             * 
             * */

            int bankId = debtTransactionFuncs.bankNameToId(chequeBankType), moneyId = debtTransactionFuncs.moneyNameToId(chequeMoneyType);
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

        private bool doesItHaveEnoughMoney(string bankTypeName, string moneyTypeName, double moneyVal)
        {
            bool returnedVal = false;
            int bankId = debtTransactionFuncs.bankNameToId(bankTypeName), moneyId = debtTransactionFuncs.moneyNameToId(moneyTypeName);
            double sumMoney = 0;
            SqlCommand sumMoneyCommand = new SqlCommand("SELECT * FROM moneyFunds WHERE bankId = @bankId AND moneyTypeId = @moneyId", baglanti);
            sumMoneyCommand.Parameters.AddWithValue("@bankId", bankId);
            sumMoneyCommand.Parameters.AddWithValue("@moneyId", moneyId);
            SqlDataReader sdr = sumMoneyCommand.ExecuteReader();
            while (sdr.Read())
            {
                string[] moneyVal2;
                double moneyVal12, afterPoint2;
                try
                {
                    moneyVal2 = sdr["moneyVal"].ToString().Split(',');
                    moneyVal12 = Convert.ToDouble(moneyVal2[0]);
                    afterPoint2 = Convert.ToDouble(moneyVal2[1]);
                }
                catch (Exception)
                {
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
            if (chequeTransactionsType == 1) this.Text += "Verme";
            else if (chequeTransactionsType == 2) this.Text += "Alma";
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
                    if (afterPoint == 0) moneyNumberToWordRichText.Text = debtTransactionFuncs.translateNumberToWord(moneyVal1) + " " + (moneyTypesCombo.SelectedItem.ToString()).ToLowerInvariant() + " sıfır kuruş";
                    else moneyNumberToWordRichText.Text = debtTransactionFuncs.translateNumberToWord(moneyVal1) + " " + (moneyTypesCombo.SelectedItem.ToString()).ToLowerInvariant() + " " + debtTransactionFuncs.translateNumberToWord(afterPoint) + " kuruş";
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
            if (doesItHaveEnoughMoney(bankChequeCombo.SelectedItem.ToString(), moneyTypesCombo.SelectedItem.ToString(), (moneyVal1 + (afterPoint / 100)))){
                DialogResult isSure = MetroFramework.MetroMessageBox.Show(this, "'" + bankChequeCombo.SelectedItem.ToString() + "' adlı bankaya '" + (moneyVal1 + (afterPoint / 100)) + "(" + moneyNumberToWordRichText.Text + ")' değerinde çek almak istiyor musunuz?", "DİKKAT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (isSure == DialogResult.Yes)
                {
                    if (addCheque(bankChequeCombo.SelectedItem.ToString(), moneyTypesCombo.SelectedItem.ToString(), Convert.ToInt32(chequeBankCodeText.Text), (moneyVal1 + (afterPoint / 100)), drawingDateTime.Value, drawingNameText.Text, recipientNameText.Text, chequeTransactionsType))
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Çek eklendi...", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (chequeTransactionsType == 1)
                        {
                            funcs.addHistory("'" + bankChequeCombo.SelectedItem.ToString() + "' adlı bankaya '" + (moneyVal1 + (afterPoint / 100)) + "(" + moneyNumberToWordRichText.Text + ")' değerinde '" + drawingNameText.Text + "' adlı kişisinden çek alındı.", 2);
                        }
                        else
                        {
                            funcs.addHistory("'" + bankChequeCombo.SelectedItem.ToString() + "' adlı bankadan '" + (moneyVal1 + (afterPoint / 100)) + "(" + moneyNumberToWordRichText.Text + ")' değerinde '" + recipientNameText.Text + "' adlı kişiye çek verildi.", 2);

                        }
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
            else MetroFramework.MetroMessageBox.Show(this, "Bankada yeterli bakiyeniz olmadığı için çek verilmedi...", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
