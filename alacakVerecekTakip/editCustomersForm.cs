using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Data.SqlClient;

namespace alacakVerecekTakip
{
    public partial class editCustomersForm : MetroFramework.Forms.MetroForm
    {
        public editCustomersForm()
        {
            InitializeComponent();
        }

        methods funcs = new methods();
        debtTransactionsMethods debtTransactionFuncs = new debtTransactionsMethods();
        SqlConnection baglanti = methods.baglanti;
        string theme;
        private void fillCustomerReliabiltyCombo()
        {
            SqlCommand fillCustomerReliabiltyComboCommand = new SqlCommand("SELECT * FROM degreeOfReliabilty ORDER BY degreeOfRealiabiltyId DESC", baglanti);
            SqlDataReader sdr = fillCustomerReliabiltyComboCommand.ExecuteReader();
            while (sdr.Read())
            {
                customerReliabiltyCombo.Items.Add(sdr["degreeOfReliabiltyDiscription"].ToString());
            }
            sdr.Close();
        }

        private void fillCustomerInfo(int customerId)
        {
            string[] reliabilityTable = findReliabilityTable();
            SqlCommand fillCustomerInfoCommand = new SqlCommand("SELECT * FROM customers WHERE customerId = @customerId", baglanti);
            fillCustomerInfoCommand.Parameters.AddWithValue("@customerId", customerId);
            SqlDataReader sdr = fillCustomerInfoCommand.ExecuteReader();
            while (sdr.Read()){
                customerIdText.Text = sdr["customerId"].ToString();
                customerNameText.Text = sdr["customerName"].ToString();
                customerSurnameText.Text = sdr["customerSurname"].ToString();
                customerPhoneText.Text = sdr["customerPhone"].ToString();
                customerMailText.Text = sdr["customerMail"].ToString();
                customerAdressRichText.Text = sdr["customerAdress"].ToString();
                for (int j = 0; j < customerReliabiltyCombo.Items.Count; j++)
                {
                    string[] reliabilityTableDetail = reliabilityTable[j].Split('-');
                    customerReliabiltyCombo.SelectedIndex = j;
                    if (customerReliabiltyCombo.SelectedText == reliabilityTableDetail[1]) customerReliabiltyCombo.SelectedIndex = j;
                }
                customerPrivateSideRichText.Text = sdr["customerPrivateSide"].ToString();
            }
            sdr.Close();
        }

        private string[] findReliabilityTable()
        {
            int reliabilityCount = reliabiltyTableRowsCount(), reliabilityCount2 = 0;
            string[] reliabiltyTable = new string[reliabilityCount];

            SqlCommand findCustomerDebtValTableCommand = new SqlCommand("SELECT * FROM degreeOfReliabilty", baglanti);
            SqlDataReader sdr = findCustomerDebtValTableCommand.ExecuteReader();
            while (sdr.Read())
            {
                if (reliabilityCount2 <= reliabilityCount)
                {
                    reliabiltyTable[reliabilityCount2] = (sdr["degreeOfRealiabiltyId"].ToString()) + "-" + sdr["degreeOfReliabiltyDiscription"].ToString();
                    reliabilityCount2++;
                }
            }
            sdr.Close();
            return reliabiltyTable;
        }

        private int reliabiltyTableRowsCount()
        {
            int rowCount = 0;
            SqlCommand reliabiltyTableRowsCountCommand = new SqlCommand("SELECT * FROM degreeOfReliabilty", baglanti);
            SqlDataReader sdr = reliabiltyTableRowsCountCommand.ExecuteReader();
            while (sdr.Read())
            {
                rowCount++;
            }
            sdr.Close();
            return rowCount;
        }

        private bool saveCustomerNewInfo(string customerName, string customerSurname, string customerPhone, string customerMail, string customerAdress, string customerReliabilty, string customerPrivateSide)
        {
            int reliabiltyId = reliabiltyNameToId(customerReliabilty);
            SqlCommand updateCustomerCommand = new SqlCommand("UPDATE customers SET customerName = @customerName, customerSurname = @customerSurname, customerPhone = @customerPhone, customerMail = @customerMail, customerAdress=  @customerAdress, customerReliabilityVal = @customerRaliabilty, customerPrivateSide = @customerPrivateSide WHERE customerId = @customerId", baglanti);
            updateCustomerCommand.Parameters.AddWithValue("@customerId", showAllCustomersUserControl.selectedCustomerId);
            updateCustomerCommand.Parameters.AddWithValue("@customerName", customerName);
            updateCustomerCommand.Parameters.AddWithValue("@customerSurname", customerSurname);
            updateCustomerCommand.Parameters.AddWithValue("@customerPhone", customerPhone);
            updateCustomerCommand.Parameters.AddWithValue("@customerMail", customerMail);
            updateCustomerCommand.Parameters.AddWithValue("@customerAdress", customerAdress);
            updateCustomerCommand.Parameters.AddWithValue("@customerRaliabilty", reliabiltyId);
            updateCustomerCommand.Parameters.AddWithValue("@customerPrivateSide", customerPrivateSide);

            int retUpdateCustomerCommandVal = updateCustomerCommand.ExecuteNonQuery();
            if (retUpdateCustomerCommandVal == 1) return true;
            else return false;
        }

