using App.Domain.Core.Common.Dtos.Pictures;
using App.Domain.Core.Common.Entities;
using App.Domain.Core.Products.Dtos.Categories;

namespace App.Domain.Core.Common.Contracts.IRepositories;

public interface IPictureRepository
{
    Task<List<PictureOutputDto>> GetProductPicture(int ProductId,CancellationToken cancellationToken);
    Task<PictureOutputDto> GetDatail(int categoryId, CancellationToken cancellationToken);
    Task Create(PictureCreateDto picturedto , CancellationToken cancellationToken);
    Task Update(PictureUpdateDto picturedto, CancellationToken cancellationToken);
    Task HardDelted(int picturedto, CancellationToken cancellationToken);
}
