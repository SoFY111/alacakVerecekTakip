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
    public partial class loginScreenForm : MetroFramework.Forms.MetroForm
    {
        public loginScreenForm()
        {
            InitializeComponent();
        }

        methods funcs = new methods();
        SqlConnection baglanti = methods.baglanti;
        public static string loginName;
        string theme, loggedName;
        private string loginFunc(string username, string password){
            SqlCommand loginCommand = new SqlCommand("SELECT userName FROM users WHERE userName=@userName AND userPass=@userPass;", baglanti);
            loginCommand.Parameters.AddWithValue("@userName", username);
            loginCommand.Parameters.AddWithValue("@userPass", password);
            SqlDataReader sdr = loginCommand.ExecuteReader();
            while (sdr.Read()){
                loggedName = sdr["userName"].ToString();
            }
            sdr.Close();
            return loggedName;
        }

        private void loginScreen_Load(object sender, EventArgs e)
        {
            if (!funcs.isConnect(baglanti)) baglanti.Open();

            this.StyleManager = metroStyleManager1;
            theme = funcs.themeChanger(0);
            if (theme == "light") {
                metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Light;
            }
            else {
                metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            }

            if (funcs.isFirstOpening()){
                funcs.addHistory("İlk defa giriş yapıldı. Giriş tarihi:" + DateTime.Now, Convert.ToInt16(1));
                anasayfa anasayfa = new anasayfa();
                anasayfa.Show();
                this.Hide();
            }
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            loginName = loginFunc((usernameInputText.Text).ToLower(), (passwordInputText.Text).ToLower());
            if (loginName != null){
                funcs.addHistory("'" + usernameInputText.Text + "' kullanıcı adı ile giriş yapıldı.Giriş tarihi:" + DateTime.Now, Convert.ToInt16(1));
                anasayfa anasayfa = new anasayfa();
                anasayfa.Show();
                this.Hide();
            }
            else {
                funcs.addHistory("'" + usernameInputText.Text + "' kullanıcı adı ile giriş yapılmaya çalışıldı.. Tarihi:" + DateTime.Now, Convert.ToInt16(1));
                MetroFramework.MetroMessageBox.Show(this, "Kullanıcı Adı veya Şifre Hatalı...", "Giriş Yapılamadı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void usernameInputText_TextChanged(object sender, EventArgs e)
        {
            if (usernameInputText.Text != "" && passwordInputText.Text != ""){
                loginButton.Enabled = true;
                loginButton.BackColor = Color.FromArgb(0, 174, 219);
            }
            else{
                loginButton.Enabled = false;
                loginButton.BackColor = Color.Silver;
            }
        }

        private void passwordInputText_TextChanged(object sender, EventArgs e)
        {
            if (usernameInputText.Text != "" && passwordInputText.Text != ""){
                loginButton.Enabled = true;
                loginButton.BackColor = Color.FromArgb(0, 174, 219);
            }
            else{
                loginButton.Enabled = false;
                loginButton.BackColor = Color.Silver;
            }
        }
    }
}