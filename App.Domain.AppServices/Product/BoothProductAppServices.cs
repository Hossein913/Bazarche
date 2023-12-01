using App.Domain.Core._Products.Contracts.AppServices;
using App.Domain.Core._Products.Contracts.Services;
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

    }
}
