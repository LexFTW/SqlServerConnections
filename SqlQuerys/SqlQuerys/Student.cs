using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlQuerys
{
    public class Student
    {
        private int studentId;
        private Guid StuidetnGuid;
        private string studentName;
        private string studentSurname;
        private DateTime ageOfBirth;
        private int studentAge;

        public int StudentId { get => studentId; set => studentId = value; }

        public string StudentName { get => studentName; set => studentName = value; }
        public string StudentSurname { get => studentSurname; set => studentSurname = value; }
        public DateTime AgeOfBirth { get => ageOfBirth; set => ageOfBirth = value; }
        public Guid StuidetnGuid1 { get => StuidetnGuid; set => StuidetnGuid = value; }
        public int StudentAge { get => studentAge; set => studentAge = value; }


        public static List<Student> students = new List<Student>();

        public Student(int Id, Guid guid, string name, string surname, DateTime dateAge, int age)
        {

            StudentId = Id;
            StuidetnGuid1 = guid;
            StudentName = name;
            StudentSurname = surname;
            AgeOfBirth = dateAge;
            StudentAge = age;


        }
        public Student(Guid guid, string name, string surname, DateTime dateAge, int age)
        {

            StuidetnGuid1 = guid;
            StudentName = name;
            StudentSurname = surname;
            AgeOfBirth = dateAge;
            StudentAge = age;
        }
        public Student()
        {

        }
    }
}
