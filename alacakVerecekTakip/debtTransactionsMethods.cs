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
    public partial class debtTransactionsMethods : UserControl
    {
        public debtTransactionsMethods()
        {
            InitializeComponent();
        }
        methods funcs = new methods();
        SqlConnection baglanti = methods.baglanti;

        public string translateNumberToWord(double moneyVal1)
        {
            string sTutar = Convert.ToDouble(moneyVal1).ToString("F2").Replace('.', ','); // Replace('.',',') ondalık ayracının . olma durumu için            
            string lira = sTutar.Substring(0, sTutar.IndexOf(',')); //tutarın tam kısmı
            string kurus = sTutar.Substring(sTutar.IndexOf(',') + 1, 2);
            string yazi = "";

            string[] birler = { "", "bir", "iki", "üç", "dört", "beş", "altı", "yedi", "sekiz", "dokuz" };
            string[] onlar = { "", "on", "yirmi", "otuz", "kırk", "elli", "altmış", "yetmiş", "seksen", "doksan" };
            string[] binler = { "katrilyon", "trilyon", "milyar", "milyon", "bin", "" }; //KATRİLYON'un önüne ekleme yapılarak artırabilir.

            int grupSayisi = 6;
            lira = lira.PadLeft(grupSayisi * 3, '0');
            string grupDegeri;

            for (int i = 0; i < grupSayisi * 3; i += 3)
            {
                grupDegeri = "";

                if (lira.Substring(i, 1) != "0") grupDegeri += birler[Convert.ToInt32(lira.Substring(i, 1))] + "yüz"; //yüzler                
                if (grupDegeri == "biryüz") grupDegeri = "yüz";

                grupDegeri += onlar[Convert.ToInt32(lira.Substring(i + 1, 1))]; //onlar
                grupDegeri += birler[Convert.ToInt32(lira.Substring(i + 2, 1))]; //birler                

                if (grupDegeri != "") grupDegeri += binler[i / 3];
                if (grupDegeri == "birbin") grupDegeri = "bin";

                if (grupDegeri != "") yazi += grupDegeri + " ";
            }
            return yazi;
        }

        public int bankNameToId(string bankTypeName)
        {
            int bankId = 0;
            SqlCommand bankNameToIdCommand = new SqlCommand("SELECT * FROM bankTypes WHERE bankTypeName = @bankTypeName", baglanti);
            bankNameToIdCommand.Parameters.AddWithValue("@bankTypeName", bankTypeName);
            SqlDataReader sdr = bankNameToIdCommand.ExecuteReader();
            while (sdr.Read())
            {
                bankId = Convert.ToInt32(sdr["bankTypeId"]);
            }
            sdr.Close();
            return bankId;
        }

        public int moneyNameToId(string moneyTypeName)
        {
            int moneyId = 0;
            SqlCommand moneyNameToIdCommand = new SqlCommand("SELECT * FROM moneyTypesTable WHERE moneyName = @moneyName", baglanti);
            moneyNameToIdCommand.Parameters.AddWithValue("@moneyName", moneyTypeName);
            SqlDataReader sdr = moneyNameToIdCommand.ExecuteReader();
            while (sdr.Read())
            {
                moneyId = Convert.ToInt32(sdr["moneyId"]);
            }
            sdr.Close();
            return moneyId;
        }

        public void reloadMainPagePanelUserControls()
        {
            if (anasayfa.mainPageUserControls == "mainPageUserControl")
            {
                anasayfa.mainpagePanel1.Controls.Clear();
                mainPageUserControl.reloadForm();
                anasayfa.mainpagePanel1.Controls.Add(mainPageUserControl.Instance);

                showChequesUserControl.reloadForm();
                cashBalanceUserControl.reloadForm();
                showAllCustomersUserControl.reloadForm();
                showCurrenctAccountsUserControl.reloadForm();
            }
            else if (anasayfa.mainPageUserControls == "cashBalanceUserControl")
            {
                anasayfa.mainpagePanel1.Controls.Clear();
                cashBalanceUserControl.reloadForm();
                anasayfa.mainpagePanel1.Controls.Add(cashBalanceUserControl.Instance);

                showChequesUserControl.reloadForm();
                mainPageUserControl.reloadForm();
                showAllCustomersUserControl.reloadForm();
                showCurrenctAccountsUserControl.reloadForm();
            }
            else if (anasayfa.mainPageUserControls == "showChequesUserControl")
            {
                anasayfa.mainpagePanel1.Controls.Clear();
                showChequesUserControl.reloadForm();
                anasayfa.mainpagePanel1.Controls.Add(showChequesUserControl.Instance);

                cashBalanceUserControl.reloadForm();
                mainPageUserControl.reloadForm();
                showAllCustomersUserControl.reloadForm();
                showCurrenctAccountsUserControl.reloadForm();
            }
            else if (anasayfa.mainPageUserControls == "showAllCustomersUserControl")
            {
                anasayfa.mainpagePanel1.Controls.Clear();
                showAllCustomersUserControl.reloadForm();
                anasayfa.mainpagePanel1.Controls.Add(showAllCustomersUserControl.Instance);

                showChequesUserControl.reloadForm();
                cashBalanceUserControl.reloadForm();
                mainPageUserControl.reloadForm();
                showCurrenctAccountsUserControl.reloadForm();
            }
            else if (anasayfa.mainPageUserControls == "showCurrenctAccountsUserControl")
            {
                anasayfa.mainpagePanel1.Controls.Clear();
                showCurrenctAccountsUserControl.reloadForm();
                anasayfa.mainpagePanel1.Controls.Add(showCurrenctAccountsUserControl.Instance);

                showChequesUserControl.reloadForm();
                cashBalanceUserControl.reloadForm();
                mainPageUserControl.reloadForm();
                showChequesUserControl.reloadForm();
            }
        }

        public void itHasPayed(int transactionId, int transactionType, int paymentInstallmentCount) 
        {
            /* 
             * transactionType: => 0 : Borç Alma
             * transactionType: => 1 : Borç Verme  
             * */

            /*
             * 
             * method'da parametre olarak işlemId(transacitonId), işlemTipi(transactionType) ve ödenenecekTaksit(paymentInstallmentCount) alıyoruz
             * ilk önce işlem tipine göre gerekli tablodan bilgiyi çekiyor, daha sonra eğer bu işlem taksit ise 
             * taksitMi değişkenini true yapıyor ve ödenmesi gereken ile ödenen tutarı karşılaştırıyor eğer
             * birbirine eşitse transactionTable tablosunda ki ödendiMi(isPaid) kısmı bir oluyor.
             * Daha sonra eğer taksit ise ödenecek taksidi parametre olarak almıştık 
             * bu taksidin gerekli alanlarını güncelliyoruz.
             * 
             * */

            string sqlText1 = "", sqlText2 = "";
            int isInstallmentDebt = 0, installmentCount = 0;
            double debtVal = 0, debtPaymentVal = 0, installmentDebtVal = 0, installmentDebtPaymentVal = 0;
            bool justUpdateDebtOrDebtorTable = false, justUpdateInstallmentDebt = false;
            if (transactionType == 0) sqlText1 = "SELECT * FROM customersMyDebt WHERE transactionTypeId = @transactionTypeId";
            else if (transactionType == 1) sqlText1 = "SELECT * FROM customersDebtor WHERE transactionTypeId = @transactionTypeId";

            SqlCommand debtInfoCommand = new SqlCommand(sqlText1, baglanti);
            debtInfoCommand.Parameters.AddWithValue("@transactionTypeId", transactionId);
            SqlDataReader sdr = debtInfoCommand.ExecuteReader();

            while (sdr.Read()){
                isInstallmentDebt = Convert.ToInt32(sdr["debtType"]);
                debtVal = Convert.ToDouble(sdr["debtVal"]);
                debtPaymentVal = Convert.ToDouble(sdr["debtPaymentVal"]);

                if ((debtPaymentVal + 1) >= debtVal) justUpdateDebtOrDebtorTable = true;
            }
            sdr.Close();

            if (justUpdateDebtOrDebtorTable){
                if (transactionType == 0) sqlText2 = "UPDATE customersMyDebt SET isPaid = 1, debtPaymentDate = @debtPaymentDate WHERE transactionTypeId = @transactionTypeId";
                else if (transactionType == 1) sqlText2 = "UPDATE customersDebtor SET isPaid = 1, debtPaymentDate = @debtPaymentDate WHERE transactionTypeId = @transactionTypeId";

                SqlCommand updateDebtCommand = new SqlCommand(sqlText2, baglanti);
                updateDebtCommand.Parameters.AddWithValue("@transactionTypeId", transactionId);
                updateDebtCommand.Parameters.AddWithValue("@debtPaymentDate", Convert.ToDateTime(DateTime.Now));
                updateDebtCommand.ExecuteNonQuery();

                SqlCommand updateTransactionTableCommand = new SqlCommand("UPDATE customersTransactionType SET isPaid = 1 WHERE customerTransactionTypeId = @customerTransactionTypeId", baglanti);
                updateTransactionTableCommand.Parameters.AddWithValue("@customerTransactionTypeId", transactionId);
                updateTransactionTableCommand.ExecuteNonQuery();
            }

            if (isInstallmentDebt == 1){
                SqlCommand debtInstallmentInfo = new SqlCommand("SELECT * FROM customersInstallment WHERE transactionTypeId = @transactionTypeId", baglanti);
                debtInstallmentInfo.Parameters.AddWithValue("@transactionTypeId", transactionId);
                SqlDataReader sdr2 = debtInstallmentInfo.ExecuteReader();
                while (sdr2.Read()){
                    installmentCount = Convert.ToInt32(sdr2["installmentCount"]);
                }
                sdr2.Close();

                justUpdateInstallmentDebt = false;
                SqlCommand debtInstallmentDetailCommand = new SqlCommand("SELECT * FROM customersInstallment WHERE transactionTypeId = @transactionTypeId AND installmentPaymentCounter = @installmentPaymentCounter", baglanti);
                debtInstallmentDetailCommand.Parameters.AddWithValue("@transactionTypeId", transactionId);
                debtInstallmentDetailCommand.Parameters.AddWithValue("@installmentPaymentCounter", paymentInstallmentCount);
                SqlDataReader sdr3 = debtInstallmentDetailCommand.ExecuteReader();
                while (sdr3.Read()){
                    installmentDebtVal = Convert.ToDouble(sdr3["installmentMinPaymentVal"]);
                    installmentDebtPaymentVal = Convert.ToDouble(sdr3["installmentPaymentVal"]);

                    if ((installmentDebtPaymentVal+ 1) >= installmentDebtVal) justUpdateInstallmentDebt = true;
                }
                sdr3.Close();

                if (justUpdateInstallmentDebt){
                    SqlCommand updateDebtInstallmentCommand = new SqlCommand("UPDATE customersInstallment SET isPaid = 1, installmentPaymentDate = @installmentPaymentDate WHERE transactionTypeId = @transactionTypeId AND installmentPaymentCounter = @installmentPaymentCounter", baglanti);
                    updateDebtInstallmentCommand.Parameters.AddWithValue("@installmentPaymentDate", Convert.ToDateTime(DateTime.Now));
                    updateDebtInstallmentCommand.Parameters.AddWithValue("@transactionTypeId", transactionId);
                    updateDebtInstallmentCommand.Parameters.AddWithValue("@installmentPaymentCounter", paymentInstallmentCount);
                    updateDebtInstallmentCommand.ExecuteNonQuery();

                    if (paymentInstallmentCount == installmentCount){
                        SqlCommand updateTransactionTableCommand = new SqlCommand("UPDATE customersTransactionType SET isPaid = 1 WHERE customerTransactionTypeId = @customerTransactionTypeId", baglanti);
                        updateTransactionTableCommand.Parameters.AddWithValue("@customerTransactionTypeId", transactionId);
                        updateTransactionTableCommand.ExecuteNonQuery();
                    }
                }
                
            }
        }

    
    }
}
