using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlStoredProcedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlStoredProcedures.Tests
{
    [TestClass()]
    public class StudentDataTests
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(StudentDataTests));
        public static StudentData studentData;
        Student student1 = new Student("Pepito", "Palotes", Convert.ToDateTime("2001-2-6"));
        Student student2 = new Student("Juanito", "Soso", Convert.ToDateTime("1999-2-6"));
        Student student3 = new Student("Harry", "Potter", Convert.ToDateTime("2001-2-6"));
        [TestInitialize]
        public void Setup()
        {
            log4net.Config.XmlConfigurator.Configure();
            studentData = new StudentData();
            studentData.Create(student1);
            studentData.Create(student2);
            studentData.Create(student3);
        }

        [TestMethod()]
        public void CreateTest()
        {
           
            var response = studentData.Create(student1);
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
           
            var response = studentData.Update(student1);
            logger.Info(".....UpdateTest:  " + response);
            Assert.IsInstanceOfType(response, typeof(Student));
        }
       
    }
}