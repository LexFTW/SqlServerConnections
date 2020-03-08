using Microsoft.VisualStudio.TestTools.UnitTesting;
using DapperORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Tests
{
    [TestClass()]
    public class StudentDataAccessTests
    {
        [TestMethod()]
        public void CreateTest()
        {
            Student student = new Student();
            student.Name = "Dapper";
            student.Surname = "ORM";
            student.Age = 1;
            student.StudentGuid = System.Guid.NewGuid();

            IStudentDataAccess studentDataAccess = new StudentDataAccess();
            var result = studentDataAccess.Create(student);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Student student = new Student();
            student.StudentId = 10;

            IStudentDataAccess studentDataAccess = new StudentDataAccess();
            var result = studentDataAccess.Delete(student);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void ReadTest()
        {
            IStudentDataAccess studentDataAccess = new StudentDataAccess();
            var result = studentDataAccess.Read();
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void ReadTest1()
        {
            IStudentDataAccess studentDataAccess = new StudentDataAccess();
            var result = studentDataAccess.Read(22);
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void ReadByIdTest()
        {
            IStudentDataAccess studentDataAccess = new StudentDataAccess();
            var student = studentDataAccess.ReadById(1);
            Assert.IsInstanceOfType(student, typeof(Student));
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Student student = new Student();
            student.StudentId = 1;
            student.Name = "Dappersito";
            student.Surname = "ORM";
            student.Age = 1;
            student.StudentGuid = System.Guid.NewGuid();

            IStudentDataAccess studentDataAccess = new StudentDataAccess();
            var result = studentDataAccess.Update(student);
            Assert.IsTrue(result);
        }
    }
}