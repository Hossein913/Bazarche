using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core._Products.Dtos.ProductDtos
{
    public class ProductAppServiceDto
    {

        public string Name { get; set; }

        public string Brand { get; set; }

        public string Grantee { get; set; }

        public string InformationDetails { get; set; }

        public string Description { get; set; }

        public string IncludedComponents { get; set; }

        public int BasePrice { get; set; }

        public List<IFormFile> Pictures { get; set; }

        public int CategoryId { get; set; }

        public int CreatedBy { get; set; }
    }
}


//Name 
//Brand 
//Grantee 
//InformationDetails 
//Description 
//IncludedComponents
//BasePrice 
//Pictures 
//CategoryId 