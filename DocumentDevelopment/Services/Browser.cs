using System.IO;
using DocumentDevelopment.Services.Interfaces;
using DocumentDevelopment.Utils.Models;

namespace DocumentDevelopment.Services
{
    public class Browser : IBrowser
    {
        public void Display(string html, PaperworkType paperworkType)
        {
            var filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Documents\\Pages\\HTML");

            var filename = $"{filePath}\\{paperworkType}.html";
            File.WriteAllText(filename, html);
            //_ = Process.Start(@"cmd.exe ", @"/c " + filename);
        }
    }
}
