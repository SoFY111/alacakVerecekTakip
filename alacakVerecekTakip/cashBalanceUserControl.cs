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
    public partial class cashBalanceUserControl : MetroFramework.Controls.MetroUserControl
    {

        private static cashBalanceUserControl _instance;
        public static cashBalanceUserControl Instance
        {
            get{
                if (_instance == null)
                    _instance = new cashBalanceUserControl();
                return _instance;
            }
        }

        public cashBalanceUserControl()
        {
            InitializeComponent();
        }

        methods funcs = new methods();
        SqlConnection baglanti = methods.baglanti;
        string theme;

        private void fillTotalMoneyAssetsListViewColumns()
        {
            /*
             * para türlerinin olduğu listView'ın
             * başlıklarını yazıyoruz.
             * 
             * */
            totalMoneyAssetsListView.Items.Clear();
            totalMoneyAssetsListView.View = View.Details;
            totalMoneyAssetsListView.GridLines = true;
            totalMoneyAssetsListView.Columns.Add("Para Türü", 129);
            totalMoneyAssetsListView.Columns.Add("Toplam Para Miktarı", 129);
        }

        private void fillTotalMoneyAssetsListViewItems()
        {
            /*
             * para türlenin olduğu listView'ın bilgilerini dolduruyoruz.
             * 
             * */

            totalMoneyAssetsListView.Items.Clear();
            ListViewItem li = new ListViewItem();
            string[] moneyTypesTable = findExchangeMoneyFromIdToName();
            string[] sumMoneyTypeTable = findSumMoneyTypeTable();

            for (int i = 0; i < sumMoneyTypeTable.Length; i++){
                for (int k = 0; k < sumMoneyTypeTable.Length; k++){
                    string[] moneyTypesTableDetail = moneyTypesTable[i].Split('-');
                    string[] sumMoneyTypeTableDetail = sumMoneyTypeTable[k].Split('-');
                    if (Convert.ToInt32(moneyTypesTableDetail[0]) == Convert.ToInt32(sumMoneyTypeTableDetail[0])){
                        li = totalMoneyAssetsListView.Items.Add(moneyTypesTableDetail[1]);
                        li.SubItems.Add(sumMoneyTypeTableDetail[1]);
                        break;
                    }
                }
            }
        }

        private void fillTotalBankAssetsListViewColumns()
        {
            /*
             * banka türlerinin olduğu listView'ın başlıklarını doluruyoruz.
             * 
             * */

            totalBankAssetsListView.Items.Clear();
            totalBankAssetsListView.View = View.Details;
            totalBankAssetsListView.GridLines = true;
            totalBankAssetsListView.Columns.Add("Banka Türü", 156);
            totalBankAssetsListView.Columns.Add("Toplam Para Miktarı");
            totalBankAssetsListView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void fillTotalBankAssetsListViewItems()
        {
            /*
             * banka türlerinin olduğu listView'ın doluruyoruz.
             * 
             * */

            totalBankAssetsListView.Items.Clear();
            ListViewItem li = new ListViewItem();
            string[] sumMoneyInBankType = findSumMoneyInBankType(), bankTypesTable = findBankType();
            for (int i = 0; i < sumMoneyInBankType.Length; i++){
                string[] sumMoneyInBankTypeDetail = sumMoneyInBankType[i].Split('-');
                for (int j = 0; j < bankTypesTable.Length; j++){
                    string[] bankTypesTableDetail = bankTypesTable[j].Split('-');

                    if (sumMoneyInBankTypeDetail[0] == bankTypesTableDetail[0]){
                        li = totalBankAssetsListView.Items.Add(bankTypesTableDetail[1]);
                        li.SubItems.Add(sumMoneyInBankTypeDetail[1]);
                        break;
                    }
                }
            }
        }

        private void fillExchangeRateTableListViewColumns()
        {
            exchangeRateTableListView.Items.Clear();
            exchangeRateTableListView.View = View.Details;
            exchangeRateTableListView.GridLines = true;
            exchangeRateTableListView.Columns.Add("Para Türü", 201);
            exchangeRateTableListView.Columns.Add("Kur Oranı");
            exchangeRateTableListView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        private void fillExchangeRateTableListViewItems()
        {
            string[] moneyTypesTable = findExchangeMoneyFromIdToName(), exchangeRateTable = findExchangeRateTable();
            ListViewItem li = new ListViewItem();
            for (int i = 0; i < moneyTypesTable.Length; i++)
            {
                string[] moneyTypesTableDetail = moneyTypesTable[i].Split('-');
                for (int j = 0; j < exchangeRateTable.Length; j++)
                {
                    string[] exchangeRateTableDetail = exchangeRateTable[j].Split('-');
                    if (moneyTypesTableDetail[0] == exchangeRateTableDetail[0])
                    {
                        li = exchangeRateTableListView.Items.Add(moneyTypesTableDetail[1].ToString());
                        li.SubItems.Add(exchangeRateTableDetail[1].ToString());
                    }
                }
            }

        }

        private string[] findSumMoneyInBankType()
        {
            /*
             * 
             * ilk for döngüsünde banklarda ki para türüne
             * gore toplam miktarı buluyor.
             * 
             * */

            string[] sumMoneyInBankType = new string[moneyCount() * bankCount()];                          ////1)bankId, 2)moneyID, 3)moneyVal
            string[] moneyTypesTable = findExchangeMoneyFromIdToName(), bankTypesTable = findBankType(), moneyFundsTable = findMoneyFundsTable(), exchangeRateTable = findExchangeRateTable();
            string[] sumBaseMoneyInBankType = new string[bankCount()];
            int arrayCounter = 0;//dizinin kaçıncı elamanına ekleyeceğimizi tutan sayac

            for (int i = 0; i < bankTypesTable.Length; i++){
                string[] bankTypesTableDetail = bankTypesTable[i].Split('-');
                double sumMoneyType = 0;

                for (int k = 0; k < moneyCount(); k++){
                    string[] moneyTypesTableDetail = moneyTypesTable[k].Split('-');
                    sumMoneyType = 0;
                    for (int j = 0; j < moneyFundsTable.Length; j++){
                        string[] moneyFundsTableDetail = moneyFundsTable[j].Split('-');
                        if (Convert.ToInt32(bankTypesTableDetail[0]) == Convert.ToInt32(moneyFundsTableDetail[0])){
                            if (moneyTypesTableDetail[0] == moneyFundsTableDetail[1]){
                                double moneyVal;
                                try{
                                    string[] moneyFundsTableDoubleMoneyVal = moneyFundsTableDetail[2].Split(',');
                                    moneyVal = Convert.ToDouble(moneyFundsTableDoubleMoneyVal[0]) + (Convert.ToDouble(moneyFundsTableDoubleMoneyVal[1].Substring(0, 2)) / 100);
                                }
                                catch (Exception)
                                
                                {
                                    moneyVal = Convert.ToDouble(moneyFundsTableDetail[2]);
                                    //throw;
                                }
                                if (moneyFundsTableDetail[3] == "0" ) sumMoneyType -= moneyVal; //eğer moneyFunds tablosunda ki transactionType(işlem tipi) 0 ise çıkarma yapsın
                                else if (moneyFundsTableDetail[3] == "1" ) sumMoneyType += moneyVal;// eğer işlem tipi 1 ise toplama yapsın
                            }
                        }
                    }
                    sumMoneyInBankType[arrayCounter] = bankTypesTableDetail[0] + "-" + moneyTypesTableDetail[0] + "-" + sumMoneyType;////1)bankId, 2)moneyID, 3)moneyVal
                    arrayCounter++;
                }
            }

            int baseMoneyId = selectBaseMoneyTypeId();

            for (int l = 0; l < bankTypesTable.Length; l++){
                double newMoneyVal = 0;
                string bankTypesDetail2 ="";
                for (int m = 0; m < sumMoneyInBankType.Length; m++){
                    string[] bankTypesTableDetail = bankTypesTable[l].Split('-');
                    string[] sumMoneyInBankTypeDetail = sumMoneyInBankType[m].ToString().Split('-');
                    bankTypesDetail2 = bankTypesTableDetail[0];
                    if (sumMoneyInBankTypeDetail[0] == bankTypesTableDetail[0]){
                        for (int n = 0; n < moneyTypesTable.Length; n++){
                            string[] moneyTypesTableDetail = moneyTypesTable[n].Split('-');

                            if (sumMoneyInBankTypeDetail[1] == moneyTypesTableDetail[0]){
                                double exchangeRate = 0;

                                if (Convert.ToInt32(sumMoneyInBankTypeDetail[1]) != baseMoneyId) exchangeRate = findExchangeRate2(Convert.ToInt32(sumMoneyInBankTypeDetail[1]));
                                else exchangeRate = 1;

                                double moneyVal = 0;
                                string[] sumMoneyInBankTypeDetail2 = sumMoneyInBankTypeDetail[2].Split(',');
                                try{
                                    double afterPoint = Convert.ToDouble(Convert.ToDouble(sumMoneyInBankTypeDetail2[1].Substring(0, 2)));
                                    moneyVal = Convert.ToDouble(sumMoneyInBankTypeDetail2[0]) + (Convert.ToDouble(afterPoint / 100));
                                }
                                catch (Exception){
                                    moneyVal = Convert.ToDouble(sumMoneyInBankTypeDetail2[0]);
                                    //throw;
                                }
                                newMoneyVal += moneyVal * exchangeRate; //kur dengesine göre baz alınacak paradan oranı bulup çarpıp yeni diziye aktarıyor.
                            }
                        }
                    }
                }
                sumBaseMoneyInBankType[l] = bankTypesDetail2 + "-" + newMoneyVal.ToString();
            }
            return sumBaseMoneyInBankType;
        }

        private string selectBaseMoneyType()
        {
            string baseMoneyTypeName = "";
            SqlCommand selectBaseMoneyTypeCommand = new SqlCommand("SELECT * FROM moneyTypesTable WHERE isBaseMoney = 1", baglanti);
            SqlDataReader sdr = selectBaseMoneyTypeCommand.ExecuteReader();
            while (sdr.Read()){
                baseMoneyTypeName = sdr["moneyName"].ToString();
            }
            sdr.Close();
            return baseMoneyTypeName;
        }
        
        private int selectBaseMoneyTypeId()
        {
            int baseMoneyTypeName = 0;
            SqlCommand selectBaseMoneyTypeCommand = new SqlCommand("SELECT * FROM moneyTypesTable WHERE isBaseMoney = 1", baglanti);
            SqlDataReader sdr = selectBaseMoneyTypeCommand.ExecuteReader();
            while (sdr.Read()){
                baseMoneyTypeName = Convert.ToInt32(sdr["moneyId"]);
            }
            sdr.Close();
            return baseMoneyTypeName;
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

        private string[] findExchangeRateTable()
        {
            /*
             * exchangeRateTable tablomuzda bütün değerler int(id) olduğundan dolayı 
             * onları string'e dönüştürmek için moneyTypes tablosunu id ile birlikte
             * ismini bir diziye aktarıyoruz. Bunu kullanmak için stringlerde kullanılan
             * Split() metodunu çağırıyoruz.
             * */
            int exchangeCount1 = moneyCount()-1, exchangeCount2 = 0;
            string[] exchangeRateTable = new string[exchangeCount1];

            SqlCommand findExchangeMoneyFromIdToNameCommand = new SqlCommand("SELECT * FROM exchangeRateTable", baglanti);
            SqlDataReader sdr = findExchangeMoneyFromIdToNameCommand.ExecuteReader();
            while (sdr.Read()){
                if (exchangeCount2 <= exchangeCount1){
                    exchangeRateTable[exchangeCount2] = (sdr["exchangeMoneyType"].ToString()) + "-" + sdr["exchangeRate"].ToString();
                    exchangeCount2++;
                }
            }
            sdr.Close();
            return exchangeRateTable;
        }

        private string[] findSumMoneyTypeTable()
        {
            /*
             * para türlerinin toplamını buluyoruz
             * ve onu string dizisine aktarıyoruz daha sonra
             * fonksiyonu çağırdığımız yerde string değişkenler 
             * için olan Split() fonskiyonunu çağırıyoruz.
             * */
            int sumMoneyTypeCount1 = moneyCount(), sumMoneyTypeCount2 = 0;
            string[] sumMoneyTypeTable = new string[sumMoneyTypeCount1];

            SqlCommand findExchangeMoneyFromIdToNameCommand = new SqlCommand("SELECT * FROM sumAllMoney", baglanti);
            SqlDataReader sdr = findExchangeMoneyFromIdToNameCommand.ExecuteReader();
            while (sdr.Read()){
                if (sumMoneyTypeCount2 <= sumMoneyTypeCount1){
                    sumMoneyTypeTable[sumMoneyTypeCount2] = (sdr["moneyTypeId"].ToString()) + "-" + sdr["sumMoneyVal"].ToString();
                    sumMoneyTypeCount2++;
                }
            }
            sdr.Close();
            return sumMoneyTypeTable;
        }

        private string[] findMoneyFundsTable()
        {
            /*
             * moneyFunds tablosunda bankId, moneyTypeId, moneyVal ve transactionType
             * sütunlarını alıyoruz, burada ki bilgilere göre işlem yapacağız
             * */
            int moneyFundsTypeCount1 = moneyFundsCount(), moneyFundsTypeCount2 = 0;
            string[] smoneyFundsTypeTable = new string[moneyFundsTypeCount1];

            SqlCommand findExchangeMoneyFromIdToNameCommand = new SqlCommand("SELECT * FROM moneyFunds", baglanti);
            SqlDataReader sdr = findExchangeMoneyFromIdToNameCommand.ExecuteReader();
            while (sdr.Read()){
                if (moneyFundsTypeCount2 <= moneyFundsTypeCount1){
                    smoneyFundsTypeTable[moneyFundsTypeCount2] = (sdr["bankId"].ToString()) + "-" + sdr["MoneyTypeId"].ToString() + "-" + sdr["moneyVal"].ToString() + "-" + sdr["transactionType"].ToString();
                    moneyFundsTypeCount2++;
                }
            }
            sdr.Close();
            return smoneyFundsTypeTable;
        }

        private string[] findBankType()
        {
            int bankTypeCount1 = bankCount(), bankTypeCount2 = 0;
            string[] bankTypeTable = new string[bankTypeCount1];

            SqlCommand findExchangeMoneyFromIdToNameCommand = new SqlCommand("SELECT * FROM bankTypes", baglanti);
            SqlDataReader sdr = findExchangeMoneyFromIdToNameCommand.ExecuteReader();
            while (sdr.Read()){
                if (bankTypeCount2 <= bankTypeCount1){
                    bankTypeTable[bankTypeCount2] = (sdr["bankTypeId"].ToString()) + "-" + sdr["bankTypeName"].ToString();
                    bankTypeCount2++;
                }
            }
            sdr.Close();
            return bankTypeTable;
        }

        private double findExchangeRate2(int moneyId)
        {
            double exchangeRate = 0;
            SqlCommand findExchangeRate2Command = new SqlCommand("SELECT * FROM exchangeRateTable WHERE exchangeMoneyType = @exchangeMoneyId", baglanti);
            findExchangeRate2Command.Parameters.AddWithValue("@exchangeMoneyId", moneyId);
            SqlDataReader sdr = findExchangeRate2Command.ExecuteReader();
            while (sdr.Read()){
                exchangeRate = Convert.ToDouble(sdr["exchangeRate"]);
            }
            sdr.Close();
            return exchangeRate;
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

        private int bankCount()
        {
            int bankCountt = 0;
            SqlCommand bankCounttCommand = new SqlCommand("SELECT * FROM bankTypes", baglanti);
            SqlDataReader sdr = bankCounttCommand.ExecuteReader();
            while (sdr.Read()){
                bankCountt++;
            }
            sdr.Close();
            return bankCountt;
        } 
        
        private int moneyFundsCount()
        {
            /*
             * moneyFunds tablosunda kaç değer olduğunu getiren fonksiyon
             * */
            int moneyFundsCount = 0;
            SqlCommand moneyFundsCountCommand = new SqlCommand("SELECT * FROM moneyFunds", baglanti);
            SqlDataReader sdr = moneyFundsCountCommand.ExecuteReader();
            while (sdr.Read()){
                moneyFundsCount++;
            }
            sdr.Close();
            return moneyFundsCount;
        }

        public static void reloadForm()
        {
            _instance = null;
        }

        private void cashBalanceUserControl_Load(object sender, EventArgs e)
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
                helpPictureBox2.Image = alacakVerecekTakip.Properties.Resources.helpWhite;
                helpPictureBox3.Image = alacakVerecekTakip.Properties.Resources.helpWhite;
            }
            else{
                helpPictureBox.Image = alacakVerecekTakip.Properties.Resources.help;
                helpPictureBox2.Image = alacakVerecekTakip.Properties.Resources.help;
                helpPictureBox3.Image = alacakVerecekTakip.Properties.Resources.help;
            }

            baseMoneyLabel1.Text += " " + selectBaseMoneyType();
            baseMoneyLabel2.Text += " " + selectBaseMoneyType();
            fillTotalMoneyAssetsListViewColumns();
            fillTotalMoneyAssetsListViewItems();
            fillTotalBankAssetsListViewColumns();
            fillTotalBankAssetsListViewItems();
            fillExchangeRateTableListViewColumns();
            fillExchangeRateTableListViewItems();

            funcs.setToolTip(helpPictureBox, "'Kasa Bakiye' butonuna basıldığında aşağıda ki gibi bir form açılır.\n'Para Türüne Göre Toplam Varlıklarınız' tablosu hangi para türünden\nne kadar olduğunu gösterir.");
            funcs.setToolTip(helpPictureBox2, "'Banka Türüne Göre Toplam Varlıklarınız' tablosu herhangi bir\nbankada ki toplam varlıklarınızın baz alınan para türüne\nayarladığınız kur değeri ile orantılı şekilde eklenir.");
            funcs.setToolTip(helpPictureBox3, "'Kur Dengesi' tablosu o anki kurları\nTCMB Resmi sitesinden çekerek yazdırır.\nEğer sabit bir kur isterseniz elle\nayarlayabilirsiniz.");
        }
    }
}
