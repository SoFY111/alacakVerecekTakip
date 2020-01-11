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
    public partial class zeroUserControl : MetroFramework.Controls.MetroUserControl
    {

        private static zeroUserControl _instance;
        public static zeroUserControl Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new zeroUserControl();
                return _instance;
            }
        }

        public zeroUserControl()
        {
            InitializeComponent();
        }

        methods funcs = new methods();
        SqlConnection baglanti = methods.baglanti;
        public static int selectedHistory;
        string theme;

        private bool deleteAllInfo()
        {
            SqlCommand deleteAllBankTypesCommand = new SqlCommand("DELETE FROM bankTypes", baglanti);
            int retDeleteAllBankTypesCommandVal = deleteAllBankTypesCommand.ExecuteNonQuery();
            if (retDeleteAllBankTypesCommandVal > 0){
                SqlCommand firstVersionBankTypesCommand = new SqlCommand("INSERT INTO bankTypes VALUES('Ziraat Bankası')", baglanti);
                int retFirstVersionBankTypesCommandVal = firstVersionBankTypesCommand.ExecuteNonQuery();

                if (retFirstVersionBankTypesCommandVal == 1){
                    SqlCommand deleteChequesCommand = new SqlCommand("DELETE FROM chequeInfo", baglanti);
                    int retDeleteChequesCommandVal = deleteChequesCommand.ExecuteNonQuery();

                    if (retDeleteChequesCommandVal >= 0){
                        SqlCommand firstVersionCompanyNameCommand = new SqlCommand("UPDATE companyName SET companyName = 'DNT Yazılım' WHERE companyNameId = 1", baglanti);
                        int retFirstVersionCompanyNameCommandVal = firstVersionCompanyNameCommand.ExecuteNonQuery();

                        if (retFirstVersionCompanyNameCommandVal == 1){
                            SqlCommand deleteAllCustomers = new SqlCommand("DELETE FROM customers", baglanti);
                            int retDeleteAllCustomersVal = deleteAllCustomers.ExecuteNonQuery();

                            if (retDeleteAllCustomersVal >= 0){
                                SqlCommand deleteAllCustomersDebtorCommand = new SqlCommand("DELETE FROM customersDebtor", baglanti);
                                int retDeleteAllCustomersDebtorCommandVal = deleteAllCustomersDebtorCommand.ExecuteNonQuery();

                                if (retDeleteAllCustomersDebtorCommandVal >= 0){
                                    SqlCommand deleteAllInstallemtCommand = new SqlCommand("DELETE FROM customersInstallment", baglanti);
                                    int retDeleteAllInstallemtCommandVal = deleteAllInstallemtCommand.ExecuteNonQuery();

                                    if (retDeleteAllInstallemtCommandVal >= 0){
                                        SqlCommand deleteCustomersMyDebtCommand = new SqlCommand("DELETE FROM customersMyDebt", baglanti);
                                        int retdeleteCustomersMyDebtCommandVal = deleteCustomersMyDebtCommand.ExecuteNonQuery();

                                        if (retdeleteCustomersMyDebtCommandVal >= 0){
                                            SqlCommand deleteCustomersTransactionTypeCommand = new SqlCommand("DELETE FROM customersTransactionType", baglanti);
                                            int retDeleteCustomersTransactionTypeCommandVal = deleteCustomersTransactionTypeCommand.ExecuteNonQuery();

                                            if (retDeleteCustomersTransactionTypeCommandVal >= 0){
                                                SqlCommand deleteDegreeOfReliabiltyCommand = new SqlCommand("DELETE FROM degreeOfReliabilty", baglanti);
                                                int retDeleteDegreeOfReliabiltyCommanddVal = deleteDegreeOfReliabiltyCommand.ExecuteNonQuery();

                                                if (retDeleteDegreeOfReliabiltyCommanddVal >= 0){
                                                    SqlCommand firstVersionDegreeOfReliabiltyCommand = new SqlCommand("INSERT INTO degreeOfReliabilty VALUES('Çok İyi')", baglanti);
                                                    int retFirstVersionDegreeOfReliabiltyCommandVal = firstVersionDegreeOfReliabiltyCommand.ExecuteNonQuery();

                                                    if (retFirstVersionDegreeOfReliabiltyCommandVal == 1){
                                                        SqlCommand deleteExchangeRateTableCommand = new SqlCommand("DELETE FROM exchangeRateTable", baglanti);
                                                        int retExchangeRateTableCommandVal = deleteExchangeRateTableCommand.ExecuteNonQuery();

                                                        if (retExchangeRateTableCommandVal >= 0){
                                                            SqlCommand deleteHistoryCommand = new SqlCommand("DELETE FROM history", baglanti);
                                                            int retDeleteHistoryCommandVal = deleteHistoryCommand.ExecuteNonQuery();

                                                            if (retDeleteHistoryCommandVal >= 0){
                                                                SqlCommand deleteMoneyFundsCommand = new SqlCommand("DELETE FROM moneyFunds", baglanti);
                                                                int retDeleteMoneyFundsyCommandVal = deleteMoneyFundsCommand.ExecuteNonQuery();

                                                                if (retDeleteMoneyFundsyCommandVal >= 0){
                                                                    SqlCommand deleteMoneyTypesTableCommand = new SqlCommand("DELETE FROM moneyTypesTable", baglanti);
                                                                    int retMoneyTypesTableCommandVal = deleteMoneyTypesTableCommand.ExecuteNonQuery();

                                                                    if (retMoneyTypesTableCommandVal >= 0){
                                                                        SqlCommand firstVersionMoneyTypesTableCommand = new SqlCommand("INSERT INTO moneyTypesTable VALUES('Türk Lirası' , 1)", baglanti);
                                                                        int retFirstVersionMoneyTypesTableCommandVal = firstVersionMoneyTypesTableCommand.ExecuteNonQuery();

                                                                        if (retFirstVersionMoneyTypesTableCommandVal == 1){
                                                                            SqlCommand deleteNotesCommand = new SqlCommand("DELETE FROM notes", baglanti);
                                                                            int retdeleteNotesCommandVal = deleteNotesCommand.ExecuteNonQuery();

                                                                            if (retdeleteNotesCommandVal >= 0){
                                                                                SqlCommand firstVersionUsersCommand = new SqlCommand("UPDATE users SET userName = 'admin', userPass = 'admin', userLastPass = 'admin' WHERE userId = 1", baglanti);
                                                                                int retFirstVersionUsersCommandVal = firstVersionUsersCommand.ExecuteNonQuery();

                                                                                if (retFirstVersionUsersCommandVal == 1){
                                                                                    SqlCommand findLastMoneyTypeIdCommand = new SqlCommand("SELECT * FROM moneyTypesTable WHERE moneyName = 'Türk Lirası'", baglanti);
                                                                                    SqlDataReader sdr = findLastMoneyTypeIdCommand.ExecuteReader();
                                                                                    int lastMoneyId = 0;
                                                                                    while (sdr.Read()){
                                                                                        lastMoneyId = Convert.ToInt32(sdr["moneyId"]);
                                                                                    }
                                                                                    sdr.Close();

                                                                                    SqlCommand deleteSumAllMoneyCommand = new SqlCommand("DELETE FROM sumAllMoney", baglanti);
                                                                                    int retDeleteSumAllMoneyCommandVal = deleteSumAllMoneyCommand.ExecuteNonQuery();

                                                                                    if (retDeleteSumAllMoneyCommandVal >= 0){
                                                                                        SqlCommand addSumAllMoneyInLastMoneyIdCommand = new SqlCommand("INSERT INTO sumAllMoney VALUES(@lastMoneyId, 0)", baglanti);
                                                                                        addSumAllMoneyInLastMoneyIdCommand.Parameters.AddWithValue("@lastMoneyId", lastMoneyId);
                                                                                        int retAddSumAllMoneyInLastMoneyIdCommandVal = addSumAllMoneyInLastMoneyIdCommand.ExecuteNonQuery();

                                                                                        if (retAddSumAllMoneyInLastMoneyIdCommandVal == 1){
                                                                                            SqlCommand editThemeCommand = new SqlCommand("UPDATE theme SET theme = 0 WHERE themeId = 1", baglanti);
                                                                                            int retEditThemeCommandVal = editThemeCommand.ExecuteNonQuery();
                                                                                            if (retEditThemeCommandVal == 1) {
                                                                                                SqlCommand editFirstOpeningCommand = new SqlCommand("UPDATE isFirstOpening SET isFirst = 1 WHERE firstOpeningId = 1", baglanti);
                                                                                                int retEditFirstOpeningCommandVal = editFirstOpeningCommand.ExecuteNonQuery();
                                                                                                if (retEditFirstOpeningCommandVal == 1) return true;
                                                                                                else return false;
                                                                                            }
                                                                                            else return false;
                                                                                        }
                                                                                        else return false;
                                                                                    }
                                                                                    else return false;
                                                                                }
                                                                                else return false;
                                                                            }
                                                                            else return false;
                                                                        }
                                                                        else return false;
                                                                    }
                                                                    else return false;
                                                                }
                                                                else return false;
                                                            }
                                                            else return false;
                                                        }
                                                        else return false;
                                                    }
                                                    else return false;
                                                }
                                                else return false;
                                            }
                                            else return false;
                                        }
                                        else return false;
                                    }
                                    else return false;
                                }
                                else return false;
                            }
                            else return false;
                        }
                        else return false;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }

        private void zeroUserControl_Load(object sender, EventArgs e)
        {
            this.StyleManager = metroStyleManager1;
            theme = funcs.themeChanger(0);

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

            }
            else
            {

            }
        }

        private void zeroButton_Click(object sender, EventArgs e)
        {
            DialogResult isRestart = MetroFramework.MetroMessageBox.Show(this, "Bütün bilgileri silmek istediğinize emin misiniz?\n(Bu işlem kalıcıdır. Geri alınamaz.)\n(Yeni Kullanıcı Adı:admin, Şifre:admin, Eski Şifre Yerine:admin)", "DİKKAT!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (isRestart == DialogResult.Yes){
                if (deleteAllInfo()){
                    MetroFramework.MetroMessageBox.Show(this, "Program sıfırlandı.", "BİGLİ!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    companyNameForm.isRestart2 = true;
                    Application.Restart();
                }
                else MetroFramework.MetroMessageBox.Show(this, "Program sıfırlanamadı.", "BİGLİ!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
