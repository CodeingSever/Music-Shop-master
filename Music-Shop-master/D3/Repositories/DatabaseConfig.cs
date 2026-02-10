using System.IO;
using Microsoft.Data.Sqlite;
using Dapper;

namespace D3.Repositories
{
    public static class DatabaseConfig
    {
        public static string DbPath = "Shop.db";
        public static string ConnectionString => $"Data Source={DbPath}";

        public static void InitializeDatabase()
        {
            if (!File.Exists(DbPath))
            {
                using (var connection = new SqliteConnection(ConnectionString))
                {
                    connection.Open();
                    
                    var tableCmd = connection.CreateCommand();
                    tableCmd.CommandText = @"
                        CREATE TABLE IF NOT EXISTS Categories (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name TEXT NOT NULL UNIQUE
                        );

                        CREATE TABLE IF NOT EXISTS Products (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Code TEXT,
                            Name TEXT NOT NULL,
                            CategoryId INTEGER,
                            Price DECIMAL NOT NULL,
                            StockQuantity INTEGER NOT NULL,
                            Description TEXT,
                            IsDeleted BOOLEAN DEFAULT 0,
                            CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
                            FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
                        );

                        CREATE TABLE IF NOT EXISTS Transactions (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Date DATETIME DEFAULT CURRENT_TIMESTAMP,
                            TotalAmount DECIMAL NOT NULL,
                            Tax DECIMAL DEFAULT 0,
                            NetTotal DECIMAL NOT NULL
                        );

                        CREATE TABLE IF NOT EXISTS TransactionItems (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            TransactionId INTEGER NOT NULL,
                            ProductId INTEGER NOT NULL,
                            ProductName TEXT,
                            Quantity INTEGER NOT NULL,
                            UnitPrice DECIMAL NOT NULL,
                            FOREIGN KEY (TransactionId) REFERENCES Transactions(Id),
                            FOREIGN KEY (ProductId) REFERENCES Products(Id)
                        );

                        -- Seed some initial data
                        INSERT OR IGNORE INTO Categories (Id, Name) VALUES (1, 'General');
                        INSERT OR IGNORE INTO Categories (Id, Name) VALUES (2, 'String Instruments');
                        INSERT OR IGNORE INTO Categories (Id, Name) VALUES (3, 'Percussion');
                    ";
                    tableCmd.ExecuteNonQuery();
                }
            }
        }
    }
}
