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

        private string findBaseMoneyType()
        {
            string returnedVal = "";
            SqlCommand findBaseMoneyTypeCommand = new SqlCommand("SELECT * FROM moneyTypesTable WHERE isBaseMoney = 1", baglanti);
            SqlDataReader sdr = findBaseMoneyTypeCommand.ExecuteReader();
            while (sdr.Read()){
                returnedVal = sdr["moneyName"].ToString();
            }
            sdr.Close();

            return returnedVal;
        }

        private int findMoneyCount()
        {
            int returnedVal = 0;
            SqlCommand findMoneyCountCommand = new SqlCommand("SELECT COUNT(moneyId) AS count FROM moneyTypesTable", baglanti);
            SqlDataReader sdr = findMoneyCountCommand.ExecuteReader();
            while (sdr.Read()){
                returnedVal = Convert.ToInt32(sdr["count"]);
            }
            sdr.Close();

            return returnedVal;
        }

        private int findBankCount()
        {
            int returnedVal = 0;
            SqlCommand findMoneyCountCommand = new SqlCommand("SELECT COUNT(bankTypeId) AS count FROM bankTypes", baglanti);
            SqlDataReader sdr = findMoneyCountCommand.ExecuteReader();
            while (sdr.Read())
            {
                returnedVal = Convert.ToInt32(sdr["count"]);
            }
            sdr.Close();

            return returnedVal;
        }

        private double finSumAllMoney()
        {
            double summAllMoney = 0;
            string[] outGoingTable = findMoneyFundsTransaction(0), inComingMoneyTable = findMoneyFundsTransaction(1), exchangeRateTable = findExchangeRateTable();


            for (int i = 0; i < inComingMoneyTable.Length; i++){
                string[] incomingMoneyDetail = inComingMoneyTable[i].Split('-');
                for (int k = 0; k < exchangeRateTable.Length; k++){
                    string[] exchangeRateTableDetail = exchangeRateTable[k].Split('-');
                    if (Convert.ToInt32(incomingMoneyDetail[0]) == findBaseMoneyId()){
                        summAllMoney += Convert.ToDouble(incomingMoneyDetail[1]);
                        break;
                    }
                    else if (Convert.ToInt32(incomingMoneyDetail[0]) == Convert.ToInt32(exchangeRateTableDetail[1])) { 
                        summAllMoney += (Convert.ToDouble(incomingMoneyDetail[1]) * Convert.ToDouble(exchangeRateTableDetail[2]));
                        break;
                    }
                }
            }

            for (int j = 0; j < outGoingTable.Length; j++){
                string[] outGoingTableDetail = outGoingTable[j].Split('-');
                for (int l = 0; l < exchangeRateTable.Length; l++){
                    string[] exchangeRateTableDetail = exchangeRateTable[l].Split('-');
                    if (Convert.ToInt32(outGoingTableDetail[0]) == findBaseMoneyId()){
                        summAllMoney -= Convert.ToDouble(outGoingTableDetail[1]);
                        break;
                    }
                    else if (Convert.ToInt32(outGoingTableDetail[0]) == Convert.ToInt32(exchangeRateTableDetail[1])) { 
                        summAllMoney -= (Convert.ToDouble(outGoingTableDetail[1]) * Convert.ToDouble(exchangeRateTableDetail[2]));
                        break;
                    }
                }
            }

            return summAllMoney;
        }

        private double findSumMoneyFundsTransaction(int transactionType)
        {
            string[] moneyFundsTable = findMoneyFundsTransaction(transactionType), exchangeRateTable = findExchangeRateTable();
            double sumAllMoney = 0;
            for (int i = 0; i < moneyFundsTable.Length; i++){
                string[] outGoingMoneysTableDetail = moneyFundsTable[i].Split('-');

                for (int k = 0; k < exchangeRateTable.Length; k++){
                    string[] exchangeRateTableDetail = exchangeRateTable[k].Split('-');
                    if (Convert.ToInt32(outGoingMoneysTableDetail[0]) == findBaseMoneyId()){
                        sumAllMoney += Convert.ToDouble(outGoingMoneysTableDetail[1]);
                        break;
                    }
                    else if (Convert.ToInt32(outGoingMoneysTableDetail[0]) == Convert.ToInt32(exchangeRateTableDetail[1])){
                        sumAllMoney += (Convert.ToDouble(outGoingMoneysTableDetail[1]) * Convert.ToDouble(exchangeRateTableDetail[2]));
                        break;
                    }
                }
            }
            return sumAllMoney;
        }

        private string[] findMoneyFundsTransaction(int transactionType)
        {
            int outGoingMoneyCountt = moneyFundsTransactionCount(transactionType), outGoingMoneyCount2 = 0;
            string[] outGoingMoneyTypes = new string[outGoingMoneyCountt];

            SqlCommand findCustomerDebtValTableCommand = new SqlCommand("SELECT * FROM moneyFunds Where transactionType = @transactionType", baglanti);
            findCustomerDebtValTableCommand.Parameters.AddWithValue("@transactionType", transactionType);
            SqlDataReader sdr = findCustomerDebtValTableCommand.ExecuteReader();
            while (sdr.Read())
            {
                if (outGoingMoneyCount2 <= outGoingMoneyCountt)
                {
                    outGoingMoneyTypes[outGoingMoneyCount2] = sdr["moneyTypeId"].ToString() + "-" + sdr["moneyVal"].ToString();
                    outGoingMoneyCount2++;
                }
            }
            sdr.Close();
            return outGoingMoneyTypes;
        }

        private int moneyFundsTransactionCount(int transactionType)
        {
            int rowCount = 0;
            SqlCommand moneyFundsTransactionCountCommand = new SqlCommand("SELECT * FROM moneyFunds WHERE transactionType = @transactionType", baglanti);
            moneyFundsTransactionCountCommand.Parameters.AddWithValue("@transactionType", transactionType);
            SqlDataReader sdr = moneyFundsTransactionCountCommand.ExecuteReader();
            while (sdr.Read())
            {
                rowCount++;
            }
            sdr.Close();
            return rowCount;
        }

        private string[] findExchangeRateTable()
        {
            int exchangeRateTableCountt = exhangeRateTableCount(), exchangeRateTableCount2 = 0;
            string[] excahngeRateTable = new string[exchangeRateTableCountt];

            SqlCommand findCustomerDebtValTableCommand = new SqlCommand("SELECT * FROM exchangeRateTable", baglanti);
            SqlDataReader sdr = findCustomerDebtValTableCommand.ExecuteReader();
            while (sdr.Read())
            {
                if (exchangeRateTableCount2 <= exchangeRateTableCountt)
                {
                    excahngeRateTable[exchangeRateTableCount2] = sdr["exchangedMoneyType"].ToString() + "-" + sdr["exchangeMoneyType"].ToString() + "-" + sdr["exchangeRate"].ToString();
                    exchangeRateTableCount2++;
                }
            }
            sdr.Close();
            return excahngeRateTable;
        }

        private int exhangeRateTableCount()
        {
            int rowCount = 0;
            SqlCommand bankTableCountCommand = new SqlCommand("SELECT * FROM exchangeRateTable", baglanti);
            SqlDataReader sdr = bankTableCountCommand.ExecuteReader();
            while (sdr.Read())
            {
                rowCount++;
            }
            sdr.Close();
            return rowCount;
        }

        private int findBaseMoneyId()
        {
            int returnedVal = 0;
            SqlCommand findBaseMoneyTypeCommand = new SqlCommand("SELECT * FROM moneyTypesTable WHERE isBaseMoney = 1", baglanti);
            SqlDataReader sdr = findBaseMoneyTypeCommand.ExecuteReader();
            while (sdr.Read())
            {
                returnedVal = Convert.ToInt32(sdr["moneyId"]);
            }
            sdr.Close();

            return returnedVal;
        }

        private double findMonthlySumIncomingMoney(int transactionType, int month, int year)
        {
            double sumAllMoney = 0;
            string[] monthlyIncomingMoneyFundsTable = findMonthlyMoneyFundsTable(transactionType, month, year), exchangeRateTable = findExchangeRateTable();

            for (int i = 0; i < monthlyIncomingMoneyFundsTable.Length; i++){
                string[] monthlyIncomingMoneyFundsTableDetail = monthlyIncomingMoneyFundsTable[i].Split('-');
                for (int j = 0; j < exchangeRateTable.Length; j++){
                    string[] exchangeRateTableDetail = exchangeRateTable[j].Split('-');
                    if (Convert.ToInt32(monthlyIncomingMoneyFundsTableDetail[0]) == findBaseMoneyId()){
                        sumAllMoney += Convert.ToDouble(monthlyIncomingMoneyFundsTableDetail[1]);
                        break;
                    }
                    else if (Convert.ToInt32(monthlyIncomingMoneyFundsTableDetail[0]) == Convert.ToInt32(exchangeRateTableDetail[1])){
                        sumAllMoney += (Convert.ToDouble(monthlyIncomingMoneyFundsTableDetail[1]) * Convert.ToDouble(exchangeRateTableDetail[2]));
                        break;
                    }
                }
            }


            return sumAllMoney;
        }

        private double findMonthlyOutGoingMoney(int transactionType, int month, int year)
        {
            double sumAllMoney = 0;
            string[] monthlyOutGoingMoneyFundsTable = findMonthlyMoneyFundsTable(transactionType, month, year), exchangeRateTable = findExchangeRateTable();

            for (int i = 0; i < monthlyOutGoingMoneyFundsTable.Length; i++)
            {
                string[] monthlyIncomingMoneyFundsTableDetail = monthlyOutGoingMoneyFundsTable[i].Split('-');
                for (int j = 0; j < exchangeRateTable.Length; j++)
                {
                    string[] exchangeRateTableDetail = exchangeRateTable[j].Split('-');
                    if (Convert.ToInt32(monthlyIncomingMoneyFundsTableDetail[0]) == findBaseMoneyId())
                    {
                        sumAllMoney += Convert.ToDouble(monthlyIncomingMoneyFundsTableDetail[1]);
                        break;
                    }
                    else if (Convert.ToInt32(monthlyIncomingMoneyFundsTableDetail[0]) == Convert.ToInt32(exchangeRateTableDetail[1]))
                    {
                        sumAllMoney += (Convert.ToDouble(monthlyIncomingMoneyFundsTableDetail[1]) * Convert.ToDouble(exchangeRateTableDetail[2]));
                        break;
                    }
                }
            }

            return sumAllMoney;
        }

        private string[] findMonthlyMoneyFundsTable(int transactionType, int month, int year)
        {
            int monthlyMoneyFundsTableRowCountt = monthlyMoneyFundsTableRowCount(transactionType, month, year), monthlyMoneyFundsTabel2 = 0;
            string[] monthlyMoneyFundsTable = new string[monthlyMoneyFundsTableRowCountt];

            SqlCommand findCustomerDebtValTableCommand = new SqlCommand("SELECT * FROM moneyFunds Where transactionType = @transactionType", baglanti);
            findCustomerDebtValTableCommand.Parameters.AddWithValue("@transactionType", transactionType);
            SqlDataReader sdr = findCustomerDebtValTableCommand.ExecuteReader();
            while (sdr.Read())
            {
                if (monthlyMoneyFundsTabel2 <= monthlyMoneyFundsTableRowCountt)
                {
                    if (Convert.ToDateTime(sdr["transactionDate"]) > Convert.ToDateTime("01/" + month + "/" + year + " 00:00:00.00") && Convert.ToDateTime(sdr["transactionDate"]) < Convert.ToDateTime("30/" + month + "/" + year + " 23:29:59.00")){
                        monthlyMoneyFundsTable[monthlyMoneyFundsTabel2] = sdr["moneyTypeId"].ToString() + "-" + sdr["moneyVal"].ToString();
                        monthlyMoneyFundsTabel2++;
                    }
                }
            }
            sdr.Close();
            return monthlyMoneyFundsTable;
        }

        private int monthlyMoneyFundsTableRowCount(int transactionType, int month, int year)
        {
            int rowCount = 0;
            SqlCommand monthlyMoneyFundsTableRowCountCommand = new SqlCommand("SELECT * FROM moneyFunds WHERE transactionType = @transactionType", baglanti);
            monthlyMoneyFundsTableRowCountCommand.Parameters.AddWithValue("@transactionType", transactionType);
            SqlDataReader sdr = monthlyMoneyFundsTableRowCountCommand.ExecuteReader();
            while (sdr.Read())
            {
                if (Convert.ToDateTime(sdr["transactionDate"]) > Convert.ToDateTime("01/" + month + "/" + year + " 00:00:00.00") && Convert.ToDateTime(sdr["transactionDate"]) < Convert.ToDateTime("30/" + month + "/" + year + " 23:29:59.00"))
                    rowCount++;
            }
            sdr.Close();
            return rowCount;
        }

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
                
            }
            else
            {
                
            }

            DateTime nowTime = DateTime.Now;
            string[] nowTimeDetail = nowTime.ToString().Split(' ');
            string[] nowTimeDetail2 = nowTimeDetail[0].Split('.');


            baseMoneyLabel2.Text = findBaseMoneyType();
            moneyCountLabel.Text = findMoneyCount().ToString() + " Farklı Para Türü Kullanıyorsunuz";
            bankCountLabel.Text = findBankCount().ToString() + " Farklı Banka Türü Kullanıyorsunuz";
            sumOutGoingMoneyLabel2.Text = findSumMoneyFundsTransaction(0).ToString();
            sumIncomingMoneyLabel2.Text = findSumMoneyFundsTransaction(1).ToString();
            cashBalanceLabel2.Text = finSumAllMoney().ToString();
            thisMonthSumMoneyLabel2.Text = findMonthlySumIncomingMoney(1, Convert.ToInt32(nowTimeDetail2[1]),Convert.ToInt32(nowTimeDetail2[2])).ToString();
            thisMonthOutGoingMoneyLabel2.Text = findMonthlyOutGoingMoney(0, Convert.ToInt32(nowTimeDetail2[1]),Convert.ToInt32(nowTimeDetail2[2])).ToString();
            //geçen aya göre bu ayki toplam gelir formül => (buAykiGelir * 100) / geçen ayki Gelir
            double thisMonthIncomingMoney = findMonthlySumIncomingMoney(1, Convert.ToInt32(nowTimeDetail2[1]), Convert.ToInt32(nowTimeDetail2[2]));

            int lastMonth, lastYear;
            if (nowTimeDetail2[1] == "01")
            {
                lastMonth = 12;
                lastYear = Convert.ToInt32(nowTimeDetail2[2]) - 1;
            }
            else
            {
                lastMonth = Convert.ToInt32(nowTimeDetail2[1]) - 1;
                lastYear = Convert.ToInt32(nowTimeDetail2[2]) - 1;
            }

            double lastMonthIncomingMoney = findMonthlySumIncomingMoney(1, lastMonth, lastYear);

            string lastMonthIcomingMoneyVSThisMonth = ((thisMonthIncomingMoney * 100) / lastMonthIncomingMoney).ToString();
            string[] moneyVal1;
            int lastMonthSumInComingMoneyVSthisMonthSumIncoming = 0;
            try
            {
                moneyVal1 = lastMonthIcomingMoneyVSThisMonth.Split(',');
                lastMonthSumInComingMoneyVSthisMonthSumIncoming = Convert.ToInt32(moneyVal1[0]);
            }
            catch (Exception)
            {
                lastMonthSumInComingMoneyVSthisMonthSumIncoming = Convert.ToInt32(lastMonthIcomingMoneyVSThisMonth);
                //throw;
            }

            if (lastMonthSumInComingMoneyVSthisMonthSumIncoming > 0 && lastMonthSumInComingMoneyVSthisMonthSumIncoming < 100){
                sumThisMonthInComingMoneyVSLastMonthInComingMoneyGauge.Value = lastMonthSumInComingMoneyVSthisMonthSumIncoming;
                sumThisMonthInComingMoneyVSLastMonthInComingMoneyGauge.ProgressColor1 = Color.FromArgb(0, 174, 219);
                sumThisMonthInComingMoneyVSLastMonthInComingMoneyGauge.ProgressColor2 = Color.FromArgb(0, 174, 219);
            }
            else{
                sumThisMonthInComingMoneyVSLastMonthInComingMoneyGauge.Value = 100;
                sumThisMonthInComingMoneyVSLastMonthInComingMoneyGauge.ProgressColor1 = Color.Red;
                sumThisMonthInComingMoneyVSLastMonthInComingMoneyGauge.ProgressColor2 = Color.Red;
            }

            funcs.setToolTip(sumThisMonthInComingMoneyVSLastMonthInComingMoneyGauge, "Bu ayki geliriniz:" + thisMonthIncomingMoney.ToString() + "\nGeçen ayki geliriniz:" + lastMonthIncomingMoney.ToString() + "\nOran:%" + lastMonthSumInComingMoneyVSthisMonthSumIncoming);
            
            //geçen aya göre bu ayki toplam gider formül => (buAykiGider * 100) / geçen ayki gider
            
            double thisMonthOutGoingMoney = findMonthlySumIncomingMoney(0, Convert.ToInt32(nowTimeDetail2[1]), Convert.ToInt32(nowTimeDetail2[2]));
            double lastMonthOutGoingMoney = findMonthlySumIncomingMoney(0, lastMonth, lastYear);
            string lastMonthOutGoingMoneyVSThisMonth;

            lastMonthOutGoingMoneyVSThisMonth = ((thisMonthOutGoingMoney * 100) / lastMonthOutGoingMoney).ToString();


            string[] moneyVal2;
            int lastMonthSumOutGoingMoneyVSthisMonthSumOutGoing = 0;
            try{
                moneyVal2 = lastMonthOutGoingMoneyVSThisMonth.Split(',');
                lastMonthSumOutGoingMoneyVSthisMonthSumOutGoing = Convert.ToInt32(moneyVal2[0]);
            }
            catch (Exception){
                lastMonthSumOutGoingMoneyVSthisMonthSumOutGoing = Convert.ToInt32(lastMonthOutGoingMoneyVSThisMonth);
                //throw;
            }

            if (lastMonthSumOutGoingMoneyVSthisMonthSumOutGoing < 100 && lastMonthSumOutGoingMoneyVSthisMonthSumOutGoing > 0){
                lastMonthOutGoingMoneyVsThisMonthOutGoingMoneyGauge.Value = lastMonthSumOutGoingMoneyVSthisMonthSumOutGoing;
                lastMonthOutGoingMoneyVsThisMonthOutGoingMoneyGauge.ProgressColor1 = Color.FromArgb(0, 174, 219);
                lastMonthOutGoingMoneyVsThisMonthOutGoingMoneyGauge.ProgressColor2 = Color.FromArgb(0, 174, 219);
            }
            else
            {
                lastMonthOutGoingMoneyVsThisMonthOutGoingMoneyGauge.Value = 100;
                lastMonthOutGoingMoneyVsThisMonthOutGoingMoneyGauge.ProgressColor1 = Color.Red;
                lastMonthOutGoingMoneyVsThisMonthOutGoingMoneyGauge.ProgressColor2 = Color.Red;
            }

            funcs.setToolTip(lastMonthOutGoingMoneyVsThisMonthOutGoingMoneyGauge, "Geçen ayki gideriniz:" + thisMonthOutGoingMoney.ToString() + "\nGeçen ayki gideriniz:" + lastMonthOutGoingMoney.ToString() + "\nOran:%" + lastMonthSumOutGoingMoneyVSthisMonthSumOutGoing);

            //bu ay gelen paraya göre bu ayki gider formül => (buAykiGelir * 100) / bu ayki gider

            double thisMonthInComingMoney1 = findMonthlySumIncomingMoney(1, Convert.ToInt32(nowTimeDetail2[1]), Convert.ToInt32(nowTimeDetail2[2]));
            double thisMonthOutGoingMoney1 = findMonthlySumIncomingMoney(0, Convert.ToInt32(nowTimeDetail2[1]), Convert.ToInt32(nowTimeDetail2[2]));
            string thisMonthOutGoingMoneyVSThisMonthInComingMoney;

            thisMonthOutGoingMoneyVSThisMonthInComingMoney = ((thisMonthInComingMoney1 * 100) / thisMonthOutGoingMoney1).ToString();


            string[] moneyVal3;
            int thisMonthSumOutGoingMoneyVSthisMonthSumIncoming = 0;
            try
            {
                moneyVal3 = thisMonthOutGoingMoneyVSThisMonthInComingMoney.Split(',');
                thisMonthSumOutGoingMoneyVSthisMonthSumIncoming = Convert.ToInt32(moneyVal3[0]);
            }
            catch (Exception)
            {
                thisMonthSumOutGoingMoneyVSthisMonthSumIncoming = Convert.ToInt32(thisMonthOutGoingMoneyVSThisMonthInComingMoney);
                //throw;
            }

            if (thisMonthSumOutGoingMoneyVSthisMonthSumIncoming < 100 && thisMonthSumOutGoingMoneyVSthisMonthSumIncoming > 0)
            {
                sumThisMonthInComingMoneyVSsumThisMonthOutGoingMoney.Value = thisMonthSumOutGoingMoneyVSthisMonthSumIncoming;
                sumThisMonthInComingMoneyVSsumThisMonthOutGoingMoney.ProgressColor1 = Color.FromArgb(0, 174, 219);
                sumThisMonthInComingMoneyVSsumThisMonthOutGoingMoney.ProgressColor2 = Color.FromArgb(0, 174, 219);
            }
            else
            {
                sumThisMonthInComingMoneyVSsumThisMonthOutGoingMoney.Value = 100;
                sumThisMonthInComingMoneyVSsumThisMonthOutGoingMoney.ProgressColor1 = Color.Red;
                sumThisMonthInComingMoneyVSsumThisMonthOutGoingMoney.ProgressColor2 = Color.Red;
            }
            funcs.setToolTip(sumThisMonthInComingMoneyVSsumThisMonthOutGoingMoney, "Bu ayki geliriniz:" + thisMonthInComingMoney1.ToString() + "\nBu ayki gideriniz:" + thisMonthOutGoingMoney1.ToString() + "\nOran:%" + thisMonthSumOutGoingMoneyVSthisMonthSumIncoming);

        }
    }
}
