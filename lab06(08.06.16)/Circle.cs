using System;

namespace lab6
{
    class Circle : Shape, IEvaluation
    {
        public Circle(double x1, double y1) : base(x1, y1)
        {

        }
        public Circle() { }

        public virtual double area()
        {
            return (Math.PI*x*x);
        }

        public virtual double perimeter()
        {
            return (2* Math.PI * x);
        }
    }
}
