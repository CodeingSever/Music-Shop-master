using System;
using System.IO;
using System.Linq;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using D3.Models;
using System.Collections.Generic;

namespace D3.Services
{
    public class ReceiptService
    {
        public void GenerateReceipt(Transaction transaction, List<TransactionItem> items, string filePath)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A5);
                    page.Margin(1, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(10));

                    page.Header()
                        .Text("ใบเสร็จรับเงิน")
                        .SemiBold().FontSize(20).AlignCenter();

                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Column(x =>
                        {
                            x.Item().Text($"วันที่: {transaction.Date:yyyy-MM-dd HH:mm:ss}");
                            x.Item().Text($"เลขที่รายการ: #{transaction.Id}");
                            x.Item().PaddingBottom(5).LineHorizontal(1);

                            x.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(3);
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                });

                                table.Header(header =>
                                {
                                    header.Cell().Element(CellStyle).Text("สินค้า");
                                    header.Cell().Element(CellStyle).AlignRight().Text("ราคา");
                                    header.Cell().Element(CellStyle).AlignRight().Text("จำนวน");
                                    header.Cell().Element(CellStyle).AlignRight().Text("รวม");

                                    static IContainer CellStyle(IContainer container)
                                    {
                                        return container.DefaultTextStyle(x => x.SemiBold()).PaddingVertical(2).BorderBottom(1).BorderColor(Colors.Grey.Lighten2);
                                    }
                                });

                                foreach (var item in items)
                                {
                                    table.Cell().Element(CellStyle).Text(item.ProductName);
                                    table.Cell().Element(CellStyle).AlignRight().Text($"{item.UnitPrice:N2}");
                                    table.Cell().Element(CellStyle).AlignRight().Text(item.Quantity.ToString());
                                    table.Cell().Element(CellStyle).AlignRight().Text($"{item.SubTotal:N2}");

                                    static IContainer CellStyle(IContainer container)
                                    {
                                        return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten3).PaddingVertical(2);
                                    }
                                }
                            });

                            x.Item().PaddingTop(5).LineHorizontal(1);
                            x.Item().AlignRight().Text($"รวมเป็นเงิน: {transaction.TotalAmount:N2}");
                            x.Item().AlignRight().Text($"ภาษี: {transaction.Tax:N2}");
                            x.Item().AlignRight().Text($"ยอดสุทธิ: {transaction.NetTotal:N2}").SemiBold().FontSize(14);
                        });

                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("ขอบคุณที่ใช้บริการ!");
                            x.CurrentPageNumber();
                        });
                });
            })
            .GeneratePdf(filePath);
        }
    }
}
