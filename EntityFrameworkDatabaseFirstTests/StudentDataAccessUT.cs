using System;
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

        [TestInitialize()]
        public void Setup()
        {
            Student student = new Student();
            studentDataAcces = new Mock<IStudentDataAccess>();
            studentDataAcces.Setup(studentDA => studentDA.Create(It.IsAny<Student>())).Returns((Student s) => s);
            studentDataAcces.Setup(studentDA => studentDA.Create(null)).Throws<ArgumentNullException>();
            studentDataAcces.Setup(studentDA => studentDA.Delete(It.IsAny<Student>())).Returns((Student s) => s);
            studentDataAcces.Setup(studentDA => studentDA.Delete(null)).Throws<ArgumentNullException>();
            studentDataAcces.Setup(studentDA => studentDA.Read()).Returns(new List<Student>());
            studentDataAcces.Setup(studentDA => studentDA.Read(It.IsAny<int>())).Returns(new List<Student>());
            studentDataAcces.Setup(studentDA => studentDA.Read(It.IsAny<string>())).Returns(new List<Student>());
            studentDataAcces.Setup(studentDA => studentDA.ReadById(It.IsAny<int>())).Returns(new Student());
            studentDataAcces.Setup(studentDA => studentDA.Update(It.IsAny<Student>())).Returns((Student s) => s);
            studentDataAcces.Setup(studentDA => studentDA.Update(null)).Throws<ArgumentNullException>();
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
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateUTException()
        {
            var test = studentDataAcces.Object;
            test.Create(null);
        }

        [TestMethod()]
        public void DeleteUT()
        {
            Student student = new Student();
            var test = studentDataAcces.Object;
            var result = test.Delete(student);
            Assert.AreEqual(student, result);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteUTException()
        {
            var test = studentDataAcces.Object;
            test.Delete(null);
        }

        [TestMethod()]
        public void ReadUT()
        {
            var test = studentDataAcces.Object;
            var result = test.Read();
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void ReadUT1()
        {
            var test = studentDataAcces.Object;
            var result = test.Read(23);
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void ReadUT2()
        {
            var test = studentDataAcces.Object;
            var result = test.Read("Mock");
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void ReadByIdUT()
        {
            var test = studentDataAcces.Object;
            var result = test.ReadById(1);
            Assert.IsInstanceOfType(result, typeof(Student));
        }

        [TestMethod()]
        public void UpdateUT()
        {
            Student student = new Student();
            var test = studentDataAcces.Object;
            var result = test.Delete(student);
            Assert.AreEqual(student, result);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateUTException()
        {
            var test = studentDataAcces.Object;
            test.Update(null);
        }
    }
}