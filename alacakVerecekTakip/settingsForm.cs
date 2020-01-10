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
    public partial class settingsForm : MetroFramework.Forms.MetroForm
    {
        public settingsForm()
        {
            InitializeComponent();
        }

        methods funcs = new methods();
        debtTransactionsMethods debtTransactionFuncs = new debtTransactionsMethods();
        SqlConnection baglanti = methods.baglanti;
        public static int selectedCustomerId = 0, selectedTransactionId = 0;
        string theme;

        public static string settingFormMainPanel = "";
        public static Panel settingFormMainPanel1 = new Panel();

        private void settingsForm_Load(object sender, EventArgs e)
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
                headerLabel.ForeColor = Color.White;
                menuPanel.BackColor = Color.FromArgb(10, 10 ,10);
                themeButton.Normalcolor = Color.FromArgb(7, 7,7);
                themeButton.Textcolor = Color.White;
                themeButton.OnHoverTextColor = Color.White;


                installmentButton.Normalcolor = Color.FromArgb(7, 7, 7);
                installmentButton.Textcolor = Color.White;
                installmentButton.OnHoverTextColor = Color.White;

                zeroButton.Normalcolor = Color.FromArgb(7, 7, 7);
                zeroButton.Textcolor = Color.White;
                zeroButton.OnHoverTextColor = Color.White;

            }
            else
            {
                headerLabel.ForeColor = Color.Black;
                menuPanel.BackColor = Color.WhiteSmoke;
                themeButton.Normalcolor = Color.WhiteSmoke;
                themeButton.Textcolor = Color.Black;
                themeButton.OnHoverTextColor = Color.White;


                installmentButton.Normalcolor = Color.WhiteSmoke;
                installmentButton.Textcolor = Color.Black;
                installmentButton.OnHoverTextColor = Color.White;

                zeroButton.Normalcolor = Color.WhiteSmoke;
                zeroButton.Textcolor = Color.Black;
                zeroButton.OnHoverTextColor = Color.White;
            }
        }

        private void installmentButton_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(editInstallmentCountUserControl.Instance);
            settingFormMainPanel1 = mainPanel;
            editInstallmentCountUserControl.Instance.Dock = DockStyle.Fill;
            editInstallmentCountUserControl.Instance.BringToFront();
            
            if (metroStyleManager1.Theme == MetroFramework.MetroThemeStyle.Dark){
                themeButton.Normalcolor = Color.FromArgb(7, 7, 7);
                zeroButton.Normalcolor = Color.FromArgb(7, 7, 7);
                installmentButton.Normalcolor = Color.FromArgb(0, 150, 219);
            }
            else{
                themeButton.Normalcolor = Color.WhiteSmoke;
                zeroButton.Normalcolor = Color.WhiteSmoke;
                installmentButton.Normalcolor = Color.FromArgb(0, 150, 219);
            }
        }

        private void zeroButton_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(zeroUserControl.Instance);
            settingFormMainPanel1 = mainPanel;
            zeroUserControl.Instance.Dock = DockStyle.Fill;
            zeroUserControl.Instance.BringToFront();
            if (metroStyleManager1.Theme == MetroFramework.MetroThemeStyle.Dark){ 
                themeButton.Normalcolor = Color.FromArgb(7, 7, 7);
                zeroButton.Normalcolor = Color.FromArgb(0, 150, 219);
                installmentButton.Normalcolor = Color.FromArgb(7, 7, 7);
            }
            else{
                themeButton.Normalcolor = Color.WhiteSmoke;
                zeroButton.Normalcolor = Color.FromArgb(0, 150, 219);
                installmentButton.Normalcolor = Color.WhiteSmoke;
            }
        }

        private void themeButton_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(changeThemeUserControl.Instance);
            settingFormMainPanel1 = mainPanel;
            changeThemeUserControl.Instance.Dock = DockStyle.Fill;
            changeThemeUserControl.Instance.BringToFront();

            if (metroStyleManager1.Theme == MetroFramework.MetroThemeStyle.Dark){
                themeButton.Normalcolor = Color.FromArgb(0, 150, 219);
                zeroButton.Normalcolor = Color.FromArgb(7, 7, 7);
                installmentButton.Normalcolor = Color.FromArgb(7, 7, 7);
            }
            else{
                themeButton.Normalcolor = Color.FromArgb(0, 150, 219);
                zeroButton.Normalcolor = Color.WhiteSmoke;
                installmentButton.Normalcolor = Color.WhiteSmoke;
            }
        }
    }
}
