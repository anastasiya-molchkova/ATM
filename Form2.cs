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
    public partial class Show_balance_form : Form
    {
        public Show_balance_form()
        {
            InitializeComponent();

            // считаем баланс банкомата в деньгах, превращаем в строку, отображаем:
            uint ATM_balanсe = ATM.how_much_money();
            string ATM_balance_with_space = (Convert.ToString(ATM_balanсe / 1000)=="0")?"": Convert.ToString(ATM_balanсe / 1000);
            ATM_balance_with_space += " ";
            if (ATM_balanсe % 1000 < 10) 
                ATM_balance_with_space += "0";
            if (ATM_balanсe % 1000 < 100)
                ATM_balance_with_space += "0";
            ATM_balance_with_space += Convert.ToString(ATM_balanсe % 1000);
            label_ATM_balance.Text = ATM_balance_with_space;

            // отображаем общее количество купюр:
            label_bankonotes_number.Text = Convert.ToString(ATM.how_many_banknotes());
            // отображаем максимальное количество купюр:
            label_max_banknotes.Text = "из " + Convert.ToString(ATM.get_maximum_banknotes_number());
            // показываем информацию по купюре каждого достоинства:
            label_info_by_banknotes_values.Text = ATM.get_information_about_banknotes_in_ATM();
        }
        
        private void Back_to_main_menu_Click(object sender, EventArgs e)
        {
            Hide();
            Main_menu_form main_Menu = new Main_menu_form();
            main_Menu.ShowDialog();
            this.Close();
        }

        private void Cancel_from_balance_menu_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
