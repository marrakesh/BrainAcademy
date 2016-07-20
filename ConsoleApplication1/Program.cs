using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {

            Console.WriteLine("Hello, whats your name?");
            string name;
            name = Console.ReadLine();
            Console.WriteLine("Calculate me two numbers, " + name + "!");
            Console.WriteLine("x = 5.2 and y = 12");
            Console.WriteLine("Whats the sum?");
            double x = 5.2;
            double y = 12;
            Console.WriteLine(x+y);
            Console.WriteLine("Give me a number!");
            int f = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(f*f);
            Console.WriteLine("Using new");
            bool boo = new bool();
            int i = new int();
            double d = new double();
            Console.WriteLine("{0}, {1}, {2}", boo, i, d);

        }
    }
}
