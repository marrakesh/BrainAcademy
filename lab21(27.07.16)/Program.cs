using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace lab21_27._07._16_
{
    internal class Program
    {
        private static readonly StudentContext db = new StudentContext();

        private static void Main()
        {
            try
            {
                Console.WriteLine(@"1 - View All students
2 - Insert new student
3 - Update student
4 - Delete student"
            );
                var choose = int.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        SelectStudents();
                        break;
                    case 2:
                        AddStudent();
                        break;
                    case 3:
                        UpdateStudent();
                        break;
                    case 4:
                        DeleteStudent();
                        break;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public static void AddStudent()
        {
            Student student = new Student
            {
                Name = Console.ReadLine(),
                Group = Convert.ToChar(Console.ReadLine()),
                Number = int.Parse(Console.ReadLine()),
                AverageGrade = double.Parse(Console.ReadLine())
            };

            db.Students.Add(student);
            {
                db.SaveChanges();
                Console.WriteLine("Save succesfull");
            }
    }

        public static void SelectStudents()
        {
            var students = db.Students;
            foreach (var stud in students)
            {
                Console.WriteLine("{0}, {1}, {2}, {3}, {4}", stud.Id, stud.Name, stud.Group, stud.Number, stud.AverageGrade);
            }
        }

        public static void UpdateStudent()
        {
            var id = int.Parse(Console.ReadLine());
            Student student = db.Students.Find(id);

            student.Name = Console.ReadLine();
            student.Group = Convert.ToChar(Console.ReadLine());
            student.Number = int.Parse(Console.ReadLine());
            student.AverageGrade = double.Parse(Console.ReadLine());
            db.SaveChanges();

        }

        public static void DeleteStudent()
        {
            var id = int.Parse(Console.ReadLine());
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
        }
    }
}