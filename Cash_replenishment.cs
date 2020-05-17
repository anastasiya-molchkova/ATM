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
        // массив текстовых полей для ввода количеств купюр для каждого номинала:
        public TextBox[] textbox_array = new TextBox[Convert.ToInt32(Banknote_values.how_many_banknotes_values)];
        public Cash_replenishment()
        {
            InitializeComponent();
            // создаём текстовые поля для ввода количеств купюр для каждого номинала:
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
        
        private void button_replenishment_Click(object sender, EventArgs e)
        {
            uint number_to_replenish = 0;                    // общее количество купюр для пополнения 
            bool everything_is_ok = true;
            for (int i = 0; i < textbox_array.Length; i++)   // идём по всем номиналам купюр
            {
                try
                {
                    uint quantity_for_value = 0;
                    if (textbox_array[i].Text != "")          // если поле пустое - оставляем ноль, иначе ловит ошибку
                        // здесь могут быть и буквы, поэтому это всё происходит под try:
                        quantity_for_value = Convert.ToUInt32(textbox_array[i].Text);
                    if (quantity_for_value < 0 )              // отрицательное значение - тоже плохо
                    {
                        everything_is_ok = false;
                        label_what_to_do.Text = "Количества не могут быть отрицательными!";
                    }
                    number_to_replenish += quantity_for_value; // количество купюр увеличиваем на значение из поля
                    // проверяем, не превысит ли количество вносимых купюр установленное максимально возможное:
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
                if (!everything_is_ok) break;  // если на каком-то поле некорректное значение или перебор по купюрам, обрываем проверку
            }

            if (!everything_is_ok)
            {
                // красим строку сигнальным цветом, чтобы пользователь увидел, что надо исправить
                label_what_to_do.ForeColor = Color.Yellow;
            }

            else // everything_is_ok
            {
                uint summ_of_replenishment = 0;                  // считаем общую сумму, на которую пополняем
                var value = Banknote_values.ten_rubles;
                for (int i = 0; i < textbox_array.Length; i++)   // опять идём по всем номиналам, полям для количеств
                {
                    textbox_array[i].Visible = false;            // выше было проверено, что всё ок, поэтому поля для ввода количеств больше не нужны
                    uint quantity_for_value = 0;                 // количество для пополнения определённого номинала
                    if (textbox_array[i].Text != "")             // иначе не сможем конвертировать пустоту в число
                        quantity_for_value = Convert.ToUInt32(textbox_array[i].Text);
                    ATM.replenish_banknote(Banknote.get_banknote_value_by_text(value), quantity_for_value);
                    summ_of_replenishment += (Banknote.get_banknote_value_by_text(value) * quantity_for_value);
                    value++;
                }
                // показываем результат, прячем лишнее
                label_what_to_do.Text = "Успешно внесена сумма: " + summ_of_replenishment;
                label_what_to_do.ForeColor = Color.MediumSpringGreen;

                button_replenishment.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
            }
        }
    }
}
