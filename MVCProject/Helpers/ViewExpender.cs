using Microsoft.AspNetCore.Mvc.Razor;

namespace MVCProject.Helpers
{
    public class ViewExpender : IViewLocationExpander
    {
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            viewLocations = new List<string>()
            {
                "~/Demo/{1}/{0}.cshtml",
                "~/Views/{1}/{0}.cshtml",
                "~/Views/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml"
            };
            return viewLocations;
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            
        }
    }
}
