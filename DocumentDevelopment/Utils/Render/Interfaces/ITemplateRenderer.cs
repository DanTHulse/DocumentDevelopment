using System.Threading.Tasks;

namespace DocumentDevelopment.Utils.Render.Interfaces
{
    public interface ITemplateRenderer
    {
        Task<string> Render<TModelType>(string templateName, TModelType model);
    }
}
