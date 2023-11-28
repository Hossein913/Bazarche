using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core._User.Dtos.CustomersDtos.CustomerAppServiceDto
{
    public class CustomerAppServiceUpdateDto
    {
        public int CustomerId { get; set; }

        public string? CustomerFirstName { get; set; }

        public string? CustomerLastName { get; set; }

        public DateTime? CustomerBirthdate { get; set; }

        public int? ProvinceId { get; set; }

        public string City { get; set; } = null!;

        public string FullAddress { get; set; } = null!;

        public string PostalCode { get; set; } = null!;

    }
}

//CustomerId { get; set; }
//CustomerFirstName { get; set; }
//CustomerLastName { get; set; }
//CustomerBirthdate { get; set; }
//ProvinceId { get; set; }
//City { get; set; } 
//FullAddress { get; set; } 
//PostalCode { get; set; } 