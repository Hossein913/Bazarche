using App.Domain.Core._Products.Dtos.CategorieDtos;

namespace App.EndPoints.MvcUi.Areas.SellerArea.Models.ProductViewModels
{
    public class CreateProductFormViewModel
    {
        public ProductCreateViewModel Product { get; set; }
        public List<CategoryOutputDto> Categories { get; set; }
    }
}
