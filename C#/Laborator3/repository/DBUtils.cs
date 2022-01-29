using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laborator4.repository
{
    public static class DBUtils
    {
        private static IDbConnection instance = null;

        public static IDbConnection getConnection()
        {
            if (instance == null || instance.State == System.Data.ConnectionState.Closed)
            {
                instance = getNewConnection();
                instance.Open();
            }
            return instance;
        }

        private static IDbConnection getNewConnection()
        {
            //return ConnectionUtils.ConnectionFactory.getInstance().createConnection();
            String url = ConfigurationManager.ConnectionStrings["agentieDeTurism"].ConnectionString;
            SqliteConnection con = null;
            try
            {
                con = new SqliteConnection(url);
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }

            return con;
        }
    }
}

