using System;
using System.IO;
using System.Threading.Tasks;
using DocumentDevelopment.Utils.Render.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;

namespace DocumentDevelopment.Utils.Render
{
    public class TemplateRenderer : ITemplateRenderer
    {
        private readonly ITempDataProvider _tempDataProvider;

        private readonly IServiceProvider _serviceProvider;

        private readonly IViewLocator _viewLocator;

        public TemplateRenderer(
            ITempDataProvider tempDataProvider,
            IServiceProvider serviceProvider, IViewLocator viewLocator)
        {
            _tempDataProvider = tempDataProvider;
            _serviceProvider = serviceProvider;
            _viewLocator = viewLocator;
        }

        public async Task<string> Render<TModel>(string viewName, TModel model)
        {
            var actionContext = new ActionContext(new DefaultHttpContext
            {
                RequestServices = _serviceProvider
            }, new RouteData(), new ActionDescriptor());

            var view = _viewLocator.FindView(actionContext, viewName);

            using (var output = new StringWriter())
            {
                var viewContext = new ViewContext(
                    actionContext,
                    view,
                    new ViewDataDictionary<TModel>(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                    {
                        Model = model
                    },
                    new TempDataDictionary(actionContext.HttpContext, _tempDataProvider),
                    output,
                    new HtmlHelperOptions());

                await view.RenderAsync(viewContext);

                return output.ToString();
            }
        }
    }
}
