
namespace D3
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabProducts = new System.Windows.Forms.TabPage();
            this.panelProductControls = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.txtSearchProduct = new System.Windows.Forms.TextBox();
            this.btnSearchProduct = new System.Windows.Forms.Button();
            this.grpProductDetails = new System.Windows.Forms.GroupBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.txtStockQty = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.tabPOS = new System.Windows.Forms.TabPage();
            this.splitContainerPOS = new System.Windows.Forms.SplitContainer();
            this.grpCart = new System.Windows.Forms.GroupBox();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.panelPOSRight = new System.Windows.Forms.Panel();
            this.lblPOSTotal = new System.Windows.Forms.Label();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.btnClearCart = new System.Windows.Forms.Button();
            this.grpPOSSearch = new System.Windows.Forms.GroupBox();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.numPOSQty = new System.Windows.Forms.NumericUpDown();
            this.lblPOSQty = new System.Windows.Forms.Label();
            this.cmbPOSProduct = new System.Windows.Forms.ComboBox();
            this.lblPOSProduct = new System.Windows.Forms.Label();
            this.tabReports = new System.Windows.Forms.TabPage();
            this.btnInventoryReport = new System.Windows.Forms.Button();
            this.btnSalesReport = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabProducts.SuspendLayout();
            this.panelProductControls.SuspendLayout();
            this.grpProductDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.tabPOS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerPOS)).BeginInit();
            this.splitContainerPOS.Panel1.SuspendLayout();
            this.splitContainerPOS.Panel2.SuspendLayout();
            this.splitContainerPOS.SuspendLayout();
            this.grpCart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.panelPOSRight.SuspendLayout();
            this.grpPOSSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPOSQty)).BeginInit();
            this.tabReports.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabProducts);
            this.tabControl1.Controls.Add(this.tabPOS);
            this.tabControl1.Controls.Add(this.tabReports);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1008, 601);
            this.tabControl1.TabIndex = 0;
            // 
            // tabProducts
            // 
            this.tabProducts.Controls.Add(this.dgvProducts);
            this.tabProducts.Controls.Add(this.panelProductControls);
            this.tabProducts.Location = new System.Drawing.Point(4, 24);
            this.tabProducts.Name = "tabProducts";
            this.tabProducts.Padding = new System.Windows.Forms.Padding(3);
            this.tabProducts.Size = new System.Drawing.Size(1000, 573);
            this.tabProducts.TabIndex = 0;
            this.tabProducts.Text = "Product Management";
            this.tabProducts.UseVisualStyleBackColor = true;
            // 
            // panelProductControls
            // 
            this.panelProductControls.Controls.Add(this.grpProductDetails);
            this.panelProductControls.Controls.Add(this.btnSearchProduct);
            this.panelProductControls.Controls.Add(this.txtSearchProduct);
             this.panelProductControls.Controls.Add(this.btnImport);
            this.panelProductControls.Controls.Add(this.btnExport);
            this.panelProductControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelProductControls.Location = new System.Drawing.Point(3, 3);
            this.panelProductControls.Name = "panelProductControls";
            this.panelProductControls.Size = new System.Drawing.Size(994, 220);
            this.panelProductControls.TabIndex = 0;
            // 
            // grpProductDetails
            // 
            this.grpProductDetails.Controls.Add(this.lblDesc);
            this.grpProductDetails.Controls.Add(this.txtDescription);
            this.grpProductDetails.Controls.Add(this.btnClear);
            this.grpProductDetails.Controls.Add(this.btnDelete);
            this.grpProductDetails.Controls.Add(this.btnUpdate);
            this.grpProductDetails.Controls.Add(this.btnAdd);
            this.grpProductDetails.Controls.Add(this.lblCategory);
            this.grpProductDetails.Controls.Add(this.cmbCategory);
            this.grpProductDetails.Controls.Add(this.lblQty);
            this.grpProductDetails.Controls.Add(this.txtStockQty);
            this.grpProductDetails.Controls.Add(this.lblPrice);
            this.grpProductDetails.Controls.Add(this.txtPrice);
            this.grpProductDetails.Controls.Add(this.lblCode);
            this.grpProductDetails.Controls.Add(this.txtCode);
            this.grpProductDetails.Controls.Add(this.lblName);
            this.grpProductDetails.Controls.Add(this.txtName);
            this.grpProductDetails.Location = new System.Drawing.Point(5, 5);
            this.grpProductDetails.Name = "grpProductDetails";
            this.grpProductDetails.Size = new System.Drawing.Size(780, 170);
            this.grpProductDetails.TabIndex = 2;
            this.grpProductDetails.TabStop = false;
            this.grpProductDetails.Text = "Product Details";
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(260, 25);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(70, 15);
            this.lblDesc.TabIndex = 15;
            this.lblDesc.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(340, 22);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(200, 80);
            this.txtDescription.TabIndex = 14;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(360, 120);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(260, 120);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(160, 120);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(60, 120);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(10, 85);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(58, 15);
            this.lblCategory.TabIndex = 9;
            this.lblCategory.Text = "Category:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(80, 82);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(150, 23);
            this.cmbCategory.TabIndex = 8;
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Location = new System.Drawing.Point(560, 55);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(56, 15);
            this.lblQty.TabIndex = 7;
            this.lblQty.Text = "Quantity:";
            // 
            // txtStockQty
            // 
            this.txtStockQty.Location = new System.Drawing.Point(630, 52);
            this.txtStockQty.Name = "txtStockQty";
            this.txtStockQty.Size = new System.Drawing.Size(100, 23);
            this.txtStockQty.TabIndex = 6;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(560, 25);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(36, 15);
            this.lblPrice.TabIndex = 5;
            this.lblPrice.Text = "Price:";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(630, 22);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(100, 23);
            this.txtPrice.TabIndex = 4;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(10, 55);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(38, 15);
            this.lblCode.TabIndex = 3;
            this.lblCode.Text = "Code:";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(80, 52);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(150, 23);
            this.txtCode.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(10, 25);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(42, 15);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(80, 22);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(150, 23);
            this.txtName.TabIndex = 0;
            // 
            // btnSearchProduct
            // 
            this.btnSearchProduct.Location = new System.Drawing.Point(215, 185);
            this.btnSearchProduct.Name = "btnSearchProduct";
            this.btnSearchProduct.Size = new System.Drawing.Size(75, 23);
            this.btnSearchProduct.TabIndex = 1;
            this.btnSearchProduct.Text = "Search";
            this.btnSearchProduct.UseVisualStyleBackColor = true;
            this.btnSearchProduct.Click += new System.EventHandler(this.btnSearchProduct_Click);
            // 
            // txtSearchProduct
            // 
            this.txtSearchProduct.Location = new System.Drawing.Point(5, 185);
            this.txtSearchProduct.Name = "txtSearchProduct";
            this.txtSearchProduct.PlaceholderText = "Search by Name or Code...";
            this.txtSearchProduct.Size = new System.Drawing.Size(200, 23);
            this.txtSearchProduct.TabIndex = 0;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(800, 20);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 17;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(800, 50);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 16;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // dgvProducts
            // 
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducts.Location = new System.Drawing.Point(3, 223);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.RowTemplate.Height = 25;
            this.dgvProducts.Size = new System.Drawing.Size(994, 347);
            this.dgvProducts.TabIndex = 1;
            this.dgvProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellClick);
            // 
            // tabPOS
            // 
            this.tabPOS.Controls.Add(this.splitContainerPOS);
            this.tabPOS.Location = new System.Drawing.Point(4, 24);
            this.tabPOS.Name = "tabPOS";
            this.tabPOS.Padding = new System.Windows.Forms.Padding(3);
            this.tabPOS.Size = new System.Drawing.Size(1000, 573);
            this.tabPOS.TabIndex = 1;
            this.tabPOS.Text = "Point of Sale";
            this.tabPOS.UseVisualStyleBackColor = true;
            // 
            // splitContainerPOS
            // 
            this.splitContainerPOS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerPOS.Location = new System.Drawing.Point(3, 3);
            this.splitContainerPOS.Name = "splitContainerPOS";
            // 
            // splitContainerPOS.Panel1
            // 
            this.splitContainerPOS.Panel1.Controls.Add(this.grpCart);
            // 
            // splitContainerPOS.Panel2
            // 
            this.splitContainerPOS.Panel2.Controls.Add(this.panelPOSRight);
            this.splitContainerPOS.Panel2.Controls.Add(this.grpPOSSearch);
            this.splitContainerPOS.Size = new System.Drawing.Size(994, 567);
            this.splitContainerPOS.SplitterDistance = 650;
            this.splitContainerPOS.TabIndex = 0;
            // 
            // grpCart
            // 
            this.grpCart.Controls.Add(this.dgvCart);
            this.grpCart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCart.Location = new System.Drawing.Point(0, 0);
            this.grpCart.Name = "grpCart";
            this.grpCart.Size = new System.Drawing.Size(650, 567);
            this.grpCart.TabIndex = 0;
            this.grpCart.TabStop = false;
            this.grpCart.Text = "Shopping Cart";
            // 
            // dgvCart
            // 
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCart.Location = new System.Drawing.Point(3, 19);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.RowTemplate.Height = 25;
            this.dgvCart.Size = new System.Drawing.Size(644, 545);
            this.dgvCart.TabIndex = 0;
            // 
            // panelPOSRight
            // 
            this.panelPOSRight.Controls.Add(this.lblPOSTotal);
            this.panelPOSRight.Controls.Add(this.btnCheckout);
            this.panelPOSRight.Controls.Add(this.btnClearCart);
            this.panelPOSRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPOSRight.Location = new System.Drawing.Point(0, 150);
            this.panelPOSRight.Name = "panelPOSRight";
            this.panelPOSRight.Size = new System.Drawing.Size(340, 417);
            this.panelPOSRight.TabIndex = 1;
            // 
            // lblPOSTotal
            // 
            this.lblPOSTotal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPOSTotal.Location = new System.Drawing.Point(10, 20);
            this.lblPOSTotal.Name = "lblPOSTotal";
            this.lblPOSTotal.Size = new System.Drawing.Size(320, 40);
            this.lblPOSTotal.TabIndex = 2;
            this.lblPOSTotal.Text = "Total: 0.00";
            this.lblPOSTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCheckout
            // 
            this.btnCheckout.BackColor = System.Drawing.Color.LightGreen;
            this.btnCheckout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCheckout.Location = new System.Drawing.Point(50, 80);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(240, 60);
            this.btnCheckout.TabIndex = 1;
            this.btnCheckout.Text = "Checkout (Print Receipt)";
            this.btnCheckout.UseVisualStyleBackColor = false;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // btnClearCart
            // 
            this.btnClearCart.Location = new System.Drawing.Point(50, 160);
            this.btnClearCart.Name = "btnClearCart";
            this.btnClearCart.Size = new System.Drawing.Size(240, 40);
            this.btnClearCart.TabIndex = 0;
            this.btnClearCart.Text = "Clear Cart";
            this.btnClearCart.UseVisualStyleBackColor = true;
            this.btnClearCart.Click += new System.EventHandler(this.btnClearCart_Click);
            // 
            // grpPOSSearch
            // 
            this.grpPOSSearch.Controls.Add(this.btnAddToCart);
            this.grpPOSSearch.Controls.Add(this.numPOSQty);
            this.grpPOSSearch.Controls.Add(this.lblPOSQty);
            this.grpPOSSearch.Controls.Add(this.cmbPOSProduct);
            this.grpPOSSearch.Controls.Add(this.lblPOSProduct);
            this.grpPOSSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpPOSSearch.Location = new System.Drawing.Point(0, 0);
            this.grpPOSSearch.Name = "grpPOSSearch";
            this.grpPOSSearch.Size = new System.Drawing.Size(340, 150);
            this.grpPOSSearch.TabIndex = 0;
            this.grpPOSSearch.TabStop = false;
            this.grpPOSSearch.Text = "Add Item";
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.Location = new System.Drawing.Point(100, 100);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(140, 30);
            this.btnAddToCart.TabIndex = 4;
            this.btnAddToCart.Text = "Add to Cart";
            this.btnAddToCart.UseVisualStyleBackColor = true;
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);
            // 
            // numPOSQty
            // 
            this.numPOSQty.Location = new System.Drawing.Point(100, 60);
            this.numPOSQty.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numPOSQty.Name = "numPOSQty";
            this.numPOSQty.Size = new System.Drawing.Size(80, 23);
            this.numPOSQty.TabIndex = 3;
            this.numPOSQty.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblPOSQty
            // 
            this.lblPOSQty.AutoSize = true;
            this.lblPOSQty.Location = new System.Drawing.Point(20, 62);
            this.lblPOSQty.Name = "lblPOSQty";
            this.lblPOSQty.Size = new System.Drawing.Size(29, 15);
            this.lblPOSQty.TabIndex = 2;
            this.lblPOSQty.Text = "Qty:";
            // 
            // cmbPOSProduct
            // 
            this.cmbPOSProduct.FormattingEnabled = true;
            this.cmbPOSProduct.Location = new System.Drawing.Point(100, 25);
            this.cmbPOSProduct.Name = "cmbPOSProduct";
            this.cmbPOSProduct.Size = new System.Drawing.Size(200, 23);
            this.cmbPOSProduct.TabIndex = 1;
            // 
            // lblPOSProduct
            // 
            this.lblPOSProduct.AutoSize = true;
            this.lblPOSProduct.Location = new System.Drawing.Point(20, 28);
            this.lblPOSProduct.Name = "lblPOSProduct";
            this.lblPOSProduct.Size = new System.Drawing.Size(52, 15);
            this.lblPOSProduct.TabIndex = 0;
            this.lblPOSProduct.Text = "Product:";
            // 
            // tabReports
            // 
            this.tabReports.Controls.Add(this.btnInventoryReport);
            this.tabReports.Controls.Add(this.btnSalesReport);
            this.tabReports.Location = new System.Drawing.Point(4, 24);
            this.tabReports.Name = "tabReports";
            this.tabReports.Padding = new System.Windows.Forms.Padding(3);
            this.tabReports.Size = new System.Drawing.Size(1000, 573);
            this.tabReports.TabIndex = 2;
            this.tabReports.Text = "Reports";
            this.tabReports.UseVisualStyleBackColor = true;
            // 
            // btnInventoryReport
            // 
            this.btnInventoryReport.Location = new System.Drawing.Point(50, 100);
            this.btnInventoryReport.Name = "btnInventoryReport";
            this.btnInventoryReport.Size = new System.Drawing.Size(200, 50);
            this.btnInventoryReport.TabIndex = 1;
            this.btnInventoryReport.Text = "Generate Inventory Report";
            this.btnInventoryReport.UseVisualStyleBackColor = true;
            this.btnInventoryReport.Click += new System.EventHandler(this.btnInventoryReport_Click);
            // 
            // btnSalesReport
            // 
            this.btnSalesReport.Location = new System.Drawing.Point(50, 30);
            this.btnSalesReport.Name = "btnSalesReport";
            this.btnSalesReport.Size = new System.Drawing.Size(200, 50);
            this.btnSalesReport.TabIndex = 0;
            this.btnSalesReport.Text = "Generate Sales Report";
            this.btnSalesReport.UseVisualStyleBackColor = true;
            this.btnSalesReport.Click += new System.EventHandler(this.btnSalesReport_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 601);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Music Shop Management System";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabProducts.ResumeLayout(false);
            this.panelProductControls.ResumeLayout(false);
            this.panelProductControls.PerformLayout();
            this.grpProductDetails.ResumeLayout(false);
            this.grpProductDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.tabPOS.ResumeLayout(false);
            this.splitContainerPOS.Panel1.ResumeLayout(false);
            this.splitContainerPOS.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerPOS)).EndInit();
            this.splitContainerPOS.ResumeLayout(false);
            this.grpCart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.panelPOSRight.ResumeLayout(false);
            this.grpPOSSearch.ResumeLayout(false);
            this.grpPOSSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPOSQty)).EndInit();
            this.tabReports.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabProducts;
        private System.Windows.Forms.TabPage tabPOS;
        private System.Windows.Forms.TabPage tabReports;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Panel panelProductControls;
        private System.Windows.Forms.GroupBox grpProductDetails;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.TextBox txtStockQty;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSearchProduct;
        private System.Windows.Forms.TextBox txtSearchProduct;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.SplitContainer splitContainerPOS;
        private System.Windows.Forms.GroupBox grpCart;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.GroupBox grpPOSSearch;
        private System.Windows.Forms.ComboBox cmbPOSProduct;
        private System.Windows.Forms.Label lblPOSProduct;
        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.NumericUpDown numPOSQty;
        private System.Windows.Forms.Label lblPOSQty;
        private System.Windows.Forms.Panel panelPOSRight;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Button btnClearCart;
        private System.Windows.Forms.Label lblPOSTotal;
        private System.Windows.Forms.Button btnInventoryReport;
        private System.Windows.Forms.Button btnSalesReport;
    }
}
