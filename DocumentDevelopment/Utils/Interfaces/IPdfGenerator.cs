using System.IO;
using DocumentDevelopment.Utils.Models;

namespace DocumentDevelopment.Utils.Interfaces
{
    public interface IPdfGenerator
    {
        Stream GeneratePdf(PdfDocument document);
    }
}
