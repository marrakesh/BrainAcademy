using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadingExample
{
    class Program
    {
        public static int incrementField;

        static void Main(string[] args)
        {
            ThreadStart starter = new ThreadStart(Increment);
            Thread thread1 = new Thread(starter);
            Thread thread2 = new Thread(starter);
            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();
        }

        static object _lock = new object();
        static void Increment()
        {
            lock (_lock)
            {
                for (int i = 0; i < 20; i++)
                {
                    incrementField++;
                    Console.WriteLine("Increment Field value: {0}, {1}", incrementField, Thread.CurrentThread.ManagedThreadId);

                }
            }
           
        }
    }
}
