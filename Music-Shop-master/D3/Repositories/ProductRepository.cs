using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.Data.Sqlite;
using D3.Models;

namespace D3.Repositories
{
    public class ProductRepository
    {
        private string _connectionString;

        public ProductRepository()
        {
            _connectionString = DatabaseConfig.ConnectionString;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                // Join with Categories to get category name
                var sql = @"
                    SELECT p.*, c.Name as CategoryName 
                    FROM Products p 
                    LEFT JOIN Categories c ON p.CategoryId = c.Id
                    WHERE p.IsDeleted = 0";
                return connection.Query<Product>(sql);
            }
        }

        public Product GetProductById(int id)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<Product>("SELECT * FROM Products WHERE Id = @Id", new { Id = id });
            }
        }

        public IEnumerable<Category> GetAllCategories()
        {
             using (var connection = new SqliteConnection(_connectionString))
            {
                return connection.Query<Category>("SELECT * FROM Categories");
            }
        }

        public void AddProduct(Product product)
        {
             using (var connection = new SqliteConnection(_connectionString))
            {
                var sql = @"
                    INSERT INTO Products (Code, Name, CategoryId, Price, StockQuantity, Description, IsDeleted)
                    VALUES (@Code, @Name, @CategoryId, @Price, @StockQuantity, @Description, 0)";
                connection.Execute(sql, product);
            }
        }

        public void UpdateProduct(Product product)
        {
             using (var connection = new SqliteConnection(_connectionString))
            {
                var sql = @"
                    UPDATE Products 
                    SET Code = @Code,
                        Name = @Name, 
                        CategoryId = @CategoryId, 
                        Price = @Price, 
                        StockQuantity = @StockQuantity, 
                        Description = @Description
                    WHERE Id = @Id";
                connection.Execute(sql, product);
            }
        }

        public void DeleteProduct(int id)
        {
             using (var connection = new SqliteConnection(_connectionString))
            {
                // Soft delete
                connection.Execute("UPDATE Products SET IsDeleted = 1 WHERE Id = @Id", new { Id = id });
            }
        }

         public void UpdateStock(int productId, int quantityChange)
        {
             using (var connection = new SqliteConnection(_connectionString))
            {
                // quantityChange can be negative (sale) or positive (restock)
                connection.Execute("UPDATE Products SET StockQuantity = StockQuantity + @Change WHERE Id = @Id", new { Change = quantityChange, Id = productId });
            }
        }
    }
}
