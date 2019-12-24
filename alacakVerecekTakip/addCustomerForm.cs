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
using System.Net.Mail;

namespace alacakVerecekTakip
{
    public partial class addCustomerForm : MetroFramework.Forms.MetroForm
    {
        public addCustomerForm()
        {
            InitializeComponent();
        }

        methods funcs = new methods();
        SqlConnection baglanti = methods.baglanti;
        string theme;

        private void fillCustomerReliabiltyCombo()
        {
            SqlCommand fillCustomerReliabiltyComboCommand = new SqlCommand("SELECT * FROM degreeOfReliabilty ORDER BY degreeOfRealiabiltyId DESC", baglanti);
            SqlDataReader sdr = fillCustomerReliabiltyComboCommand.ExecuteReader();
            while (sdr.Read()){
                customerReliabiltyCombo.Items.Add(sdr["degreeOfReliabiltyDiscription"].ToString());
            }
            sdr.Close();
            customerReliabiltyCombo.SelectedIndex = 0;
        }

        private bool addCustomer(string customerName, string customerSurname, string customerPhone, string customerMail, string customerAdress, string customerReliabilty)
        {
            int reliabiltyId = reliabiltyNameToId(customerReliabilty);
            SqlCommand addCustomerCommand = new SqlCommand("INSERT INTO customers VALUES(@customerName, @customerSurname, @customerPhone, @customerMail, @customerAdress, @customerRaliabilty)", baglanti);
            addCustomerCommand.Parameters.AddWithValue("@customerName", customerName);
            addCustomerCommand.Parameters.AddWithValue("@customerSurname", customerSurname);
            addCustomerCommand.Parameters.AddWithValue("@customerPhone", customerPhone);
            addCustomerCommand.Parameters.AddWithValue("@customerMail", customerMail);
            addCustomerCommand.Parameters.AddWithValue("@customerAdress", customerAdress);
            addCustomerCommand.Parameters.AddWithValue("@customerRaliabilty", reliabiltyId);

            int retAddCustomerCommandVal = addCustomerCommand.ExecuteNonQuery();
            if (retAddCustomerCommandVal == 1) return true;
            else return false;
        }

        private int reliabiltyNameToId(string reliabiltyName)
        {
            int degreeOfReliabiltyId = 0;
            SqlCommand reliabiltyNameToIdCommand = new SqlCommand("SELECT * FROM degreeOfReliabilty WHERE degreeOfReliabiltyDiscription = @degreeOfReliabiltyDiscription", baglanti);
            reliabiltyNameToIdCommand.Parameters.AddWithValue("@degreeOfReliabiltyDiscription", reliabiltyName);
            SqlDataReader sdr = reliabiltyNameToIdCommand.ExecuteReader();
            while (sdr.Read()){
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
                returnedVal = true;
            }
            sdr.Close();
            return returnedVal;
        }

        private bool mailControl(string mail)
        {
            try{
                MailAddress m = new MailAddress(mail);
                return true;
            }
            catch (Exception){
                return false;
                //throw;
            }
        }

