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
    public partial class historyDetailForm : MetroFramework.Forms.MetroForm
    {
        public historyDetailForm()
        {
            InitializeComponent();
        }

        methods funcs = new methods();
        SqlConnection baglanti = methods.baglanti;
        string theme;

        private void fillTheBlanks(int selectedHistory)
        {
            string historyTypeDis = "";

            SqlCommand fillTheBlanksCommand = new SqlCommand("SELECT * FROM history WHERE historyId = @historyId", baglanti);
            fillTheBlanksCommand.Parameters.AddWithValue("@historyId", selectedHistory);
            SqlDataReader sdr = fillTheBlanksCommand.ExecuteReader();
            while (sdr.Read()){
                if (Convert.ToInt32(sdr["historyType"].ToString()) == 1) historyTypeDis = "Hızlı İşlemler";
                else if (Convert.ToInt32(sdr["historyType"].ToString()) == 2) historyTypeDis = "Cari İşlemler";
                else if (Convert.ToInt32(sdr["historyType"].ToString()) == 3) historyTypeDis = "Kasa İşlemleri";
                else if (Convert.ToInt32(sdr["historyType"].ToString()) == 4) historyTypeDis = "Diğer İşlemler";
                historyTypeText.Text = historyTypeDis;
                historyDateText.Text = sdr["historyDate"].ToString();
                historyDiscriptionRichText.Text = sdr["historyDiscription"].ToString();
            }
            sdr.Close();
        }

        private void historyDetailForm_Load(object sender, EventArgs e)
        {
            this.StyleManager = metroStyleManager1;
            theme = funcs.themeChanger(0);
            if (theme == "light")   metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Light;
            else metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;

            if (funcs.isConnect(baglanti) == true){
                connectSituation.BackColor = Color.Lime;
                funcs.setToolTip(connectSituation, "Veri Tabanı Bağlantısı Var");
            }
            else{
                MetroFramework.MetroMessageBox.Show(this, "Veri Tabanı Bağlantısı Kurulamadığından Dolayı Program Kapatılıyor..", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            fillTheBlanks(allHistoryForm.selectedHistory);
        }
    }
}
