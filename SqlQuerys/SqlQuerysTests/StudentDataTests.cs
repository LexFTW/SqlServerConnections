using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQuerys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            log4net.Config.XmlConfigurator.Configure();
            studentData = new StudentData();
            studentData.Create("Pepe", "Martinez", "1991,3,6");
            studentData.Create("Lolo", "Ruiz", "2000,3,7");
            studentData.Create("Susana", "Lopez", "1998,7,6");
        }

        [TestMethod()]
        public void CreateTest()
        {
            var pName = "Maria";
            var pSurname = "Perez";
            var pBirth = "2005-3-7";
            var response = studentData.Create(pName, pSurname, pBirth);
            logger.Info("CreateTest:  " + response);
            Assert.IsTrue(response);
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
            var name = "Mariana";
            var Surname = "Jimenez";
            var age = "2019-7-8";
            var id = 1;
            var response = studentData.Update(id, name, Surname,age);
            logger.Info(".....UpdateTest:  " + response);
            Assert.IsTrue(response);
        }
    }
}