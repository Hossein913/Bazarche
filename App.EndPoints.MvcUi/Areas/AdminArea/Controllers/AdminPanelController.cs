using App.Domain.Core._User.Contracts.AppServices;
using App.Domain.Core._User.Dtos.WageDtos;
using App.EndPoints.MvcUi.Areas.AdminArea.Controllers;
using App.EndPoints.MvcUi.Areas.AdminArea.ViewModels.Product;
using App.EndPoints.MvcUi.Areas.AdminArea.ViewModels.Wages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace App.EndPoints.MvcUi.Areas.Admin.Controllers
{
    
    public class AdminPanelController : AdminBaseController
    {
        protected readonly IWageAppServices _wageApp;

        public AdminPanelController(IWageAppServices wageApp)
        {
            _wageApp = wageApp;
        }

        public async Task<ActionResult> Index(CancellationToken cancellationToken)
        {
            var result = await _wageApp.GetAll(cancellationToken);
             List<GetAllWageViewModel> productsViewModel = result.Select<WageOutputDto, GetAllWageViewModel>(w => 
                new GetAllWageViewModel
                {
                     
                    BoothName = w.Booth ,
                    CustomerName = w.customerfullName ,
                    ProductName = w.product ,
                    Price = w .price,
                    Count = w.Count ,
                    FeePercenteage = w.FeePercenteage ,
                    WageAmount = w.WageAmount ,
                }


             ).ToList();

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
