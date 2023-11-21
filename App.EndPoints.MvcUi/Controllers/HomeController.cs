using App.Domain.Core._Booth.Contracts.AppServices;
using App.Domain.Core._Products.Contracts.AppServices;
using App.Domain.Core._Products.Entities;
using App.EndPoints.MvcUi.Models;
using App.EndPoints.MvcUi.Models.Home;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace App.EndPoints.MvcUi.Controllers
{

    [AllowAnonymous]
    public class HomeController : Controller
    {

        private readonly ICategoryAppServices _categoryAppServices;
        private readonly IBoothAppServices _boothAppServices;
        private readonly IAuctionAppServices _auctionAppServices;
        private readonly IProductAppServices _productAppServices;
 
        private readonly ILogger<HomeController> _logger;

        public HomeController(
            ILogger<HomeController> logger,
            ICategoryAppServices categoryAppServices,
            IBoothAppServices boothAppServices,
            IAuctionAppServices auctionAppServices,
            IProductAppServices productAppServices)
        {
            _logger = logger;
            _categoryAppServices = categoryAppServices;
            _boothAppServices = boothAppServices;
            _auctionAppServices = auctionAppServices;
            _productAppServices = productAppServices;
        }
        [HttpGet]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            IndexViewModel viewModel = new IndexViewModel();
            viewModel.Categories = await _categoryAppServices.GetAll(cancellationToken);
            viewModel.boothOutputs = await _boothAppServices.GetAllHome(cancellationToken);
            viewModel.auctionOutputs = await _auctionAppServices.GetAllAuctions(cancellationToken);

            return View(viewModel);
        }


            [HttpGet]
        public async Task<IActionResult> ParentCategoryProducts(int id, CancellationToken cancellationToken)
        {
            CategoryProductsViewModel CategoryProducts = new CategoryProductsViewModel();
            
            CategoryProducts.Id = id;
            CategoryProducts.Categories = await _categoryAppServices.GetAll(cancellationToken);
            CategoryProducts.Products = await _productAppServices.GetAllByParentCategory(id, cancellationToken);
            return View("CategoryProduct",CategoryProducts);
        }

        [HttpGet]
        public async Task<IActionResult> ChildCategoryProducts(int id, CancellationToken cancellationToken)
        {
            CategoryProductsViewModel CategoryProducts = new CategoryProductsViewModel();

            CategoryProducts.Id = id;
            CategoryProducts.Categories = await _categoryAppServices.GetAll(cancellationToken);
            CategoryProducts.Products = await _productAppServices.GetAllByChildCategory(id, cancellationToken);
            return View("CategoryProduct", CategoryProducts);
        }

        [HttpGet]
        public async Task<IActionResult> AllBoothsList(CancellationToken cancellationToken)
        {
            var Boothlist = await _boothAppServices.GetAllHome(cancellationToken);
            return View(Boothlist);
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}