using System;
using System.IO;

namespace _4_lesson
{
    //Автор: Варанкин Владимир
    class Program
    {
        static void Main()
        {
            Task1 obj1 = new Task1(-10, 10, 20);
            Console.WriteLine("Массив с числами:\n{0}", obj1.Row);
            Console.WriteLine("\nКоличество пар, делящихся на 3: {0}", obj1.Count);
            Console.ReadKey();

            Task3 obj2 = new Task3("C:\\Users\\aseasy\\Desktop\\c-sharp\\c-sharp 1 level\\4 lesson\\password.txt");
            //Task3 obj2 = new Task3(@"\password.txt"); - не работает :(
            obj2.Task_3_proverka();
        
        }
    }
    /// <summary>
    /// 1 задание. Подсчет количества пар чисел, делящихся на три.
    /// Task1 - Конструктор получает min - минимум, max - максимум, kol - количество значений в массиве
    /// CountTwain() - Метод подсчета пар;
    /// Count - Свойство для вывода количества пар;
    /// Row - Свойство для вывода массива чисел;
    /// </summary>
    class Task1
    {
        int min, max;
        int[] arr;
        string row = "";
        int count;
        Random R = new Random();

        public Task1(int min, int max, int kol)
        {
            this.min = min;
            this.max = max;
            arr = new int[kol];

            for (int i = 0; i<arr.Length; i++)
            {
                arr[i] = R.Next(this.min, this.max);
                row = row + string.Format("{0,8}", arr[i].ToString());
            }

            CountTwain();
        }

        void CountTwain()
        {            
            count = 0;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] % 3 == 0 || arr[i+1] % 3 == 0)
                {
                    count++;
                }
            }            
        }
        public string Row
        {
            get { return row; }
        }

        public int Count
        {
            get { return count; }            
        }       
    }

    /// <summary>
    /// Задание 3. Проверка логина и пароля. Логин и пароль берется из файла password.txt
    /// </summary>
    class Task3
    {
        string[] ss;

        public Task3(string filename)
        {
            if (File.Exists(filename))
            {
                //Считываем все строки из файла
                ss = File.ReadAllLines(filename);
            }
            else Console.WriteLine("Error load file");

            foreach (string s in ss)
            {
                Console.WriteLine(s);
            }
        }

        bool Task_3_Authorization(string s1, string s2)
        {            
            return (s1 == ss[0] && s2 == ss[1]) ? true : false;
        }

        public void Task_3_proverka()
        {
            Console.Clear();
            Console.WriteLine("3 задание. Проверка логина и пароля");
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

                if (Task_3_Authorization(s1, s2))
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
    }
   
}
