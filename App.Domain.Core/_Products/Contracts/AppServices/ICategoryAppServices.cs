﻿using App.Domain.Core._Products.Dtos.CategorieDtos;

namespace App.Domain.Core._Products.Contracts.AppServices;

public interface ICategoryAppServices
{
    Task<List<CategoryOutputDto>> GetAll(CancellationToken cancellationToken);
    Task<CategoryOutputDto> GetById(int Id, CancellationToken cancellationToken);
    Task Create(CategoryCreateDto category, CancellationToken cancellationToken);
    Task Update(CategoryUpdateDto categor, CancellationToken cancellationToken);
    Task HardDelte(int categoryId, CancellationToken cancellationToken);
}
