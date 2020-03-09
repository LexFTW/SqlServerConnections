using EntityFrameworkDatabaseFirst.Database_First;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EntityFrameworkDatabaseFirst.Tests
{
    [TestClass()]
    public class StudentDataAccessUT
    {
        private static Mock<IStudentDataAccess> studentDataAcces;

        [TestInitialize()]
        public void Setup()
        {
            Student student = new Student();
            studentDataAcces = new Mock<IStudentDataAccess>();
            studentDataAcces.Setup(studentDA => studentDA.Create(It.IsAny<Student>())).Returns((Student s) => s);
        }

        [TestMethod()]
        public void CreateUT()
        {
            Student student = new Student();
            var test = studentDataAcces.Object;
            var result = test.Create(student);
            Assert.AreEqual(student, result);
        }

        [TestMethod()]
        public void DeleteUT()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ReadUT()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ReadUT1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ReadUT2()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ReadByIdUT()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateUT()
        {
            Assert.Fail();
        }
    }
}