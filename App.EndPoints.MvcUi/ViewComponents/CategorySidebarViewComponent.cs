using App.Domain.Core._Products.Contracts.AppServices;
using App.Domain.Core._Products.Dtos.CategorieDtos;
using App.EndPoints.MvcUi.Areas.SellerArea.Models.BoothViewModels;
using App.EndPoints.MvcUi.Models.Home;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace App.EndPoints.MvcUi.ViewComponents
{
    public class CategorySidebarViewComponent : ViewComponent
    {
        private readonly ICategoryAppServices _categoryAppServices;


        public CategorySidebarViewComponent(ICategoryAppServices categoryAppServices)
        {
            _categoryAppServices = categoryAppServices;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Categories = await _categoryAppServices.GetAll(CancellationToken.None);
            var CategoriesViewModel = Categories.Select<CategoryOutputDto, CategoriesViewModel>(categories => new CategoriesViewModel
            {
                Id = categories.Id,
                Title = categories.Title,
                ParentId = categories.ParentId,
                PictureFileName = categories.PictureFileName,
                Subcategories = categories.Subcategories,
                Picture = categories.Picture,
            }).ToList();
            return View(CategoriesViewModel);
        }
    }
}
