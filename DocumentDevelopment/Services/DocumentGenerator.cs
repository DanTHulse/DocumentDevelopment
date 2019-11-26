using System.IO;
using System.Threading.Tasks;
using DinkToPdf;
using DocumentDevelopment.Services.Interfaces;
using DocumentDevelopment.Utils.Interfaces;
using DocumentDevelopment.Utils.Models;
using DocumentDevelopment.Utils.Render.Interfaces;
using DocumentDevelopment.ViewModels;

namespace DocumentDevelopment.Services
{
    public class DocumentGenerator : IDocumentGenerator
    {
        private readonly ITemplateRenderer _templateRenderer;
        private readonly IPdfGenerator _pdfGenerator;

        public DocumentGenerator(ITemplateRenderer templateRenderer,
            IPdfGenerator pdfGenerator)
        {
            _templateRenderer = templateRenderer;
            _pdfGenerator = pdfGenerator;
        }

        public async Task<string> CreateDocument(DataModel data, PaperworkType paperworkType, bool generateHtml)
        {
            var htmlModel = await _templateRenderer.Render(paperworkType.ToString(), data);

            var pdfSettings = new PdfDocument
            {
                Html = htmlModel,
                MarginCm = 0.5,
                Orientation = Orientation.Landscape,
                PaperKind = PaperKind.A4,
                Title = paperworkType.ToString(),
                Zoom = 1.27
            };

            var filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Documents\\PDF");

            using (var pdf = _pdfGenerator.GeneratePdf(pdfSettings))
            {
                if (File.Exists($"{filePath}\\{paperworkType}.pdf"))
                {
                    File.Delete($"{filePath}\\{paperworkType}.pdf");
                }

                using var fs = File.OpenWrite($"{filePath}\\{paperworkType}.pdf");
                pdf.CopyTo(fs);
            }

            if (generateHtml)
            {
                RegenerateHtml(htmlModel, paperworkType);
            }

            return htmlModel;
        }

        private void RegenerateHtml(string html, PaperworkType paperworkType)
        {
            var filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Documents\\Pages\\HTML");

            var filename = $"{filePath}\\{paperworkType}.html";
            File.WriteAllText(filename, html);
        }
    }
}
