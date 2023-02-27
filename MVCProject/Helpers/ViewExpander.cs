using Microsoft.AspNetCore.Mvc.Razor;

namespace MVCProject.Helpers
{
    public class ViewExpander : IViewLocationExpander
    {
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            viewLocations = new[] {
                        
                        $"~/Views/Shared/{{0}}.cshtml",
                        $"~/Views/{{1}}/{{0}}.cshtml",
                        $"~/Demo/{{1}}/{{0}}.cshtml",
                        $"~/Demo/{{0}}.cshtml",
                    }.Concat(viewLocations);

            return viewLocations;
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            
        }
    }
}
