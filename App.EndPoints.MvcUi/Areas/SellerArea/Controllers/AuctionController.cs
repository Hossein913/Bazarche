using App.Domain.Core._Products.Contracts.AppServices;
using App.Domain.Core._Products.Dtos.AuctionDtos;
using App.Domain.Core._Products.Dtos.ProductDtos;
using App.Domain.Core._Products.Entities;
using App.EndPoints.MvcUi.Areas.SellerArea.Models.AuctionViewModels;
using App.EndPoints.MvcUi.Areas.SellerArea.Models.BoothProductViewModels;
using App.Frameworks.Web.DateConverter;
using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace App.EndPoints.MvcUi.Areas.SellerArea.Controllers
{
    public class AuctionController : BaseController
    {

        protected readonly IProductAppServices _productApp;
        protected readonly IAuctionAppServices _auctionApp;

        public AuctionController(IProductAppServices productAppService, IAuctionAppServices auctionApp)
        {
            _productApp = productAppService;
            _auctionApp = auctionApp;
        }

        public async Task<ActionResult> Index(CancellationToken cancellationToken)
        {
            var result = await _auctionApp.GetAllForBooth(CurrentBoothId, cancellationToken);
            List<GetAllAuctionViewModel> auctionViewModel = result.Select<AuctionOutputDto, GetAllAuctionViewModel>(a =>
                new GetAllAuctionViewModel
                {
                    Id = a.Id ,
                    WinnerId = a.WinnerId ,
                    StartTime = a.StartTime.ToPersianNumericDate() ,
                    EndTime = a.EndTime.ToPersianNumericDate(),
                    BasePrice = a.BasePrice ,
                    Status = a.Status ,
                    IsConfirmed = a.IsConfirmed ,
                    ProductDto = a.ProductDto,
                    MaxBid = a.Bids.Count > 0 ? a.Bids.FirstOrDefault(): null,
                }
            ).ToList();
            return View(auctionViewModel);
        }


        [HttpGet]
        public async Task<ActionResult> Create(int productId, CancellationToken cancellationToken)
        {

            var product = await _productApp.GetDetails(productId, cancellationToken);
            CreateAuctionViewModels createAuction = null;
            if (product != null)
            {
                createAuction = new CreateAuctionViewModels
                {
                    ProductId = product.Id,
                    BoothId = CurrentBoothId,
                    BasePrice = 0,
                    ProductName = product.Name,
                    ProductBrand = product.Brand,
                    Avatar = product.Pictures.FirstOrDefault(),
                    MainUrl = Request.Headers["Referer"].ToString(),
                };
            }

            return View(createAuction);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateAuctionViewModels createAuction, CancellationToken cancellationToken)
        {
            PersianCalendar persianCalendarStart = new PersianCalendar();
            DateTime StartDateTime = persianCalendarStart.ToDateTime(createAuction.StartYear, createAuction.StartMonth, createAuction.StartDay, createAuction.StartHour, 0, 0, 0);

            PersianCalendar EndpersianCalendar = new PersianCalendar();
            DateTime EndDateTime = EndpersianCalendar.ToDateTime(createAuction.EndYear, createAuction.EndMonth, createAuction.EndDay, createAuction.EndHour, 0, 0, 0);

            AuctionCreateDto auctionCreate = new AuctionCreateDto
            {
                ProductId = createAuction.ProductId,
                BoothId = CurrentBoothId,
                StartTime = StartDateTime,
                EndTime = EndDateTime,
                BasePrice = createAuction.BasePrice,
            };

            await _auctionApp.Create(auctionCreate, cancellationToken);

            
            return RedirectToAction("Create", new { productId = createAuction.ProductId });
        }


        public async Task<ActionResult> Cancel(int auctionId, CancellationToken cancellationToken)
        {
            await _auctionApp.Cancel(auctionId, cancellationToken);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(int id, CancellationToken cancellationToken)
        {
            return View();
        }


        public async Task<ActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection, CancellationToken cancellationToken)
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken)
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
