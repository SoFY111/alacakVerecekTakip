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
    public partial class methods : UserControl
    {
        public methods()
        {
            InitializeComponent();
        }

        //public static SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-MEUA7KT\\SQLEXPRESS;Initial Catalog=creditAndDebitProgram;Integrated Security=True");
        public static SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-47VE9DM;Initial Catalog=creditAndDebitProgram;Integrated Security=True");
        public static SqlConnection yeniBaglantı = new SqlConnection("Data Source=DESKTOP-47VE9DM;Initial Catalog=master;Integrated Security=True");
        public int themeCode;

        public string themeChanger(int calledBlock)
        {//calledBlock = 0 => load kısmında, calledBlock = 1 => buton kısmında çağırıldı demektir
         /*
          * ilk önce tema kodunun kaç olduğunu alıyoruz 
          * eğer çift ise beyaz tema tek ise karanlık temayıuyguluyoruz
          * aynı kodu bir daha yazmamak için veri tabanı güncelleme komutlarını bir method içine aldık
          */

            string retVal;

            if (baglanti.State.ToString() != "Open") baglanti.Open();
            bool setThemeCode(int changingThemeCode)
            {
                SqlCommand setThemeCodeCommand = new SqlCommand("UPDATE theme SET theme = @themeCode WHERE themeId = 1", baglanti);
                setThemeCodeCommand.Parameters.AddWithValue("@themeCode", changingThemeCode);
                int retSetThemeCodeComVal = setThemeCodeCommand.ExecuteNonQuery();
                if (retSetThemeCodeComVal == 1) return true;
                else return false;
            }
            SqlCommand themeInfoCommand = new SqlCommand("SELECT * FROM theme WHERE themeId = 1", baglanti);
            SqlDataReader sdr = themeInfoCommand.ExecuteReader();
            while (sdr.Read()){
                themeCode = Convert.ToInt32(sdr["theme"]);
            }
            sdr.Close();

            if (calledBlock == 0){
                if (themeCode % 2 == 0) retVal = "light";
                else retVal = "dark";
            }
            else{
                if (themeCode % 2 == 1){
                    if (themeCode == 10) setThemeCode(0);
                    retVal = "light";
                }
                else{
                    if (themeCode >= 11) setThemeCode(1);
                    retVal = "dark";
                }
                if (themeCode > 11) setThemeCode(1);
                else {
                    themeCode++;
                    int newThemeCode = themeCode;
                    setThemeCode(newThemeCode);
                }
            }
            return retVal;
        }

        public ToolTip setToolTip(Control cntrl, string announcement)
        {//tooltip ekleme fonks.
            ToolTip toolTip = new ToolTip();
            toolTip.Active = true; // Görünsün mü?
            toolTip.UseFading = true; // Silinerek kaybolma ve yavaşça görünme
            toolTip.UseAnimation = true; // Animasyonlu açılış
            toolTip.ShowAlways = true; // her zaman göster
            toolTip.AutoPopDelay = 15000; // Mesajın açık kalma süresi
            toolTip.InitialDelay = 1000; // Mesajın açılma süresi
            toolTip.SetToolTip(cntrl, announcement); // Hangi kontrolde görünsün
            return toolTip;
        }

        public string companyName()
        {
            string companyName = "";
            SqlCommand themeInfoCommand = new SqlCommand("SELECT companyName FROM companyName WHERE companyNameId = 1", baglanti);
            SqlDataReader sdr1 = themeInfoCommand.ExecuteReader();
            while (sdr1.Read()){
                companyName = sdr1["companyName"].ToString();
            }
            sdr1.Close();
            return companyName;
        }

        public bool isConnect(SqlConnection baglanti)
        {
            bool isConnect = false;
            if (baglanti.State.ToString() == "Open") isConnect = true;
            else{
                baglanti.Open();
                if (baglanti.State.ToString() == "Open") isConnect = true;
                else isConnect = false;
            }
            return isConnect;
        }

        public void addHistory(string historyDiscription, int historyType)
        {
            DateTime time = DateTime.Now;
            string nowTime = time.ToString("yyyy'/'MM'/'dd' 'HH':'mm':'ss");

            SqlCommand addHistoryCommand = new SqlCommand("INSERT INTO history VALUES(@historyType, @historyDiscription, @historyDate);", baglanti);
            addHistoryCommand.Parameters.AddWithValue("@historyType", historyType);
            addHistoryCommand.Parameters.AddWithValue("@historyDiscription", historyDiscription);
            addHistoryCommand.Parameters.AddWithValue("@historyDate", nowTime);
            try{
                addHistoryCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                //throw;
            }
        }

        public bool isFirstOpening()
        {

            if (!isConnect(baglanti)) baglanti.Open();
            bool isFirstOpening = false;
            SqlCommand isFirstOpeningCommand = new SqlCommand("SELECT * FROM isFirstOpening WHERE firstOpeningId = 1", baglanti);
            SqlDataReader sdr = isFirstOpeningCommand.ExecuteReader();
            while (sdr.Read()){
                if (Convert.ToInt32(sdr["isFirst"]) == 1) isFirstOpening = true;
            }
            sdr.Close();

            return isFirstOpening;
        }

        public void updateFirstOpening()
        {
            SqlCommand editFirstOpeningCommand = new SqlCommand("UPDATE isFirstOpening SET isFirst = 0 WHERE firstOpeningId = 1", baglanti);
            int retEditFirstOpeningCommandVal = editFirstOpeningCommand.ExecuteNonQuery();
        }
    
        public void autoBackUp()
        {
            /* isAutoBackup tablosunda ki değer
            1 => otamatik yedekleme sıklığı ayda 1 kere(15)
            2 => otamatik yedekleme sıklığı ayda 2 kere(8,23)
            3 => otamatik yedekleme sıklığı ayda 3 kere(10, 20 ve 30'unde=>(Şubat ayında 28))
            5 => otamatik yedekleme sıklığı ayda 5 kere (1, 7, 13, 19, 25'inde)
            7 => otamatik yedekleme sıklığı ayda 7 kere (1, 5, 9, 13, 17, 21, 25'inde)
            10 => otamatik yedekleme sıklığı ayda 10 kere (1, 4, 7, 10, 13, 16, 19, 22, 25, 28)
            15 => otamatik yedekleme sıklığı ayda 15 kere (1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 28)
            30 => otamatik yedekleme sıklığı ayda 30 kere (Her Gün)
            99 => otamatik yedekleme sıklığı program her açıldığında ve kapandığında
         */
            int backUpRate = 0, nowDay = 0, nowMonth = 0;
            SqlCommand getBackUpRateCommand = new SqlCommand("SELECT * FROM isAutoBackUp WHERE isAutoBackUpId = 1", baglanti);
            SqlDataReader sdr = getBackUpRateCommand.ExecuteReader();
            while (sdr.Read()){
                backUpRate = Convert.ToInt32(sdr["isAutoBackupFrequency"]);
            }
            sdr.Close();

            nowDay = Convert.ToInt32(DateTime.Now.Day);
            nowMonth = Convert.ToInt32(DateTime.Now.Month);
            backupForm backupForm = new backupForm();

            if (backUpRate == 99) backupForm.backupDatabase("C:\\AlacakVerecekYedek\\OtomatikYedek");
            else{
                if (backUpRate == 1) if (nowDay == 15) backupForm.backupDatabase("C:\\AlacakVerecekYedek\\OtomatikYedek");
                else if (backUpRate == 2) if (nowDay == 8 || nowDay == 23) backupForm.backupDatabase("C:\\AlacakVerecekYedek\\OtomatikYedek");
                else if (backUpRate == 3) {
                    if (nowMonth == 2) if (nowDay == 10 || nowDay == 20 || nowDay == 28) backupForm.backupDatabase("C:\\AlacakVerecekYedek\\OtomatikYedek");
                    else if (nowMonth != 2) if (nowDay == 10 || nowDay == 20 || nowDay == 30) backupForm.backupDatabase("C:\\AlacakVerecekYedek\\OtomatikYedek");
                }
                else if (backUpRate == 5) if (nowDay == 1 || nowDay == 7 || nowDay == 13 || nowDay == 19 || nowDay == 28) backupForm.backupDatabase("C:\\AlacakVerecekYedek\\OtomatikYedek");
                else if (backUpRate == 7) if (nowDay == 1 || nowDay == 5 || nowDay == 9 || nowDay == 13 || nowDay == 17 || nowDay == 21 || nowDay == 25) backupForm.backupDatabase("C:\\AlacakVerecekYedek\\OtomatikYedek");
                else if (backUpRate == 10) if (nowDay == 1 || nowDay == 4 || nowDay == 7 || nowDay == 10 || nowDay == 13 || nowDay == 16 || nowDay == 19 || nowDay == 21 || nowDay == 23 || nowDay == 25 || nowDay == 28) backupForm.backupDatabase("C:\\AlacakVerecekYedek\\OtomatikYedek");
                else if (backUpRate == 15) if (nowDay == 1 || nowDay == 3 || nowDay == 5 || nowDay == 7 || nowDay == 9 || nowDay == 11 || nowDay == 13 || nowDay == 15 || nowDay == 17 || nowDay == 19 || nowDay == 21 || nowDay == 23 || nowDay == 25 || nowDay == 28) backupForm.backupDatabase("C:\\AlacakVerecekYedek\\OtomatikYedek");
                else if (backUpRate == 30) if (nowDay >= 1 || nowDay <= 28) backupForm.backupDatabase("C:\\AlacakVerecekYedek\\OtomatikYedek");
            }
            

        }

    }
}
