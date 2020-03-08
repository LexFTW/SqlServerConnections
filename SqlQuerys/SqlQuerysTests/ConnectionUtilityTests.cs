using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQuerys;
using SqlQuerysTests.Properties;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlQuerys.Tests
{
    [TestClass()]
    public class ConnectionUtilityTests
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(ConnectionUtilityTests));
        SqlConnection connectionSql;
        [TestInitialize]
        public void Setup()
        {
            log4net.Config.XmlConfigurator.Configure();
        }


        [TestMethod()]
        public void GetConnectionStringByNameTest()
        {

            var name = Resources.SqlString;
            logger.Info("GetString: " + name);
            var response = ConnectionUtility.GetConnectionStringByName(name);
            logger.Info("response....    " + response);
            Assert.AreEqual("Data Source=.;Initial Catalog=SqlConections;User ID=sa;Password=yourStrong(!)Password", response);
        }


   
    }
}