using App.Domain.Core._Booth.Dtos.BoothDtos;

namespace App.Domain.Core._Booth.Contracts.AppServices;

public interface IBoothAppServices
{
    Task<List<BoothOutputDto>> GetAllHome(CancellationToken cancellationToken);
}
