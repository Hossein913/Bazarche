using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace App.Domain.Core._User.Dtos.SellersDtos.SellerAppServiceDto
{
    public class SellerRegisterDto
    {

        #region SellerViewModel

        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }


        public string LastName { get; set; }

        public string ShabaNumber { get; set; }
        #endregion

        #region AddressViewModel 

        public int ProvinceId { get; set; }

        public string? City { get; set; }

        public string? Address { get; set; }

        public string? PostalCode { get; set; }
        #endregion

        #region BoothViewModel

        public string BoothName { get; set; }

        public string Description { get; set; }

        public IFormFile BoothAvatar { get; set; }
        #endregion


    }
}

//Email { get; set; }
//Password { get; set; }
//ConfirmPassword { get; set; }
//FirstName { get; set; }
//LastName { get; set; }
//ShabaNumber { get; set; }
//ProvinceId { get; set; }
//City { get; set; }
//Address { get; set; }
//PostalCode { get; set; }
//BoothName { get; set; }
//Description { get; set; }
//BoothAvatar { get; set; }
