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
        public static int selectedCustomerId = 0, selectedTransactionId = 0;
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
                customerListView.Columns.Add("Müşteri Adı", 127);
                customerListView.Columns.Add("Müşteri Soyadı", 127);
                customerListView.Columns.Add("Müşteri Telefon No", 137);
                customerListView.Columns.Add("Müşteri Güvenilirlik Durumu", 127);
                customerListView.Columns.Add("İşlem Tipi", 117);
                customerListView.Columns.Add("Borç Tipi", 77);
                customerListView.Columns.Add("Para Miktarı", 117);
                customerListView.Columns.Add("Para Türü", 117);
                customerListView.Columns.Add("Banka Türü", 127);
                customerListView.Columns.Add("İşlem Tarihi", 137);
                customerListView.Columns.Add("İşlem Id", 28);
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

                string showDebtorCustomerCommandText = "";
                if (sortingType == 1) showDebtorCustomerCommandText = "SELECT * FROM customersDebtor ORDER BY debtorId DESC";
                else showDebtorCustomerCommandText = "SELECT * FROM customersMyDebt ORDER BY myDebtId DESC";
                fillCustomersListViewColumns(sortingType);
                string[] customerListTable;
                customerListTable = findCustomerTable();
                SqlCommand showDebtorCustomerCommand = new SqlCommand(showDebtorCustomerCommandText, baglanti);
                SqlDataReader sdr = showDebtorCustomerCommand.ExecuteReader();
                ListViewItem li = new ListViewItem();
                while (sdr.Read())
                {
                    for (int i = 0; i < customerListTable.Length; i++)
                    {
                        string[] customerListTableDetail = customerListTable[i].Split('-');
                        if (Convert.ToInt32(customerListTableDetail[0]) == Convert.ToInt32(sdr["customerId"]))
                        {

                            li = customerListView.Items.Add(customerListTableDetail[1]);
                            li.SubItems.Add(customerListTableDetail[2]);
                            li.SubItems.Add(customerListTableDetail[3] + "-" + customerListTableDetail[4]);
                            for (int l = 0; l < reliabilityTable.Length; l++)
                            {
                                string[] reliabilityTableDetail = reliabilityTable[l].Split('-');
                                if (Convert.ToInt32(customerListTableDetail[7]) == Convert.ToInt32(reliabilityTableDetail[0]))
                                {
                                    li.SubItems.Add(reliabilityTableDetail[1]);
                                    break;
                                }
                            }
                            if (sortingType == 1) li.SubItems.Add("Borç verildi.");
                            else li.SubItems.Add("Borç alındı.");
                            if (Convert.ToInt32(sdr["debtType"]) == 0) li.SubItems.Add("Peşin");
                            else if (Convert.ToInt32(sdr["debtType"]) == 1) li.SubItems.Add("Taksit");
                            li.SubItems.Add(sdr["debtVal"].ToString());
                            for (int j = 0; j < moneyTypesTable.Length; j++)
                            {
                                string[] moneyTypesTableDetail = moneyTypesTable[j].Split('-');
                                if (Convert.ToInt32(moneyTypesTableDetail[0]) == Convert.ToInt32(sdr["debtMoneyTypeId"]))
                                {
                                    li.SubItems.Add(moneyTypesTableDetail[1]);
                                    break;
                                }
                            }
                            for (int k = 0; k < bankTypesTable.Length; k++)
                            {
                                string[] bankTypesTableDetail = bankTypesTable[k].Split('-');
                                if (Convert.ToInt32(bankTypesTableDetail[0]) == Convert.ToInt32(sdr["debtBankTypeId"]))
                                {
                                    li.SubItems.Add(bankTypesTableDetail[1]);
                                    break;
                                }
                            }
                            li.SubItems.Add(sdr["debtDate"].ToString());
                            if(sortingType == 1) li.SubItems.Add(sdr["debtorId"].ToString());
                            else li.SubItems.Add(sdr["myDebtId"].ToString());
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

        private string[] findCustomerTable()
        {
            int customerCount = customerTableCount(), customerCount2 = 0;
            string[] customerTable = new string[customerCount];

            SqlCommand findCustomerDebtValTableCommand = new SqlCommand("SELECT * FROM customers", baglanti);
            SqlDataReader sdr = findCustomerDebtValTableCommand.ExecuteReader();
            while (sdr.Read())
            {
                if (customerCount2 <= customerCount)
                {
                    customerTable[customerCount2] = (sdr["customerId"].ToString()) + "-" + sdr["customerName"].ToString() + "-" + sdr["customerSurname"].ToString() + "-" + sdr["customerPhone"].ToString() + "-" + sdr["customerMail"].ToString() + "-" + sdr["customerAdress"].ToString() + "-" + sdr["customerReliabilityVal"].ToString();
                    customerCount2++;
                }
            }
            sdr.Close();
            return customerTable;
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
        private int customerTableCount()
        {
            int rowCount = 0;
            SqlCommand bankTableCountCommand = new SqlCommand("SELECT * FROM customers", baglanti);
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

        private void customerListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (customerListView.SelectedIndices.Count > 0)
            {
                selectedCustomerId = Convert.ToInt32(customerListView.SelectedItems[0].SubItems[11].Text);
                selectedTransactionId = Convert.ToInt32(customerListView.SelectedItems[0].SubItems[10].Text);
                customerDebtDetail customerDebtDetail = new customerDebtDetail();
                customerDebtDetail.ShowDialog();
            }
        }
    }
}