using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace App.EndPoints.MvcUi.Areas.AdminArea.Controllers
{
    [Area("AdminArea"), Authorize(Roles ="Admin")]
    public class AdminBaseController : Controller
    {

        public int CurrentUserId
        {
            get
            {
                try
                {
                    var appUserId = ((ClaimsIdentity)HttpContext.User.Identity).Claims.Where(c => c.Type == "UserId")
                        .Select(c => c.Value).SingleOrDefault();
                    return Convert.ToInt32(appUserId);
                }
                catch (Exception ex)
                {
                }
                return 0;
            }
        }


    }
}
