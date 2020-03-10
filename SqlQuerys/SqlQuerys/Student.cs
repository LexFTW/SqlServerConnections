using System;
using System.Collections.Generic;

namespace SqlQuerys
{
    public class Student
    {
        private Guid StudentGuid;

        public int StudentId { get; set; }

        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public DateTime AgeOfBirth { get; set; }
        public int StudentAge { get; set; }
        public Guid StudentGuid1 { get; set; }
        public static List<Student> Students { get; set; } = new List<Student>();

        public Student(int Id, Guid guid, string name, string surname, DateTime dateAge, int age)
        {

            StudentId = Id;
            StudentGuid1 = guid;
            StudentName = name;
            StudentSurname = surname;
            AgeOfBirth = dateAge;
            StudentAge = age;


        }
        public Student(Guid guid, string name, string surname, DateTime dateAge, int age)
        {

            StudentGuid1 = guid;
            StudentName = name;
            StudentSurname = surname;
            AgeOfBirth = dateAge;
            StudentAge = age;
        }
        public Student(string name, string surname, DateTime dateAge)
        {

           
            StudentName = name;
            StudentSurname = surname;
            AgeOfBirth = dateAge;
           
        }
        public Student()
        {

        }
    }
}
