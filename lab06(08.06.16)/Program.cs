using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    
    class Program
    {
        static void Main(string[] args)
        {
            FourSquare Obj = new FourSquare(2, 5);
            Console.WriteLine("{0},{1}", Obj.area(), Obj.perimeter() );
            Console.WriteLine();
            Diamond ObjD = new Diamond(5, 0.5);
            Console.WriteLine("{0},  {1}", ObjD.area(), ObjD.perimeter());

        }
    }
}
