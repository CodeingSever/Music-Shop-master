using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using D3.Models;
using D3.Repositories;
using D3.Services;
using System.Globalization;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;

namespace D3
{
    public partial class Form1 : Form
    {
        private readonly ProductRepository _productRepo;
        private readonly TransactionRepository _transactionRepo;
        private readonly ReceiptService _receiptService;
        
        // POS Cart
        private BindingList<TransactionItem> _cartItems;
        private List<Product> _allProducts; // Cache for POS dropdown

        public Form1()
        {
            InitializeComponent();
            _productRepo = new ProductRepository();
            _transactionRepo = new TransactionRepository();
            _receiptService = new ReceiptService();
            _cartItems = new BindingList<TransactionItem>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LocalizeUI();
            LoadCategories();
            LoadProducts();
            SetupCartGrid();
            LoadPOSProducts();
        }

        private void LocalizeUI()
        {
            this.Text = "ระบบจัดการร้านดนตรี";
            tabProducts.Text = "จัดการสินค้า";
            grpProductDetails.Text = "รายละเอียดสินค้า";
            lblDesc.Text = "รายละเอียด:";
            btnClear.Text = "ล้างข้อมูล";
            btnDelete.Text = "ลบ";
            btnUpdate.Text = "แก้ไข";
            btnAdd.Text = "เพิ่ม";
            lblCategory.Text = "หมวดหมู่:";
            lblQty.Text = "จำนวน:";
            lblPrice.Text = "ราคา:";
            lblCode.Text = "รหัส:";
            lblName.Text = "ชื่อ:";
            btnSearchProduct.Text = "ค้นหา";
            txtSearchProduct.PlaceholderText = "ค้นหาจากชื่อหรือรหัส...";
            btnExport.Text = "ส่งออก";
            btnImport.Text = "นำเข้า";
            
            tabPOS.Text = "จุดขาย (POS)";
            grpCart.Text = "ตะกร้าสินค้า";
            lblPOSTotal.Text = "รวมทั้งหมด: 0.00";
            btnCheckout.Text = "ชำระเงิน (พิมพ์ใบเสร็จ)";
            btnClearCart.Text = "ล้างตะกร้า";
            grpPOSSearch.Text = "เพิ่มสินค้าลงตะกร้า";
            btnAddToCart.Text = "เพิ่มลงตะกร้า";
            lblPOSQty.Text = "จำนวน:";
            lblPOSProduct.Text = "สินค้า:";
            
            tabReports.Text = "รายงาน";
            btnInventoryReport.Text = "สร้างรายงานสินค้าคงคลัง";
            btnSalesReport.Text = "สร้างรายงานการขาย";
        }

        // ================= PRODUCT MANAGEMENT =================

        private void LoadCategories()
        {
            var categories = _productRepo.GetAllCategories().ToList();
            if (cmbCategory.Items.Count == 0 && categories.Count > 0)
            {
                cmbCategory.DataSource = categories;
                cmbCategory.DisplayMember = "Name";
                cmbCategory.ValueMember = "Id";
            }
        }

        private void LoadProducts(string search = "")
        {
            var products = _productRepo.GetAllProducts();
            if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(p => p.Name.Contains(search, StringComparison.OrdinalIgnoreCase) || 
                                               (p.Code?.Contains(search, StringComparison.OrdinalIgnoreCase) ?? false));
            }
            dgvProducts.DataSource = products.ToList();
            
