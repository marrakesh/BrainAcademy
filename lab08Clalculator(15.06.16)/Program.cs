using System;

namespace lab08.Calculator_delegate
{
    
    class Program
    {
        public delegate double Calculate(double x, double y);

        class Calculators
        {
            public double Calculate(Calculate func, double x, double y)
            {
                return func(x, y);
            }
        }
        class Type
        {
            public double Add(double x, double y)
            {
                return x + y;
            }
            public double Min(double x, double y)
            {
                return x - y;
            }

            public double Multi(double x, double y)
            {
                return x * y;
            }

            public double Div(double x, double y)
            {
                return x / y;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Input first number: ");
            double x = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Input second number: ");
            double y = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Input an operation between theese two numbers: ");
            char oper = Convert.ToChar(Console.ReadLine());
            Calculators calc = new Calculators();
            Type operat = new Type();
            Calculate myvar;
            double res;
            switch (oper)
            {
                case '+':
                    myvar = operat.Add;
                    break;
                case '-':
                    myvar = operat.Min;
                    break;
                case '*':
                    myvar = operat.Multi;
                    break;
                case '/':
                    myvar = operat.Div;
                    break;
                default:
                    myvar = delegate (double x1, double y1) { return -1; };
                    break;
            }
            res = calc.Calculate(myvar,x,y);

            Console.WriteLine(res);
        }
    }
}

//namespace lab08.Calculator_delegate
//{

//    class Program
//    {
//        public delegate double Calculate(double x, double y);

//        class Calculator
//        {
//            public double Add(double x, double y)
//            {
//                return x + y;
//            }

//            public double Min(double x, double y)
//            {
//                return x - y;
//            }

//            public double Multi(double x, double y)
//            {
//                return x * y;
//            }

//            public double Div(double x, double y)
//            {
//                return x / y;
//            }
//        }
//        static void Main(string[] args)
//        {
//            Calculator calc = new Calculator();
//            Calculate myvar1 = calc.Add;
//            Calculate myvar2 = calc.Min;
//            Calculate myvar3 = calc.Multi;
//            Calculate myvar4 = calc.Div;

//            double res = myvar2(10, 1.2);
//            Console.WriteLine(res);
//        }
//    }
//}
