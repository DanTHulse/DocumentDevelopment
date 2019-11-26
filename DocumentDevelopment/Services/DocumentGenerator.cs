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

        public async Task<PaperworkType> CreateDocument(BaseTemplateModel templateModel, PaperworkType paperworkType)
        {
            var htmlModel = await _templateRenderer.Render(paperworkType.ToString(), templateModel);

            var pdfSettings = new PdfDocument
            {
                Html = htmlModel,
                MarginCm = 0.5,
                Orientation = Orientation.Landscape,
                PaperKind = PaperKind.A4,
                Title = paperworkType.ToString(),
                Zoom = 1.27
            };

            var filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Documents");

            using (var pdf = _pdfGenerator.GeneratePdf(pdfSettings))
            {
                if (File.Exists($"{filePath}\\{paperworkType}.pdf"))
                {
                    File.Delete($"{filePath}\\{paperworkType}.pdf");
                }

                using (var fs = File.OpenWrite($"{filePath}\\{paperworkType}.pdf"))
                {
                    pdf.CopyTo(fs);
                }
            }

            return paperworkType;
        }
    }
}
