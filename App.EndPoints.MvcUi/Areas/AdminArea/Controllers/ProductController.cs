using App.Domain.Core._Products.Contracts.AppServices;
using App.Domain.Core._Products.Dtos.ProductDtos;
using App.EndPoints.MvcUi.Areas.AdminArea.ViewModels.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;

namespace App.EndPoints.MvcUi.Areas.AdminArea.Controllers
{
    public class ProductController : AdminBaseController
    {
        protected readonly IProductAppServices _productApp;

        public ProductController(IProductAppServices productApp)
        {
            _productApp = productApp;
        }

        public async Task<ActionResult> Index(CancellationToken cancellationToken)
        {
            var products = await _productApp.GetAll(cancellationToken);
            List<GetAllProductViewModel> productsViewModel = products
                .Select<ProductOutputDto, GetAllProductViewModel>(p => 
                new GetAllProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Avatar = p.Avatar,
                    Description = p.Description,
                    IsConfirmed = p.IsConfirmed,
                    BasePrice = p.Id,
                    CreatedAt = p.CreatedAt
                }).OrderByDescending(p => p.IsConfirmed).ThenBy(p => p.Id).ToList();
            return View(productsViewModel);
        }

        public async Task<ActionResult> GetAllToConfirm(CancellationToken cancellationToken)
        {
            var products = await _productApp.GetAllToConfirm(cancellationToken);
            List<GetAllProductViewModel> productsViewModel = products.Where(p => p.IsConfirmed == true)
                .Select<ProductOutputDto, GetAllProductViewModel>(p => new GetAllProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Avatar = p.Avatar,
                    Description = p.Description,
                    IsConfirmed = p.IsConfirmed,
                    BasePrice = p.Id,
                    CreatedAt = p.CreatedAt
                }).ToList();
            return View(productsViewModel);
        }

        public async Task<ActionResult> Details(int id)
        {
            return View();
        }

        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
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


