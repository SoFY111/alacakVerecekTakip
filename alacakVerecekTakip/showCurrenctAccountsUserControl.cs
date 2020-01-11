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
    public partial class showCurrenctAccountsUserControl : MetroFramework.Controls.MetroUserControl
    {

        private static showCurrenctAccountsUserControl _instance;
        public static showCurrenctAccountsUserControl Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new showCurrenctAccountsUserControl();
                return _instance;
            }
        }

        methods funcs = new methods();
        debtTransactionsMethods debtTransactionFuncs = new debtTransactionsMethods();
        SqlConnection baglanti = methods.baglanti;
        public static int selectedCustomerId = 0, selectedTransactionId = 0;
        string theme;

        public showCurrenctAccountsUserControl()
        {
            InitializeComponent();
        }

        private void fillCurrencyAccountListViewItems()
        {
            
            string[] bankTypesTable = findBabkTypesTable(), moneyTypesTable = findExchangeMoneyFromIdToName();
            ListViewItem li = new ListViewItem();
            for (int i = 0; i < bankTypesTable.Length; i++){
                string[] bankTypesTableDetail = bankTypesTable[i].Split('-');

                ListViewGroup lwgrp = new ListViewGroup(bankTypesTableDetail[1]);
                currencyAccountListView.Groups.Add(lwgrp);

                for (int j = 0; j < moneyTypesTable.Length; j++){
                    string[] moneyTypesTableDetail = moneyTypesTable[j].Split('-');

                    li = currencyAccountListView.Items.Add("");
                    li.SubItems.Add(moneyTypesTableDetail[1]);
                    li.SubItems.Add(doesItHaveEnoughMoney(bankTypesTableDetail[1], moneyTypesTableDetail[1]).ToString());
                    li.Group = lwgrp;
                }
            }
        }

        private double doesItHaveEnoughMoney(string bankTypeName, string moneyTypeName)
        {
            int bankId = debtTransactionFuncs.bankNameToId(bankTypeName), moneyId = debtTransactionFuncs.moneyNameToId(moneyTypeName);
            double sumMoney = 0;
            SqlCommand sumMoneyCommand = new SqlCommand("SELECT * FROM moneyFunds WHERE bankId = @bankId AND moneyTypeId = @moneyId", baglanti);
            sumMoneyCommand.Parameters.AddWithValue("@bankId", bankId);
            sumMoneyCommand.Parameters.AddWithValue("@moneyId", moneyId);
            SqlDataReader sdr = sumMoneyCommand.ExecuteReader();
            while (sdr.Read()){
                string[] moneyVal2;
                double moneyVal12, afterPoint2;
                try{
                    moneyVal2 = sdr["moneyVal"].ToString().Split(',');
                    moneyVal12 = Convert.ToDouble(moneyVal2[0]);
                    afterPoint2 = Convert.ToDouble(moneyVal2[1].Substring(0, 2));
                }
                catch (Exception){
                    moneyVal12 = Convert.ToDouble(sdr["moneyVal"].ToString());
                    afterPoint2 = 0;
                    //throw;
                }
                if (Convert.ToInt32(sdr["transactionType"]) == 0) sumMoney -= moneyVal12 + (afterPoint2 / 100);
                else if (Convert.ToInt32(sdr["transactionType"]) == 1) sumMoney += moneyVal12 + (afterPoint2 / 100);
            }
            sdr.Close();

            return sumMoney;
        }

        private string[] findBabkTypesTable()
        {
            int bankCount = bankTableCount(), bankCount2 = 0;
            string[] bankTypesTable = new string[bankCount];

            SqlCommand findCustomerDebtValTableCommand = new SqlCommand("SELECT * FROM bankTypes", baglanti);
            SqlDataReader sdr = findCustomerDebtValTableCommand.ExecuteReader();
            while (sdr.Read()){
                if (bankCount2 <= bankCount){
                    bankTypesTable[bankCount2] = sdr["bankTypeId"].ToString() + "-" + sdr["bankTypeName"].ToString();
                    bankCount2++;
                }
            }
            sdr.Close();
            return bankTypesTable;
        }

        private int bankTableCount()
        {
            int rowCount = 0;
            SqlCommand bankTableCountCommand = new SqlCommand("SELECT * FROM bankTypes", baglanti);
            SqlDataReader sdr = bankTableCountCommand.ExecuteReader();
            while (sdr.Read()){
                rowCount++;
            }
            sdr.Close();
            return rowCount;
        }

        private string[] findExchangeMoneyFromIdToName()
        {
            int moneyCount1 = moneyCount(), moneyCount2 = 0;
            string[] exchangeMoneyName = new string[moneyCount1];

            SqlCommand findExchangeMoneyFromIdToNameCommand = new SqlCommand("SELECT * FROM moneyTypesTable", baglanti);
            SqlDataReader sdr = findExchangeMoneyFromIdToNameCommand.ExecuteReader();
            while (sdr.Read()){
                if (moneyCount2 <= moneyCount1){
                    exchangeMoneyName[moneyCount2] = (sdr["moneyId"].ToString()) + "-" + sdr["moneyName"].ToString();
                    moneyCount2++;
                }
            }
            sdr.Close();
            return exchangeMoneyName;
        }

        private int moneyCount()
        {
            int moneyCountt = 0;
            SqlCommand moneyCountCommand = new SqlCommand("SELECT * FROM moneyTypesTable", baglanti);
            SqlDataReader sdr = moneyCountCommand.ExecuteReader();
            while (sdr.Read()){
                moneyCountt++;
            }
            sdr.Close();
            return moneyCountt;
        }

        public static void reloadForm()
        {
            _instance = null;
        }

        private void showCurrenctAccountsUserControl_Load(object sender, EventArgs e)
        {
            this.StyleManager = metroStyleManager1;
            theme = funcs.themeChanger(0);

            if (theme == "light") metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Light;
            else metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            if (funcs.isConnect(baglanti) == true) { }
            else{
                MetroFramework.MetroMessageBox.Show(this, "Veri Tabanı Bağlantısı Kurulamadığından Dolayı Program Kapatılıyor..", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            if (metroStyleManager1.Theme == MetroFramework.MetroThemeStyle.Dark){
                helpPictureBox.Image = alacakVerecekTakip.Properties.Resources.helpWhite;
            }
            else{
                helpPictureBox.Image = alacakVerecekTakip.Properties.Resources.help;
            }

            
            fillCurrencyAccountListViewItems();
        }
    }
}