            // Translate headers
            if (dgvProducts.Columns["Code"] != null) dgvProducts.Columns["Code"].HeaderText = "รหัส";
            if (dgvProducts.Columns["Name"] != null) dgvProducts.Columns["Name"].HeaderText = "ชื่อสินค้า";
            if (dgvProducts.Columns["CategoryName"] != null) dgvProducts.Columns["CategoryName"].HeaderText = "หมวดหมู่";
            if (dgvProducts.Columns["Price"] != null) dgvProducts.Columns["Price"].HeaderText = "ราคา";
            if (dgvProducts.Columns["StockQuantity"] != null) dgvProducts.Columns["StockQuantity"].HeaderText = "คงเหลือ";
            if (dgvProducts.Columns["Description"] != null) dgvProducts.Columns["Description"].HeaderText = "รายละเอียด";
            if (dgvProducts.Columns["IsDeleted"] != null) dgvProducts.Columns["IsDeleted"].Visible = false;
            if (dgvProducts.Columns["CreatedAt"] != null) dgvProducts.Columns["CreatedAt"].Visible = false;
            if (dgvProducts.Columns["CategoryId"] != null) dgvProducts.Columns["CategoryId"].Visible = false;
            if (dgvProducts.Columns["Id"] != null) dgvProducts.Columns["Id"].Visible = false;
        }

        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            LoadProducts(txtSearchProduct.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if(cmbCategory.SelectedValue == null) 
                {
                    MessageBox.Show("กรุณาเลือกหมวดหมู่");
                    return;
                }

                var product = new Product
                {
                    Code = txtCode.Text,
                    Name = txtName.Text,
                    Price = string.IsNullOrEmpty(txtPrice.Text) ? 0 : decimal.Parse(txtPrice.Text),
                    StockQuantity = string.IsNullOrEmpty(txtStockQty.Text) ? 0 : int.Parse(txtStockQty.Text),
                    CategoryId = (int)cmbCategory.SelectedValue,
                    Description = txtDescription.Text
                };
                _productRepo.AddProduct(product);
                MessageBox.Show("เพิ่มสินค้าเรียบร้อยแล้ว!");
                LoadProducts();
                ClearProductInputs();
                LoadPOSProducts(); // Refresh POS list
            }
            catch (Exception ex)
            {
                MessageBox.Show($"เกิดข้อผิดพลาดในการเพิ่มสินค้า: {ex.Message}");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
             if (dgvProducts.SelectedRows.Count == 0 || dgvProducts.SelectedRows[0].DataBoundItem == null) return;
             var selected = (Product)dgvProducts.SelectedRows[0].DataBoundItem;

             try
            {
                selected.Code = txtCode.Text;
                selected.Name = txtName.Text;
                selected.Price = string.IsNullOrEmpty(txtPrice.Text) ? 0 : decimal.Parse(txtPrice.Text);
                selected.StockQuantity = string.IsNullOrEmpty(txtStockQty.Text) ? 0 : int.Parse(txtStockQty.Text);
                selected.CategoryId = (int)cmbCategory.SelectedValue;
                selected.Description = txtDescription.Text;

                _productRepo.UpdateProduct(selected);
                MessageBox.Show("อัปเดตสินค้าเรียบร้อยแล้ว!");
                LoadProducts();
                ClearProductInputs();
                LoadPOSProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"เกิดข้อผิดพลาดในการอัปเดตสินค้า: {ex.Message}");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
             if (dgvProducts.SelectedRows.Count == 0) return;
             if (MessageBox.Show("คุณแน่ใจหรือไม่ว่าต้องการลบสินค้านี้?", "ยืนยัน", MessageBoxButtons.YesNo) == DialogResult.Yes)
             {
                 var selected = (Product)dgvProducts.SelectedRows[0].DataBoundItem;
                 _productRepo.DeleteProduct(selected.Id);
                 LoadProducts();
                 ClearProductInputs();
                 LoadPOSProducts();
             }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearProductInputs();
        }

