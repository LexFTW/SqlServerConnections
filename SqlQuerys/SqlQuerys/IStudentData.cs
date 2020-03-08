namespace SqlQuerys
{
    public interface IStudentData
    {
        bool Create(string pName, string pSurname, string pBirth);
        Student Read(int pId);
        bool Update(Student student);
        bool Delete(Student student);
    }
}
