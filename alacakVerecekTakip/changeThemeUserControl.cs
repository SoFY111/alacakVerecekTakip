using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace alacakVerecekTakip
{
    public partial class changeThemeUserControl : MetroFramework.Controls.MetroUserControl
    {

        private static changeThemeUserControl _instance;
        public static changeThemeUserControl Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new changeThemeUserControl();
                return _instance;
            }
        }

        public changeThemeUserControl()
        {
            InitializeComponent();
        }

        methods funcs = new methods();
        SqlConnection baglanti = methods.baglanti;
        public static int selectedHistory;
        string theme;

        private void changeThemeUserControl_Load(object sender, EventArgs e)
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

            if (metroStyleManager1.Theme == MetroFramework.MetroThemeStyle.Dark)
            {
                darkLightThemeChangerButton.TileImage = alacakVerecekTakip.Properties.Resources.lightButton;
                darkLightThemeChangerButton.Text = "Açık Mod";
            }
            else
            {
                darkLightThemeChangerButton.TileImage = alacakVerecekTakip.Properties.Resources.darkButton;
                darkLightThemeChangerButton.Text = "Koyu Mod";
            }
        }

        private void darkLightThemeChangerButton_Click(object sender, EventArgs e)
        {
            theme = funcs.themeChanger(1);
            MetroFramework.MetroMessageBox.Show(this, "Tema değiştirildi.. Temanın uygulanamsı için programı yeniden başlatın..", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult isRestart = MetroFramework.MetroMessageBox.Show(this, "Programı şimdi yeniden başlatmak ister misiniz?\n(Eğer yeniden başlatmazsanız program düzgün görüntülenmeyecektir.)", "DİKKAT!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (isRestart == DialogResult.Yes){
                companyNameForm.isRestart2 = true;
                Application.Restart();
            }
        }
    }
}
