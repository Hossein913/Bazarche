using App.Domain.Core._Products.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core._Products.Contracts.AppServices
{
    public interface IProductAppServices
    {
        Task<List<ProductOutputDto>> GetAll(CancellationToken cancellationToken);

        Task<List<ProductOutputDto>> GetAllToConfirm(CancellationToken cancellationToken);
        public Task<List<ProductOutputDto>> GetAllByParentCategory(int parentCategoryId, CancellationToken cancellationToken);
        public Task<List<ProductOutputDto>> GetAllByChildCategory(int ChildCategoryId, CancellationToken cancellationToken);
        Task<List<ProductOutputDto>> GetAllForBooth(int BoothId, CancellationToken cancellationToken);
        Task<List<ProductOutputDto>> GetAllForOrderItems(List<Dictionary<int, int>> ProductPrice, CancellationToken cancellationToken);
        Task<List<ProductOutputDto>> GetAllWithIdList(List<int> ProductIdList, CancellationToken cancellationToken);
        Task<List<ProductOutputDto>> GetAllByOwner(int appuserId, CancellationToken cancellationToken);
        Task<ProductOutputDto> GetDetails(int productId, CancellationToken cancellationToken);
        Task<ProductOutputDto> GetDetailWithRelation(int productId, CancellationToken cancellationToken);
        Task<List<ProductOutputDto>> GetPopularOrderedProducts(int ProductCount, CancellationToken cancellationToken);
        Task<int> Create(ProductAppServiceDto product, int CurrentUserId,string ProjectRouteAddress, CancellationToken cancellationToken);
        Task Update(ProductUpdateAppServiceDto productUpdateAppService, int CurrentUserId, string ProjectRouteAddress, CancellationToken CancellationToken);
        Task SoftDelete(int productId, CancellationToken cancellationToken);
        Task DeletePicture(int productid, int pictureid, CancellationToken cancellationToken);
        Task ConfirmProduct(int productId,bool status, CancellationToken cancellationToken);
    }

}
