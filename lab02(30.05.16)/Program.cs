using System;

namespace ConsoleApplication4
{
    class Programs
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"
                1 - OldMan
                2 - OldMan2
                3 - Fibonachi
                4 - Fibonachi(Recursion)
                5 - Calculator
");
            int choose = int.Parse(Console.ReadLine());

            switch (choose)
            {
                case 1:
                    Console.WriteLine(@"You choose the ""Old Man"" game");
                    OldMan();
                    break;
                case 2:
                    Console.WriteLine(@"You choose the ""Old Man 2"" game");
                    OldMan2();
                    break;
                case 3:
                    Console.WriteLine(@"You choose the ""Fibonachi element finder""");
                    Fibonachi();
                    break;
                case 4:
                    Console.WriteLine(@"You choose the ""Fibonachi element finder"" via recursion");
                    int n = int.Parse(Console.ReadLine());
                    int res = FibonachRecur(n);
                    Console.WriteLine(res);
                    break;
                case 5:
                    Console.WriteLine("You choose Calculator");
                    Calculator();
                    break;
            }
            
        }

        static void OldMan()
        {
            Console.WriteLine(@"
                1 - Oldman from left side to right side
                2 - Oldman from right side to legt side
                3 - Oldman with goat from left side to right side
                4 - Oldman with goat from right side to left side
                5 - Oldman with wolf from left side to right side
                6 - Oldman with wolf from right side to left side
                7 - Oldman with weed from left side to right side
                8 - Oldman with weed from right side to left side
                ");


            //3254724 3274584
            while (true)
            {
                Console.WriteLine("Type step sequence: ");
                Console.WriteLine(@"***Example***
                    53684");
                int step = int.Parse(Console.ReadLine());

                if (step == 3254724 || step == 3274584)
                {
                    Console.WriteLine("You're right!");
                    break;
                }
                else
                {
                    Console.WriteLine("Try again!");
                    continue;
                }
            }
        }

        static void OldMan2()
        {
            char ded1 = '1';
            char ded2 = '2';
            char dedkoza1 = '3';
            char dedkoza2 = '4';
            char dedvolk1 = '5';
            char dedvolk2 = '6';
            char dedkapusta1 = '7';
            char dedkapusta2 = '8';
            Console.WriteLine("Under development");
        }

        static void Fibonachi()
        {
            int FiboElement = 1;
           
            int ElementIndex = int.Parse(Console.ReadLine());
            int first = 1;
            int second = 1;
            int i = 2;
            while(i < ElementIndex)
            {
                if (ElementIndex == 1 || ElementIndex == 2)
                {
                    FiboElement = 1;
                    i++;
                }
                else
                {
                    FiboElement = first + second;
                    first = second;
                    second = FiboElement;
                    i++;
                }
                
            }

            Console.WriteLine(FiboElement);

        }

        static int FibonachRecur(int ElementIndex)
        {
            if (ElementIndex == 1 || ElementIndex == 2)
            {
                return 1;
            }
            else
            {
                return FibonachRecur(ElementIndex - 1) + FibonachRecur(ElementIndex - 2);
            }
        }

        static void Calculator()
        {
            double x, y, result;
            Console.WriteLine("Input first number: ");
            x = double.Parse(Console.ReadLine());
            Console.WriteLine("Input second number: ");
            y = double.Parse(Console.ReadLine());
            Console.WriteLine("Input operation: '+', '-', '*'. '/' ");
            char oper = (char)Console.Read();
            

            switch (oper)
            {
                case '+':
                    result = x + y;
                    Console.WriteLine("Result is {0}", result);
                    break;

                case '-':
                    result = x - y;
                    Console.WriteLine("Result is {0}", result);
                    break;
                case '*':
                    result = x * y;
                    Console.WriteLine("Result is {0}", result);
                    break;
                case '/':
                    result = x / y;
                    Console.WriteLine("Result is {0}", result);
                    break;
                default:
                    Console.WriteLine("Illegal operation");
                    break;
            }
        }

    }
}
