namespace SqlQuerys
{
    public interface IStudentData
    {
        bool Create(string pName, string pSurname, string pBirth);
        Student Read(int pId);
        bool Update(int pId, string pName, string pSurname, string pBirth);
        bool Delete(int pId);
    }
}
