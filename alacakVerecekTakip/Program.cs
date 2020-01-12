using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace alacakVerecekTakip
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            methods funcs = new methods();
            programIsOpen();
            if (!funcs.isFirstOpening()) Application.Run(new loginScreenForm());
            else if (funcs.isFirstOpening()) Application.Run(new anasayfa());
        }

        static void programIsOpen(){
            SqlConnection baglanti = methods.baglanti;
            methods funcs = new methods();
            int backUpRate = 0;
            if (!funcs.isConnect(baglanti)) baglanti.Open();
            SqlCommand getBackupRate = new SqlCommand("SELECT * FROM isAutoBackUp WHERE isAutoBackUpId = 1", baglanti);
            SqlDataReader sdr = getBackupRate.ExecuteReader();
            while (sdr.Read())
            {
                backUpRate = Convert.ToInt32(sdr["isAutoBackupFrequency"]);
            }
            sdr.Close();

            if (backUpRate == 99) funcs.autoBackUp();
        }
    }
}
