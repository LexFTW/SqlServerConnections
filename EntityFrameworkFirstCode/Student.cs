using System;

namespace EntityFrameworkFirstCode
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public Guid StudentGuid { get; set; }

        public override string ToString()
        {
            return StudentId + ", " + Name + ", " + Surname + ", " + Age + ", " + StudentGuid;
        }

    }
}
