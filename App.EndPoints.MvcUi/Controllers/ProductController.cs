using App.Domain.Core._Booth.Contracts.AppServices;
using App.Domain.Core._Products.Contracts.AppServices;
using App.Domain.Core._Products.Dtos.CommentDtos;
using App.Domain.Core._Products.Dtos.ProductDtos;
using App.Domain.Core._Products.Entities;
using App.Domain.Core._Products.Enums;
using App.EndPoints.MvcUi.Models._Customer;
using App.EndPoints.MvcUi.Models.Home;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MvcUi.Controllers
{
    [AllowAnonymous]
    public class ProductController : Controller
    {

        private readonly IBoothAppServices _boothAppServices;
        private readonly IProductAppServices _productAppServices;

        public ProductController(
            IBoothAppServices boothAppServices,
            IProductAppServices productAppServices)
        {
            _boothAppServices = boothAppServices;
            _productAppServices = productAppServices;
        }
        [HttpGet]

        public async Task<IActionResult> ParentCategoryProducts(int id, CancellationToken cancellationToken)
        {
            var Products = await _productAppServices
                .GetAllByParentCategory(id, cancellationToken);

            var ProductViewModel = Products.Select<ProductOutputDto, ProductViewModel>(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Brand = p.Grantee,
                AvatarFileUrl = p.Avatar,
                Description = p.Description,
                MaxPrice = p.MinPrice,
                MinPrice = p.MaxPrice,
            }).ToList();
            return View("CategoryProduct", ProductViewModel);

        }

        [HttpGet]
        public async Task<IActionResult> ChildCategoryProducts(int id, CancellationToken cancellationToken)
        {
            var Products = await _productAppServices.GetAllByChildCategory(id, cancellationToken);
            var ProductViewModel = Products.Select<ProductOutputDto, ProductViewModel>(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Brand = p.Grantee,
                AvatarFileUrl = p.Avatar,
                Description = p.Description,
                MaxPrice = p.MinPrice,
                MinPrice = p.MaxPrice,
            }).ToList();

            return View("CategoryProduct", ProductViewModel);
        }


        [HttpGet]
        public async Task<IActionResult> BoothProducts(int boothid, CancellationToken cancellationToken)
        {
            var BoothDetail = await _boothAppServices.GetDetails(boothid, cancellationToken);
            var Products = await _productAppServices.GetAllForBooth(boothid, cancellationToken);
            var ProductViewModel = Products.Select<ProductOutputDto, ProductViewModel>(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Brand = p.Grantee,
                AvatarFileUrl = p.Avatar,
                Description = p.Description,
                BoothPrice = p.BoothProducts.FirstOrDefault(bp => bp.Status == Convert.ToBoolean((int)BoothProductStatus.Active)),
            }).ToList();
            //------checking the BoothProducts status is just for show the active one and others
            //will use for price history

            BoothWithProductsViewModel boothWithProducts = new BoothWithProductsViewModel
            {
                id = BoothDetail.Id,
                Name = BoothDetail.Name,
                Description = BoothDetail.Description,
                AvatarUrl = BoothDetail.AvatarPicture.ImageUrl,
                MedalName = BoothDetail.Medal.Name,
                products = ProductViewModel
            };
            return View(boothWithProducts);
        }



        [HttpGet]
        public async Task<IActionResult> ProductFullPage(int productId, CancellationToken cancellationToken)
        {
            var product = await _productAppServices.GetDetails(productId, cancellationToken);
            ProductViewModel productViewModel = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Brand = product.Brand,
                Grantee = product.Grantee,
                InformationDetails = product.InformationDetails,
                Description = product.Description,
                IncludedComponents = product.IncludedComponents,
                Comments = product.Comments.ToList(),
                Pictures = product.Pictures,
                BoothProducts = product.BoothProducts
                      .OrderBy(p => p.Price)
                      .Where(p => p.Status == Convert.ToBoolean((int)BoothProductStatus.Active))
                      .Select(bp => new ProductBoothPricesViewModel {
                                    Id = bp.Id,
                                    Price = bp.Price,
                                    Booth = new BoothViewModel 
                                            {
                                                Id = bp.Booth.Id ,
                                                Name = bp.Booth.Name ,
                                                MedalName = bp.Booth.Medal.Name ,
                                            }
                      })        
                      .ToList(),        
                        
            };

            return View(productViewModel);
        }
    }
}
 