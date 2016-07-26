using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApplication24
{
    class Program
    {
        static void Main(string[] args)
        {
            //Parallel.For(0, 10, i =>
            //{
            //    Console.WriteLine("i = {0}, thread = {1} ", i, Thread.CurrentThread.ManagedThreadId);
            //    Thread.Sleep(10);
            //});

            //Parallel.Invoke(() =>
            //{
            //    Console.WriteLine("hello 1");
            //},
            //() =>
            //{
            //    Console.WriteLine("hello 2");
            //},
            //() =>
            //{
            //    Console.WriteLine("hello 3");
            //});

            //IAsyncResult result =  BeginGetFactorial(1, 3, null, null);
            //int resw = EndGetFactorial(result);
            //Console.WriteLine(resw);
            object range =new int[] { 5, 6 };

            ThreadManipulator ThreadMan = new ThreadManipulator();
            Thread addOneThred1 = new Thread(ThreadMan.AddOne);
            Thread addOneThred2 = new Thread(ThreadMan.AddOne);
            Thread addCustomThread = new Thread(ThreadMan.AddCustom);
            Thread StopThread = new Thread(ThreadMan.Stop);

            addOneThred1.Start(5);
            addOneThred2.Start(5);
            addCustomThread.Start(range);
            StopThread.Start();
            addOneThred1.Join();
            addOneThred2.Join();
            addCustomThread.Join();
            StopThread.Join();

        }
        public delegate int getFactorialHandler(int start, int final);
        static getFactorialHandler FactorialCaller;

        public static int getFactorial(int start, int final)
        {
            int res = 0;
            for(int i = start; i <= final; i++)
            {
                res += i;
            }

            return res;
        }
        public static IAsyncResult BeginGetFactorial(int start, int final, AsyncCallback callback, object userState)
        {
            FactorialCaller = new getFactorialHandler(getFactorial);
            return FactorialCaller.BeginInvoke(start, final, callback, userState);
            
        }

        public static int EndGetFactorial(IAsyncResult result)
        {

            return FactorialCaller.EndInvoke(result);
        }


    }
    class ThreadManipulator
    {
        public ConsoleKey key;
        //AddOne
        public void AddOne(object num)
        {
            for(int i = 0; i < 50; i++)
            {
                Console.WriteLine("AddOne loop element {0}", i);
                if(i % (int)num == 0)
                {
                    Console.WriteLine("AddOne loop element {0} is divided by {1}", i, num);
                }
                Thread.Sleep(1000);
                if(key == ConsoleKey.Q )
                {
                    break;
                }
            }
            
        }
        //AddCustom
        public void AddCustom(object range)
        {
            int[] rangearr = (int[])range;
            int step = rangearr[0];
            int num = rangearr[1];
            for (int i = 0; i < 200; i += step)
            {
                Console.WriteLine("AddCustom loop element {0}", i);
                if (i % num == 0)
                {
                    Console.WriteLine("AddCustom loop element {0} is divided by {1}", i, num);
                }
                Thread.Sleep(1000);
                if (key == ConsoleKey.W)
                {
                    break;
                }
            }
        }
        //Stop
        public void Stop()
        {
            while (key != ConsoleKey.Q)
            {
                key = Console.ReadKey().Key;
            }
            while (key != ConsoleKey.W)
            {
                key = Console.ReadKey().Key;
            }
        }
    }
}
