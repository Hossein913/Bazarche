using App.Domain.Core._Booth.Contracts.AppServices;
using App.Domain.Core._Booth.Dtos.BoothDtos;
using App.Domain.Core._Products.Contracts.AppServices;
using App.EndPoints.MvcUi.Models.Home;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace App.EndPoints.MvcUi.Controllers
{
    [AllowAnonymous]
    public class BoothController : Controller
    {
        private readonly IBoothAppServices _boothAppServices;

        public BoothController(
            ILogger<HomeController> logger,
            ICategoryAppServices categoryAppServices,
            IBoothAppServices boothAppServices,
            IAuctionAppServices auctionAppServices,
            IProductAppServices productAppServices)
        {
            _boothAppServices = boothAppServices;
        }

        [HttpGet]
        public async Task<IActionResult> BoothsList(CancellationToken cancellationToken)
        {
            var Boothlist = await _boothAppServices.GetAllHome(cancellationToken);
            var BoothViewModel = Boothlist
                .Select<BoothOutputDto, BoothViewModel>(b => new BoothViewModel
            {
                Id = b.Id ,
                Name = b.Name ,
                AvatarPictureFile = b.AvatarPictureFile ,
                MedalName = b.MedalName ,
                Description = b.Description,

            }).ToList();
            return View(Boothlist);
        }
    }
}

