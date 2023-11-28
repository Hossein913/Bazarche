using App.Domain.Core._Products.Contracts.AppServices;
using App.Domain.Core._Products.Dtos.CategorieDtos;
using App.EndPoints.MvcUi.Areas.SellerArea.Models.BoothViewModels;
using App.EndPoints.MvcUi.Models.Home;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MvcUi.ViewComponents
{
    public class ParentCategoryNavbarViewComponent : ViewComponent
    {
        private readonly ICategoryAppServices _categoryAppServices;

        public ParentCategoryNavbarViewComponent(ICategoryAppServices categoryAppServices)
        {
            _categoryAppServices = categoryAppServices;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryAppServices.GetAll(CancellationToken.None);
            var cateroriesViewModel = categories.Select<CategoryOutputDto, CategoriesViewModel>(c => new CategoriesViewModel
            {
                Id = c.Id ,
                Title = c.Title , 
                ParentId = c.ParentId ,
                PictureFileName = c.PictureFileName ,
                Picture = c.Picture ,
            }).ToList();
            return View(cateroriesViewModel);
        }
    }
}

//Id = Categories ,
//Title = Categories , 
//ParentId = Categories ,
//PictureFileName = Categories ,
//Subcategories = Categories ,
//Picture = Categories ,