using DbUp;
using System.Data;

namespace Api.Config
{
    public class DbMigration
    {
        public static void MigrateDatabase(string connectionString)
        {
			try
			{
				EnsureDatabase.For.SqlDatabase(connectionString);
				var upgrader = DeployChanges.To
					.SqlDatabase(connectionString)
					.WithScriptsEmbeddedInAssembly(typeof(DbMigration).Assembly)
					.LogToConsole()
					.Build();

				var result = upgrader.PerformUpgrade();

				if (!result.Successful)
				{
					throw result.Error;
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
        }
    }
}
