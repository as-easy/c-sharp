using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8_lesson
{
    /// <summary>
    /// Автор - Варанкин Владимир
    /// Задание 2. *Используя полученные знания разработать игру “Верю-Не верю"
    /// Form1 - открывает игру Верю - Не верю
    /// Также присутствует редактор вопросов Form2
    /// </summary>
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
