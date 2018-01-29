using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MutexExample
{
    class Program
    {
        static Mutex mutexobj = new Mutex();
        private static int result = 1;
        public static void FactThread(int iterations) // Функция, вычисляющая факториал, запускаемая через новый поток
        {
            mutexobj.WaitOne();
            result = 1;
            for (int i = 1; i <= iterations; i++)
            {
                result *= i;
                Console.WriteLine("{0}\t{1}\ts\t{2}", i, result, Thread.CurrentThread.Name);
                Thread.Sleep(100);
            }
            Console.WriteLine("Result factorial {0}, from standart thread {1}", result, Thread.CurrentThread.Name);
            mutexobj.ReleaseMutex();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("I\tV\tT\tTName");

            //Создание нескольких потоков и запуск их в RealTime
            List<Thread> ths = new List<Thread>();
            ths.Add(new Thread(new ThreadStart(() => FactThread(1))));
            ths[0].Name = "Поток " + 1;
            ths.Add(new Thread(new ThreadStart(() => FactThread(2))));
            ths[1].Name = "Поток " + 2;
            ths.Add(new Thread(new ThreadStart(() => FactThread(3))));
            ths[2].Name = "Поток " + 3;
            ths.Add(new Thread(new ThreadStart(() => FactThread(4))));
            ths[3].Name = "Поток " + 4;
            ths.Add(new Thread(new ThreadStart(() => FactThread(5))));
            ths[4].Name = "Поток " + 5;
            for (int i = 0; i < 5; i++)
            {
                ths[i].Start();
            }
            Console.ReadKey();
        }
    }
}
