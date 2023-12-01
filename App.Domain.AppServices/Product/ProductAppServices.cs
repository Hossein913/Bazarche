using App.Domain.Core._Booth.Entities;
using App.Domain.Core._Common.Contracts.Services;
using App.Domain.Core._Common.Dtos.PictureDtos;
using App.Domain.Core._Common.Entities;
using App.Domain.Core._Common.Enums;
using App.Domain.Core._Products.Contracts.AppServices;
using App.Domain.Core._Products.Contracts.Services;
using App.Domain.Core._Products.Dtos.ProductDtos;
using App.Domain.Core._Products.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Product
{
    public class ProductAppServices : IProductAppServices
    {
        protected readonly ICategoryServices _categoryServices;
        protected readonly IProductServices _productServices;
        protected readonly IOrderItemServices _orderItemServices;
        protected readonly IBoothProductServices _boothProductServices;
        protected readonly IFileServices _fileServices;
        protected readonly ICommentServices _commentServices;
        public ProductAppServices(
            ICategoryServices categoryServices,
            IProductServices productServices,
            IFileServices fileServices,
            IOrderItemServices orderItemServices,
            IBoothProductServices boothProductServices,
            ICommentServices commentServices)
        {
            this._categoryServices = categoryServices;
            _productServices = productServices;
            _fileServices = fileServices;
            _orderItemServices = orderItemServices;
            _boothProductServices = boothProductServices;
            _commentServices = commentServices;
        }

        public async Task<int> Create(ProductAppServiceDto product,int CurrentUserId, string ProjectRouteAddress, CancellationToken cancellationToken)
        {

            ICollection<Picture> pictures = new List<Picture>();

            foreach (var PhotoFile in product.Pictures)
            {
                var photoName =await _fileServices.FileUploadAsync(PhotoFile, FileServicesEntityType.Product, ProjectRouteAddress);
                Picture picture = new Picture
                {
                    ImageUrl = photoName,
                    CreatedAt = DateTime.Now,
                    CreatedBy = CurrentUserId,
                    IsDeleted = false

                };
                pictures.Add(picture);
            }

            ProductCreateDto productCreateDto = new ProductCreateDto
            {
                Name = product.Name,
                Brand = product.Brand,
                Grantee = product.Grantee,
                InformationDetails = product.InformationDetails,
                Description = product.Description,
                IncludedComponents = product.IncludedComponents,
                BasePrice = product.BasePrice,
                CategoryId = 13,
                IsConfirmed = null,
                CreatedAt = DateTime.Now,
                CreatedBy = CurrentUserId,
                IsDeleted = false,
                Pictures = pictures
            };

            await _productServices.Create(productCreateDto, cancellationToken);

            return 1;
        }

        public async Task<List<ProductOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductOutputDto>> GetAllByParentCategory(int parentCategoryId, CancellationToken cancellationToken)
        {
            List<int> categoryIds = new List<int>();
            var categoryResult = await _categoryServices.GetById(parentCategoryId, cancellationToken);
            foreach (var item in categoryResult.Subcategories)
            {
                categoryIds.Add(item.Id);
            }
            var products = await _productServices.GetAllByCategory(cancellationToken, categoryIds.ToArray());
            var ConfirmedProducts = products.Where(p => p.IsConfirmed==true).ToList();
            return ConfirmedProducts;
        }

        public async Task<List<ProductOutputDto>> GetAllByChildCategory(int ChildCategoryId, CancellationToken cancellationToken)
        {
            var products = await _productServices.GetAllByCategory(cancellationToken, ChildCategoryId);
            var ConfirmedProducts = products.Where(p => p.IsConfirmed == true).ToList();
            return ConfirmedProducts;
        }

        public async Task<List<ProductOutputDto>> GetAllForBooth(int BoothId, CancellationToken cancellationToken)
        {
            var products = await _productServices.GetAllForBooth(BoothId, cancellationToken);
            var ConfirmedProducts = products.Where(p => p.IsConfirmed == true).ToList();
            return ConfirmedProducts;
        }

        public async Task<List<ProductOutputDto>> GetAllForOrderItems(List<Dictionary<int, int>> ProductPrice, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductOutputDto>> GetAllWithIdList(List<int> ProductIdList, CancellationToken cancellationToken)
        {
            var products = await _productServices.GetAllWithIdList(ProductIdList, cancellationToken);
            var ConfirmedProducts = products.Where(p => p.IsConfirmed == true).ToList();
            return ConfirmedProducts;
        }
        public async Task<List<ProductOutputDto>> GetPopularOrderedProducts(int ProductCount, CancellationToken cancellationToken)
        {
           var ProductId = await _orderItemServices.GetPopularOrderedProductsId(ProductCount, cancellationToken);
           var products = await _productServices.GetAllWithIdList(ProductId, cancellationToken);
           var ConfirmedProducts = products.Where(p => p.IsConfirmed == true).ToList();
           return ConfirmedProducts;
        }

        public async Task<ProductOutputDto> GetDetails(int productId, CancellationToken cancellationToken)
        {
            var comments = await _commentServices.GetAllForProduct(productId, cancellationToken);
           var product = await _productServices.GetDetails(productId, cancellationToken);
           var productPrices =await _boothProductServices.GetAllForProduct(productId, cancellationToken);
           product.BoothProducts = productPrices.Select(bp => new BoothProduct
           {
               Id = bp.Id,
               Price = bp.Price,
               Count = bp.Count,
               Status = bp.Status,
               CreatedAt = bp.CreatedAt,
               Booth = bp.Booth,
               

           }).ToList();

           product.Comments = comments.OrderBy(c => c.CreatedAt).ToList();

            return product;
            }

        public async Task SoftDelete(int productId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task Update(ProductUpdateDto product, CancellationToken CancellationToken)
        {
            throw new NotImplementedException();
        }


    }
}