        private void ClearProductInputs()
        {
            txtCode.Clear();
            txtName.Clear();
            txtPrice.Clear();
            txtStockQty.Clear();
            txtDescription.Clear();
            if(cmbCategory.Items.Count > 0) cmbCategory.SelectedIndex = 0;
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvProducts.Rows.Count)
            {
                var row = dgvProducts.Rows[e.RowIndex];
                if (row.DataBoundItem is Product product)
                {
                    txtCode.Text = product.Code;
                    txtName.Text = product.Name;
                    txtPrice.Text = product.Price.ToString();
                    txtStockQty.Text = product.StockQuantity.ToString();
                    txtDescription.Text = product.Description;
                    cmbCategory.SelectedValue = product.CategoryId;
                }
            }
        }
        
        private void btnImport_Click(object sender, EventArgs e) 
        {
            MessageBox.Show("ฟีเจอร์นำเข้าข้อมูลยังไม่พร้อมใช้งาน");
        }
        
        private void btnExport_Click(object sender, EventArgs e)
        {
             MessageBox.Show("ฟีเจอร์ส่งออกข้อมูลยังไม่พร้อมใช้งาน");
        }

        // ================= POS =================

        private void LoadPOSProducts()
        {
            _allProducts = _productRepo.GetAllProducts().Where(p => p.StockQuantity > 0).ToList();
            cmbPOSProduct.DataSource = _allProducts;
            cmbPOSProduct.DisplayMember = "Name";
            cmbPOSProduct.ValueMember = "Id";
        }

        private void SetupCartGrid()
        {
            dgvCart.AutoGenerateColumns = false;
            dgvCart.DataSource = _cartItems;
            
            if(dgvCart.Columns.Count == 0)
            {
                dgvCart.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ProductName", HeaderText = "สินค้า" });
                dgvCart.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "UnitPrice", HeaderText = "ราคา" });
                dgvCart.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Quantity", HeaderText = "จำนวน" });
                dgvCart.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SubTotal", HeaderText = "รวม" });
            }
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (cmbPOSProduct.SelectedItem == null) return;
            var product = (Product)cmbPOSProduct.SelectedItem;
            var qty = (int)numPOSQty.Value;

            if (qty > product.StockQuantity)
            {
                MessageBox.Show($"สินค้าไม่เพียงพอ! มีอยู่: {product.StockQuantity}");
                return;
            }

            var existingItem = _cartItems.FirstOrDefault(i => i.ProductId == product.Id);
            if (existingItem != null)
            {
                if (existingItem.Quantity + qty > product.StockQuantity)
                {
                     MessageBox.Show($"ไม่สามารถเพิ่มได้อีก สินค้าหมดสต็อกแล้ว");
                     return;
                }
                existingItem.Quantity += qty;
                _cartItems.ResetBindings();
            }
            else
            {
                _cartItems.Add(new TransactionItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    UnitPrice = product.Price,
                    Quantity = qty
                });
            }
            UpdatePOSTotal();
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            _cartItems.Clear();
            UpdatePOSTotal();
        }

        private void UpdatePOSTotal()
        {
            decimal total = _cartItems.Sum(i => i.SubTotal);
            lblPOSTotal.Text = $"รวมทั้งหมด: {total:N2}";
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (_cartItems.Count == 0)
            {
                MessageBox.Show("ตะกร้าสินค้าว่างเปล่า!");
                return;
            }

            try
            {
                var transaction = new Transaction
                {
                    TotalAmount = _cartItems.Sum(i => i.SubTotal),
                    Tax = 0, // Implement tax logic if needed
                    NetTotal = _cartItems.Sum(i => i.SubTotal),
                    Date = DateTime.Now
                };

                int transId = _transactionRepo.CreateTransaction(transaction, _cartItems.ToList());
                transaction.Id = transId;

                // Generate Receipt
                string fileName = $"Receipt_{transId}_{DateTime.Now:yyyyMMddHHmmss}.pdf";
                string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
                _receiptService.GenerateReceipt(transaction, _cartItems.ToList(), fullPath);

                MessageBox.Show($"ทำรายการสำเร็จ! บันทึกใบเสร็จที่ {fileName}");
                
                // Open Receipt
                try 
                {
                    new Process { StartInfo = new ProcessStartInfo(fullPath) { UseShellExecute = true } }.Start();
                }
                catch (Exception ex) 
                {
                     // Improve error handling if no PDF viewer
                     MessageBox.Show("สร้างใบเสร็จแล้วแต่ไม่สามารถเปิดได้โดยอัตโนมัติ: " + ex.Message);
                }

                _cartItems.Clear();
                UpdatePOSTotal();
                LoadPOSProducts(); // Refresh stock
                LoadProducts(); // Refresh management view
            }
            catch (Exception ex)
            {
                MessageBox.Show($"การชำระเงินล้มเหลว: {ex.Message}");
            }
        }

        // ================= REPORTS =================

        private void btnSalesReport_Click(object sender, EventArgs e)
        {
            try
            {
                var transactions = _transactionRepo.GetAllTransactions().ToList();
                var reportService = new ReportService();
                string fileName = $"SalesReport_{DateTime.Now:yyyyMMddHHmmss}.pdf";
                string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
                
                reportService.GenerateSalesReport(transactions, fullPath);
                
                new Process { StartInfo = new ProcessStartInfo(fullPath) { UseShellExecute = true } }.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการสร้างรายงาน: " + ex.Message);
            }
        }

        private void btnInventoryReport_Click(object sender, EventArgs e)
        {
             try
            {
                var products = _productRepo.GetAllProducts().ToList();
                var reportService = new ReportService();
                string fileName = $"InventoryReport_{DateTime.Now:yyyyMMddHHmmss}.pdf";
                string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
                
                reportService.GenerateInventoryReport(products, fullPath);
                
                new Process { StartInfo = new ProcessStartInfo(fullPath) { UseShellExecute = true } }.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการสร้างรายงาน: " + ex.Message);
            }
        }
    }
}
