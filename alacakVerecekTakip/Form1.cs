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
    public partial class anasayfa : MetroFramework.Forms.MetroForm
    {
        public anasayfa()
        {
            InitializeComponent();
        }

        methods funcs = new methods();
        SqlConnection baglanti = methods.baglanti;
        public static Panel mainpagePanel1 = new Panel();
        public static string companyName;
        public static int historyButttonVal = 0, customerListViewSortingType = -1;
        string theme;

       
        private void anasayfa_Load(object sender, EventArgs e)
        {
           /*DateTime time1 = DateTime.Now;
            System.Threading.Thread.Sleep(1000);
            DateTime time2 = DateTime.Now;
            TimeSpan time3 = time2 - time1;
            char[] ayrac = {':', '.'};
            string[] time4 = (time3.ToString()).Split(ayrac);
            
            MessageBox.Show((time4[2]));*/

            this.StyleManager = metroStyleManager1;
            theme = funcs.themeChanger(0);

            if (theme == "light") metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Light;
            else metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            if (metroStyleManager1.Theme == MetroFramework.MetroThemeStyle.Dark)
            {
                darkLightThemeChangerButton.TileImage = alacakVerecekTakip.Properties.Resources.lightButton;
                darkLightThemeChangerButton.Text = "Açık Mod";
            }
            else
            {
                darkLightThemeChangerButton.TileImage = alacakVerecekTakip.Properties.Resources.darkButton;
                darkLightThemeChangerButton.Text = "Koyu Mod";
            }

            if (funcs.isConnect(baglanti) == true){
                connectSituation.BackColor = Color.Lime;
                funcs.setToolTip(connectSituation, "Veri Tabanı Bağlantısı Var");
            }
            else{
                MetroFramework.MetroMessageBox.Show(this, "Veri Tabanı Bağlantısı Kurulamadığından Dolayı Program Kapatılıyor..", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }


            this.Text +=  " - " + funcs.companyName();
            companyName = this.Text;

            funcs.setToolTip(debtorButton, "Size Borcu Olan Kişiler.");
            funcs.setToolTip(autoBackupButton, "Yedekleme Ayarları.");
            funcs.setToolTip(companyNameChangerButton, "Firma Adı Değiştir.");
            funcs.setToolTip(userSettingsButton, "Kullanıcı Adı/Şifre Değiştir.");
            funcs.setToolTip(degreeOfReliabilityButton, "Güvenilirlik Durumu.");
            funcs.setToolTip(userSettingsButton, "Kullanıcı Adı/Şifre Değiştir.");

            mainPageUserControl mainPageUserControl = new mainPageUserControl();
            foreach (Control ctrl in mainPanel.Controls)
            {
                ctrl.Dispose();
            }
        }

        private void anasayfa_FormClosing(object sender, FormClosingEventArgs e){
            if(e.CloseReason == CloseReason.ApplicationExitCall && companyNameForm.isRestart2 == true){
                
            }
            else{

                if(e.CloseReason == CloseReason.FormOwnerClosing ||e.CloseReason == CloseReason.UserClosing || e.CloseReason == CloseReason.ApplicationExitCall) {
                    DialogResult isExit = MetroFramework.MetroMessageBox.Show(this, "ÇIKMAK İSTEDİĞİNİZE EMİN MİSİNİZ?", "DİKKAT!!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (isExit == DialogResult.Cancel) e.Cancel = true;
                    else Environment.Exit(1);
                }
            }
        }

        private void exitButton_Click(object sender, EventArgs e) => Application.Exit();

        private void darkLightThemeChangerButton_Click(object sender, EventArgs e)
        {
            theme = funcs.themeChanger(1);
            if (theme == "light") metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Light;
            else metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;

            if (metroStyleManager1.Theme == MetroFramework.MetroThemeStyle.Dark){
                darkLightThemeChangerButton.TileImage = alacakVerecekTakip.Properties.Resources.lightButton;
                darkLightThemeChangerButton.Text = "Açık Mod";
            }
            else{
                darkLightThemeChangerButton.TileImage = alacakVerecekTakip.Properties.Resources.darkButton;
                darkLightThemeChangerButton.Text = "Koyu Mod";
            }
        }

        private void moneyTypesButton_Click(object sender, EventArgs e)
        {
            moneyTypesButtonForm moneyTypesButtonForm = new moneyTypesButtonForm();
            moneyTypesButtonForm.ShowDialog();
        }

        private void companyNameChangerButton_Click(object sender, EventArgs e)
        {
            companyNameForm companyNameButtonForm = new companyNameForm();
            companyNameButtonForm.ShowDialog();
        }

        private void userSettingsButton_Click(object sender, EventArgs e)
        {
            userSettingsForm userSettingsForm = new userSettingsForm();
            userSettingsForm.ShowDialog();
        }

        private void notesButton_Click(object sender, EventArgs e)
        {
            notesForm notesForm = new notesForm();
            notesForm.ShowDialog();
        }

        private void degreeOfReliabilityButton_Click(object sender, EventArgs e)
        {
            reliabilityForm reliabilityForm = new reliabilityForm();
            reliabilityForm.ShowDialog();
        }

        private void settingsHistory_Click(object sender, EventArgs e)
        {
            historyButttonVal = 4;
            allHistoryForm allHistoryForm = new allHistoryForm();
            allHistoryForm.ShowDialog();
        }

        private void autoBackupButton_Click(object sender, EventArgs e)
        {
            backupForm backupForm = new backupForm();
            backupForm.ShowDialog();
        }

        private void mainPageButton_Click(object sender, EventArgs e)
        {
            if (!mainPanel.Controls.Contains(mainPageUserControl.Instance)){
                mainPanel.Controls.Add(mainPageUserControl.Instance);
                mainPageUserControl.Instance.Dock = DockStyle.Fill;
                mainPageUserControl.Instance.BringToFront();
            }
            else mainPageUserControl.Instance.BringToFront();
        }

        private void cashBalanceButton_Click(object sender, EventArgs e)
        {
            mainpagePanel1 = mainPanel;
            if (!mainPanel.Controls.Contains(cashBalanceUserControl.Instance))
            {
                mainPanel.Controls.Add(cashBalanceUserControl.Instance);
                cashBalanceUserControl.Instance.Dock = DockStyle.Fill;
                cashBalanceUserControl.Instance.BringToFront();
            }
            else cashBalanceUserControl.Instance.BringToFront();
        }

        private void bankTypesButton_Click(object sender, EventArgs e)
        {
            bankTypesForm bankTypesForm = new bankTypesForm();
            bankTypesForm.ShowDialog();
        }

        private void cashInflowButton_Click(object sender, EventArgs e)
        {
            cashInflowForm cashInflowValueForm = new cashInflowForm();
            cashInflowValueForm.ShowDialog();
        }

        private void cashHistoryButton_Click(object sender, EventArgs e)
        {
            historyButttonVal = 3;
            allHistoryForm allHistoryForm = new allHistoryForm();
            allHistoryForm.ShowDialog();
        }

        private void cashOutflowButton_Click(object sender, EventArgs e)
        {
            cashOutflowForm cashOutflowForm = new cashOutflowForm();
            cashOutflowForm.ShowDialog();
        }

        private void chequeTransactionsButton_Click(object sender, EventArgs e)
        {
            chequeTransactionsForm chequeTransactionsForm = new chequeTransactionsForm();
            chequeTransactionsForm.ShowDialog();
        }

        private void showChequesButton_Click(object sender, EventArgs e)
        {
            mainpagePanel1 = mainPanel;
            if (!mainPanel.Controls.Contains(showChequesUserControl.Instance))
            {
                mainPanel.Controls.Add(showChequesUserControl.Instance);
                showChequesUserControl.Instance.Dock = DockStyle.Fill;
                showChequesUserControl.Instance.BringToFront();
            }
            else showChequesUserControl.Instance.BringToFront();
        }

        private void currencyHistoryButton_Click(object sender, EventArgs e)
        {
            historyButttonVal = 2;
            allHistoryForm allHistoryForm = new allHistoryForm();
            allHistoryForm.ShowDialog();
        }

        private void customersButton_Click(object sender, EventArgs e)
        {
            customerListViewSortingType = 0;
            mainpagePanel1 = mainPanel;
            showAllCustomers.reloadForm();
            mainPanel.Controls.Add(showAllCustomers.Instance);
            showAllCustomers.Instance.Dock = DockStyle.Fill;
            showAllCustomers.Instance.BringToFront();
        }

        private void debtorButton_Click(object sender, EventArgs e)
        {
            customerListViewSortingType = 1;
            mainpagePanel1 = mainPanel;
            
            showAllCustomers.reloadForm();
            mainPanel.Controls.Add(showAllCustomers.Instance);
            showAllCustomers.Instance.Dock = DockStyle.Fill;
            showAllCustomers.Instance.BringToFront();
        }

        private void contactButton_Click(object sender, EventArgs e)
        {
            addCustomerForm addCustomerForm = new addCustomerForm();
            addCustomerForm.ShowDialog();
        }

        private void myDebtButton_Click(object sender, EventArgs e)
        {
            customerListViewSortingType = 2;
            mainpagePanel1 = mainPanel;
            showAllCustomers.reloadForm();
            mainPanel.Controls.Add(showAllCustomers.Instance);
            showAllCustomers.Instance.Dock = DockStyle.Fill;
            showAllCustomers.Instance.BringToFront();
        }
    }
}
