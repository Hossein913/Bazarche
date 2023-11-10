using App.Domain.Core._Booth.Contracts.AppServices;
using App.Domain.Core._Products.Contracts.AppServices;
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
        private readonly IBoothAppServices _BoothAppServices;


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ICategoryAppServices categoryAppServices, IBoothAppServices boothAppServices)
        {
            _logger = logger;
            _categoryAppServices = categoryAppServices;
            _BoothAppServices = boothAppServices;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var result = await _categoryAppServices.GetAll(cancellationToken);

            IndexViewModel viewModel = new IndexViewModel();
              viewModel.ParentCategories = result.Where(x => x.ParentId==null).ToList();
              viewModel.ChildCategories = result.Where(x => x.ParentId != null).ToList();
              viewModel.boothOutputs = await _BoothAppServices.GetAllHome(cancellationToken);

            return View(viewModel);
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