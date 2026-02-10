# Music Shop Management System

## Project Overview
This project is a comprehensive Shop Management System designed for a music store. It allows store owners to manage inventory, process sales, and generate reports. The system is built using modern C# technologies and follows Object-Oriented Programming (OOP) principles.

## Features
1.  **Product Management**: Add, Edit, Delete (Soft Delete), and Search products.
2.  **Inventory Management**: Track stock levels, auto-deduct stock upon sale.
3.  **Point of Sale (POS)**: Add items to cart, calculate totals, and checkout.
4.  **Receipt Generation**: Automatically generate PDF receipts upon checkout.
5.  **Reporting**: View inventory and sales reports (PDF export).

## Technology Stack
-   **Language**: C# (.NET 10.0 / 9.0 compatible)
-   **Framework**: Windows Forms (WinForms)
-   **Database**: SQLite (`Microsoft.Data.Sqlite`) with Dapper ORM
-   **PDF Library**: QuestPDF
-   **IDE**: Visual Studio 2026 / VS Code

## Installation Guide
1.  **Prerequisites**:
    -   .NET SDK (Version 9.0 or higher recommended)
    -   Visual Studio or VS Code

2.  **Setup**:
    -   Clone the repository.
    -   Navigate to the `D3` folder.
    -   Run `dotnet restore` to install dependencies.
    -   Run `dotnet run` to start the application.

3.  **Database**:
    -   The application automatically creates `Shop.db` on the first run. No manual setup required.

## User Manual

### Dashboard
The application uses a Tab-based interface:
1.  **Product Management Tab**:
    -   View list of all products.
    -   Use the form on the top to Add or Update products.
    -   Select a product from the grid to fill the form for editing.
    -   Click "Delete" to remove a product (soft delete).
    -   Use the Search bar to filter products by Name or Code.

2.  **Point of Sale (POS) Tab**:
    -   Select a product from the dropdown (only in-stock items shown).
    -   Enter quantity and click "Add to Cart".
    -   Review the cart in the left grid.
    -   Click "Checkout" to complete the sale. A PDF receipt will be generated and opened.

3.  **Reports Tab**:
    -   Click buttons to generate Inventory or Sales reports as PDF.

## Source Code Structure
-   **Models/**: proper POCO classes (`Product`, `Transaction`, `Category`) representing database entities.
-   **Repositories/**: Data Access Layer (DAL) implementation.
    -   `DatabaseConfig.cs`: Handles SQLite connection and table creation.
    -   `ProductRepository.cs`: CRUD operations for products.
    -   `TransactionRepository.cs`: Handles sales transactions and stock updates.
-   **Services/**: Business Logic for non-database tasks.
    -   `ReceiptService.cs`: Generates PDF receipts.
    -   `ReportService.cs`: Generates PDF reports.
-   **Forms/**: (Conceptual) The main UI logic is in `Form1.cs` (Main Dashboard).
-   **docs/**: Contains UML diagrams (`.puml` files).

## OOP & Design Patterns
-   **Repository Pattern**: Used to abstract database logic from the UI.
-   **Service Layer**: Encapsulates complex business logic like PDF generation.
-   **Encapsulation**: All models use properties with getters/setters.
-   **Polymorphism**: Used in the PDF generation generation (QuestPDF).

## Authors
-   [Student Name 1]
-   [Student Name 2]
-   [Student Name 3]
