using System.Data.Entity;

namespace StudentManager
{
    //class StudentContext : DbContext
    //{
    //    public StudentContext() : base("DbConnection") { }

    //    public DbSet<Student> Students { get; set; }
    //    public DbSet<Group> Groups { get; set; }
    //}

    public class StudentContext : DbContext
    {
        public StudentContext() : base("DbConnectionWFEF")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}