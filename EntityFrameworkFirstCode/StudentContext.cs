using System.Data.Entity;

namespace EntityFrameworkFirstCode
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

    }
}
