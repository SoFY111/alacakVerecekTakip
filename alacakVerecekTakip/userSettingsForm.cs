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
    public partial class userSettingsForm : MetroFramework.Forms.MetroForm
    {
        public userSettingsForm()
        {
            InitializeComponent();
        }

        methods funcs = new methods();
        SqlConnection baglanti = methods.baglanti;
        private string loggedUsername = loginScreenForm.loginName;
        string theme;

        private bool saveNewName(string oldUserName, string newUserName)
        {
            try{
                if (oldUserName != newUserName){
                    SqlCommand saveNewNameCommand = new SqlCommand("UPDATE users SET userName = @newUserName WHERE userName=@oldUserName;", baglanti);
                    saveNewNameCommand.Parameters.AddWithValue("@oldUserName", oldUserName);
                    saveNewNameCommand.Parameters.AddWithValue("@newUserName", newUserName);
                    int retSaveNewNameCommandVal = saveNewNameCommand.ExecuteNonQuery();
                    if (retSaveNewNameCommandVal == 1){
                        loggedUsername = newNameText.Text;
                        oldNameText.Text = newUserName;
                        newNameText.Text = null;
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            catch (Exception){
                return false;
            }
        }

        private bool saveNewPassword(string loggedUsername, string oldUserPass, string newUserPass)
        {
            try{
                SqlCommand saveNewPasswordCommand = new SqlCommand("UPDATE users SET userPass = @newUserPass WHERE userPass = @oldUserPass", baglanti);
                saveNewPasswordCommand.Parameters.AddWithValue("@newUserPass", newUserPass);
                saveNewPasswordCommand.Parameters.AddWithValue("@oldUserPass", oldUserPass);
                int retSaveNewUserPasswordCommandVal = saveNewPasswordCommand.ExecuteNonQuery();
                if (retSaveNewUserPasswordCommandVal == 1){
                    oldPasswordText.Text = null;
                    newPasswordText.Text = null;
                    againNewPasswordText.Text = null;
                    return true;
                }
                else return false;
            }
            catch (Exception){
                return false;
            }
        }

        private string oldPasswordControl()
        {
            string returnedVal = "";
            SqlCommand oldPasswordControlCommand = new SqlCommand("SELECT * FROM users", baglanti);
            SqlDataReader sdr = oldPasswordControlCommand.ExecuteReader();
            while (sdr.Read())
            {
                returnedVal = sdr["userPass"].ToString();
            }
            sdr.Close();
            return returnedVal.ToLower();
        }

        private void userSettings_Load(object sender, EventArgs e)
        {
            this.StyleManager = metroStyleManager1;
            theme = funcs.themeChanger(0);
            if (theme == "light"){
                metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Light;
                usernameGroupBox.ForeColor = Color.Black;
                passwordGroupBox.ForeColor = Color.Black;
            }
            else {
                metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
                usernameGroupBox.ForeColor = Color.FromArgb(170, 170, 170);
                passwordGroupBox.ForeColor = Color.FromArgb(170, 170, 170);
            }

            if (funcs.isConnect(baglanti) == true){
                connectSituation.BackColor = Color.Lime;
                funcs.setToolTip(connectSituation, "Veri Tabanı Bağlantısı Var");
            }
            else{
                MetroFramework.MetroMessageBox.Show(this, "Veri Tabanı Bağlantısı Kurulamadığından Dolayı Program Kapatılıyor..", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            oldNameText.Text = loggedUsername;
        }

        private void saveNewNameButton_Click(object sender, EventArgs e)
        {
            if (oldNameText.Text != newNameText.Text) {
                if (saveNewName((oldNameText.Text).ToLower(), (newNameText.Text).ToLower())){
                    MetroFramework.MetroMessageBox.Show(this, "Yeni Kullanıcı Adı Kaydedildi...", "BİLGİ!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    funcs.addHistory("'" + oldNameText.Text + "' olan kullanıcı adı '" + newNameText.Text + "' ile değiştirildi.", 4);
                }
                else MetroFramework.MetroMessageBox.Show(this, "Yeni kullanıcı adı kaydedilemedi...", "BİLGİ!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MetroFramework.MetroMessageBox.Show(this, "Yeni kullanıcı adı, eskisiyle aynı olamaz...", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void saveNewPasswordButton_Click(object sender, EventArgs e)
        {
            if (oldPasswordControl() != oldPasswordText.Text.ToLower()){
                if ((newPasswordText.Text).ToLower() == (againNewPasswordText.Text).ToLower()) {
                    if(saveNewPassword(loggedUsername, (oldPasswordText.Text).ToLower(), (newPasswordText.Text).ToLower())){
                        MetroFramework.MetroMessageBox.Show(this, "Yeni Şifre Kaydedildi...", "BİLGİ!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        funcs.addHistory("Şifre değiştirildi.", 4);
                    }
                    else MetroFramework.MetroMessageBox.Show(this, "Şifre değiştirilemedi...", "BİLGİ!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MetroFramework.MetroMessageBox.Show(this, "Şifrelerin İkisini De Aynı Giriniz...", "BİLGİ!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MetroFramework.MetroMessageBox.Show(this, "Eski şifre ile yeni şifre aynı olamaz...", "BİLGİ!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void newNameText_TextChanged(object sender, EventArgs e)
        {
            if (newNameText.Text != ""){
                saveNewNameButton.Enabled = true;
                saveNewNameButton.BackColor = Color.FromArgb(0, 174, 219);
            }
            else{
                saveNewNameButton.Enabled = false;
                saveNewNameButton.BackColor = Color.Silver;
            }
        }

        private void newPasswordText_TextChanged(object sender, EventArgs e)
        {
            if (newPasswordText.Text != "" && againNewPasswordText.Text != ""){
                saveNewPasswordButton.Enabled = true;
                saveNewPasswordButton.BackColor = Color.FromArgb(0, 174, 219);

            }
            else{
                saveNewPasswordButton.Enabled = false;
                saveNewPasswordButton.BackColor = Color.Silver;
            }
        }

        private void againNewPasswordText_TextChanged(object sender, EventArgs e)
        {
            if (newPasswordText.Text != "" && againNewPasswordText.Text != ""){
                saveNewPasswordButton.Enabled = true;
                saveNewPasswordButton.BackColor = Color.FromArgb(0, 174, 219);

            }
            else{
                saveNewPasswordButton.Enabled = false;
                saveNewPasswordButton.BackColor = Color.Silver;
            }
        }
    }
}