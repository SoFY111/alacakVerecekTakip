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
    public partial class companyNameForm : MetroFramework.Forms.MetroForm
    {
        public companyNameForm()
        {
            InitializeComponent();
        }

        methods funcs = new methods();
        SqlConnection baglanti = methods.baglanti;
        string oldCompanyName, theme;
        public static bool isRestart2 = false;
        private string fillCompanyNameTextBox()
        {
            SqlCommand komut = new SqlCommand("SELECT companyName FROM companyName WHERE companyNameId = 1", baglanti);
            SqlDataReader rdr = komut.ExecuteReader();
            while (rdr.Read()){
                oldCompanyName = rdr["companyName"].ToString();
            }
            rdr.Close();
            return oldCompanyName;
        }

        private bool updateCompanyName(string newCompanyName)
        {//şirket ismini güncellemek için bu fonksiyon çağırılır. try-catch kullanmamızın sebebi programın çöküp hata göstermemesi için
            try
            {
                SqlCommand updateCompanyName = new SqlCommand("UPDATE companyName SET companyName=@companyName WHERE companyNameId = '1';", baglanti);
                updateCompanyName.Parameters.AddWithValue("@companyName", newCompanyName);
                int retEditCommandValue = updateCompanyName.ExecuteNonQuery();
                if (retEditCommandValue == 1) return true;
                else return false;
            }
            catch (Exception)
            {
                return false;
                //throw; --Yorum satırı olmasının nedeni throw komutu hataları ekrana gösterir, try-catch kullanmamızın nedeni hatayı ekrana göstermemektir.
            }
        }

        private bool isTextChange = false;
        private void companyNameForm_Load(object sender, EventArgs e)
        {
            this.StyleManager = metroStyleManager1;
            theme = funcs.themeChanger(0);
            if (theme == "light") metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Light;
            else metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;

            if (funcs.isConnect(baglanti) == true){
                connectSituation.BackColor = Color.Lime;
                funcs.setToolTip(connectSituation, "Veri Tabanı Bağlantısı Var");
            }
            else {
                MetroFramework.MetroMessageBox.Show(this, "Veri Tabanı Bağlantısı Kurulamadığından Dolayı Program Kapatılıyor..", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            companyNameInputText.Text = fillCompanyNameTextBox();
        }

        private void companyNameInputText_TextChanged(object sender, EventArgs e)
        {
            if (oldCompanyName != companyNameInputText.Text){
                isTextChange = true;
                saveButton.Enabled = true;
                saveButton.BackColor = Color.FromArgb(0, 174, 219);
            }
            else{
                isTextChange = false;
                saveButton.Enabled = false;
                saveButton.BackColor = Color.Silver;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

            if (updateCompanyName(companyNameInputText.Text)){
                string[] oldCompanyName1 = (anasayfa.companyName).Split('-');
                MetroFramework.MetroMessageBox.Show(this, "Şirket ismi değiştirildi..\nDeğişiklikler uygulama yeniden başlatıldıktan sonra geçerli olacaktır.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                funcs.addHistory("'" + oldCompanyName1[1] + "' olan şirket ismi '" + companyNameInputText.Text + "' ile değiştirildi", 4);
                DialogResult isRestart = MetroFramework.MetroMessageBox.Show(this, "Programı şimdi yeniden başlatmak ister misiniz?", "DİKKAT!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question );
                if (isRestart == DialogResult.Yes) {
                    isRestart2 = true;
                    Application.Restart();
                }
            }
            else MetroFramework.MetroMessageBox.Show(this, "Şirket ismi değiştilemedi.\nLütfen bizimle iletişime geçin...", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
