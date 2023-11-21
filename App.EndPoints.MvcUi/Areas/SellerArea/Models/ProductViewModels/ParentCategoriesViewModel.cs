using App.Domain.Core._Common.Entities;
using App.Domain.Core._Products.Entities;

namespace App.EndPoints.MvcUi.Areas.SellerArea.Models.ProductViewModels
{
    public class ParentCategoriesViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public int? ParentId { get; set; }

        public string PictureFileName { get; set; }

        public ICollection<Category> Subcategories { get; set; }
        public Picture? Picture { get; set; }
    }
}

