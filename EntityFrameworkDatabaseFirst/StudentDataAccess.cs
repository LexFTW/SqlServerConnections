using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkDatabaseFirst.Database_First;

namespace EntityFrameworkDatabaseFirst
{
    public class StudentDataAccess : IStudentDataAccess
    {
        public bool Create(Student student)
        {
            using (var db = new StudentContext())
            {
                try
                {
                    db.Students.Add(student);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    //Logs
                    throw;
                }
            }
        }

        public bool Delete(Student student)
        {
            throw new NotImplementedException();
        }

        public List<Student> Read(string value)
        {
            throw new NotImplementedException();
        }

        public List<Student> Read(int value)
        {
            throw new NotImplementedException();
        }

        public List<Student> Read()
        {
            throw new NotImplementedException();
        }

        public Student ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
