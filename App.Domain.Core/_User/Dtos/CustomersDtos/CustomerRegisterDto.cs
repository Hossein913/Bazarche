using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace App.Domain.Core._User.Dtos.CustommersDtos
{
    public class CustomerRegisterDto
    {

        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int ProvinceId { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string PostalCode { get; set; }

    }
}

//Email { get; set; }
//Password { get; set; }
//FirstName { get; set; }
//LastName { get; set; }
//ProvinceId { get; set; }
//City { get; set; }
//Address { get; set; }
//PostalCode { get; set; }
