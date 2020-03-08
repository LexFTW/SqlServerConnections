using System.Data.Entity;

namespace EntityFrameworkFirstCode
{
    public class StudentDataset : DbContext
    {
        public DbSet<Student> Students { get; set; }

    }
}
