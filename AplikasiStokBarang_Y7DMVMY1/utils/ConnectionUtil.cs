using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data;
using MySql.Data.MySqlClient;
using Mysqlx.Resultset;

namespace FastWork_AplikasiStokBarang_Y7DMVMY1.utils
{
    static class ConnectionUtil
    {
        private static MySqlConnection _databaseConnection=null;

        public static MySqlConnection CreateConnection()
        {
            if (_databaseConnection == null)
            {
                _databaseConnection = new MySqlConnection(ConfigurationManager.ConnectionStrings[
                    "mysqlCN"
                    ].ConnectionString);
            }
            return _databaseConnection;
        }
        public static void CloseConnection()
        {
            if(_databaseConnection.State == ConnectionState.Closed)
            {
                return;
            }
            _databaseConnection.Close();
        }
        public static MySqlConnection GetConnection()
        {
            return _databaseConnection;
        }
        public static void OpenConnection()
        {
            if(_databaseConnection.State == ConnectionState.Open)
            {
                return;
            }
            _databaseConnection.Open();
        }
    }
}
