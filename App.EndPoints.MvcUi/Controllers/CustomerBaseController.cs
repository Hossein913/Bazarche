using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace App.EndPoints.MvcUi.Controllers
{
    //[Authorize]
    [Authorize(Roles ="Customer")]
    public class CustomerBaseController : Controller
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

        public int CurrentCartId
        {
            get
            {
                try
                {
                    var appUserId = ((ClaimsIdentity)HttpContext.User.Identity).Claims.Where(c => c.Type == "CartId")
                        .Select(c => c.Value).SingleOrDefault();
                    return Convert.ToInt32(appUserId);
                }
                catch (Exception ex)
                {
                }
                return 0;
            }
        }

        public int CurrentCustomerId
        {
            get
            {
                try
                {
                    var appUserId = ((ClaimsIdentity)HttpContext.User.Identity).Claims.Where(c => c.Type == "CustomerId")
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