        private void addCustomerForm_Load(object sender, EventArgs e)
        {
            this.StyleManager = metroStyleManager1;
            theme = funcs.themeChanger(0);

            if (theme == "light") metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Light;
            else metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            if (funcs.isConnect(baglanti) == true) { }
            else{
                MetroFramework.MetroMessageBox.Show(this, "Veri Tabanı Bağlantısı Kurulamadığından Dolayı Program Kapatılıyor..", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            if (funcs.isConnect(baglanti) == true){
                connectSituation.BackColor = Color.Lime;
                funcs.setToolTip(connectSituation, "Veri Tabanı Bağlantısı Var");
            }
            else{
                MetroFramework.MetroMessageBox.Show(this, "Veri Tabanı Bağlantısı Kurulamadığından Dolayı Program Kapatılıyor..", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            if (metroStyleManager1.Theme == MetroFramework.MetroThemeStyle.Dark){
                helpPictureBox.Image = alacakVerecekTakip.Properties.Resources.helpWhite;
                customerPhoneText.BackColor = Color.FromArgb(17, 17, 17);
                customerPhoneText.ForeColor = Color.Silver;
                customerAdressRichText.BackColor = Color.FromArgb(17, 17, 17);
                customerAdressRichText.ForeColor = Color.Silver;
            }
            else{
                helpPictureBox.Image = alacakVerecekTakip.Properties.Resources.help;
                customerPhoneText.BackColor = Color.White;
                customerPhoneText.ForeColor = Color.Black;
                customerAdressRichText.BackColor = Color.White;
                customerAdressRichText.ForeColor = Color.Black;
            }

            fillCustomerReliabiltyCombo();
        }

        private void customerNameText_TextChanged(object sender, EventArgs e)
        {
            if (customerNameText.Text == "" || customerSurnameText.Text == "" || customerPhoneText.Text == "" || customerMailText.Text == "" || customerAdressRichText.Text == ""){
                saveButton.Enabled = false;
                saveButton.BackColor = Color.Silver;
                saveButton.ForeColor = Color.Black;
            }
            else{
                saveButton.Enabled = true;
                saveButton.BackColor = Color.FromArgb(0, 174, 219);
                saveButton.ForeColor = Color.White;
            }
        }

        private void customerSurnameText_TextChanged(object sender, EventArgs e)
        {
            if (customerNameText.Text == "" || customerSurnameText.Text == "" || customerPhoneText.Text == "" || customerMailText.Text == "" || customerAdressRichText.Text == ""){
                saveButton.Enabled = false;
                saveButton.BackColor = Color.Silver;
                saveButton.ForeColor = Color.Black;
            }
            else{
                saveButton.Enabled = true;
                saveButton.BackColor = Color.FromArgb(0, 174, 219);
                saveButton.ForeColor = Color.White;
            }
        }

        private void customerPhoneText_TextChanged(object sender, EventArgs e)
        {
            if (customerNameText.Text == "" || customerSurnameText.Text == "" || customerPhoneText.Text == "" || customerMailText.Text == "" || customerAdressRichText.Text == ""){
                saveButton.Enabled = false;
                saveButton.BackColor = Color.Silver;
                saveButton.ForeColor = Color.Black;
            }
            else{
                saveButton.Enabled = true;
                saveButton.BackColor = Color.FromArgb(0, 174, 219);
                saveButton.ForeColor = Color.White;
            }
        }

        private void customerMailText_TextChanged(object sender, EventArgs e)
        {
            if (customerNameText.Text == "" || customerSurnameText.Text == "" || customerPhoneText.Text == "" || customerMailText.Text == "" || customerAdressRichText.Text == ""){
                saveButton.Enabled = false;
                saveButton.BackColor = Color.Silver;
                saveButton.ForeColor = Color.Black;
            }
            else{
                saveButton.Enabled = true;
                saveButton.BackColor = Color.FromArgb(0, 174, 219);
                saveButton.ForeColor = Color.White;
            }
        }

        private void customerAdressRichText_TextChanged(object sender, EventArgs e)
        {
            if (customerNameText.Text == "" || customerSurnameText.Text == "" || customerPhoneText.Text == "" || customerMailText.Text == "" || customerAdressRichText.Text == ""){
                saveButton.Enabled = false;
                saveButton.BackColor = Color.Silver;
                saveButton.ForeColor = Color.Black;
            }
            else{
                saveButton.Enabled = true;
                saveButton.BackColor = Color.FromArgb(0, 174, 219);
                saveButton.ForeColor = Color.White;
            }
        }

        private void customerReliabiltyCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!customerIsAddedBefore(customerNameText.Text, customerSurnameText.Text)){
                if (mailControl(customerMailText.Text)){
                    if (addCustomer(customerNameText.Text, customerSurnameText.Text, customerPhoneText.Text, customerMailText.Text, customerAdressRichText.Text, customerReliabiltyCombo.Text)){
                        MetroFramework.MetroMessageBox.Show(this, "'" + customerNameText.Text + " " + customerSurnameText.Text + "' adlı müşteri başarılı bir şekilde eklendi.", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        funcs.addHistory("'" + customerNameText.Text + " " + customerSurnameText.Text + "' adlı müşteri eklendi.", 1);
                        if (anasayfa.mainpagePanel1.Controls.Contains(showAllCustomers.Instance)){
                            anasayfa.mainpagePanel1.Controls.Clear();
                            showAllCustomers.reloadForm();
                            anasayfa.mainpagePanel1.Controls.Add(showAllCustomers.Instance);
                        }
                    }
                    else MetroFramework.MetroMessageBox.Show(this, "Müşteri eklenemedi...", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MetroFramework.MetroMessageBox.Show(this, "Lütfen geçerli bir mail adresi giriniz.", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MetroFramework.MetroMessageBox.Show(this, "Böyle bir müşteri adı daha önce kaydedilmiş. Lütfen başka bir isim giriniz.", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}