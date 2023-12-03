﻿using App.Domain.Core._Products.Contracts.AppServices;
using App.Domain.Core._Products.Contracts.Services;
using App.Domain.Core._Products.Dtos.BoothProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Product
{
    public class BoothProductAppServices : IBoothProductAppServices
    {
        protected readonly IBoothProductServices _boothProductServices;

        public BoothProductAppServices(IBoothProductServices boothProductServices)
        {
            _boothProductServices = boothProductServices;
        }

        public async Task Create(BoothProductCreateDto boothProduct, CancellationToken cancellationToken)
        {
            await _boothProductServices.Create(boothProduct, cancellationToken);
        }

        public async Task<List<BoothProductOutputDto>> GetAllForProduct(int ProductId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetProductIdAsync(int boothProductId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task SoftDelete(int BoothProductId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task Update(BoothProductUpdateDto boothProduct, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
