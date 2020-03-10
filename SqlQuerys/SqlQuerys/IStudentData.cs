namespace SqlQuerys
{
    public interface IStudentData
    {
      Student Create(Student student);
        Student Read(int pId);
        Student Update(Student student);
        bool Delete(int pId);
       
    }
}
