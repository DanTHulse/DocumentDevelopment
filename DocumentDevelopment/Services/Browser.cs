using System.Diagnostics;
using System.IO;
using DocumentDevelopment.Services.Interfaces;
using DocumentDevelopment.Utils.Models;

namespace DocumentDevelopment.Services
{
    public class Browser : IBrowser
    {
        public void Display(string html, PaperworkType paperworkType)
        {
            var filename = $"{Path.GetTempPath()}{paperworkType}.htm";
            File.WriteAllText(filename, html);
            _ = Process.Start(@"cmd.exe ", @"/c " + filename);
        }
    }
}
