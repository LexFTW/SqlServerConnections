using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntityFrameworkFirstCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkFirstCode.Tests
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
            Assert.Fail();
        }

        [DataRow("Alexis")]
        [DataRow("Mengual")]
        [DataRow("22")]
        [DataTestMethod()]
        public void ReadTest(string value)
        {
            var students = studentDataAccess.Read(value);
            Assert.IsNotNull(students);
        }

        [TestMethod()]
        public void ReadByIdTest()
        {
            var student = studentDataAccess.ReadById(2);
            Assert.IsInstanceOfType(student, typeof(Student));
            
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Assert.Fail();
        }
    }
}