using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Data;

namespace App.EndPoints.MvcUi.Areas.SellerArea.Controllers
{
    [Area("SellerArea"), Authorize(Roles = "Seller")]
    public class BaseController : Controller
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

        public int CurrentSellerId
        {
            get
            {
                try
                {
                    var sellerId = ((ClaimsIdentity)HttpContext.User.Identity).Claims.Where(c => c.Type == "SellerId")
                        .Select(c => c.Value).SingleOrDefault();
                    return Convert.ToInt32(sellerId);
                }
                catch (Exception ex)
                {
                }
                return 0;
            }
        }

        public int CurrentBoothId
        {
            get
            {
                try
                {
                    var boothId = ((ClaimsIdentity)HttpContext.User.Identity).Claims.Where(c => c.Type == "BoothId")
                        .Select(c => c.Value).SingleOrDefault();
                    return Convert.ToInt32(boothId);
                }
                catch (Exception ex)
                {
                }
                return 0;
            }
        }
   
    }
}
