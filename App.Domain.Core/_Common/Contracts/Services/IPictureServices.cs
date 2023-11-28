using App.Domain.Core._Common.Dtos.PictureDtos;

namespace App.Domain.Core._Common.Contracts.Services;

public interface IPictureServices
{
    Task<PictureOutputDto> GetDetails(int pictureId, CancellationToken cancellationToken);
    Task<int> Create(PictureCreateDto picturedto, CancellationToken cancellationToken);
    Task Update(PictureUpdateDto picturedto, CancellationToken cancellationToken);
    Task HardDeleted(int picturedto, CancellationToken cancellationToken);
    Task SoftDeleted(int pictureId, CancellationToken cancellationToken);
}
