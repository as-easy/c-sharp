using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _6_lesson
{
    //автор: Варанкин Владимир
    /// <summary>
    /// Задание 2. *Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.
    /// Сделать меню с различными функциями и представьте пользователю выбор для какой функции и на каком отрезке находить минимум. 
    /// Используйте массив делегатов.
    /// </summary>
    class Task_2
    {
        delegate double Equation(double x);

        static double Quadratic_equation(double x)
        {
            return x * x - 50 * x + 10;
        }        static double Linear_equation(double x)
        {
            return x + 5;
        }
        static double Absolute_equation(double x)
        {
            return Math.Abs(x + 100);
        }

        /// <summary>
        /// Метод, записывающий в файл значения переданного уравнения
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="step"></param>
        /// <param name="select_equation">Практическое использование делегата для передачи уравнения</param>
        static void SaveFunc(string fileName, double min, double max, double step, Equation select_equation)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);

            double x = min;

            while (x <= max)
            {
                bw.Write(select_equation(x));
                x += step;
            }

            bw.Close();
            fs.Close();
        }
        /// <summary>
        /// Поиск минимума в файле
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        static double Load(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);

            double min = double.MaxValue;
            double d;

            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                d = bw.ReadDouble();
                if (d < min) min = d;
            }

            bw.Close();
            fs.Close();
            return min;
        }

        public static void Task_2_Main()
        {
            int select;
            Equation select_equation;

            try
            {
                Console.WriteLine("Выберите цифру функции для расчета минимума:");
                Console.WriteLine("1. Квадратное уравнение x^2 - 50*x + 10");
                Console.WriteLine("2. Линейное уравнение x + 5");
                Console.WriteLine("3. Абсолютное уравнение |x + 100|");
                Console.WriteLine();

                switch (select = Int32.Parse(Console.ReadLine()))
                {
                    case 1: select_equation = Quadratic_equation; break;
                    case 2: select_equation = Linear_equation; break;
                    case 3: select_equation = Absolute_equation; break;

                    default: select_equation = Quadratic_equation; break;
                }

                Console.WriteLine();
                Console.WriteLine("Выберите отрезок.");
                Console.Write("Минимум (Целое число): ");
                int min = Int32.Parse(Console.ReadLine());
                Console.Write("Максимум (Целое число): ");
                int max = Int32.Parse(Console.ReadLine());

                SaveFunc("data.bin", min, max, 0.5, select_equation);
                Console.WriteLine("\n" + Load("data.bin"));
                Console.ReadKey();
            }
            catch
            {
               Console.WriteLine("Пишите цифры только с целым значением");
            }

           
        }
    }
}
