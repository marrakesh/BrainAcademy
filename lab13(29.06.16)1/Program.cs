using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ConsoleApplication20
{
    class Program
    {
        static void Main(string[] args)
        {
            Type type = Type.GetType("BrainAcademy.Student");
            Console.WriteLine("Properties by reflection");
            PropertyInfo[] properties = type.GetProperties();
            foreach(PropertyInfo property in properties)
            {
                Console.WriteLine(property.Name);
            }

            Console.WriteLine("Methods by reflection");
            MethodInfo[] methods = type.GetMethods();
            foreach (MethodInfo method in methods)
            {
                Console.WriteLine(method.Name);
            }
        }
    }
   
}
namespace BrainAcademy
{
    class Student
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }

        public Student()
        {
            this.Id = -1;
            this.name = "Unknown";
            this.lastname = "Unknown";
        }

        public Student(int Id, string name, string lastname)
        {
            this.Id = Id;
            this.name = name;
            this.lastname = lastname;
        }

        public void printId()
        {
            Console.WriteLine("Id : {0}", Id);
        }

        public void fullName()
        {
            Console.WriteLine("Full Name : {0} {1}", name, lastname);
        }
    }
}