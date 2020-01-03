using System;
using System.Threading.Tasks;
using DocumentDevelopment.Data;
using DocumentDevelopment.Helpers;
using DocumentDevelopment.Services.Interfaces;
using DocumentDevelopment.ViewModels;

namespace DocumentDevelopment.Services
{
    public class Handler : IHandler
    {
        private readonly IDocumentGenerator _generator;

        public Handler(IDocumentGenerator generator)
        {
            _generator = generator;
        }

        public async Task Run()
        {
            var mockData = MockDataModel.Build;

            try
            {
                var loop = true;

                do
                {
                    Console.Clear();

                    Console.WriteLine("\n Do you want to regenerate the HTML? [ y / N ]");

                    await HandleAll(mockData, (Console.ReadKey()).Key == ConsoleKey.Y);

                    Console.WriteLine("\n\n\nIteration Complete");
                    Console.WriteLine("\nRun again? [ y / N ]");

                    loop = (Console.ReadKey()).Key == ConsoleKey.Y;


                } while (loop);
            }
            catch
            {
                throw;
            }
        }

        private async Task HandleAll(DocumentData mockData, bool generateHtml)
        {
            foreach (var type in EnumHelpers.EnumToList<PaperworkType>())
            {
                var model = await _generator.CreateDocument(mockData, type, generateHtml);
            }
        }
    }
}
