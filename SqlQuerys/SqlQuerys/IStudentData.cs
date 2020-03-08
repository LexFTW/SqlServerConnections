namespace SqlQuerys
{
    public interface IStudentData
    {
        bool Create(Student student);
        bool Read();
        bool Update(Student student);
        bool Delete(Student student);
    }
}
