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
    public partial class customerDebtDetail : MetroFramework.Forms.MetroForm
    {
        public customerDebtDetail()
        {
            InitializeComponent();
        }

        methods funcs = new methods();
        SqlConnection baglanti = methods.baglanti;
        string theme;

        private void fillCustomerTransactionListViewColumns()
        {
            customerTransactionListView.Items.Clear();
            customerTransactionListView.View = View.Details;
            customerTransactionListView.GridLines = true;
            customerTransactionListView.Columns.Add("Müşteri Adı Soyadı", 122);
            customerTransactionListView.Columns.Add("İşlem Tipi", 122);
            customerTransactionListView.Columns.Add("İşlem Tutarı", 122);
            customerTransactionListView.Columns.Add("Para Türü", 122);
            customerTransactionListView.Columns.Add("İşlem Tarihi", 122);
            customerTransactionListView.Columns.Add("İşlem Id", 122);
        }

        private void fillCustomersInfo(int customerId)
        {
            string[] reliabilityTable = findReliabilityTable();
            SqlCommand fillCustomersInfoCommand = new SqlCommand("SELECT * FROM customers WHERE customerId = @customerId", baglanti);
            fillCustomersInfoCommand.Parameters.AddWithValue("@customerId", customerId);
            SqlDataReader sdr = fillCustomersInfoCommand.ExecuteReader();
            while (sdr.Read()){
                customerIdText.Text = sdr["customerId"].ToString();
                customerNameText.Text = sdr["customerName"].ToString();
                customerSurnameText.Text = sdr["customerSurname"].ToString();
                customerPhoneText.Text = sdr["customerPhone"].ToString();
                customerMailText.Text = sdr["customerMail"].ToString();
                customerAdressRichText.Text = sdr["customerAdress"].ToString();
                for (int i = 0; i < reliabilityTable.Length; i++){
                    string[] reliabilityTableDetail = reliabilityTable[i].Split('-');
                    if (Convert.ToInt32(reliabilityTableDetail[0]) == Convert.ToInt32(sdr["customerReliabilityVal"])){
                        customerReliabiltyText.Text = reliabilityTableDetail[1];
                    }
                }
            }
            sdr.Close();
        }

        private void fillCustomerTransactionListViewItems(int customerId)
        {
            int rowCount = 0;
            string[] customersDebtorTable = findCustomersDebtorTable(), customersMyDebtTable = findCustomersMyDebtTable(), moneyTypesTable = findExchangeMoneyFromIdToName();
            SqlCommand fillCustomerTransactionListViewCommand = new SqlCommand("SELECT * FROM customersTransactionType WHERE customerId = @customerId", baglanti);
            fillCustomerTransactionListViewCommand.Parameters.AddWithValue("@customerId", customerId);
            SqlDataReader sdr = fillCustomerTransactionListViewCommand.ExecuteReader();
            ListViewItem li = new ListViewItem();
            while (sdr.Read()){
                li = customerTransactionListView.Items.Add(customerNameText.Text + " " + customerSurnameText.Text);
                if (Convert.ToInt32(sdr["transactionType"]) == 0)li.SubItems.Add("Borç Alma");
                else li.SubItems.Add("Borç Verme");

                if (Convert.ToInt32(sdr["transactionType"]) == 0){
                    for (int i = 0; i < customersMyDebtTable.Length; i++){
                        string[] customersMyDebtTableDetail = customersMyDebtTable[i].Split('-');
                        if (Convert.ToInt32(customersMyDebtTableDetail[2]) == Convert.ToInt32(sdr["customerTransactionTypeId"])){
                            li.SubItems.Add(customersMyDebtTableDetail[4]);
                            for (int k = 0; k < moneyTypesTable.Length; k++){
                                string[] moneyTypesTableDetail = moneyTypesTable[k].Split('-');
                                if (Convert.ToInt32(customersMyDebtTableDetail[5]) == Convert.ToInt32(moneyTypesTableDetail[0])){
                                    li.SubItems.Add(moneyTypesTableDetail[1]);
                                }

                            }
                            break;
                        }
                    }
                }
                else if (Convert.ToInt32(sdr["transactionType"]) == 1){
                    for (int j = 0; j < customersDebtorTable.Length; j++){
                        string[] customersDebtorTableDetail = customersDebtorTable[j].Split('-');
                        if (Convert.ToInt32(customersDebtorTableDetail[2]) == Convert.ToInt32(sdr["customerTransactionTypeId"])){
                            li.SubItems.Add(customersDebtorTableDetail[4]);
                            for (int k = 0; k < moneyTypesTable.Length; k++){
                                string[] moneyTypesTableDetail = moneyTypesTable[k].Split('-');
                                if (Convert.ToInt32(customersDebtorTableDetail[5]) == Convert.ToInt32(moneyTypesTableDetail[0])){
                                    li.SubItems.Add(moneyTypesTableDetail[1]);
                                }

                            }
                            break;
                        }
                    }
                }
                li.SubItems.Add(sdr["transactionDate"].ToString());
                li.SubItems.Add(sdr["customerTransactionTypeId"].ToString());
                rowCount++;
            }
            sdr.Close();
            customerTransactionListViewLabel.Text =  "'" + customerNameText.Text + " " + customerSurnameText.Text + "' adlı müşteriye ait " + rowCount.ToString() + " adet kayıt bulundu.";
        }

        private void fillDebtPaymentListView1Columns(int debtType)
        {
            /*
             * debtType=>0:Peşin
             * debtType=>1:Taksit
             * 
             * */
            debtPaymentListView1.Clear();
            debtPaymentListView1.Items.Clear();
            debtPaymentListView1.View = View.Details;
            debtPaymentListView1.GridLines = true;

            if (debtType == 0){
                debtPaymentListView1.Columns.Add("Para Ödenen Tarih", 163);
                debtPaymentListView1.Columns.Add("Para Tutarı", 163);
                debtPaymentListView1.Columns.Add("Ödenen Tutar", 163);
                debtPaymentListView1.Columns.Add("Para Türü", 163);
                debtPaymentListView1.Columns.Add("Banka Türü", 163);
                debtPaymentListView1.Columns.Add("Para Verilme Tarihi", 163);
                debtPaymentListView1.Columns.Add("Para Ödenmesi Gereken Tarih", 163);
            }
            else{
                debtPaymentListView1.Columns.Add("Para Ödenen Tarih", 163);
                debtPaymentListView1.Columns.Add("Ödenecek Taksit", 163);
                debtPaymentListView1.Columns.Add("Ödenecek Taksit Tarihi", 163);
                debtPaymentListView1.Columns.Add("Ödenemsi Gereken Minimum Para Tutarı", 163);
                debtPaymentListView1.Columns.Add("Ödenene Para Tutarı", 163);
                debtPaymentListView1.Columns.Add("Para Türü", 163);
                debtPaymentListView1.Columns.Add("Banka Türü", 163);
            }
        }

        private void fillDebtPaymentListView1Items(int debtTypeId, int transactionTypeId, int transactionId)
        {
            /*
             * debtType=>0:Peşin
             * debtType=>1:Taksit
             * 
             * transactionType=>0:Borç Alma
             * transactionType=>1:Borç Verme
             * 
             * */
            if (debtTypeId == 0){
                string sqlCommandText = "";
                if (transactionTypeId == 0) sqlCommandText = "SELECT * FROM customersMyDebt WHERE transactionTypeId = @transactionTypeId";
                else if(transactionTypeId == 1) sqlCommandText = "SELECT * FROM customersDebtor WHERE transactionTypeId = @transactionTypeId";
                string[] moneyTypesTable = findExchangeMoneyFromIdToName(), bankTypesTable = findBankTypesTable();
                SqlCommand findDebtDetailCommand = new SqlCommand(sqlCommandText, baglanti);
                findDebtDetailCommand.Parameters.AddWithValue("@transactionTypeId", transactionId);
                SqlDataReader sdr = findDebtDetailCommand.ExecuteReader();
                ListViewItem li = new ListViewItem();
                while (sdr.Read()){
                    if (Convert.ToDateTime(sdr["debtPaymentDate"]) == Convert.ToDateTime("2000-01-01 00:00:00.000")) li = debtPaymentListView1.Items.Add("Ödenmedi");
                    else li = debtPaymentListView1.Items.Add(sdr["debtPaymentDate"].ToString());

                    li.SubItems.Add(sdr["debtVal"].ToString());
                    li.SubItems.Add(sdr["debtPaymentVal"].ToString());
                    for (int i = 0; i < moneyTypesTable.Length; i++){
                        string[] moneyTypesTableDetail = moneyTypesTable[i].Split('-');
                        if (Convert.ToInt32(moneyTypesTableDetail[0]) == Convert.ToInt32(sdr["debtMoneyTypeId"])){
                            li.SubItems.Add(moneyTypesTableDetail[1]);
                            break;
                        }
                    }

                    for (int j = 0; j < bankTypesTable.Length; j++){
                        string[] bankTypesTableDetail = bankTypesTable[j].Split('-');
                        if (Convert.ToInt32(bankTypesTableDetail[0]) == Convert.ToInt32(sdr["debtBankTypeId"])){
                            li.SubItems.Add(bankTypesTableDetail[1]);
                            break;
                        }
                    }

                    li.SubItems.Add(sdr["debtDate"].ToString());
                    li.SubItems.Add(sdr["debtMinPaymentDate"].ToString());


                }
                sdr.Close();
            }
            else{
                string[] customerDebtOrDebtorTable, moneyTypesTable = findExchangeMoneyFromIdToName(), bankTypesTable = findBankTypesTable();
                if (transactionTypeId == 0) customerDebtOrDebtorTable = findCustomersMyDebtTable();
                else customerDebtOrDebtorTable = findCustomersDebtorTable();

                SqlCommand findDebtInstallmentCommand = new SqlCommand("SELECT * FROM customersInstallment WHERE transactionTypeId = @transactionTypeId ORDER BY installmentId", baglanti);
                findDebtInstallmentCommand.Parameters.AddWithValue("@transactionTypeId", transactionId);
                SqlDataReader sdr = findDebtInstallmentCommand.ExecuteReader();
                ListViewItem li = new ListViewItem();
                
                while (sdr.Read()){
                    if (Convert.ToDateTime(sdr["installmentPaymentDate"]) == Convert.ToDateTime("2000-01-01 00:00:00")) li = debtPaymentListView1.Items.Add("Ödenmedi");
                    else li = debtPaymentListView1.Items.Add(sdr["installmentPaymentDate"].ToString());

                    li.SubItems.Add(sdr["installmentPaymentCounter"].ToString());
                    li.SubItems.Add(sdr["installmentMinPaymentDate"].ToString());
                    li.SubItems.Add(sdr["installmentMinPaymentVal"].ToString());
                    li.SubItems.Add(sdr["installmentPaymentVal"].ToString());
                    for (int i = 0; i < customerDebtOrDebtorTable.Length; i++){
                        string[] customerDebtOrDebtorTableDetail = customerDebtOrDebtorTable[i].Split('-');
                        if (transactionId == Convert.ToInt32(customerDebtOrDebtorTableDetail[2])){
                            for (int j = 0; j < moneyTypesTable.Length; j++){
                                string[] moneyTypesTableDetail = moneyTypesTable[j].Split('-');
                                if (Convert.ToInt32(customerDebtOrDebtorTableDetail[5]) == Convert.ToInt32(moneyTypesTableDetail[0])){
                                    li.SubItems.Add(moneyTypesTableDetail[1]);
                                    break;
                                }

                            }
                        }
                    }

                    for (int i = 0; i < customerDebtOrDebtorTable.Length; i++){
                        string[] customerDebtOrDebtorTableDetail = customerDebtOrDebtorTable[i].Split('-');
                        if (transactionId == Convert.ToInt32(customerDebtOrDebtorTableDetail[2])){
                            for (int j = 0; j < bankTypesTable.Length; j++){
                                string[] bankTypesTableDetail = bankTypesTable[j].Split('-');
                                if (Convert.ToInt32(customerDebtOrDebtorTableDetail[6]) == Convert.ToInt32(bankTypesTableDetail[0])){
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

        private string[] findReliabilityTable()
        {
            int reliabilityCount = reliabiltyTableRowsCount(), reliabilityCount2 = 0;
            string[] reliabiltyTable = new string[reliabilityCount];

            SqlCommand findCustomerDebtValTableCommand = new SqlCommand("SELECT * FROM degreeOfReliabilty", baglanti);
            SqlDataReader sdr = findCustomerDebtValTableCommand.ExecuteReader();
            while (sdr.Read()){
                if (reliabilityCount2 <= reliabilityCount){
                    reliabiltyTable[reliabilityCount2] = (sdr["degreeOfRealiabiltyId"].ToString()) + "-" + sdr["degreeOfReliabiltyDiscription"].ToString();
                    reliabilityCount2++;
                }
            }
            sdr.Close();
            return reliabiltyTable;
        }

        private int reliabiltyTableRowsCount()
        {
            int rowCount = 0;
            SqlCommand reliabiltyTableRowsCountCommand = new SqlCommand("SELECT * FROM degreeOfReliabilty", baglanti);
            SqlDataReader sdr = reliabiltyTableRowsCountCommand.ExecuteReader();
            while (sdr.Read()){
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
            while (sdr.Read()){
                if (customersTableRowCount2 <= customersTableRowCount){
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
            while (sdr.Read()){
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
            while (sdr.Read()){
                if (customersTableRowCount2 <= customersTableRowCount){
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
            int rowCount = 0;
            SqlCommand rowCountCommand = new SqlCommand("SELECT * FROM moneyTypesTable", baglanti);
            SqlDataReader sdr = rowCountCommand.ExecuteReader();
            while (sdr.Read()){
                rowCount++;
            }
            sdr.Close();
            return rowCount;
        }

        private string findInstallmentType(int transactionId)
        {
            string installmentType = "", sqlCommandText = "";
            int transactionTypeId = 0;
            SqlCommand findDebtOrDebtorCommand = new SqlCommand("SELECT * FROM customersTransactionType WHERE customerTransactionTypeId = @customersTransactionType", baglanti);
            findDebtOrDebtorCommand.Parameters.AddWithValue("@customersTransactionType", transactionId);
            SqlDataReader sdr = findDebtOrDebtorCommand.ExecuteReader();
            while (sdr.Read()){
                transactionTypeId = Convert.ToInt32(sdr["transactionType"]);
            }
            sdr.Close();

            if (transactionTypeId == 0) sqlCommandText = "SELECT * FROM customersMyDebt WHERE transactionTypeId = @transactionTypeId ";
            else if (transactionTypeId == 1) sqlCommandText = "SELECT * FROM customersDebtor WHERE transactionTypeId = @transactionTypeId ";
            SqlCommand findInstallmentTypeCommand = new SqlCommand(sqlCommandText, baglanti);
            findInstallmentTypeCommand.Parameters.AddWithValue("@transactionTypeId", transactionId);
            SqlDataReader sdr2 = findInstallmentTypeCommand.ExecuteReader();
            while (sdr2.Read()){
                if (Convert.ToInt32(sdr2["debtType"]) == 0) installmentType = "Peşin";
                else if (Convert.ToInt32(sdr2["debtType"]) == 1) installmentType = "Taksit";
            }
            sdr2.Close();
            return installmentType;
        }

        private string[] findBankTypesTable()
        {
            int bankCount1 = bankCount(), bankCount2 = 0;
            string[] exchangeMoneyName = new string[bankCount1];

            SqlCommand findExchangeMoneyFromIdToNameCommand = new SqlCommand("SELECT * FROM bankTypes", baglanti);
            SqlDataReader sdr = findExchangeMoneyFromIdToNameCommand.ExecuteReader();
            while (sdr.Read()){
                if (bankCount2 <= bankCount1){
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
            while (sdr.Read()){
                rowCount++;
            }
            sdr.Close();
            return rowCount;
        }

        private void customerDebtDetail_Load(object sender, EventArgs e)
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

            if (funcs.isConnect(baglanti) == true){
                connectSituation.BackColor = Color.Lime;
                funcs.setToolTip(connectSituation, "Veri Tabanı Bağlantısı Var");
            }
            else{
                MetroFramework.MetroMessageBox.Show(this, "Veri Tabanı Bağlantısı Kurulamadığından Dolayı Program Kapatılıyor..", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            if (metroStyleManager1.Theme == MetroFramework.MetroThemeStyle.Dark){
                helpPictureBox.Image = alacakVerecekTakip.Properties.Resources.helpWhite;
                customerPhoneText.BackColor = Color.FromArgb(17, 17, 17);
                customerPhoneText.ForeColor = Color.Silver;
                customerAdressRichText.BackColor = Color.FromArgb(17, 17, 17);
                customerAdressRichText.ForeColor = Color.Silver;
                customerInfoGroup.ForeColor = Color.Silver;
            }
            else{
                helpPictureBox.Image = alacakVerecekTakip.Properties.Resources.help;
                customerPhoneText.BackColor = Color.White;
                customerPhoneText.ForeColor = Color.Black;
                customerAdressRichText.BackColor = Color.White;
                customerAdressRichText.ForeColor = Color.Black;
                customerInfoGroup.ForeColor = Color.Black;
            }
            funcs.setToolTip(helpPictureBox, "'Müşteri Bilgileri' kısmından müşteriye ait bilgiler görülebilir.\nEğer müşteri bilgileri değiştirilmek istenirse 'Müşetri Tablosudnan'\ndeğiştilebilir. Sağ kısımda sizin müşteriye borçlarınız ve onun\nsize olan borçları gözükmektedir. Alt kısımda ise sağ taraftan\nseçitğiniz borcun detayları gözükmektedir.");

            fillCustomersInfo(showAllCustomersUserControl.selectedCustomerId);
            fillCustomerTransactionListViewColumns();
            fillCustomerTransactionListViewItems(showAllCustomersUserControl.selectedCustomerId);
            
        }

        private void customerTransactionListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (customerTransactionListView.SelectedItems.Count > 0){
                infoLabel1.Text = "İşlem Tipi: " + customerTransactionListView.SelectedItems[0].SubItems[1].Text;
                int transactionType = 0, debtType = 0;
                if (findInstallmentType(Convert.ToInt32(customerTransactionListView.SelectedItems[0].SubItems[5].Text)) != "") infoLabel2.Text = "Borç Tipi: " + findInstallmentType(Convert.ToInt32(customerTransactionListView.SelectedItems[0].SubItems[5].Text));
                
                if (customerTransactionListView.SelectedItems[0].SubItems[1].Text == "Borç Alma") transactionType = 0;
                else if (customerTransactionListView.SelectedItems[0].SubItems[1].Text == "Borç Verme") transactionType = 1;
                
                if (findInstallmentType(Convert.ToInt32(customerTransactionListView.SelectedItems[0].SubItems[5].Text)) == "Peşin") debtType = 0;
                if (findInstallmentType(Convert.ToInt32(customerTransactionListView.SelectedItems[0].SubItems[5].Text)) == "Taksit") debtType = 1;

                fillDebtPaymentListView1Columns(debtType);
                fillDebtPaymentListView1Items(debtType, transactionType, Convert.ToInt32(customerTransactionListView.SelectedItems[0].SubItems[5].Text));
            }
            
        }
    }
}
