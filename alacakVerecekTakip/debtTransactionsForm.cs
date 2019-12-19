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
    public partial class debtTransactionsForm : MetroFramework.Forms.MetroForm
    {
        public debtTransactionsForm()
        {
            InitializeComponent();
        }

        methods funcs = new methods();
        SqlConnection baglanti = methods.baglanti;
        string theme;

        private void fillCustomersCombo()
        {
            SqlCommand fillCustomersComboCommand = new SqlCommand("SELECT * FROM customers", baglanti);
            SqlDataReader sdr = fillCustomersComboCommand.ExecuteReader();
            while (sdr.Read()){
                customersCombo.Items.Add(sdr["customerName"].ToString() + " " + sdr["customerSurname"].ToString());
            }
            sdr.Close();
            customersCombo.SelectedIndex = 0;
        }

        private void sellForm_Load(object sender, EventArgs e)
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

            if (funcs.isConnect(baglanti) == true)
            {
                connectSituation.BackColor = Color.Lime;
                funcs.setToolTip(connectSituation, "Veri Tabanı Bağlantısı Var");
            }
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

            fillCustomersCombo();
        }
    }
}
