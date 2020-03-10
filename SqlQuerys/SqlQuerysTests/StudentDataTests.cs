using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SqlQuerys.Tests
{
    [TestClass()]
    public class StudentDataTests
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(StudentDataTests));
        public static StudentData studentData;
        [TestInitialize]
        public void Setup()
        {
            
            studentData = new StudentData();
            Student student1 = new Student("Pepe", "Garrido", Convert.ToDateTime("2002-5-7"));
            Student student2 = new Student("Marina", "Lopez", Convert.ToDateTime("2007-8-2"));
            Student student3 = new Student("Lolo", "Perez", Convert.ToDateTime("2005-7-7"));
            studentData.Create(student1);
            studentData.Create(student2);
            studentData.Create(student3);
        }

        [TestMethod()]
        public void CreateTest()
        {
            Student student4 = new Student("Susana", "Martinez", Convert.ToDateTime("1991-5-9"));

            var response = studentData.Create(student4);
            logger.Info("CreateTest:  " + response);
            Assert.IsInstanceOfType(response, typeof(Student));
        }

        [TestMethod()]
        public void DeleteTest()
        {
            var response = studentData.Delete(3);
            logger.Info("DeleteTest:  " + response);
            Assert.IsTrue(response);
        }

        [TestMethod()]
        public void ReadTest()
        {
            var response = studentData.Read(3);
            logger.Info("ReadTest:  " + response);
            Assert.IsInstanceOfType(response, typeof(Student));
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Student student5 = new Student(1,Guid.NewGuid()," Pepe", "Garrido", Convert.ToDateTime("2002-5-7"),20);
            var response = studentData.Update(student5);
            logger.Info(".....UpdateTest:  " + response);
            Assert.IsInstanceOfType(response, (typeof(Student)));
        }
    }
}