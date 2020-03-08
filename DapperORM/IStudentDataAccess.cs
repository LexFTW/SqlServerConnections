using System.Collections.Generic;

namespace DapperORM
{
    public interface IStudentDataAccess
    {
        bool Create(Student student);
        Student ReadById(int id);
        List<Student> Read();
        List<Student> Read(string value);
        List<Student> Read(int value);
        bool Update(Student student);
        bool Delete(Student student);

    }
}
