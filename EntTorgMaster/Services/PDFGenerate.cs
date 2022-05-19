using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.JSInterop;
using EntTorgMaster.Helpers;
using EntTorgMaster.Data;

namespace EntTorgMaster.Services
{
    public static class PDFGenerate
    {
        public static void GenerateNaryad(IJSRuntime js, Order order)
        {
            var memoryStream = new MemoryStream();

            // Marge in centimeter, then I convert with .ToDpi()
            float margeLeft = 0.5f;
            float margeRight = 0.5f;
            float margeTop = 0.5f;
            float margeBottom = 0.5f;

            Document pdf = new Document(
                                    PageSize.A5,
                                    margeLeft.ToDpi(),
                                    margeRight.ToDpi(),
                                    margeTop.ToDpi(),
                                    margeBottom.ToDpi()
                                   );

            pdf.AddTitle(order.Shet);
            pdf.AddAuthor("Ent erp system");
            pdf.AddCreationDate();
            pdf.AddKeywords(order.Shet);
            pdf.AddSubject($"Счет {order.Shet} от {order.ShetDate?.ToString("dd.MM.yy")}");

            PdfWriter writer = PdfWriter.GetInstance(pdf, memoryStream);
            BaseFont baseFont = BaseFont.CreateFont(Path.Combine("Fonts", "calibri.ttf"), BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            pdf.Open();

            foreach (var door in order.OrderDoors)
            {
                ImageGenerate.Create(door);
                int shtild_numeric = 0;
                int.TryParse(door.Shild, out shtild_numeric);
                for (int naryad = 1; naryad <= door.Count; naryad++)
                {
                    string shtild = shtild_numeric==0 ? door.Shild : (shtild_numeric++).ToString();
                    //var title = new Paragraph(new Phrase(new Chunk($"Наряд заказ № {order.Shet}/{door.Position}/{naryad}", new Font(baseFont, 12f, Font.BOLD))));
                    //title.SetAlignment("center");
                    //pdf.Add(title);
                    string titleStr = $@"Наряд заказ № {order.Shet}/{door.Position}/{naryad}
Дверь {door.DoorType?.Name}

Счет: {order.Shet} от {order.ShetDate?.ToString("dd.MM.yy")} Заказчик: {order.CustomerName}
";
                    var pDoorName = new Paragraph(titleStr, new Font(baseFont, 14f, Font.BOLD));
                    pDoorName.SetAlignment("center");
                    pdf.Add(pDoorName);



                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(@"d:\1.png");

                    Table table = new Table(2);
                    table.Width = 100;
                    table.Cellpadding = 0;
                    table.Cellspacing = 0;
                    table.Padding = 0;
                    table.Spacing = 0;
                    table.SetWidths(new int[] { 40, 60 });
                    table.BorderColor = BaseColor.White;
                    table.BorderWidth = 0;
                    table.DefaultCellBorderWidth = 0;
                    table.AddCell(new Phrase(new Chunk(image, 0, 0)));
                    string sStr = door.SEqual ? "x равн" : door.S is not null ? "x " + door.S : "";
                    string text = @$"Размеры: {door.H} x {door.W} {sStr}
Открывание: {door.Open.GetEnumDescription()}
Окрас: {door.Ral}
Наличник: {door.Nalichnik.GetEnumDescription()}
Доводчик: {door.Dovod.GetEnumDescription()}
Шильда: {shtild}
";
                    Cell cell = new Cell();
                    cell.BorderWidth = 0;
                    cell.BorderColor = BaseColor.White;
                    cell.Add(new Phrase(text, new Font(baseFont, 12f)));
                    table.AddCell(cell);
                    pdf.Add(table);
                    pdf.Add(new Phrase(door.Note, new Font(baseFont, 10f)));
                    string stepsStr = $@"
Св ________________________ Стоимость _________
Сб ________________________ Стоимость _________
Пк ________________________ Стоимость _________
Уп ________________________ Стоимость _________
Пг ________________________ Стоимость _________";
                    pdf.Add(new Paragraph(stepsStr, new Font(baseFont, 12f)));
                    pdf.NewPage();
                }
            }
            //text = text.Replace(Environment.NewLine, String.Empty).Replace("  ", String.Empty);

            Font brown = new Font(Font.COURIER, 9f, Font.NORMAL);

            Font lightblue = new Font(Font.COURIER, 9f, Font.NORMAL);

            Font courier = new Font(Font.COURIER, 9f);

            Font georgia = FontFactory.GetFont("georgia", 10f);

            
            pdf.Close();

            js.InvokeVoidAsync("jsDownloadFile",
                            "Списбок нарядов.pdf",
                            memoryStream.ToArray()
                            );
        }

        public static float ToDpi(this float centimeter)
        {
            var inch = centimeter / 2.54;
            return (float)(inch * 72);
        }
    }
}
