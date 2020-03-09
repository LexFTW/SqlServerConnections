using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EntityFrameworkDatabaseFirst.Tests
{
    [TestClass()]
    public class StudentDataAccessUT
    {
        private static Mock<StudentDataAccess> studentDataAcces;

        [ClassInitialize()]
        public static void TestFixtureSetup(TestContext context)
        {
            studentDataAcces = new Mock<StudentDataAccess>();
        }

        [TestInitialize()]
        public void Setup()
        {

        }

        [TestMethod()]
        public void CreateUT()
        {
            Assert.Fail();
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