using App.Domain.Core._Common.Dtos.AppSettingDtos;
using App.Domain.Core._Products.Contracts.AppServices;
using App.Domain.Core._Products.Dtos.CategorieDtos;
using App.Domain.Core._Products.Dtos.ProductDtos;
using App.Domain.Core._Products.Entities;
using App.Domain.Core._User.Entities;
using App.EndPoints.MvcUi.Areas.SellerArea.Models;
using App.EndPoints.MvcUi.Areas.SellerArea.Models.ProductViewModels;
using App.EndPoints.MvcUi.Areas.SellerArea.Models.ProductViewModels.ProductEnum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using System.Threading;
using ProductCreateViewModel = App.EndPoints.MvcUi.Areas.SellerArea.Models.ProductViewModels.ProductCreateViewModel;

namespace App.EndPoints.MvcUi.Areas.SellerArea.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ICategoryAppServices _categoryApp;
        private readonly IProductAppServices _productApp;
        private readonly UserManager<AppUser> _userManager;

        public ProductController(
            IWebHostEnvironment hostingEnvironment,
            ICategoryAppServices categoryAppServices,
            IProductAppServices productAppServices,
            UserManager<AppUser> userManager)
        {
            _hostingEnvironment = hostingEnvironment;
            _categoryApp = categoryAppServices;
            _productApp = productAppServices;
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
            CreateProductFormViewModel viewModel = new CreateProductFormViewModel();
            viewModel.Categories = await _categoryApp.GetAll(cancellationToken);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateProductFormViewModel productViewModel, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                if (productViewModel.Pictures != null)
                {

                    ProductAppServiceDto productAppService = new ProductAppServiceDto
                    {
                        Name = productViewModel.Name,
                        Brand = productViewModel.Brand,
                        Grantee = productViewModel.Grantee,
                        InformationDetails = productViewModel.InformationDetails,
                        Description = productViewModel.Description,
                        IncludedComponents = productViewModel.IncludedComponents,
                        BasePrice = productViewModel.BasePrice,
                        Pictures = productViewModel.Pictures,
                        CategoryId = productViewModel.CategoryId,
                        CreatedBy = CurrentUserId,
                    };

                    var result = await _productApp.Create(productAppService, CurrentUserId, _hostingEnvironment.WebRootPath, cancellationToken);
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
            productViewModel.Categories = await _categoryApp.GetAll(cancellationToken);
            return View(productViewModel);
        }

        [HttpGet]
        public async Task<ActionResult> ParentCategories(CancellationToken cancellationToken)
        {
            ViewBag.BoothId = CurrentBoothId;
            var Categories = await _categoryApp.GetAll(cancellationToken);
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
            var products = await _productApp.GetAllByParentCategory(categoryId, cancellationToken);

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
            var products = await _productApp.GetAllByOwner(CurrentUserId, cancellationToken);

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


        public async Task<ActionResult> Delete(int productId, CancellationToken cancellationToken)
        {
            await _productApp.SoftDelete(productId, cancellationToken);
            return RedirectToAction("GetOwned");
        }

        public async Task<ActionResult> Edit(int productId, CancellationToken cancellationToken)
        {
            var Categories = await _categoryApp.GetAll(cancellationToken);
            var product = await _productApp.GetDetails(productId, cancellationToken);
            ProductUpdateViewModel updateViewModel = new ProductUpdateViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Brand = product.Brand,
                Grantee = product.Grantee,
                InformationDetails = product.InformationDetails,
                Description = product.Description,
                IncludedComponents = product.IncludedComponents,
                BasePrice = product.BasePrice,
                PicturesFile = product.Pictures.ToList(),
                CategoryId = product.CategoryId,
                UploadPictures = new List<IFormFile>(),
                Categories = Categories
            };

            return View(updateViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ProductUpdateViewModel productUpdate, CancellationToken cancellationToken)
        {

            if (ModelState.IsValid)
            {

                    ProductUpdateAppServiceDto productUpdateDto = new ProductUpdateAppServiceDto
                    {
                        Id = productUpdate.Id,
                        Name = productUpdate.Name,
                        Brand = productUpdate.Brand,
                        Grantee = productUpdate.Grantee,
                        InformationDetails = productUpdate.InformationDetails,
                        Description = productUpdate.Description,
                        IncludedComponents = productUpdate.IncludedComponents,
                        BasePrice = productUpdate.BasePrice,
                        UploadPictures = productUpdate.UploadPictures,
                        CategoryId = productUpdate.CategoryId,
                    };

                var resultMessage =  await _productApp.Update(productUpdateDto, CurrentUserId, _hostingEnvironment.WebRootPath, cancellationToken);

                if (resultMessage == "success")
                {
                    return RedirectToAction("GetOwned","Product");
                }
                else if (resultMessage == "owning Error")
                {
                    return Redirect("/Home/Error");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, resultMessage);
                };

            }
            return View(productUpdate);
        }


        public async Task<ActionResult> DeletePicture(int productId, int pictureId, CancellationToken cancellationToken)
        {
            await _productApp.DeletePicture(productId, pictureId, cancellationToken);
            return RedirectToAction(nameof(Edit), new { productId = productId });
        }
    }
}
