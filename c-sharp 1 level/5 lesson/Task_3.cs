using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _5_lesson
{
    /// <summary>
    /// Задание 3. Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой. Регистр можно не учитывать.
    /// <para> Б) С методом сортировки пузырьком</para>
    /// </summary>
    static class Task_3
    {
        /// <summary>
        /// Главный метод класса.
        /// <para> Метод просит пользователя ввести 2 строки для сравнения и выводит сообщения является ли Строка2 перестановкой букв Строки1</para>
        /// </summary>
        public static void Task_3_Main()
        {
            StringBuilder str1, str2;
            const string CONTINUE= "\n\n...Нажмите ESC для выхода или любую другую клавишу для продолжения...\n\n";
            const string no_permutation = "Строка2 не является перестановкой букв Строки1";
            const string permutation = "Строка2 является перестановкой букв строки 1";
                     
            do
            {
                Console.Clear();

                Console.Write("Введите 1 строку: ");
                str1 = new StringBuilder(Console.ReadLine().ToLower());

                Console.Write("Введите 2 строку: ");
                str2 = new StringBuilder(Console.ReadLine().ToLower());

                if (str1.Length != str2.Length)
                {
                    Console.WriteLine(no_permutation + CONTINUE);
                    continue;
                }

                Bubble_Sort(ref str1);
                Bubble_Sort(ref str2);
                
                Console.WriteLine(str1);
                Console.WriteLine(str2);

                Console.WriteLine(str1.Equals(str2) ? permutation + CONTINUE : no_permutation + CONTINUE);                

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            
        }
        /// <summary>
        /// Метод предназначен для сортировки "пузырьком"
        /// </summary>
        /// <param name="str">Принимаемая строка для сортировки</param>
        private static void Bubble_Sort(ref StringBuilder str)
        {
            for (int i = 0; i < str.Length - 1; i++)
            {
                for (int j = 0; j < str.Length - 1 - i; j++)
                {
                    if (str[j] > str[j + 1])
                    {
                        char[] temp = { str[j] };
                        str[j] = str[j + 1];
                        str[j + 1] = temp[0];
                    }
                }
            }
        }        
    }
}
