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
            studentDataAccess.Create(student);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ReadTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ReadTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ReadByIdTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Assert.Fail();
        }
    }
}