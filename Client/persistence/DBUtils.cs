using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using log4net;
using log4net.Repository.Hierarchy;

namespace persistence
{
	public static class DBUtils
	{
		private static readonly ILog log = LogManager.GetLogger("DBUtils");

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
			String url = ConfigurationManager.ConnectionStrings["agentieDB"].ConnectionString;

			log.InfoFormat("Trying to connect to database " + url);

			SQLiteConnection con = null;
			try
			{
				con = new SQLiteConnection(url);
			}
			catch (SqlException e)
			{
				log.Error(e);
				Console.WriteLine(e.Message);
			}

			return con;
		}
	}
}