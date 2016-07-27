using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace lab20_25._07._16_StudentsDB
{
    internal class Program
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["StudDBlab"].ConnectionString;

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
                        SelectAll();
                        break;
                    case 2:
                        InsertStudent();
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

        private static void SelectAll()
        {
            var adapter = new SqlDataAdapter("SELECT * FROM Students", ConnectionString);

            var dataSet = new DataSet();
            adapter.Fill(dataSet);
            Console.WriteLine();
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                var id = (int)row[0];
                var name = row[1].ToString();
                var Class = row[2].ToString().Trim();
                var number = (int)row[3];
                var avgGrade = (double)row[4];
                Console.WriteLine($"{id}, {name}, {Class}, {number}, {avgGrade}");
            }
        }

        private static void InsertStudent()
        {

            Console.WriteLine("Insert student Name");
            var name = Console.ReadLine();
            Console.WriteLine("Insert student Class(A, B, C, D)");
            var Class = Console.ReadLine();
            Console.WriteLine("Insert student Number(From 1 to 5)");
            var number = int.Parse(Console.ReadLine());
            Console.WriteLine("Insert student Average grade");
            var avgGrade = double.Parse(Console.ReadLine());

            var query =
                $"INSERT INTO Students (Name, Class, Number, [Average grade] ) VALUES ('{name}', '{Class}', '{number}', '{avgGrade}')";

            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            Console.WriteLine("Insert was successfull");
        }

        private static void UpdateStudent()
        {
            Console.WriteLine("Update student by ID or by name");
            Console.WriteLine(@"1 - ID
2 - Name");
            var choose = int.Parse(Console.ReadLine());

            if (choose == 1)
            {
                Console.WriteLine("Insert student ID");
                var id = int.Parse(Console.ReadLine());
                Console.WriteLine(@"Insert update target(format: ""Name = 'Alexis Sanchez'"")");
                var target = Console.ReadLine();

                var query = $"UPDATE Students SET {target} WHERE ID = {id}";
                Console.WriteLine(query);

                using (var connection = new SqlConnection(ConnectionString))
                {
                    using (var command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                Console.WriteLine("Update was successfull");
            }

            else if (choose == 2)
            {
                Console.WriteLine("Insert student Name");
                var name = Console.ReadLine();
                Console.WriteLine(@"Insert update target(format: ""Class = B or [Average grade] = 5.0 "")");
                var target = Console.ReadLine();

                var query = $"UPDATE Students SET {target} WHERE Name = {name}";
                Console.WriteLine(query);

                using (var connection = new SqlConnection(ConnectionString))
                {
                    using (var command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                Console.WriteLine("Update was successfull");
            }
        }

        private static void DeleteStudent()
        {
            Console.WriteLine("DELETE student by ID or by Name");
            Console.WriteLine(@"1 - ID
2 - Name");
            var choose = int.Parse(Console.ReadLine());

            if (choose == 1)
            {
                Console.WriteLine("Insert student ID");
                var id = int.Parse(Console.ReadLine());

                var query = $"DELETE FROM Students WHERE ID = {id}";
                Console.WriteLine(query);

                using (var connection = new SqlConnection(ConnectionString))
                {
                    using (var command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                Console.WriteLine("Delete was successfull");
            }

            else if (choose == 2)
            {
                Console.WriteLine("Insert student Name");
                var name = Console.ReadLine();

                var query = $"DELETE FROM Students WHERE Name = '{name}'";
                Console.WriteLine(query);

                using (var connection = new SqlConnection(ConnectionString))
                {
                    using (var command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                Console.WriteLine("Delete was successfull");
            }
        }
    }
}
