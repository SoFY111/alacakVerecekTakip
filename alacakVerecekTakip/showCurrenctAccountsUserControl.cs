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
    public partial class showCurrenctAccountsUserControl : MetroFramework.Controls.MetroUserControl
    {

        private static showCurrenctAccountsUserControl _instance;
        public static showCurrenctAccountsUserControl Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new showCurrenctAccountsUserControl();
                return _instance;
            }
        }

        methods funcs = new methods();
        debtTransactionsMethods debtTransactionFuncs = new debtTransactionsMethods();
        SqlConnection baglanti = methods.baglanti;
        public static int selectedCustomerId = 0, selectedTransactionId = 0;
        string theme;

        public showCurrenctAccountsUserControl()
        {
            InitializeComponent();
        }

        private void fillCurrencyAccountListViewColumns()
        {
            currencyAccountListView.Items.Clear();
            currencyAccountListView.View = View.Details;
            currencyAccountListView.GridLines = true;
            currencyAccountListView.OwnerDraw = true;

            currencyAccountListView.Columns.Add("Para Türü", 628, HorizontalAlignment.Right);
            currencyAccountListView.Columns.Add("Toplam Miktarı", 628, HorizontalAlignment.Left);

        }

        private void fillCurrencyAccountListViewGroups()
        {
            currencyAccountListView.Groups.Clear();
            SqlCommand fillCurrencyAccountListViewGroupCommmand = new SqlCommand("SELECT * FROM bankTypes", baglanti);
            SqlDataReader sdr = fillCurrencyAccountListViewGroupCommmand.ExecuteReader();
            while (sdr.Read())
            {
                currencyAccountListView.Groups.Add(new ListViewGroup(sdr["bankTypeName"].ToString(), HorizontalAlignment.Left));
            }
            sdr.Close();
        }

        private void fillCurrencyAccountListViewItems()
        {
            string[] bankTypesTable = findBabkTypesTable(), moneyTypesTable = findExchangeMoneyFromIdToName();
            ListViewItem li = new ListViewItem();
            for (int i = 0; i < bankTypesTable.Length; i++){
                string[] bankTypesTableDetail = bankTypesTable[i].Split('-');
                for (int j = 0; j < moneyTypesTable.Length; j++){
                    string[] moneyTypesTableDetail = moneyTypesTable[j].Split('-');
                    li = currencyAccountListView.Items.Add(moneyTypesTableDetail[1]);
                    li.SubItems.Add(doesItHaveEnoughMoney(bankTypesTableDetail[1], moneyTypesTableDetail[1]).ToString());
                    li.Group = currencyAccountListView.Groups[i];
                }
            }
        }

        private double doesItHaveEnoughMoney(string bankTypeName, string moneyTypeName)
        {
            int bankId = debtTransactionFuncs.bankNameToId(bankTypeName), moneyId = debtTransactionFuncs.moneyNameToId(moneyTypeName);
            double sumMoney = 0;
            SqlCommand sumMoneyCommand = new SqlCommand("SELECT * FROM moneyFunds WHERE bankId = @bankId AND moneyTypeId = @moneyId", baglanti);
            sumMoneyCommand.Parameters.AddWithValue("@bankId", bankId);
            sumMoneyCommand.Parameters.AddWithValue("@moneyId", moneyId);
            SqlDataReader sdr = sumMoneyCommand.ExecuteReader();
            while (sdr.Read())
            {
                string[] moneyVal2;
                double moneyVal12, afterPoint2;
                try{
                    moneyVal2 = sdr["moneyVal"].ToString().Split(',');
                    moneyVal12 = Convert.ToDouble(moneyVal2[0]);
                    afterPoint2 = Convert.ToDouble(moneyVal2[1].Substring(0, 2));
                }
                catch (Exception){
                    moneyVal12 = Convert.ToDouble(sdr["moneyVal"].ToString());
                    afterPoint2 = 0;
                    //throw;
                }
                if (Convert.ToInt32(sdr["transactionType"]) == 0) sumMoney -= moneyVal12 + (afterPoint2 / 100);
                else if (Convert.ToInt32(sdr["transactionType"]) == 1) sumMoney += moneyVal12 + (afterPoint2 / 100);
            }
            sdr.Close();

            return sumMoney;
        }

        private string[] findBabkTypesTable()
        {
            int bankCount = bankTableCount(), bankCount2 = 0;
            string[] bankTypesTable = new string[bankCount];

            SqlCommand findCustomerDebtValTableCommand = new SqlCommand("SELECT * FROM bankTypes", baglanti);
            SqlDataReader sdr = findCustomerDebtValTableCommand.ExecuteReader();
            while (sdr.Read())
            {
                if (bankCount2 <= bankCount)
                {
                    bankTypesTable[bankCount2] = sdr["bankTypeId"].ToString() + "-" + sdr["bankTypeName"].ToString();
                    bankCount2++;
                }
            }
            sdr.Close();
            return bankTypesTable;
        }

        private int bankTableCount()
        {
            int rowCount = 0;
            SqlCommand bankTableCountCommand = new SqlCommand("SELECT * FROM bankTypes", baglanti);
            SqlDataReader sdr = bankTableCountCommand.ExecuteReader();
            while (sdr.Read())
            {
                rowCount++;
            }
            sdr.Close();
            return rowCount;
        }

        private string[] findExchangeMoneyFromIdToName()
        {
            int moneyCount1 = moneyCount(), moneyCount2 = 0;
            string[] exchangeMoneyName = new string[moneyCount1];

            SqlCommand findExchangeMoneyFromIdToNameCommand = new SqlCommand("SELECT * FROM moneyTypesTable", baglanti);
            SqlDataReader sdr = findExchangeMoneyFromIdToNameCommand.ExecuteReader();
            while (sdr.Read())
            {
                if (moneyCount2 <= moneyCount1)
                {
                    exchangeMoneyName[moneyCount2] = (sdr["moneyId"].ToString()) + "-" + sdr["moneyName"].ToString();
                    moneyCount2++;
                }
            }
            sdr.Close();
            return exchangeMoneyName;
        }

        private int moneyCount()
        {
            int moneyCountt = 0;
            SqlCommand moneyCountCommand = new SqlCommand("SELECT * FROM moneyTypesTable", baglanti);
            SqlDataReader sdr = moneyCountCommand.ExecuteReader();
            while (sdr.Read())
            {
                moneyCountt++;
            }
            sdr.Close();
            return moneyCountt;
        }

        public static void reloadForm()
        {
            _instance = null;
        }

        private void currencyAccountListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            /*TextFormatFlags flags = TextFormatFlags.Left;

            using (StringFormat sf = new StringFormat())
            {
                // Store the column text alignment, letting it default
                // to Left if it has not been set to Center or Right.
                switch (e.Header.TextAlign)
                {
                    case HorizontalAlignment.Center:
                        sf.Alignment = StringAlignment.Center;
                        flags = TextFormatFlags.HorizontalCenter;
                        break;
                    case HorizontalAlignment.Right:
                        sf.Alignment = StringAlignment.Far;
                        flags = TextFormatFlags.Right;
                        break;
                }

                // Draw the text and background for a subitem with a 
                // negative value. 
                double subItemValue;
                if (e.ColumnIndex > 0 && Double.TryParse( e.SubItem.Text, out subItemValue) && subItemValue < 0)
                {
                    // Unless the item is selected, draw the standard 
                    // background to make it stand out from the gradient.
                    if ((e.ItemState & ListViewItemStates.Selected) == 0)
                    {
                        e.DrawBackground();
                    }

                    // Draw the subitem text in red to highlight it. 
                    e.Graphics.DrawString(e.SubItem.Text,
                        currencyAccountListView.Font, Brushes.Red, e.Bounds, sf);

                    return;
                }

                // Draw normal text for a subitem with a nonnegative 
                // or nonnumerical value.
                e.DrawText(flags);
            }*/

        }

        private void currencyAccountListView_DrawSubItem_1(object sender, DrawListViewSubItemEventArgs e)
        {
            // This is the default text alignment
            TextFormatFlags flags = TextFormatFlags.Left;

            // Align text on the right for the subitems after row 11 in the 
            // first column
            if (e.ColumnIndex == 0 && e.Item.Index >= 0)
            {
                flags = TextFormatFlags.Right;
            }

            e.DrawText(flags);
        }

        private void showCurrenctAccountsUserControl_Load(object sender, EventArgs e)
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

            fillCurrencyAccountListViewColumns();
            fillCurrencyAccountListViewGroups();
            fillCurrencyAccountListViewItems();
        }
    }
}
