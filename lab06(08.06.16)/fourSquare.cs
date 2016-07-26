namespace lab6
{
    class FourSquare : Shape, IEvaluation
    {
        public FourSquare(double x1, double y1) : base(x1, y1)
        {

        }
        public FourSquare() { }

        public virtual double area()
        {
            return (x * y);
        }

        public virtual double perimeter()
        {
            return (x + y + x + y);
        }
    }
    class Square : FourSquare
    {
        public Square(double x1, double y1) : base(x1, y1)
        {

        }

        public override double area()
        {
            return x * x;
        }

        public override double perimeter()
        {
            return 4 * x;
        }
    }

    class Rectangle : FourSquare
    {
        public Rectangle(double x1, double y1) : base(x1, y1)
        {

        }

        public override double area()
        {
            return x * y;
        }

        public override double perimeter()
        {
            return 2* (x + y);
        }

    }

    class Diamond : FourSquare
    {
        public double sin;
        public Diamond(double x1, double sin1) : base(x1, sin1)
        {
            x = x1;
            sin = sin1;
        }
        public new double area()
        {
            return x * x * sin;
        }

        public new double perimeter()
        {
            return 4 * x;
        }
    }
}
