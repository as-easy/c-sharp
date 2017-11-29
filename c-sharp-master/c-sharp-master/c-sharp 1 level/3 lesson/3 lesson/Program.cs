using System;

namespace _3_lesson
{
    class Program
    {
        //Автор: Варанкин Владимир

        /// <summary>
        /// 2. Задание. С клавиатуры вводятся числа, пока не будет введен 0 (каждое число в новой строке). 
        /// <para>Требуется подсчитать сумму всех нечетных положительных чисел. Сами числа и сумму вывести на экран.</para>
        /// <para>Добавить обработку исключительных ситуаций на то, что могут быть введены некорректные данные. </para>
        /// <para></para>
        /// <para>3 задание. Сложение рациональных дробей</para>
        /// </summary>
        static void Main(string[] args)
        {
            int sum = 0, number = 0;

            #region 2 задание
            Console.WriteLine("2 Задание. Подсчет всех положительных нечетных чисел!\n");

            do
            {
                try
                {
                    do
                    {
                        Console.Write("Введите целое число. Число 0 - окончание счета: ");
                        number = int.Parse(Console.ReadLine());
                        Math2 obj = new Math2();
                        sum = sum + obj.Summa(number);

                    } while (number != 0);
                    break;
                }

                catch (Exception)
                {
                    Console.WriteLine("\nВводите только целые числа! Нажмите любую клавишу для продолжения счета..\n");
                    Console.ReadKey();
                }
            } while (true);

            Console.WriteLine($"Сумма всех нечетных положительных чисел: {sum}");
            Console.WriteLine("\nДля перехода к след. заданию нажмите любую клавишу.");
            Console.ReadKey();
            #endregion


            #region 3 задание
            Console.WriteLine("\n3 Задание. Демонстрация сложения дробей!");
            int num1, num2;

            Math3 obj2 = new Math3(1, 4);

            do
            {
                try
                {

                    Console.Write("Введите числитель (только целое число): ");
                    num1 = int.Parse(Console.ReadLine());

                    Console.Write("Введите знаменатель (только целое число): ");
                    num2 = int.Parse(Console.ReadLine());

                    break;
                }

                catch (Exception)
                {
                    Console.WriteLine("\nВводите только целые числа! Нажмите любую клавишу, чтобы заново ввести числа..\n");
                    Console.ReadKey();
                }
            } while (true);

            Console.WriteLine($" Сложение дроби пользователя {num1}/{num2} c 1/4 = " + obj2.Slozh(num1, num2));
            Console.WriteLine("\nДля выхода из программы нажмите любую клавишу.");
            Console.ReadKey();

            #endregion


        }
    }
    /// <summary>
    /// Класс для второго задания и метод подсчета суммы 
    /// </summary>
    class Math2
    {
        private int sum = 0;
       
        public int Summa (int number)
        {
            if(number != 0 && number > 0 && number%2 == 1)
            {
                sum = sum + number;
                return sum;
            }

            return 0;            
        }
    }

    /// <summary>
    /// Класс для третьего задания и метод для сложения дробей
    /// </summary>
    class Math3
    {
        private int num3;
        private int num4;

        public Math3(int num3, int num4)
        {
            this.num3 = num3;
            this.num4 = num4;
        }

        public string Slozh(int num1, int num2)
        {
            num1 = num1 * num4 + num2 * num3;
            num2 = num2 * num4;
            return string.Format($"{num1}/{num2}");
        }
    }
}
