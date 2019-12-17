using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace alacakVerecekTakip
{
    public partial class backupForm : MetroFramework.Forms.MetroForm
    {
        public backupForm()
        {
            InitializeComponent();
        }

        methods funcs = new methods();
        SqlConnection baglanti = methods.baglanti;
        public static int selectedHistory;
        string theme;

        private bool isAutoBack()
        {
            bool isAutoBck = false;
            SqlCommand isAutoBackupCommand = new SqlCommand("SELECT * FROM isAutoBackup WHERE isAutoBackupId = 1", baglanti);
            SqlDataReader sdr = isAutoBackupCommand.ExecuteReader();
            while (sdr.Read()){
                if (Convert.ToInt32(sdr["isAutoBackup"].ToString()) == 1) isAutoBck = true;
                else isAutoBck = false;
            }
            sdr.Close();
            return isAutoBck;
        }

        private bool updateAutoBackup(int value)
        {/* isAutoBackup tablosunda ki değer
            0 => otamatik yedekleme yok
            1 => otamatik yedekleme sıklığı seçilmiş
         */
            SqlCommand updateAutoBackupCommand = new SqlCommand("UPDATE isAutoBackup SET isAutoBackup = @autoBackup WHERE isAutoBackupId = 1", baglanti);
            updateAutoBackupCommand.Parameters.AddWithValue("@autoBackup", value);
            int retUpdateAutoBackupVal = updateAutoBackupCommand.ExecuteNonQuery();
            if (retUpdateAutoBackupVal == 1) return true;
            else return false;
        }

        private bool updateAutoBackupFrequency(int value)
        {/* isAutoBackup tablosunda ki değer
            1 => otamatik yedekleme sıklığı ayda 1 kere(15)
            2 => otamatik yedekleme sıklığı ayda 2 kere(8,23)
            3 => otamatik yedekleme sıklığı ayda 3 kere(10, 20 ve 30'unde=>(Şubat ayında 28))
            5 => otamatik yedekleme sıklığı ayda 5 kere (1, 7, 13, 19, 25'inde)
            7 => otamatik yedekleme sıklığı ayda 7 kere (1, 5, 9, 13, 17, 21, 25'inde)
            10 => otamatik yedekleme sıklığı ayda 10 kere (1, 4, 7, 10, 13, 16, 19, 22, 25, 28)
            15 => otamatik yedekleme sıklığı ayda 15 kere (1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 28)
            30 => otamatik yedekleme sıklığı ayda 30 kere (Her Gün)
            99 => otamatil yedekleme sıklığı program her açıldığında ve kapandığında
         */
            SqlCommand updateAutoBackupCommand = new SqlCommand("UPDATE isAutoBackup SET isAutoBackupFrequency = @autoBackupFrequency WHERE isAutoBackupId = 1", baglanti);
            updateAutoBackupCommand.Parameters.AddWithValue("@autoBackupFrequency", value);
            int retUpdateAutoBackupVal = updateAutoBackupCommand.ExecuteNonQuery();
            if (retUpdateAutoBackupVal == 1) return true;
            else return false;
        }

        private int autoBackupFrequencyVal()
        {
            int autoBackupFrequencyVal = 1;
            SqlCommand autoBackupFrequencyValCommand = new SqlCommand("SELECT * FROM isAutoBackup WHERE isAutoBackupId = 1", baglanti);
            SqlDataReader sdr = autoBackupFrequencyValCommand.ExecuteReader();
            while (sdr.Read())
            {
                autoBackupFrequencyVal = Convert.ToInt32(sdr["isAutoBackupFrequency"].ToString());
            }
            sdr.Close();
            return autoBackupFrequencyVal;
        }

        private void CreateDumpDevice(string dumpName, string backupPath)
        {
            //C:\\ herhangi bir yere 1 den fazla yedek almak için her seferinde BACKUP DEVICE oluşturuyoruz.
            SqlCommand myCommand = new SqlCommand("EXEC sp_addumpdevice 'disk', '" + dumpName + "', '" + backupPath + "' ", baglanti);
            try{
                myCommand.ExecuteNonQuery();
            }
            catch (Exception err){
                if (err.ToString().IndexOf("already exist") > 0){
                    //eger bu device zaten mevcut ise birşey yapmıyoruz. 
                    return;
                }
                else{
                    MessageBox.Show(err.Message, "Hata");
                }
            }
        }

        private bool deleteDumpDevice()
        {
            /* her yedek aldığımızda BACKUP DEVICE oluşturuyorduk bir süre
             * sonra bunlar çok fazla yük bindirmeye başlayacaktı,
             * böyle bir şey olmaması için her yedek alma işleminden
             * sonra BACKUP DEVICE(dump) siliyoruz, böylelikle 
             * hem veri tabanımızda fazladan bir tablo oluşturmadık hemde 
             * BACKUP DEVICES sayısını minumum'da tuttuk */
            SqlCommand deleteDumpDeviceCommand = new SqlCommand("EXEC sys.sp_dropdevice 'sqlBackUP1';", baglanti);
            int retDeleteDumpDeviceCommandVal = deleteDumpDeviceCommand.ExecuteNonQuery();
            if (retDeleteDumpDeviceCommandVal == 1) return true;
            else return false;
        }

        private bool backupDatabase(string filePath)
        {
            /* ilk önce yedek alınan günün tarih ve saatini sistemden çekiyoruz,
             * daha sonra yedek alınacak ismi giriyoruz ve CreateDumpDevice methodu ile
             * bir BACKUP DEVICE oluşturuyoruz, daha sonra backupDatabaseCommand ile
             * veri tabanımızın yedeğini alıyoruz eğer çalışırsa yedek aldığımız
             * BACKUP DEVICE'ı siliyoruz. */
            DateTime date1 = DateTime.Now;
            string time = date1.ToString("yyyyMMddTHHmm"), dumpName = "sqlBackUP1";
            filePath += "\\AlacakVerecekTakipYedek" + time + ".bak";
            CreateDumpDevice(dumpName, filePath);

            SqlCommand backupDatabaseCommand = new SqlCommand("BACKUP database creditAndDebitProgram to @dumpName ", baglanti);
            backupDatabaseCommand.Parameters.AddWithValue("@dumpName", dumpName);
            backupDatabaseCommand.Parameters.AddWithValue("@filePath", filePath);

            int retBackupDatabaseCommandVal = backupDatabaseCommand.ExecuteNonQuery();
            if (retBackupDatabaseCommandVal == -1){
                bool deleteDumpDeviceComplated = deleteDumpDevice();
                if (deleteDumpDeviceComplated) return true;
                else return false;
            }
            else return false;
        }

        private bool deleteAndBackupDB(string backupPath, SqlConnection yeniBaglanti)
        {
            /* burada sqlCommand ile veri tabanımızı aktif olarak kullanan biri
             * varsa onları 'kill' komutu ile siliyoruz eğer bunu yapmazsak veri tabanımızı silemiyoruz.
             * killUsersInDBCommand komutu başarılı bir şekilde çalıştıktan sonra veri tabanımızı siliyoruz.
             * eğer deleteDBCommand başarılı bir şekilde çalışıtsa backupDBCommand ile veri tabanımızı
             * geri yüklemiş oluyoruz. */
            string sqlCommand = "declare @Sql varchar(1000), @veritabaniadi varchar(100) " +
                "set @veritabaniadi = 'creditAndDebitProgram' " +
                "set @Sql = '' " +
                "select @Sql = @Sql + 'kill ' + convert(char(10), spid) + ' ' " +
                "from master.dbo.sysprocesses " +
                "where db_name(dbid) = @veritabaniadi " +
                "and " +
                "dbid <> 0 " +
                "and " +
                "spid <> @@spid " +
                "exec(@Sql) ";
            SqlCommand killUsersInDBCommand = new SqlCommand(sqlCommand, yeniBaglanti);

            int retKillUsersInDBCommand = killUsersInDBCommand.ExecuteNonQuery();
            if (retKillUsersInDBCommand == -1){
                SqlCommand deleteDBCommand = new SqlCommand("DROP DATABASE creditAndDebitProgram", yeniBaglanti);

                int retDeleteDBCommandVal = deleteDBCommand.ExecuteNonQuery();
                if (retDeleteDBCommandVal == -1)
                {
                    SqlCommand backupDBCommand = new SqlCommand("RESTORE DATABASE creditAndDebitProgram FROM DISK = '" + backupPath + "'", yeniBaglanti);

                    int retBackupDBCommandVal = backupDBCommand.ExecuteNonQuery();
                    if (retBackupDBCommandVal == -1) return true;
                    else return false;
                }
                else return false;
            }
            else return false;
        }

        private void backupForm_Load(object sender, EventArgs e)
        {
            this.StyleManager = metroStyleManager1;
            theme = funcs.themeChanger(0);
            onceBackupGroup.BackColor = Color.Transparent;
            openBackupGroup.BackColor = Color.Transparent;

            if (theme == "light"){
                metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Light;
                onceBackupGroup.ForeColor = Color.Black;
                openBackupGroup.ForeColor = Color.Black;
            }
            else{
                metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
                onceBackupGroup.ForeColor = Color.DarkGray;
                openBackupGroup.ForeColor = Color.DarkGray;
            }

            if (funcs.isConnect(baglanti) == true){
                connectSituation.BackColor = Color.Lime;
                funcs.setToolTip(connectSituation, "Veri Tabanı Bağlantısı Var");
            }
            else{
                MetroFramework.MetroMessageBox.Show(this, "Veri Tabanı Bağlantısı Kurulamadığından Dolayı Program Kapatılıyor..", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            if (isAutoBack()){
                autoBackUpToggle.Checked = true;

                if (theme == "light"){
                    autoBackupFrequencyLabel.ForeColor = Color.Black;
                    everyTimeAutoBackupLabel.ForeColor = Color.Black;
                    infoLabel.ForeColor = Color.Black;
                    autoBackupFrequencyCombo.ForeColor = Color.Black;
                    everyTimeAutoBackupCheck.BackgroundImage = alacakVerecekTakip.Properties.Resources.ok;
                }
                else{
                    autoBackupFrequencyLabel.ForeColor = Color.FromArgb(170, 170, 170);
                    everyTimeAutoBackupLabel.ForeColor = Color.FromArgb(170, 170, 170);
                    infoLabel.ForeColor = Color.FromArgb(170, 170, 170);
                    autoBackupFrequencyCombo.ForeColor = Color.Black;
                    everyTimeAutoBackupCheck.BackgroundImage = alacakVerecekTakip.Properties.Resources.okWhite;
                }

                int autoBackupFrequencyValue = autoBackupFrequencyVal();
                if (autoBackupFrequencyValue != 99){
                    everyTimeAutoBackupCheck.Enabled = true;
                    everyTimeAutoBackupCheck.Checked = false;
                    autoBackupFrequencyCombo.Enabled = true;

                    autoBackupFrequencyCombo.Text = autoBackupFrequencyValue.ToString();
                }
                else{
                    everyTimeAutoBackupCheck.Enabled = true;
                    everyTimeAutoBackupCheck.Checked = true;
                    autoBackupFrequencyCombo.Enabled = false;
                }
                saveAutoBackupSettingsButton.Enabled = true;
            }
            else{
                autoBackUpToggle.Checked = false;

                if (theme == "light"){
                    autoBackupFrequencyLabel.ForeColor = Color.FromArgb(170, 170, 170);
                    everyTimeAutoBackupLabel.ForeColor = Color.FromArgb(170, 170, 170);
                    infoLabel.ForeColor = Color.FromArgb(170, 170, 170);
                    autoBackupFrequencyCombo.ForeColor = Color.FromArgb(170, 170, 170);
                    everyTimeAutoBackupCheck.BackgroundImage = alacakVerecekTakip.Properties.Resources.ok;
                    autoBackupGroup.ForeColor = Color.DarkGray;
                }
                else{
                    autoBackupFrequencyLabel.ForeColor = Color.Black;
                    everyTimeAutoBackupLabel.ForeColor = Color.Black;
                    infoLabel.ForeColor = Color.Black;
                    autoBackupFrequencyCombo.ForeColor = Color.Silver;
                    everyTimeAutoBackupCheck.BackgroundImage = alacakVerecekTakip.Properties.Resources.okWhite;
                    autoBackupGroup.ForeColor = Color.Black;
                }

                everyTimeAutoBackupCheck.Enabled = false;
                everyTimeAutoBackupCheck.CheckState = CheckState.Indeterminate;
                autoBackupFrequencyCombo.Enabled = false;
            }
        }

        private void autoBackUpToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (autoBackUpToggle.Checked == true){
                if (theme == "light"){
                    autoBackupFrequencyLabel.ForeColor = Color.Black;
                    everyTimeAutoBackupLabel.ForeColor = Color.Black;
                    infoLabel.ForeColor = Color.Black;
                    saveAutoBackupSettingsButton.BackColor = Color.FromArgb(0, 174, 219);
                    autoBackupGroup.ForeColor = Color.Black; ;
                    autoBackupFrequencyCombo.ForeColor = Color.Black;
                    everyTimeAutoBackupCheck.BackgroundImage = alacakVerecekTakip.Properties.Resources.ok;
                }
                else{
                    autoBackupFrequencyLabel.ForeColor = Color.FromArgb(170, 170, 170);
                    everyTimeAutoBackupLabel.ForeColor = Color.FromArgb(170, 170, 170);
                    infoLabel.ForeColor = Color.FromArgb(170, 170, 170);
                    saveAutoBackupSettingsButton.BackColor = Color.FromArgb(0, 174, 219);
                    autoBackupGroup.ForeColor = Color.FromArgb(170, 170, 170);
                    autoBackupFrequencyCombo.ForeColor = Color.Black;
                    everyTimeAutoBackupCheck.BackgroundImage = alacakVerecekTakip.Properties.Resources.okWhite;
                }

                everyTimeAutoBackupCheck.Enabled = true;
                saveAutoBackupSettingsButton.Enabled = true;
                autoBackupFrequencyCombo.Enabled = true;
                everyTimeAutoBackupCheck.Checked = false;
            }
            else{
                if (theme == "light"){
                    autoBackupFrequencyLabel.ForeColor = Color.FromArgb(170, 170, 170);
                    everyTimeAutoBackupLabel.ForeColor = Color.FromArgb(170, 170, 170);
                    infoLabel.ForeColor = Color.FromArgb(170, 170, 170);
                    saveAutoBackupSettingsButton.BackColor = Color.Silver;
                    autoBackupFrequencyCombo.ForeColor = Color.FromArgb(170, 170, 170);
                    everyTimeAutoBackupCheck.BackgroundImage = alacakVerecekTakip.Properties.Resources.ok;
                    autoBackupGroup.ForeColor = Color.DarkGray;
                }
                else{
                    autoBackupFrequencyLabel.ForeColor = Color.Black;
                    everyTimeAutoBackupLabel.ForeColor = Color.Black;
                    infoLabel.ForeColor = Color.Black;
                    saveAutoBackupSettingsButton.BackColor = Color.Silver;
                    autoBackupFrequencyCombo.ForeColor = Color.Silver;
                    everyTimeAutoBackupCheck.BackgroundImage = alacakVerecekTakip.Properties.Resources.okWhite;
                    autoBackupGroup.ForeColor = Color.Black;
                }
                everyTimeAutoBackupCheck.Enabled = false;
                everyTimeAutoBackupCheck.CheckState = CheckState.Indeterminate;
                saveAutoBackupSettingsButton.Enabled = false;
                autoBackupFrequencyCombo.Enabled = false;
            }
        }

        private void everyTimeAutoBackupCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (everyTimeAutoBackupCheck.Checked == true) autoBackupFrequencyCombo.Enabled = false;
            else autoBackupFrequencyCombo.Enabled = true;
        }

        private void saveAutoBackupSettings_Click(object sender, EventArgs e)
        {
            if ((everyTimeAutoBackupCheck.CheckState == CheckState.Checked || autoBackupFrequencyCombo.Text != "")){
                updateAutoBackup(1);
                if (everyTimeAutoBackupCheck.Checked == true)
                {
                    updateAutoBackupFrequency(99);
                    MetroFramework.MetroMessageBox.Show(this, "'Otomatik Yedekleme' işlemi kaydedildi..\nProgram Her açılıp kapandığında yedek alınacak. Bundan dolayı açılıp kapanma süreleri uzayabilir.!!", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    funcs.addHistory("'Otomatik Yedekleme' ayarları değiştirildi. Yeni ayar program her açılıp kapandığında yenilenecek.", 4);
                }
                else{
                    updateAutoBackupFrequency(Convert.ToInt32(autoBackupFrequencyCombo.Text));
                    MetroFramework.MetroMessageBox.Show(this, "'Otomatik Yedekleme' işlemi kaydedildi..\nProgram ayda " + autoBackupFrequencyCombo.Text + " kere yedeklenecek...", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    funcs.addHistory("'Yedekleme' ayarları değiştirildi. Yeni ayar program ayda " + autoBackupFrequencyCombo.Text + " kere yedeklenecek.", 4);
                }
            }
            else{
                updateAutoBackup(0);
                MetroFramework.MetroMessageBox.Show(this, "Otamatik olarak kaydedilmeyecek...", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                funcs.addHistory("'Yedekleme' ayarları değiştirildi. Yeni ayar program yedeklenmeyecek. " , 4);
            }
        }

        private void onceBackupButton_Click(object sender, EventArgs e)
        {
            DateTime nowTime = DateTime.Now;
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog()){
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK){
                    onceBackupPathText.Text = folderBrowserDialog.SelectedPath;
                    if (backupDatabase(folderBrowserDialog.SelectedPath)) {
                        MetroFramework.MetroMessageBox.Show(this, "Yedek alma işlemi başarılı bir şekilde gerçekleşti...", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        funcs.addHistory(nowTime.ToString("yyyy'/'MM'/'dd' 'HH':'mm':'ss") + " tarihinde '" +folderBrowserDialog.SelectedPath + "' adresine programın yedeği alındı alındı.", 4);
                    }
                    else MetroFramework.MetroMessageBox.Show(this, "Yedek alma işlemi gerçekleşmedi...", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void openBackupButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog()){
                openFile.InitialDirectory = "C:\\AlacakVerecekTakipYedek";//dialog her açıldığında bu adres açılsın
                openFile.Filter = "Alacak Verecek Yedek Dosyası |*.bak";//sadece bu uzantıları kabul eder
                openFile.FilterIndex = 2;
                openFile.Title = ".bak Dosyası Seçiniz..";
                if (openFile.ShowDialog() == DialogResult.OK){
                    openBackupPathText.Text = openFile.FileName;

                    baglanti.Close();//eski bağlantıyı kapatıyoruz çünkü master tablosunda çalışacağız
                    SqlConnection yeniBaglanti = new SqlConnection("Data Source=HAKAN-BILGISAYA;Initial Catalog=master;Integrated Security=True");
                    yeniBaglanti.Open();
                    if (funcs.isConnect(yeniBaglanti) == true){
                        if (deleteAndBackupDB(openBackupPathText.Text, yeniBaglanti)){
                            yeniBaglanti.Close();

                            baglanti.Open();
                            if (funcs.isConnect(baglanti) == true){
                                connectSituation.BackColor = Color.Lime;
                                funcs.setToolTip(connectSituation, "Veri Tabanı Bağlantısı Var");
                                MetroFramework.MetroMessageBox.Show(this, "Yedekten geri yükleme işlemi başarılı...", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                funcs.addHistory("'" + openFile.FileName + "' adresinde ki yedekten geri yükleme yapıldı.", 4);
                            }
                            else{
                                MetroFramework.MetroMessageBox.Show(this, "Veri Tabanı Bağlantısı Kurulamadığından Dolayı Program Kapatılıyor..", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Application.Exit();
                            }
                        }
                        else MetroFramework.MetroMessageBox.Show(this, "Geri Yükleme işlemi gerçekleştirilemedi..", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Veri Tabanı Bağlantısı Kurulamadığından Dolayı Program Kapatılıyor..", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                }
            }
        }
    }
}
