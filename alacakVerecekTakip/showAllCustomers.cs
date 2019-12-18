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
    public partial class showAllCustomers : MetroFramework.Controls.MetroUserControl
    {

        private static showAllCustomers _instance;
        public static showAllCustomers Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new showAllCustomers();
                return _instance;
            }
        }

        public showAllCustomers()
        {
            InitializeComponent();
        }

        methods funcs = new methods();
        SqlConnection baglanti = methods.baglanti;
        string theme;

        private void fillCustomersListViewColumns()
        {
            customerListView.Items.Clear();
            customerListView.View = View.Details;
            customerListView.GridLines = true;
            customerListView.Columns.Add("Çek Keşide Zamanı", 158);
            customerListView.Columns.Add("Banka Türü", 158);
            customerListView.Columns.Add("Banka Kodu", 158);
            customerListView.Columns.Add("Para Miktarı", 158);
            customerListView.Columns.Add("Para Türü", 150);
            customerListView.Columns.Add("Çeki Veren Kişi", 158);
            customerListView.Columns.Add("Çeki Alan Kişi", 158);
            customerListView.Columns.Add("Çek İşelm Tipi", 155);
            customerListView.Columns.Add("Çek Id");
            customerListView.AutoResizeColumn(7, ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void fillCustomersListViewItems(int sortingType)
        {
            /*
             * sortingType => 0:Bütün Müşteriler
             * sortingType => 1:Bana Borcu Olan Müşteriler
             * sortingType => 2:Borcum Olan Müşteriler
             * 
             * */

            SqlCommand fillCustomersListViewItemsCommand = new SqlCommand("SELECT * FROM customers WHERE debtType = @debtType", baglanti);
            fillCustomersListViewItemsCommand.Parameters.AddWithValue("@debtType", sortingType);


        }



        public static void reloadForm()
        {
            _instance = null;
        }

        private void showAllCustomers_Load(object sender, EventArgs e)
        {
            this.StyleManager = metroStyleManager1;
            theme = funcs.themeChanger(0);
            int listViewSortingType = anasayfa.customerListViewSortingType;

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
                helpPictureBox.Image = alacakVerecekTakip.Properties.Resources.helpWhite;
            }
            else
            {
                helpPictureBox.Image = alacakVerecekTakip.Properties.Resources.help;
            }

            fillCustomersListViewColumns();
            fillCustomersListViewItems(listViewSortingType);
        }
    }
}
