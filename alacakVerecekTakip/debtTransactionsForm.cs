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
    public partial class debtTransactionsForm : MetroFramework.Forms.MetroForm
    {
        public debtTransactionsForm()
        {
            InitializeComponent();
        }

        methods funcs = new methods();
        debtTransactionsMethods debtTransactionFuncs = new debtTransactionsMethods();
        SqlConnection baglanti = methods.baglanti;
        public static int transactionType = 0;
        string theme;

        private void fillCustomersCombo()
        {
            SqlCommand fillCustomersComboCommand = new SqlCommand("SELECT * FROM customers ORDER BY customerName", baglanti);
            SqlDataReader sdr = fillCustomersComboCommand.ExecuteReader();
            while (sdr.Read())
            {
                customersCombo.Items.Add(sdr["customerName"].ToString() + " " + sdr["customerSurname"].ToString());
            }
            sdr.Close();
            customersCombo.SelectedIndex = 0;
        }

        private void fillBankTypesCombo()
        {
            SqlCommand fillBankTypesComboCommand = new SqlCommand("SELECT * FROM bankTypes ORDER BY bankTypeName", baglanti);
            SqlDataReader sdr = fillBankTypesComboCommand.ExecuteReader();
            while (sdr.Read())
            {
                bankTypesCombo.Items.Add(sdr["bankTypeName"].ToString());
            }
            sdr.Close();
            bankTypesCombo.SelectedIndex = 0;
        }

        private void fillMoneyTypesCombo()
        {
            SqlCommand fillMoneyTypesComboCommand = new SqlCommand("SELECT * FROM moneyTypesTable ORDER BY moneyName", baglanti);
            SqlDataReader sdr = fillMoneyTypesComboCommand.ExecuteReader();
            while (sdr.Read())
            {
                moneyTypesCombo.Items.Add(sdr["moneyName"].ToString());
            }
            sdr.Close();
            moneyTypesCombo.SelectedIndex = 0;
        }

        private void fillInstallmentCountCombo()
        {
            SqlCommand fillInstallmentCountComboCommand = new SqlCommand("SELECT * FROM installmentCount ORDER BY installmentCount", baglanti);
            SqlDataReader sdr = fillInstallmentCountComboCommand.ExecuteReader();
            while (sdr.Read())
            {
                installmentCountCombo.Items.Add(sdr["installmentCount"].ToString());
            }
            sdr.Close();
            installmentCountCombo.SelectedIndex = 0;
        }

        private bool addDebtORDebtor(int transactionType, int installmentType, int installmentCount, string customerName, string bankTypeName, string moneyTypeName, double moneyVal, DateTime dateTime)
        {
            /*
             * 
             * transactionType => 0:Borç Alma
             * transactionType => 1:Borç Verme
             * 
             * installmentType => 0:Peşin
             * installmentType => 1:Taksit
             * 
             * */
            bool returnedVal = false;
            int bankId = debtTransactionFuncs.bankNameToId(bankTypeName), moneyId = debtTransactionFuncs.moneyNameToId(moneyTypeName), customerId = customerNameToCustomerId(customerName);
            DateTime time = DateTime.Now;
            string nowTime = time.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss");
            string[] cleanDate1 = dateTime.ToString().Split(' ');
            string[] cleanDate2 = cleanDate1[0].Split('.');
            string cleanDate3 = cleanDate2[2] + "-" + cleanDate2[1] + "-" + cleanDate2[0] + " 00:00:00.00";
            SqlCommand addDebtORDebtorTransactionsTableCommand = new SqlCommand("INSERT INTO customersTransactionType VALUES(@customerId, @transactionType, @transactionDate, @isPaid)", baglanti);
            addDebtORDebtorTransactionsTableCommand.Parameters.AddWithValue("@customerId", customerId);
            addDebtORDebtorTransactionsTableCommand.Parameters.AddWithValue("@transactionType", transactionType);
            addDebtORDebtorTransactionsTableCommand.Parameters.AddWithValue("@transactionDate", Convert.ToDateTime(nowTime)); ;
            addDebtORDebtorTransactionsTableCommand.Parameters.AddWithValue("@isPaid", 0); ;
            int retAddDebtORDebtorTransactionsTableCommandVal = addDebtORDebtorTransactionsTableCommand.ExecuteNonQuery();
            if (retAddDebtORDebtorTransactionsTableCommandVal == 1)
            {
                int lastTransactionId = findLastTransactionId();
                if (transactionType == 0)
                {
                    SqlCommand addDebtORDebtorCommand = new SqlCommand("INSERT INTO customersMyDebt VALUES(@customerId, @transactionTypeId, @debtType, @debtVal, @debtPaymentVal, @debtMoneyTypeId, @debtBankTypeId, @debtDate, @debtMinPaymentDate, @isPaid, @debtPaymentDate)", baglanti);
                    addDebtORDebtorCommand.Parameters.AddWithValue("@customerId", customerId);
                    addDebtORDebtorCommand.Parameters.AddWithValue("@transactionTypeId", lastTransactionId);
                    addDebtORDebtorCommand.Parameters.AddWithValue("@debtType", installmentType);
                    addDebtORDebtorCommand.Parameters.AddWithValue("@debtVal", moneyVal);
                    addDebtORDebtorCommand.Parameters.AddWithValue("@debtPaymentVal", 0);
                    addDebtORDebtorCommand.Parameters.AddWithValue("@debtMoneyTypeId", moneyId);
                    addDebtORDebtorCommand.Parameters.AddWithValue("@debtBankTypeId", bankId);
                    addDebtORDebtorCommand.Parameters.AddWithValue("@debtDate", Convert.ToDateTime(nowTime));
                    addDebtORDebtorCommand.Parameters.AddWithValue("@debtMinPaymentDate", Convert.ToDateTime(cleanDate3));
                    addDebtORDebtorCommand.Parameters.AddWithValue("@isPaid", 0);
                    addDebtORDebtorCommand.Parameters.AddWithValue("@debtPaymentDate", Convert.ToDateTime("2000-01-1 00:00:00.00"));
                    int retAddDebtORDebtorCommandVal = addDebtORDebtorCommand.ExecuteNonQuery();
                    if (retAddDebtORDebtorCommandVal == 1)
                    {
                        if (installmentType == 1)
                        {
                            double minInstallmentVal = moneyVal / installmentCount;

                            for (int i = 0; i < installmentCount; i++)
                            {
                                SqlCommand addInstallmentTableCommand = new SqlCommand("INSERT INTO customersInstallment VALUES(@customerId, @transactionTypeId, @installmentCount, @installmentPaymentCounter, @installmentMinPaymentVal, @installmentPaymentVal, @installmentMinPaymentDate, @installmentPaymentDate, @isPaid)", baglanti);
                                addInstallmentTableCommand.Parameters.AddWithValue("@customerId", customerId);
                                addInstallmentTableCommand.Parameters.AddWithValue("@transactionTypeId", lastTransactionId);
                                addInstallmentTableCommand.Parameters.AddWithValue("@installmentCount", installmentCount);
                                addInstallmentTableCommand.Parameters.AddWithValue("@installmentPaymentCounter", i + 1);
                                addInstallmentTableCommand.Parameters.AddWithValue("@installmentMinPaymentVal", minInstallmentVal);
                                addInstallmentTableCommand.Parameters.AddWithValue("@installmentPaymentVal", 0);
                                addInstallmentTableCommand.Parameters.AddWithValue("@installmentMinPaymentDate", (Convert.ToDateTime(cleanDate3).AddMonths(i)));
                                addInstallmentTableCommand.Parameters.AddWithValue("@installmentPaymentDate", Convert.ToDateTime("2000-01-1 00:00:00.00"));
                                addInstallmentTableCommand.Parameters.AddWithValue("@isPaid", 0);

                                int retAddInstallmentTableCommandVal = addInstallmentTableCommand.ExecuteNonQuery();
                                if (retAddInstallmentTableCommandVal == 1) returnedVal = true;
                                else returnedVal = false;
                            }
                        }
                        else returnedVal = true;
                    }
                    else returnedVal = false;
                }
                else
                {
                    SqlCommand addDebtORDebtorCommand = new SqlCommand("INSERT INTO customersDebtor VALUES(@customerId, @transactionId, @debtType, @debtVal, @debtPaymentVal, @debtMoneyTypeId, @debtBankTypeId, @debtDate, @debtMinPaymentDate, @isPaid, @debtPaymentDate)", baglanti);
                    addDebtORDebtorCommand.Parameters.AddWithValue("@customerId", customerId);
                    addDebtORDebtorCommand.Parameters.AddWithValue("@transactionId", lastTransactionId);
                    addDebtORDebtorCommand.Parameters.AddWithValue("@debtType", installmentType);
                    addDebtORDebtorCommand.Parameters.AddWithValue("@debtVal", moneyVal);
                    addDebtORDebtorCommand.Parameters.AddWithValue("@debtPaymentVal", 0);
                    addDebtORDebtorCommand.Parameters.AddWithValue("@debtMoneyTypeId", moneyId);
                    addDebtORDebtorCommand.Parameters.AddWithValue("@debtBankTypeId", bankId);
                    addDebtORDebtorCommand.Parameters.AddWithValue("@debtDate", Convert.ToDateTime(nowTime));
                    addDebtORDebtorCommand.Parameters.AddWithValue("@debtMinPaymentDate", Convert.ToDateTime(cleanDate3));
                    addDebtORDebtorCommand.Parameters.AddWithValue("@isPaid", 0);
                    addDebtORDebtorCommand.Parameters.AddWithValue("@debtPaymentDate", Convert.ToDateTime("2000-01-1 00:00:00.00"));
                    int retAddDebtORDebtorCommandVal = addDebtORDebtorCommand.ExecuteNonQuery();
                    if (retAddDebtORDebtorCommandVal == 1)
                    {
                        if (installmentType == 1)
                        {
                            double minInstallmentVal = moneyVal / installmentCount;

                            for (int i = 0; i < installmentCount; i++)
                            {
                                SqlCommand addInstallmentTableCommand = new SqlCommand("INSERT INTO customersInstallment VALUES(@customerId, @transactionTypeId, @installmentCount, @installmentPaymentCounter, @installmentMinPaymentVal, @installmentPaymentVal, @installmentMinPaymentDate, @installmentPaymentDate, @isPaid)", baglanti);
                                addInstallmentTableCommand.Parameters.AddWithValue("@customerId", customerId);
                                addInstallmentTableCommand.Parameters.AddWithValue("@transactionTypeId", lastTransactionId);
                                addInstallmentTableCommand.Parameters.AddWithValue("@installmentCount", installmentCount);
                                addInstallmentTableCommand.Parameters.AddWithValue("@installmentPaymentCounter", i + 1);
                                addInstallmentTableCommand.Parameters.AddWithValue("@installmentMinPaymentVal", minInstallmentVal);
                                addInstallmentTableCommand.Parameters.AddWithValue("@installmentPaymentVal", 0);
                                addInstallmentTableCommand.Parameters.AddWithValue("@installmentMinPaymentDate", (Convert.ToDateTime(cleanDate3).AddMonths(i)));
                                addInstallmentTableCommand.Parameters.AddWithValue("@installmentPaymentDate", Convert.ToDateTime("2000-01-1 00:00:00.00"));
                                addInstallmentTableCommand.Parameters.AddWithValue("@isPaid", 0);

                                int retAddInstallmentTableCommandVal = addInstallmentTableCommand.ExecuteNonQuery();
                                if (retAddInstallmentTableCommandVal == 1) returnedVal = true;
                                else returnedVal = false;
                            }
                        }
                        else returnedVal = true;
                    }
                    else returnedVal = false;
                }
            }
            else returnedVal = false;
            return returnedVal;
        }

        private int customerNameToCustomerId(string customerName)
        {
            int customerId = 0;
            string[] customerCleanName = customerName.Split(' ');
            SqlCommand customerNameToCustomerIdCommand = new SqlCommand("SELECT * FROM customers WHERE customerName = @customerName AND customerSurname = @customerSurname", baglanti);
            customerNameToCustomerIdCommand.Parameters.AddWithValue("@customerName", customerCleanName[0]);
            customerNameToCustomerIdCommand.Parameters.AddWithValue("@customerSurname", customerCleanName[1]);
            SqlDataReader sdr = customerNameToCustomerIdCommand.ExecuteReader();
            while (sdr.Read())
            {
                customerId = Convert.ToInt32(sdr["customerId"]);
            }
            sdr.Close();
            return customerId;
        }

        private int findLastTransactionId()
        {
            int lastTransactionId = 0;
            SqlCommand findLastTransactionIdCommand = new SqlCommand("SELECT TOP 1 * FROM customersTransactionType ORDER BY customerTransactionTypeId DESC", baglanti);
            SqlDataReader sdr = findLastTransactionIdCommand.ExecuteReader();
            while (sdr.Read())
            {
                lastTransactionId = Convert.ToInt32(sdr["customerTransactionTypeId"]);
            }
            sdr.Close();
            return lastTransactionId;
        }

        private void sellForm_Load(object sender, EventArgs e)
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

            if (metroStyleManager1.Theme == MetroFramework.MetroThemeStyle.Dark)
            {
                helpPictureBox.Image = alacakVerecekTakip.Properties.Resources.helpWhite;
                moneyNumberToWordRichText.BackColor = Color.FromArgb(17, 17, 17);
                moneyNumberToWordRichText.ForeColor = Color.FromArgb(170, 170, 170);
            }
            else
            {
                helpPictureBox.Image = alacakVerecekTakip.Properties.Resources.help;
                moneyNumberToWordRichText.BackColor = Color.WhiteSmoke;
                moneyNumberToWordRichText.ForeColor = Color.Black;
            }

            fillInstallmentCountCombo();
            fillCustomersCombo();
            fillBankTypesCombo();
            fillMoneyTypesCombo();

        }

        bool pressThePoint = false;
        int digitAfterThePoint = 0;

        private void moneyNumberToWordRichText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)44)
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)08)
            {
                moneyValText.Text = "";
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

        private void moneyValText_TextChanged(object sender, EventArgs e)
        {
            cashPaymentRadio.Checked = true;
            installmentCountCombo.SelectedIndex = 0;
            installmentCountCombo.Enabled = false;
            if (moneyValText.Text != "")
            {
                OKButton.Enabled = true;
                OKButton.BackColor = Color.FromArgb(0, 174, 219);
                OKButton.ForeColor = Color.White;

                saveButton.Enabled = true;
                saveButton.BackColor = Color.FromArgb(0, 174, 219);
                saveButton.ForeColor = Color.White;
            }
            else
            {
                OKButton.Enabled = false;
                OKButton.BackColor = Color.Silver;
                OKButton.ForeColor = Color.White;

                saveButton.Enabled = false;
                saveButton.BackColor = Color.Silver;
                saveButton.ForeColor = Color.Black;
            }

        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (moneyValText.Text != "")
            {
                string[] moneyVal;
                double moneyVal1, afterPoint;
                try
                {
                    moneyVal = moneyValText.Text.Split(',');
                    moneyVal1 = Convert.ToDouble(moneyVal[0]);
                    afterPoint = Convert.ToDouble(moneyVal[1]);
                }
                catch (Exception)
                {
                    moneyVal1 = Convert.ToDouble(moneyValText.Text);
                    afterPoint = 0;
                    //throw;
                }

                if (moneyVal1 > 99999999) MetroFramework.MetroMessageBox.Show(this, "Bir kerede en fazla 99.999.999 " + " lira" + " ekleyebilirsiniz.", "BİLGİ!!!", MessageBoxButtons.OK);
                else
                {
                    if (afterPoint == 0) moneyNumberToWordRichText.Text = debtTransactionFuncs.translateNumberToWord(moneyVal1) + " " + (moneyTypesCombo.SelectedItem.ToString()).ToLowerInvariant() + " sıfır kuruş";
                    else moneyNumberToWordRichText.Text = debtTransactionFuncs.translateNumberToWord(moneyVal1) + " " + (moneyTypesCombo.SelectedItem.ToString()).ToLowerInvariant() + " " + debtTransactionFuncs.translateNumberToWord(afterPoint) + " kuruş";
                }
                installmentCountCombo_SelectedIndexChanged(sender, e);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

            DateTime date = dateCombo.Value;
            date = date.AddMonths(Convert.ToInt32(installmentCountCombo.Text));


            string[] moneyVal;
            double moneyVal1, afterPoint;
            try
            {
                moneyVal = moneyValText.Text.Split(',');
                moneyVal1 = Convert.ToDouble(moneyVal[0]);
                afterPoint = Convert.ToDouble(moneyVal[1]);
            }
            catch (Exception)
            {
                moneyVal1 = Convert.ToDouble(moneyValText.Text);
                afterPoint = 0;
                //throw;
            }

            int installmentType = 0, installmentCount = 0;
            if (cashPaymentRadio.Checked == true) installmentType = 0;
            else if (installmentPaymentRadio.Checked == true)
            {
                installmentType = 1;
                installmentCount = Convert.ToInt32(installmentCountCombo.Text);
            }


            if (loanRadio.Checked == true) transactionType = 1;
            else if (barrowRadio.Checked == true) transactionType = 0;

            if (addDebtORDebtor(transactionType, installmentType, installmentCount, customersCombo.Text, bankTypesCombo.Text, moneyTypesCombo.Text, moneyVal1 + (afterPoint / 100), dateCombo.Value))
            {
                if (installmentType == 0)
                {
                    if (transactionType == 1)
                    {
                        MetroFramework.MetroMessageBox.Show(this, "'" + customersCombo.Text + "' adlı kişiye '" + moneyValText.Text + "(" + moneyNumberToWordRichText.Text + ")' tutarında '" + dateCombo.Value + "' tarihine kadar borç verildi..", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        funcs.addHistory("'" + customersCombo.Text + "' adlı kişiye '" + moneyValText.Text + "(" + moneyNumberToWordRichText.Text + ")' tutarında '" + dateCombo.Value + "' tarihine kadar borç verildi..", 2);
                    }
                    else
                    {
                        MetroFramework.MetroMessageBox.Show(this, "'" + customersCombo.Text + "' adlı kişiden '" + moneyValText.Text + "(" + moneyNumberToWordRichText.Text + ")' tutarında '" + dateCombo.Value + "' tarihine kadar borç alındı..", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        funcs.addHistory("'" + customersCombo.Text + "' adlı kişiden '" + moneyValText.Text + "(" + moneyNumberToWordRichText.Text + ")' tutarında '" + dateCombo.Value + "' tarihine kadar borç alındı..", 2);
                    }
                }
                else
                {
                    string[] cleanDate1 = dateCombo.Value.ToString().Split(' ');
                    string[] cleanDate2 = cleanDate1[0].Split('.');
                    if (transactionType == 1)
                    {
                        MetroFramework.MetroMessageBox.Show(this, "'" + customersCombo.Text + "' adlı kişiye '" + moneyValText.Text + "(" + moneyNumberToWordRichText.Text + ")' tutarında '" + installmentCountCombo.Text + "' ay boyunca her ayın '" + cleanDate2[0] + ".' gününde ödenmek şartıyla borç verildi..\n(Son ödeme tarihi '" + dateCombo.Value.AddMonths(Convert.ToInt32(installmentCountCombo.Text) -1) + "')", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        funcs.addHistory("'" + customersCombo.Text + "' adlı kişiye '" + moneyValText.Text + "(" + moneyNumberToWordRichText.Text + ")' tutarında '" + installmentCountCombo.Text + "' ay boyunca her ayın '" + cleanDate2[0] + ".' gününde ödenmek şartıyla borç verildi..\n(Son ödeme tarihi '" + dateCombo.Value.AddMonths(Convert.ToInt32(installmentCountCombo.Text) - 1) + "')", 2);
                    }
                    else
                    {
                        MetroFramework.MetroMessageBox.Show(this, "'" + customersCombo.Text + "' adlı kişiden '" + moneyValText.Text + "(" + moneyNumberToWordRichText.Text + ")' tutarında '" + installmentCountCombo.Text + "' ay boyunca her ayın '" + cleanDate2[0] + ".' gününde ödenmek şartıyla borç alındı..\n(Son ödeme tarihi '" + dateCombo.Value.AddMonths(Convert.ToInt32(installmentCountCombo.Text) - 1) + "')", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        funcs.addHistory("'" + customersCombo.Text + "' adlı kişiden '" + moneyValText.Text + "(" + moneyNumberToWordRichText.Text + ")' tutarında '" + installmentCountCombo.Text + "' ay boyunca her ayın '" + cleanDate2[0] + ".' gününde ödenmek şartıyla borç alındı..\n(Son ödeme tarihi '" + dateCombo.Value.AddMonths(Convert.ToInt32(installmentCountCombo.Text) - 1) + "')", 2);
                    }
                }

                if (anasayfa.mainpagePanel1.Controls.Contains(showAllCustomers.Instance))
                {
                    anasayfa.mainpagePanel1.Controls.Clear();
                    showAllCustomers.reloadForm();
                    anasayfa.mainpagePanel1.Controls.Add(showAllCustomers.Instance);
                }
            }
        }

        private void installmentPaymentRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (installmentPaymentRadio.Checked == true)
            {
                installmentCountCombo.SelectedIndex = 1;
                installmentCountCombo.Enabled = true;
            }
            else
            {
                installmentCountCombo.Enabled = false;
                installmentCountCombo.SelectedIndex = 0;
            }
        }

        private void installmentCountCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (moneyValText.Text != "")
            {
                string[] moneyVal;
                double moneyVal1, afterPoint;
                try
                {
                    moneyVal = moneyValText.Text.Split(',');
                    moneyVal1 = Convert.ToDouble(moneyVal[0]);
                    afterPoint = Convert.ToDouble(moneyVal[1]);
                }
                catch (Exception)
                {
                    moneyVal1 = Convert.ToDouble(moneyValText.Text);
                    afterPoint = 0;
                    //throw;
                }
                if (installmentCountCombo.Text == "0") monthlyPaymentLabel.Text = "Aylık ödenecek tutar " + (moneyVal1 + (afterPoint / 100)).ToString() + " " + moneyTypesCombo.SelectedText;
                else if (installmentCountCombo.Text != "0")
                {
                    double monthlyPaymentVal = (moneyVal1 + (afterPoint / 100)) / Convert.ToInt32(installmentCountCombo.Text);
                    monthlyPaymentLabel.Text = "Aylık ödenecek tutar " + monthlyPaymentVal.ToString() + " " + moneyTypesCombo.SelectedText;
                }
            }
        }
    }
}