using System.Collections.Generic;

namespace DapperORM
{
    public interface IStudentDataAccess
    {
        Student Create(Student student);
        Student ReadById(int id);
        List<Student> Read();
        List<Student> Read(string value);
        List<Student> Read(int value);
        Student Update(Student student);
        Student Delete(Student student);

    }
}
