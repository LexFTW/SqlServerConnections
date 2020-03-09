using System.Collections.Generic;

namespace EntityFrameworkFirstCode
{
    public interface IStudentDataAccess
    {
        Student Create(Student student);
        Student ReadById(int id);
        List<Student> Read(string value);
        List<Student> Read(int value);
        List<Student> Read();
        Student Update(Student student);
        Student Delete(Student student);

    }
}
