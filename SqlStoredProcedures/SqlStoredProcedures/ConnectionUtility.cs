using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using SqlStoredProcedures.Properties;

namespace SqlStoredProcedures
{
   public class ConnectionUtility
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(ConnectionUtility));
        SqlConnection connectionSql;

        public static SqlConnection OpenConnection()
        {
            SqlConnection connectionSql = new SqlConnection();
            try
            {
                connectionSql = new SqlConnection(GetConnectionStringByName(Resources.SqlString));
                connectionSql.Open();
            }
            catch (Exception exception)
            {
                logger.Info("Connection Error", exception);
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
