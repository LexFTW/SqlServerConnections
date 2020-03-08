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
            using (var db = new StudentContext())
            {
                try
                {
                    var students = db.Students.Where(s => s.Name.Contains(value)
                    || s.Surname.Contains(value)).ToList();
                    return students;
                }
                catch (Exception e)
                {
                    // Logs
                    throw;
                }
            }
        }

        public List<Student> Read(int value)
        {
            using (var db = new StudentContext())
            {
                try
                {
                    var students = db.Students.Where(s => s.Age == value).ToList();
                    return students;
                }
                catch (Exception e)
                {
                    // Logs
                    throw;
                }
            }
        }

        public List<Student> Read()
        {
            using (var db = new StudentContext())
            {
                try
                {
                    var students = db.Students.ToList();
                    return students;
                }
                catch (Exception e)
                {
                    // Logs
                    throw;
                }
            }
        }

        public Student ReadById(int id)
        {
            using (var db = new StudentContext())
            {
                try
                {
                    var student = db.Students.Find(id);
                    return student;
                }
                catch (Exception e)
                {
                    // Logs
                    throw;
                }
            }
        }

        public bool Update(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
