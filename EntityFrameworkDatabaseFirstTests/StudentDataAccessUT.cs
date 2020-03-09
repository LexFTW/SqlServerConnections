using System.Collections.Generic;
using EntityFrameworkDatabaseFirst.Database_First;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EntityFrameworkDatabaseFirst.Tests
{
    [TestClass()]
    public class StudentDataAccessUT
    {
        private static Mock<IStudentDataAccess> studentDataAcces;

        [ClassInitialize()]
        public static void TestFixtureSetup(TestContext context)
        {
        }

        [TestInitialize()]
        public void Setup()
        {
            var student = new Student();
            studentDataAcces = new Mock<IStudentDataAccess>();
            studentDataAcces.Setup(studentData => studentData.Create(student)).Returns(student);
        }

        [TestMethod()]
        public void CreateUT()
        {
            var test = studentDataAcces.Object;
            Student student = new Student();
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