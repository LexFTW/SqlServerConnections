using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntityFrameworkDatabaseFirst.Database_First;
using System;

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
            Assert.AreEqual(result, student);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateTestException()
        {
            studentDataAccess.Create(null);
        }


        [TestMethod()]
        public void DeleteTest()
        {
            Student student = new Student();
            student.StudentId = 2;
            var result = studentDataAccess.Delete(student);
            Assert.AreEqual(result, student);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteTestException()
        {
            studentDataAccess.Delete(null);
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
        [ExpectedException(typeof(AssertFailedException))]
        public void ReadByIdTestException()
        {
            var student = studentDataAccess.ReadById(0);
            Assert.IsInstanceOfType(student, typeof(Student));

        }

        [TestMethod()]
        public void ReadAll()
        {
            var students = studentDataAccess.Read();
            Assert.IsNotNull(students);

        }

        [TestMethod()]
        public void UpdateTest()
        {
            var student = new Student();
            student.StudentId = 1;
            var result = studentDataAccess.Update(student);
            Assert.IsInstanceOfType(result, typeof(Student));
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void UpdateTestException()
        {
            studentDataAccess.Update(null);
        }

        [ClassCleanup]
        public static void TestFixtureTearDown()
        {
            var studentContext = new StudentContext();
            studentContext.Database.ExecuteSqlCommand("TRUNCATE TABLE Students");
        }
    }
}