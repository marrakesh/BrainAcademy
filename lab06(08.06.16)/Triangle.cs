using System;

namespace lab6
{
    class Triangle : Shape, IEvaluation
    {
        public double z;

        public Triangle(double x1, double y1, double z1) : base(x1, y1)
        {
            z = z1;
        }
        //p=(a+b+c)/2;    s=Sqrt(p*(p-a)*(p-b)*(p-c)
        public double area()
        {
            double p = (x + y + z)/2;
            return Math.Sqrt(p*(p - x)*(p - y)*(p - z));
        }

        public double perimeter()
        {
            return (x + y + z);
        }
    }
}
