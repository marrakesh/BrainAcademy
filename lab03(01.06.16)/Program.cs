using System;

namespace ConsoleApplication5
{
    class Program
    {
        enum Comps { Desktop, Laptop, Server}

        struct CompsStruct
        {
            public int CPU;
            public double Freq;
            public int RAM;
            public int HDD;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(@"
                1 - Array Search
                2 - Array Max
                3 - Computers
");
            int choose = int.Parse(Console.ReadLine());

            switch (choose)
            {
                case 1:
                    Console.WriteLine(@"You choose the ""Array Search""");
                    Array_Search();
                    break;
                case 2:
                    Console.WriteLine(@"You choose the ""Array Max""");
                    Array_Max();
                    break;
                case 3:
                    Console.WriteLine(@"You choose the ""Fibonachi element finder""");
                    Computers();
                    break;
            }

        }


        static void Array_Search()
        {
            int[,] array = new int[2, 2];

            //for(int i = 0; i < array.GetLength(0); i++)
            //{
            //    for(int j = 0; j < array.GetLength(1); j++)
            //    {
            //        array[i, j] = Convert.ToInt32(Console.ReadLine());
            //    }
            //}
            Console.WriteLine("Fill the array");
            Array_Fill(array);
            Console.WriteLine("What we are looking for?");
            int search_element = Convert.ToInt32(Console.ReadLine());
            int positionX = -1;
            int positionY = -1;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == search_element)
                    {
                        positionX = i;
                        positionY = j;
                    }

                }
            }
            Console.WriteLine("Position is: {0}, {1}", positionX, positionY);
        }

        static void Array_Max()
        {
            int[,] array1 = new int[2, 2];
            int[,] array2 = new int[2, 2];

            //for (int i = 0; i < array1.GetLength(0); i++)
            //{
            //    for (int j = 0; j < array1.GetLength(1); j++)
            //    {
            //        array1[i, j] = Convert.ToInt32(Console.ReadLine());
            //    }
            //}

            //for (int i = 0; i < array2.GetLength(0); i++)
            //{
            //    for (int j = 0; j < array2.GetLength(1); j++)
            //    {
            //        array2[i, j] = Convert.ToInt32(Console.ReadLine());
            //    }
            //}
            Console.WriteLine("Fill the first array");
            Array_Fill(array1);
            Console.WriteLine("Fill the second array");
            Array_Fill(array2);
            int array1_sum = 0;
            int array2_sum = 0;
            //for (int i = 0; i < array1.GetLength(0); i++)
            //{
            //    for (int j = 0; j < array1.GetLength(1); j++)
            //    {
            //        array1_sum +=array1[i,j];
            //    }
            //}
            //for (int i = 0; i < array2.GetLength(0); i++)
            //{
            //    for (int j = 0; j < array2.GetLength(1); j++)
            //    {
            //        array2_sum += array2[i, j];
            //    }
            //}
            array1_sum = Array_Sum(array1);
            array2_sum = Array_Sum(array2);
            Console.WriteLine("Sum of the first array is {0} and the second is {1}", array1_sum, array2_sum);
            if (array1_sum > array2_sum)
            {
                Console.WriteLine("Array1 > Array2");
            }
            else if (array1_sum < array2_sum)
            {
                Console.WriteLine("Array2 > Array1");
            }
            else
            {
                Console.WriteLine("They're equal");
            }

        }

        static void Array_Fill(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }

        static int Array_Sum(int[,] array)
        {
            int array_sum = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array_sum += array[i, j];
                }
            }
            return array_sum;
        }

        static void Computers()
        {
            CompsStruct Desktop = new CompsStruct();
            Desktop.CPU = 4;
            Desktop.Freq = 1.2;
            Desktop.RAM = 8;
            Desktop.HDD = 500;

            CompsStruct Laptop = new CompsStruct();
            Laptop.CPU = 2;
            Laptop.Freq = 1.0;
            Laptop.RAM = 4;
            Laptop.HDD = 750;

            CompsStruct Server = new CompsStruct();
            Server.CPU = 8;
            Server.Freq = 1.1;
            Server.RAM = 32;
            Server.HDD = 1500;

            //x = new int[4,5][]
            //int[][] offices = new int[4][];
            //offices[0] = new int[3] { 2, 4, 1 };
            //offices[1] = new int[3] { 5, 0, 0 };
            //offices[2] = new int[3] { 0, 7, 0 };
            //offices[3] = new int[3] { 2, 4, 3 };
            int[][] offices = new int[][]
            {
                new int[] {2, 4 ,1},
                new int[] {5, 0, 0},
                new int[] {0, 7, 0},
                new int[] {2, 4, 3}
            };
            
            Console.WriteLine("\t\t{0}         {1}          {2}", Comps.Desktop, Comps.Laptop, Comps.Server, Comps.Server);
            for (int i = 0; i < offices.Length; i++)
            {
                Console.Write("Office({0}): ", i+1);

                for (int j = 0; j < offices[i].Length; j++)
                    Console.Write("\t{0}\t", offices[i][j]);

                Console.WriteLine();
            }
            int desktopNumber = 0, laptopNumber = 0, serverNumber = 0, totalNumber = 0;
            for(int i = 0; i < 4; i++)
            {
                desktopNumber += offices[i][0];
            }
            for (int i = 0; i < 4; i++)
            {
               laptopNumber += offices[i][1];
            }
            for (int i = 0; i < 4; i++)
            {
                serverNumber += offices[i][2];
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    totalNumber += offices[i][j];
                }
            }

            Console.WriteLine("Number of machines: ");
            Console.WriteLine(
                @"
                  a - all computers
                  d - only desktops
                  l - only laptops
                  s - only servers");

            //char machinesTypeChar = Convert.ToChar(Console.ReadLine());
            while (true)
            {
                char machinesTypeChar = Convert.ToChar(Console.ReadLine());
                //switch (machinesTypeChar)
                //{
                //    case 'd':
                //        Console.WriteLine("Total number of {0}: {1}", Comps.Desktop, desktopNumber);
                //        break;
                //    case 'l':
                //        Console.WriteLine("Total number of {0}: {1}", Comps.Laptop, laptopNumber);
                //        break;
                //    case 's':
                //        Console.WriteLine("Total number of {0}: {1}", Comps.Server, serverNumber);
                //        break;
                //    case 'a':
                //        Console.WriteLine("Total number of all computers: {0}", totalNumber);
                //        break;
                //    default:
                //        Console.WriteLine("Wrong input");
                //        break;
                //}
                if(machinesTypeChar == 'd')
                {
                    Console.WriteLine("Total number of {0}: {1}", Comps.Desktop, desktopNumber);
                    break;
                }
                else if(machinesTypeChar == 'l')
                {
                    Console.WriteLine("Total number of {0}: {1}", Comps.Laptop, laptopNumber);
                    break;
                }
                else if(machinesTypeChar == 's')
                {
                    Console.WriteLine("Total number of {0}: {1}", Comps.Server, serverNumber);
                    break;
                }
                else if(machinesTypeChar == 'a')
                {
                    Console.WriteLine("Total number of all computers: {0}", totalNumber);
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input, try again!");
                    continue;
                }
            }
            Console.WriteLine("The highest perfomance:");
            

            if(Desktop.CPU > Laptop.CPU && Desktop.CPU > Server.CPU)
            {
                Console.WriteLine("Desktop CPU most powerfull");
            }
            else if (Laptop.CPU > Desktop.CPU  && Laptop.CPU > Server.CPU)
            {
                Console.WriteLine("Laptop CPU most powerfull");
            }
            else if (Server.CPU > Desktop.CPU && Server.CPU > Laptop.CPU)
            {
                Console.WriteLine("Server CPU most powerfull");
            }

            if (Desktop.Freq > Laptop.Freq && Desktop.Freq > Server.Freq)
            {
                Console.WriteLine("Desktop Frequency most powerfull");
            }
            else if (Laptop.Freq > Desktop.Freq && Laptop.Freq > Server.Freq)
            {
                Console.WriteLine("Laptop Frequency most powerfull");
            }
            else if (Server.Freq > Desktop.Freq && Server.Freq > Laptop.Freq)
            {
                Console.WriteLine("Server Frequency most powerfull");
            }

            if (Desktop.RAM > Laptop.RAM && Desktop.RAM > Server.RAM)
            {
                Console.WriteLine("Desktop RAM most powerfull");
            }
            else if (Laptop.RAM > Desktop.RAM && Laptop.RAM > Server.RAM)
            {
                Console.WriteLine("Laptop RAM most powerfull");
            }
            else if (Server.RAM > Desktop.RAM && Server.RAM > Laptop.RAM)
            {
                Console.WriteLine("Server RAM most powerfull");
            }

            if (Desktop.HDD > Laptop.HDD && Desktop.HDD > Server.HDD)
            {
                Console.WriteLine("Desktop HDD most powerfull");
            }
            else if (Laptop.HDD > Desktop.HDD && Laptop.HDD > Server.HDD)
            {
                Console.WriteLine("Laptop HDD most powerfull");
            }
            else if (Server.HDD > Desktop.HDD && Server.HDD > Laptop.HDD)
            {
                Console.WriteLine("Server HDD most powerfull");
            }
        }
    }
}
