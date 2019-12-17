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
    public partial class allHistoryForm : MetroFramework.Forms.MetroForm
    {
        public allHistoryForm()
        {
            InitializeComponent();
        }

        methods funcs = new methods();
        SqlConnection baglanti = methods.baglanti;
        public static int selectedHistory;
        string theme;

        private void fillHistoryListViewColumn()
        {
            historyListView.Items.Clear();
            historyListView.View = View.Details;
            historyListView.GridLines = true;
            historyListView.Columns.Add("İşlem Türü", 125);
            historyListView.Columns.Add("İşlemin Sırası", 75);
            historyListView.Columns.Add("İşlem İşlem Tarihi", 125);
            historyListView.Columns.Add("İşlem Açıklaması");
            historyListView.AllowSorting = true;
            historyListView.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void fillHistoryListViewItems(int orderTransactionsType)
        {
            historyListView.Items.Clear();
            string transactions = "";
            if (orderTransactionsType == 0)
            {
                SqlCommand fillHistoryListViewCommand = new SqlCommand("SELECT * FROM history ORDER BY historyId DESC", baglanti);
                SqlDataReader sdr = fillHistoryListViewCommand.ExecuteReader();
                ListViewItem li = new ListViewItem();

                while (sdr.Read())
                {
                    if (sdr.GetInt32(1) == 1) transactions = "Hızlı İşlemler";
                    else if (sdr.GetInt32(1) == 2) transactions = "Cari İşlemler";
                    else if (sdr.GetInt32(1) == 3) transactions = "Kasa İşlemleri";
                    else if (sdr.GetInt32(1) == 4) transactions = "Diğer İşlemler";

                    li = historyListView.Items.Add(transactions);
                    li.SubItems.Add(sdr.GetInt32(0).ToString());
                    li.SubItems.Add(sdr.GetSqlDateTime(3).ToString());
                    li.SubItems.Add(sdr.GetString(2));
                }
                sdr.Close();
            }
            else {
                transactions = historyTypeDiscription(orderTransactionsType);

                SqlCommand fillHistoryListViewCommand = new SqlCommand("SELECT * FROM history WHERE historyType = @historyTypeId  ORDER BY historyId DESC", baglanti);
                fillHistoryListViewCommand.Parameters.AddWithValue("@historyTypeId", orderTransactionsType);
                SqlDataReader sdr = fillHistoryListViewCommand.ExecuteReader();
                ListViewItem li = new ListViewItem();

                while (sdr.Read())
                {
                    li = historyListView.Items.Add(transactions);
                    li.SubItems.Add(sdr.GetInt32(0).ToString());
                    li.SubItems.Add(sdr.GetSqlDateTime(3).ToString());
                    li.SubItems.Add(sdr.GetString(2));
                }
                sdr.Close();
            }
            
        }

        private void fillOrderTransactionsCombo()
        {
            SqlCommand fillOrderTransactionsComboCommand = new SqlCommand("SELECT * FROM historyType", baglanti);
            SqlDataReader sdr = fillOrderTransactionsComboCommand.ExecuteReader();
            while (sdr.Read()){
                orderTransactionsCombo.Items.Add(sdr["historyTypeDiscription"]);
            }
            sdr.Close();
        }

        private int historyTypeVal(string historyTypeDiscription)
        {
            int historyTypeVal = 0;
            SqlCommand historyTypeValCommand = new SqlCommand("SELECT * FROM historyType WHERE historyTypeDiscription = @historyTypeDiscription", baglanti);
            historyTypeValCommand.Parameters.AddWithValue("@historyTypeDiscription", historyTypeDiscription);
            SqlDataReader sdr = historyTypeValCommand.ExecuteReader();
            while (sdr.Read()){
                historyTypeVal = Convert.ToInt32(sdr["historyId"]);
            }
            sdr.Close();
            return historyTypeVal;
        }

        private string historyTypeDiscription(int historyTypeVal)
        {
            string historyTypeDis = "Hızlı İşlemler";
            if (historyTypeVal == 0) return historyTypeDis;

            SqlCommand historyTypeValCommand = new SqlCommand("SELECT * FROM historyType WHERE historyTypeId = @historyTypeId", baglanti);
            historyTypeValCommand.Parameters.AddWithValue("@historyTypeId", historyTypeVal);
            SqlDataReader sdr2 = historyTypeValCommand.ExecuteReader();

            while (sdr2.Read())
            {
                historyTypeDis = sdr2["historyTypeDiscription"].ToString();
            }
            sdr2.Close();
            return historyTypeDis;
        }

        private string findTransactionType(int transactionType)
        {
            string transactionName = "";
            SqlCommand findTransactionTypeCommand = new SqlCommand("SELECT * FROM historyType WHERE historyTypeId = @transactionType", baglanti);
            findTransactionTypeCommand.Parameters.AddWithValue("@transactionType", transactionType);
            SqlDataReader sdr = findTransactionTypeCommand.ExecuteReader();
            while (sdr.Read()){
                transactionName = sdr["historyTypeDiscription"].ToString();
            }
            sdr.Close();
            return transactionName;
        }

        private void allHistoryForm_Load(object sender, EventArgs e)
        {
            int historyButtonvAl = anasayfa.historyButttonVal;
            this.StyleManager = metroStyleManager1;
            theme = funcs.themeChanger(0);
            if (theme == "light"){
                metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Light;
                headerLabel.BackColor = Color.Transparent;
                headerLabel.ForeColor = Color.Black;
            }
            else {
                metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
                headerLabel.BackColor = Color.Transparent;
                headerLabel.ForeColor = Color.White;
            }

            if (funcs.isConnect(baglanti) == true){
                connectSituation.BackColor = Color.Lime;
                funcs.setToolTip(connectSituation, "Veri Tabanı Bağlantısı Var");
            }
            else{
                MetroFramework.MetroMessageBox.Show(this, "Veri Tabanı Bağlantısı Kurulamadığından Dolayı Program Kapatılıyor..", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            if (historyButtonvAl == 4)
            {
                orderTransactionsCombo.Visible = true;
                fillOrderTransactionsCombo();
                fillHistoryListViewColumn();
                orderTransactionsCombo.SelectedIndex = 0;
                fillHistoryListViewItems(orderTransactionsCombo.SelectedIndex);
            }
            else
            {
                headerLabel.Visible = false;
                this.Text += " " + findTransactionType(historyButtonvAl);
                orderTransactionsCombo.Visible = false;
                fillHistoryListViewColumn();
                fillHistoryListViewItems(historyButtonvAl);
            }

            DateTime date1 = DateTime.Now;
            DateTime date2 = DateTime.Now;
            date2.ToString("yyyy'/'MM'/'dd' 'HH':'mm':'ss");

            //MessageBox.Show(DateTime.Now.ToString("yyyy'/'MM'/'dd' 'HH':'mm':'ss"));
            //MessageBox.Show(DateTime.Now.ToString("dd'/'MM'/'yyyy' 'HH':'mm':'ss"));
            //MessageBox.Show(date1.ToString());
        }

        private void orderTransactionsCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillHistoryListViewItems(orderTransactionsCombo.SelectedIndex);
            headerLabel.Text = orderTransactionsCombo.Text;
        }

        private void historyListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (historyListView.SelectedItems.Count > 0)
            {
                selectedHistory = Convert.ToInt32(historyListView.SelectedItems[0].SubItems[1].Text);
                historyDetailForm historyDetailForm = new historyDetailForm();
                historyDetailForm.ShowDialog();
            }
        }
    }
}
