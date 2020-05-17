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
    public partial class Cash_withdrawal_form : Form
    {
        public Cash_withdrawal_form()
        {
            InitializeComponent();
        }

        private void button_show_balance_Click(object sender, EventArgs e)
        {
            Hide();
            Show_balance_form balance_Form = new Show_balance_form();
            balance_Form.ShowDialog();
            this.Close();
        }

        private void button_back_to_main_menu_Click(object sender, EventArgs e)
        {
            Hide();
            Main_menu_form main_Menu = new Main_menu_form();
            main_Menu.ShowDialog();
            this.Close();
        }
        // функция принимает истину или ложь, чтобы перейти к следующему этапу формы и наоборот
        private void change_form_to_enter_summ(bool hide_initial_buttons)
        {
            // скрываем или показываем кнопки с конкретными суммами:
            button1000.Visible = !hide_initial_buttons;
            button2000.Visible = !hide_initial_buttons;
            button5000.Visible = !hide_initial_buttons;
            button10000.Visible = !hide_initial_buttons;
            button15000.Visible = !hide_initial_buttons;
            button_other_amount.Visible = !hide_initial_buttons;

            // скрываем или показываем поле для суммы и кнопки для выдачи денег:
            textBox_for_summ.Visible = hide_initial_buttons;
            button_by_small_value.Visible = hide_initial_buttons;
            button_by_large_value.Visible = hide_initial_buttons;
        }
        private void button1000_Click(object sender, EventArgs e)
        {
            change_form_to_enter_summ(true);
            textBox_for_summ.Text = "1000";
        }

        private void button2000_Click(object sender, EventArgs e)
        {
            change_form_to_enter_summ(true);
            textBox_for_summ.Text = "2000";
        }

        private void button5000_Click(object sender, EventArgs e)
        {
            change_form_to_enter_summ(true);
            textBox_for_summ.Text = "5000";
        }

        private void button10000_Click(object sender, EventArgs e)
        {
            change_form_to_enter_summ(true);
            textBox_for_summ.Text = "10000";
        }

        private void button15000_Click(object sender, EventArgs e)
        {
            change_form_to_enter_summ(true);
            textBox_for_summ.Text = "15000";
        }

        private void button_other_amount_Click(object sender, EventArgs e)
        {
            change_form_to_enter_summ(true);
        }

        private void button_by_large_value_Click(object sender, EventArgs e)
        {
            if (check_and_withdrawal(true) == false)
                label_no_result.Visible = true;
        }

        private void button_by_small_value_Click(object sender, EventArgs e)
        {
            if (check_and_withdrawal(false) == false)
                label_no_result.Visible = true;
        }

        // в этом векторе будем хранить номиналы купюр, которыми производим выдачу, они могут повторяться, т.к. тут нет количеств:
        private List<uint> try_to_withdraw = new List<uint> { };

        // создаём массив купюр, в который скопируем запасы банкомата для симуляции попытки выдачи средств:
        private static List<Banknote> banknotes_stock_for_check = new List<Banknote> { };

        // получаем максимальный номинал из перечисления, который есть в запасах и который меньше указанной суммы:
        private static Banknote_values max_available_value_less_than(uint summ, Banknote_values max_value)
        {
            var banknote_value = ((max_value == Banknote_values.how_many_banknotes_values)? max_value-1 : max_value);  
            while ((Banknote.get_banknote_value_by_text(banknote_value) > summ)
                || (banknotes_stock_for_check[Convert.ToInt32(banknote_value)].get_banknote_quantity() == 0))
            {
                if (banknote_value == Banknote_values.ten_rubles)
                    break;
                // переходим к более низкому номиналу, пока номинал превышает сумму или в нулевом количестве
                banknote_value--;

            }
            return banknote_value;
        }
        // получаем минимальный доступный номинал:
        private static Banknote_values min_available_value()
        {
            var banknote_value = Banknote_values.ten_rubles;
            while (ATM.how_many_banknotes_of(banknote_value) == 0)
                banknote_value++;
            return banknote_value;
        }

        // функция проверяет, можем ли мы выдать заданную сумму и заполняет массив купюр (достоинство-количество),
        // которыми можно выдать. Возвращает истину, если всё получилось и ложь - если нет.
        private bool check_and_withdrawal(bool by_large_values)
        {
            label_no_result.Visible = false;
            uint users_wish = 0; // в этой переменной будем хранить сумму, которую хочет получить пользователь

            // СНАЧАЛА ПРОВЕРЯЕМ, НОРМАЛЬНУЮ ЛИ СУММУ ХОЧЕТ ПОЛЬЗОВАТЕЛЬ
            try
            {
                // пытаемся получить сумму из окошка для неё, если там не число - ловим ошибку
                users_wish = Convert.ToUInt32(textBox_for_summ.Text);
            }
            catch
            {
                MessageBox.Show("Запрашиваемая сумма не корректна!");
            }
            if (users_wish == 0)
            // 0 - нормальное число, но не в данном случае
            {
                label_no_result.Text = "Введите ненулевую и недробную сумму";
                return false;
            }
            // если пользователь хочет больше, чем есть - тоже сразу нет:
            uint ATM_balanсe = ATM.how_much_money();
            if (users_wish > ATM_balanсe)
            {
                label_no_result.Text = "В банкомате нет столько денег!\nПроверьте баланс и попробуйте ввести сумму меньше.";
                return false;
            }
            // если пользователь хочет более мелкие деньги, чем есть, то тоже нет:
            if (users_wish % Banknote.get_banknote_value_by_text(min_available_value()) != 0)
            {
                label_no_result.Text = "Минимальная доступная купюра: ";
                label_no_result.Text += Banknote.get_banknote_value_by_text(min_available_value());
                label_no_result.Text += "р. Скорректируйте сумму для выдачи с учётом этого.";
                return false;
            }

            // для каждой транзакции будем заполнять массив с проверочными остатками заново:
            banknotes_stock_for_check.Clear();

            // пара сокращений:
            Banknote_values min_value = Banknote_values.ten_rubles;
            Banknote_values max_value = Banknote_values.how_many_banknotes_values;

            if (by_large_values) // нужна выдача крупными купюрами, о мелких не беспокоимся, просто копируем данные
                for (var value = min_value; value < max_value; value++)
                {
                    Banknote next_banknote = new Banknote(Banknote.get_banknote_value_by_text(value), ATM.how_many_banknotes_of(value));
                    banknotes_stock_for_check.Add(next_banknote);
                }
            else // нужна выдача мелкими купюрами, тут код подлиннее, чтобы сразу понять, какими купюрами можем обойтись
            {
                // изначально полагаем максимальную мелкую купюру равной 200р
                Banknote_values max_small_value = Banknote_values.two_hundred_rubles;
                uint summ_of_small_values = 0; // будем считать сумму, которую можем выдать мелкими купюрами

                // копируем остатки банкомата в массив для проверки выдачи суммы, считаем сумму мелких купюр:
                for (var value = min_value; value < max_value; value++)
                {
                    Banknote next_banknote = new Banknote(Banknote.get_banknote_value_by_text(value), ATM.how_many_banknotes_of(value));
                    banknotes_stock_for_check.Add(next_banknote);
                    if (value <= max_small_value)
                    {
                        summ_of_small_values += next_banknote.get_summ();
                        // если посчитали всю сумму мелкими купюрами, и её не хватает, то добавляем к мелким следующую купюру
                        if ((value == max_small_value) && (summ_of_small_values < users_wish))
                            max_small_value++;  // мы не будем проверять здесь, что значение выйдет за предел диапазона, т.к. уже проверили, что всех денег банкомата для суммы хватит
                    }
                }
                max_value = max_small_value;  // ограничиваем максимальный номинал максимальной мелкой купюрой, которой хватит для выдачи суммы мелкими купюрами
            }

            // очистим массив снимаемых купюр, будем пополнять его по мере набора желаемой суммы
            try_to_withdraw.Clear();

            // сумма, которую снимаем:
            uint total_summ_to_withdraw = 0;

            // ЖАДНЫЙ АЛГОРИТМ, подбираем купюры для выдачи начиная с самой крупной подходящей:
            while (users_wish > 0) // будем уменьшать это значение по мере подбора банкнот
            {
                // идём от наиболее больших сумм, это же проверка, так мы быстрее наберём нужную сумму
                Banknote_values max_enum_value = max_available_value_less_than(users_wish, max_value);
                var max_available_banknote_value = Banknote.get_banknote_value_by_text(max_enum_value);

                // максимально "доступный" номинал по факту может оказаться и не доступным:
                if (banknotes_stock_for_check[Convert.ToInt32(max_enum_value)].get_banknote_quantity() == 0)
                {
                    // тогда мы не можем эту купюру использовать и набор суммы завершён
                    label_no_result.Text = "Не удаётся набрать запрашиваемую сумму, не хватает каких-то купюр.\n";
                    label_no_result.Text += "Попробуйте ввести сумму ";
                    label_no_result.Text += Convert.ToString(total_summ_to_withdraw);
                    // очистим уже частично заполненный массив снимаемых купюр:
                    try_to_withdraw.Clear();
                    return false;           // проверка окончена
                }
                // ИНАЧЕ продолжаем, добавляем купюру в список для снятия:
                banknotes_stock_for_check[Convert.ToInt32(max_enum_value)].substract_banknote();
                try_to_withdraw.Add(max_available_banknote_value);
                total_summ_to_withdraw += max_available_banknote_value;
                users_wish -= max_available_banknote_value;
            }
            // дошли до сюда, значит набрали всю сумму

            // скрываем кнопки и поле для суммы, готовим текст о результате
            textBox_for_summ.Visible = false;
            button_by_small_value.Visible = false;
            button_by_large_value.Visible = false;
            
            // снимаем все подобранные банкноты по очереди, и печатаем их неповторяющиеся номиналы
            var used_banknote = try_to_withdraw[0];   // это для печати, сохраняем номинал первой банкноты на выдачу
            var number_of_used_banknotes = 0;         // это тоже для печати
            string info_about_banknotes = "\nиспользованы купюры:\n" + used_banknote;
            foreach (var value in try_to_withdraw)
            {
                ATM.withdraw_banknote(value);
                if (value != used_banknote)           // показываем количество для выданной купюры
                {
                    info_about_banknotes += " x " + number_of_used_banknotes + '\n' + value;
                    used_banknote = value;            // начинаем рассматривать следующую
                    number_of_used_banknotes = 0;
                }
                number_of_used_banknotes++;
            }
            info_about_banknotes += " x " + number_of_used_banknotes;   // добавляем информацию о количестве последней выданной купюры

            label_for_positive_result.Text = "ВЫДАНА СУММА " + total_summ_to_withdraw;
            label_for_positive_result.Text += info_about_banknotes;
            label_for_positive_result.Visible = true;

            return true;
        }
    }
}
