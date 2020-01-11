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
            bool isFirstOpening = false;
            SqlCommand isFirstOpeningCommand = new SqlCommand("SELECT * FROM isFirstOpening WHERE firstOpeningId = 1", baglanti);
            SqlDataReader sdr = isFirstOpeningCommand.ExecuteReader();
            while (sdr.Read()){
                if (Convert.ToInt32(sdr["isFirst"]) == 1) isFirstOpening = true;
            }
            sdr.Close();

            return isFirstOpening;
        }
    }
}
