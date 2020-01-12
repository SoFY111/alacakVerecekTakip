using System;
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
    public partial class moneyTransactionForm : MetroFramework.Forms.MetroForm
    {
        public moneyTransactionForm()
        {
            InitializeComponent();
        }

        methods funcs = new methods();
        debtTransactionsMethods debtTransactionFuncs = new debtTransactionsMethods();
        SqlConnection baglanti = methods.baglanti;
        string theme;
        int transactionType = 0;

        private void fillCustomerNameAndSurnameCombo()
        {
            string[] customersDebtorIds = findDistinctCustomersDebtorIds();
            for (int i = 0; i < customersDebtorIds.Length; i++)
            {
                SqlCommand fillCustomerNameAndSurnameComboCommand = new SqlCommand("SELECT * FROM customers WHERE customerId = @customerId ORDER BY customerName", baglanti);
                fillCustomerNameAndSurnameComboCommand.Parameters.AddWithValue("@customerId", customersDebtorIds[i]);
                SqlDataReader sdr = fillCustomerNameAndSurnameComboCommand.ExecuteReader();
                while (sdr.Read())
                {
                    customerNameAndSurnameCombo.Items.Add(sdr["customerName"].ToString() + " " + sdr["customerSurname"].ToString());
                }
                sdr.Close();
                customerNameAndSurnameCombo.SelectedIndex = 0;
            }
        }

        private void fillCustomerDebtListCombo(string customerNameAndSurname)
        {
            customerDebtListCombo.Items.Clear();
            string[] customerNameAndSurnameDetail = customerNameAndSurname.Split(' ');
            int customerId = findCustomerId(customerNameAndSurnameDetail[0], customerNameAndSurnameDetail[1]);
            string[] customerDebtorTable = findCustomersDebtorTable(customerId), customerMyDebtTable = findCustomersMyDebtTable(customerId);

            SqlCommand findCustomerTransactionsCommand = new SqlCommand("SELECT * FROM customersTransactionType WHERE customerId = @customerId AND transactionType = @customerTransactionTypeId", baglanti);
            findCustomerTransactionsCommand.Parameters.AddWithValue("@customerId", customerId);
            findCustomerTransactionsCommand.Parameters.AddWithValue("@customerTransactionTypeId", transactionType);

            SqlDataReader sdr = findCustomerTransactionsCommand.ExecuteReader();
            while (sdr.Read())
            {
                if (transactionType == 1)
                {
                    for (int i = 0; i < customerDebtorTable.Length; i++)
                    {
                        string[] customerDebtorTableDetail = customerDebtorTable[i].Split('-');
                        if (Convert.ToInt32(customerDebtorTableDetail[2]) == Convert.ToInt32(sdr["customerTransactionTypeId"])){
                            customerDebtListCombo.Items.Add(sdr["customerTransactionTypeId"].ToString() + "-" + "Borç Verme" + "-" + customerDebtorTableDetail[4] + "-" + sdr["transactionDate"].ToString());
                        }
                    }
                }
                else if (transactionType == 0)
                {
                    for (int i = 0; i < customerMyDebtTable.Length; i++)
                    {
                        string[] customerMyDebtTableDetail = customerMyDebtTable[i].Split('-');
                        if (Convert.ToInt32(customerMyDebtTableDetail[2]) == Convert.ToInt32(sdr["customerTransactionTypeId"]))
                        {
                            customerDebtListCombo.Items.Add(sdr["customerTransactionTypeId"].ToString() + "-" + "Borç Alma" + "-" + customerMyDebtTableDetail[4] + "-" + sdr["transactionDate"].ToString());
                        }
                    }
                }
            }
            sdr.Close();
        }
        private void fillCustomerDebtListViewColumns(int debtType)
        {
            /*
             * debtType=>0:Peşin
             * debtType=>1:Taksit
             * 
             * */
            customerDebtListView.Clear();
            customerDebtListView.Items.Clear();
            customerDebtListView.View = View.Details;
            customerDebtListView.GridLines = true;

            if (debtType == 0)
            {
                customerDebtListView.Columns.Add("Para Ödenen Tarih", 128);
                customerDebtListView.Columns.Add("Para Tutarı", 128);
                customerDebtListView.Columns.Add("Ödenen Tutar", 128);
                customerDebtListView.Columns.Add("Para Türü", 128);
                customerDebtListView.Columns.Add("Banka Türü", 128);
                customerDebtListView.Columns.Add("Para Verilme Tarihi", 128);
                customerDebtListView.Columns.Add("Para Ödenmesi Gereken Tarih", 128);
            }
            else
            {
                customerDebtListView.Columns.Add("Para Ödenen Tarih", 128);
                customerDebtListView.Columns.Add("Ödenecek Taksit", 127);
                customerDebtListView.Columns.Add("Ödenecek Taksit Tarihi", 128);
                customerDebtListView.Columns.Add("Ödenemsi Gereken Minimum Para Tutarı", 128);
                customerDebtListView.Columns.Add("Ödenene Para Tutarı", 128);
                customerDebtListView.Columns.Add("Para Türü", 128);
                customerDebtListView.Columns.Add("Banka Türü", 128);
            }
        }

        private void fillCustomerDebtListViewItems(int debtTypeId, int transactionTypeId, int transactionId)
        {
            /*
             * debtType=>0:Peşin
             * debtType=>1:Taksit
             * 
             * transactionType=>0:Borç Alma
             * transactionType=>1:Borç Verme
             * 
             * */
            customerDebtListView.Items.Clear();

            if (debtTypeId == 0)
            {
                string sqlCommandText = "";
                if (transactionTypeId == 0) sqlCommandText = "SELECT * FROM customersMyDebt WHERE transactionTypeId = @transactionTypeId";
                else if (transactionTypeId == 1) sqlCommandText = "SELECT * FROM customersDebtor WHERE transactionTypeId = @transactionTypeId";

                string[] moneyTypesTable = findExchangeMoneyFromIdToName(), bankTypesTable = findBankTypesTable();
                SqlCommand findDebtDetailCommand = new SqlCommand(sqlCommandText, baglanti);
                findDebtDetailCommand.Parameters.AddWithValue("@transactionTypeId", transactionId);
                SqlDataReader sdr = findDebtDetailCommand.ExecuteReader();
                ListViewItem li = new ListViewItem();
                while (sdr.Read())
                {
                    if (Convert.ToDateTime(sdr["debtPaymentDate"]) == Convert.ToDateTime("2000-01-01 00:00:00.000")) li = customerDebtListView.Items.Add("Ödenmedi");
                    else li = customerDebtListView.Items.Add(sdr["debtPaymentDate"].ToString());

                    li.SubItems.Add(sdr["debtVal"].ToString());
                    li.SubItems.Add(sdr["debtPaymentVal"].ToString());
                    for (int i = 0; i < moneyTypesTable.Length; i++)
                    {
                        string[] moneyTypesTableDetail = moneyTypesTable[i].Split('-');
                        if (Convert.ToInt32(moneyTypesTableDetail[0]) == Convert.ToInt32(sdr["debtMoneyTypeId"]))
                        {
                            li.SubItems.Add(moneyTypesTableDetail[1]);
                            break;
                        }
                    }

                    for (int j = 0; j < bankTypesTable.Length; j++)
                    {
                        string[] bankTypesTableDetail = bankTypesTable[j].Split('-');
                        if (Convert.ToInt32(bankTypesTableDetail[0]) == Convert.ToInt32(sdr["debtBankTypeId"]))
                        {
                            li.SubItems.Add(bankTypesTableDetail[1]);
                            break;
                        }
                    }

                    li.SubItems.Add(sdr["debtDate"].ToString());
                    li.SubItems.Add(sdr["debtMinPaymentDate"].ToString());


                }
                sdr.Close();
            }
            else
            {
                string[] customerDebtOrDebtorTable, moneyTypesTable = findExchangeMoneyFromIdToName(), bankTypesTable = findBankTypesTable();
                if (transactionTypeId == 0) customerDebtOrDebtorTable = findCustomersMyDebtTable();
                else customerDebtOrDebtorTable = findCustomersDebtorTable();

                SqlCommand findDebtInstallmentCommand = new SqlCommand("SELECT * FROM customersInstallment WHERE transactionTypeId = @transactionTypeId ORDER BY installmentId", baglanti);
                findDebtInstallmentCommand.Parameters.AddWithValue("@transactionTypeId", transactionId);
                SqlDataReader sdr = findDebtInstallmentCommand.ExecuteReader();
                ListViewItem li = new ListViewItem();

                while (sdr.Read())
                {
                    if (Convert.ToDateTime(sdr["installmentPaymentDate"]) == Convert.ToDateTime("2000-01-01 00:00:00")) li = customerDebtListView.Items.Add("Ödenmedi");
                    else li = customerDebtListView.Items.Add(sdr["installmentPaymentDate"].ToString());

                    li.SubItems.Add(sdr["installmentPaymentCounter"].ToString());
                    li.SubItems.Add(sdr["installmentMinPaymentDate"].ToString());
                    li.SubItems.Add(sdr["installmentMinPaymentVal"].ToString());
                    li.SubItems.Add(sdr["installmentPaymentVal"].ToString());
                    for (int i = 0; i < customerDebtOrDebtorTable.Length; i++)
                    {
                        string[] customerDebtOrDebtorTableDetail = customerDebtOrDebtorTable[i].Split('-');
                        if (transactionId == Convert.ToInt32(customerDebtOrDebtorTableDetail[2]))
                        {
                            for (int j = 0; j < moneyTypesTable.Length; j++)
                            {
                                string[] moneyTypesTableDetail = moneyTypesTable[j].Split('-');
                                if (Convert.ToInt32(customerDebtOrDebtorTableDetail[5]) == Convert.ToInt32(moneyTypesTableDetail[0]))
                                {
                                    li.SubItems.Add(moneyTypesTableDetail[1]);
                                    break;
                                }

                            }
                        }
                    }

                    for (int i = 0; i < customerDebtOrDebtorTable.Length; i++)
                    {
                        string[] customerDebtOrDebtorTableDetail = customerDebtOrDebtorTable[i].Split('-');
                        if (transactionId == Convert.ToInt32(customerDebtOrDebtorTableDetail[2]))
                        {
                            for (int j = 0; j < bankTypesTable.Length; j++)
                            {
                                string[] bankTypesTableDetail = bankTypesTable[j].Split('-');
                                if (Convert.ToInt32(customerDebtOrDebtorTableDetail[6]) == Convert.ToInt32(bankTypesTableDetail[0]))
                                {
                                    li.SubItems.Add(bankTypesTableDetail[1]);
                                    break;
                                }

                            }
                        }
                    }

                }
                sdr.Close();

            }
        }

        private int findDebtType(int transactionId)
        {
            int debtType = 0, transactionTypeId = findTransactionTypeId(transactionId);
            string findDebtTypeCommandText = "";
            
            if (transactionTypeId == 0) findDebtTypeCommandText = "SELECT * FROM customersMyDebt WHERE transactionTypeId = @transactionTypeId";
            else if (transactionTypeId == 1) findDebtTypeCommandText = "SELECT * FROM customersDebtor WHERE transactionTypeId = @transactionTypeId";

            SqlCommand findDebtTypeIdCommand = new SqlCommand(findDebtTypeCommandText, baglanti);
            findDebtTypeIdCommand.Parameters.AddWithValue("@transactionTypeId", transactionId);
            SqlDataReader sdr = findDebtTypeIdCommand.ExecuteReader();
            while (sdr.Read())
            {
                debtType = Convert.ToInt32(sdr["debtType"]);
            }
            sdr.Close();

            return debtType;
        }

        private int findTransactionTypeId(int transactionId)
        {
            int transactionTypeId = 0;
            SqlCommand findTransactionTypeIdCommand = new SqlCommand("SELECT * FROM customersTransactionType WHERE customerTransactionTypeId = @customerTransactionTypeId", baglanti);
            findTransactionTypeIdCommand.Parameters.AddWithValue("@customerTransactionTypeId", transactionId);
            SqlDataReader sdr = findTransactionTypeIdCommand.ExecuteReader();
            while (sdr.Read())
            {
                transactionTypeId = Convert.ToInt32(sdr["transactionType"]);
            }
            sdr.Close();

            return transactionTypeId;
        }

        private int findCustomerId(string customerName, string customerSurname)
        {
            int customerId = 0;
            SqlCommand findCustomerIdCommand = new SqlCommand("SELECT * FROM customers WHERE customerName = @customerName AND customerSurname = @customerSurname", baglanti);
            findCustomerIdCommand.Parameters.AddWithValue("@customerName", customerName);
            findCustomerIdCommand.Parameters.AddWithValue("@customerSurname", customerSurname);
            SqlDataReader sdr = findCustomerIdCommand.ExecuteReader();
            while (sdr.Read())
            {
                customerId = Convert.ToInt32(sdr["customerId"]);
            }
            sdr.Close();
            return customerId;
        }

        private string[] findDistinctCustomersDebtorIds()
        {
            int customersTableRowCount = findDistinctCustomersDebtorIdsRowCount(), customersTableRowCount2 = 0;
            string[] customersDebtorTable = new string[customersTableRowCount];

            SqlCommand findCustomerDebtValTableCommand = new SqlCommand("SELECT DISTINCT customerId FROM customersTransactionType WHERE transactionType = @transactionType", baglanti);
            findCustomerDebtValTableCommand.Parameters.AddWithValue("@transactionType", transactionType);
            SqlDataReader sdr = findCustomerDebtValTableCommand.ExecuteReader();
            while (sdr.Read())
            {
                if (customersTableRowCount2 <= customersTableRowCount)
                {
                    customersDebtorTable[customersTableRowCount2] = sdr["customerId"].ToString();
                    customersTableRowCount2++;
                }
            }
            sdr.Close();
            return customersDebtorTable;
        }

        private int findDistinctCustomersDebtorIdsRowCount()
        {
            int rowCount = 0;
            SqlCommand rowCountCommand = new SqlCommand("SELECT DISTINCT customerId FROM customersTransactionType WHERE transactionType = @transactionType", baglanti);
            rowCountCommand.Parameters.AddWithValue("@transactionType", transactionType);
            SqlDataReader sdr = rowCountCommand.ExecuteReader();
            while (sdr.Read())
            {
                rowCount++;
            }
            sdr.Close();
            return rowCount;
        }

        private string[] findCustomersDebtorTable(int customerId)
        {
            int customersTableRowCount = customersDebtorTableRowCount(customerId), customersTableRowCount2 = 0;
            string[] customersDebtorTable = new string[customersTableRowCount];

            SqlCommand findCustomerDebtValTableCommand = new SqlCommand("SELECT * FROM customersDebtor WHERE customerId = @customerId", baglanti);
            findCustomerDebtValTableCommand.Parameters.AddWithValue("@customerId", customerId);
            SqlDataReader sdr = findCustomerDebtValTableCommand.ExecuteReader();
            while (sdr.Read())
            {
                if (customersTableRowCount2 <= customersTableRowCount)
                {
                    customersDebtorTable[customersTableRowCount2] = sdr["debtorId"].ToString() + "-" + sdr["customerId"].ToString() + "-" + sdr["transactionTypeId"].ToString() + "-" + sdr["debtType"].ToString() + "-" + sdr["debtVal"].ToString() + "-" + sdr["debtMoneyTypeId"].ToString() + "-" + sdr["debtBankTypeId"].ToString() + "-" + sdr["debtDate"].ToString() + "-" + sdr["debtPaymentDate"].ToString();
                    customersTableRowCount2++;
                }
            }
            sdr.Close();
            return customersDebtorTable;
        }

        private int customersDebtorTableRowCount(int customerId)
        {
            int rowCount = 0;
            SqlCommand rowCountCommand = new SqlCommand("SELECT * FROM customersDebtor WHERE customerId = @customerId", baglanti);
            rowCountCommand.Parameters.AddWithValue("@customerId", customerId);
            SqlDataReader sdr = rowCountCommand.ExecuteReader();
            while (sdr.Read())
            {
                rowCount++;
            }
            sdr.Close();
            return rowCount;
        }

        private string[] findCustomersMyDebtTable(int customerId)
        {
            int customersTableRowCount = customersMyDebtTableRowCount(customerId), customersTableRowCount2 = 0;
            string[] customersDebtorTable = new string[customersTableRowCount];

            SqlCommand findCustomerDebtValTableCommand = new SqlCommand("SELECT * FROM customersMyDebt WHERE customerId = @customerId", baglanti);
            findCustomerDebtValTableCommand.Parameters.AddWithValue("@customerId", customerId);
            SqlDataReader sdr = findCustomerDebtValTableCommand.ExecuteReader();
            while (sdr.Read())
            {
                if (customersTableRowCount2 <= customersTableRowCount)
                {
                    customersDebtorTable[customersTableRowCount2] = sdr["myDebtId"].ToString() + "-" + sdr["customerId"].ToString() + "-" + sdr["transactionTypeId"].ToString() + "-" + sdr["debtType"].ToString() + "-" + sdr["debtVal"].ToString() + "-" + sdr["debtMoneyTypeId"].ToString() + "-" + sdr["debtBankTypeId"].ToString() + "-" + sdr["debtDate"].ToString() + "-" + sdr["debtPaymentDate"].ToString();
                    customersTableRowCount2++;
                }
            }
            sdr.Close();
            return customersDebtorTable;
        }

        private int customersMyDebtTableRowCount(int customerId)
        {
            int rowCount = 0;
            SqlCommand rowCountCommand = new SqlCommand("SELECT * FROM customersMyDebt WHERE customerId = @customerId", baglanti);
            rowCountCommand.Parameters.AddWithValue("@customerId", customerId);
            SqlDataReader sdr = rowCountCommand.ExecuteReader();
            while (sdr.Read())
            {
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
            int rowCount = 0;
            SqlCommand rowCountCommand = new SqlCommand("SELECT * FROM moneyTypesTable", baglanti);
            SqlDataReader sdr = rowCountCommand.ExecuteReader();
            while (sdr.Read())
            {
                rowCount++;
            }
            sdr.Close();
            return rowCount;
        }

        private string[] findBankTypesTable()
        {
            int bankCount1 = bankCount(), bankCount2 = 0;
            string[] exchangeMoneyName = new string[bankCount1];

            SqlCommand findExchangeMoneyFromIdToNameCommand = new SqlCommand("SELECT * FROM bankTypes", baglanti);
            SqlDataReader sdr = findExchangeMoneyFromIdToNameCommand.ExecuteReader();
            while (sdr.Read())
            {
                if (bankCount2 <= bankCount1)
                {
                    exchangeMoneyName[bankCount2] = (sdr["bankTypeId"].ToString()) + "-" + sdr["bankTypeName"].ToString();
                    bankCount2++;
                }
            }
            sdr.Close();
            return exchangeMoneyName;
        }

        private int bankCount()
        {
            int rowCount = 0;
            SqlCommand rowCountCommand = new SqlCommand("SELECT * FROM bankTypes", baglanti);
            SqlDataReader sdr = rowCountCommand.ExecuteReader();
            while (sdr.Read())
            {
                rowCount++;
            }
            sdr.Close();
            return rowCount;
        }

        private string[] findCustomersDebtorTable()
        {
            int customersTableRowCount = customersDebtorTableRowCount(), customersTableRowCount2 = 0;
            string[] customersDebtorTable = new string[customersTableRowCount];

            SqlCommand findCustomerDebtValTableCommand = new SqlCommand("SELECT * FROM customersDebtor", baglanti);
            SqlDataReader sdr = findCustomerDebtValTableCommand.ExecuteReader();
            while (sdr.Read())
            {
                if (customersTableRowCount2 <= customersTableRowCount)
                {
                    customersDebtorTable[customersTableRowCount2] = sdr["debtorId"].ToString() + "-" + sdr["customerId"].ToString() + "-" + sdr["transactionTypeId"].ToString() + "-" + sdr["debtType"].ToString() + "-" + sdr["debtVal"].ToString() + "-" + sdr["debtMoneyTypeId"].ToString() + "-" + sdr["debtBankTypeId"].ToString() + "-" + sdr["debtDate"].ToString() + "-" + sdr["debtPaymentDate"].ToString();
                    customersTableRowCount2++;
                }
            }
            sdr.Close();
            return customersDebtorTable;
        }



        private int customersDebtorTableRowCount()
        {
            int rowCount = 0;
            SqlCommand rowCountCommand = new SqlCommand("SELECT * FROM customersDebtor", baglanti);
            SqlDataReader sdr = rowCountCommand.ExecuteReader();
            while (sdr.Read())
            {
                rowCount++;
            }
            sdr.Close();
            return rowCount;
        }

        private string[] findCustomersMyDebtTable()
        {
            int customersTableRowCount = customersMyDebtTableRowCount(), customersTableRowCount2 = 0;
            string[] customersDebtorTable = new string[customersTableRowCount];

            SqlCommand findCustomerDebtValTableCommand = new SqlCommand("SELECT * FROM customersMyDebt", baglanti);
            SqlDataReader sdr = findCustomerDebtValTableCommand.ExecuteReader();
            while (sdr.Read())
            {
                if (customersTableRowCount2 <= customersTableRowCount)
                {
                    customersDebtorTable[customersTableRowCount2] = sdr["myDebtId"].ToString() + "-" + sdr["customerId"].ToString() + "-" + sdr["transactionTypeId"].ToString() + "-" + sdr["debtType"].ToString() + "-" + sdr["debtVal"].ToString() + "-" + sdr["debtMoneyTypeId"].ToString() + "-" + sdr["debtBankTypeId"].ToString() + "-" + sdr["debtDate"].ToString() + "-" + sdr["debtPaymentDate"].ToString();
                    customersTableRowCount2++;
                }
            }
            sdr.Close();
            return customersDebtorTable;
        }

        private int customersMyDebtTableRowCount()
        {
            int rowCount = 0;
            SqlCommand rowCountCommand = new SqlCommand("SELECT * FROM customersMyDebt", baglanti);
            SqlDataReader sdr = rowCountCommand.ExecuteReader();
            while (sdr.Read())
            {
                rowCount++;
            }
            sdr.Close();
            return rowCount;
        }

        private bool addIncomingMoney(int bankId, int moneyId, double addingMoney, double addedMoney, int transactionId, int transactionType, DateTime transactionDate, int installmentCount)
        {
            /*
             *  transactionType => 0:Borç Alma
             *  transactionType => 1:Borç Verme
             * 
             *  Kasa Para Çıkışı => 0
             *  Kasa Para Girişi => 1
             *  
             *  installmentCount => 0:Taksit Yok
             *  installmentCount => 1,2,3,4,5,6,7,8:Taksit Sayısı
             * */
            bool returnedVal = false;

            SqlCommand addMoneyFundsCommand = new SqlCommand("INSERT INTO moneyFunds VALUES(@bankId, @moneyTypeId, @moneyVal, @transactionType, @transactionDate)", baglanti);
            addMoneyFundsCommand.Parameters.AddWithValue("@bankId", bankId);
            addMoneyFundsCommand.Parameters.AddWithValue("@moneyTypeId", moneyId);
            addMoneyFundsCommand.Parameters.AddWithValue("@moneyVal",addingMoney);
            addMoneyFundsCommand.Parameters.AddWithValue("@transactionType", transactionType);
            addMoneyFundsCommand.Parameters.AddWithValue("@transactionDate", Convert.ToDateTime(DateTime.Now.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss")));
            int retAddMoneyFundsCommandVal = addMoneyFundsCommand.ExecuteNonQuery();
            if (retAddMoneyFundsCommandVal == 1)
            {
                double sumMoneyVal = 0;
                SqlCommand sumMoneyInfoCommand = new SqlCommand("SELECT * FROM sumAllMoney WHERE moneyTypeId = @moneyId", baglanti);
                sumMoneyInfoCommand.Parameters.AddWithValue("@moneyId", moneyId);
                SqlDataReader sdr = sumMoneyInfoCommand.ExecuteReader();
                while (sdr.Read()){
                    sumMoneyVal = Convert.ToDouble(sdr["sumMoneyVal"]);
                }
                sdr.Close();

                string[] moneyVal;
                double moneyVal1, afterPoint;
                try{
                    moneyVal = sumMoneyVal.ToString().Split(',');
                    moneyVal1 = Convert.ToDouble(moneyVal[0]);
                    afterPoint = Convert.ToDouble(moneyVal[1].Substring(0, 2));
                }
                catch (Exception){
                    moneyVal1 = Convert.ToDouble(sumMoneyVal.ToString());
                    afterPoint = 0;
                    //throw;
                }
                double moneyTransaction = 0;
                if (transactionType == 0) moneyTransaction = (sumMoneyVal) - addingMoney;
                else if (transactionType == 1) moneyTransaction = (moneyVal1 + (afterPoint / 100)) + addingMoney;
                SqlCommand updateSumMoneyValTableCommand = new SqlCommand("UPDATE sumAllMoney SET sumMoneyVal = @moneyVal WHERE moneyTypeId = @moneyId", baglanti);
                updateSumMoneyValTableCommand.Parameters.AddWithValue("@moneyVal", moneyTransaction);
                updateSumMoneyValTableCommand.Parameters.AddWithValue("@moneyId", moneyId);
                int retUpdateSumMoneyValTableCommandVal = updateSumMoneyValTableCommand.ExecuteNonQuery();
                if (retUpdateSumMoneyValTableCommandVal == 1){
                    
                    string selectDebtOrDebtorTableInfoCommand = "", updateCustomerDebtOrDebtorTableSqlText = "", sumAddedMoney = "";
                    int installmentType = 0;
                    if (transactionType == 0) selectDebtOrDebtorTableInfoCommand = "SELECT * FROM customersMyDebt WHERE transactionTypeId = @transactionId";
                    else if (transactionType == 1) selectDebtOrDebtorTableInfoCommand = "SELECT * FROM customersDebtor WHERE transactionTypeId = @transactionId";

                    SqlCommand debtIsInstallmentOrCashCommand = new SqlCommand(selectDebtOrDebtorTableInfoCommand, baglanti);
                    debtIsInstallmentOrCashCommand.Parameters.AddWithValue("@transactionId", transactionId);
                    SqlDataReader sdr2 = debtIsInstallmentOrCashCommand.ExecuteReader();
                    while (sdr2.Read()){
                        installmentType = Convert.ToInt32(sdr2["debtType"]);
                        sumAddedMoney = sdr2["debtPaymentVal"].ToString();
                    }
                    sdr2.Close();

                    string[] moneyVal2;
                    double moneyVal12, afterPoint2;
                    try{
                        moneyVal2 = sumAddedMoney.Split(',');
                        moneyVal12 = Convert.ToDouble(moneyVal2[0]);
                        afterPoint2 = Convert.ToDouble(moneyVal2[1].Substring(0, 2));
                    }
                    catch (Exception){
                        moneyVal12 = Convert.ToDouble(sumAddedMoney);
                        afterPoint2 = 0;
                        //throw;
                    }

                    if (transactionType == 0) updateCustomerDebtOrDebtorTableSqlText = "UPDATE customersMyDebt SET debtPaymentVal = @newMoneyVal WHERE transactionTypeId = @transactionTypeId";
                    else if (transactionType == 1) updateCustomerDebtOrDebtorTableSqlText = "UPDATE customersDebtor SET debtPaymentVal = @newMoneyVal WHERE transactionTypeId = @transactionTypeId";

                    SqlCommand updateCustomerDebtOrDebtorTableCommand = new SqlCommand(updateCustomerDebtOrDebtorTableSqlText, baglanti);
                    updateCustomerDebtOrDebtorTableCommand.Parameters.AddWithValue("@newMoneyVal", (moneyVal12 + (afterPoint2 / 1000)) + addingMoney);
                    updateCustomerDebtOrDebtorTableCommand.Parameters.AddWithValue("@transactionTypeId", transactionId);
                    int retUpdateCustomerDebtOrDebtorTableCommandVal = updateCustomerDebtOrDebtorTableCommand.ExecuteNonQuery();
                    if (retUpdateCustomerDebtOrDebtorTableCommandVal == 1){
                        if (installmentType == 0) returnedVal = true;
                        else if(installmentType == 1){
                            SqlCommand updateInstallmentTableCommand = new SqlCommand("UPDATE customersInstallment SET installmentPaymentVal = @installmentPaymentVal WHERE transactionTypeId = @transactionTypeId AND installmentPaymentCounter = @installmentPaymentCounter", baglanti);
                            updateInstallmentTableCommand.Parameters.AddWithValue("@installmentPaymentVal", addedMoney+addingMoney);
                            updateInstallmentTableCommand.Parameters.AddWithValue("@transactionTypeId", transactionId);
                            updateInstallmentTableCommand.Parameters.AddWithValue("@installmentPaymentCounter", installmentCount);
                            int retUpdateInstallmentTableCommandVal = updateInstallmentTableCommand.ExecuteNonQuery();
                            if (retUpdateInstallmentTableCommandVal == 1) returnedVal = true;
                            else{
                                returnedVal = false;
                            }
                        }
                    }
                    else{
                        //sumMoneyTableda son ekleneni çıkart
                        //moneyFundsTable da ki son id li bilgiyi sil
                        returnedVal = false;
                    }
                }
                else{
                    //moneyFundsTable da ki son id li bilgiyi sil
                    returnedVal = false;
                }
            }
            else returnedVal = false;
            return returnedVal;
        }

        private bool doesItHaveEnoughMoney(string bankTypeName, string moneyTypeName, double moneyVal)
        {
            bool returnedVal = false;
            int bankId = debtTransactionFuncs.bankNameToId(bankTypeName), moneyId = debtTransactionFuncs.moneyNameToId(moneyTypeName);
            double sumMoney = 0;
            SqlCommand sumMoneyCommand = new SqlCommand("SELECT * FROM moneyFunds WHERE bankId = @bankId AND moneyTypeId = @moneyId", baglanti);
            sumMoneyCommand.Parameters.AddWithValue("@bankId", bankId);
            sumMoneyCommand.Parameters.AddWithValue("@moneyId", moneyId);
            SqlDataReader sdr = sumMoneyCommand.ExecuteReader();
            while (sdr.Read())
            {
                string[] moneyVal2;
                double moneyVal12, afterPoint2;
                try
                {
                    moneyVal2 = sdr["moneyVal"].ToString().Split(',');
                    moneyVal12 = Convert.ToDouble(moneyVal2[0]);
                    afterPoint2 = Convert.ToDouble(moneyVal2[1]);
                }
                catch (Exception)
                {
                    moneyVal12 = Convert.ToDouble(sdr["moneyVal"].ToString());
                    afterPoint2 = 0;
                    //throw;
                }
                if (Convert.ToInt32(sdr["transactionType"]) == 0) sumMoney -= moneyVal12 + (afterPoint2 / 100);
                else if (Convert.ToInt32(sdr["transactionType"]) == 1) sumMoney += moneyVal12 + (afterPoint2 / 100);
            }
            sdr.Close();
            if (sumMoney < moneyVal) returnedVal = false;
            else returnedVal = true;

            return returnedVal;
        }

        private void inComingMoneyForm_Load(object sender, EventArgs e)
        {
            /*
             * moneyTransactionType => 0:Gider ekle(Borç Alma)
             * moneyTransactionType => 1:Gelir ekle(Borç Verme)
             * 
             * */
            this.StyleManager = metroStyleManager1;
            theme = funcs.themeChanger(0);
            transactionType = anasayfa.moneyTransactionTypeId;


            if (theme == "light") metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Light;
            else metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            if (funcs.isConnect(baglanti) == true) { }
            else{
                MetroFramework.MetroMessageBox.Show(this, "Veri Tabanı Bağlantısı Kurulamadığından Dolayı Program Kapatılıyor..", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            if (funcs.isConnect(baglanti) == true){
                connectSituation.BackColor = Color.Lime;
                funcs.setToolTip(connectSituation, "Veri Tabanı Bağlantısı Var");
            }
            else{
                MetroFramework.MetroMessageBox.Show(this, "Veri Tabanı Bağlantısı Kurulamadığından Dolayı Program Kapatılıyor..", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            if (metroStyleManager1.Theme == MetroFramework.MetroThemeStyle.Dark){
                moneyNumberToWordRichText.BackColor = Color.FromArgb(17, 17, 17);
                moneyNumberToWordRichText.ForeColor = Color.FromArgb(170, 170, 170);
                moneyNumberToWordRichText1.BackColor = Color.FromArgb(17, 17, 17);
                moneyNumberToWordRichText1.ForeColor = Color.FromArgb(170, 170, 170);
                moneyNumberToWordRichText2.BackColor = Color.FromArgb(17, 17, 17);
                moneyNumberToWordRichText2.ForeColor = Color.FromArgb(170, 170, 170);   
            }
            else{
                moneyNumberToWordRichText.BackColor = Color.WhiteSmoke;
                moneyNumberToWordRichText.ForeColor = Color.Black;
                moneyNumberToWordRichText1.BackColor = Color.WhiteSmoke;
                moneyNumberToWordRichText1.ForeColor = Color.Black;
                moneyNumberToWordRichText2.BackColor = Color.WhiteSmoke;
                moneyNumberToWordRichText2.ForeColor = Color.Black;
            }

            if (transactionType == 0){
                this.Text = "Gider Ekle";
                saveButton.Text = "Gideri Ekle";
            }
            else if (transactionType == 1){
                this.Text = "Gelir Ekle";
                saveButton.Text = "Geliri Ekle";
            }
            fillCustomerNameAndSurnameCombo();
        }

        private void customerNameAndSurnameCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillCustomerDebtListCombo(customerNameAndSurnameCombo.Text);
        }

        private void customerDebtListCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] customerDebtListComboSelectedDetail = customerDebtListCombo.Text.Split('-');
            int transactionId = Convert.ToInt32(customerDebtListComboSelectedDetail[0]);
            fillCustomerDebtListViewColumns(findDebtType(transactionId));
            fillCustomerDebtListViewItems(findDebtType(transactionId), findTransactionTypeId(transactionId), transactionId);
            bankTypesText1.Text = null;
            moneyTypesText1.Text = null;
            moneyValText.Text = null;
            moneyNumberToWordRichText.Text = null;
            moneyValText1.Text = null;
            moneyNumberToWordRichText1.Text = null;
            inputMoneyVal.Text = null;
            moneyNumberToWordRichText2.Text = null;
        }

        private void customerDebtListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (customerDebtListView.SelectedIndices.Count > 0){
                string[] customerDebtListComboSelectedDetail = customerDebtListCombo.Text.Split('-');
                int debtType = findDebtType(Convert.ToInt32(customerDebtListComboSelectedDetail[0]));
                if (debtType == 0){
                    bankTypesText1.Text = customerDebtListView.SelectedItems[0].SubItems[4].Text;
                    moneyTypesText1.Text = customerDebtListView.SelectedItems[0].SubItems[3].Text;
                    moneyValText.Text = customerDebtListView.SelectedItems[0].SubItems[1].Text;
                    moneyValText1.Text = customerDebtListView.SelectedItems[0].SubItems[2].Text;

                    string[] moneyVal;
                    double moneyVal1, afterPoint;
                    try{
                        moneyVal = moneyValText.Text.Split(',');
                        moneyVal1 = Convert.ToDouble(moneyVal[0]);
                        afterPoint = Convert.ToDouble(moneyVal[1]);
                    }
                    catch (Exception){
                        moneyVal1 = Convert.ToDouble(moneyValText.Text);
                        afterPoint = 0;
                        //throw;
                    }

                    string[] moneyVal2;
                    double moneyVal12, afterPoint2;
                    try{
                        moneyVal2 = moneyValText1.Text.Split(',');
                        moneyVal12 = Convert.ToDouble(moneyVal2[0]);
                        afterPoint2 = Convert.ToDouble(moneyVal2[1]);
                    }
                    catch (Exception){
                        moneyVal12 = Convert.ToDouble(moneyValText1.Text);
                        afterPoint2 = 0;
                        //throw;
                    }

                    if (afterPoint == 0) moneyNumberToWordRichText.Text = debtTransactionFuncs.translateNumberToWord(moneyVal1) + " " + (moneyTypesText1.Text).ToLowerInvariant() + " sıfır kuruş";
                    else moneyNumberToWordRichText.Text = debtTransactionFuncs.translateNumberToWord(moneyVal1) + " " + (moneyTypesText1.Text).ToLowerInvariant() + " " + debtTransactionFuncs.translateNumberToWord(afterPoint) + " kuruş";

                    if (moneyValText1.Text == "0") moneyNumberToWordRichText1.Text = "sıfır " + (moneyTypesText1.Text).ToLowerInvariant() + " sıfır kuruş";
                    else{
                        if (afterPoint2 == 0) moneyNumberToWordRichText1.Text = debtTransactionFuncs.translateNumberToWord(moneyVal12) + " " + (moneyTypesText1.Text).ToLowerInvariant() + " sıfır kuruş";
                        else moneyNumberToWordRichText1.Text = debtTransactionFuncs.translateNumberToWord(moneyVal12) + " " + (moneyTypesText1.Text).ToLowerInvariant() + " " + debtTransactionFuncs.translateNumberToWord(afterPoint2) + " kuruş";
                    }
                }
                else if (debtType == 1)
                {
                    bankTypesText1.Text = customerDebtListView.SelectedItems[0].SubItems[6].Text;
                    moneyTypesText1.Text = customerDebtListView.SelectedItems[0].SubItems[5].Text;
                    moneyValText.Text = customerDebtListView.SelectedItems[0].SubItems[3].Text;
                    moneyValText1.Text = customerDebtListView.SelectedItems[0].SubItems[4].Text;

                    string[] moneyVal;
                    double moneyVal1, afterPoint;
                    try{
                        moneyVal = moneyValText.Text.Split(',');
                        moneyVal1 = Convert.ToDouble(moneyVal[0]);
                        afterPoint = Convert.ToDouble(moneyVal[1]);
                    }
                    catch (Exception){
                        moneyVal1 = Convert.ToDouble(moneyValText.Text);
                        afterPoint = 0;
                        //throw;
                    }

                    string[] moneyVal2;
                    double moneyVal12, afterPoint2;
                    try{
                        moneyVal2 = moneyValText1.Text.Split(',');
                        moneyVal12 = Convert.ToDouble(moneyVal2[0]);
                        afterPoint2 = Convert.ToDouble(moneyVal2[1]);
                    }
                    catch (Exception){
                        moneyVal12 = Convert.ToDouble(moneyValText1.Text);
                        afterPoint2 = 0;
                        //throw;
                    }

                    if (afterPoint == 0) moneyNumberToWordRichText.Text = debtTransactionFuncs.translateNumberToWord(moneyVal1) + " " + (moneyTypesText1.Text).ToLowerInvariant() + " sıfır kuruş";
                    else moneyNumberToWordRichText.Text = debtTransactionFuncs.translateNumberToWord(moneyVal1) + " " + (moneyTypesText1.Text).ToLowerInvariant() + " " + debtTransactionFuncs.translateNumberToWord(afterPoint) + " kuruş";

                    if (moneyValText1.Text == "0") moneyNumberToWordRichText1.Text ="sıfır " + (moneyTypesText1.Text).ToLowerInvariant() + " sıfır kuruş";
                    else{
                        if (afterPoint2 == 0) moneyNumberToWordRichText1.Text = debtTransactionFuncs.translateNumberToWord(moneyVal12) + " " + (moneyTypesText1.Text).ToLowerInvariant() + " sıfır kuruş";
                        else moneyNumberToWordRichText1.Text = debtTransactionFuncs.translateNumberToWord(moneyVal12) + " " + (moneyTypesText1.Text).ToLowerInvariant() + " " + debtTransactionFuncs.translateNumberToWord(afterPoint2) + " kuruş";
                    }
                }
            }
        }

        bool pressThePoint = false;
        int digitAfterThePoint = 0;

        private void inputMoneyVal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)44){
                e.Handled = true;
            }
            if (e.KeyChar == (char)08){
                inputMoneyVal.Text = "";
                digitAfterThePoint = 0;
                pressThePoint = false;
            }
            else{
                if (pressThePoint){
                    if (digitAfterThePoint < 2 && e.KeyChar != (char)44){
                        digitAfterThePoint++;
                    }
                    else e.Handled = true;
                }
                if (e.KeyChar == (char)44) pressThePoint = true;
            }
    }

        private void inputMoneyVal_TextChanged(object sender, EventArgs e)
        {
            if (inputMoneyVal.Text != "" && bankTypesText1.Text != ""){
                OKButton.Enabled = true;
                OKButton.BackColor = Color.FromArgb(0, 174, 219);
            }
            else{
                OKButton.Enabled = false;
                OKButton.BackColor = Color.Silver;
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            string[] moneyVal;
            double moneyVal1, afterPoint;
            try{
                moneyVal = inputMoneyVal.Text.Split(',');
                moneyVal1 = Convert.ToDouble(moneyVal[0]);
                afterPoint = Convert.ToDouble(moneyVal[1]);
            }
            catch (Exception){
                moneyVal1 = Convert.ToDouble(inputMoneyVal.Text);
                afterPoint = 0;
                //throw;
            }
            
            string[] moneyVal2;
            double moneyVal12, afterPoint2;
            try{
                moneyVal2 = moneyValText.Text.Split(',');
                moneyVal12 = Convert.ToDouble(moneyVal2[0]);
                afterPoint2 = Convert.ToDouble(moneyVal2[1]);
            }
            catch (Exception){
                moneyVal12 = Convert.ToDouble(moneyValText.Text);
                afterPoint2 = 0;
                //throw;
            }

            string[] moneyVal3;
            double moneyVal13, afterPoint3;
            try
            {
                moneyVal3 = moneyValText1.Text.Split(',');
                moneyVal13 = Convert.ToDouble(moneyVal3[0]);
                afterPoint3 = Convert.ToDouble(moneyVal3[1]);
            }
            catch (Exception)
            {
                moneyVal13 = Convert.ToDouble(moneyValText1.Text);
                afterPoint3 = 0;
                //throw;
            }
            if (((moneyVal1 + (afterPoint / 100)) + (moneyVal13 + (afterPoint3 / 100))) > (moneyVal12 + (afterPoint2 / 100))) { 
                MetroFramework.MetroMessageBox.Show(this, "Ödenmesi gereken tutardan daha fazla tutar giremezsiniz.\n(Şimdiye kadar ödediği miktar dahil edilmiştir.)", "BİLGİ!!!", MessageBoxButtons.OK);
                saveButton.Enabled = false;
                saveButton.BackColor = Color.Silver;
                saveButton.ForeColor = Color.White;
            }
            else{
                if ((moneyVal1 + (afterPoint / 100)) > (moneyVal12 + (afterPoint2 / 100))) { 
                    MetroFramework.MetroMessageBox.Show(this, "Ödenmesi gereken tutardan daha fazla tutar giremezsiniz. ", "BİLGİ!!!", MessageBoxButtons.OK);
                    moneyNumberToWordRichText2.Text = "";
                    saveButton.Enabled = false;
                    saveButton.BackColor = Color.Silver;
                    saveButton.ForeColor = Color.White;
                }
                else{
                    if (afterPoint == 0) moneyNumberToWordRichText2.Text = debtTransactionFuncs.translateNumberToWord(moneyVal1) + " " + (moneyTypesText1.Text).ToLowerInvariant() + " sıfır kuruş";
                    else moneyNumberToWordRichText2.Text = debtTransactionFuncs.translateNumberToWord(moneyVal1) + " " + (moneyTypesText1.Text).ToLowerInvariant() + " " + debtTransactionFuncs.translateNumberToWord(afterPoint) + " kuruş";

                    saveButton.Enabled = true;
                    saveButton.BackColor = Color.FromArgb(0, 174, 219);
                    saveButton.ForeColor = Color.White;
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string[] moneyVal;
            double moneyVal1, afterPoint;
            try
            {
                moneyVal = inputMoneyVal.Text.Split(',');
                moneyVal1 = Convert.ToDouble(moneyVal[0]);
                afterPoint = Convert.ToDouble(moneyVal[1]);
            }
            catch (Exception)
            {
                moneyVal1 = Convert.ToDouble(inputMoneyVal.Text);
                afterPoint = 0;
                //throw;
            }

            string[] moneyVal3;
            double moneyVal13, afterPoint3;
            try
            {
                moneyVal3 = moneyValText1.Text.Split(',');
                moneyVal13 = Convert.ToDouble(moneyVal3[0]);
                afterPoint3 = Convert.ToDouble(moneyVal3[1]);
            }
            catch (Exception)
            {
                moneyVal13 = Convert.ToDouble(moneyValText1.Text);
                afterPoint3 = 0;
                //throw;
            }

            int transactionType = 0;
            string[] customerDebtListComboDetail = customerDebtListCombo.Text.Split('-');
            if (customerDebtListComboDetail[1] == "Borç Alma") transactionType = 0;
            else if (customerDebtListComboDetail[1] == "Borç Verme") transactionType = 1;
            if (customerDebtListView.Items.Count > 1){
                if ((doesItHaveEnoughMoney(bankTypesText1.Text, moneyTypesText1.Text, (moneyVal1 + (afterPoint / 100))) && transactionType == 1) || transactionType == 0){
                    if (addIncomingMoney(debtTransactionFuncs.bankNameToId(bankTypesText1.Text), debtTransactionFuncs.moneyNameToId(moneyTypesText1.Text), (moneyVal1 + (afterPoint / 100)), (moneyVal13 + (afterPoint3 / 100)), Convert.ToInt32(customerDebtListComboDetail[0]), transactionType, Convert.ToDateTime(customerDebtListComboDetail[3]), Convert.ToInt32(customerDebtListView.SelectedItems[0].SubItems[1].Text))){
                        MetroFramework.MetroMessageBox.Show(this, "Taksit başarılı bir şekilde ödendi. ", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        funcs.addHistory("'" + customerNameAndSurnameCombo.Text + "' adlı müşteriye ait '" + customerDebtListComboDetail[2] + "' tutarinda ki borcun '" + customerDebtListView.SelectedItems[0].SubItems[1].Text + ".' taksidine '" + inputMoneyVal.Text + "(" + moneyNumberToWordRichText2.Text + ")' değerinde ekleme yapıldı.\n(Banka Türü:'" + bankTypesText1.Text + "' Para Türü:'" + moneyTypesText1.Text + "')", 2);
                        if (findDebtType(Convert.ToInt32(customerDebtListComboDetail[0])) == 0) debtTransactionFuncs.itHasPayed(Convert.ToInt32(customerDebtListComboDetail[0]), transactionType, 0);
                        else if (findDebtType(Convert.ToInt32(customerDebtListComboDetail[0])) == 1) debtTransactionFuncs.itHasPayed(Convert.ToInt32(customerDebtListComboDetail[0]), transactionType, Convert.ToInt32(customerDebtListView.SelectedItems[0].SubItems[1].Text));
                        fillCustomerDebtListViewItems(findDebtType(Convert.ToInt32(customerDebtListComboDetail[0])), findTransactionTypeId(Convert.ToInt32(customerDebtListComboDetail[0])), Convert.ToInt32(customerDebtListComboDetail[0]));

                        debtTransactionFuncs.reloadMainPagePanelUserControls();
                    }
                    else {
                        MetroFramework.MetroMessageBox.Show(this, "Taksit ödenmedi. ", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }    
                else {
                    MetroFramework.MetroMessageBox.Show(this, "Bakiyeniz yetersizdir.. ", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else{
                if (addIncomingMoney(debtTransactionFuncs.bankNameToId(bankTypesText1.Text), debtTransactionFuncs.moneyNameToId(moneyTypesText1.Text), (moneyVal1 + (afterPoint / 100)), (moneyVal13 + (afterPoint3 / 100)), Convert.ToInt32(customerDebtListComboDetail[0]), transactionType, Convert.ToDateTime(customerDebtListComboDetail[3]), 1)){
                    MetroFramework.MetroMessageBox.Show(this, "Borç başarılı bir şekilde ödendi. ", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    funcs.addHistory("'" + customerNameAndSurnameCombo.Text + "' adlı müşteriye ait '" + customerDebtListComboDetail[2] + "' tutarinda ki borcuna '" + inputMoneyVal.Text + "(" + moneyNumberToWordRichText2.Text + ")' değerinde ekleme yapıldı.\n(Banka Türü:'" + bankTypesText1.Text + "' Para Türü:'" + moneyTypesText1.Text + "')", 2);

                    if (findDebtType(Convert.ToInt32(customerDebtListComboDetail[0])) == 0) debtTransactionFuncs.itHasPayed(Convert.ToInt32(customerDebtListComboDetail[0]), transactionType, 0);
                    else if (findDebtType(Convert.ToInt32(customerDebtListComboDetail[0])) == 1) debtTransactionFuncs.itHasPayed(Convert.ToInt32(customerDebtListComboDetail[0]), transactionType, Convert.ToInt32(customerDebtListView.SelectedItems[0].SubItems[1].Text));
                    fillCustomerDebtListViewItems(findDebtType(Convert.ToInt32(customerDebtListComboDetail[0])), findTransactionTypeId(Convert.ToInt32(customerDebtListComboDetail[0])), Convert.ToInt32(customerDebtListComboDetail[0]));

                    debtTransactionFuncs.reloadMainPagePanelUserControls();
                }
                else MetroFramework.MetroMessageBox.Show(this, "Taksit ödenmedi. ", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
