using System.Collections.Generic;
using EntityFrameworkDatabaseFirst.Database_First;

namespace EntityFrameworkDatabaseFirst
{
    public interface IStudentDataAccess
    {
        bool Create(Student student);
        Student ReadById(int id);
        List<Student> Read(string value);
        List<Student> Read(int value);
        List<Student> Read();
        bool Update(Student student);
        bool Delete(Student student);

    }
}
