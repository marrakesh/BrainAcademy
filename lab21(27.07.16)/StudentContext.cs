using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab21_27._07._16_
{
    class StudentContext : DbContext
    {
        public StudentContext() : base("DbConnection")
        { }

        public DbSet<Student> Students { get; set; }
    }
}
