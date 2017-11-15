using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _5_lesson
{
    class Task_1
    {
        const string CONTINUE = "...Нажмите ESC для выхода или любую другую клавишу для продолжения...\n\n";

        Regex regex = new Regex(@"^[a-zA-Z][\w]{1,9}\b"); //рег.выражение писать без пробелов!
        string s1 = null;

        public void Body()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Введите логин от 2 до 10 символов (Первая буква, остальные буквы и цифры):");
                s1 = Console.ReadLine();

                if (Verification(s1))
                {
                    Console.WriteLine("\nЛогин корректный. Ваш логин: {0}\n", Login(s1));
                    Console.WriteLine(CONTINUE);
                }
                else
                {
                    Console.WriteLine("\nЛогин некорректный \n");
                    Console.WriteLine(CONTINUE);
                }

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
            

        public bool Verification(string s1)
        {
           return regex.IsMatch(s1); 
        }

        public Match Login(string s1)
        {
            return regex.Match(s1);
        }

    }
}
