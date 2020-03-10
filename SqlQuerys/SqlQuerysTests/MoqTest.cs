using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQuerys;
using Moq;

namespace SqlQuerysTests
{
    /// <summary>
    /// Descripción resumida de MoqTest
    /// </summary>
    [TestClass]
    public class MoqTest
    {
        Mock<IStudentData> moqObject;
        readonly Student inputStudent = new Student("Pepe", "Perez", Convert.ToDateTime("2000-4-2"));
        readonly Student outStudent = new Student();

        [TestInitialize]
        public void Setup()
        {

            moqObject = new Mock<IStudentData>();
            moqObject.Setup(iStudent => iStudent.Create(inputStudent)).Returns(outStudent);
            moqObject.Setup(iStudent => iStudent.Create(null)).Throws<NullReferenceException>();
            moqObject.Setup(iStudent => iStudent.Read(1)).Returns(outStudent);
            moqObject.Setup(iStudent => iStudent.Read(1)).Throws<ArgumentNullException>();
            moqObject.Setup(iStudent => iStudent.Update(inputStudent)).Returns(outStudent);
            moqObject.Setup(iStudent => iStudent.Update(null)).Throws<ArgumentNullException>();
            moqObject.Setup(iStudent => iStudent.Delete(1)).Returns(true);



        }
        public MoqTest()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtiene o establece el contexto de las pruebas que proporciona
        ///información y funcionalidad para la serie de pruebas actual.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Atributos de prueba adicionales
        //
        // Puede usar los siguientes atributos adicionales conforme escribe las pruebas:
        //
        // Use ClassInitialize para ejecutar el código antes de ejecutar la primera prueba en la clase
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup para ejecutar el código una vez ejecutadas todas las pruebas en una clase
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Usar TestInitialize para ejecutar el código antes de ejecutar cada prueba 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup para ejecutar el código una vez ejecutadas todas las pruebas
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void CreateTestUt()
        {
            Student student = new Student("Pepe", "Garrido", Convert.ToDateTime("2002-5-7"));
            var test = moqObject.Object;
            var result = test.Create(student);
            Assert.AreEqual(student, result);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateException()
        {
            var test = moqObject.Object;
            test.Create(null);
        }

        [TestMethod()]
        public void DeleteTest()
        {
          
            var test = moqObject.Object;
            var result = test.Delete(1);
            Assert.IsTrue( result);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteUTException()
        {
            var test = moqObject.Object;
            test.Delete(0);
        }

        [TestMethod()]
        public void ReadUT()
        {
            var test = moqObject.Object;
            var result = test.Read(2);
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void ReadTestUT()
        {
            var test = moqObject.Object;
            var result = test.Read(2000);
            Assert.IsNotNull(result);
        }


        [TestMethod()]
        public void UpdateTestUT()
        {
            Student student = new Student();
            var test = moqObject.Object;
            var result = test.Update(student);
            Assert.AreEqual(student, result);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateException()
        {
            var test = moqObject.Object;
            test.Update(null);
        }
    }
}
