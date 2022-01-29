using System;
using System.Data;
using Microsoft.Data.Sqlite;

namespace ConnectionUtils
{
	public class SqliteConnectionFactory : ConnectionFactory
	{
		public override IDbConnection createConnection()
		{
			//Mono Sqlite Connection
			//String connectionString = "URI=file:/Users/grigo/didactic/MPP/ExempleCurs/2017/database/tasks.db,Version=3";
			//return new SqliteConnection(connectionString);

			// Windows Sqlite Connection, fisierul .db ar trebuie sa fie in directorul debug/bin
			String connectionString = "Data Source=agentie_de_turism.db;";
			return new SqliteConnection(connectionString);
		}
	}
}
