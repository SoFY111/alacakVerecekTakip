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
    public partial class inComingMoneyForm : MetroFramework.Forms.MetroForm
    {
        public inComingMoneyForm()
        {
            InitializeComponent();
        }

        methods funcs = new methods();
        SqlConnection baglanti = methods.baglanti;
        string theme;

        private void fillCustomerNameAndSurnameCombo()
        {
            SqlCommand fillCustomerNameAndSurnameComboCommand = new SqlCommand("SELECT * FROM customers ORDER BY customerName", baglanti);
            SqlDataReader sdr = fillCustomerNameAndSurnameComboCommand.ExecuteReader();
            while (sdr.Read())
            {
                customerNameAndSurnameCombo.Items.Add(sdr["customerName"].ToString() + " " + sdr["customerSurname"].ToString());
            }
            sdr.Close();
            customerNameAndSurnameCombo.SelectedIndex = 0;
        }

        private void fillCustomerDebtListCombo(string customerNameAndSurname)
        {
            customerDebtListCombo.Items.Clear();
            string[] customerNameAndSurnameDetail = customerNameAndSurname.Split(' ');
            int customerId = findCustomerId(customerNameAndSurnameDetail[0], customerNameAndSurnameDetail[1]);
            string[] customerDebtorTable = findCustomersDebtorTable(customerId), customerMyDebtTable = findCustomersMyDebtTable(customerId);

            SqlCommand findCustomerTransactionsCommand = new SqlCommand("SELECT * FROM customersTransactionType WHERE customerId = @customerId", baglanti);
            findCustomerTransactionsCommand.Parameters.AddWithValue("@customerId", customerId);
            SqlDataReader sdr = findCustomerTransactionsCommand.ExecuteReader();
            while (sdr.Read())
            {
                for (int i = 0; i < customerDebtorTable.Length; i++)
                {
                    string[] customerDebtorTableDetail = customerDebtorTable[i].Split('-');
                    if (Convert.ToInt32(customerDebtorTableDetail[2]) == Convert.ToInt32(sdr["customerTransactionTypeId"])){
                        customerDebtListCombo.Items.Add(sdr["customerTransactionTypeId"].ToString() + "-" + customerDebtorTableDetail[4] + "-" + sdr["transactionDate"].ToString());
                    }
                }

                for (int i = 0; i < customerMyDebtTable.Length; i++)
                {
                    string[] customerMyDebtTableDetail = customerMyDebtTable[i].Split('-');
                    if (Convert.ToInt32(customerMyDebtTableDetail[2]) == Convert.ToInt32(sdr["customerTransactionTypeId"]))
                    {
                        customerDebtListCombo.Items.Add(sdr["customerTransactionTypeId"].ToString() + "-" + customerMyDebtTableDetail[4] + "-" + sdr["transactionDate"].ToString());
                    }
                }
            }
            sdr.Close();
        }

        private int findCustomerId(string customerName, string customerSurname)
        {
            int customerId = 0;
            SqlCommand findCustomerIdCommand = new SqlCommand("SELECT * FROM customers WHERE customerName = @customerName AND customerSurname = @customerSurname", baglanti);
            findCustomerIdCommand.Parameters.AddWithValue("@customerName", customerName);
            findCustomerIdCommand.Parameters.AddWithValue("@customerSurname", customerSurname);
            SqlDataReader sdr = findCustomerIdCommand.ExecuteReader();
            while (sdr.Read())
            {
                customerId = Convert.ToInt32(sdr["customerId"]);
            }
            sdr.Close();
            return customerId;
        }

        private string[] findCustomersDebtorTable(int customerId)
        {
            int customersTableRowCount = customersDebtorTableRowCount(customerId), customersTableRowCount2 = 0;
            string[] customersDebtorTable = new string[customersTableRowCount];

            SqlCommand findCustomerDebtValTableCommand = new SqlCommand("SELECT * FROM customersDebtor WHERE customerId = @customerId", baglanti);
            findCustomerDebtValTableCommand.Parameters.AddWithValue("@customerId", customerId);
            SqlDataReader sdr = findCustomerDebtValTableCommand.ExecuteReader();
            while (sdr.Read())
            {
                if (customersTableRowCount2 <= customersTableRowCount)
                {
                    customersDebtorTable[customersTableRowCount2] = sdr["debtorId"].ToString() + "-" + sdr["customerId"].ToString() + "-" + sdr["transactionTypeId"].ToString() + "-" + sdr["debtType"].ToString() + "-" + sdr["debtVal"].ToString() + "-" + sdr["debtMoneyTypeId"].ToString() + "-" + sdr["debtBankTypeId"].ToString() + "-" + sdr["debtDate"].ToString() + "-" + sdr["debtPaymentDate"].ToString();
                    customersTableRowCount2++;
                }
            }
            sdr.Close();
            return customersDebtorTable;
        }



        private int customersDebtorTableRowCount( int customerId)
        {
            int rowCount = 0;
            SqlCommand rowCountCommand = new SqlCommand("SELECT * FROM customersDebtor WHERE customerId = @customerId", baglanti);
            rowCountCommand.Parameters.AddWithValue("@customerId", customerId);
            SqlDataReader sdr = rowCountCommand.ExecuteReader();
            while (sdr.Read())
            {
                rowCount++;
            }
            sdr.Close();
            return rowCount;
        }

        private string[] findCustomersMyDebtTable(int customerId)
        {
            int customersTableRowCount = customersMyDebtTableRowCount(customerId), customersTableRowCount2 = 0;
            string[] customersDebtorTable = new string[customersTableRowCount];

            SqlCommand findCustomerDebtValTableCommand = new SqlCommand("SELECT * FROM customersMyDebt WHERE customerId = @customerId", baglanti);
            findCustomerDebtValTableCommand.Parameters.AddWithValue("@customerId", customerId);
            SqlDataReader sdr = findCustomerDebtValTableCommand.ExecuteReader();
            while (sdr.Read())
            {
                if (customersTableRowCount2 <= customersTableRowCount)
                {
                    customersDebtorTable[customersTableRowCount2] = sdr["myDebtId"].ToString() + "-" + sdr["customerId"].ToString() + "-" + sdr["transactionTypeId"].ToString() + "-" + sdr["debtType"].ToString() + "-" + sdr["debtVal"].ToString() + "-" + sdr["debtMoneyTypeId"].ToString() + "-" + sdr["debtBankTypeId"].ToString() + "-" + sdr["debtDate"].ToString() + "-" + sdr["debtPaymentDate"].ToString();
                    customersTableRowCount2++;
                }
            }
            sdr.Close();
            return customersDebtorTable;
        }



        private int customersMyDebtTableRowCount(int customerId)
        {
            int rowCount = 0;
            SqlCommand rowCountCommand = new SqlCommand("SELECT * FROM customersMyDebt WHERE customerId = @customerId", baglanti);
            rowCountCommand.Parameters.AddWithValue("@customerId", customerId);
            SqlDataReader sdr = rowCountCommand.ExecuteReader();
            while (sdr.Read())
            {
                rowCount++;
            }
            sdr.Close();
            return rowCount;
        }


        private void inComingMoneyForm_Load(object sender, EventArgs e)
        {
            this.StyleManager = metroStyleManager1;
            theme = funcs.themeChanger(0);

            if (theme == "light") metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Light;
            else metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            if (funcs.isConnect(baglanti) == true) { }
            else{
                MetroFramework.MetroMessageBox.Show(this, "Veri Tabanı Bağlantısı Kurulamadığından Dolayı Program Kapatılıyor..", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            if (funcs.isConnect(baglanti) == true){
                connectSituation.BackColor = Color.Lime;
                funcs.setToolTip(connectSituation, "Veri Tabanı Bağlantısı Var");
            }
            else{
                MetroFramework.MetroMessageBox.Show(this, "Veri Tabanı Bağlantısı Kurulamadığından Dolayı Program Kapatılıyor..", "BİLGİ!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            if (metroStyleManager1.Theme == MetroFramework.MetroThemeStyle.Dark){
                helpPictureBox.Image = alacakVerecekTakip.Properties.Resources.helpWhite;
            }
            else{
                helpPictureBox.Image = alacakVerecekTakip.Properties.Resources.help;
            }


            fillCustomerNameAndSurnameCombo();
        }

        private void customerNameAndSurnameCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillCustomerDebtListCombo(customerNameAndSurnameCombo.Text);
        }
    }
}
