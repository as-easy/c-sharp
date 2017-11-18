using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _5_lesson
{
    /// <summary>
    /// Класс Task_1 проверяет корректность ввода логина. 
    /// <para>Корректным логином будет строка от 2-х до 10-ти символов, содержащая только буквы или цифры, и при этом цифра не может быть первой.</para>
    /// </summary>    
    static class Task_1
    {
        /// <summary>
        /// Главный метод класса.
        /// <para>Метод просит пользователя ввести логин и выводит корректность логина</para>
        /// <param name="logintemp">Введенный логин пользователя</param>
        /// <param name="regex">Регулярное выражение - @"^[a-zA-Z][\w]{1,9}\b"</param>
        /// </summary>
        public static void Task_1_Main()
        {
            const string CONTINUE = "\n\n...Нажмите ESC для выхода или любую другую клавишу для продолжения...\n\n";
            string logintemp = null;
            Regex regex = new Regex(@"^[a-zA-Z][\w]{1,9}\b"); //рег.выражение писать без пробелов!

            do
            {
                Console.Clear();

                Console.WriteLine("Введите логин от 2 до 10 символов (Первая буква, остальные буквы и цифры):");
                logintemp = Console.ReadLine();

                Console.Write(Verification(logintemp, regex) ? ($"\nЛогин корректный. Ваш логин: {Login(logintemp, regex)} {CONTINUE}") : ($"\nЛогин некорректный {CONTINUE}"));
                
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
        
        /// <summary>
        /// Проверка логина на корректность ввода
        /// </summary>
        /// <param name="logintemp">Введенный логин пользователя</param>
        /// <param name="regex">Регулярное выражение, с помощью которого отсеиваются неккоректные логины</param>
        /// <returns>Возвращает: true - корректный логин; false - некорректный логин</returns>
        private static bool Verification(string logintemp, Regex regex)
        {
           return regex.IsMatch(logintemp); 
        }

        /// <summary>
        /// Метод возвращает введенный логин; если логин был введен как "Login123+=", то вернется значение "Login123"
        /// </summary>
        /// <param name="logintemp">Введенный логин пользователя</param>
        /// <param name="regex">Регулярное выражение, с помощью которого приводим логин в надлежащий вид</param>
        /// <returns>Возвращает обработанный логин</returns>
        private static Match Login(string logintemp, Regex regex)
        {
            return regex.Match(logintemp);
        }
    }
}
