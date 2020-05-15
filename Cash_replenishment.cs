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
    public partial class Cash_replenishment : Form
    {
        public TextBox[] textbox_array = new TextBox[Convert.ToInt32(Banknote_values.how_many_banknotes_values)];
        public Cash_replenishment()
        {
            InitializeComponent();
            for (int i = 0; i < textbox_array.Length; i++)
            {
                textbox_array[i] = new TextBox();
                textbox_array[i].Location = new Point(115, 50 + 40 * i);
                textbox_array[i].Size = new Size(60, 30);
                textbox_array[i].Tag = i;
                textbox_array[i].Text = "";
                Controls.Add(textbox_array[i]);
            }
        }
        private void button_back_to_menu_Click(object sender, EventArgs e)
        {
            Hide();
            Main_menu_form main_Menu = new Main_menu_form();
            main_Menu.ShowDialog();
            this.Close();
        }

        private void button_check_balance_Click(object sender, EventArgs e)
        {
            Hide();
            Show_balance_form balance_Form = new Show_balance_form();
            balance_Form.ShowDialog();
            this.Close();
        }

        private void Cash_replenishment_Load(object sender, EventArgs e)
        {
        }
        
        private void button_replenishment_Click(object sender, EventArgs e)
        {
            uint number_to_replenish = 0;
            bool everything_is_ok = true;
            for (int i = 0; i < textbox_array.Length; i++)
            {
                try
                {
                    uint quantity_for_value = 0;
                    if (textbox_array[i].Text != "")
                        quantity_for_value = Convert.ToUInt32(textbox_array[i].Text);
                    if (quantity_for_value < 0 )
                    {
                        everything_is_ok = false;
                        label_what_to_do.Text = "Количества не могут быть отрицательными!";
                    }
                    number_to_replenish += quantity_for_value;
                    if ((number_to_replenish + ATM.how_many_banknotes()) > ATM.get_maximum_banknotes_number())
                    {
                        everything_is_ok = false;
                        label_what_to_do.Text = "Ограничение! Общее количество не должно превышать "
                                          + (ATM.get_maximum_banknotes_number() - ATM.how_many_banknotes());
                    }
                }
                catch
                {
                      everything_is_ok = false;
                      label_what_to_do.Text = "Введены некорректные количества, введите корректные:";
                }
                if (!everything_is_ok) break;
            }

            if (!everything_is_ok)
            {
                label_what_to_do.ForeColor = Color.Yellow;
            }

            else // everything_is_ok
            {
                uint summ_of_replenishment = 0;
                var value = Banknote_values.ten_rubles;
                for (int i = 0; i < textbox_array.Length; i++)
                {
                    textbox_array[i].Visible = false;
                    uint quantity_for_value = 0;
                    if (textbox_array[i].Text != "")
                        quantity_for_value = Convert.ToUInt32(textbox_array[i].Text);
                    ATM.replenish_banknote(Banknote.get_banknote_value_by_text(value), quantity_for_value);
                    summ_of_replenishment += (Banknote.get_banknote_value_by_text(value) * quantity_for_value);
                    value++;
                }    
                label_what_to_do.Text = "Успешно внесена сумма: " + summ_of_replenishment;
                label_what_to_do.ForeColor = Color.MediumSpringGreen;
            }
        }
    }
}
