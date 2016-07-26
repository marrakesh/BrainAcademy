using System;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization;

namespace lab20_25._07._16_Serialization
{
    [Serializable]
    public class DataStudent
    {
        public int StudentID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public bool scholarship { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var StudentSeriesObj = new DataStudent { StudentID = 000001, firstName = "Bill", lastName = "Gates",scholarship = false};

            IFormatter binFormatter = new BinaryFormatter();
            IFormatter soapFormatter = new SoapFormatter();
            XmlSerializer xmlSer = new XmlSerializer(typeof(DataStudent));

            Stream binStream = new FileStream(@"E:/binStud.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            Stream soapStream = new FileStream(@"E:/soapStud.soap", FileMode.Create, FileAccess.Write, FileShare.None);
            FileStream xmlStream = new FileStream(@"E:/xmlStud.xml", FileMode.Create, FileAccess.Write, FileShare.None);

            binFormatter.Serialize(binStream, StudentSeriesObj);
            soapFormatter.Serialize(soapStream, StudentSeriesObj);
            xmlSer.Serialize(xmlStream, StudentSeriesObj);

            binStream.Close();
            soapStream.Close();
            xmlStream.Close();

            IFormatter binReadFormatter = new BinaryFormatter();
            IFormatter soapReadFormatter = new SoapFormatter();
            XmlSerializer xmlReadSer = new XmlSerializer(typeof(DataStudent));

            Stream binReadStream = new FileStream("binStud.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            Stream soapReadStream = new FileStream("soapStud.soap", FileMode.Open, FileAccess.Read, FileShare.Read);
            FileStream xmlReadStream = new FileStream("xmlStud.xml", FileMode.Open, FileAccess.Read, FileShare.Read);

            DataStudent obj1 = (DataStudent)binReadFormatter.Deserialize(binReadStream);
            DataStudent obj2 = (DataStudent)soapReadFormatter.Deserialize(soapReadStream);
            DataStudent obj3 = (DataStudent)xmlReadSer.Deserialize(xmlReadStream);

            binReadStream.Close();
            soapReadStream.Close();
            xmlReadStream.Close();

            Console.WriteLine("Binary - StudentID: {0}, First Name: {1}, Last Name: {2}, Scholarship: {3}", obj1.StudentID, obj1.firstName, obj1.lastName, obj1.scholarship);
            Console.WriteLine("SOAP - StudentID: {0}, First Name: {1}, Last Name: {2}, Scholarship: {3}", obj2.StudentID, obj2.firstName, obj2.lastName, obj2.scholarship);
            Console.WriteLine("XML - StudentID: {0}, First Name: {1}, Last Name: {2}, Scholarship: {3}", obj3.StudentID, obj3.firstName, obj3.lastName, obj3.scholarship);

            Console.ReadLine();
        }
    }
}
