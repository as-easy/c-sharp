using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4
{
    class Program
    {
        static void Main()
        {
            Array myArray = Array.CreateInstance(typeof(String), 2);

            Console.WriteLine("Введите первое значение и нажмите Enter: ");
            myArray.SetValue(Console.ReadLine(), 0);

            Console.WriteLine("\nВведите второе значение и нажмите Enter: ");
            myArray.SetValue(Console.ReadLine(), 1);

            Console.WriteLine("\nПеременная 1-ая: {0}, \t2-ая: {1}  \n\nнажмите Enter", myArray.GetValue(0), myArray.GetValue(1));
            Console.ReadKey();

            Array.Reverse(myArray);

            Console.WriteLine("\nПеременная 1-ая: {0}, \t2-ая: {1}  \n\nнажмите Enter", myArray.GetValue(0), myArray.GetValue(1));
            Console.ReadKey();
        }
    }
}
