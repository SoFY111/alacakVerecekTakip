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
    public partial class editInstallmentCountUserControl : MetroFramework.Controls.MetroUserControl
    {

        private static editInstallmentCountUserControl _instance;
        public static editInstallmentCountUserControl Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new editInstallmentCountUserControl();
                return _instance;
            }
        }

        public editInstallmentCountUserControl()
        {
            InitializeComponent();
        }

        methods funcs = new methods();
        SqlConnection baglanti = methods.baglanti;
        public static int selectedHistory;
        string theme;

        private void fillShowInstallmentCountListViewColumn()
        {
            
        }

        private void fillShowInstallmentCountListViewItems() 
        {
            SqlCommand fillShowInstallmentCountListViewItemsCommand = new SqlCommand("SELECT * FROM installmentCount", baglanti);
            SqlDataReader sdr = fillShowInstallmentCountListViewItemsCommand.ExecuteReader();
            ListViewItem li = new ListViewItem();
            while (sdr.Read())
            {

            }
            sdr.Close();

        }

        private void editInstallmentCountUserControl_Load(object sender, EventArgs e)
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

            }
            else
            {

            }

            fillShowInstallmentCountListViewColumn();
            fillShowInstallmentCountListViewItems();
        }
    }
}
