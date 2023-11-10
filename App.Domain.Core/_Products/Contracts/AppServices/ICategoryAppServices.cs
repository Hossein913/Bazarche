using App.Domain.Core._Products.Dtos.CategorieDtos;

namespace App.Domain.Core._Products.Contracts.AppServices;

public interface ICategoryAppServices
{
    Task<List<CategoryOutputDto>> GetAll(CancellationToken cancellationToken);
}
