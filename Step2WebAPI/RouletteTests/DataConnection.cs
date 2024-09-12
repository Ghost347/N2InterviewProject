using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using RouletteAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteTests
{
	public class DataConnection
	{
		private static readonly object _lock = new();
		private static bool _databaseInitialized;
		private static SqliteConnection? _inMemoryDbConnection;

		public static AppDbContext CreateMemoryDb()
		{
			string sourceFile = "C:\\study\\Cs\\Interview\\RouletteAPI3\\RouletteAPI\\RouletteAPI\\Bets.db";
			lock (_lock)
			{
				if (!_databaseInitialized)
				{
					_inMemoryDbConnection = new SqliteConnection(String.Format("Data Source = {0}", ":memory:"));
					_inMemoryDbConnection.Open();
					using (SqliteConnection source = new SqliteConnection(String.Format("Data Source = {0}", sourceFile)))
					{
						source.Open();
						source.BackupDatabase(_inMemoryDbConnection);
					}

					_databaseInitialized = true;
				}
			}

			var optionsBuilderMain = new DbContextOptionsBuilder<AppDbContext>();
			optionsBuilderMain.UseSqlite(_inMemoryDbConnection);

			AppDbContext dbContextMain = new AppDbContext(optionsBuilderMain.Options);

			return dbContextMain;
		}


	}
}
