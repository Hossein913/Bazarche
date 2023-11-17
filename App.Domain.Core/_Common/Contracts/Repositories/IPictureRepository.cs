using App.Domain.Core._Common.Dtos.PictureDtos;

namespace App.Domain.Core._Common.Contracts.Repositories;

public interface IPictureRepository
{
//    Task<List<PictureOutputDto>> GetProductPicture(int ProductId, CancellationToken cancellationToken);
//    Task<PictureOutputDto> GetDetail(int categoryId, CancellationToken cancellationToken);
    Task Create(PictureCreateDto picturedto, CancellationToken cancellationToken);
    Task Update(PictureUpdateDto picturedto, CancellationToken cancellationToken);
    Task HardDeleted(int picturedto, CancellationToken cancellationToken);
    Task SoftDeleted(int pictureId, CancellationToken cancellationToken);
}
