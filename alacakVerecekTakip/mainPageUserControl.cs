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


    public partial class mainPageUserControl : MetroFramework.Controls.MetroUserControl
    {
        private static mainPageUserControl _instance;
        public static mainPageUserControl Instance
        {
            get{
                if (_instance == null)
                    _instance = new mainPageUserControl();
                return _instance;
            }
        }

        public mainPageUserControl()
        {
            InitializeComponent();
        }

        methods funcs = new methods();
        SqlConnection baglanti = methods.baglanti;
        public static int selectedHistory;
        string theme;


        public static void reloadForm()
        {
            _instance = null;
        }

        private void mainPageUserControl_Load(object sender, EventArgs e)
        {
            this.StyleManager = metroStyleManager1;
            theme = funcs.themeChanger(0);
            
            if (theme == "light") metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Light;
            else metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            if (funcs.isConnect(baglanti) == true){}
            else{
                MetroFramework.MetroMessageBox.Show(this, "Veri Tabanı Bağlantısı Kurulamadığından Dolayı Program Kapatılıyor..", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            if (metroStyleManager1.Theme == MetroFramework.MetroThemeStyle.Dark)
            {
                monthlyTotalIncomeCircleProgressbarPercentLabel.ForeColor = Color.FromArgb(170, 170, 170);
                monthlyTotalExpendituresCircleProgressbarPercentLabel.ForeColor = Color.FromArgb(170, 170, 170);
                totalIncomeCircleProgressbarPercentLabel.ForeColor = Color.FromArgb(170, 170, 170);
                totalExpendituresCircleProgressbarPercentLabel.ForeColor = Color.FromArgb(170, 170, 170);
                monthlyTotalIncomeCircleProgressbar.ProgressBackColor = Color.FromArgb(50, 50, 50);
                totalIncomeCircleProgressbar.ProgressBackColor = Color.FromArgb(50, 50, 50);
                monthlyTotalExpendituresCircleProgressbar.ProgressBackColor = Color.FromArgb(50, 50, 50);
                totalExpendituresCircleProgressbar.ProgressBackColor = Color.FromArgb(50, 50, 50);
            }
            else
            {
                monthlyTotalIncomeCircleProgressbarPercentLabel.ForeColor = Color.Black;
                monthlyTotalExpendituresCircleProgressbarPercentLabel.ForeColor = Color.Black;
                totalIncomeCircleProgressbarPercentLabel.ForeColor = Color.Black;
                totalExpendituresCircleProgressbarPercentLabel.ForeColor = Color.Black;
                monthlyTotalIncomeCircleProgressbar.ProgressBackColor = Color.Gainsboro;
                totalIncomeCircleProgressbar.ProgressBackColor = Color.Gainsboro;
                monthlyTotalExpendituresCircleProgressbar.ProgressBackColor = Color.Gainsboro;
                totalExpendituresCircleProgressbar.ProgressBackColor = Color.Gainsboro;
            }
        }
    }
}
