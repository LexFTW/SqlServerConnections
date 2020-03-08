using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkFirstCode
{
    public class StudentDataAccess : IStudentDataAccess
    {
        public bool Create(Student student)
        {
            using(var db = new StudentDataset())
            {
                try
                {
                    db.Students.Add(student);
                    db.SaveChanges();
                    return true;
                }catch(Exception e){
                    // Logs
                    throw;
                }
            }
        }

        public bool Delete(Student student)
        {
            using (var db = new StudentDataset())
            {
                try
                {
                    db.Entry(student).State = EntityState.Deleted;
                    db.SaveChanges();
                    return true;
                }catch(Exception e){
                    // Logs
                    throw;
                }
            }
        }

        public List<Student> Read(string value)
        {
            using (var db = new StudentDataset())
            {
                try
                {
                    var students = db.Students.Where(s => s.Name.Contains(value) 
                    || s.Surname.Contains(value)).ToList();
                    return students;
                }catch(Exception e)
                {
                    // logs
                    throw;
                }
            }
        }

        public List<Student> Read(int value)
        {
            using (var db = new StudentDataset())
            {
                try
                {
                    var students = db.Students.Where(s => s.Age == value).ToList();
                    return students;
                }
                catch (Exception e)
                {
                    // logs
                    throw;
                }
            }
        }

        public Student ReadById(int id)
        {
            using (var db = new StudentDataset())
            {
                try
                {
                    var student = db.Students.Find(id);
                    return student;
                }catch(Exception e)
                {
                    // Logs
                    throw;
                }
            }
        }

        public bool Update(Student student)
        {
            var studentInDatabase = ReadById(student.StudentId);
            studentInDatabase.Name = student.Name;
            studentInDatabase.Surname = student.Surname;
            studentInDatabase.Age = student.Age;
            studentInDatabase.StudentGuid = student.StudentGuid;

            using (var db = new StudentDataset())
            {
                db.SaveChanges();
                return true;
            }
            throw new Exception();
        }
    }
}
