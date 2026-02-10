using System;
using System.Collections.Generic;
using System.Linq;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using D3.Models;

namespace D3.Services
{
    public class ReportService
    {
        public void GenerateInventoryReport(List<Product> products, string filePath)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(10));

                    page.Header().Text("รายงานสินค้าคงคลัง").SemiBold().FontSize(20).AlignCenter();

                    page.Content().PaddingVertical(1, Unit.Centimetre).Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.RelativeColumn(3);
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });

                        table.Header(header =>
                        {
                            header.Cell().Element(CellStyle).Text("รหัส");
                            header.Cell().Element(CellStyle).Text("ชื่อสินค้า");
                            header.Cell().Element(CellStyle).Text("หมวดหมู่");
                            header.Cell().Element(CellStyle).AlignRight().Text("ราคา");
                            header.Cell().Element(CellStyle).AlignRight().Text("คงเหลือ");

                            static IContainer CellStyle(IContainer container)
                            {
                                return container.DefaultTextStyle(x => x.SemiBold()).PaddingVertical(5).BorderBottom(1).BorderColor(Colors.Grey.Lighten2);
                            }
                        });

                        foreach (var product in products)
                        {
                            table.Cell().Element(CellStyle).Text(product.Code);
                            table.Cell().Element(CellStyle).Text(product.Name);
                            table.Cell().Element(CellStyle).Text(product.CategoryName);
                            table.Cell().Element(CellStyle).AlignRight().Text($"{product.Price:N2}");
                            
                            // Highlight low stock
                            if(product.StockQuantity < 5)
                                table.Cell().Element(CellStyle).Element(c => c.Background(Colors.Red.Lighten4)).AlignRight().Text(product.StockQuantity.ToString());
                            else
                                table.Cell().Element(CellStyle).AlignRight().Text(product.StockQuantity.ToString());

                            static IContainer CellStyle(IContainer container)
                            {
                                return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten3).PaddingVertical(5);
                            }
                        }
                    });
                     
                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.Span("สร้างเมื่อ " + DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
                        x.CurrentPageNumber();
                    });
                });
            })
            .GeneratePdf(filePath);
        }

        public void GenerateSalesReport(List<Transaction> transactions, string filePath)
        {
             QuestPDF.Settings.License = LicenseType.Community;

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(10));

                    page.Header().Text("รายงานการขาย").SemiBold().FontSize(20).AlignCenter();

                    page.Content().PaddingVertical(1, Unit.Centimetre).Column(col => 
                    {
                        col.Item().Text($"จำนวนรายการทั้งหมด: {transactions.Count}");
                        col.Item().Text($"รายได้รวม: {transactions.Sum(t => t.TotalAmount):N2}");
                        col.Item().PaddingBottom(10).LineHorizontal(1);

                        col.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            table.Header(header =>
                            {
                                header.Cell().Element(CellStyle).Text("วันที่");
                                header.Cell().Element(CellStyle).Text("เลขที่รายการ");
                                header.Cell().Element(CellStyle).AlignRight().Text("ยอดเงิน");

                                static IContainer CellStyle(IContainer container)
                                {
                                    return container.DefaultTextStyle(x => x.SemiBold()).PaddingVertical(5).BorderBottom(1).BorderColor(Colors.Grey.Lighten2);
                                }
                            });

                            foreach (var tran in transactions)
                            {
                                table.Cell().Element(CellStyle).Text(tran.Date.ToString("yyyy-MM-dd HH:mm"));
                                table.Cell().Element(CellStyle).Text(tran.Id.ToString());
                                table.Cell().Element(CellStyle).AlignRight().Text($"{tran.TotalAmount:N2}");

                                static IContainer CellStyle(IContainer container)
                                {
                                    return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten3).PaddingVertical(5);
                                }
                            }
                        });
                    });

                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.Span("สร้างเมื่อ " + DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
                        x.CurrentPageNumber();
                    });
                });
            })
            .GeneratePdf(filePath);
        }
    }
}
