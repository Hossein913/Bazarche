using App.Domain.AppServices.Product;
using App.Domain.Core._Common.Entities;
using App.Domain.Core._Products.Contracts.AppServices;
using App.Domain.Core._Products.Dtos.ProductDtos;
using App.Domain.Core._Products.Entities;
using App.Domain.Core._Products.Enums;
using App.EndPoints.MvcUi.Areas.AdminArea.ViewModels.Product;
using App.EndPoints.MvcUi.Models.Home;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;

namespace App.EndPoints.MvcUi.Areas.AdminArea.Controllers
{
    public class ProductController : AdminBaseController
    {
        protected readonly IProductAppServices _productApp;
        protected readonly IBoothProductAppServices _boothProductApp;
        protected readonly ICategoryAppServices _categoryApp;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ProductController(
            IProductAppServices productApp,
            IWebHostEnvironment hostingEnvironment,
            ICategoryAppServices categoryApp,
            IBoothProductAppServices boothProductApp)
        {
            _productApp = productApp;
            _hostingEnvironment = hostingEnvironment;
            _categoryApp = categoryApp;
            _boothProductApp = boothProductApp;
        }

       
        public async Task<ActionResult> Index(CancellationToken cancellationToken)
        {
            var products = await _productApp.GetAll(cancellationToken);
            List<GetAllProductViewModel> productsViewModel = products
                .Select<ProductOutputDto, GetAllProductViewModel>(p => 
                new GetAllProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Avatar = p.Avatar,
                    Description = p.Description,
                    IsConfirmed = p.IsConfirmed,
                    BasePrice = p.BasePrice,
                    CreatedAt = p.CreatedAt
                }).OrderByDescending(p => p.IsConfirmed).ThenBy(p => p.Id).ToList();
            return View(productsViewModel);
        }

        public async Task<ActionResult> GetAllToConfirm(CancellationToken cancellationToken)
        {
            var products = await _productApp.GetAllToConfirm(cancellationToken);
            List<GetAllProductViewModel> productsViewModel = products
                .Select<ProductOutputDto, GetAllProductViewModel>(p => new GetAllProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Avatar = p.Avatar,
                    Description = p.Description,
                    BasePrice = p.BasePrice,
                    CreatedAt = p.CreatedAt
                }).ToList();
            return View(productsViewModel);
        }

        public async Task<ActionResult> Details(int id, CancellationToken cancellationToken)
        {
            var product = await _productApp.GetDetails(id, cancellationToken);
            GetProductDetailsViewModel ProductDetails = new GetProductDetailsViewModel
            {

                Id= product.Id ,
                Name= product.Name ,
                Brand= product.Brand ,
                Avatar= product.Avatar ,
                Grantee= product.Grantee ,
                InformationDetails= product.InformationDetails,
                Description= product.Description ,
                IncludedComponents= product.IncludedComponents ,
                IsConfirmed= product.IsConfirmed ,
                BasePrice= product.BasePrice ,
                CreatedAt= product.CreatedAt ,
                CategoryId= product.CategoryId ,
                Pictures= product.Pictures ,
                BoothProducts= product.BoothProducts , 
                
            };
            return View(ProductDetails);
        }

        public async Task<ActionResult> Create(CancellationToken cancellationToken)
        {
            var Categories = await _categoryApp.GetAll(cancellationToken);
            ProductCreateViewModel productCreate = new ProductCreateViewModel
            {
                Categories = Categories
            };
            return View(productCreate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductCreateViewModel productViewModel,CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                if (productViewModel.UploadPictures != null)
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
                        Pictures = productViewModel.UploadPictures,
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
                        return RedirectToAction("Create");
                    }

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "تصویری برای کالا انتخاب نشده است.");
                }
            }
            return View(productViewModel);
        }

        public async Task<ActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            var Categories = await _categoryApp.GetAll(cancellationToken);
            var product = await _productApp.GetDetails(id,cancellationToken);
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
                        Name = productUpdate.Name ,
                        Brand = productUpdate.Brand ,
                        Grantee = productUpdate.Grantee ,
                        InformationDetails = productUpdate.InformationDetails ,
                        Description = productUpdate.Description ,
                        IncludedComponents = productUpdate.IncludedComponents ,
                        BasePrice = productUpdate.BasePrice ,
                        UploadPictures = productUpdate.UploadPictures ,
                        CategoryId = productUpdate.CategoryId ,
                    };
                var resultMessage = await _productApp.Update(productUpdateDto,CurrentUserId, _hostingEnvironment.WebRootPath, cancellationToken);
               
                if (resultMessage == "success")
                {
                    return RedirectToAction("Details", new {id =  productUpdate.Id});

                }else
                {
                    ModelState.AddModelError(string.Empty, resultMessage);
                };

            }
            return View(productUpdate);
        }

        public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken)
        {
           await _productApp.SoftDelete(id, cancellationToken);
           return RedirectToAction("GetAllToConfirm");
        }

        public async Task<ActionResult> Confirm(int productId,bool status, CancellationToken cancellationToken)
        {
            await _productApp.ConfirmProduct(productId, status, cancellationToken);
            return Redirect(Request.Headers["referer"].ToString());
        }

        public async Task<ActionResult> DeletePicture(int productId, int pictureId, CancellationToken cancellationToken)
        {
            await _productApp.DeletePicture(productId, pictureId, cancellationToken);
            return RedirectToAction(nameof(Edit), new { id = productId });
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

        public async Task<ActionResult> EditBoothProduct(int boothProductId, bool status, CancellationToken cancellationToken)
        {
            await _boothProductApp.ChangeBoothProductState(boothProductId, status, cancellationToken);
            return Redirect(Request.Headers["referer"].ToString());
        }
    }
}


