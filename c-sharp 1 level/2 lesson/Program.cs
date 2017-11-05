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
            Task_4();
        }

        /// <summary>
        /// Задание 4. Реализовать метод проверки логина и пароля. 
        /// Логин:root, Password:GeekBrains.  Проверка в методе Task_4_Authorization().
        /// Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает.
        /// С помощью цикла do while ограничить ввод пароля тремя попытками.
        /// </summary>
        static void Task_4()
        {
            Console.WriteLine("4 задание. Проверка логина и пароля \n");
            Console.WriteLine("Для продолжения нажмите любую клавишу...");
            Console.ReadKey();

            bool temp = false;
            int i = 0;
            string s1, s2;

            do
            {
                Console.Clear();

                Console.Write("Введите логин:");
                s1 = Console.ReadLine();

                Console.Write("Введите пароль:");
                s2 = Console.ReadLine();

                temp = Task_4_Authorization(s1, s2);

                if (temp)
                {
                    Console.WriteLine("\nВы ввели правильный логин и пароль!");
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
                            Console.ReadKey();
                            break;
                    }
                }

                i++;

            } while (i <= 2);
        }

        /// <summary>
        /// Задание 5. Проверка массы человека. 
        /// Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и сообщает, нужно ли человеку похудеть, набрать вес или все в норме;
        /// б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.
        /// 16—18,5	- дефицит вес
        /// 18,5—24,99 - Норма
        /// 25—30 - Избыточная масса тела(предожирение)
        /// </summary>
        static void Task_5()
        {

        }

        static bool Task_4_Authorization(string s1, string s2)
        {
            return (s1 == "root" && s2 == "GeekBrains") ? true : false;
        }


    }
}
