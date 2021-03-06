﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadExample
{
    class Program
    {
        public static void Fact(int iterations) // Функция, вычисляющая факториал для определенного числа итераций
        {
            int result = 1;
            for (int i = 1; i <= iterations; i++)
            {
                result *= i;
                Console.WriteLine("{0}\t{1}\tm\t{2}", i, result, Thread.CurrentThread.Name);
                Thread.Sleep(400);
            }
            Console.WriteLine("Result factorial {0}, from main thread", result);
        }

        public static void FactThread(int iterations) // Функция, вычисляющая факториал, запускаемая через новый поток
        {
            int result = 1;
            for (int i = 1; i <= iterations; i++)
            {
                result *= i;
                Console.WriteLine("{0}\t{1}\ts\t{2}", i, result, Thread.CurrentThread.Name);
                Thread.Sleep(400);
            }
            Console.WriteLine("Result factorial {0}, from standart thread", result);
        }


        static void Main(string[] args)
        {
            Console.Write("Insert iterations: ");
            int x = Int32.Parse(Console.ReadLine());
            Console.WriteLine("I\tV\tT\tTID");

            //Создание и запуск нового потока
            Thread th = new Thread(new ThreadStart(() => FactThread(x)));
            th.Name = "Параллельный поток";
            th.Start();

            //Запуск функции в основном потоке
            Fact(x);
            Console.ReadKey();
        }

        
    }
}
