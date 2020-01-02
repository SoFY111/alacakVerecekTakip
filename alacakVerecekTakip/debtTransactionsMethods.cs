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
                showChequesUserControl.reloadForm();
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
    }
}
