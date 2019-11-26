using System.Threading.Tasks;
using DocumentDevelopment.Utils.Models;
using DocumentDevelopment.ViewModels;

namespace DocumentDevelopment.Services.Interfaces
{
    public interface IDocumentGenerator
    {
        Task<string> CreateDocument(BaseTemplateModel templateModel, PaperworkType paperworkType);
    }
}
