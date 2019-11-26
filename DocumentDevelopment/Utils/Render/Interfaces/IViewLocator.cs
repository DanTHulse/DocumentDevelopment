using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace DocumentDevelopment.Utils.Render.Interfaces
{
    public interface IViewLocator
    {
        IView FindView(ActionContext actionContext, string viewName);
    }
}
