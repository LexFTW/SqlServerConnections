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
            var result = studentDataAccess.Create(student);
            Assert.IsTrue(result);
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