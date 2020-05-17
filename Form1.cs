using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM
{
    public partial class Main_menu_form : Form
    {
        public Main_menu_form()
        {
            InitializeComponent();
            // при запуске главного меню в первый раз, заполняем банкомат случайным количеством денег в рамках ограничений на количество купюр
            ATM.create_random_ATM_stock();
        }
        private void button_main_menu_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button_show_ATM_balance_form_Click(object sender, EventArgs e)
        {
            Hide();
            Show_balance_form balance_Form = new Show_balance_form();
            balance_Form.ShowDialog();
            this.Close();
        }
        private void button_money_withdrawal_Click(object sender, EventArgs e)
        {
            Hide();
            Cash_withdrawal_form cash_Withdrawal_Form = new Cash_withdrawal_form();
            cash_Withdrawal_Form.ShowDialog();
            this.Close();
        }

        private void button_money_replenishment_Click(object sender, EventArgs e)
        {
            Hide();
            Cash_replenishment cash_Replenishment_Form = new Cash_replenishment();
            cash_Replenishment_Form.ShowDialog();
            this.Close();
        }
    }
}
