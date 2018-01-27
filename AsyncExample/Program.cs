using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncExample
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

        static async void DisplayAsyncFact(int iterations) // Функция, ожидающая выполнение функции вычисления факториала
        {
            int result = await FactAsync(iterations);
            Thread.Sleep(400);
            Console.WriteLine("Result factorial {0}, from async thread", result);
        }

        static Task<int> FactAsync(int iterations) //Асинхронная функция вычисления факториала
        {
            int result = 1;

            return Task.Run(() =>
            {
                Thread.CurrentThread.Name = "Асинхронный поток";
                for (int i = 1; i <= iterations; i++)
                {
                    result *= i;
                    Console.WriteLine("{0}\t{1}\ta\t{2}", i, result,
                        Thread.CurrentThread.Name);
                }
                return result;
            });
        }

        static void Main(string[] args)
        {

            Console.Write("Insert iterations: ");
            int x = Int32.Parse(Console.ReadLine());

            Console.WriteLine("I\tV\tT\tTID");

            //Запуск функции в асинхронном потоке
            DisplayAsyncFact(x);

            //Запуск функции в основном потоке
            Fact(x);

            Console.ReadKey();
        }
    }
}
