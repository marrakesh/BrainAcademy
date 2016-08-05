using System.Collections.Generic;

namespace StudentManager
{
    //class Group
    //{
    //    public int ID { get; set; }
    //    public string GroupName { get; set; }
    //}

    public class Group
    {
        public Group()
        {
            Students = new List<Student>();
        }

        public int Id { get; set; }
        public string GroupName { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}