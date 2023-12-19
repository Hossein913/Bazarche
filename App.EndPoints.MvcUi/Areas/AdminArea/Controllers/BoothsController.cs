using App.Domain.AppServices.Booth;
using App.Domain.Core._Booth.Contracts.AppServices;
using App.Domain.Core._User.Dtos.BoothDtos.BoothAppServiceDto;
using App.EndPoints.MvcUi.Areas.AdminArea.ViewModels.Booths;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MvcUi.Areas.AdminArea.Controllers
{
    public class BoothsController : AdminBaseController
    {
        protected readonly IBoothAppServices _boothApp;
        protected readonly IWebHostEnvironment _webHostEnvironment;
        public BoothsController(IBoothAppServices boothApp, IWebHostEnvironment webHostEnvironment)
        {
            _boothApp = boothApp;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ActionResult> Edit(int boothId, int sellerId, CancellationToken cancellationToken)
        {
            var result = await _boothApp.GetDetails(boothId, cancellationToken);
            UpdateBoothViewModel updateBooth = new UpdateBoothViewModel
            {
                Id = result.Id,
                AvatarUrl = result.AvatarPicture.ImageUrl,
                AvatarId = result.AvatarPicture.Id,
                Name = result.Name,
                Description = result.Description,
                SellerId = sellerId,
            };
            return View(updateBooth);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UpdateBoothViewModel updateBooth,CancellationToken cancellationToken )
        {
            if (ModelState.IsValid)
            {
                BoothAppServiceUpdateDto boothAppServiceUpdate = new BoothAppServiceUpdateDto
                {
                    BoothId = updateBooth.Id,
                    BoothName =updateBooth.Name ,
                    Description =updateBooth.Description ,
                    BoothAvatarFile =updateBooth.AvatarFileUpload ,
                };
                
                await _boothApp.Update(boothAppServiceUpdate,CurrentUserId, _webHostEnvironment.WebRootPath,cancellationToken);
                return RedirectToAction("Details", "Sellers" , new { sellerId= updateBooth.SellerId});
            }
            return View(updateBooth);
        }

        public async Task<ActionResult> SetActivity(int boothId, bool status, CancellationToken cancellationToken)
        {
            await _boothApp.SetActivity(boothId, status, cancellationToken);
            return Redirect(Request.Headers["Referer"].ToString());
        }

    }
}
