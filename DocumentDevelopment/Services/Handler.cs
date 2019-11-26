using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentDevelopment.Data;
using DocumentDevelopment.Helpers;
using DocumentDevelopment.Services.Interfaces;
using DocumentDevelopment.Utils.Models;
using DocumentDevelopment.ViewModels;

namespace DocumentDevelopment.Services
{
    public class Handler : IHandler
    {
        private readonly IDocumentGenerator _generator;
        private readonly IBrowser _browser;

        public Handler(IDocumentGenerator generator, IBrowser browser)
        {
            _generator = generator;
            _browser = browser;
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

                    var types = EnumHelpers.EnumToList<PaperworkType>();

                    foreach (var t in types)
                    {
                        Console.WriteLine($"{(int)t} - {t.ToString()}");
                    }

                    var choice = (PaperworkType)ConsoleHelpers.ReadNumber();

                    switch (choice)
                    {
                        case PaperworkType.All:
                            await HandleAll(mockData, types);
                            break;
                        case PaperworkType.AllSoildFuel:
                            await HandleAllSolidFuel(mockData, types);
                            break;
                        case PaperworkType.AllOil:
                            await HandleAllOil(mockData, types);
                            break;
                        case PaperworkType.AllOther:
                            await HandleAllOther(mockData, types);
                            break;
                        default:
                            await Handle(mockData, choice);
                            break;
                    }

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

        private async Task Handle(DataModel mockData, PaperworkType choice)
        {
            var model = await _generator.CreateDocument(mockData, choice);
            _browser.Display(model, choice);
        }

        private async Task HandleAll(DataModel mockData, List<PaperworkType> types)
        {
            foreach (var type in types.Where(w => !DefaultTypes.All.Contains(w)))
            {
                await Handle(mockData, type);
            }
        }

        private async Task HandleAllSolidFuel(DataModel mockData, List<PaperworkType> types)
        {
            foreach (var type in types.Where(w => DefaultTypes.AllSolidFuel.Contains(w)))
            {
                await Handle(mockData, type);
            }
        }

        private async Task HandleAllOil(DataModel mockData, List<PaperworkType> types)
        {
            foreach (var type in types.Where(w => DefaultTypes.AllOil.Contains(w)))
            {
                await Handle(mockData, type);
            }
        }

        private async Task HandleAllOther(DataModel mockData, List<PaperworkType> types)
        {
            foreach (var type in types.Where(w => DefaultTypes.AllOther.Contains(w)))
            {
                await Handle(mockData, type);
            }
        }
    }
}