        private int reliabiltyNameToId(string reliabiltyName)
        {
            int degreeOfReliabiltyId = 0;
            SqlCommand reliabiltyNameToIdCommand = new SqlCommand("SELECT * FROM degreeOfReliabilty WHERE degreeOfReliabiltyDiscription = @degreeOfReliabiltyDiscription", baglanti);
            reliabiltyNameToIdCommand.Parameters.AddWithValue("@degreeOfReliabiltyDiscription", reliabiltyName);
            SqlDataReader sdr = reliabiltyNameToIdCommand.ExecuteReader();
            while (sdr.Read())
            {
                degreeOfReliabiltyId = Convert.ToInt32(sdr["degreeOfRealiabiltyId"]);
            }
            sdr.Close();
            return degreeOfReliabiltyId;
        }

        private bool customerIsAddedBefore(string customerName, string customerSurname)
        {
            bool returnedVal = false;
            SqlCommand customerIsAddedBeforeCommand = new SqlCommand("SELECT * FROM customers WHERE customerName = @customerName AND customerSurname = @customerSurname", baglanti);
            customerIsAddedBeforeCommand.Parameters.AddWithValue("@customerName", customerName);
            customerIsAddedBeforeCommand.Parameters.AddWithValue("@customerSurname", customerSurname);
            SqlDataReader sdr = customerIsAddedBeforeCommand.ExecuteReader();
            while (sdr.Read())
            {
                if(Convert.ToInt32(sdr["customerId"]) == showAllCustomersUserControl.selectedCustomerId) returnedVal = false;
                else if(Convert.ToInt32(sdr["customerId"]) != showAllCustomersUserControl.selectedCustomerId) returnedVal = true;
            }
            sdr.Close();
            return returnedVal;
        }

        private bool mailControl(string mail)
        {
            try
            {
                MailAddress m = new MailAddress(mail);
                return true;
            }
            catch (Exception)
            {
                return false;
                //throw;
            }
        }

        private void editCustomersForm_Load(object sender, EventArgs e)
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

            if (metroStyleManager1.Theme == MetroFramework.MetroThemeStyle.Dark)
            {
                customerPhoneText.BackColor = Color.FromArgb(17, 17, 17);
                customerPhoneText.ForeColor = Color.Silver;
                customerAdressRichText.BackColor = Color.FromArgb(17, 17, 17);
                customerAdressRichText.ForeColor = Color.Silver;
                customerPrivateSideRichText.BackColor = Color.FromArgb(17, 17, 17);
                customerPrivateSideRichText.ForeColor = Color.Silver;
            }
            else
            {
                customerPhoneText.BackColor = Color.White;
                customerPhoneText.ForeColor = Color.Black;
                customerAdressRichText.BackColor = Color.White;
                customerAdressRichText.ForeColor = Color.Black;
                customerPrivateSideRichText.BackColor = Color.White;
                customerPrivateSideRichText.ForeColor = Color.Black;
            }


            fillCustomerReliabiltyCombo();
            fillCustomerInfo(showAllCustomersUserControl.selectedCustomerId);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!customerIsAddedBefore(customerNameText.Text, customerSurnameText.Text))
            {
                if (mailControl(customerMailText.Text))
                {
                    if (saveCustomerNewInfo(customerNameText.Text, customerSurnameText.Text, customerPhoneText.Text, customerMailText.Text, customerAdressRichText.Text, customerReliabiltyCombo.SelectedItem.ToString(), customerPrivateSideRichText.Text))
                    {
                        MetroFramework.MetroMessageBox.Show(this, "'" + customerNameText.Text + " " + customerSurnameText.Text + "' adlı müşteri başarılı bir şekilde güncellendi.", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        funcs.addHistory("'" + customerNameText.Text + " " + customerSurnameText.Text + "' adlı müşteri eklendi.", 1);

                        debtTransactionFuncs.reloadMainPagePanelUserControls();
                    }
                    else MetroFramework.MetroMessageBox.Show(this, "Müşteri güncellenemedi...", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MetroFramework.MetroMessageBox.Show(this, "Lütfen geçerli bir mail adresi giriniz.", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MetroFramework.MetroMessageBox.Show(this, "Böyle bir müşteri adı daha önce kaydedilmiş. Lütfen başka bir isim giriniz.", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
