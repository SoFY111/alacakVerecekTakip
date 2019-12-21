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

        private void fillCustomersListViewColumns(int sortingType)
        {
            customerListView.Items.Clear();
            customerListView.View = View.Details;
            customerListView.GridLines = true;
            if (sortingType == 0)
            {
                customerListView.Columns.Add("Müşteri Adı", 208);
                customerListView.Columns.Add("Müşteri Soyadı", 208);
                customerListView.Columns.Add("Müşteri Telefon No", 208);
                customerListView.Columns.Add("Müşteri Mail", 208);
                customerListView.Columns.Add("Müşteri Adres", 210);
                customerListView.Columns.Add("Müşteri Güvenilirlik Durumu", 208);
                customerListView.Columns.Add("MüşteriId", 17);
            }
            else if (sortingType == 1 || sortingType == 2)
            {
                customerListView.Columns.Add("Müşteri Adı", 130);
                customerListView.Columns.Add("Müşteri Soyadı", 130);
                customerListView.Columns.Add("Müşteri Telefon No", 140);
                customerListView.Columns.Add("Müşteri Güvenilirlik Durumu", 130);
                customerListView.Columns.Add("İşlem Tipi", 120);
                customerListView.Columns.Add("Borç Tipi", 80);
                customerListView.Columns.Add("Para Miktarı", 120);
                customerListView.Columns.Add("Para Türü", 120);
                customerListView.Columns.Add("Banka Türü", 130);
                customerListView.Columns.Add("İşlem Tarihi", 140);
                customerListView.Columns.Add("MüşteriId", 28);
            }
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

            string[] moneyTypesTable = findExchangeMoneyFromIdToName(), reliabilityTable = findReliabilityTable(), bankTypesTable = findBabkTypesTable();

            if (sortingType == 0)
            {
                fillCustomersListViewColumns(sortingType);
                SqlCommand showAllCustomersCommand = new SqlCommand("SELECT * FROM customers ORDER BY customerName", baglanti);
                SqlDataReader sdr = showAllCustomersCommand.ExecuteReader();
                ListViewItem li = new ListViewItem();
                while (sdr.Read())
                {
                    for (int i = 0; i < reliabilityTable.Length; i++)
                    {
                        if (i == Convert.ToInt32(sdr["customerReliabilityVal"]))
                        {
                            string[] reliabilityTableDetail = reliabilityTable[i].Split('-');

                            li = customerListView.Items.Add(sdr["customerName"].ToString());
                            li.SubItems.Add(sdr["customerSurname"].ToString());
                            li.SubItems.Add(sdr["customerPhone"].ToString());
                            li.SubItems.Add(sdr["customerMail"].ToString());
                            li.SubItems.Add(sdr["customerAdress"].ToString());
                            li.SubItems.Add(reliabilityTableDetail[1]);
                            li.SubItems.Add(sdr["customerId"].ToString());
                        }
                    }
                }
                sdr.Close();
            }
            else if (sortingType == 1 || sortingType == 2)
            {
                fillCustomersListViewColumns(sortingType);
                string[] customerListTable;
                customerListTable = findDebtorTable(sortingType);
                SqlCommand showDebtorCustomerCommand = new SqlCommand("SELECT * FROM customers ORDER BY customerId", baglanti);
                SqlDataReader sdr = showDebtorCustomerCommand.ExecuteReader();
                ListViewItem li = new ListViewItem();
                while (sdr.Read())
                {
                    for (int i = 0; i < customerListTable.Length; i++)
                    {
                        string[] customerListTableDetail = customerListTable[i].Split('-');

                        if (Convert.ToInt32(customerListTableDetail[1]) == Convert.ToInt32(sdr["customerId"]))
                        {

                            li = customerListView.Items.Add(sdr["customerName"].ToString());
                            li.SubItems.Add(sdr["customerSurname"].ToString());
                            li.SubItems.Add(sdr["customerPhone"].ToString());
                            for (int l = 0; l < reliabilityTable.Length; l++)
                            {
                                string[] reliabilityTableDetail = reliabilityTable[l].Split('-');
                                if (Convert.ToInt32(sdr["customerReliabilityVal"]) == Convert.ToInt32(reliabilityTableDetail[0]))
                                {
                                    li.SubItems.Add(reliabilityTableDetail[1]);
                                    break;
                                }
                            }
                            if (sortingType == 1) li.SubItems.Add("Borç verildi.");
                            if (sortingType == 2) li.SubItems.Add("Borç alındı.");
                            if (Convert.ToInt32(customerListTableDetail[3]) == 0) li.SubItems.Add("Peşin");
                            if (Convert.ToInt32(customerListTableDetail[3]) == 1) li.SubItems.Add("Taksit");
                            li.SubItems.Add(customerListTableDetail[4]);
                            for (int j = 0; j < moneyTypesTable.Length; j++)
                            {
                                string[] moneyTypesTableDetail = moneyTypesTable[j].Split('-');
                                if (Convert.ToInt32(moneyTypesTableDetail[0]) == Convert.ToInt32(customerListTableDetail[5]))
                                {
                                    li.SubItems.Add(moneyTypesTableDetail[1]);
                                    break;
                                }
                            }
                            for (int k = 0; k < bankTypesTable.Length; k++)
                            {
                                string[] bankTypesTableDetail = bankTypesTable[k].Split('-');
                                if (Convert.ToInt32(bankTypesTableDetail[0]) == Convert.ToInt32(customerListTableDetail[6]))
                                {
                                    li.SubItems.Add(bankTypesTableDetail[1]);
                                    break;
                                }
                            }
                            li.SubItems.Add(customerListTableDetail[7]);
                            li.SubItems.Add(sdr["customerId"].ToString());
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

        private string[] findDebtorTable(int sortingType)
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
            int debtorCount = debtorTableCount(sortingType), debtorCount2 = 0;
            string[] debtTable = new string[debtorCount];

            if (sortingType == 1)
            {
                SqlCommand findCustomerDebtValTableCommand = new SqlCommand("SELECT * FROM customersDebtor", baglanti);
                SqlDataReader sdr = findCustomerDebtValTableCommand.ExecuteReader();
                while (sdr.Read())
                {
                    if (debtorCount2 <= debtorCount)
                    {
                        debtTable[debtorCount2] = (sdr["debtorId"].ToString()) + "-" + sdr["customerId"].ToString() + "-" + sdr["transactionTypeId"].ToString() + "-" + sdr["debtType"].ToString() + "-" + sdr["debtVal"].ToString() + "-" + sdr["debtMoneyTypeId"].ToString() + "-" + sdr["debtBankTypeId"].ToString() + "-" + sdr["debtDate"].ToString() + "-" + sdr["debtPaymentDate"].ToString();
                        debtorCount2++;
                    }
                }
                sdr.Close();
            }
            else
            {
                SqlCommand findCustomersMyDebtValTableCommand = new SqlCommand("SELECT * FROM customersMyDebt", baglanti);
                SqlDataReader sdr = findCustomersMyDebtValTableCommand.ExecuteReader();
                while (sdr.Read())
                {
                    if (debtorCount2 <= debtorCount)
                    {
                        debtTable[debtorCount2] = (sdr["myDebtId"].ToString()) + "-" + sdr["customerId"].ToString() + "-" + sdr["transactionTypeId"].ToString() + "-" + sdr["debtType"].ToString() + "-" + sdr["debtVal"].ToString() + "-" + sdr["debtMoneyTypeId"].ToString() + "-" + sdr["debtBankTypeId"].ToString() + "-" + sdr["debtDate"].ToString() + "-" + sdr["debtPaymentDate"].ToString();
                        debtorCount2++;
                    }
                }
                sdr.Close();
            }
            return debtTable;
        }
        private string[] findBabkTypesTable()
        {
            int bankCount = bankTableCount(), bankCount2 = 0;
            string[] bankTypesTable = new string[bankCount];

            SqlCommand findCustomerDebtValTableCommand = new SqlCommand("SELECT * FROM bankTypes", baglanti);
            SqlDataReader sdr = findCustomerDebtValTableCommand.ExecuteReader();
            while (sdr.Read())
            {
                if (bankCount2 <= bankCount)
                {
                    bankTypesTable[bankCount2] = sdr["bankTypeId"].ToString() + "-" + sdr["bankTypeName"].ToString();
                    bankCount2++;
                }
            }
            sdr.Close();
            return bankTypesTable;
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

        private int reliabiltyTableRowsCount()
        {
            int rowCount = 0;
            SqlCommand reliabiltyTableRowsCountCommand = new SqlCommand("SELECT * FROM degreeOfReliabilty", baglanti);
            SqlDataReader sdr = reliabiltyTableRowsCountCommand.ExecuteReader();
            while (sdr.Read())
            {
                rowCount++;
            }
            sdr.Close();
            return rowCount;
        }

        private int debtorTableCount(int sortingType)
        {
            int rowCount = 0;
            if (sortingType == 1)
            {
                SqlCommand debtorTableCountCommand = new SqlCommand("SELECT * FROM customersDebtor", baglanti);
                SqlDataReader sdr = debtorTableCountCommand.ExecuteReader();
                while (sdr.Read())
                {
                    rowCount++;
                }
                sdr.Close();
            }
            else
            {
                SqlCommand myDebtTableCountCommand = new SqlCommand("SELECT * FROM customersMyDebt", baglanti);
                SqlDataReader sdr = myDebtTableCountCommand.ExecuteReader();
                while (sdr.Read())
                {
                    rowCount++;
                }
                sdr.Close();
            }
            return rowCount;
        }

        private int bankTableCount()
        {
            int rowCount = 0;
            SqlCommand bankTableCountCommand = new SqlCommand("SELECT * FROM bankTypes", baglanti);
            SqlDataReader sdr = bankTableCountCommand.ExecuteReader();
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
            fillCustomersListViewItems(listViewSortingType);
        }
    }
}