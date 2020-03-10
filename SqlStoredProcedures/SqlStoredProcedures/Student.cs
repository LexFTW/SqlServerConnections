using System;
using System.Collections.Generic;

namespace SqlStoredProcedures
{
    public class Student
    {

        private int studentId;
        private Guid StudentGuid;
        private string studentName;
        private string studentSurname;
        private DateTime ageOfBirth;
        private int studentAge;

        public int StudentId { get => studentId; set => studentId = value; }

        public string StudentName { get => studentName; set => studentName = value; }
        public string StudentSurname { get => studentSurname; set => studentSurname = value; }
        public DateTime AgeOfBirth { get => ageOfBirth; set => ageOfBirth = value; }
        public int StudentAge { get => studentAge; set => studentAge = value; }
        public Guid StudentGuid1 { get => StudentGuid; set => StudentGuid = value; }

        public static List<Student> students = new List<Student>();

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
