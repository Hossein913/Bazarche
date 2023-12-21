using App.Domain.Core._Products.Contracts.AppServices;
using App.Domain.Core._Products.Dtos.BidDtos;
using App.Domain.Core._Products.Entities;
using App.Domain.Core._Products.Enums;
using App.EndPoints.MvcUi.Models._Bid;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;

namespace App.EndPoints.MvcUi.Controllers
{
    public class CustomerBidController : CustomerBaseController
    {
        protected readonly IBidAppServices _bidApp ;
        protected readonly IAuctionAppServices _auctionApp ;


        public CustomerBidController(IBidAppServices bidAppServices, IAuctionAppServices auctionApp)
        {
            _bidApp = bidAppServices;
            _auctionApp = auctionApp;
        }

        [HttpGet]
        public  async Task<IActionResult> Create(int auctionId,CancellationToken cancellationToken)
        {
            var result = await _auctionApp.GetDetail(auctionId, cancellationToken);
            CreateBidViewModel createViewModel = null;
            if (result != null)
            {
                createViewModel = new CreateBidViewModel {
                    AuctionId = auctionId ,
                    CurrentCustomerId = CurrentCustomerId,
                    EndTime = result.EndTime ,
                    Bids = result.Bids.ToList() ,
                    Booth = result.Booth ,
                    ProductDto = result.ProductDto,
                };
            }
            
            if (TempData.ContainsKey("result"))
            {

                switch (TempData["result"].ToString())
                {
                    case "Succeeded":
                        ViewData["result"] = "Succeeded";
                        break;

                    case "LessThanBasePrice":
                        ViewData["result"] = "LessThanBasePrice";
                        break;

                    case "LessThanMaxBid":
                        ViewData["result"] = "LessThanMaxBid";
                        break;
                }
            }

            return View(createViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<IActionResult> Create(CreateBidViewModel bidViewModel,CancellationToken cancellationToken)
        {
            BidCreateDto bidCreateDto = new BidCreateDto {
             AuctionId = bidViewModel.AuctionId,
             CustomerId = CurrentCustomerId,
             BidPrice= bidViewModel.BidPrice ,
            };
            var result = await _bidApp.Create(bidCreateDto,cancellationToken);
            switch (result)
            {
                case AddBidResult.Succeeded:
                    TempData["result"] = "Succeeded";
                    break;

                case AddBidResult.LessThanBasePrice:
                    TempData["result"] = "LessThanBasePrice";
                    break;

                case AddBidResult.LessThanMaxBid:
                    TempData["result"] = "LessThanMaxBid";
                    break;
            }

            return RedirectToAction("Create", new { auctionId = bidViewModel.AuctionId });

        }


        // GET: CustomerBidController/Delete/5
        public  async Task<IActionResult> Delete(int bidId, CancellationToken cancellationToken)
        {
            await _bidApp.Delete(bidId, cancellationToken);
            return RedirectToAction("AllAuctions", "Customer");
        }

        // POST: CustomerBidController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<IActionResult> Delete(int id, IFormCollection collection)
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
