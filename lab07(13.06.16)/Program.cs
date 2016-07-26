using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication12
{
    public class Element0Exception : Exception
    {
        public Element0Exception()
        {

        }
        public Element0Exception(string message) : base(message)
        {

        }
        public Element0Exception(string message, Exception inner) :base(message, inner)
        {

        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
            //    Console.WriteLine("Enter first number: ");
            //    int first = Convert.ToInt32(Console.ReadLine());
            //    Console.WriteLine("Enter second number: ");
            //    int second = Convert.ToInt32(Console.ReadLine());

            //    int result = first / second;
            //    Console.WriteLine(result);
            //}
            //catch (DivideByZeroException ex)
            //{
            //    string path = @"E:\log.txt";
            //    StreamWriter wc = new StreamWriter(path);
            //    wc.Write(ex.GetType().Name);
            //    wc.WriteLine();
            //    wc.Write(ex.Message);
            //    wc.Close();
            //}
            
            try
            {
                int[] arr = new int[10];

                try
                {

                    int sum = 0;
                    for (int i = 0; i < arr.Length; i++)
                    {
                        Console.WriteLine("Input {0} element", i);
                        arr[i] = int.Parse(Console.ReadLine());
                        if (arr[1] == 2)
                        {
                            throw new FormatException("Input 2!!!");
                        }
                    }
                    Console.WriteLine("Input element index");
                    int index = int.Parse(Console.ReadLine());
                    Console.WriteLine(arr[index]);
                    Console.WriteLine("Input element indexes");
                    int index1 = int.Parse(Console.ReadLine());
                    int index2 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Divide {0}", arr[index1] / arr[index2]);
                    for (int i = 0; i < arr.Length; i++)
                    {
                        sum += arr[i];
                    }
                    Console.WriteLine("Sum: {0}", sum);
                }
                catch (NullReferenceException ex0)
                {
                    Console.WriteLine(ex0.Message);
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    throw new IndexOutOfRangeException("Too big index", ex);
                }
                catch (FormatException ex1)
                {
                    Console.WriteLine(ex1.Message);
                }

                catch (DivideByZeroException ex2)
                {
                    Console.WriteLine(ex2.Message);
                    throw new Element0Exception("zero element in array", ex2);

                }
                catch (OverflowException ex3)
                {
                    Console.WriteLine(ex3.Message);

                }
            }
            catch (IndexOutOfRangeException exx)
            {
                Console.WriteLine(exx.Message);
            }
            catch (Element0Exception exx0)
            {
                Console.WriteLine(exx0.Message);
            }
            
        }
    }
}
