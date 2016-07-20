using System;

namespace ConsoleApplication13
{
    class ClockEventArgs : EventArgs
    {
        public int time;
    }

    class BigBen
    {
        public delegate void Clock(object sender, ClockEventArgs args);

        public event Clock ClockHandler;


        public void Clock7Am()
        {
            Console.WriteLine("Big Ben at 7Am");
            ClockEventArgs args = new ClockEventArgs();
            args.time = 7;
            ClockHandler(this, args);
        }

        public void Clock6PM()
        {
            Console.WriteLine("Big Ben at 6Pm");
            ClockEventArgs args = new ClockEventArgs();
            args.time = 18;
            ClockHandler(this, args);
        }
    }

    class Person
    {
        public string _name;
        public BigBen _ben;

        public Person(string name, BigBen ben)
        {
            this._name = name;
            this._ben = ben;
            this._ben.ClockHandler += BenClockHandler;
            this._ben.ClockHandler += delegate(object sender, ClockEventArgs args)
            {
                Console.WriteLine("Tea time");
            };
            this._ben.ClockHandler += (object sender, ClockEventArgs args) => {
                Console.WriteLine("{0} cleaning tooth", _name);
            };
        }

        public void TeaTime(object sender, ClockEventArgs args)
        {
            Console.WriteLine("It's tea time!");
        }

        public void BenClockHandler(object sender, ClockEventArgs args)
        {
            Console.WriteLine("{0} hears Big Ben", _name);

            if (args.time == 7)
            {
                Console.WriteLine("{0} moaning - Ooooh, too early :(", _name);
            }
            else if(args.time == 18)
            {
                Console.WriteLine("{0} excited and going home", _name);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BigBen bigben = new BigBen();
          
            Person vasya = new Person("Vasya", bigben);
            Person katya = new Person("Katya", bigben);
            Person dima = new Person("Dima", bigben);
            bigben.Clock6PM();
        }
    }
}
