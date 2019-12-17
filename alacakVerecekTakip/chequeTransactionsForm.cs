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
    public partial class chequeTransactionsForm : MetroFramework.Forms.MetroForm
    {
        public chequeTransactionsForm()
        {
            InitializeComponent();
        }

        methods funcs = new methods();
        SqlConnection baglanti = methods.baglanti;
        public static int chequeTransactionsType = -1;
        string theme;

        private void chequeTransactions_Load(object sender, EventArgs e)
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
                helpPictureBox.Image = alacakVerecekTakip.Properties.Resources.helpWhite;
            }
            else
            {
                helpPictureBox.Image = alacakVerecekTakip.Properties.Resources.help;
            }
        }

        private void drawChequeButton_Click(object sender, EventArgs e)
        {
            chequeTransactionsType = 2;
            addChequeForm addChequeForm = new addChequeForm();
            addChequeForm.ShowDialog();
        }

        private void addChequeButton_Click(object sender, EventArgs e)
        {
            chequeTransactionsType = 1;
            addChequeForm addChequeForm = new addChequeForm();
            addChequeForm.ShowDialog();
        }
    }
}
