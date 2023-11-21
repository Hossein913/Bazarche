using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace App.EndPoints.MvcUi.Areas.SellerArea.Controllers
{
    [Area("SellerArea"), AllowAnonymous]
    public class BaseController : Controller
    {
        public int CurrentUserId
        {
            get
            {
                try
                {
                    var userId = ((ClaimsIdentity)HttpContext.User.Identity).Claims.Where(c => c.Type == "UserId")
                        .Select(c => c.Value).SingleOrDefault();
                    return Convert.ToInt32(userId);
                }
                catch (Exception ex)
                {
                }
                return 0;
            }
        }
    }
}
