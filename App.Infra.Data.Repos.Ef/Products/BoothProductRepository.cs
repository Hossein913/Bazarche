using App.Domain.Core._Products.Contracts.Repositories;
using App.Domain.Core._Products.Dtos.BoothProductDtos;
using App.Infra.Data.SqlServer.Ef.DbCntx;

namespace App.Infra.Data.Repos.Ef.Products;

public class BoothProductRepository : IBoothProductRepository
{
    private readonly BazarcheContext _context;

    public BoothProductRepository(BazarcheContext context)
    {
        _context = context;
    }

    public Task Create(BoothProductCreateDto boothProduct, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<BoothProductOutputDto>> GetAllForBooth(int boothtId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<BoothProductOutputDto>> GetAllForProduct(int ProductId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<BoothProductOutputDto> GetDatail(int boothProductId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SoftDelete(int BoothProductId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Update(BoothProductUpdateDto boothProduct, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
