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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Product
{
    public class ProductAppServices : IProductAppServices
    {
        protected readonly ICategoryServices _categoryServices;
        protected readonly IProductServices _productServices;
        protected readonly IFileServices _fileServices;
        public ProductAppServices(
            ICategoryServices categoryServices,
            IProductServices productServices,
            IFileServices fileServices)
        {
            _categoryServices = categoryServices;
            _productServices = productServices;
            _fileServices = fileServices;
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
            var Products = await _productServices.GetAllByCategory(cancellationToken, categoryIds.ToArray());
            return Products;
        }

        public async Task<List<ProductOutputDto>> GetAllByChildCategory(int ChildCategoryId, CancellationToken cancellationToken)
        {
            var Products = await _productServices.GetAllByCategory(cancellationToken, ChildCategoryId);
            return Products;
        }

        public async Task<List<ProductOutputDto>> GetAllForBooth(int BoothId, CancellationToken cancellationToken)
        {
            var result = await _productServices.GetAllForBooth(BoothId, cancellationToken);
            return result;
        }

        public async Task<List<ProductOutputDto>> GetAllForOrderItems(List<Dictionary<int, int>> ProductPrice, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductOutputDto>> GetAllWithIdList(List<int> ProductIdList, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductOutputDto> GetDetail(int productId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
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
