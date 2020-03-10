using System.Collections.Generic;

namespace DapperORM
{
    public interface IStudentDataAccess<T>
    {
        T Create(T student);
        T ReadById(int id);
        List<T> Read();
        List<T> Read(string value);
        List<T> Read(int value);
        T Update(T student);
        T Delete(T student);

    }
}
