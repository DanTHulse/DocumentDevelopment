using DinkToPdf;

namespace DocumentDevelopment.Utils.Models
{
    public class PdfDocument
    {
        public string Title { get; set; }
        public string Html { get; set; }
        public Orientation Orientation { get; set; }
        public PaperKind PaperKind { get; set; }
        public double MarginCm { get; set; }
        public double Zoom { get; set; }
    }
}
