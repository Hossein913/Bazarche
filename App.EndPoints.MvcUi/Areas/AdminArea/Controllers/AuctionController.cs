using App.Domain.Core._Products.Contracts.AppServices;
using App.Domain.Core._Products.Enums;
using App.EndPoints.MvcUi.Areas.AdminArea.ViewModels.Auctions;
using App.Frameworks.Web.DateConverter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MvcUi.Areas.AdminArea.Controllers
{
    public class AuctionController : AdminBaseController
    {

        protected readonly IAuctionAppServices _auctionApp;

        public AuctionController(IAuctionAppServices auctionApp)
        {
            _auctionApp = auctionApp;
        }

        public async Task<ActionResult> IndexOfRegistered(CancellationToken cancellationToken)
        {
            var resutl = await _auctionApp.GetAllRegistered(cancellationToken);
            var viewModel = resutl.Select(a =>
             new GatAllAuctionsViewModel
            {
                 Id = a.Id ,
                 StartTime = a.StartTime.ToPersianNumericDateTime() ,
                 EndTime = a.EndTime.ToPersianNumericDateTime() ,
                 BasePrice = a.BasePrice ,
                 IsConfirmed = a.IsConfirmed ,
                 Booth = a.Booth , 
                 ProductDto = a.ProductDto , 
                 status = AuctionStatus.Defined
             }).ToList();

            return View("Index", viewModel);
        }
        public async Task<ActionResult> IndexOfRuning(CancellationToken cancellationToken)
        {
            var resutl = await _auctionApp.GetAllRuning(cancellationToken);
            var viewModel = resutl.Select(a =>
             new GatAllAuctionsViewModel
             {
                 Id = a.Id,
                 StartTime = a.StartTime.ToPersianNumericDateTime(),
                 EndTime = a.EndTime.ToPersianNumericDateTime(),
                 BasePrice = a.BasePrice,
                 IsConfirmed = a.IsConfirmed,
                 Booth = a.Booth,
                 ProductDto = a.ProductDto,
                 status = AuctionStatus.Runing
             }).ToList();

            return View("Index", viewModel);
        }
        public async Task<ActionResult> IndexOfEnded(CancellationToken cancellationToken)
        {
            var resutl = await _auctionApp.GetAllEnded(cancellationToken);
            var viewModel = resutl.Select(a =>
             new GatAllAuctionsViewModel
             {
                 Id = a.Id,
                 StartTime = a.StartTime.ToPersianNumericDateTime(),
                 EndTime = a.EndTime.ToPersianNumericDateTime(),
                 BasePrice = a.BasePrice,
                 IsConfirmed = a.IsConfirmed,
                 Booth = a.Booth,
                 ProductDto = a.ProductDto,
                 status = AuctionStatus.Ended,
                 WinnerName = a.WinnerCustomer.Firstname+" "+ a.WinnerCustomer.Lastname
             }).ToList();

            return View("Index", viewModel);
        }


        public async Task<ActionResult> Cancel(int auctionId, CancellationToken cancellationToken)
        {
            await _auctionApp.Cancel(auctionId, cancellationToken);
            return Redirect(Request.Headers["referer"].ToString());
        }
        public async Task<ActionResult> GetEndAuction(int auctionId, CancellationToken cancellationToken)
        {
            await _auctionApp.GetEndAuction(auctionId, cancellationToken);
            return Redirect(Request.Headers["referer"].ToString());
        }



    }
}
