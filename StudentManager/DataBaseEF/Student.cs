namespace StudentManager
{
    //public class Student
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public string Group { get; set; }
    //    public int Number { get; set; }
    //    public double AverageGrade { get; set; }
    //    public bool Scholarship { get; set; }
    //}

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public double AverageGrade { get; set; }
        public bool Scholarship { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}