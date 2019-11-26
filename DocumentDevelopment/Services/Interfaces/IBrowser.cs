using DocumentDevelopment.Utils.Models;

namespace DocumentDevelopment.Services.Interfaces
{
    public interface IBrowser
    {
        void Display(string html, PaperworkType paperworkType);
    }
}
