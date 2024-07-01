using Microsoft.Data.Sqlite;

namespace EmployeeManagementApi.Data
{
    public class DatabaseInitializer
    {
        public static void InitializeDatabase(string connectionString)
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            var tableCommand = connection.CreateCommand();
            tableCommand.CommandText = @"
            CREATE TABLE IF NOT EXISTS Employees (
                Id TEXT PRIMARY KEY,
                FirstName TEXT NOT NULL,
                LastName TEXT NOT NULL,
                Email TEXT NOT NULL,
                PhoneNumber TEXT NOT NULL,
                Position TEXT NOT NULL,
                Department TEXT NOT NULL
            )";
            tableCommand.ExecuteNonQuery();
        }
    }
}
