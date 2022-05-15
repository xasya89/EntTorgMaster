using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.JSInterop;
using EntTorgMaster.Data;

namespace EntTorgMaster.Services
{
    public static class PDFGenerate
    {
        public static void GenerateNaryad(IJSRuntime js, List<Order> orders)
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

            pdf.AddTitle("Blazor-PDF");
            pdf.AddAuthor("Christophe Peugnet");
            pdf.AddCreationDate();
            pdf.AddKeywords("blazor");
            pdf.AddSubject("Create a pdf file with iText");

            PdfWriter writer = PdfWriter.GetInstance(pdf, memoryStream);

            //HEADER and FOOTER

            var fontStyle = FontFactory.GetFont("Arial", 16, BaseColor.White);
            var labelHeader = new Chunk("Header Blazor PDF", fontStyle);
            HeaderFooter header = new HeaderFooter(new Phrase(labelHeader), false)
            {
                BackgroundColor = new BaseColor(133, 76, 199),
                Alignment = Element.ALIGN_CENTER,
                Border = iTextSharp.text.Rectangle.NO_BORDER
            };
            //header.Border = Rectangle.NO_BORDER;
            //pdf.Header = header;


            var labelFooter = new Chunk("Page", fontStyle);
            HeaderFooter footer = new HeaderFooter(new Phrase(labelFooter), true)
            {
                Border = iTextSharp.text.Rectangle.NO_BORDER,
                Alignment = Element.ALIGN_RIGHT
            };
            //pdf.Footer = footer;

            pdf.Open();

            var title = new Paragraph("Text and Paragraphe", new Font(Font.HELVETICA, 20, Font.BOLD));
            title.SetAlignment("right");
            

            
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(@"d:\1.jpg");
            title.Add(image);
            pdf.Add(image);
            pdf.Add(labelHeader);

            pdf.Close();

            memoryStream.ToArray();
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
