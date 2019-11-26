using System.IO;
using DinkToPdf;
using DinkToPdf.Contracts;
using DocumentDevelopment.Utils.Interfaces;
using DocumentDevelopment.Utils.Models;

namespace DocumentDevelopment.Utils
{
    public class PdfGenerator : IPdfGenerator
    {
        private readonly IConverter _converter;

        public PdfGenerator(IConverter converter)
        {
            _converter = converter;
        }

        public Stream GeneratePdf(PdfDocument document)
        {
            // 1. Create the configuration
            var doc = new HtmlToPdfDocument
            {
                GlobalSettings =
                {
                    ColorMode = ColorMode.Color,
                    Orientation = document.Orientation,
                    PaperSize = document.PaperKind,
                    DocumentTitle = document.Title,
                    Margins = new MarginSettings(document.MarginCm, document.MarginCm, document.MarginCm, document.MarginCm)
                    {
                        Unit = Unit.Centimeters
                    }
                },
                Objects =
                {
                    new ObjectSettings
                    {
                        HtmlContent = document.Html,
                        WebSettings =
                        {
                            DefaultEncoding = "utf-8"
                        },
                        LoadSettings = new LoadSettings
                        {
                            ZoomFactor = document.Zoom//1.27
                        }
                    }
                }
            };

            // 2. Convert the HTML into bytes
            var result = _converter.Convert(doc);

            // 3. Return the bytes as a memory stream
            return new MemoryStream(result);
        }
    }
}
