using System;
using System.Threading.Tasks;
using DocumentDevelopment.Data;
using DocumentDevelopment.Helpers;
using DocumentDevelopment.Services.Interfaces;
using DocumentDevelopment.Utils.Models;

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
                    var types = EnumHelpers.EnumToList<PaperworkType>();

                    foreach (var t in types)
                    {
                        Console.WriteLine($"{(int)t} - {t.ToString()}");
                    }

                    var choice = (PaperworkType)ConsoleHelpers.ReadNumber();

                    mockData.DocumentKey = await _generator.CreateDocument(mockData, choice);

                    Console.WriteLine("\n\n\nIteration Complete");
                    Console.WriteLine("\nRun again? [ y / N ]");

                    if ((Console.ReadKey()).Key == ConsoleKey.N)
                    {
                        loop = false;
                    }


                } while (loop);
            }
            catch
            {
                throw;
            }
        }
    }
}
