﻿using System;
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
    public partial class chequeTransactionsForm : MetroFramework.Forms.MetroForm
    {
        public chequeTransactionsForm()
        {
            InitializeComponent();
        }

        methods funcs = new methods();
        SqlConnection baglanti = methods.baglanti;
        public static int chequeTransactionsType = -1;
        string theme;

        private void fillChequeListViewColumns()
        {
            chequeListView.Items.Clear();
            chequeListView.View = View.Details;
            chequeListView.GridLines = true;
            chequeListView.Columns.Add("Çek Keşide Zamanı", 158);
            chequeListView.Columns.Add("Banka Türü", 158);
            chequeListView.Columns.Add("Banka Kodu", 158);
            chequeListView.Columns.Add("Para Miktarı", 158);
            chequeListView.Columns.Add("Para Türü", 150);
            chequeListView.Columns.Add("Çeki Veren Kişi", 158);
            chequeListView.Columns.Add("Çeki Alan Kişi", 158);
            chequeListView.Columns.Add("Çek İşelm Tipi", 155);
            chequeListView.Columns.Add("Çek Id");
            chequeListView.AutoResizeColumn(7, ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void fillChequeListViewItems()
        {
            chequeListView.Items.Clear();
            string chequeTransactionType = "";
            string[] bankTypesTable = findBankType(), moneyTypesTable = findExchangeMoneyFromIdToName();
            SqlCommand findChequeListViewCommand = new SqlCommand("SELECT * FROM chequeInfo ORDER BY chequeId DESC", baglanti);
            SqlDataReader sdr = findChequeListViewCommand.ExecuteReader();
            ListViewItem li = new ListViewItem();
            while (sdr.Read())
            {
                for (int i = 0; i < bankTypesTable.Length; i++)
                {
                    string[] bankTypesTableDetail = bankTypesTable[i].Split('-');
                    if (Convert.ToInt32(sdr["chequeBankId"]) == Convert.ToInt32(bankTypesTableDetail[0]))
                    {
                        for (int j = 0; j < moneyTypesTable.Length; j++)
                        {
                            string[] moneyTypesTableDetail = moneyTypesTable[j].Split('-');
                            if (Convert.ToInt32(sdr["chequeMoneyTypeId"]) == Convert.ToInt32(moneyTypesTableDetail[0]))
                            {
                                if (Convert.ToInt32(sdr["chequeTransactionType"]) == 1) chequeTransactionType = "Alma";
                                else if (Convert.ToInt32(sdr["chequeTransactionType"]) == 2) chequeTransactionType = "Verme";
                                li = chequeListView.Items.Add(sdr["chequeDate"].ToString());
                                li.SubItems.Add(bankTypesTableDetail[1]);
                                li.SubItems.Add(sdr["chequeBankCode"].ToString());
                                li.SubItems.Add(sdr["chequeVal"].ToString());
                                li.SubItems.Add(moneyTypesTableDetail[1]);
                                li.SubItems.Add(sdr["chequeDrawingName"].ToString());
                                li.SubItems.Add(sdr["chequeRecipientName"].ToString());
                                li.SubItems.Add(chequeTransactionType);
                                li.SubItems.Add(sdr["chequeId"].ToString());
                            }
                        }
                    }
                }

            }
            sdr.Close();
        }

        private string[] findBankType()
        {
            int bankTypeCount1 = bankCount(), bankTypeCount2 = 0;
            string[] bankTypeTable = new string[bankTypeCount1];

            SqlCommand findExchangeMoneyFromIdToNameCommand = new SqlCommand("SELECT * FROM bankTypes", baglanti);
            SqlDataReader sdr = findExchangeMoneyFromIdToNameCommand.ExecuteReader();
            while (sdr.Read())
            {
                if (bankTypeCount2 <= bankTypeCount1)
                {
                    bankTypeTable[bankTypeCount2] = (sdr["bankTypeId"].ToString()) + "-" + sdr["bankTypeName"].ToString();
                    bankTypeCount2++;
                }
            }
            sdr.Close();
            return bankTypeTable;
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

        private int bankCount()
        {
            int bankCountt = 0;
            SqlCommand bankCounttCommand = new SqlCommand("SELECT * FROM bankTypes", baglanti);
            SqlDataReader sdr = bankCounttCommand.ExecuteReader();
            while (sdr.Read())
            {
                bankCountt++;
            }
            sdr.Close();
            return bankCountt;
        }

        private void chequeTransactions_Load(object sender, EventArgs e)
        {
            this.StyleManager = metroStyleManager1;
            theme = funcs.themeChanger(0);

            if (theme == "light") metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Light;
            else metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            if (funcs.isConnect(baglanti) == true)
            {
                connectSituation.BackColor = Color.Lime;
                funcs.setToolTip(connectSituation, "Veri Tabanı Bağlantısı Var");
            }
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

            fillChequeListViewColumns();
            fillChequeListViewItems();
        }

        private void drawChequeButton_Click(object sender, EventArgs e)
        {
            chequeTransactionsType = 2;
            addChequeForm addChequeForm = new addChequeForm();
            addChequeForm.ShowDialog();
        }

        private void addChequeButton_Click(object sender, EventArgs e)
        {
            chequeTransactionsType = 1;
            addChequeForm addChequeForm = new addChequeForm();
            addChequeForm.ShowDialog();
        }
    }
}
