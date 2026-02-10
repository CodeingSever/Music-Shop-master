using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.Data.Sqlite;
using D3.Models;

namespace D3.Repositories
{
    public class TransactionRepository
    {
        private string _connectionString;

        public TransactionRepository()
        {
            _connectionString = DatabaseConfig.ConnectionString;
        }

        public int CreateTransaction(Transaction transaction, List<TransactionItem> items)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                using (var tr = connection.BeginTransaction())
                {
                    try
                    {
                        var sqlTrans = @"
                            INSERT INTO Transactions (Date, TotalAmount, Tax, NetTotal)
                            VALUES (@Date, @TotalAmount, @Tax, @NetTotal);
                            SELECT last_insert_rowid();";
                        
                        // ExecuteScalar returns the ID of the new transaction
                        var id = connection.ExecuteScalar<int>(sqlTrans, transaction, tr);

                        var sqlItem = @"
                            INSERT INTO TransactionItems (TransactionId, ProductId, ProductName, Quantity, UnitPrice)
                            VALUES (@TransactionId, @ProductId, @ProductName, @Quantity, @UnitPrice)";

                        foreach (var item in items)
                        {
                            item.TransactionId = id;
                            connection.Execute(sqlItem, item, tr);
                            
                            // Deduct stock
                            connection.Execute("UPDATE Products SET StockQuantity = StockQuantity - @Qty WHERE Id = @ProdId", new {Qty = item.Quantity, ProdId = item.ProductId}, tr);
                        }

                        tr.Commit();
                        return id;
                    }
                    catch
                    {
                        tr.Rollback();
                        throw;
                    }
                }
            }
        }

        public IEnumerable<Transaction> GetAllTransactions()
        {
             using (var connection = new SqliteConnection(_connectionString))
            {
                return connection.Query<Transaction>("SELECT * FROM Transactions ORDER BY Date DESC");
            }
        }
    }
}
