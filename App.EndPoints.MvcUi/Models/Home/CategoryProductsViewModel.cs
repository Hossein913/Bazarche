using App.Domain.Core._Products.Dtos.CategorieDtos;
using App.Domain.Core._Products.Dtos.ProductDtos;

namespace App.EndPoints.MvcUi.Models.Home
{
    public class CategoryProductsViewModel
    {
        public int Id { get; set; }
        public CategoryOutputDto Category { get; set; }
        public List<CategoryOutputDto> Categories { get; set; }
        public List<ProductOutputDto> Products { get; set; }
    }
}
