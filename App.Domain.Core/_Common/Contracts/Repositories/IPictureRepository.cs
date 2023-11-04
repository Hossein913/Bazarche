using App.Domain.Core._Common.Dtos.PictureDtos;

namespace App.Domain.Core._Common.Contracts.Repositories;

public interface IPictureRepository
{
    Task<List<PictureOutputDto>> GetProductPicture(int ProductId, CancellationToken cancellationToken);
    Task<PictureOutputDto> GetDatail(int categoryId, CancellationToken cancellationToken);
    Task Create(PictureCreateDto picturedto, CancellationToken cancellationToken);
    Task Update(PictureUpdateDto picturedto, CancellationToken cancellationToken);
    Task HardDelted(int picturedto, CancellationToken cancellationToken);
}
