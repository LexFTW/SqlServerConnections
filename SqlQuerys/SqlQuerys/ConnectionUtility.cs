using System;
using System.Configuration;
using System.Data.SqlClient;
using log4net;
using SqlQuerys.Properties;

namespace SqlQuerys
{
    class ConnectionUtility
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(ConnectionUtility));
        SqlConnection connectionSql;

        public void OpenConnection()
        {
            try
            {
                connectionSql = new SqlConnection(GetConnectionStringByName(Resources.SqlString));
                connectionSql.Open();
            }
            catch (Exception exception)
            {
                logger.Info("Connection Error", exception);
            }
        }

        public void CloseConnection()
        {
            connectionSql.Close();
        }
        public string GetConnectionStringByName(string name)
        {
            string returnValue = null;
            ConnectionStringSettings settings =
                ConfigurationManager.ConnectionStrings[name];
            if (settings != null)
            {
                returnValue = settings.ConnectionString;
            }
            logger.Info("valor Cadena " + returnValue);
            return returnValue;
        }

    }
}
