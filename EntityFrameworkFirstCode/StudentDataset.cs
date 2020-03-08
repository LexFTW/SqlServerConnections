using System.Data.Entity;

namespace EntityFrameworkFirstCode
{
    class StudentDataset : DbContext
    {
        public DbSet<Student> Students { get; set; }

    }
}
