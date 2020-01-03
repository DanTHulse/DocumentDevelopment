using System.Threading.Tasks;
using DocumentDevelopment.ViewModels;

namespace DocumentDevelopment.Services.Interfaces
{
    public interface IDocumentGenerator
    {
        Task<string> CreateDocument(DocumentData data, PaperworkType paperworkType, bool generateHtml);
    }
}
