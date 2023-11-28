using App.Domain.Core._Products.Contracts.AppServices;
using App.Domain.Core._Products.Dtos.ProductDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MvcUi.Areas.SellerArea.Controllers
{
    public class AuctionController : BaseController
    {

        protected readonly IProductAppServices _productAppService;
        public AuctionController(IProductAppServices productAppService)
        {
            _productAppService = productAppService;
        }

        public ActionResult Details(int id,CancellationToken  cancellationToken)
        {
            return View();
        }

        public ActionResult Create(int Id, CancellationToken cancellationToken)
        {
            var result = _productAppService.GetDetails(Id, cancellationToken);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, CancellationToken cancellationToken)
        {
            return View();
        }

        public ActionResult Edit(int id, CancellationToken cancellationToken)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection, CancellationToken cancellationToken)
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
        public ActionResult Delete(int id, CancellationToken cancellationToken)
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
