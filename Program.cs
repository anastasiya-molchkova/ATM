using System;
using System.Collections.Generic;       // для использования списков
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM
{
    // принимаемые номиналы банкнот, последнее значение будет хранить количество номиналов:
    enum Banknote_values 
    { ten_rubles, fifty_rubles, one_hundred_rubles, two_hundred_rubles, 
        five_hundred_rubles, one_thousand_rubles, two_thousand_rubles, five_thousand_rubles, 
        how_many_banknotes_values
    };

    // Класс банкнота - по сути пачка купюр одного достоинства, хранит номинал купюры и количество купюр с таким номиналом:
    class Banknote
    {
        private uint value;                             // достоинство (номинал)
        private uint number;                            // количество
        public Banknote(uint value, uint quantity)      // конструктор класса
        {
            this.value = value;
            this.number = quantity;
        }
        public void add_banknotes(uint quantity_to_add) // добавляем заданное количество
        {
            this.number += quantity_to_add;
        }
        public void substract_banknote()                // убираем одну купюру
        {
            this.number--;
        }
        public uint get_banknote_value()                // геттер - получаем номинал купюры
        {
            return this.value;
        }
        public uint get_banknote_quantity()             // геттер - получаем количество купюр
        {
            return this.number;
        }
        public uint get_summ()                          // геттер - получаем количество денег из банкнот одного достоинства
        {
            return this.value*this.number;
        }
        // статический метод (используем без создания объекта) для получения номинала по значению из перечисления кпюр
        public static uint get_banknote_value_by_text(Banknote_values some_banknote)
        {
            switch (some_banknote)
            {
                case Banknote_values.ten_rubles: return 10;
                case Banknote_values.fifty_rubles: return 50;
                case Banknote_values.one_hundred_rubles: return 100;
                case Banknote_values.two_hundred_rubles: return 200;
                case Banknote_values.five_hundred_rubles: return 500;
                case Banknote_values.one_thousand_rubles: return 1000;
                case Banknote_values.two_thousand_rubles: return 2000;
                case Banknote_values.five_thousand_rubles: return 5000;
                default: return 0;
            }
        }
    }

    // статический Класс Банкомат, хранит купюры разного достоинства, пополняет запасы, выдаёт сумму по запросу
    static class ATM
    {
        // ПЕРЕМЕННЫЕ-ЧЛЕНЫ:
        // переменная для сокращения количества номиналов купюр:
        private static uint number_of_banknotes_values = Convert.ToUInt32(Banknote_values.how_many_banknotes_values);
        // ограничение - максимальное количество купюр в банкомате:
        private const uint max_banknotes_number = 200;
        // массив для хранения данных о запасах купюр (номинал-количество) в банкомате:
        private static List<Banknote> banknotes_stock = new List<Banknote> { };
        
        // МЕТОДЫ:
        // наполняем банкомат случайным образом, не выходя за рамки ограничений:
        public static void create_random_ATM_stock()
        {
            Random random_number = new Random();
            var banknote_value = Banknote_values.ten_rubles; // здесь немного корявый момент, по сути это должно быть первое значение из перечисления, но как к нему обратиться я не знаю 
            do
            {
                // делим максимальное количество купюр на количество номиналов, этим будем ограничивать случайное количество:
                uint random_quantity = Convert.ToUInt32(random_number.Next()) %
                                      (max_banknotes_number / number_of_banknotes_values);
                Banknote next_banknote = new Banknote(Banknote.get_banknote_value_by_text(banknote_value), random_quantity);
                // добавляем новую стопку купюр одного номинала в запас банкомата, даже если их 0:
                banknotes_stock.Add(next_banknote);
                banknote_value++;                                                  // переходим к следующему номиналу
            } while (banknote_value < Banknote_values.how_many_banknotes_values);  // перебираем все номиналы
        }

        // получаем общее количество денег в банкомате:
        public static uint how_much_money()
        {
            uint summ = 0;
            for (var i = 0; i < number_of_banknotes_values; ++i)
                summ += banknotes_stock[i].get_summ();
            return summ;
        }
        // получаем общее количество купюр в банкомате:
        public static uint how_many_banknotes()
        {
            uint summ = 0;
            for (var i = 0; i < number_of_banknotes_values; ++i)
                summ += banknotes_stock[i].get_banknote_quantity();
            return summ;
        }
        // получаем максимальное количество купюр в банкомате:
        public static uint get_maximum_banknotes_number()
        {
            return max_banknotes_number;
        }
        // получаем информацию о запасах банкомата по каждому номиналу в виде текста:
        public static String get_information_about_banknotes_in_ATM()
        {
            string info = "";
            for (var i = 0; i < number_of_banknotes_values; ++i)
            {
                info += Convert.ToString(banknotes_stock[i].get_banknote_value());
                info += "р. - ";
                info += Convert.ToString(banknotes_stock[i].get_banknote_quantity());
                info += " шт.  ";
                if (i % 2 == 1) info += "\n";
            }
            return info;
        }
        // получаем имеющееся количество купюр определённого номинала:
        public static uint how_many_banknotes_of(Banknote_values banknote_value)
        {
            return banknotes_stock[Convert.ToInt32(banknote_value)].get_banknote_quantity();
        }
        // пополняем купюру заданного номинала:
        public static void replenish_banknote(uint value, uint quantity_to_add)
        {
            var i = 0;
            while (i < number_of_banknotes_values)
            {
                if (banknotes_stock[i].get_banknote_value() == value)
                {
                    banknotes_stock[i].add_banknotes(quantity_to_add);
                    break;
                }
                i++;
            }
        }
        // снимаем с банкомата купюру заданного номинала:
        public static void withdraw_banknote(uint value)
        {
            var i = 0;
            while (i < number_of_banknotes_values)
            {
                if (banknotes_stock[i].get_banknote_value() == value)
                {
                    banknotes_stock[i].substract_banknote();
                    break;
                }
                i++;
            }
        }
    }
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main_menu_form());

        }
    }
}
