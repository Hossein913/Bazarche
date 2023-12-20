using App.Domain.Core._Products.Contracts.AppServices;
using App.Domain.Core._Products.Contracts.Services;
using App.Domain.Core._Products.Dtos.BoothProductDtos;
using App.Domain.Core._Products.Entities;
using App.Domain.Core._Products.Enums;
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

        public async Task ChangeBoothProductState(int boothProductId, bool status, CancellationToken cancellationToken)
        {
            BoothProductStatus boothProductStatus;
            if (status)
            {
                boothProductStatus = BoothProductStatus.Active;
            }
            else
            {
                boothProductStatus = BoothProductStatus.Active;
            }
            await _boothProductServices.ChangeBoothProductState(boothProductId, boothProductStatus, cancellationToken);
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
        public async Task SetActivity(int BoothProductId, CancellationToken cancellationToken)
        {
            await _boothProductServices.SetActivity(BoothProductId, cancellationToken);
        }

        public async Task Update(BoothProductUpdateDto boothProduct, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
