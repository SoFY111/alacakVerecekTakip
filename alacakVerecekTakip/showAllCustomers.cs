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
            customerListView.Columns.Add("Müşeteri Adı Soyadı", 160);
            customerListView.Columns.Add("Müşteri Telefon No", 85);
            customerListView.Columns.Add("Müşteri EMAIL", 215);
            customerListView.Columns.Add("Taksit Mi", 90);
            customerListView.Columns.Add("Güvenilirlik Durumu", 127);
            customerListView.Columns.Add("Borç Türü", 100);
            customerListView.Columns.Add("Borç Durumu", 127);
            customerListView.Columns.Add("Borç Miktarı", 150);
            customerListView.Columns.Add("Para Türü", 127);
            customerListView.Columns.Add("Müşteri Id", 85);
            //customerListView.AutoResizeColumn(9, ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void fillCustomersListViewItems(int sortingType)
        {
            /*
             * sortingType => 0:Bütün Müşteriler
             * sortingType => 1:Bana Borcu Olan Müşteriler
             * sortingType => 2:Borcum Olan Müşteriler
             * 
             * debtType(Borç türü) => 1: Peşin
             * debtType(Borç türü) => 2: Taksit
             * 
             * */

            string[] moneyTypesTable = findExchangeMoneyFromIdToName(), customerDebtValTable = findCustomerDebtValTable(), reliabilityTable = findReliabilityTable();

            if (sortingType == 0) {
                SqlCommand fillCustomersListViewItemsCommand = new SqlCommand("SELECT * FROM customers", baglanti);
                SqlDataReader sdr = fillCustomersListViewItemsCommand.ExecuteReader();
                ListViewItem li = new ListViewItem();
                while (sdr.Read())
                {
                    for (int j = 0; j < customerDebtValTable.Length; j++)
                    {

                        string[] customerDebtValTableDetail = customerDebtValTable[j].Split('-');
                        if (Convert.ToInt32(sdr["customerId"]) == Convert.ToInt32(customerDebtValTableDetail[1]))
                        {
                            for (int i = 0; i < moneyTypesTable.Length; i++)
                            {

                                string[] moneyTypesTableDetail = moneyTypesTable[i].Split('-');
                                if (Convert.ToInt32(sdr["customerDebtMoneyId"]) == Convert.ToInt32(moneyTypesTableDetail[0]))
                                {

                                    for (int k = 0; k < reliabilityTable.Length; k++)
                                    {
                                        string[] reliabilityTableDetail = reliabilityTable[k].Split('-');

                                        if (Convert.ToInt32(sdr["customerReliabilityVal"]) == Convert.ToInt32(reliabilityTableDetail[0]))
                                        {
                                            li = customerListView.Items.Add(sdr["customerName"].ToString() + " " + sdr["customerSurname"]);
                                            li.SubItems.Add(sdr["customerPhone"].ToString());
                                            li.SubItems.Add(sdr["customerMail"].ToString());
                                            if (Convert.ToInt32(sdr["customerIsInstallment"]) == 0) li.SubItems.Add("Hayır");
                                            else if (Convert.ToInt32(sdr["customerIsInstallment"]) == 1) li.SubItems.Add("Evet");
                                            li.SubItems.Add(reliabilityTableDetail[1]);
                                            if (Convert.ToInt32(sdr["customerDebtType"]) == 1) li.SubItems.Add("Peşin");
                                            else if (Convert.ToInt32(sdr["customerDebtType"]) == 2) li.SubItems.Add("Taksit");
                                            if (Convert.ToInt32(sdr["customerIsDebt"]) == 0) li.SubItems.Add("Ödedi");
                                            else if (Convert.ToInt32(sdr["customerIsDebt"]) == 1) li.SubItems.Add("Ödüyor");
                                            li.SubItems.Add(customerDebtValTableDetail[2]);
                                            li.SubItems.Add(moneyTypesTableDetail[1]);
                                            li.SubItems.Add(sdr["customerId"].ToString());
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                sdr.Close();
            }
            else
            {
                SqlCommand fillCustomersListViewItemsCommand = new SqlCommand("SELECT * FROM customers WHERE customerDebtType = @debtType", baglanti);
                fillCustomersListViewItemsCommand.Parameters.AddWithValue("@debtType", sortingType);
                SqlDataReader sdr = fillCustomersListViewItemsCommand.ExecuteReader();
                ListViewItem li = new ListViewItem();
                while (sdr.Read())
                {
                    for (int j = 0; j < customerDebtValTable.Length; j++)
                    {

                        string[] customerDebtValTableDetail = customerDebtValTable[j].Split('-');
                        if (Convert.ToInt32(sdr["customerId"]) == Convert.ToInt32(customerDebtValTableDetail[1]))
                        {
                            for (int i = 0; i < moneyTypesTable.Length; i++)
                            {

                                string[] moneyTypesTableDetail = moneyTypesTable[i].Split('-');
                                if (Convert.ToInt32(sdr["customerDebtMoneyId"]) == Convert.ToInt32(moneyTypesTableDetail[0]))
                                {

                                    for (int k = 0; k < reliabilityTable.Length; k++)
                                    {
                                        string[] reliabilityTableDetail = reliabilityTable[k].Split('-');

                                        if (Convert.ToInt32(sdr["customerReliabilityVal"]) == Convert.ToInt32(reliabilityTableDetail[0]))
                                        {
                                            li = customerListView.Items.Add(sdr["customerName"].ToString() + " " + sdr["customerSurname"]);
                                            li.SubItems.Add(sdr["customerPhone"].ToString());
                                            li.SubItems.Add(sdr["customerMail"].ToString());
                                            if (Convert.ToInt32(sdr["customerIsInstallment"]) == 0) li.SubItems.Add("Hayır");
                                            else if (Convert.ToInt32(sdr["customerIsInstallment"]) == 1) li.SubItems.Add("Evet");
                                            li.SubItems.Add(reliabilityTableDetail[1]);
                                            if (Convert.ToInt32(sdr["customerDebtType"]) == 1) li.SubItems.Add("Peşin");
                                            else if (Convert.ToInt32(sdr["customerDebtType"]) == 2) li.SubItems.Add("Taksit");
                                            if (Convert.ToInt32(sdr["customerIsDebt"]) == 0) li.SubItems.Add("Ödedi");
                                            else if (Convert.ToInt32(sdr["customerIsDebt"]) == 1) li.SubItems.Add("Ödüyor");
                                            li.SubItems.Add(customerDebtValTableDetail[2]);
                                            li.SubItems.Add(moneyTypesTableDetail[1]);
                                            li.SubItems.Add(sdr["customerId"].ToString());
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                sdr.Close();
            }

                      
        }

        private string[] findExchangeMoneyFromIdToName()
        {
            int moneyCount1 = moneyCount(), moneyCount2 = 0;
            string[] exchangeMoneyName = new string[moneyCount1];

            SqlCommand findExchangeMoneyFromIdToNameCommand = new SqlCommand("SELECT * FROM moneyTypesTable", baglanti);
            SqlDataReader sdr = findExchangeMoneyFromIdToNameCommand.ExecuteReader();
            while (sdr.Read())
            {
                if (moneyCount2 <= moneyCount1)
                {
                    exchangeMoneyName[moneyCount2] = (sdr["moneyId"].ToString()) + "-" + sdr["moneyName"].ToString();
                    moneyCount2++;
                }
            }
            sdr.Close();
            return exchangeMoneyName;
        }

        private string[] findCustomerDebtValTable()
        {
            int debtCount = customersDebtValTableRowsCount(), debtCount2 = 0;
            string[] customerDebtValTable = new string[debtCount];

            SqlCommand findCustomerDebtValTableCommand = new SqlCommand("SELECT * FROM customersDebtValue", baglanti);
            SqlDataReader sdr = findCustomerDebtValTableCommand.ExecuteReader();
            while (sdr.Read())
            {
                if (debtCount2 <= debtCount)
                {
                    customerDebtValTable[debtCount2] = (sdr["debtValueId"].ToString()) + "-" + sdr["customerId"].ToString() + "-" + sdr["debtValue"].ToString();
                    debtCount2++;
                }
            }
            sdr.Close();
            return customerDebtValTable;
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

        private int moneyCount()
        {
            int moneyCountt = 0;
            SqlCommand moneyCountCommand = new SqlCommand("SELECT * FROM moneyTypesTable", baglanti);
            SqlDataReader sdr = moneyCountCommand.ExecuteReader();
            while (sdr.Read())
            {
                moneyCountt++;
            }
            sdr.Close();
            return moneyCountt;
        }

        private int customersDebtValTableRowsCount()
        {
            int rowCount = 0;
            SqlCommand moneyCountCommand = new SqlCommand("SELECT * FROM customersDebtValue", baglanti);
            SqlDataReader sdr = moneyCountCommand.ExecuteReader();
            while (sdr.Read())
            {
                rowCount++;
            }
            sdr.Close();
            return rowCount;
        }

        private int reliabiltyTableRowsCount()
        {
            int rowCount = 0;
            SqlCommand moneyCountCommand = new SqlCommand("SELECT * FROM degreeOfReliabilty", baglanti);
            SqlDataReader sdr = moneyCountCommand.ExecuteReader();
            while (sdr.Read())
            {
                rowCount++;
            }
            sdr.Close();
            return rowCount;
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

            if (listViewSortingType == 0) customersListViewLabel.Text = "Müşteri Tablosu";
            if (listViewSortingType == 1) customersListViewLabel.Text = "Size Borcu Olan Müşteriler";
            if (listViewSortingType == 2) customersListViewLabel.Text = "Borcunuz Olan Müşteriler";

            fillCustomersListViewColumns();
            fillCustomersListViewItems(listViewSortingType);
        }
    }
}
