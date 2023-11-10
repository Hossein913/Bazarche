using App.Domain.Core._Booth.Dtos.BoothDtos;

namespace App.Domain.Core._Booth.Contracts.Services;

public interface IBoothServices
{
    Task<List<BoothOutputDto>> GetAllHome(CancellationToken cancellationToken);
}
