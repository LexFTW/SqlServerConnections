using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntityFrameworkDatabaseFirst.Database_First;

namespace EntityFrameworkDatabaseFirst.Tests
{
    [TestClass()]
    public class StudentDataAccessTests
    {
        private static StudentDataAccess studentDataAccess;

        [ClassInitialize()]
        public static void TestFixtureSetup(TestContext context)
        {
            studentDataAccess = new StudentDataAccess();
        }

        [TestInitialize()]
        public void Setup()
        {
            Student student = new Student();
            student.StudentId = 1;
            student.Name = "Alexis";
            student.Surname = "Mengual Vázquez";
            student.Age = 22;
            student.StudentGuid = System.Guid.NewGuid();

            studentDataAccess.Create(student);
        }

        [TestMethod()]
        public void CreateTest()
        {
            Student student = new Student();
            student.Name = "Alexis";
            student.Surname = "Mengual Vázquez";
            student.Age = 22;
            student.StudentGuid = System.Guid.NewGuid();
            var result = studentDataAccess.Create(student);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Student student = new Student();
            student.StudentId = 2;
            var students = studentDataAccess.Delete(student);
            Assert.IsTrue(students);
        }

        [DataRow("Alexis")]
        [DataRow("Mengual")]
        [DataTestMethod()]
        public void ReadTest(string value)
        {
            var students = studentDataAccess.Read(value);
            Assert.IsNotNull(students);
        }

        [DataRow(22)]
        [DataTestMethod()]
        public void ReadIntTest(int value)
        {
            var students = studentDataAccess.Read(value);
            Assert.IsNotNull(students);
        }

        [TestMethod()]
        public void ReadByIdTest()
        {
            var student = studentDataAccess.ReadById(1);
            Assert.IsInstanceOfType(student, typeof(Student));

        }

        [TestMethod()]
        public void UpdateTest()
        {
            var student = new Student();
            student.StudentId = 1;
            var result = studentDataAccess.Update(student);
            Assert.IsTrue(result);
        }
    }
}