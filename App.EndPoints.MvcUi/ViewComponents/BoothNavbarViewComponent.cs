using App.Domain.Core._Booth.Contracts.AppServices;
using App.Domain.Core._Booth.Dtos.BoothDtos;
using App.EndPoints.MvcUi.Models.Home;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MvcUi.ViewComponents
{
    public class BoothNavbarViewComponent : ViewComponent
    {
        protected readonly IBoothAppServices _boothAppServices;

        public BoothNavbarViewComponent(IBoothAppServices boothAppServices)
        {
            _boothAppServices = boothAppServices;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var booth = await _boothAppServices.GetAllHome(CancellationToken.None);
            var boothViewModel = booth.Select<BoothOutputDto, BoothViewModel>(categories => new BoothViewModel
            {
                Id = categories.Id,
                Name = categories.Name,
                AvatarPictureFile = categories.AvatarPictureFile,
                MedalName = categories.MedalName,
                Description = categories.Description,
            }).ToList();

            return View(boothViewModel);
        }
    }
}
