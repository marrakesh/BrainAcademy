using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirplaneLibrary.Classes;
using AirplaineLibrary;
using System.Reflection;

namespace AirplaineLibrary
{
    public enum AirplainTypes {SportPlane, CargoPlane, TurboProp, Jet };

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true, Inherited = false)]
    public sealed class AirplaneTypeAttribute : Attribute
    {
        public AirplainTypes Type { get; set; }

        public AirplaneTypeAttribute()
        {
            Type = AirplainTypes.TurboProp;
        }
        public AirplaneTypeAttribute(AirplainTypes Type)
        {
            this.Type = Type;
        }

        public static implicit operator AirplaneTypeAttribute(string v)
        {
            throw new NotImplementedException();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Type type = Type.GetType("AirplaneLibrary.Classes.UniversalAirplane");
            //PropertyInfo[] prop = type.GetProperties();
            //foreach (PropertyInfo pro in prop)
            //{
            //    Console.WriteLine(pro.Name);
            //}
            //Type type1 = Type.GetType("AirplaineLibrary.AirplaneTypeAttribute");
            //PropertyInfo[] prop1 = type1.GetProperties();
            //foreach(PropertyInfo pro in prop1)
            //{
            //    Console.WriteLine(pro.Name);
            //}

            Attribute[] asa =Attribute.GetCustomAttributes(typeof(UniversalAirplane), typeof(AirplaneTypeAttribute));
            foreach (var attr in asa) {
                AirplaneTypeAttribute airTypeAttr = (AirplaneTypeAttribute)attr;
                Console.WriteLine(airTypeAttr.Type);    
            }

            Attribute[] asa1 = Attribute.GetCustomAttributes(typeof(CargoAirplane), typeof(AirplaneTypeAttribute));
            foreach(var attr in asa1)
            {
                AirplaneTypeAttribute airt = (AirplaneTypeAttribute)attr;
                Console.WriteLine(airt.Type);
            }

            Console.ReadLine();


        }
    }
}

namespace AirplaneLibrary.Classes
{

    [AirplaneType(AirplainTypes.CargoPlane)]
    [AirplaneType(AirplainTypes.Jet)]

    class UniversalAirplane
    {
        public int Speed {get; set;}
        public string Name  {get; set;}
        public UniversalAirplane()
        {
            Console.WriteLine("Universal");
        }
    }

    [AirplaneType(AirplainTypes.CargoPlane)]
    class CargoAirplane
    {
        public int Speed;
        public string Name;
        public CargoAirplane()
        {
            Console.WriteLine("Cargo");
        }
    }
}
