using App.Domain.Core._Products.Contracts.AppServices;
using App.Domain.Core._Products.Dtos.BoothProductDtos;
using App.EndPoints.MvcUi.Areas.SellerArea.Models.BoothProductViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MvcUi.Areas.SellerArea.Controllers
{
    public class BoothProductController : BaseController
    {
        protected readonly IProductAppServices _productApp;
        protected readonly IBoothProductAppServices _boothProductApp;

        public BoothProductController(IProductAppServices productAppService, IBoothProductAppServices boothProductApp)
        {
            _productApp = productAppService;
            _boothProductApp = boothProductApp;
        }

        [HttpGet]
        public async Task<ActionResult> Create(int productId, CancellationToken cancellationToken)
        {
            var product = await _productApp.GetDetails(productId, cancellationToken);
            CreateBoothProductViewModel createBoothProduct = null;
            if (product != null)
            {
                createBoothProduct = new CreateBoothProductViewModel
                {
                    ProductId = product.Id ,
                    BoothId = CurrentBoothId  ,
                    Price = 0 ,
                    Count = 0 ,
                    ProductName = product.Name ,
                    ProductBrand = product.Brand ,
                    Avatar = product.Pictures.FirstOrDefault() ,
                    MainUrl = Request.Headers["Referer"].ToString(),
                };
            }

            return View(createBoothProduct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateBoothProductViewModel boothProduct,CancellationToken cancellationToken)
        {
            BoothProductCreateDto createBoothProductCreateDto = new BoothProductCreateDto
            {
                ProductId = boothProduct.ProductId ,
                BoothId = CurrentBoothId,
                Price = boothProduct.Price,
                Count = boothProduct.Count,

            };

            await _boothProductApp.Create(createBoothProductCreateDto, cancellationToken);

            return View();
        }

        public async Task<ActionResult> Index()
        {
            return View();
        }

        public async Task<ActionResult> Details(int id)
        {
            return View();
        }

        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
        return RedirectToAction(nameof(Index));
            }
            catch
            {
        return View();
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
        return RedirectToAction(nameof(Index));
            }
            catch
            {
        return View();
            }
        }
    }
}
