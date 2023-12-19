using App.Domain.Core._Booth.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core._User.Dtos.SellersDtos.SellerAppServiceDto
{
    public class SellerAppServiceUpdateDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime? Birthdate { get; set; }

        public string? ShabaNumber { get; set; }

        public int? ProvinceId { get; set; }

        public string City { get; set; } = null!;

        public string FullAddress { get; set; } = null!;

        public string PostalCode { get; set; } = null!;

        public int? ProfilePicId { get; set; }

        public IFormFile? SellerProfilePicFile { get; set; }

    }
}

//Id { get; set; }
//FirstName { get; set; }
//LastName { get; set; }
//Birthdate { get; set; }
//ShabaNumber { get; set; }
//ProvinceId { get; set; }
//City { get; set; }
//FullAddress { get; set; } 
//PostalCode { get; set; } 
//ProfilePicId { get; set; }
//SellerProfilePicFile { get; set; }
