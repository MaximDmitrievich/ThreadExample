using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Races
{
    class Program
    {
        private static int i = 0;
        static void Method1()
        {
            for (int j = 0; j < 1000; j++, i++) ;
            // Console.WriteLine("+ 1: " + i);
        }
        static void Method2()
        {
            for (int j = 0; j < 1000; j++, i--) ;
            //Console.WriteLine("- 1: " + i); 
        }
        static void Main(string[] args)
        {
            Thread op1 = new Thread(Method1);
            op1.Start();
            Thread op2 = new Thread(Method2);
            op2.Start();
            Console.WriteLine("Result: " + i);
            Thread.Sleep(100);
            Thread op3 = new Thread(Method1);
            op3.Start();
            Thread op4 = new Thread(Method2);
            op4.Start();
            Console.WriteLine("Result: " + i);
            Thread.Sleep(100);
            Thread op5 = new Thread(Method1);
            op5.Start();
            Thread op6 = new Thread(Method2);
            op6.Start();
            Console.WriteLine("Result: " + i);
            Thread.Sleep(100);
            Thread op7 = new Thread(Method1);
            op7.Start();
            Thread op8 = new Thread(Method2);
            op8.Start();
            Console.WriteLine("Result: " + i);
            Console.ReadKey();
        }
    }
}
