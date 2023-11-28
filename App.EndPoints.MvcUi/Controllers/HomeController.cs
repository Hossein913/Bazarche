using App.Domain.Core._Booth.Contracts.AppServices;
using App.Domain.Core._Products.Contracts.AppServices;
using App.Domain.Core._Products.Dtos.AuctionDtos;
using App.Domain.Core._Products.Dtos.ProductDtos;
using App.Domain.Core._Products.Entities;
using App.EndPoints.MvcUi.Models;
using App.EndPoints.MvcUi.Models.Home;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace App.EndPoints.MvcUi.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {


        private readonly IAuctionAppServices _auctionAppServices;
        private readonly IProductAppServices _productAppServices;

        public HomeController(
            IAuctionAppServices auctionAppServices,
            IProductAppServices productAppServices)
        {
            _auctionAppServices = auctionAppServices;
            _productAppServices = productAppServices;
        }
        [HttpGet]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            IndexViewModel viewModel = new IndexViewModel();
            
            var auctions = await _auctionAppServices.GetAllAuctions(cancellationToken);
            var auctionViewModelList = auctions.Select<AuctionOutputDto, AuctionViewModel>( a => new AuctionViewModel
            {
                Id = a.Id,
                ProductId = a.ProductId,
                BoothId = a.BoothId,
                StartTime = a.StartTime,
                EndTime = a.EndTime,
                Bids = a.Bids,
                BoothName = a.Booth.Name , 
                ProductDto = a.ProductDto,
            }).ToList();

            var products = await _productAppServices.GetPopularOrderedProducts(4, cancellationToken);
            var productsViewModelList = products.Select<ProductOutputDto,ProductViewModel>(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Brand = p.Grantee,
                AvatarFileUrl = p.Avatar,
                Description = p.Description,
                MaxPrice = p.MinPrice,
                MinPrice = p.MaxPrice,

            }).ToList();

            IndexViewModel indexViewModel = new IndexViewModel();
            indexViewModel.auctionViewModels = auctionViewModelList;
            indexViewModel.productsViewModels = productsViewModelList;

            return View(indexViewModel);
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

