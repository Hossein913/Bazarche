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
        public int SellerId { get; set; }
        public string? SellerFirstName { get; set; }

        public string? SellerLastName { get; set; }

        public DateTime? SellerBirthdate { get; set; }

        public string? SellerShabaNumber { get; set; }

        public int? ProvinceId { get; set; }

        public string City { get; set; } = null!;

        public string FullAddress { get; set; } = null!;

        public string PostalCode { get; set; } = null!;

        public int? ProfilePicId { get; set; }

        public IFormFile? SellerProfilePicFile { get; set; }

    }
}

//SellerFirstName { get; set; }
//SellerLastName { get; set; }
//SellerBirthdate { get; set; }
//SellerShabaNumber { get; set; }
//ProvinceId { get; set; }
//City { get; set; } 
//FullAddress { get; set; } 
//PostalCode { get; set; } 
//ProfilePicName { get; set; }
//SellerProfilePicFile { get; set; }
//BoothName { get; set; }
//Description { get; set; }
//AvatarPictureName { get; set; }
//BoothAvatarFile { get; set; }