using App.Domain.Core._Common.Entities;
using App.Domain.Core._Products.Entities;

namespace App.EndPoints.MvcUi.Areas.SellerArea.Models.ProductViewModels
{
    public class ProductListViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Brand { get; set; } = null!;

        public string? Avatar { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int BasePrice { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}

//Id { get; set; }
//Name { get; set; } 
//Brand { get; set; }
//Avatar { get; set; } 
//Description { get; set; }
//BasePrice { get; set; }
//CreatedAt { get; set; }