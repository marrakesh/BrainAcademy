using System;
using System.IO;
using System.Text;

namespace Example_1_FileStream
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"E:\new.txt";
            string name = @"";
            string message = Console.ReadLine();
            InOutOperation IOnew = new InOutOperation(path);
            IOnew.WriteToFile(message);
            IOnew.ReadFromFile();
            IOnew.Memory(message);
           
        }
    }

    class InOutOperation
    {
        private string fileName { get; set; }
        private string currentLocation { get; set; }

        public InOutOperation()
        {
            
        }

        public InOutOperation(string path, string name)
        {
            fileName = name;
            currentLocation = path;
        }

        public InOutOperation(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            fileName = fileInfo.Name;
            currentLocation = fileInfo.DirectoryName;
        }

        public void WriteToFile(string message)
        {
            using (StreamWriter strWrt = new StreamWriter(currentLocation + fileName))
            {
                strWrt.WriteLine(message);
            }
            
        }

        public void ReadFromFile()
        {
            using (FileStream flStream = new FileStream(currentLocation + fileName, FileMode.Open))
            {
                using (StreamReader strReader = new StreamReader(flStream))
                {
                    Console.WriteLine(strReader.ReadToEnd());
                    strReader.Close();
                }
                
            }
        }

        public void Memory(string message)
        {
            byte[] byteMessage = Encoding.ASCII.GetBytes(message);
            MemoryStream memStr = new MemoryStream();
            memStr.Write(byteMessage, 0, byteMessage.Length);
            Console.WriteLine(Encoding.ASCII.GetString(memStr.ToArray()));
            
        }

        public void WriteAsync(string message)
        {
            using (StreamWriter strWrt = new StreamWriter(currentLocation + fileName))
            {
                strWrt.WriteAsync(message);

            }
        }
    }
}