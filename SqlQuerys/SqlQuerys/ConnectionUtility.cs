using System;
using System.Configuration;
using System.Data.SqlClient;
using log4net;
using SqlQuerys.Properties;

namespace SqlQuerys
{
    public class ConnectionUtility
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(ConnectionUtility));
        static SqlConnection connectionSql=null;

        public static SqlConnection OpenConnection()
        {

            try
            {
                connectionSql = new SqlConnection(GetConnectionStringByName(Resources.SqlString));
                connectionSql.Open();
            }

            catch (InvalidOperationException exception)
            {
                logger.Error("Connection Error", exception);
                throw;
            }
            catch (SqlException exception)
            {
                logger.Error("Connection Error", exception);
                throw;
            }
            catch (Exception exception)
            {
                logger.Error("Connection Error", exception);
                throw;
            }
            return connectionSql;
        }

        public void CloseConnection()
        {
            connectionSql.Close();
        }
        public static string GetConnectionStringByName(string name)
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
