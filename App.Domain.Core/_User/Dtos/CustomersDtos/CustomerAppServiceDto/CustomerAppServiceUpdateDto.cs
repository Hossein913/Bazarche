using App.Domain.Core._User.Dtos.ProvinceDto;
using App.Domain.Core._User.Enums;
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
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime? Birthdate { get; set; }

        public CustomerSexuality? SexualityId { get; set; }

        public IFormFile? UploadProfilePic { get; set; }

        public int? ProfilePicId { get; set; }

        #region UpdateAddress
        public int? ProvinceId { get; set; }

        public string City { get; set; } = null!;

        public string FullAddress { get; set; } = null!;

        public string PostalCode { get; set; } = null!;
        #endregion
    }
}

//Id { get; set; }
//FirstName { get; set; }
//LastName { get; set; }
//Birthdate { get; set; }
//SexualityId { get; set; }
//UploadProfilePic { get; set; }
//ProvinceId { get; set; }
//City { get; set; } 
//FullAddress { get; set; } 
//PostalCode { get; set; } 






