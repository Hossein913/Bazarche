using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace App.EndPoints.MvcUi.ViewComponents
{
    public class CustomerPanelSidebarViewComponent : ViewComponent
    {
        public CustomerPanelSidebarViewComponent()
        {

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
