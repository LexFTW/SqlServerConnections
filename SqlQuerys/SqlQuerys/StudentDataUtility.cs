using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlQuerys
{
   public class StudentDataUtility
    {
        public static Student AddStudent(string pName, string pSurname, string pAge)
        {
           
            DateTime DateAge = GetDateTime(pAge);
            Guid guid = Guid.NewGuid();
            int age = CalculateAge(DateAge);
            Student student = new Student(guid, pName, pSurname, DateAge, age);
            AddStudentList(student);
            return student;
        }
        private static int CalculateAge(DateTime DateAge)
        {
            int age = DateTime.Today.AddTicks(-DateAge.Ticks).Year - 1;
            return age;
        }
        private static DateTime GetDateTime(string pAge)
        {
            DateTime date = Convert.ToDateTime(pAge);
            return date;
        }
        public static void AddStudentList(Student studentAdd)
        {
            Student.students.Add(studentAdd);
        }
    }
}
