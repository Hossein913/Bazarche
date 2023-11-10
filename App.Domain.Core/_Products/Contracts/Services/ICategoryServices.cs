using App.Domain.Core._Products.Dtos.CategorieDtos;

namespace App.Domain.Core._Products.Contracts.Services;

public interface ICategoryServices
{
    Task<List<CategoryOutputDto>> GetAll(CancellationToken cancellationToken);

}
