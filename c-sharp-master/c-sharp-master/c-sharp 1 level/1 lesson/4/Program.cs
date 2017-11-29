using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4
{
    class MyClass  //6 задание: создание своего класса и метода Print()
    {
        public void Print(string s, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(s);
        }
       
    }

    class Program
    {
        static void Main()
        {            
            #region _4_zamena
            Console.WriteLine("Задание 4. Замена переменных без использования 3-ей\n");

            Array myArray = Array.CreateInstance(typeof(String), 2);

            Console.WriteLine("Введите любое первое значение и нажмите Enter: ");
            myArray.SetValue(Console.ReadLine(), 0);

            Console.WriteLine("\nВведите любое второе значение и нажмите Enter: ");
            myArray.SetValue(Console.ReadLine(), 1);

            Console.WriteLine("\n\tПеременная 1-ая: {0}, \t2-ая: {1}  ", myArray.GetValue(0), myArray.GetValue(1));
            Console.WriteLine("\nнажмите Enter для замены значений...");
            Console.ReadKey();

            Array.Reverse(myArray); 

            Console.WriteLine("\n\tПеременная 1-ая: {0}, \t2-ая: {1}  ", myArray.GetValue(0), myArray.GetValue(1));
            Console.WriteLine("\n\nнажмите Enter для перехода к заданию 5");
            Console.ReadKey();
            #endregion
            
            #region _5_FIO
            Console.Clear();
            Console.SetCursorPosition(0, 0);

            int x = Console.WindowWidth/2;
            int xtemp = x;
            int y = Console.WindowHeight/2;
            string s0, s1;
            MyClass ob1 = new MyClass();

            Console.WriteLine("Задание 5. Вывод ФИО и города на центр экрана.");

            Console.WriteLine("\nВведите Вашу фамилию и имя:");
            s0 = Console.ReadLine();
            s0 = "ФИО:   " + s0;

            Console.WriteLine("\nВведите Ваш город:");
            s1 = Console.ReadLine();
            s1 = "Город: " + s1;

            Console.Clear();

            x = xtemp - (s0.Length / 2);
            ob1.Print(s0, x, y-1);
            ob1.Print(s1, x, y+1);

            Console.WriteLine("\n\nнажмите Enter для выхода из программы...");
            Console.ReadKey();
            #endregion
        }
    }
}
