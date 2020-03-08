using System.Collections.Generic;

namespace EntityFrameworkFirstCode
{
    public interface IStudentDataAccess
    {
        bool Create(Student student);
        Student ReadById(int id);
        List<Student> Read(string query);
        bool Update(Student student);
        bool Delete(Student student);

    }
}
