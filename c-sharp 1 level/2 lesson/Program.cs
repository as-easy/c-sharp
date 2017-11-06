using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lesson
{

    class Program
    {
        static void Main()
        {
            //Task_4();
            //Task_5();
            //Task_6();
            Task_7();
        }

        /// <summary>
        /// Задание 4. Реализовать метод проверки логина и пароля. 
        /// Логин:root, Password:GeekBrains.  Проверка в методе Task_4_Authorization().
        /// Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает.
        /// С помощью цикла do while ограничить ввод пароля тремя попытками.
        /// </summary>
        static void Task_4()
        {
            Console.WriteLine("4 задание. Проверка логина и пароля");
            Console.WriteLine("\nДля продолжения нажмите любую клавишу...");
            Console.ReadKey();
            
            int i = 0;
            string s1, s2;

            do
            {
                Console.Clear();

                Console.Write("Введите логин:");
                s1 = Console.ReadLine();

                Console.Write("Введите пароль:");
                s2 = Console.ReadLine();                

                if (Task_4_Authorization(s1, s2))
                {
                    Console.WriteLine("\nВы ввели правильный логин и пароль!");
                    Console.WriteLine("\nДля перехода к следующему заданию нажмите любую клавишу...");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    switch (i)
                    {
                        case 0:
                            Console.WriteLine("\nЛогин или пароль неверен. Введите логин и пароль еще раз. Осталось 2 попытки");
                            Console.ReadKey();
                            break;

                        case 1:
                            Console.WriteLine("\nЛогин или пароль неверен. Введите логин и пароль еще раз. Осталось 1 попытка");
                            Console.ReadKey();
                            break;

                        default:
                            Console.WriteLine("\nПревышен лимит попыток!");
                            Console.WriteLine("\nДля перехода к следующему заданию нажмите любую клавишу...");
                            Console.ReadKey();
                            break;
                    }
                }

                i++;

            } while (i <= 2);
        }

        static bool Task_4_Authorization(string s1, string s2)
        {
            return (s1 == "root" && s2 == "GeekBrains") ? true : false;
        }

        /// <summary>
        /// Задание 5. Проверка массы человека. 
        /// Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы (кг/м2) и сообщает, нужно ли человеку похудеть, набрать вес или все в норме;
        /// б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.
        /// менее 18,5 - Дефицит вес
        /// 18,5—24,99 - Норма
        /// 25 и более - Избыточная масса тела(предожирение)
        /// </summary>
        static void Task_5()
        {
            Console.WriteLine("5 задание. Вычисление индекса массы тела.");
            Console.WriteLine("\nДля продолжения нажмите любую клавишу...");
            Console.ReadKey();
            Console.Clear();
            
            double wt, ht, wttemp, index;      

            Console.Write("Введите ваш вес в кг через запятую (прим. 45,5):");
            wt = double.Parse(Console.ReadLine());
            
            Console.Write("Введите ваш рост в метрах через запятую (прим. 1,76):");
            ht = double.Parse(Console.ReadLine());

            index = wt / (ht * ht);
            
            if(index<18.5)
            {
                wttemp = 18.5 * (ht * ht);
                Console.WriteLine($"\nВаш индекс {index:0.0}, что означает дефицит веса. Норма с 18.5 до 24,99. \nДо нижнего порога нормы Вам необходимо набрать {wttemp - wt:0.0} кг.");
                Console.WriteLine("\nДля перехода к следующему заданию нажмите любую клавишу...");
                Console.ReadKey();
            }
            else if(index>=25)
            {
                wttemp = 24.99 * (ht * ht);
                Console.WriteLine($"\nВаш индекс {index:0.0}, что означает избыток веса. Норма с 18.5 до 24,99. \nДо верхнего порога нормы Вам необходимо сбросить {wt - wttemp:0.0} кг.");
                Console.WriteLine("\nДля перехода к следующему заданию нажмите любую клавишу...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"\nДа, нормальный у Вас вес. Ваш индекс {index:0.0}.");
                Console.WriteLine("\nДля перехода к следующему заданию нажмите любую клавишу...");
                Console.ReadKey();
            }
        }
        /// <summary>
        /// Задание 6. Написать программу подсчета количества “Хороших” чисел в диапазоне от 1 до 1 000 000 000. 
        /// Хорошим называется число, которое делится на сумму своих цифр. 
        /// Реализовать подсчет времени выполнения программы, используя структуру DateTime.
        /// 
        /// </summary>
        static void Task_6()
        {
            Console.WriteLine("6 задание. Подсчет \"Хороших\" чисел.");
            Console.WriteLine("\nДля продолжения нажмите любую клавишу...");
            Console.ReadKey();
            Console.Clear();

            int sum = 0, count =0;
            int num, numtemp;
            DateTime start = DateTime.Now;
            for (num = 1; num <= 1_000_000_000; num++) //1_000_000_000 - около 5 минут
            {
                numtemp = num;

                do
                {
                    sum = sum + (numtemp - ((int)(numtemp / 10)) * 10);
                    numtemp = numtemp / 10;

                } while (numtemp != 0);
                
                if (num % sum == 0)
                {
                    count++;
                }

                sum = 0;

            }

            DateTime finish = DateTime.Now;
            Console.WriteLine($"\nКоличество \"Хороших\" чисел: {count}");
            Console.WriteLine($"\nПодсчет длился: {finish - start}");
            Console.WriteLine("\nДля перехода к следующему заданию нажмите любую клавишу...");
            Console.ReadKey();
        }


    }
}
