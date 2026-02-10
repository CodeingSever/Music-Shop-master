using System;

namespace D3.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class Product
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } // For display
        public decimal Price { get; set; }
        public int StockQuantity { get; set; } 
        public string Description { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    public class Transaction
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }
        public decimal Tax { get; set; }
        public decimal NetTotal { get; set; }
    }

    public class TransactionItem
    {
        public int Id { get; set; }
        public int TransactionId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty; // Snapshot
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; } // Snapshot
        public decimal SubTotal => Quantity * UnitPrice;
    }
}
