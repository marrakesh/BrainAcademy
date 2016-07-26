using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ConsoleApplication25
{
    class Program
    {
        static void Main(string[] args)
        {
            var source = new CancellationTokenSource();

            int n = Convert.ToInt32(Console.ReadLine());

            var task1 = Task.Factory.StartNew(() => factorial(n, source.Token), source.Token);
            CancellationRequest(source);

            //source.Token.Register(() => NotificationMessage());

            //CancellationRequest(source);
            // Task, Task(result), 
            //FactorialMethodAsync(n, source.Token);

            Console.ReadLine();

        }

        public static void CancellationRequest(CancellationTokenSource source)
        {
            if (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                source.Cancel();
            }
        }

        public static void NotificationMessage(CancellationToken token)
        {
            if (token.IsCancellationRequested)
            {
                Console.WriteLine("Cancelation requested");

                token.ThrowIfCancellationRequested();
            }
        }

        public static void factorial(int n, CancellationToken token)
        {
           
            int result = 1;
            if(n < 0)
            {
                Console.WriteLine("Error");
            }
            else if(n > 1)
            {
                for(int i = 2; i <= n; i++)
                {
                    result += i;
                }
            }
            Thread.Sleep(5000);
            Console.WriteLine(result);

        }

        public static async Task FactorialMethodAsync(int n, CancellationToken token)
        {
            
            Task<int> FactorialTask = factorialAsync(n, token);
            int result = await factorialAsync(n, token);
          
            Console.WriteLine(result);

        }

        public static async Task<int> factorialAsync(int n, CancellationToken token)
        {

            int result = 1;
            if (n < 0)
            {
                Console.WriteLine("Error");
            }
            else if (n > 1)
            {
                for (int i = 2; i <= n; i++)
                {
                    result += i;
                }
            }
            Thread.Sleep(1000);
            return result;

        }


    }
}
