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
         Student inputStudent = new Student("Pepe", "Perez", Convert.ToDateTime("2000-4-2"));
         Student outStudent = null;

        [TestInitialize]
        public void Setup()
        {

            moqObject = new Mock<IStudentData>();
            moqObject.Setup(iStudent => iStudent.Create(inputStudent)).Returns(inputStudent);
            moqObject.Setup(iStudent => iStudent.Create(null)).Throws<NullReferenceException>();
            moqObject.Setup(iStudent => iStudent.Read(1)).Returns(outStudent);
            moqObject.Setup(iStudent => iStudent.Read(0)).Throws<NullReferenceException>();
            moqObject.Setup(iStudent => iStudent.Update(inputStudent)).Returns(outStudent);
            moqObject.Setup(iStudent => iStudent.Update(null)).Throws<NullReferenceException>();
            moqObject.Setup(iStudent => iStudent.Delete(1)).Returns(true);
            moqObject.Setup(iStudent => iStudent.Delete(0)).Throws<ArgumentNullException>();



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
        public void CreateTest()
        {
            var result = moqObject.Object.Create(inputStudent);
            Assert.AreEqual(inputStudent, result);

        }
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void CreateException()
        {
            
            var response = moqObject.Object.Create(null);
            Assert.IsNull(response);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            var response = moqObject.Object.Delete(1);
            Assert.IsTrue(response);

        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteException()
        {
            var response = moqObject.Object.Delete(0);
            Assert.IsInstanceOfType(response,typeof(ArgumentNullException));
        }

        [TestMethod()]
        public void ReadTest()
        {
            var result = moqObject.Object.Create(inputStudent);
            Assert.AreEqual(inputStudent, result);
        }

       
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void ReadException()
        {

            var response = moqObject.Object.Create(null);
            Assert.IsInstanceOfType(response, typeof(NullReferenceException));
        }



        [TestMethod()]
        public void UpdateTest()
        {
            var response = moqObject.Object.Update(inputStudent);
            Assert.AreEqual(outStudent, response);


        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void UpdateException()
        {
            var response = moqObject.Object.Create(null);
            Assert.IsInstanceOfType(response, typeof(NullReferenceException));
        }
    }
}
