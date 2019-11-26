using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using DinkToPdf;
using DinkToPdf.Contracts;
using DocumentDevelopment.Services;
using DocumentDevelopment.Services.Interfaces;
using DocumentDevelopment.Utils;
using DocumentDevelopment.Utils.Interfaces;
using DocumentDevelopment.Utils.Render;
using DocumentDevelopment.Utils.Render.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.ObjectPool;
using Microsoft.Extensions.PlatformAbstractions;

namespace DocumentDevelopment
{
    class Program
    {
        static void Main()
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            var applicationEnvironment = PlatformServices.Default.Application;
            var environment = new HostingEnvironment
            {
                ApplicationName = Assembly.GetEntryAssembly().GetName().Name
            };
            var appDirectory = Directory.GetCurrentDirectory();
            var diagnosticSource = new DiagnosticListener("Microsoft.AspNetCore");

            var serviceProvider = new ServiceCollection()
                .AddSingleton<IDocumentGenerator, DocumentGenerator>()
                .AddSingleton(applicationEnvironment)
                .AddSingleton<IHostingEnvironment>(environment)
                .AddSingleton<IHandler, Handler>()
                .AddSingleton<ITools, PdfTools>()
                .AddSingleton<IBrowser, Browser>()
                .AddSingleton<IConverter, SynchronizedConverter>()
                .AddSingleton<ObjectPoolProvider, DefaultObjectPoolProvider>()
                .AddSingleton<IPdfGenerator, PdfGenerator>()
                .AddSingleton<DiagnosticSource>(diagnosticSource)
                .AddScoped<IViewLocator, ViewLocator>()
                .AddScoped<ITemplateRenderer, TemplateRenderer>()
                .Configure<RazorViewEngineOptions>(options =>
                {
                    options.FileProviders.Clear();
                    options.FileProviders.Add(new PhysicalFileProvider(appDirectory));
                });

            serviceProvider.AddMvc();
            serviceProvider.AddLogging();
            serviceProvider.BuildServiceProvider();

            var srv = serviceProvider.BuildServiceProvider().GetService<IHandler>();
            await srv.Run();
        }
    }
}
