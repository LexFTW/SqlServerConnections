namespace SqlQuerys
{
    public interface IStudentData
    {
        bool Create(string pName, string pSurname, string pBirth);
        bool Read();
        bool Update(Student student);
        bool Delete(Student student);
    }
}
