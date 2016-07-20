using System;

namespace lab05
{

    class Program
    {
        static void Main(string[] args)
        {
            //rectangle rec = new rectangle(15, 100);
            //rec.print();
            overloadOper sas = new overloadOper();
            sas.a = 5;
            overloadOper sas1 = new overloadOper();
            sas1.a = 9;
            overloadOper q = sas + sas1;
            Console.WriteLine(q.a);
        

        }
       
    }
    

    class rectangle
    {
        public int h, w;

        public rectangle(int height, int width)
        {
            h = height;
            w = width;
        }

        public void print()
        {
            for(int i = 0; i < w; i++)
            {
                string Line = "";
                Line += "*";
                Console.Write(Line);
            }
            for(int j = 0; j < h; j++)
            {
                Console.SetCursorPosition(0, j+1);
                Console.Write("*");
                if(j == j / 2)
                {
                    Console.SetCursorPosition(w / 2, h / 2);
                    Console.Write("Hello");
                }
                Console.SetCursorPosition(w-1, j+1);
                Console.WriteLine("*");

            }
            for (int i = 0; i < w; i++)
            {
                string Line = "";
                Line += "*";
                Console.Write(Line);
            }
            Console.WriteLine();

        }

        
    }

    class overloadOper
    {
        public int a;
        public static overloadOper operator +(overloadOper el1, overloadOper el2)
        {
            overloadOper sum = new overloadOper();
            sum.a = el1.a * el2.a;
            return sum;
        }
        public void sass()
        {
            Console.WriteLine(2 + 3);
        }
    }
}
