using App.Domain.Core.Common.Contracts.IRepositories;
using App.Domain.Core.Common.Dtos.Pictures;

namespace App.Infra.Data.Repos.Ef.Commons;

public class PictureRepository : IPictureRepository
{
    public Task Create(PictureCreateDto picturedto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<PictureOutputDto> GetDatail(int categoryId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<PictureOutputDto>> GetProductPicture(int ProductId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task HardDelted(int picturedto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Update(PictureUpdateDto picturedto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
