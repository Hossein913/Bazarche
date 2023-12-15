using App.Domain.Core._Common.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core._Products.Dtos.ProductDtos
{
    public class ProductUpdateAppServiceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Brand { get; set; }

        public string Grantee { get; set; }

        public string InformationDetails { get; set; }

        public string Description { get; set; }

        public string IncludedComponents { get; set; }

        public int BasePrice { get; set; }

        public List<IFormFile> UploadPictures { get; set; }

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
//UploadPictures
//Pictures 
//CategoryId 