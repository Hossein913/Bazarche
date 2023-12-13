using App.Domain.Core._Common.Dtos.AppSettingDtos;
using App.Domain.Core._Products.Contracts.AppServices;
using App.Domain.Core._Products.Dtos.CategorieDtos;
using App.Domain.Core._Products.Dtos.ProductDtos;
using App.Domain.Core._Products.Entities;
using App.Domain.Core._User.Entities;
using App.EndPoints.MvcUi.Areas.AdminArea.ViewModels.Product.ProductEnum;
using App.EndPoints.MvcUi.Areas.SellerArea.Models;
using App.EndPoints.MvcUi.Areas.SellerArea.Models.ProductViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using System.Threading;

namespace App.EndPoints.MvcUi.Areas.SellerArea.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ICategoryAppServices _categoryAppServices;
        private readonly IProductAppServices _productAppServices;
        private readonly UserManager<AppUser> _userManager;

        public ProductController(
            IWebHostEnvironment hostingEnvironment,
            ICategoryAppServices categoryAppServices,
            IProductAppServices productAppServices,
            UserManager<AppUser> userManager)
        {
            _hostingEnvironment = hostingEnvironment;
            _categoryAppServices = categoryAppServices;
            _productAppServices = productAppServices;
            _userManager = userManager;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Create(CancellationToken cancellationToken)
        {
            ViewBag.BoothId = CurrentBoothId;
            CreateProductFormViewModel viewModel = new CreateProductFormViewModel();
            viewModel.Product = new ProductCreateViewModel();
            viewModel.Categories = await _categoryAppServices.GetAll(cancellationToken);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateProductFormViewModel productViewModel, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                if (productViewModel.Product.Pictures != null)
                {

                    ProductAppServiceDto productAppService = new ProductAppServiceDto
                    {
                        Name = productViewModel.Product.Name,
                        Brand = productViewModel.Product.Brand,
                        Grantee = productViewModel.Product.Grantee,
                        InformationDetails = productViewModel.Product.InformationDetails,
                        Description = productViewModel.Product.Description,
                        IncludedComponents = productViewModel.Product.IncludedComponents,
                        BasePrice = productViewModel.Product.BasePrice,
                        Pictures = productViewModel.Product.Pictures,
                        CategoryId = productViewModel.Product.CategoryId,
                        CreatedBy = CurrentUserId,
                    };

                    var result = await _productAppServices.Create(productAppService, CurrentUserId, _hostingEnvironment.WebRootPath, cancellationToken);
                    if (result == 0)
                    {
                        ModelState.AddModelError(string.Empty, "ذخیره کالا با مشکل روبه رو شد.");

                    }
                    else if (result > 0)
                    {
                        return RedirectToAction("Create", "Product");
                    }

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "تصویری برای کالا انتخاب نشده است.");
                }
            }
            return View(productViewModel);
        }

        [HttpGet]
        public async Task<ActionResult> ParentCategories(CancellationToken cancellationToken)
        {
            ViewBag.BoothId = CurrentBoothId;
            var Categories = await _categoryAppServices.GetAll(cancellationToken);
            var CategoriesViewModel = Categories.Select(c => new ParentCategoriesViewModel
            {
                Id = c.Id,
                Title = c.Title,
                ParentId = c.ParentId,
                Picture = c.Picture,
                Subcategories = c.Subcategories
            }).ToList();

            return View(CategoriesViewModel);
        }

        [HttpGet]
        public async Task<ActionResult> CategoryProducts(int categoryId, CancellationToken cancellationToken)
        {
            var products = await _productAppServices.GetAllByParentCategory(categoryId, cancellationToken);

            var ProductListViewModel = products.Select(c => new ProductListViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Brand = c.Brand,
                Avatar = c.Avatar,
                Description = c.Description,
                BasePrice = c.BasePrice,
                CreatedAt = c.CreatedAt,

            }).OrderBy(x => x.CreatedAt).ToList();

            return View("CategoryProducts", ProductListViewModel);
        }

        [HttpGet]
        public async Task<ActionResult> GetOwned(CancellationToken cancellationToken)
        {
            var products = await _productAppServices.GetAllByOwner(CurrentUserId, cancellationToken);

            var ProductListViewModel = products.Select(p =>
            {
                OwnedProductStatus Status ;
                if (p.IsConfirmed == null && p.BoothProducts.Count == 0)
                {
                    Status = OwnedProductStatus.Registered;
                }
                else if (p.IsConfirmed == true && p.BoothProducts.Count == 0)
                {
                    Status = OwnedProductStatus.Confirmed;
                }
                else if (p.IsConfirmed == true && p.BoothProducts.Count > 0)
                {
                    Status = OwnedProductStatus.InUse;
                }
                else
                {
                    Status = OwnedProductStatus.Unconfirmed;
                }

                return new ProductListViewModel
                       {
                          Id = p.Id,
                          Name = p.Name,
                          Brand = p.Brand,
                          Avatar = p.Avatar,
                          Description = p.Description,
                          BasePrice = p.BasePrice,
                          CategoryTitle = p.CategoryTitle,
                          OwnedProductStatus = Status,
                          CreatedAt = p.CreatedAt
                       };

             }).ToList();


            return View(ProductListViewModel.OrderBy(p => p.OwnedProductStatus).ThenBy(p => p.CreatedAt).ToList());
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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


        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
